namespace Seven_Sistema
{
    partial class FrmRelAbertFechCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelAbertFechCaixa));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.cbbSituacao = new System.Windows.Forms.ComboBox();
            this.btnProcurarUsuario1 = new System.Windows.Forms.Button();
            this.lblUsuario1 = new System.Windows.Forms.Label();
            this.cbbUsuario1 = new System.Windows.Forms.ComboBox();
            this.btnProcurarPDV = new System.Windows.Forms.Button();
            this.rbtnDataFechamento = new System.Windows.Forms.RadioButton();
            this.rbtnDataAbertura = new System.Windows.Forms.RadioButton();
            this.btnProcurarUsuario = new System.Windows.Forms.Button();
            this.lblCodPDV = new System.Windows.Forms.Label();
            this.cbbCodPDV = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.cbbUsuario = new System.Windows.Forms.ComboBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.dtCaixa = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.btnDevolucoes = new System.Windows.Forms.Button();
            this.btnVendas = new System.Windows.Forms.Button();
            this.btnSangriaSupriemento = new System.Windows.Forms.Button();
            this.btnSaidasProdutosServ = new System.Windows.Forms.Button();
            this.btnConsultarPagamento = new System.Windows.Forms.Button();
            this.btnFluxoCaixa = new System.Windows.Forms.Button();
            this.btnHistoricoCaixa = new System.Windows.Forms.Button();
            this.btnExportarCsv = new System.Windows.Forms.Button();
            this.rbtnExportarTxt = new System.Windows.Forms.Button();
            this.btnResumido = new System.Windows.Forms.Button();
            this.ttpCaixa = new System.Windows.Forms.ToolTip(this.components);
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.picbInterrogacao3 = new System.Windows.Forms.PictureBox();
            this.pEnabled = new System.Windows.Forms.Panel();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCaixa)).BeginInit();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao3)).BeginInit();
            this.pEnabled.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblSituacao);
            this.grbBox1.Controls.Add(this.cbbSituacao);
            this.grbBox1.Controls.Add(this.btnProcurarUsuario1);
            this.grbBox1.Controls.Add(this.lblUsuario1);
            this.grbBox1.Controls.Add(this.cbbUsuario1);
            this.grbBox1.Controls.Add(this.btnProcurarPDV);
            this.grbBox1.Controls.Add(this.rbtnDataFechamento);
            this.grbBox1.Controls.Add(this.rbtnDataAbertura);
            this.grbBox1.Controls.Add(this.btnProcurarUsuario);
            this.grbBox1.Controls.Add(this.lblCodPDV);
            this.grbBox1.Controls.Add(this.cbbCodPDV);
            this.grbBox1.Controls.Add(this.lblUsuario);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.cbbUsuario);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Location = new System.Drawing.Point(27, 49);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(760, 84);
            this.grbBox1.TabIndex = 2;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Enabled = false;
            this.lblSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacao.Location = new System.Drawing.Point(446, 39);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(61, 13);
            this.lblSituacao.TabIndex = 18;
            this.lblSituacao.Text = "Situação:";
            // 
            // cbbSituacao
            // 
            this.cbbSituacao.BackColor = System.Drawing.Color.LightBlue;
            this.cbbSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSituacao.DropDownWidth = 95;
            this.cbbSituacao.Enabled = false;
            this.cbbSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSituacao.FormattingEnabled = true;
            this.cbbSituacao.Items.AddRange(new object[] {
            "",
            "ABERTO",
            "FECHADO"});
            this.cbbSituacao.Location = new System.Drawing.Point(449, 55);
            this.cbbSituacao.Name = "cbbSituacao";
            this.cbbSituacao.Size = new System.Drawing.Size(95, 21);
            this.cbbSituacao.TabIndex = 15;
            this.cbbSituacao.DropDown += new System.EventHandler(this.cbbSituacao_DropDown);
            this.cbbSituacao.DropDownClosed += new System.EventHandler(this.cbbSituacao_DropDownClosed);
            this.cbbSituacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbSituacao_KeyPress);
            this.cbbSituacao.MouseLeave += new System.EventHandler(this.cbbSituacao_MouseLeave);
            this.cbbSituacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbSituacao_MouseMove);
            // 
            // btnProcurarUsuario1
            // 
            this.btnProcurarUsuario1.Enabled = false;
            this.btnProcurarUsuario1.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarUsuario1.Image")));
            this.btnProcurarUsuario1.Location = new System.Drawing.Point(374, 52);
            this.btnProcurarUsuario1.Name = "btnProcurarUsuario1";
            this.btnProcurarUsuario1.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarUsuario1.TabIndex = 14;
            this.btnProcurarUsuario1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCaixa.SetToolTip(this.btnProcurarUsuario1, "Clique para pesquisar um Usuário.");
            this.btnProcurarUsuario1.UseVisualStyleBackColor = true;
            this.btnProcurarUsuario1.Click += new System.EventHandler(this.btnProcurarUsuario1_Click);
            this.btnProcurarUsuario1.MouseLeave += new System.EventHandler(this.btnProcurarUsuario1_MouseLeave);
            this.btnProcurarUsuario1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarUsuario1_MouseMove);
            // 
            // lblUsuario1
            // 
            this.lblUsuario1.AutoSize = true;
            this.lblUsuario1.Enabled = false;
            this.lblUsuario1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario1.Location = new System.Drawing.Point(252, 39);
            this.lblUsuario1.Name = "lblUsuario1";
            this.lblUsuario1.Size = new System.Drawing.Size(145, 13);
            this.lblUsuario1.TabIndex = 14;
            this.lblUsuario1.Text = "Usuário do Fechamento:";
            // 
            // cbbUsuario1
            // 
            this.cbbUsuario1.BackColor = System.Drawing.Color.LightBlue;
            this.cbbUsuario1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUsuario1.DropDownWidth = 180;
            this.cbbUsuario1.Enabled = false;
            this.cbbUsuario1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUsuario1.FormattingEnabled = true;
            this.cbbUsuario1.Location = new System.Drawing.Point(255, 55);
            this.cbbUsuario1.Name = "cbbUsuario1";
            this.cbbUsuario1.Size = new System.Drawing.Size(113, 21);
            this.cbbUsuario1.TabIndex = 13;
            this.cbbUsuario1.DropDown += new System.EventHandler(this.cbbUsuario1_DropDown);
            this.cbbUsuario1.DropDownStyleChanged += new System.EventHandler(this.cbbUsuario1_DropDownStyleChanged);
            this.cbbUsuario1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbUsuario1_KeyPress);
            this.cbbUsuario1.MouseLeave += new System.EventHandler(this.cbbUsuario1_MouseLeave);
            this.cbbUsuario1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbUsuario1_MouseMove);
            // 
            // btnProcurarPDV
            // 
            this.btnProcurarPDV.Enabled = false;
            this.btnProcurarPDV.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarPDV.Image")));
            this.btnProcurarPDV.Location = new System.Drawing.Point(728, 52);
            this.btnProcurarPDV.Name = "btnProcurarPDV";
            this.btnProcurarPDV.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarPDV.TabIndex = 17;
            this.btnProcurarPDV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCaixa.SetToolTip(this.btnProcurarPDV, "Clique para pesquisar um Computador/PDV.");
            this.btnProcurarPDV.UseVisualStyleBackColor = true;
            this.btnProcurarPDV.Click += new System.EventHandler(this.btnProcurarPDV_Click);
            this.btnProcurarPDV.MouseLeave += new System.EventHandler(this.btnPesquisarPDV_MouseLeave);
            this.btnProcurarPDV.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisarPDV_MouseMove);
            // 
            // rbtnDataFechamento
            // 
            this.rbtnDataFechamento.AutoSize = true;
            this.rbtnDataFechamento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnDataFechamento.Location = new System.Drawing.Point(182, 19);
            this.rbtnDataFechamento.Name = "rbtnDataFechamento";
            this.rbtnDataFechamento.Size = new System.Drawing.Size(125, 17);
            this.rbtnDataFechamento.TabIndex = 5;
            this.rbtnDataFechamento.TabStop = true;
            this.rbtnDataFechamento.Text = "Data de Fechamento";
            this.rbtnDataFechamento.UseVisualStyleBackColor = true;
            this.rbtnDataFechamento.CheckedChanged += new System.EventHandler(this.rbtnDataDechamento_CheckedChanged);
            this.rbtnDataFechamento.MouseLeave += new System.EventHandler(this.rbtnDataDechamento_MouseLeave);
            this.rbtnDataFechamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnDataDechamento_MouseMove);
            // 
            // rbtnDataAbertura
            // 
            this.rbtnDataAbertura.AutoSize = true;
            this.rbtnDataAbertura.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnDataAbertura.Location = new System.Drawing.Point(70, 19);
            this.rbtnDataAbertura.Name = "rbtnDataAbertura";
            this.rbtnDataAbertura.Size = new System.Drawing.Size(106, 17);
            this.rbtnDataAbertura.TabIndex = 4;
            this.rbtnDataAbertura.TabStop = true;
            this.rbtnDataAbertura.Text = "Data de Abertura";
            this.rbtnDataAbertura.UseVisualStyleBackColor = true;
            this.rbtnDataAbertura.CheckedChanged += new System.EventHandler(this.rbtnDataAbertura_CheckedChanged);
            this.rbtnDataAbertura.MouseLeave += new System.EventHandler(this.radioButton1_MouseLeave);
            this.rbtnDataAbertura.MouseMove += new System.Windows.Forms.MouseEventHandler(this.radioButton1_MouseMove);
            // 
            // btnProcurarUsuario
            // 
            this.btnProcurarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarUsuario.Image")));
            this.btnProcurarUsuario.Location = new System.Drawing.Point(125, 52);
            this.btnProcurarUsuario.Name = "btnProcurarUsuario";
            this.btnProcurarUsuario.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarUsuario.TabIndex = 12;
            this.btnProcurarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCaixa.SetToolTip(this.btnProcurarUsuario, "Clique para pesquisar um Usuário.");
            this.btnProcurarUsuario.UseVisualStyleBackColor = true;
            this.btnProcurarUsuario.Click += new System.EventHandler(this.btnProcurarUsuario_Click);
            this.btnProcurarUsuario.MouseLeave += new System.EventHandler(this.btnProcurarUsuario_MouseLeave);
            this.btnProcurarUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarUsuario_MouseMove);
            // 
            // lblCodPDV
            // 
            this.lblCodPDV.AutoSize = true;
            this.lblCodPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodPDV.Location = new System.Drawing.Point(639, 39);
            this.lblCodPDV.Name = "lblCodPDV";
            this.lblCodPDV.Size = new System.Drawing.Size(96, 13);
            this.lblCodPDV.TabIndex = 0;
            this.lblCodPDV.Text = "Escolha o PDV:";
            // 
            // cbbCodPDV
            // 
            this.cbbCodPDV.BackColor = System.Drawing.Color.LightBlue;
            this.cbbCodPDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCodPDV.DropDownWidth = 80;
            this.cbbCodPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCodPDV.FormattingEnabled = true;
            this.cbbCodPDV.Location = new System.Drawing.Point(642, 55);
            this.cbbCodPDV.Name = "cbbCodPDV";
            this.cbbCodPDV.Size = new System.Drawing.Size(80, 21);
            this.cbbCodPDV.TabIndex = 16;
            this.cbbCodPDV.DropDown += new System.EventHandler(this.cbbCodPDV_DropDown);
            this.cbbCodPDV.DropDownClosed += new System.EventHandler(this.cbbCodPDV_DropDownClosed);
            this.cbbCodPDV.MouseLeave += new System.EventHandler(this.cbbCodPDV_MouseLeave);
            this.cbbCodPDV.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbCodPDV_MouseMove);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(3, 39);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(124, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuário da Abertura:";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(612, 19);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // mtxtpData
            // 
            this.mtxtpData.BackColor = System.Drawing.Color.White;
            this.mtxtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData.Location = new System.Drawing.Point(528, 16);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 7;
            this.mtxtpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData.DoubleClick += new System.EventHandler(this.mtxtpData_DoubleClick);
            this.mtxtpData.Enter += new System.EventHandler(this.mtxtpData_Enter);
            this.mtxtpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData_KeyPress);
            this.mtxtpData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData_KeyUp);
            this.mtxtpData.Leave += new System.EventHandler(this.mtxtpData_Leave);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(313, 19);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 6;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(6, 19);
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
            // cbbUsuario
            // 
            this.cbbUsuario.BackColor = System.Drawing.Color.LightBlue;
            this.cbbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUsuario.DropDownWidth = 180;
            this.cbbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUsuario.FormattingEnabled = true;
            this.cbbUsuario.Location = new System.Drawing.Point(6, 55);
            this.cbbUsuario.Name = "cbbUsuario";
            this.cbbUsuario.Size = new System.Drawing.Size(113, 21);
            this.cbbUsuario.TabIndex = 11;
            this.cbbUsuario.DropDown += new System.EventHandler(this.cbbUsuario_DropDown);
            this.cbbUsuario.DropDownClosed += new System.EventHandler(this.cbbUsuario_DropDownClosed);
            this.cbbUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbUsuario_KeyPress);
            this.cbbUsuario.MouseLeave += new System.EventHandler(this.cbbUsuario_MouseLeave);
            this.cbbUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbUsuario_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(570, 19);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(98, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite o Código:";
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(644, 16);
            this.mtxtpData1.Mask = "00/00/0000";
            this.mtxtpData1.Name = "mtxtpData1";
            this.mtxtpData1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData1.TabIndex = 8;
            this.mtxtpData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData1.DoubleClick += new System.EventHandler(this.mtxtpData1_DoubleClick);
            this.mtxtpData1.Enter += new System.EventHandler(this.mtxtpData1_Enter);
            this.mtxtpData1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData1_KeyPress);
            this.mtxtpData1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData1_KeyUp);
            this.mtxtpData1.Leave += new System.EventHandler(this.mtxtpData1_Leave);
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(728, 13);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 10;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCaixa.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(674, 16);
            this.txtpCodigo.MaxLength = 10;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtpCodigo.TabIndex = 9;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(679, 139);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 237;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(705, 139);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 18;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCaixa.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(262, 236);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(300, 33);
            this.lblProgresso.TabIndex = 233;
            this.lblProgresso.Text = "Por favor, aguarde...";
            this.lblProgresso.Visible = false;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.pgbProgresso.Location = new System.Drawing.Point(252, 269);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(321, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 234;
            this.pgbProgresso.Visible = false;
            // 
            // dtCaixa
            // 
            this.dtCaixa.AllowUserToAddRows = false;
            this.dtCaixa.AllowUserToDeleteRows = false;
            this.dtCaixa.AllowUserToResizeRows = false;
            this.dtCaixa.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtCaixa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtCaixa.Location = new System.Drawing.Point(27, 177);
            this.dtCaixa.MultiSelect = false;
            this.dtCaixa.Name = "dtCaixa";
            this.dtCaixa.ReadOnly = true;
            this.dtCaixa.RowHeadersVisible = false;
            this.dtCaixa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtCaixa.ShowCellErrors = false;
            this.dtCaixa.ShowCellToolTips = false;
            this.dtCaixa.ShowEditingIcon = false;
            this.dtCaixa.ShowRowErrors = false;
            this.dtCaixa.Size = new System.Drawing.Size(760, 172);
            this.dtCaixa.TabIndex = 19;
            this.dtCaixa.TabStop = false;
            this.dtCaixa.DataSourceChanged += new System.EventHandler(this.dtCaixa_DataSourceChanged);
            this.dtCaixa.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtCaixa_CellEnter);
            this.dtCaixa.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtCaixa_CellFormatting);
            this.dtCaixa.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtCaixa_RowsAdded);
            this.dtCaixa.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtCaixa_RowsRemoved);
            this.dtCaixa.MouseLeave += new System.EventHandler(this.dtCaixa_MouseLeave);
            this.dtCaixa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtCaixa_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(24, 352);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 238;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(732, 472);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 29;
            this.btnSair.Text = "Sa&ir";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCaixa.SetToolTip(this.btnSair, "Sair do Relatório de Abertura e Fechamento de Caixa.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.btnDevolucoes);
            this.grbBox2.Controls.Add(this.btnVendas);
            this.grbBox2.Controls.Add(this.btnSangriaSupriemento);
            this.grbBox2.Controls.Add(this.btnSaidasProdutosServ);
            this.grbBox2.Controls.Add(this.btnConsultarPagamento);
            this.grbBox2.Controls.Add(this.btnFluxoCaixa);
            this.grbBox2.Controls.Add(this.btnHistoricoCaixa);
            this.grbBox2.Controls.Add(this.btnExportarCsv);
            this.grbBox2.Controls.Add(this.rbtnExportarTxt);
            this.grbBox2.Controls.Add(this.btnResumido);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(27, 381);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(760, 85);
            this.grbBox2.TabIndex = 20;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Ações:";
            // 
            // btnDevolucoes
            // 
            this.btnDevolucoes.Image = ((System.Drawing.Image)(resources.GetObject("btnDevolucoes.Image")));
            this.btnDevolucoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDevolucoes.Location = new System.Drawing.Point(660, 50);
            this.btnDevolucoes.Name = "btnDevolucoes";
            this.btnDevolucoes.Size = new System.Drawing.Size(94, 25);
            this.btnDevolucoes.TabIndex = 30;
            this.btnDevolucoes.Text = "&Devoluções";
            this.btnDevolucoes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCaixa.SetToolTip(this.btnDevolucoes, "Clique para verificar o Histórico do Caixa do registro selecionado.");
            this.btnDevolucoes.UseVisualStyleBackColor = true;
            this.btnDevolucoes.Click += new System.EventHandler(this.btnDevolucoes_Click);
            this.btnDevolucoes.MouseLeave += new System.EventHandler(this.btnDevolucoes_MouseLeave);
            this.btnDevolucoes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDevolucoes_MouseMove);
            // 
            // btnVendas
            // 
            this.btnVendas.Image = ((System.Drawing.Image)(resources.GetObject("btnVendas.Image")));
            this.btnVendas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVendas.Location = new System.Drawing.Point(660, 19);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.Size = new System.Drawing.Size(93, 25);
            this.btnVendas.TabIndex = 29;
            this.btnVendas.Text = "&Vendas";
            this.btnVendas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCaixa.SetToolTip(this.btnVendas, "Clique para verificar o Histórico do Caixa do registro selecionado.");
            this.btnVendas.UseVisualStyleBackColor = true;
            this.btnVendas.Click += new System.EventHandler(this.btnVendas_Click);
            this.btnVendas.MouseLeave += new System.EventHandler(this.btnVendas_MouseLeave);
            this.btnVendas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVendas_MouseMove);
            // 
            // btnSangriaSupriemento
            // 
            this.btnSangriaSupriemento.Image = ((System.Drawing.Image)(resources.GetObject("btnSangriaSupriemento.Image")));
            this.btnSangriaSupriemento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSangriaSupriemento.Location = new System.Drawing.Point(326, 19);
            this.btnSangriaSupriemento.Name = "btnSangriaSupriemento";
            this.btnSangriaSupriemento.Size = new System.Drawing.Size(135, 25);
            this.btnSangriaSupriemento.TabIndex = 23;
            this.btnSangriaSupriemento.Text = "Sangria/Suprimen&tos";
            this.btnSangriaSupriemento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCaixa.SetToolTip(this.btnSangriaSupriemento, "Clique para consultar as sangria/suprimento do registro selecionado.");
            this.btnSangriaSupriemento.UseVisualStyleBackColor = true;
            this.btnSangriaSupriemento.Click += new System.EventHandler(this.btnSangriaSupriemento_Click);
            this.btnSangriaSupriemento.MouseLeave += new System.EventHandler(this.btnSangriaSupriemento_MouseLeave);
            this.btnSangriaSupriemento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSangriaSupriemento_MouseMove);
            // 
            // btnSaidasProdutosServ
            // 
            this.btnSaidasProdutosServ.Image = ((System.Drawing.Image)(resources.GetObject("btnSaidasProdutosServ.Image")));
            this.btnSaidasProdutosServ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaidasProdutosServ.Location = new System.Drawing.Point(139, 50);
            this.btnSaidasProdutosServ.Name = "btnSaidasProdutosServ";
            this.btnSaidasProdutosServ.Size = new System.Drawing.Size(171, 25);
            this.btnSaidasProdutosServ.TabIndex = 26;
            this.btnSaidasProdutosServ.Text = "Saí&das de Produtos/Serviços";
            this.btnSaidasProdutosServ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCaixa.SetToolTip(this.btnSaidasProdutosServ, "Clique para consultar as saídas dos produtos do registro selecionado.");
            this.btnSaidasProdutosServ.UseVisualStyleBackColor = true;
            this.btnSaidasProdutosServ.Click += new System.EventHandler(this.btnSaidasProdutosServ_Click);
            this.btnSaidasProdutosServ.MouseLeave += new System.EventHandler(this.btnSaidasProdutosServ_MouseLeave);
            this.btnSaidasProdutosServ.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSaidasProdutosServ_MouseMove);
            // 
            // btnConsultarPagamento
            // 
            this.btnConsultarPagamento.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultarPagamento.Image")));
            this.btnConsultarPagamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultarPagamento.Location = new System.Drawing.Point(160, 19);
            this.btnConsultarPagamento.Name = "btnConsultarPagamento";
            this.btnConsultarPagamento.Size = new System.Drawing.Size(128, 25);
            this.btnConsultarPagamento.TabIndex = 22;
            this.btnConsultarPagamento.Text = "&Consultar Saldos";
            this.btnConsultarPagamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCaixa.SetToolTip(this.btnConsultarPagamento, "Clique para consultar os saldos do registro selecionado.");
            this.btnConsultarPagamento.UseVisualStyleBackColor = true;
            this.btnConsultarPagamento.Click += new System.EventHandler(this.btnConsultarPagamento_Click);
            this.btnConsultarPagamento.MouseLeave += new System.EventHandler(this.btnConsultarPagamento_MouseLeave);
            this.btnConsultarPagamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnConsultarPagamento_MouseMove);
            // 
            // btnFluxoCaixa
            // 
            this.btnFluxoCaixa.Image = ((System.Drawing.Image)(resources.GetObject("btnFluxoCaixa.Image")));
            this.btnFluxoCaixa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFluxoCaixa.Location = new System.Drawing.Point(6, 19);
            this.btnFluxoCaixa.Name = "btnFluxoCaixa";
            this.btnFluxoCaixa.Size = new System.Drawing.Size(116, 25);
            this.btnFluxoCaixa.TabIndex = 21;
            this.btnFluxoCaixa.Text = "&Fluxo de Caixa";
            this.btnFluxoCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCaixa.SetToolTip(this.btnFluxoCaixa, "Clique para verificar o Fluxo de Caixa do registro selecionado.");
            this.btnFluxoCaixa.UseVisualStyleBackColor = true;
            this.btnFluxoCaixa.Click += new System.EventHandler(this.btnFluxoCaixa_Click);
            this.btnFluxoCaixa.MouseLeave += new System.EventHandler(this.btnFluxoCaixa_MouseLeave);
            this.btnFluxoCaixa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnFluxoCaixa_MouseMove);
            // 
            // btnHistoricoCaixa
            // 
            this.btnHistoricoCaixa.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoricoCaixa.Image")));
            this.btnHistoricoCaixa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistoricoCaixa.Location = new System.Drawing.Point(494, 19);
            this.btnHistoricoCaixa.Name = "btnHistoricoCaixa";
            this.btnHistoricoCaixa.Size = new System.Drawing.Size(133, 25);
            this.btnHistoricoCaixa.TabIndex = 24;
            this.btnHistoricoCaixa.Text = "&Histórico do Caixa";
            this.btnHistoricoCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCaixa.SetToolTip(this.btnHistoricoCaixa, "Clique para verificar o Histórico do Caixa do registro selecionado.");
            this.btnHistoricoCaixa.UseVisualStyleBackColor = true;
            this.btnHistoricoCaixa.Click += new System.EventHandler(this.btnHistoricoCaixa_Click);
            this.btnHistoricoCaixa.MouseLeave += new System.EventHandler(this.btnHistoricoCaixa_MouseLeave);
            this.btnHistoricoCaixa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnHistoricoCaixa_MouseMove);
            // 
            // btnExportarCsv
            // 
            this.btnExportarCsv.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarCsv.Image")));
            this.btnExportarCsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarCsv.Location = new System.Drawing.Point(326, 50);
            this.btnExportarCsv.Name = "btnExportarCsv";
            this.btnExportarCsv.Size = new System.Drawing.Size(135, 25);
            this.btnExportarCsv.TabIndex = 27;
            this.btnExportarCsv.Text = "Exp. dados p&ara (.csv)";
            this.btnExportarCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCaixa.SetToolTip(this.btnExportarCsv, "Gerar arquivo da grade de dados em (.csv)(Excel).");
            this.btnExportarCsv.UseVisualStyleBackColor = true;
            this.btnExportarCsv.Click += new System.EventHandler(this.btnExportarCsv_Click);
            this.btnExportarCsv.MouseLeave += new System.EventHandler(this.btnExportarCsv_MouseLeave);
            this.btnExportarCsv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExportarCsv_MouseMove);
            // 
            // rbtnExportarTxt
            // 
            this.rbtnExportarTxt.Image = ((System.Drawing.Image)(resources.GetObject("rbtnExportarTxt.Image")));
            this.rbtnExportarTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtnExportarTxt.Location = new System.Drawing.Point(494, 50);
            this.rbtnExportarTxt.Name = "rbtnExportarTxt";
            this.rbtnExportarTxt.Size = new System.Drawing.Size(133, 25);
            this.rbtnExportarTxt.TabIndex = 28;
            this.rbtnExportarTxt.Text = "&Exp. dados para (.txt)";
            this.rbtnExportarTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCaixa.SetToolTip(this.rbtnExportarTxt, "Gerar arquivo da grade de dados em (.txt)(Bloco de Notas).");
            this.rbtnExportarTxt.UseVisualStyleBackColor = true;
            this.rbtnExportarTxt.Click += new System.EventHandler(this.rbtnExportarTxt_Click);
            this.rbtnExportarTxt.MouseLeave += new System.EventHandler(this.rbtnExportarTxt_MouseLeave);
            this.rbtnExportarTxt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnExportarTxt_MouseMove);
            // 
            // btnResumido
            // 
            this.btnResumido.Image = ((System.Drawing.Image)(resources.GetObject("btnResumido.Image")));
            this.btnResumido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResumido.Location = new System.Drawing.Point(6, 50);
            this.btnResumido.Name = "btnResumido";
            this.btnResumido.Size = new System.Drawing.Size(116, 25);
            this.btnResumido.TabIndex = 25;
            this.btnResumido.Text = "&Relatório em PDF";
            this.btnResumido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCaixa.SetToolTip(this.btnResumido, "Relatório das Informações em PDF");
            this.btnResumido.UseVisualStyleBackColor = true;
            this.btnResumido.Click += new System.EventHandler(this.btnResumido_Click);
            this.btnResumido.MouseLeave += new System.EventHandler(this.btnResumido_MouseLeave);
            this.btnResumido.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnResumido_MouseMove);
            // 
            // ttpCaixa
            // 
            this.ttpCaixa.AutoPopDelay = 5000;
            this.ttpCaixa.InitialDelay = 1000;
            this.ttpCaixa.IsBalloon = true;
            this.ttpCaixa.ReshowDelay = 100;
            this.ttpCaixa.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpCaixa.ToolTipTitle = "Dica:";
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // picbInterrogacao3
            // 
            this.picbInterrogacao3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao3.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao3.Image")));
            this.picbInterrogacao3.Location = new System.Drawing.Point(27, 472);
            this.picbInterrogacao3.Name = "picbInterrogacao3";
            this.picbInterrogacao3.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao3.TabIndex = 241;
            this.picbInterrogacao3.TabStop = false;
            this.picbInterrogacao3.Click += new System.EventHandler(this.picbInterrogacao3_Click);
            this.picbInterrogacao3.MouseLeave += new System.EventHandler(this.picbInterrogacao3_MouseLeave);
            this.picbInterrogacao3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao3_MouseMove);
            // 
            // pEnabled
            // 
            this.pEnabled.Controls.Add(this.btnSair);
            this.pEnabled.Controls.Add(this.picbInterrogacao3);
            this.pEnabled.Controls.Add(this.grbBox1);
            this.pEnabled.Controls.Add(this.grbBox2);
            this.pEnabled.Controls.Add(this.picbInterrogacao1);
            this.pEnabled.Controls.Add(this.btnPesquisar);
            this.pEnabled.Controls.Add(this.lblRegistros);
            this.pEnabled.Controls.Add(this.lblProgresso);
            this.pEnabled.Controls.Add(this.pgbProgresso);
            this.pEnabled.Controls.Add(this.dtCaixa);
            this.pEnabled.Location = new System.Drawing.Point(-15, -37);
            this.pEnabled.Name = "pEnabled";
            this.pEnabled.Size = new System.Drawing.Size(817, 592);
            this.pEnabled.TabIndex = 242;
            // 
            // FrmRelAbertFechCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(784, 471);
            this.ControlBox = false;
            this.Controls.Add(this.pEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelAbertFechCaixa";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Abertura e Fechamento de Caixa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRelCaixas_FormClosing);
            this.Load += new System.EventHandler(this.FrmRelCaixas_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRelCaixas_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtCaixa)).EndInit();
            this.grbBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao3)).EndInit();
            this.pEnabled.ResumeLayout(false);
            this.pEnabled.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnProcurarUsuario;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.Label lblCodPDV;
        private System.Windows.Forms.ComboBox cbbCodPDV;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.ComboBox cbbUsuario;
        private System.Windows.Forms.RadioButton rbtnDataFechamento;
        private System.Windows.Forms.RadioButton rbtnDataAbertura;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.Windows.Forms.DataGridView dtCaixa;
        private System.Windows.Forms.Button btnProcurarPDV;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnFluxoCaixa;
        private System.Windows.Forms.Button btnHistoricoCaixa;
        private System.Windows.Forms.Button btnExportarCsv;
        private System.Windows.Forms.Button rbtnExportarTxt;
        private System.Windows.Forms.Button btnResumido;
        private System.Windows.Forms.Button btnProcurarUsuario1;
        private System.Windows.Forms.Label lblUsuario1;
        private System.Windows.Forms.ComboBox cbbUsuario1;
        private System.Windows.Forms.ToolTip ttpCaixa;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.ComboBox cbbSituacao;
        private System.Windows.Forms.PictureBox picbInterrogacao3;
        private System.Windows.Forms.Button btnConsultarPagamento;
        private System.Windows.Forms.Button btnSangriaSupriemento;
        private System.Windows.Forms.Button btnSaidasProdutosServ;
        private System.Windows.Forms.Panel pEnabled;
        private System.Windows.Forms.Button btnDevolucoes;
        private System.Windows.Forms.Button btnVendas;
    }
}