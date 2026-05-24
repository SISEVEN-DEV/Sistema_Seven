namespace Seven_Sistema
{
    partial class FrmRelDevolucao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelDevolucao));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnCodVenda = new System.Windows.Forms.RadioButton();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cbbTipoDevolucao = new System.Windows.Forms.ComboBox();
            this.btnProcurarConsumidor = new System.Windows.Forms.Button();
            this.lblConsumidor = new System.Windows.Forms.Label();
            this.cbbConsumidor = new System.Windows.Forms.ComboBox();
            this.lblDatas = new System.Windows.Forms.Label();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.btnProcurar1 = new System.Windows.Forms.Button();
            this.btnProcurarUsuario = new System.Windows.Forms.Button();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.lblCodPDV = new System.Windows.Forms.Label();
            this.cbbCodPDV = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.mtxtHorario1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtHorario = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.lblAte = new System.Windows.Forms.Label();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.cbbUsuario = new System.Windows.Forms.ComboBox();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.dtDevolucao = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.ttpDevolucao = new System.Windows.Forms.ToolTip(this.components);
            this.btnRelatorioPDF = new System.Windows.Forms.Button();
            this.btnExportarCsv = new System.Windows.Forms.Button();
            this.rbtnExportarTxt = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnGerarCupom = new System.Windows.Forms.Button();
            this.btnConsultarItens = new System.Windows.Forms.Button();
            this.btnConsultarItensInc = new System.Windows.Forms.Button();
            this.btnConsultarValoresDev = new System.Windows.Forms.Button();
            this.btnVendaOrcamento = new System.Windows.Forms.Button();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblValorTotalDev = new System.Windows.Forms.Label();
            this.lblTotalDev = new System.Windows.Forms.Label();
            this.lblNovosItens = new System.Windows.Forms.Label();
            this.lblValorTotNovItem = new System.Windows.Forms.Label();
            this.pEnabled = new System.Windows.Forms.Panel();
            this.btnProcurarVenda = new System.Windows.Forms.Button();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDevolucao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.grbBox2.SuspendLayout();
            this.pEnabled.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnProcurarVenda);
            this.grbBox1.Controls.Add(this.rbtnCodVenda);
            this.grbBox1.Controls.Add(this.lblTipo);
            this.grbBox1.Controls.Add(this.cbbTipoDevolucao);
            this.grbBox1.Controls.Add(this.btnProcurarConsumidor);
            this.grbBox1.Controls.Add(this.lblConsumidor);
            this.grbBox1.Controls.Add(this.cbbConsumidor);
            this.grbBox1.Controls.Add(this.lblDatas);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.btnProcurar1);
            this.grbBox1.Controls.Add(this.btnProcurarUsuario);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.lblCodPDV);
            this.grbBox1.Controls.Add(this.cbbCodPDV);
            this.grbBox1.Controls.Add(this.lblUsuario);
            this.grbBox1.Controls.Add(this.mtxtHorario1);
            this.grbBox1.Controls.Add(this.mtxtHorario);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.cbbUsuario);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Location = new System.Drawing.Point(27, 50);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(821, 123);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            this.grbBox1.Enter += new System.EventHandler(this.grbBox1_Enter);
            // 
            // rbtnCodVenda
            // 
            this.rbtnCodVenda.AutoSize = true;
            this.rbtnCodVenda.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodVenda.Location = new System.Drawing.Point(70, 19);
            this.rbtnCodVenda.Name = "rbtnCodVenda";
            this.rbtnCodVenda.Size = new System.Drawing.Size(107, 17);
            this.rbtnCodVenda.TabIndex = 3;
            this.rbtnCodVenda.TabStop = true;
            this.rbtnCodVenda.Text = "Código da Venda";
            this.rbtnCodVenda.UseVisualStyleBackColor = true;
            this.rbtnCodVenda.CheckedChanged += new System.EventHandler(this.rbtnCodVenda_CheckedChanged);
            this.rbtnCodVenda.MouseLeave += new System.EventHandler(this.rbtnCodVenda_MouseLeave);
            this.rbtnCodVenda.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodVenda_MouseMove);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Enabled = false;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(464, 79);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(119, 13);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo de Devolução:";
            // 
            // cbbTipoDevolucao
            // 
            this.cbbTipoDevolucao.BackColor = System.Drawing.Color.LightBlue;
            this.cbbTipoDevolucao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoDevolucao.DropDownWidth = 470;
            this.cbbTipoDevolucao.Enabled = false;
            this.cbbTipoDevolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTipoDevolucao.FormattingEnabled = true;
            this.cbbTipoDevolucao.Items.AddRange(new object[] {
            "",
            "DEVOLUCAO EM CREDITO LOJA",
            "DEVOLUCAO EM DINHEIRO",
            "DEVOLUCAO EM PRODUTOS",
            "DEVOLUCAO PARCIAL DE PRODUTOS COM DEVOLUCAO EM DINHEIRO",
            "DEVOLUCAO PARCIAL DE PRODUTOS COM DEVOLUCAO EM CREDITO LOJA"});
            this.cbbTipoDevolucao.Location = new System.Drawing.Point(467, 94);
            this.cbbTipoDevolucao.Name = "cbbTipoDevolucao";
            this.cbbTipoDevolucao.Size = new System.Drawing.Size(348, 21);
            this.cbbTipoDevolucao.TabIndex = 17;
            this.cbbTipoDevolucao.DropDown += new System.EventHandler(this.cbbTipoDevolucao_DropDown);
            this.cbbTipoDevolucao.DropDownClosed += new System.EventHandler(this.cbbTipoDevolucao_DropDownClosed);
            this.cbbTipoDevolucao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbTipoDevolucao_KeyPress);
            this.cbbTipoDevolucao.MouseLeave += new System.EventHandler(this.cbbTipoDevolucao_MouseLeave);
            this.cbbTipoDevolucao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbTipoDevolucao_MouseMove);
            // 
            // btnProcurarConsumidor
            // 
            this.btnProcurarConsumidor.Enabled = false;
            this.btnProcurarConsumidor.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarConsumidor.Image")));
            this.btnProcurarConsumidor.Location = new System.Drawing.Point(332, 91);
            this.btnProcurarConsumidor.Name = "btnProcurarConsumidor";
            this.btnProcurarConsumidor.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarConsumidor.TabIndex = 16;
            this.btnProcurarConsumidor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnProcurarConsumidor, "Clique para pesquisar um Consumidor.");
            this.btnProcurarConsumidor.UseVisualStyleBackColor = true;
            this.btnProcurarConsumidor.Click += new System.EventHandler(this.btnProcurarConsumidor_Click);
            this.btnProcurarConsumidor.MouseLeave += new System.EventHandler(this.btnProcurarConsumidor_MouseLeave);
            this.btnProcurarConsumidor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarConsumidor_MouseMove);
            // 
            // lblConsumidor
            // 
            this.lblConsumidor.AutoSize = true;
            this.lblConsumidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsumidor.Location = new System.Drawing.Point(3, 78);
            this.lblConsumidor.Name = "lblConsumidor";
            this.lblConsumidor.Size = new System.Drawing.Size(76, 13);
            this.lblConsumidor.TabIndex = 0;
            this.lblConsumidor.Text = "Consumidor:";
            // 
            // cbbConsumidor
            // 
            this.cbbConsumidor.BackColor = System.Drawing.Color.LightBlue;
            this.cbbConsumidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbConsumidor.DropDownWidth = 550;
            this.cbbConsumidor.Enabled = false;
            this.cbbConsumidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbConsumidor.FormattingEnabled = true;
            this.cbbConsumidor.Location = new System.Drawing.Point(6, 94);
            this.cbbConsumidor.Name = "cbbConsumidor";
            this.cbbConsumidor.Size = new System.Drawing.Size(320, 21);
            this.cbbConsumidor.TabIndex = 15;
            this.cbbConsumidor.DropDown += new System.EventHandler(this.cbbConsumidor_DropDown);
            this.cbbConsumidor.DropDownClosed += new System.EventHandler(this.cbbConsumidor_DropDownClosed);
            this.cbbConsumidor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbConsumidor_KeyPress);
            this.cbbConsumidor.MouseLeave += new System.EventHandler(this.cbbConsumidor_MouseLeave);
            this.cbbConsumidor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbConsumidor_MouseMove);
            // 
            // lblDatas
            // 
            this.lblDatas.AutoSize = true;
            this.lblDatas.Enabled = false;
            this.lblDatas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatas.Location = new System.Drawing.Point(3, 39);
            this.lblDatas.Name = "lblDatas";
            this.lblDatas.Size = new System.Drawing.Size(177, 13);
            this.lblDatas.TabIndex = 0;
            this.lblDatas.Text = "Data e Horário da Devolução:";
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(183, 19);
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
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(6, 19);
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
            // btnProcurar1
            // 
            this.btnProcurar1.Enabled = false;
            this.btnProcurar1.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurar1.Image")));
            this.btnProcurar1.Location = new System.Drawing.Point(789, 52);
            this.btnProcurar1.Name = "btnProcurar1";
            this.btnProcurar1.Size = new System.Drawing.Size(26, 25);
            this.btnProcurar1.TabIndex = 14;
            this.btnProcurar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnProcurar1, "Clique para pesquisar um Computador/PDV.");
            this.btnProcurar1.UseVisualStyleBackColor = true;
            this.btnProcurar1.Click += new System.EventHandler(this.btnProcurar1_Click);
            this.btnProcurar1.MouseLeave += new System.EventHandler(this.btnProcurar1_MouseLeave);
            this.btnProcurar1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurar1_MouseMove);
            // 
            // btnProcurarUsuario
            // 
            this.btnProcurarUsuario.Enabled = false;
            this.btnProcurarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarUsuario.Image")));
            this.btnProcurarUsuario.Location = new System.Drawing.Point(586, 52);
            this.btnProcurarUsuario.Name = "btnProcurarUsuario";
            this.btnProcurarUsuario.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarUsuario.TabIndex = 11;
            this.btnProcurarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnProcurarUsuario, "Clique para pesquisar um Usuário.");
            this.btnProcurarUsuario.UseVisualStyleBackColor = true;
            this.btnProcurarUsuario.Click += new System.EventHandler(this.btnProcurarUsuario_Click);
            this.btnProcurarUsuario.MouseLeave += new System.EventHandler(this.btnProcurarUsuario_MouseLeave);
            this.btnProcurarUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarUsuario_MouseMove);
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Enabled = false;
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(332, 52);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 9;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // lblCodPDV
            // 
            this.lblCodPDV.AutoSize = true;
            this.lblCodPDV.Enabled = false;
            this.lblCodPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodPDV.Location = new System.Drawing.Point(722, 38);
            this.lblCodPDV.Name = "lblCodPDV";
            this.lblCodPDV.Size = new System.Drawing.Size(84, 13);
            this.lblCodPDV.TabIndex = 0;
            this.lblCodPDV.Text = "Cód. do PDV:";
            // 
            // cbbCodPDV
            // 
            this.cbbCodPDV.BackColor = System.Drawing.Color.LightBlue;
            this.cbbCodPDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCodPDV.DropDownWidth = 80;
            this.cbbCodPDV.Enabled = false;
            this.cbbCodPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCodPDV.FormattingEnabled = true;
            this.cbbCodPDV.Location = new System.Drawing.Point(725, 54);
            this.cbbCodPDV.Name = "cbbCodPDV";
            this.cbbCodPDV.Size = new System.Drawing.Size(58, 21);
            this.cbbCodPDV.TabIndex = 13;
            this.cbbCodPDV.DropDown += new System.EventHandler(this.cbbCodPDV_DropDown);
            this.cbbCodPDV.DropDownClosed += new System.EventHandler(this.cbbCodPDV_DropDownClosed);
            this.cbbCodPDV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbCodPDV_KeyPress);
            this.cbbCodPDV.MouseLeave += new System.EventHandler(this.cbbCodPDV_MouseLeave);
            this.cbbCodPDV.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbCodPDV_MouseMove);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Enabled = false;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(464, 39);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(54, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuário:";
            // 
            // mtxtHorario1
            // 
            this.mtxtHorario1.BackColor = System.Drawing.Color.White;
            this.mtxtHorario1.Enabled = false;
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
            this.mtxtHorario.Enabled = false;
            this.mtxtHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorario.Location = new System.Drawing.Point(90, 55);
            this.mtxtHorario.Mask = "00:00:00";
            this.mtxtHorario.Name = "mtxtHorario";
            this.mtxtHorario.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario.TabIndex = 6;
            this.mtxtHorario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorario.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtxtHorario_MaskInputRejected);
            this.mtxtHorario.DoubleClick += new System.EventHandler(this.mtxtHorario_DoubleClick);
            this.mtxtHorario.Enter += new System.EventHandler(this.mtxtHorario_Enter);
            this.mtxtHorario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorario_KeyPress);
            this.mtxtHorario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorario_KeyUp);
            this.mtxtHorario.Leave += new System.EventHandler(this.mtxtHorario_Leave);
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Enabled = false;
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
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Enabled = false;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(153, 58);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // mtxtpData
            // 
            this.mtxtpData.BackColor = System.Drawing.Color.White;
            this.mtxtpData.Enabled = false;
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
            // cbbUsuario
            // 
            this.cbbUsuario.BackColor = System.Drawing.Color.LightBlue;
            this.cbbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUsuario.DropDownWidth = 180;
            this.cbbUsuario.Enabled = false;
            this.cbbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUsuario.FormattingEnabled = true;
            this.cbbUsuario.Location = new System.Drawing.Point(467, 54);
            this.cbbUsuario.Name = "cbbUsuario";
            this.cbbUsuario.Size = new System.Drawing.Size(113, 21);
            this.cbbUsuario.TabIndex = 10;
            this.cbbUsuario.DropDown += new System.EventHandler(this.cbbUsuario_DropDown);
            this.cbbUsuario.DropDownClosed += new System.EventHandler(this.cbbUsuario_DropDownClosed);
            this.cbbUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbUsuario_KeyPress);
            this.cbbUsuario.MouseLeave += new System.EventHandler(this.cbbUsuario_MouseLeave);
            this.cbbUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbUsuario_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(703, 18);
            this.txtpCodigo.MaxLength = 9;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtpCodigo.TabIndex = 4;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(543, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(154, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite o código da venda:";
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(305, 267);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(300, 33);
            this.lblProgresso.TabIndex = 245;
            this.lblProgresso.Text = "Por favor, aguarde...";
            this.lblProgresso.Visible = false;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.pgbProgresso.Location = new System.Drawing.Point(295, 300);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(321, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 246;
            this.pgbProgresso.Visible = false;
            // 
            // dtDevolucao
            // 
            this.dtDevolucao.AllowUserToAddRows = false;
            this.dtDevolucao.AllowUserToDeleteRows = false;
            this.dtDevolucao.AllowUserToResizeRows = false;
            this.dtDevolucao.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtDevolucao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDevolucao.Enabled = false;
            this.dtDevolucao.Location = new System.Drawing.Point(27, 216);
            this.dtDevolucao.MultiSelect = false;
            this.dtDevolucao.Name = "dtDevolucao";
            this.dtDevolucao.ReadOnly = true;
            this.dtDevolucao.RowHeadersVisible = false;
            this.dtDevolucao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtDevolucao.ShowCellErrors = false;
            this.dtDevolucao.ShowCellToolTips = false;
            this.dtDevolucao.ShowEditingIcon = false;
            this.dtDevolucao.ShowRowErrors = false;
            this.dtDevolucao.Size = new System.Drawing.Size(820, 172);
            this.dtDevolucao.TabIndex = 19;
            this.dtDevolucao.TabStop = false;
            this.dtDevolucao.DataSourceChanged += new System.EventHandler(this.dtDevolucao_DataSourceChanged);
            this.dtDevolucao.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDevolucao_CellEnter);
            this.dtDevolucao.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtDevolucao_CellFormatting);
            this.dtDevolucao.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtDevolucao_RowsAdded);
            this.dtDevolucao.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtDevolucao_RowsRemoved);
            this.dtDevolucao.MouseLeave += new System.EventHandler(this.dtDevolucao_MouseLeave);
            this.dtDevolucao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtDevolucao_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(24, 391);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(742, 179);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 249;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(768, 179);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 18;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // ttpDevolucao
            // 
            this.ttpDevolucao.AutoPopDelay = 5000;
            this.ttpDevolucao.InitialDelay = 1000;
            this.ttpDevolucao.IsBalloon = true;
            this.ttpDevolucao.ReshowDelay = 100;
            this.ttpDevolucao.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpDevolucao.ToolTipTitle = "Dica:";
            // 
            // btnRelatorioPDF
            // 
            this.btnRelatorioPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorioPDF.Image")));
            this.btnRelatorioPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorioPDF.Location = new System.Drawing.Point(238, 50);
            this.btnRelatorioPDF.Name = "btnRelatorioPDF";
            this.btnRelatorioPDF.Size = new System.Drawing.Size(160, 25);
            this.btnRelatorioPDF.TabIndex = 26;
            this.btnRelatorioPDF.Text = "&Relatório em PDF";
            this.ttpDevolucao.SetToolTip(this.btnRelatorioPDF, "Clique para gerar em PDF o relatório resumido de Devolução/Troca.");
            this.btnRelatorioPDF.UseVisualStyleBackColor = true;
            this.btnRelatorioPDF.Click += new System.EventHandler(this.btnRelatorioPDF_Click);
            this.btnRelatorioPDF.MouseLeave += new System.EventHandler(this.btnRelatorioPDF_MouseLeave);
            this.btnRelatorioPDF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRelatorioPDF_MouseMove);
            // 
            // btnExportarCsv
            // 
            this.btnExportarCsv.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarCsv.Image")));
            this.btnExportarCsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarCsv.Location = new System.Drawing.Point(452, 50);
            this.btnExportarCsv.Name = "btnExportarCsv";
            this.btnExportarCsv.Size = new System.Drawing.Size(149, 25);
            this.btnExportarCsv.TabIndex = 30;
            this.btnExportarCsv.Text = "E&xp. dados para (.csv)";
            this.btnExportarCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnExportarCsv, "Gerar arquivo da grade de dados em (.csv)(Excel).");
            this.btnExportarCsv.UseVisualStyleBackColor = true;
            this.btnExportarCsv.Click += new System.EventHandler(this.btnExportarCsv_Click);
            this.btnExportarCsv.MouseLeave += new System.EventHandler(this.btnExportarCsv_MouseLeave);
            this.btnExportarCsv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExportarCsv_MouseMove);
            // 
            // rbtnExportarTxt
            // 
            this.rbtnExportarTxt.Image = ((System.Drawing.Image)(resources.GetObject("rbtnExportarTxt.Image")));
            this.rbtnExportarTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtnExportarTxt.Location = new System.Drawing.Point(644, 50);
            this.rbtnExportarTxt.Name = "rbtnExportarTxt";
            this.rbtnExportarTxt.Size = new System.Drawing.Size(171, 25);
            this.rbtnExportarTxt.TabIndex = 31;
            this.rbtnExportarTxt.Text = "Exp. d&ados para (.txt)";
            this.ttpDevolucao.SetToolTip(this.rbtnExportarTxt, "Gerar arquivo da grade de dados em (.txt)(Bloco de Notas).");
            this.rbtnExportarTxt.UseVisualStyleBackColor = true;
            this.rbtnExportarTxt.Click += new System.EventHandler(this.rbtnExportarTxt_Click);
            this.rbtnExportarTxt.MouseLeave += new System.EventHandler(this.rbtnExportarTxt_MouseLeave);
            this.rbtnExportarTxt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnExportarTxt_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(796, 508);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(54, 32);
            this.btnSair.TabIndex = 32;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnSair, "Sair do Relatório de Devolução/Troca.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnGerarCupom
            // 
            this.btnGerarCupom.Image = ((System.Drawing.Image)(resources.GetObject("btnGerarCupom.Image")));
            this.btnGerarCupom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerarCupom.Location = new System.Drawing.Point(6, 19);
            this.btnGerarCupom.Name = "btnGerarCupom";
            this.btnGerarCupom.Size = new System.Drawing.Size(171, 25);
            this.btnGerarCupom.TabIndex = 22;
            this.btnGerarCupom.Text = "&Cupom da Devolução/Troca";
            this.btnGerarCupom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnGerarCupom, "Clique para gerar em PDF o cupom do registro selecionado.");
            this.btnGerarCupom.UseVisualStyleBackColor = true;
            this.btnGerarCupom.Click += new System.EventHandler(this.btnGerarCupom_Click);
            this.btnGerarCupom.MouseLeave += new System.EventHandler(this.btnGerarCupom_MouseLeave);
            this.btnGerarCupom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnGerarCupom_MouseMove);
            // 
            // btnConsultarItens
            // 
            this.btnConsultarItens.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultarItens.Image")));
            this.btnConsultarItens.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultarItens.Location = new System.Drawing.Point(238, 19);
            this.btnConsultarItens.Name = "btnConsultarItens";
            this.btnConsultarItens.Size = new System.Drawing.Size(160, 25);
            this.btnConsultarItens.TabIndex = 23;
            this.btnConsultarItens.Text = "Consultar &Itens Devolvidos";
            this.btnConsultarItens.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnConsultarItens, "Clique para consultar os itens devolvidos do registro selecionado.");
            this.btnConsultarItens.UseVisualStyleBackColor = true;
            this.btnConsultarItens.Click += new System.EventHandler(this.btnConsultarItens_Click);
            this.btnConsultarItens.MouseLeave += new System.EventHandler(this.btnConsultarItens_MouseLeave);
            this.btnConsultarItens.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnConsultarItens_MouseMove);
            // 
            // btnConsultarItensInc
            // 
            this.btnConsultarItensInc.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultarItensInc.Image")));
            this.btnConsultarItensInc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultarItensInc.Location = new System.Drawing.Point(452, 19);
            this.btnConsultarItensInc.Name = "btnConsultarItensInc";
            this.btnConsultarItensInc.Size = new System.Drawing.Size(149, 25);
            this.btnConsultarItensInc.TabIndex = 24;
            this.btnConsultarItensInc.Text = "Consultar Ite&ns Incluídos";
            this.btnConsultarItensInc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnConsultarItensInc, "Clique para consultar os novos itens incluídos do registro selecionado.");
            this.btnConsultarItensInc.UseVisualStyleBackColor = true;
            this.btnConsultarItensInc.Click += new System.EventHandler(this.btnConsultarItensInc_Click);
            this.btnConsultarItensInc.MouseLeave += new System.EventHandler(this.btnConsultarItensInc_MouseLeave);
            this.btnConsultarItensInc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnConsultarItensInc_MouseMove);
            // 
            // btnConsultarValoresDev
            // 
            this.btnConsultarValoresDev.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultarValoresDev.Image")));
            this.btnConsultarValoresDev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultarValoresDev.Location = new System.Drawing.Point(644, 19);
            this.btnConsultarValoresDev.Name = "btnConsultarValoresDev";
            this.btnConsultarValoresDev.Size = new System.Drawing.Size(171, 25);
            this.btnConsultarValoresDev.TabIndex = 27;
            this.btnConsultarValoresDev.Text = "Consultar &Valores Devolvidos";
            this.btnConsultarValoresDev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnConsultarValoresDev, "Clique para consultar os pagamentos devolvidos do registro selecionado.");
            this.btnConsultarValoresDev.UseVisualStyleBackColor = true;
            this.btnConsultarValoresDev.Click += new System.EventHandler(this.btnConsultarValoresDev_Click);
            this.btnConsultarValoresDev.MouseLeave += new System.EventHandler(this.btnConsultarValoresDev_MouseLeave);
            this.btnConsultarValoresDev.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnConsultarValoresDev_MouseMove);
            // 
            // btnVendaOrcamento
            // 
            this.btnVendaOrcamento.Image = ((System.Drawing.Image)(resources.GetObject("btnVendaOrcamento.Image")));
            this.btnVendaOrcamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVendaOrcamento.Location = new System.Drawing.Point(6, 50);
            this.btnVendaOrcamento.Name = "btnVendaOrcamento";
            this.btnVendaOrcamento.Size = new System.Drawing.Size(171, 25);
            this.btnVendaOrcamento.TabIndex = 25;
            this.btnVendaOrcamento.Text = "Venda da Dev&olução";
            this.ttpDevolucao.SetToolTip(this.btnVendaOrcamento, "Clique para verificar a venda que gerou a devolução selecionada.");
            this.btnVendaOrcamento.UseVisualStyleBackColor = true;
            this.btnVendaOrcamento.Click += new System.EventHandler(this.btnVendaOrcamento_Click);
            this.btnVendaOrcamento.MouseLeave += new System.EventHandler(this.btnVendaOrcamento_MouseLeave);
            this.btnVendaOrcamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVendaOrcamento_MouseMove);
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.Location = new System.Drawing.Point(27, 508);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 253;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.btnVendaOrcamento);
            this.grbBox2.Controls.Add(this.btnConsultarValoresDev);
            this.grbBox2.Controls.Add(this.btnConsultarItensInc);
            this.grbBox2.Controls.Add(this.btnConsultarItens);
            this.grbBox2.Controls.Add(this.btnGerarCupom);
            this.grbBox2.Controls.Add(this.rbtnExportarTxt);
            this.grbBox2.Controls.Add(this.btnRelatorioPDF);
            this.grbBox2.Controls.Add(this.btnExportarCsv);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(27, 421);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(821, 81);
            this.grbBox2.TabIndex = 21;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Ações";
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorTotal.BackColor = System.Drawing.Color.White;
            this.lblValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotal.Enabled = false;
            this.lblValorTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotal.Location = new System.Drawing.Point(265, 391);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(112, 26);
            this.lblValorTotal.TabIndex = 0;
            this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotal.Click += new System.EventHandler(this.lblValorTotal_Click);
            this.lblValorTotal.MouseLeave += new System.EventHandler(this.lblValorSaldo_MouseLeave);
            this.lblValorTotal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorSaldo_MouseMove);
            // 
            // lblValor
            // 
            this.lblValor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValor.BackColor = System.Drawing.Color.Transparent;
            this.lblValor.Enabled = false;
            this.lblValor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.Color.Black;
            this.lblValor.Location = new System.Drawing.Point(187, 390);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(166, 26);
            this.lblValor.TabIndex = 0;
            this.lblValor.Text = "Total (R$):";
            this.lblValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorTotalDev
            // 
            this.lblValorTotalDev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorTotalDev.BackColor = System.Drawing.Color.White;
            this.lblValorTotalDev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotalDev.Enabled = false;
            this.lblValorTotalDev.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalDev.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotalDev.Location = new System.Drawing.Point(736, 392);
            this.lblValorTotalDev.Name = "lblValorTotalDev";
            this.lblValorTotalDev.Size = new System.Drawing.Size(112, 26);
            this.lblValorTotalDev.TabIndex = 0;
            this.lblValorTotalDev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotalDev.Click += new System.EventHandler(this.lblValorTotalDev_Click);
            this.lblValorTotalDev.MouseLeave += new System.EventHandler(this.lblValorTotalDev_MouseLeave);
            this.lblValorTotalDev.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotalDev_MouseMove);
            // 
            // lblTotalDev
            // 
            this.lblTotalDev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalDev.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalDev.Enabled = false;
            this.lblTotalDev.Font = new System.Drawing.Font("Calibri", 12.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalDev.ForeColor = System.Drawing.Color.Black;
            this.lblTotalDev.Location = new System.Drawing.Point(620, 391);
            this.lblTotalDev.Name = "lblTotalDev";
            this.lblTotalDev.Size = new System.Drawing.Size(219, 26);
            this.lblTotalDev.TabIndex = 0;
            this.lblTotalDev.Text = "Devolvido (R$):";
            this.lblTotalDev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNovosItens
            // 
            this.lblNovosItens.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNovosItens.BackColor = System.Drawing.Color.Transparent;
            this.lblNovosItens.Enabled = false;
            this.lblNovosItens.Font = new System.Drawing.Font("Calibri", 12.25F, System.Drawing.FontStyle.Bold);
            this.lblNovosItens.ForeColor = System.Drawing.Color.Black;
            this.lblNovosItens.Location = new System.Drawing.Point(376, 391);
            this.lblNovosItens.Name = "lblNovosItens";
            this.lblNovosItens.Size = new System.Drawing.Size(219, 26);
            this.lblNovosItens.TabIndex = 0;
            this.lblNovosItens.Text = "Novos Itens (R$):";
            this.lblNovosItens.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorTotNovItem
            // 
            this.lblValorTotNovItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorTotNovItem.BackColor = System.Drawing.Color.White;
            this.lblValorTotNovItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotNovItem.Enabled = false;
            this.lblValorTotNovItem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotNovItem.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotNovItem.Location = new System.Drawing.Point(504, 391);
            this.lblValorTotNovItem.Name = "lblValorTotNovItem";
            this.lblValorTotNovItem.Size = new System.Drawing.Size(112, 26);
            this.lblValorTotNovItem.TabIndex = 0;
            this.lblValorTotNovItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotNovItem.Click += new System.EventHandler(this.lblValorTotNovItem_Click);
            this.lblValorTotNovItem.MouseLeave += new System.EventHandler(this.lblValorTotNovItem_MouseLeave);
            this.lblValorTotNovItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotNovItem_MouseMove);
            // 
            // pEnabled
            // 
            this.pEnabled.Controls.Add(this.btnSair);
            this.pEnabled.Controls.Add(this.picbInterrogacao);
            this.pEnabled.Controls.Add(this.lblValorTotNovItem);
            this.pEnabled.Controls.Add(this.grbBox2);
            this.pEnabled.Controls.Add(this.grbBox1);
            this.pEnabled.Controls.Add(this.lblNovosItens);
            this.pEnabled.Controls.Add(this.btnPesquisar);
            this.pEnabled.Controls.Add(this.lblValorTotalDev);
            this.pEnabled.Controls.Add(this.picbInterrogacao1);
            this.pEnabled.Controls.Add(this.lblTotalDev);
            this.pEnabled.Controls.Add(this.pgbProgresso);
            this.pEnabled.Controls.Add(this.lblValorTotal);
            this.pEnabled.Controls.Add(this.lblProgresso);
            this.pEnabled.Controls.Add(this.lblValor);
            this.pEnabled.Controls.Add(this.dtDevolucao);
            this.pEnabled.Controls.Add(this.lblRegistros);
            this.pEnabled.Location = new System.Drawing.Point(-15, -38);
            this.pEnabled.Name = "pEnabled";
            this.pEnabled.Size = new System.Drawing.Size(885, 597);
            this.pEnabled.TabIndex = 254;
            // 
            // btnProcurarVenda
            // 
            this.btnProcurarVenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcurarVenda.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarVenda.Image")));
            this.btnProcurarVenda.Location = new System.Drawing.Point(789, 15);
            this.btnProcurarVenda.Name = "btnProcurarVenda";
            this.btnProcurarVenda.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarVenda.TabIndex = 18;
            this.btnProcurarVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnProcurarVenda, "Clique para pesquisar uma Venda.");
            this.btnProcurarVenda.UseVisualStyleBackColor = true;
            this.btnProcurarVenda.Click += new System.EventHandler(this.btnProcurarVenda_Click);
            // 
            // FrmRelDevolucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(847, 507);
            this.ControlBox = false;
            this.Controls.Add(this.pEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelDevolucao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Dovolução de Produtos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRelDevolucao_FormClosing);
            this.Load += new System.EventHandler(this.FrmRelDevolucao_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRelDevolucao_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDevolucao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.grbBox2.ResumeLayout(false);
            this.pEnabled.ResumeLayout(false);
            this.pEnabled.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblDatas;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.Button btnProcurar1;
        private System.Windows.Forms.Button btnProcurarUsuario;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.Label lblCodPDV;
        private System.Windows.Forms.ComboBox cbbCodPDV;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.MaskedTextBox mtxtHorario1;
        private System.Windows.Forms.MaskedTextBox mtxtHorario;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.ComboBox cbbUsuario;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cbbTipoDevolucao;
        private System.Windows.Forms.Button btnProcurarConsumidor;
        private System.Windows.Forms.Label lblConsumidor;
        private System.Windows.Forms.ComboBox cbbConsumidor;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.Windows.Forms.DataGridView dtDevolucao;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.ToolTip ttpDevolucao;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnRelatorioPDF;
        private System.Windows.Forms.Button btnExportarCsv;
        private System.Windows.Forms.Button rbtnExportarTxt;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnGerarCupom;
        private System.Windows.Forms.Button btnConsultarItens;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Button btnConsultarItensInc;
        private System.Windows.Forms.Button btnConsultarValoresDev;
        private System.Windows.Forms.Label lblValorTotalDev;
        private System.Windows.Forms.Label lblTotalDev;
        private System.Windows.Forms.Label lblNovosItens;
        private System.Windows.Forms.Label lblValorTotNovItem;
        private System.Windows.Forms.Button btnVendaOrcamento;
        private System.Windows.Forms.RadioButton rbtnCodVenda;
        private System.Windows.Forms.Panel pEnabled;
        private System.Windows.Forms.Button btnProcurarVenda;
    }
}