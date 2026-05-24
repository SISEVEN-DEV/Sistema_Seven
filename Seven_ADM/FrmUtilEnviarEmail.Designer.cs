namespace Seven_Sistema
{
    partial class FrmUtilEnviarEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUtilEnviarEmail));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnFuncionario = new System.Windows.Forms.Button();
            this.btnPesquisarForn = new System.Windows.Forms.Button();
            this.btnProcurarCliente = new System.Windows.Forms.Button();
            this.lblAsterisco4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblAsterisco3 = new System.Windows.Forms.Label();
            this.lblAsterisco2 = new System.Windows.Forms.Label();
            this.txtMeuEmail = new System.Windows.Forms.TextBox();
            this.lblMeuEmail = new System.Windows.Forms.Label();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.lblQtdeCar = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.txtAnexo = new System.Windows.Forms.TextBox();
            this.lblQtde = new System.Windows.Forms.Label();
            this.lblArquivosAnexados = new System.Windows.Forms.Label();
            this.btnLimparAnexo = new System.Windows.Forms.Button();
            this.btnAnexar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAssunto = new System.Windows.Forms.TextBox();
            this.lblAssunto = new System.Windows.Forms.Label();
            this.txtPara = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.btnSair = new System.Windows.Forms.Button();
            this.pcibAnexo = new System.Windows.Forms.PictureBox();
            this.ttpEmail = new System.Windows.Forms.ToolTip(this.components);
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.grbBox1.SuspendLayout();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibAnexo)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.txtMsg);
            this.grbBox1.Controls.Add(this.btnFuncionario);
            this.grbBox1.Controls.Add(this.btnPesquisarForn);
            this.grbBox1.Controls.Add(this.btnProcurarCliente);
            this.grbBox1.Controls.Add(this.lblAsterisco4);
            this.grbBox1.Controls.Add(this.txtNome);
            this.grbBox1.Controls.Add(this.lblNome);
            this.grbBox1.Controls.Add(this.lblAsterisco3);
            this.grbBox1.Controls.Add(this.lblAsterisco2);
            this.grbBox1.Controls.Add(this.txtMeuEmail);
            this.grbBox1.Controls.Add(this.lblMeuEmail);
            this.grbBox1.Controls.Add(this.lblAsterisco1);
            this.grbBox1.Controls.Add(this.lblQtdeCar);
            this.grbBox1.Controls.Add(this.grbBox2);
            this.grbBox1.Controls.Add(this.btnEnviar);
            this.grbBox1.Controls.Add(this.label3);
            this.grbBox1.Controls.Add(this.txtAssunto);
            this.grbBox1.Controls.Add(this.lblAssunto);
            this.grbBox1.Controls.Add(this.txtPara);
            this.grbBox1.Controls.Add(this.label1);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(840, 310);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Novo E-mail:";
            // 
            // txtMsg
            // 
            this.txtMsg.BackColor = System.Drawing.Color.White;
            this.txtMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsg.Location = new System.Drawing.Point(6, 167);
            this.txtMsg.MaxLength = 500;
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(410, 123);
            this.txtMsg.TabIndex = 9;
            this.txtMsg.TextChanged += new System.EventHandler(this.txtMsg_TextChanged);
            this.txtMsg.Enter += new System.EventHandler(this.txtMsg_Enter);
            this.txtMsg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMsg_KeyPress);
            this.txtMsg.Leave += new System.EventHandler(this.txtMsg_Leave);
            // 
            // btnFuncionario
            // 
            this.btnFuncionario.Image = ((System.Drawing.Image)(resources.GetObject("btnFuncionario.Image")));
            this.btnFuncionario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFuncionario.Location = new System.Drawing.Point(328, 97);
            this.btnFuncionario.Name = "btnFuncionario";
            this.btnFuncionario.Size = new System.Drawing.Size(85, 25);
            this.btnFuncionario.TabIndex = 7;
            this.btnFuncionario.Text = "&Funcionário";
            this.btnFuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEmail.SetToolTip(this.btnFuncionario, "Clique para pesquisar umFuncionário.");
            this.btnFuncionario.UseVisualStyleBackColor = true;
            this.btnFuncionario.Click += new System.EventHandler(this.btnFuncionario_Click);
            this.btnFuncionario.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.btnFuncionario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // btnPesquisarForn
            // 
            this.btnPesquisarForn.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisarForn.Image")));
            this.btnPesquisarForn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisarForn.Location = new System.Drawing.Point(237, 97);
            this.btnPesquisarForn.Name = "btnPesquisarForn";
            this.btnPesquisarForn.Size = new System.Drawing.Size(85, 25);
            this.btnPesquisarForn.TabIndex = 6;
            this.btnPesquisarForn.Text = "For&necedor";
            this.btnPesquisarForn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEmail.SetToolTip(this.btnPesquisarForn, "Clique para pesquisar um Fornecedor.");
            this.btnPesquisarForn.UseVisualStyleBackColor = true;
            this.btnPesquisarForn.Click += new System.EventHandler(this.btnPesquisarForn_Click);
            this.btnPesquisarForn.MouseLeave += new System.EventHandler(this.btnPesquisarForn_MouseLeave);
            this.btnPesquisarForn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisarForn_MouseMove);
            // 
            // btnProcurarCliente
            // 
            this.btnProcurarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarCliente.Image")));
            this.btnProcurarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcurarCliente.Location = new System.Drawing.Point(107, 97);
            this.btnProcurarCliente.Name = "btnProcurarCliente";
            this.btnProcurarCliente.Size = new System.Drawing.Size(124, 25);
            this.btnProcurarCliente.TabIndex = 5;
            this.btnProcurarCliente.Text = "&Cliente/Consumidor";
            this.btnProcurarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEmail.SetToolTip(this.btnProcurarCliente, "Clique para pesquisar um Cliente/Consumidor.");
            this.btnProcurarCliente.UseVisualStyleBackColor = true;
            this.btnProcurarCliente.Click += new System.EventHandler(this.btnProcurarCliente_Click);
            this.btnProcurarCliente.MouseLeave += new System.EventHandler(this.btnProcurarCliente_MouseLeave);
            this.btnProcurarCliente.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarCliente_MouseMove);
            // 
            // lblAsterisco4
            // 
            this.lblAsterisco4.AutoSize = true;
            this.lblAsterisco4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco4.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco4.Location = new System.Drawing.Point(98, 45);
            this.lblAsterisco4.Name = "lblAsterisco4";
            this.lblAsterisco4.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco4.TabIndex = 0;
            this.lblAsterisco4.Text = "*";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(111, 45);
            this.txtNome.MaxLength = 60;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(300, 20);
            this.txtNome.TabIndex = 3;
            this.txtNome.Enter += new System.EventHandler(this.txtNome_Enter);
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            this.txtNome.Leave += new System.EventHandler(this.txtNome_Leave);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(43, 48);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(60, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Meu nome:";
            // 
            // lblAsterisco3
            // 
            this.lblAsterisco3.AutoSize = true;
            this.lblAsterisco3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco3.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco3.Location = new System.Drawing.Point(237, 148);
            this.lblAsterisco3.Name = "lblAsterisco3";
            this.lblAsterisco3.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco3.TabIndex = 46;
            this.lblAsterisco3.Text = "*";
            // 
            // lblAsterisco2
            // 
            this.lblAsterisco2.AutoSize = true;
            this.lblAsterisco2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco2.Location = new System.Drawing.Point(98, 19);
            this.lblAsterisco2.Name = "lblAsterisco2";
            this.lblAsterisco2.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco2.TabIndex = 0;
            this.lblAsterisco2.Text = "*";
            // 
            // txtMeuEmail
            // 
            this.txtMeuEmail.BackColor = System.Drawing.Color.White;
            this.txtMeuEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeuEmail.Location = new System.Drawing.Point(111, 19);
            this.txtMeuEmail.MaxLength = 60;
            this.txtMeuEmail.Name = "txtMeuEmail";
            this.txtMeuEmail.Size = new System.Drawing.Size(300, 20);
            this.txtMeuEmail.TabIndex = 2;
            this.txtMeuEmail.Enter += new System.EventHandler(this.txtMeuEmail_Enter);
            this.txtMeuEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMeuEmail_KeyPress);
            this.txtMeuEmail.Leave += new System.EventHandler(this.txtMeuEmail_Leave);
            // 
            // lblMeuEmail
            // 
            this.lblMeuEmail.AutoSize = true;
            this.lblMeuEmail.Location = new System.Drawing.Point(42, 22);
            this.lblMeuEmail.Name = "lblMeuEmail";
            this.lblMeuEmail.Size = new System.Drawing.Size(61, 13);
            this.lblMeuEmail.TabIndex = 0;
            this.lblMeuEmail.Text = "Meu e-mail:";
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(98, 72);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // lblQtdeCar
            // 
            this.lblQtdeCar.Location = new System.Drawing.Point(228, 293);
            this.lblQtdeCar.Name = "lblQtdeCar";
            this.lblQtdeCar.Size = new System.Drawing.Size(183, 13);
            this.lblQtdeCar.TabIndex = 0;
            this.lblQtdeCar.Text = "Max. de Caracteres: 0/500";
            this.lblQtdeCar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.txtAnexo);
            this.grbBox2.Controls.Add(this.lblQtde);
            this.grbBox2.Controls.Add(this.lblArquivosAnexados);
            this.grbBox2.Controls.Add(this.btnLimparAnexo);
            this.grbBox2.Controls.Add(this.btnAnexar);
            this.grbBox2.Location = new System.Drawing.Point(416, 10);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(418, 253);
            this.grbBox2.TabIndex = 10;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Anexos:";
            // 
            // txtAnexo
            // 
            this.txtAnexo.BackColor = System.Drawing.Color.White;
            this.txtAnexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnexo.Location = new System.Drawing.Point(6, 48);
            this.txtAnexo.MaxLength = 2000;
            this.txtAnexo.Multiline = true;
            this.txtAnexo.Name = "txtAnexo";
            this.txtAnexo.ReadOnly = true;
            this.txtAnexo.Size = new System.Drawing.Size(412, 175);
            this.txtAnexo.TabIndex = 13;
            // 
            // lblQtde
            // 
            this.lblQtde.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtde.Location = new System.Drawing.Point(6, 226);
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(406, 24);
            this.lblQtde.TabIndex = 0;
            this.lblQtde.Text = "Arquivos: 0";
            this.lblQtde.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblArquivosAnexados
            // 
            this.lblArquivosAnexados.AutoSize = true;
            this.lblArquivosAnexados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArquivosAnexados.Location = new System.Drawing.Point(192, 34);
            this.lblArquivosAnexados.Name = "lblArquivosAnexados";
            this.lblArquivosAnexados.Size = new System.Drawing.Size(52, 13);
            this.lblArquivosAnexados.TabIndex = 0;
            this.lblArquivosAnexados.Text = "Anexos:";
            // 
            // btnLimparAnexo
            // 
            this.btnLimparAnexo.Enabled = false;
            this.btnLimparAnexo.Image = ((System.Drawing.Image)(resources.GetObject("btnLimparAnexo.Image")));
            this.btnLimparAnexo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnLimparAnexo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLimparAnexo.Location = new System.Drawing.Point(312, 19);
            this.btnLimparAnexo.Name = "btnLimparAnexo";
            this.btnLimparAnexo.Size = new System.Drawing.Size(100, 25);
            this.btnLimparAnexo.TabIndex = 12;
            this.btnLimparAnexo.Text = "&Limpar anexos";
            this.btnLimparAnexo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEmail.SetToolTip(this.btnLimparAnexo, "Clique para limpar os arquivos anexados.");
            this.btnLimparAnexo.UseVisualStyleBackColor = true;
            this.btnLimparAnexo.Click += new System.EventHandler(this.btnLimparAnexo_Click);
            this.btnLimparAnexo.MouseLeave += new System.EventHandler(this.btnLimparAnexo_MouseLeave);
            this.btnLimparAnexo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnLimparAnexo_MouseMove);
            // 
            // btnAnexar
            // 
            this.btnAnexar.Image = ((System.Drawing.Image)(resources.GetObject("btnAnexar.Image")));
            this.btnAnexar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAnexar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAnexar.Location = new System.Drawing.Point(6, 19);
            this.btnAnexar.Name = "btnAnexar";
            this.btnAnexar.Size = new System.Drawing.Size(125, 25);
            this.btnAnexar.TabIndex = 11;
            this.btnAnexar.Text = "&Anexar um arquivo";
            this.btnAnexar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEmail.SetToolTip(this.btnAnexar, "Clique para adicionar um ou mais arquivos.");
            this.btnAnexar.UseVisualStyleBackColor = true;
            this.btnAnexar.Click += new System.EventHandler(this.btnAnexar_Click);
            this.btnAnexar.MouseLeave += new System.EventHandler(this.btnAnexar_MouseLeave);
            this.btnAnexar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAnexar_MouseMove);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.Image")));
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEnviar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEnviar.Location = new System.Drawing.Point(764, 269);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(70, 35);
            this.btnEnviar.TabIndex = 15;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEmail.SetToolTip(this.btnEnviar, "Clique para enviar um E-mail.");
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            this.btnEnviar.MouseLeave += new System.EventHandler(this.btnEnviar_MouseLeave);
            this.btnEnviar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEnviar_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mensagem:";
            // 
            // txtAssunto
            // 
            this.txtAssunto.BackColor = System.Drawing.Color.White;
            this.txtAssunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssunto.Location = new System.Drawing.Point(111, 128);
            this.txtAssunto.MaxLength = 60;
            this.txtAssunto.Name = "txtAssunto";
            this.txtAssunto.Size = new System.Drawing.Size(299, 20);
            this.txtAssunto.TabIndex = 8;
            this.txtAssunto.Enter += new System.EventHandler(this.txtAssunto_Enter);
            this.txtAssunto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAssunto_KeyPress);
            this.txtAssunto.Leave += new System.EventHandler(this.txtAssunto_Leave);
            // 
            // lblAssunto
            // 
            this.lblAssunto.AutoSize = true;
            this.lblAssunto.Location = new System.Drawing.Point(57, 131);
            this.lblAssunto.Name = "lblAssunto";
            this.lblAssunto.Size = new System.Drawing.Size(48, 13);
            this.lblAssunto.TabIndex = 0;
            this.lblAssunto.Text = "Assunto:";
            // 
            // txtPara
            // 
            this.txtPara.BackColor = System.Drawing.Color.White;
            this.txtPara.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPara.Location = new System.Drawing.Point(111, 71);
            this.txtPara.MaxLength = 60;
            this.txtPara.Name = "txtPara";
            this.txtPara.Size = new System.Drawing.Size(300, 20);
            this.txtPara.TabIndex = 4;
            this.txtPara.Enter += new System.EventHandler(this.txtPara_Enter);
            this.txtPara.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPara_KeyPress);
            this.txtPara.Leave += new System.EventHandler(this.txtPara_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Para (Destinatário):";
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(311, 137);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(300, 33);
            this.lblProgresso.TabIndex = 39;
            this.lblProgresso.Text = "Por favor, aguarde...";
            this.lblProgresso.Visible = false;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.pgbProgresso.Location = new System.Drawing.Point(301, 170);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(321, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 0;
            this.pgbProgresso.Visible = false;
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(797, 328);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 35);
            this.btnSair.TabIndex = 16;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEmail.SetToolTip(this.btnSair, "Sair de Enviar E-Mail.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // pcibAnexo
            // 
            this.pcibAnexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibAnexo.Image = ((System.Drawing.Image)(resources.GetObject("pcibAnexo.Image")));
            this.pcibAnexo.Location = new System.Drawing.Point(12, 328);
            this.pcibAnexo.Name = "pcibAnexo";
            this.pcibAnexo.Size = new System.Drawing.Size(20, 20);
            this.pcibAnexo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibAnexo.TabIndex = 38;
            this.pcibAnexo.TabStop = false;
            this.pcibAnexo.Click += new System.EventHandler(this.pcibAnexo_Click);
            this.pcibAnexo.MouseLeave += new System.EventHandler(this.pcibAnexo_MouseLeave);
            this.pcibAnexo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibAnexo_MouseMove);
            // 
            // ttpEmail
            // 
            this.ttpEmail.AutoPopDelay = 5000;
            this.ttpEmail.InitialDelay = 1000;
            this.ttpEmail.IsBalloon = true;
            this.ttpEmail.ReshowDelay = 100;
            this.ttpEmail.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpEmail.ToolTipTitle = "Dica:";
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // FrmUtilEnviarEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(863, 368);
            this.ControlBox = false;
            this.Controls.Add(this.lblProgresso);
            this.Controls.Add(this.pgbProgresso);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.pcibAnexo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUtilEnviarEmail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar E-mail";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUtilEnviarEmail_FormClosing);
            this.Load += new System.EventHandler(this.FrmUtilEnviarEmail_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmUtilEnviarEmail_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibAnexo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblQtdeCar;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Label lblQtde;
        private System.Windows.Forms.Label lblArquivosAnexados;
        private System.Windows.Forms.PictureBox pcibAnexo;
        private System.Windows.Forms.Button btnLimparAnexo;
        private System.Windows.Forms.Button btnAnexar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAssunto;
        private System.Windows.Forms.Label lblAssunto;
        private System.Windows.Forms.TextBox txtPara;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.Label lblAsterisco3;
        private System.Windows.Forms.Label lblAsterisco2;
        private System.Windows.Forms.TextBox txtMeuEmail;
        private System.Windows.Forms.Label lblMeuEmail;
        private System.Windows.Forms.Label lblAsterisco4;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.ToolTip ttpEmail;
        private System.Windows.Forms.Button btnProcurarCliente;
        private System.Windows.Forms.Button btnFuncionario;
        private System.Windows.Forms.Button btnPesquisarForn;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.TextBox txtAnexo;
    }
}