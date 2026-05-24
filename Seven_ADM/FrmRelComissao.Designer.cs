namespace Seven_ADM
{
    partial class FrmRelComissao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelComissao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.btnPesqFuncionario = new System.Windows.Forms.Button();
            this.btnPesqVenda = new System.Windows.Forms.Button();
            this.lblCodVenda = new System.Windows.Forms.Label();
            this.txtCodVenda = new System.Windows.Forms.TextBox();
            this.lblFuncionario = new System.Windows.Forms.Label();
            this.cbbFuncionario = new System.Windows.Forms.ComboBox();
            this.btnPesqOS = new System.Windows.Forms.Button();
            this.lblCodOS = new System.Windows.Forms.Label();
            this.txtCodOS = new System.Windows.Forms.TextBox();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.cbbSituacao = new System.Windows.Forms.ComboBox();
            this.mtxtHorario1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtHorario = new System.Windows.Forms.MaskedTextBox();
            this.lblDataVenda = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.dtCom = new System.Windows.Forms.DataGridView();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.lblValorSituacao = new System.Windows.Forms.Label();
            this.lblCxSituacao = new System.Windows.Forms.Label();
            this.btnBaixaRegistro = new System.Windows.Forms.Button();
            this.btnTodasContas = new System.Windows.Forms.Button();
            this.btnExportarCsv = new System.Windows.Forms.Button();
            this.rbtnExportarTxt = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.pEnabled = new System.Windows.Forms.Panel();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.lblValorAPagar = new System.Windows.Forms.Label();
            this.lblValorPago = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblaPagar = new System.Windows.Forms.Label();
            this.lblPago = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.ttpComissoes = new System.Windows.Forms.ToolTip(this.components);
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.grbBox2.SuspendLayout();
            this.pEnabled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnPesqFuncionario);
            this.grbBox1.Controls.Add(this.btnPesqVenda);
            this.grbBox1.Controls.Add(this.lblCodVenda);
            this.grbBox1.Controls.Add(this.txtCodVenda);
            this.grbBox1.Controls.Add(this.lblFuncionario);
            this.grbBox1.Controls.Add(this.cbbFuncionario);
            this.grbBox1.Controls.Add(this.btnPesqOS);
            this.grbBox1.Controls.Add(this.lblCodOS);
            this.grbBox1.Controls.Add(this.txtCodOS);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.lblSituacao);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.cbbSituacao);
            this.grbBox1.Controls.Add(this.mtxtHorario1);
            this.grbBox1.Controls.Add(this.mtxtHorario);
            this.grbBox1.Controls.Add(this.lblDataVenda);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Location = new System.Drawing.Point(35, 47);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(760, 123);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            this.grbBox1.Enter += new System.EventHandler(this.grbBox1_Enter);
            // 
            // btnPesqFuncionario
            // 
            this.btnPesqFuncionario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesqFuncionario.Image = ((System.Drawing.Image)(resources.GetObject("btnPesqFuncionario.Image")));
            this.btnPesqFuncionario.Location = new System.Drawing.Point(269, 92);
            this.btnPesqFuncionario.Name = "btnPesqFuncionario";
            this.btnPesqFuncionario.Size = new System.Drawing.Size(26, 25);
            this.btnPesqFuncionario.TabIndex = 15;
            this.btnPesqFuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComissoes.SetToolTip(this.btnPesqFuncionario, "Clique para pesquisar uma Funcionário.");
            this.btnPesqFuncionario.UseVisualStyleBackColor = true;
            this.btnPesqFuncionario.Click += new System.EventHandler(this.btnPesqFuncionario_Click);
            // 
            // btnPesqVenda
            // 
            this.btnPesqVenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesqVenda.Image = ((System.Drawing.Image)(resources.GetObject("btnPesqVenda.Image")));
            this.btnPesqVenda.Location = new System.Drawing.Point(728, 52);
            this.btnPesqVenda.Name = "btnPesqVenda";
            this.btnPesqVenda.Size = new System.Drawing.Size(26, 25);
            this.btnPesqVenda.TabIndex = 13;
            this.btnPesqVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComissoes.SetToolTip(this.btnPesqVenda, "Clique para pesquisar uma Venda.");
            this.btnPesqVenda.UseVisualStyleBackColor = true;
            this.btnPesqVenda.Click += new System.EventHandler(this.btnPesqVenda_Click);
            // 
            // lblCodVenda
            // 
            this.lblCodVenda.AutoSize = true;
            this.lblCodVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodVenda.Location = new System.Drawing.Point(606, 39);
            this.lblCodVenda.Name = "lblCodVenda";
            this.lblCodVenda.Size = new System.Drawing.Size(95, 13);
            this.lblCodVenda.TabIndex = 35;
            this.lblCodVenda.Text = "Cód. da Venda:";
            // 
            // txtCodVenda
            // 
            this.txtCodVenda.BackColor = System.Drawing.Color.White;
            this.txtCodVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodVenda.Location = new System.Drawing.Point(609, 55);
            this.txtCodVenda.MaxLength = 10;
            this.txtCodVenda.Name = "txtCodVenda";
            this.txtCodVenda.Size = new System.Drawing.Size(113, 20);
            this.txtCodVenda.TabIndex = 12;
            this.txtCodVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodVenda.Enter += new System.EventHandler(this.textBox1_Enter);
            this.txtCodVenda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodVenda_KeyPress);
            this.txtCodVenda.Leave += new System.EventHandler(this.txtCodVenda_Leave);
            // 
            // lblFuncionario
            // 
            this.lblFuncionario.AutoSize = true;
            this.lblFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuncionario.Location = new System.Drawing.Point(6, 78);
            this.lblFuncionario.Name = "lblFuncionario";
            this.lblFuncionario.Size = new System.Drawing.Size(77, 13);
            this.lblFuncionario.TabIndex = 31;
            this.lblFuncionario.Text = "Funcionário:";
            // 
            // cbbFuncionario
            // 
            this.cbbFuncionario.BackColor = System.Drawing.Color.LightBlue;
            this.cbbFuncionario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFuncionario.DropDownWidth = 550;
            this.cbbFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbFuncionario.FormattingEnabled = true;
            this.cbbFuncionario.Location = new System.Drawing.Point(9, 94);
            this.cbbFuncionario.Name = "cbbFuncionario";
            this.cbbFuncionario.Size = new System.Drawing.Size(254, 21);
            this.cbbFuncionario.TabIndex = 14;
            this.cbbFuncionario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbFuncionario_KeyPress);
            // 
            // btnPesqOS
            // 
            this.btnPesqOS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesqOS.Image = ((System.Drawing.Image)(resources.GetObject("btnPesqOS.Image")));
            this.btnPesqOS.Location = new System.Drawing.Point(528, 52);
            this.btnPesqOS.Name = "btnPesqOS";
            this.btnPesqOS.Size = new System.Drawing.Size(26, 25);
            this.btnPesqOS.TabIndex = 11;
            this.btnPesqOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComissoes.SetToolTip(this.btnPesqOS, "Clique para pesquisar uma Ordem de Serviço.");
            this.btnPesqOS.UseVisualStyleBackColor = true;
            this.btnPesqOS.Click += new System.EventHandler(this.btnPesqOS_Click);
            // 
            // lblCodOS
            // 
            this.lblCodOS.AutoSize = true;
            this.lblCodOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodOS.Location = new System.Drawing.Point(406, 39);
            this.lblCodOS.Name = "lblCodOS";
            this.lblCodOS.Size = new System.Drawing.Size(84, 13);
            this.lblCodOS.TabIndex = 30;
            this.lblCodOS.Text = "Cód. da O.S.:";
            // 
            // txtCodOS
            // 
            this.txtCodOS.BackColor = System.Drawing.Color.White;
            this.txtCodOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodOS.Location = new System.Drawing.Point(409, 55);
            this.txtCodOS.MaxLength = 10;
            this.txtCodOS.Name = "txtCodOS";
            this.txtCodOS.Size = new System.Drawing.Size(113, 20);
            this.txtCodOS.TabIndex = 10;
            this.txtCodOS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodOS.Enter += new System.EventHandler(this.txtCodOS_Enter);
            this.txtCodOS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodOS_KeyPress);
            this.txtCodOS.Leave += new System.EventHandler(this.txtCodOS_Leave);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(674, 16);
            this.txtpCodigo.MaxLength = 10;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtpCodigo.TabIndex = 4;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacao.Location = new System.Drawing.Point(607, 78);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(61, 13);
            this.lblSituacao.TabIndex = 0;
            this.lblSituacao.Text = "Situação:";
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(332, 52);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 9;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComissoes.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            // 
            // cbbSituacao
            // 
            this.cbbSituacao.BackColor = System.Drawing.Color.LightBlue;
            this.cbbSituacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSituacao.DropDownWidth = 115;
            this.cbbSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSituacao.FormattingEnabled = true;
            this.cbbSituacao.Items.AddRange(new object[] {
            "",
            "PENDENTE",
            "CONCLUÍDO"});
            this.cbbSituacao.Location = new System.Drawing.Point(609, 94);
            this.cbbSituacao.Name = "cbbSituacao";
            this.cbbSituacao.Size = new System.Drawing.Size(145, 21);
            this.cbbSituacao.TabIndex = 16;
            this.cbbSituacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbSituacao_KeyPress);
            // 
            // mtxtHorario1
            // 
            this.mtxtHorario1.BackColor = System.Drawing.Color.White;
            this.mtxtHorario1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorario1.Location = new System.Drawing.Point(269, 55);
            this.mtxtHorario1.Mask = "00:00:00";
            this.mtxtHorario1.Name = "mtxtHorario1";
            this.mtxtHorario1.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario1.TabIndex = 8;
            this.mtxtHorario1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorario1.DoubleClick += new System.EventHandler(this.mtxtHorario1_DoubleClick);
            this.mtxtHorario1.Enter += new System.EventHandler(this.mtxtHorario1_Enter);
            this.mtxtHorario1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorario1_KeyPress);
            this.mtxtHorario1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorario1_KeyUp);
            this.mtxtHorario1.Leave += new System.EventHandler(this.mtxtHorario1_Leave);
            // 
            // mtxtHorario
            // 
            this.mtxtHorario.BackColor = System.Drawing.Color.White;
            this.mtxtHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorario.Location = new System.Drawing.Point(90, 55);
            this.mtxtHorario.Mask = "00:00:00";
            this.mtxtHorario.Name = "mtxtHorario";
            this.mtxtHorario.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario.TabIndex = 6;
            this.mtxtHorario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorario.DoubleClick += new System.EventHandler(this.mtxtHorario_DoubleClick);
            this.mtxtHorario.Enter += new System.EventHandler(this.mtxtHorario_Enter);
            this.mtxtHorario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorario_KeyPress);
            this.mtxtHorario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorario_KeyUp);
            this.mtxtHorario.Leave += new System.EventHandler(this.mtxtHorario_Leave);
            // 
            // lblDataVenda
            // 
            this.lblDataVenda.AutoSize = true;
            this.lblDataVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataVenda.Location = new System.Drawing.Point(3, 39);
            this.lblDataVenda.Name = "lblDataVenda";
            this.lblDataVenda.Size = new System.Drawing.Size(152, 13);
            this.lblDataVenda.TabIndex = 0;
            this.lblDataVenda.Text = "Data e Horário da Venda:";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(153, 58);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(185, 55);
            this.mtxtpData1.Mask = "00/00/0000";
            this.mtxtpData1.Name = "mtxtpData1";
            this.mtxtpData1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData1.TabIndex = 7;
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
            this.mtxtpData.Location = new System.Drawing.Point(6, 55);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 5;
            this.mtxtpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData.DoubleClick += new System.EventHandler(this.mtxtpData_DoubleClick);
            this.mtxtpData.Enter += new System.EventHandler(this.mtxtpData_Enter);
            this.mtxtpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData_KeyPress);
            this.mtxtpData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData_KeyUp);
            this.mtxtpData.Leave += new System.EventHandler(this.mtxtpData_Leave);
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
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(70, 19);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 3;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(6, 19);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 2;
            this.rbtnCodigo.TabStop = true;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            // 
            // dtCom
            // 
            this.dtCom.AllowUserToAddRows = false;
            this.dtCom.AllowUserToDeleteRows = false;
            this.dtCom.AllowUserToOrderColumns = true;
            this.dtCom.AllowUserToResizeRows = false;
            this.dtCom.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtCom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtCom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtCom.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtCom.Enabled = false;
            this.dtCom.Location = new System.Drawing.Point(32, 213);
            this.dtCom.MultiSelect = false;
            this.dtCom.Name = "dtCom";
            this.dtCom.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtCom.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtCom.RowHeadersVisible = false;
            this.dtCom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtCom.ShowCellErrors = false;
            this.dtCom.ShowCellToolTips = false;
            this.dtCom.ShowEditingIcon = false;
            this.dtCom.ShowRowErrors = false;
            this.dtCom.Size = new System.Drawing.Size(763, 172);
            this.dtCom.TabIndex = 18;
            this.dtCom.DataSourceChanged += new System.EventHandler(this.dtCom_DataSourceChanged);
            this.dtCom.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtCom_CellEnter);
            this.dtCom.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtCom_CellFormatting);
            this.dtCom.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtCom_RowsAdded);
            this.dtCom.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtCom_RowsRemoved);
            this.dtCom.MouseLeave += new System.EventHandler(this.dtCom_MouseLeave);
            this.dtCom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtCom_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(713, 176);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 17;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComissoes.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(687, 176);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 234;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(32, 388);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 239;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.lblValorSituacao);
            this.grbBox2.Controls.Add(this.lblCxSituacao);
            this.grbBox2.Controls.Add(this.btnBaixaRegistro);
            this.grbBox2.Controls.Add(this.btnTodasContas);
            this.grbBox2.Controls.Add(this.btnExportarCsv);
            this.grbBox2.Controls.Add(this.rbtnExportarTxt);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(32, 416);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(763, 50);
            this.grbBox2.TabIndex = 240;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Ações:";
            // 
            // lblValorSituacao
            // 
            this.lblValorSituacao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorSituacao.BackColor = System.Drawing.Color.Transparent;
            this.lblValorSituacao.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorSituacao.ForeColor = System.Drawing.Color.Black;
            this.lblValorSituacao.Location = new System.Drawing.Point(35, 17);
            this.lblValorSituacao.Name = "lblValorSituacao";
            this.lblValorSituacao.Size = new System.Drawing.Size(110, 26);
            this.lblValorSituacao.TabIndex = 41;
            this.lblValorSituacao.Text = "Situação";
            this.lblValorSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValorSituacao.Visible = false;
            // 
            // lblCxSituacao
            // 
            this.lblCxSituacao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCxSituacao.BackColor = System.Drawing.Color.White;
            this.lblCxSituacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCxSituacao.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCxSituacao.ForeColor = System.Drawing.Color.Black;
            this.lblCxSituacao.Location = new System.Drawing.Point(7, 20);
            this.lblCxSituacao.Name = "lblCxSituacao";
            this.lblCxSituacao.Size = new System.Drawing.Size(22, 20);
            this.lblCxSituacao.TabIndex = 42;
            this.lblCxSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCxSituacao.Visible = false;
            // 
            // btnBaixaRegistro
            // 
            this.btnBaixaRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaixaRegistro.Image = ((System.Drawing.Image)(resources.GetObject("btnBaixaRegistro.Image")));
            this.btnBaixaRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaixaRegistro.Location = new System.Drawing.Point(247, 19);
            this.btnBaixaRegistro.Name = "btnBaixaRegistro";
            this.btnBaixaRegistro.Size = new System.Drawing.Size(105, 25);
            this.btnBaixaRegistro.TabIndex = 39;
            this.btnBaixaRegistro.Text = "&Baixar Registro";
            this.btnBaixaRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComissoes.SetToolTip(this.btnBaixaRegistro, "Clique para baixar/confirmar o registro selecionado.");
            this.btnBaixaRegistro.UseVisualStyleBackColor = true;
            this.btnBaixaRegistro.Click += new System.EventHandler(this.btnBaixaRegistro_Click);
            // 
            // btnTodasContas
            // 
            this.btnTodasContas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTodasContas.Image = ((System.Drawing.Image)(resources.GetObject("btnTodasContas.Image")));
            this.btnTodasContas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTodasContas.Location = new System.Drawing.Point(358, 19);
            this.btnTodasContas.Name = "btnTodasContas";
            this.btnTodasContas.Size = new System.Drawing.Size(116, 25);
            this.btnTodasContas.TabIndex = 37;
            this.btnTodasContas.Text = "&Relatório em PDF";
            this.btnTodasContas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComissoes.SetToolTip(this.btnTodasContas, "Clique para gerar em PDF o relatório de Comissões.");
            this.btnTodasContas.UseVisualStyleBackColor = true;
            this.btnTodasContas.Click += new System.EventHandler(this.btnTodasContas_Click);
            // 
            // btnExportarCsv
            // 
            this.btnExportarCsv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportarCsv.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarCsv.Image")));
            this.btnExportarCsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarCsv.Location = new System.Drawing.Point(480, 19);
            this.btnExportarCsv.Name = "btnExportarCsv";
            this.btnExportarCsv.Size = new System.Drawing.Size(135, 25);
            this.btnExportarCsv.TabIndex = 32;
            this.btnExportarCsv.Text = "Exp. dados &para (.csv)";
            this.btnExportarCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComissoes.SetToolTip(this.btnExportarCsv, "Gerar arquivo da grade de dados em (.csv)(Excel).");
            this.btnExportarCsv.UseVisualStyleBackColor = true;
            this.btnExportarCsv.Click += new System.EventHandler(this.btnExportarCsv_Click);
            // 
            // rbtnExportarTxt
            // 
            this.rbtnExportarTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnExportarTxt.Image = ((System.Drawing.Image)(resources.GetObject("rbtnExportarTxt.Image")));
            this.rbtnExportarTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtnExportarTxt.Location = new System.Drawing.Point(621, 19);
            this.rbtnExportarTxt.Name = "rbtnExportarTxt";
            this.rbtnExportarTxt.Size = new System.Drawing.Size(133, 25);
            this.rbtnExportarTxt.TabIndex = 38;
            this.rbtnExportarTxt.Text = "Exp. d&ados para (.txt)";
            this.rbtnExportarTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComissoes.SetToolTip(this.rbtnExportarTxt, "Gerar arquivo da grade de dados em (.txt)(Bloco de Notas).");
            this.rbtnExportarTxt.UseVisualStyleBackColor = true;
            this.rbtnExportarTxt.Click += new System.EventHandler(this.rbtnExportarTxt_Click);
            // 
            // btnSair
            // 
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(740, 472);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 241;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComissoes.SetToolTip(this.btnSair, "Sair do Relatório de Comissões.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // pEnabled
            // 
            this.pEnabled.Controls.Add(this.picbInterrogacao2);
            this.pEnabled.Controls.Add(this.pgbProgresso);
            this.pEnabled.Controls.Add(this.lblProgresso);
            this.pEnabled.Controls.Add(this.lblValorAPagar);
            this.pEnabled.Controls.Add(this.lblValorPago);
            this.pEnabled.Controls.Add(this.lblValorTotal);
            this.pEnabled.Controls.Add(this.lblaPagar);
            this.pEnabled.Controls.Add(this.lblPago);
            this.pEnabled.Controls.Add(this.lblTotal);
            this.pEnabled.Controls.Add(this.btnSair);
            this.pEnabled.Controls.Add(this.grbBox1);
            this.pEnabled.Controls.Add(this.grbBox2);
            this.pEnabled.Controls.Add(this.btnPesquisar);
            this.pEnabled.Controls.Add(this.picbInterrogacao1);
            this.pEnabled.Controls.Add(this.dtCom);
            this.pEnabled.Controls.Add(this.lblRegistros);
            this.pEnabled.Location = new System.Drawing.Point(-23, -35);
            this.pEnabled.Name = "pEnabled";
            this.pEnabled.Size = new System.Drawing.Size(834, 532);
            this.pEnabled.TabIndex = 242;
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.Location = new System.Drawing.Point(32, 472);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 250;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.pgbProgresso.Location = new System.Drawing.Point(263, 301);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(321, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 248;
            this.pgbProgresso.Visible = false;
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(273, 268);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(300, 33);
            this.lblProgresso.TabIndex = 249;
            this.lblProgresso.Text = "Por favor, aguarde...";
            this.lblProgresso.Visible = false;
            // 
            // lblValorAPagar
            // 
            this.lblValorAPagar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorAPagar.BackColor = System.Drawing.Color.White;
            this.lblValorAPagar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorAPagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblValorAPagar.Enabled = false;
            this.lblValorAPagar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorAPagar.ForeColor = System.Drawing.Color.Black;
            this.lblValorAPagar.Location = new System.Drawing.Point(521, 388);
            this.lblValorAPagar.Name = "lblValorAPagar";
            this.lblValorAPagar.Size = new System.Drawing.Size(86, 26);
            this.lblValorAPagar.TabIndex = 242;
            this.lblValorAPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorAPagar.Click += new System.EventHandler(this.lblValorAPagar_Click);
            // 
            // lblValorPago
            // 
            this.lblValorPago.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorPago.BackColor = System.Drawing.Color.White;
            this.lblValorPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblValorPago.Enabled = false;
            this.lblValorPago.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorPago.ForeColor = System.Drawing.Color.Black;
            this.lblValorPago.Location = new System.Drawing.Point(321, 388);
            this.lblValorPago.Name = "lblValorPago";
            this.lblValorPago.Size = new System.Drawing.Size(86, 26);
            this.lblValorPago.TabIndex = 243;
            this.lblValorPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorPago.Click += new System.EventHandler(this.lblValorPago_Click);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorTotal.BackColor = System.Drawing.Color.White;
            this.lblValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblValorTotal.Enabled = false;
            this.lblValorTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotal.Location = new System.Drawing.Point(709, 388);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(86, 26);
            this.lblValorTotal.TabIndex = 244;
            this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotal.Click += new System.EventHandler(this.lblValorTotal_Click);
            // 
            // lblaPagar
            // 
            this.lblaPagar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblaPagar.BackColor = System.Drawing.Color.Transparent;
            this.lblaPagar.Enabled = false;
            this.lblaPagar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblaPagar.ForeColor = System.Drawing.Color.Red;
            this.lblaPagar.Location = new System.Drawing.Point(414, 387);
            this.lblaPagar.Name = "lblaPagar";
            this.lblaPagar.Size = new System.Drawing.Size(109, 26);
            this.lblaPagar.TabIndex = 245;
            this.lblaPagar.Text = "a Pagar (R$):";
            this.lblaPagar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPago
            // 
            this.lblPago.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPago.BackColor = System.Drawing.Color.Transparent;
            this.lblPago.Enabled = false;
            this.lblPago.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPago.ForeColor = System.Drawing.Color.Green;
            this.lblPago.Location = new System.Drawing.Point(232, 387);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(90, 26);
            this.lblPago.TabIndex = 246;
            this.lblPago.Text = "Pago (R$):";
            this.lblPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Enabled = false;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(613, 387);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(90, 26);
            this.lblTotal.TabIndex = 247;
            this.lblTotal.Text = "Total (R$):";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ttpComissoes
            // 
            this.ttpComissoes.AutoPopDelay = 5000;
            this.ttpComissoes.InitialDelay = 1000;
            this.ttpComissoes.IsBalloon = true;
            this.ttpComissoes.ReshowDelay = 100;
            this.ttpComissoes.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpComissoes.ToolTipTitle = "Dica:";
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // FrmRelComissao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(784, 480);
            this.ControlBox = false;
            this.Controls.Add(this.pEnabled);
            this.KeyPreview = true;
            this.Name = "FrmRelComissao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Comissões";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRelComissao_FormClosing);
            this.Load += new System.EventHandler(this.FrmRelComissao_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRelComissao_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.grbBox2.ResumeLayout(false);
            this.pEnabled.ResumeLayout(false);
            this.pEnabled.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnPesqOS;
        private System.Windows.Forms.Label lblCodOS;
        private System.Windows.Forms.TextBox txtCodOS;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.ComboBox cbbSituacao;
        private System.Windows.Forms.MaskedTextBox mtxtHorario1;
        private System.Windows.Forms.MaskedTextBox mtxtHorario;
        private System.Windows.Forms.Label lblDataVenda;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.Button btnPesqVenda;
        private System.Windows.Forms.Label lblCodVenda;
        private System.Windows.Forms.TextBox txtCodVenda;
        private System.Windows.Forms.Label lblFuncionario;
        private System.Windows.Forms.ComboBox cbbFuncionario;
        private System.Windows.Forms.DataGridView dtCom;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnTodasContas;
        private System.Windows.Forms.Button btnExportarCsv;
        private System.Windows.Forms.Button rbtnExportarTxt;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel pEnabled;
        private System.Windows.Forms.ToolTip ttpComissoes;
        private System.Windows.Forms.Button btnBaixaRegistro;
        private System.Windows.Forms.Label lblValorSituacao;
        private System.Windows.Forms.Label lblCxSituacao;
        private System.Windows.Forms.Label lblValorAPagar;
        private System.Windows.Forms.Label lblValorPago;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblaPagar;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnPesqFuncionario;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.Windows.Forms.Label lblProgresso;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
    }
}