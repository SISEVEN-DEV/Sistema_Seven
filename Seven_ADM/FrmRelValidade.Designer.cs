namespace Seven_Sistema
{
    partial class FrmRelValidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelValidade));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblProdutoServico = new System.Windows.Forms.Label();
            this.btnProcurarProduto = new System.Windows.Forms.Button();
            this.cbbProduto = new System.Windows.Forms.ComboBox();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.lblAte1 = new System.Windows.Forms.Label();
            this.lblDatas = new System.Windows.Forms.Label();
            this.mtxtpData3 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpData2 = new System.Windows.Forms.MaskedTextBox();
            this.rbtnNLote = new System.Windows.Forms.RadioButton();
            this.lblAte = new System.Windows.Forms.Label();
            this.rbtnDataValidade = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.txtpLote = new System.Windows.Forms.TextBox();
            this.btnSelecionarData1 = new System.Windows.Forms.Button();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.picbInterrogacao3 = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.btnExportarCsv = new System.Windows.Forms.Button();
            this.rbtnExportarTxt = new System.Windows.Forms.Button();
            this.btnImprimirRel = new System.Windows.Forms.Button();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.dtValidade = new System.Windows.Forms.DataGridView();
            this.ttpValidade = new System.Windows.Forms.ToolTip(this.components);
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.pEnabled = new System.Windows.Forms.Panel();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao3)).BeginInit();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtValidade)).BeginInit();
            this.pEnabled.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblProdutoServico);
            this.grbBox1.Controls.Add(this.btnProcurarProduto);
            this.grbBox1.Controls.Add(this.cbbProduto);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.lblAte1);
            this.grbBox1.Controls.Add(this.lblDatas);
            this.grbBox1.Controls.Add(this.mtxtpData3);
            this.grbBox1.Controls.Add(this.mtxtpData2);
            this.grbBox1.Controls.Add(this.rbtnNLote);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.rbtnDataValidade);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.txtpLote);
            this.grbBox1.Controls.Add(this.btnSelecionarData1);
            this.grbBox1.Location = new System.Drawing.Point(22, 46);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(576, 106);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            this.grbBox1.Enter += new System.EventHandler(this.grbBox1_Enter);
            // 
            // lblProdutoServico
            // 
            this.lblProdutoServico.AutoSize = true;
            this.lblProdutoServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdutoServico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblProdutoServico.Location = new System.Drawing.Point(295, 62);
            this.lblProdutoServico.Name = "lblProdutoServico";
            this.lblProdutoServico.Size = new System.Drawing.Size(55, 13);
            this.lblProdutoServico.TabIndex = 0;
            this.lblProdutoServico.Text = "Produto:";
            // 
            // btnProcurarProduto
            // 
            this.btnProcurarProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarProduto.Image")));
            this.btnProcurarProduto.Location = new System.Drawing.Point(544, 75);
            this.btnProcurarProduto.Name = "btnProcurarProduto";
            this.btnProcurarProduto.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarProduto.TabIndex = 15;
            this.btnProcurarProduto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnProcurarProduto, "Clique para pesquisar um Produto.");
            this.btnProcurarProduto.UseVisualStyleBackColor = true;
            this.btnProcurarProduto.Click += new System.EventHandler(this.btnProcurarProduto_Click);
            this.btnProcurarProduto.MouseLeave += new System.EventHandler(this.btnProcurarProduto_MouseLeave);
            this.btnProcurarProduto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarProduto_MouseMove);
            // 
            // cbbProduto
            // 
            this.cbbProduto.BackColor = System.Drawing.Color.LightBlue;
            this.cbbProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProduto.DropDownWidth = 550;
            this.cbbProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbProduto.FormattingEnabled = true;
            this.cbbProduto.Location = new System.Drawing.Point(298, 78);
            this.cbbProduto.Name = "cbbProduto";
            this.cbbProduto.Size = new System.Drawing.Size(240, 21);
            this.cbbProduto.TabIndex = 14;
            this.cbbProduto.DropDown += new System.EventHandler(this.cbbProduto_DropDown);
            this.cbbProduto.DropDownClosed += new System.EventHandler(this.cbbProduto_DropDownClosed);
            this.cbbProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbProduto_KeyPress);
            this.cbbProduto.MouseLeave += new System.EventHandler(this.cbbProduto_MouseLeave);
            this.cbbProduto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbProduto_MouseMove);
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(206, 75);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 13;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // lblAte1
            // 
            this.lblAte1.AutoSize = true;
            this.lblAte1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte1.Location = new System.Drawing.Point(90, 81);
            this.lblAte1.Name = "lblAte1";
            this.lblAte1.Size = new System.Drawing.Size(26, 13);
            this.lblAte1.TabIndex = 32;
            this.lblAte1.Text = "Até:";
            // 
            // lblDatas
            // 
            this.lblDatas.AutoSize = true;
            this.lblDatas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDatas.Location = new System.Drawing.Point(6, 62);
            this.lblDatas.Name = "lblDatas";
            this.lblDatas.Size = new System.Drawing.Size(110, 13);
            this.lblDatas.TabIndex = 0;
            this.lblDatas.Text = "Data de Cadastro:";
            // 
            // mtxtpData3
            // 
            this.mtxtpData3.BackColor = System.Drawing.Color.White;
            this.mtxtpData3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData3.Location = new System.Drawing.Point(122, 78);
            this.mtxtpData3.Mask = "00/00/0000";
            this.mtxtpData3.Name = "mtxtpData3";
            this.mtxtpData3.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData3.TabIndex = 12;
            this.mtxtpData3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData3.DoubleClick += new System.EventHandler(this.mtxtpData3_DoubleClick);
            this.mtxtpData3.Enter += new System.EventHandler(this.mtxtpData3_Enter);
            this.mtxtpData3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData3_KeyPress);
            this.mtxtpData3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData3_KeyUp);
            this.mtxtpData3.Leave += new System.EventHandler(this.mtxtpData3_Leave);
            // 
            // mtxtpData2
            // 
            this.mtxtpData2.BackColor = System.Drawing.Color.White;
            this.mtxtpData2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData2.Location = new System.Drawing.Point(6, 78);
            this.mtxtpData2.Mask = "00/00/0000";
            this.mtxtpData2.Name = "mtxtpData2";
            this.mtxtpData2.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData2.TabIndex = 11;
            this.mtxtpData2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData2.DoubleClick += new System.EventHandler(this.mtxtpData2_DoubleClick);
            this.mtxtpData2.Enter += new System.EventHandler(this.mtxtpData2_Enter);
            this.mtxtpData2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData2_KeyPress);
            this.mtxtpData2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData2_KeyUp);
            this.mtxtpData2.Leave += new System.EventHandler(this.mtxtpData2_Leave);
            // 
            // rbtnNLote
            // 
            this.rbtnNLote.AutoSize = true;
            this.rbtnNLote.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnNLote.Location = new System.Drawing.Point(6, 42);
            this.rbtnNLote.Name = "rbtnNLote";
            this.rbtnNLote.Size = new System.Drawing.Size(76, 17);
            this.rbtnNLote.TabIndex = 4;
            this.rbtnNLote.TabStop = true;
            this.rbtnNLote.Text = "Nº do Lote";
            this.rbtnNLote.UseVisualStyleBackColor = true;
            this.rbtnNLote.CheckedChanged += new System.EventHandler(this.rbtnNLote_CheckedChanged);
            this.rbtnNLote.MouseLeave += new System.EventHandler(this.rbtnNLote_MouseLeave);
            this.rbtnNLote.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnNLote_MouseMove);
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(428, 21);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // rbtnDataValidade
            // 
            this.rbtnDataValidade.AutoSize = true;
            this.rbtnDataValidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnDataValidade.Location = new System.Drawing.Point(6, 19);
            this.rbtnDataValidade.Name = "rbtnDataValidade";
            this.rbtnDataValidade.Size = new System.Drawing.Size(107, 17);
            this.rbtnDataValidade.TabIndex = 2;
            this.rbtnDataValidade.TabStop = true;
            this.rbtnDataValidade.Text = "Data de Validade";
            this.rbtnDataValidade.UseVisualStyleBackColor = true;
            this.rbtnDataValidade.CheckedChanged += new System.EventHandler(this.rbtnDataValidade_CheckedChanged);
            this.rbtnDataValidade.MouseLeave += new System.EventHandler(this.rbtnDataValidade_MouseLeave);
            this.rbtnDataValidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnDataValidade_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(117, 42);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 5;
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
            this.rbtnCodigo.Location = new System.Drawing.Point(117, 19);
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
            // mtxtpData
            // 
            this.mtxtpData.BackColor = System.Drawing.Color.White;
            this.mtxtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData.Location = new System.Drawing.Point(344, 18);
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
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(242, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(96, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite as datas:";
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(460, 18);
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
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpCodigo.Location = new System.Drawing.Point(491, 18);
            this.txtpCodigo.MaxLength = 10;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(78, 20);
            this.txtpCodigo.TabIndex = 10;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // txtpLote
            // 
            this.txtpLote.BackColor = System.Drawing.Color.White;
            this.txtpLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpLote.Location = new System.Drawing.Point(299, 18);
            this.txtpLote.MaxLength = 60;
            this.txtpLote.Name = "txtpLote";
            this.txtpLote.Size = new System.Drawing.Size(271, 20);
            this.txtpLote.TabIndex = 6;
            this.txtpLote.Visible = false;
            this.txtpLote.Enter += new System.EventHandler(this.txtpLote_Enter);
            this.txtpLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpLote_KeyPress);
            this.txtpLote.Leave += new System.EventHandler(this.txtpLote_Leave);
            // 
            // btnSelecionarData1
            // 
            this.btnSelecionarData1.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData1.Image")));
            this.btnSelecionarData1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData1.Location = new System.Drawing.Point(544, 15);
            this.btnSelecionarData1.Name = "btnSelecionarData1";
            this.btnSelecionarData1.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData1.TabIndex = 9;
            this.btnSelecionarData1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnSelecionarData1, "Clique para selecionar as datas.");
            this.btnSelecionarData1.UseVisualStyleBackColor = true;
            this.btnSelecionarData1.Click += new System.EventHandler(this.btnSelecionarData1_Click);
            this.btnSelecionarData1.MouseLeave += new System.EventHandler(this.btnSelecionarData1_MouseLeave);
            this.btnSelecionarData1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData1_MouseMove);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(490, 158);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 31;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPesquisar.Location = new System.Drawing.Point(517, 158);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 16;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // picbInterrogacao3
            // 
            this.picbInterrogacao3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao3.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao3.Image")));
            this.picbInterrogacao3.Location = new System.Drawing.Point(22, 455);
            this.picbInterrogacao3.Name = "picbInterrogacao3";
            this.picbInterrogacao3.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao3.TabIndex = 234;
            this.picbInterrogacao3.TabStop = false;
            this.picbInterrogacao3.Click += new System.EventHandler(this.picbInterrogacao3_Click);
            this.picbInterrogacao3.MouseLeave += new System.EventHandler(this.picbInterrogacao3_MouseLeave);
            this.picbInterrogacao3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao3_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(543, 455);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 21;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnSair, "Sair do Relatório de Validade de Produtos.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.btnExportarCsv);
            this.grbBox2.Controls.Add(this.rbtnExportarTxt);
            this.grbBox2.Controls.Add(this.btnImprimirRel);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(22, 400);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(576, 49);
            this.grbBox2.TabIndex = 18;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Ações";
            // 
            // btnExportarCsv
            // 
            this.btnExportarCsv.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarCsv.Image")));
            this.btnExportarCsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarCsv.Location = new System.Drawing.Point(435, 19);
            this.btnExportarCsv.Name = "btnExportarCsv";
            this.btnExportarCsv.Size = new System.Drawing.Size(135, 25);
            this.btnExportarCsv.TabIndex = 21;
            this.btnExportarCsv.Text = "Exp. &dados para (.csv)";
            this.btnExportarCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnExportarCsv, "Gerar arquivo da grade de dados em (.csv)(Excel).");
            this.btnExportarCsv.UseVisualStyleBackColor = true;
            this.btnExportarCsv.Click += new System.EventHandler(this.btnExportarCsv_Click);
            this.btnExportarCsv.MouseLeave += new System.EventHandler(this.btnExportarCsv_MouseLeave);
            this.btnExportarCsv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExportarCsv_MouseMove);
            // 
            // rbtnExportarTxt
            // 
            this.rbtnExportarTxt.Image = ((System.Drawing.Image)(resources.GetObject("rbtnExportarTxt.Image")));
            this.rbtnExportarTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtnExportarTxt.Location = new System.Drawing.Point(217, 19);
            this.rbtnExportarTxt.Name = "rbtnExportarTxt";
            this.rbtnExportarTxt.Size = new System.Drawing.Size(133, 25);
            this.rbtnExportarTxt.TabIndex = 20;
            this.rbtnExportarTxt.Text = "Exp. d&ados para (.txt)";
            this.rbtnExportarTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.rbtnExportarTxt, "Gerar arquivo da grade de dados em (.txt)(Bloco de Notas).");
            this.rbtnExportarTxt.UseVisualStyleBackColor = true;
            this.rbtnExportarTxt.Click += new System.EventHandler(this.rbtnExportarTxt_Click);
            this.rbtnExportarTxt.MouseLeave += new System.EventHandler(this.rbtnExportarTxt_MouseLeave);
            this.rbtnExportarTxt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnExportarTxt_MouseMove);
            // 
            // btnImprimirRel
            // 
            this.btnImprimirRel.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirRel.Image")));
            this.btnImprimirRel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirRel.Location = new System.Drawing.Point(6, 19);
            this.btnImprimirRel.Name = "btnImprimirRel";
            this.btnImprimirRel.Size = new System.Drawing.Size(120, 25);
            this.btnImprimirRel.TabIndex = 19;
            this.btnImprimirRel.Text = "Relatório em PD&F";
            this.btnImprimirRel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpValidade.SetToolTip(this.btnImprimirRel, "Relatório das Informações em PDF");
            this.btnImprimirRel.UseVisualStyleBackColor = true;
            this.btnImprimirRel.Click += new System.EventHandler(this.btnImprimirRel_Click);
            this.btnImprimirRel.MouseLeave += new System.EventHandler(this.btnImprimirRel_MouseLeave);
            this.btnImprimirRel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnImprimirRel_MouseMove);
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(165, 254);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(300, 33);
            this.lblProgresso.TabIndex = 227;
            this.lblProgresso.Text = "Por favor, aguarde...";
            this.lblProgresso.Visible = false;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.pgbProgresso.Location = new System.Drawing.Point(156, 286);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(321, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 228;
            this.pgbProgresso.Visible = false;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(19, 371);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtValidade
            // 
            this.dtValidade.AllowUserToAddRows = false;
            this.dtValidade.AllowUserToDeleteRows = false;
            this.dtValidade.AllowUserToResizeRows = false;
            this.dtValidade.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtValidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtValidade.Enabled = false;
            this.dtValidade.Location = new System.Drawing.Point(22, 196);
            this.dtValidade.MultiSelect = false;
            this.dtValidade.Name = "dtValidade";
            this.dtValidade.ReadOnly = true;
            this.dtValidade.RowHeadersVisible = false;
            this.dtValidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtValidade.ShowCellErrors = false;
            this.dtValidade.ShowCellToolTips = false;
            this.dtValidade.ShowEditingIcon = false;
            this.dtValidade.ShowRowErrors = false;
            this.dtValidade.Size = new System.Drawing.Size(576, 172);
            this.dtValidade.TabIndex = 17;
            this.dtValidade.DataSourceChanged += new System.EventHandler(this.dtValidade_DataSourceChanged);
            this.dtValidade.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtValidade_CellEnter);
            this.dtValidade.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtValidade_CellFormatting);
            this.dtValidade.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtValidade_RowsAdded);
            this.dtValidade.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtValidade_RowsRemoved);
            this.dtValidade.MouseLeave += new System.EventHandler(this.dtValidade_MouseLeave);
            this.dtValidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtValidade_MouseMove);
            // 
            // ttpValidade
            // 
            this.ttpValidade.AutoPopDelay = 5000;
            this.ttpValidade.InitialDelay = 1000;
            this.ttpValidade.IsBalloon = true;
            this.ttpValidade.ReshowDelay = 100;
            this.ttpValidade.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpValidade.ToolTipTitle = "Dica:";
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // pEnabled
            // 
            this.pEnabled.Controls.Add(this.btnSair);
            this.pEnabled.Controls.Add(this.picbInterrogacao3);
            this.pEnabled.Controls.Add(this.grbBox1);
            this.pEnabled.Controls.Add(this.btnPesquisar);
            this.pEnabled.Controls.Add(this.grbBox2);
            this.pEnabled.Controls.Add(this.picbInterrogacao2);
            this.pEnabled.Controls.Add(this.lblRegistros);
            this.pEnabled.Controls.Add(this.lblProgresso);
            this.pEnabled.Controls.Add(this.pgbProgresso);
            this.pEnabled.Controls.Add(this.dtValidade);
            this.pEnabled.Location = new System.Drawing.Point(-10, -34);
            this.pEnabled.Name = "pEnabled";
            this.pEnabled.Size = new System.Drawing.Size(620, 587);
            this.pEnabled.TabIndex = 235;
            // 
            // FrmRelValidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(601, 458);
            this.ControlBox = false;
            this.Controls.Add(this.pEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelValidade";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Validade de Produtos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRelValidade_FormClosing);
            this.Load += new System.EventHandler(this.FrmRelValidade_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRelValidade_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao3)).EndInit();
            this.grbBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtValidade)).EndInit();
            this.pEnabled.ResumeLayout(false);
            this.pEnabled.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnNLote;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.RadioButton rbtnDataValidade;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.Button btnSelecionarData1;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.TextBox txtpLote;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.Label lblAte1;
        private System.Windows.Forms.Label lblDatas;
        private System.Windows.Forms.MaskedTextBox mtxtpData3;
        private System.Windows.Forms.MaskedTextBox mtxtpData2;
        private System.Windows.Forms.Label lblProdutoServico;
        private System.Windows.Forms.Button btnProcurarProduto;
        private System.Windows.Forms.ComboBox cbbProduto;
        private System.Windows.Forms.PictureBox picbInterrogacao3;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnImprimirRel;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.DataGridView dtValidade;
        private System.Windows.Forms.ToolTip ttpValidade;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.Panel pEnabled;
        private System.Windows.Forms.Button btnExportarCsv;
        private System.Windows.Forms.Button rbtnExportarTxt;
    }
}