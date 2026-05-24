namespace Seven_Sistema
{
    partial class FrmRelEntradasProdutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelEntradasProdutos));
            this.lblAte = new System.Windows.Forms.Label();
            this.lblDataVenda = new System.Windows.Forms.Label();
            this.lblDatas = new System.Windows.Forms.Label();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.btnPesqDFe = new System.Windows.Forms.Button();
            this.lblCodDevolucao = new System.Windows.Forms.Label();
            this.txtCodDFe = new System.Windows.Forms.TextBox();
            this.mtxtHorario1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtHorario = new System.Windows.Forms.MaskedTextBox();
            this.cbbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.btnProcurarFornecedor = new System.Windows.Forms.Button();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.cbbFornecedor = new System.Windows.Forms.ComboBox();
            this.btnProcurarProduto = new System.Windows.Forms.Button();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.lblProduto = new System.Windows.Forms.Label();
            this.cbbProduto = new System.Windows.Forms.ComboBox();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.dtFornProd = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.btnExportarCsv = new System.Windows.Forms.Button();
            this.rbtnExportarTxt = new System.Windows.Forms.Button();
            this.btnResumido = new System.Windows.Forms.Button();
            this.lblValorQuantidade = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.ttpEntrada = new System.Windows.Forms.ToolTip(this.components);
            this.btnSair = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.pEnabled = new System.Windows.Forms.Panel();
            this.btnClienteCons = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbbClienteCons = new System.Windows.Forms.ComboBox();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFornProd)).BeginInit();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.pEnabled.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(235, 35);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 5;
            this.lblAte.Text = "Até:";
            // 
            // lblDataVenda
            // 
            this.lblDataVenda.AutoSize = true;
            this.lblDataVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataVenda.Location = new System.Drawing.Point(2, 16);
            this.lblDataVenda.Name = "lblDataVenda";
            this.lblDataVenda.Size = new System.Drawing.Size(160, 13);
            this.lblDataVenda.TabIndex = 0;
            this.lblDataVenda.Text = "Data e Horário da Entrada:";
            // 
            // lblDatas
            // 
            this.lblDatas.AutoSize = true;
            this.lblDatas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDatas.Location = new System.Drawing.Point(2, 35);
            this.lblDatas.Name = "lblDatas";
            this.lblDatas.Size = new System.Drawing.Size(80, 13);
            this.lblDatas.TabIndex = 0;
            this.lblDatas.Text = "Digite as datas:";
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(267, 32);
            this.mtxtpData1.Mask = "00/00/0000";
            this.mtxtpData1.Name = "mtxtpData1";
            this.mtxtpData1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData1.TabIndex = 4;
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
            this.mtxtpData.Location = new System.Drawing.Point(88, 32);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 2;
            this.mtxtpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData.DoubleClick += new System.EventHandler(this.mtxtpData_DoubleClick);
            this.mtxtpData.Enter += new System.EventHandler(this.mtxtpData_Enter);
            this.mtxtpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData_KeyPress);
            this.mtxtpData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData_KeyUp);
            this.mtxtpData.Leave += new System.EventHandler(this.mtxtpData_Leave);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnPesqDFe);
            this.grbBox1.Controls.Add(this.lblCodDevolucao);
            this.grbBox1.Controls.Add(this.txtCodDFe);
            this.grbBox1.Controls.Add(this.btnClienteCons);
            this.grbBox1.Controls.Add(this.lblCliente);
            this.grbBox1.Controls.Add(this.cbbClienteCons);
            this.grbBox1.Controls.Add(this.mtxtHorario1);
            this.grbBox1.Controls.Add(this.mtxtHorario);
            this.grbBox1.Controls.Add(this.cbbTipo);
            this.grbBox1.Controls.Add(this.lblTipo);
            this.grbBox1.Controls.Add(this.btnProcurarFornecedor);
            this.grbBox1.Controls.Add(this.lblFornecedor);
            this.grbBox1.Controls.Add(this.cbbFornecedor);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.btnProcurarProduto);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.lblProduto);
            this.grbBox1.Controls.Add(this.lblDatas);
            this.grbBox1.Controls.Add(this.cbbProduto);
            this.grbBox1.Controls.Add(this.lblDataVenda);
            this.grbBox1.Location = new System.Drawing.Point(21, 52);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(916, 100);
            this.grbBox1.TabIndex = 8;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // btnPesqDFe
            // 
            this.btnPesqDFe.Image = ((System.Drawing.Image)(resources.GetObject("btnPesqDFe.Image")));
            this.btnPesqDFe.Location = new System.Drawing.Point(660, 29);
            this.btnPesqDFe.Name = "btnPesqDFe";
            this.btnPesqDFe.Size = new System.Drawing.Size(26, 25);
            this.btnPesqDFe.TabIndex = 26;
            this.btnPesqDFe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEntrada.SetToolTip(this.btnPesqDFe, "Clique para pesquisar um Documento Fiscal Eletrônico.");
            this.btnPesqDFe.UseVisualStyleBackColor = true;
            this.btnPesqDFe.Click += new System.EventHandler(this.btnPesqDFe_Click);
            this.btnPesqDFe.MouseLeave += new System.EventHandler(this.btnPesqDFe_MouseLeave);
            this.btnPesqDFe.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesqDFe_MouseMove);
            // 
            // lblCodDevolucao
            // 
            this.lblCodDevolucao.AutoSize = true;
            this.lblCodDevolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodDevolucao.Location = new System.Drawing.Point(538, 17);
            this.lblCodDevolucao.Name = "lblCodDevolucao";
            this.lblCodDevolucao.Size = new System.Drawing.Size(82, 13);
            this.lblCodDevolucao.TabIndex = 25;
            this.lblCodDevolucao.Text = "Cód. do DFe:";
            // 
            // txtCodDFe
            // 
            this.txtCodDFe.BackColor = System.Drawing.Color.White;
            this.txtCodDFe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodDFe.Location = new System.Drawing.Point(541, 32);
            this.txtCodDFe.MaxLength = 10;
            this.txtCodDFe.Name = "txtCodDFe";
            this.txtCodDFe.Size = new System.Drawing.Size(113, 20);
            this.txtCodDFe.TabIndex = 7;
            this.txtCodDFe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodDFe.Enter += new System.EventHandler(this.txtCodDFe_Enter);
            this.txtCodDFe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodDFe_KeyPress);
            this.txtCodDFe.Leave += new System.EventHandler(this.txtCodDFe_Leave);
            // 
            // mtxtHorario1
            // 
            this.mtxtHorario1.BackColor = System.Drawing.Color.White;
            this.mtxtHorario1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorario1.Location = new System.Drawing.Point(351, 32);
            this.mtxtHorario1.Mask = "00:00:00";
            this.mtxtHorario1.Name = "mtxtHorario1";
            this.mtxtHorario1.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario1.TabIndex = 5;
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
            this.mtxtHorario.Location = new System.Drawing.Point(172, 32);
            this.mtxtHorario.Mask = "00:00:00";
            this.mtxtHorario.Name = "mtxtHorario";
            this.mtxtHorario.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario.TabIndex = 3;
            this.mtxtHorario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorario.DoubleClick += new System.EventHandler(this.mtxtHorario_DoubleClick);
            this.mtxtHorario.Enter += new System.EventHandler(this.mtxtHorario_Enter);
            this.mtxtHorario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorario_KeyPress);
            this.mtxtHorario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorario_KeyUp);
            this.mtxtHorario.Leave += new System.EventHandler(this.mtxtHorario_Leave);
            // 
            // cbbTipo
            // 
            this.cbbTipo.BackColor = System.Drawing.Color.LightBlue;
            this.cbbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipo.DropDownWidth = 95;
            this.cbbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTipo.FormattingEnabled = true;
            this.cbbTipo.Items.AddRange(new object[] {
            "",
            "DFe",
            "MANUAL"});
            this.cbbTipo.Location = new System.Drawing.Point(815, 32);
            this.cbbTipo.Name = "cbbTipo";
            this.cbbTipo.Size = new System.Drawing.Size(95, 21);
            this.cbbTipo.TabIndex = 9;
            this.cbbTipo.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbbTipo_DrawItem);
            this.cbbTipo.DropDown += new System.EventHandler(this.cbbTipo_DropDown);
            this.cbbTipo.DropDownClosed += new System.EventHandler(this.cbbTipo_DropDownClosed);
            this.cbbTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbTipo_KeyPress);
            this.cbbTipo.MouseLeave += new System.EventHandler(this.cbbTipo_MouseLeave);
            this.cbbTipo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbTipo_MouseMove);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(812, 16);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(36, 13);
            this.lblTipo.TabIndex = 9;
            this.lblTipo.Text = "Tipo:";
            // 
            // btnProcurarFornecedor
            // 
            this.btnProcurarFornecedor.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarFornecedor.Image")));
            this.btnProcurarFornecedor.Location = new System.Drawing.Point(581, 69);
            this.btnProcurarFornecedor.Name = "btnProcurarFornecedor";
            this.btnProcurarFornecedor.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarFornecedor.TabIndex = 13;
            this.btnProcurarFornecedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEntrada.SetToolTip(this.btnProcurarFornecedor, "Clique para pesquisar um Fornecedor.");
            this.btnProcurarFornecedor.UseVisualStyleBackColor = true;
            this.btnProcurarFornecedor.Click += new System.EventHandler(this.btnProcurarFornecedor_Click);
            this.btnProcurarFornecedor.MouseLeave += new System.EventHandler(this.btnProcurarFornecedor_MouseLeave);
            this.btnProcurarFornecedor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarFornecedor_MouseMove);
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFornecedor.Location = new System.Drawing.Point(296, 55);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(75, 13);
            this.lblFornecedor.TabIndex = 0;
            this.lblFornecedor.Text = "Fornecedor:";
            // 
            // cbbFornecedor
            // 
            this.cbbFornecedor.BackColor = System.Drawing.Color.LightBlue;
            this.cbbFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFornecedor.DropDownWidth = 550;
            this.cbbFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbFornecedor.FormattingEnabled = true;
            this.cbbFornecedor.Location = new System.Drawing.Point(299, 71);
            this.cbbFornecedor.Name = "cbbFornecedor";
            this.cbbFornecedor.Size = new System.Drawing.Size(276, 21);
            this.cbbFornecedor.TabIndex = 12;
            this.cbbFornecedor.DropDown += new System.EventHandler(this.cbbFornecedor_DropDown);
            this.cbbFornecedor.DropDownClosed += new System.EventHandler(this.cbbFornecedor_DropDownClosed);
            this.cbbFornecedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbFornecedor_KeyPress);
            this.cbbFornecedor.MouseLeave += new System.EventHandler(this.cbbFornecedor_MouseLeave);
            this.cbbFornecedor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbFornecedor_MouseMove);
            // 
            // btnProcurarProduto
            // 
            this.btnProcurarProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarProduto.Image")));
            this.btnProcurarProduto.Location = new System.Drawing.Point(267, 69);
            this.btnProcurarProduto.Name = "btnProcurarProduto";
            this.btnProcurarProduto.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarProduto.TabIndex = 11;
            this.btnProcurarProduto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEntrada.SetToolTip(this.btnProcurarProduto, "Clique para pesquisar um Produto.");
            this.btnProcurarProduto.UseVisualStyleBackColor = true;
            this.btnProcurarProduto.Click += new System.EventHandler(this.btnProcurarProduto_Click);
            this.btnProcurarProduto.MouseLeave += new System.EventHandler(this.btnProcurarProduto_MouseLeave);
            this.btnProcurarProduto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarProduto_MouseMove);
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(414, 29);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 6;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEntrada.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(3, 55);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(55, 13);
            this.lblProduto.TabIndex = 0;
            this.lblProduto.Text = "Produto:";
            // 
            // cbbProduto
            // 
            this.cbbProduto.BackColor = System.Drawing.Color.LightBlue;
            this.cbbProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProduto.DropDownWidth = 550;
            this.cbbProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbProduto.FormattingEnabled = true;
            this.cbbProduto.Location = new System.Drawing.Point(6, 71);
            this.cbbProduto.Name = "cbbProduto";
            this.cbbProduto.Size = new System.Drawing.Size(255, 21);
            this.cbbProduto.TabIndex = 10;
            this.cbbProduto.DropDown += new System.EventHandler(this.cbbProduto_DropDown);
            this.cbbProduto.DropDownClosed += new System.EventHandler(this.cbbProduto_DropDownClosed);
            this.cbbProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbProduto_KeyPress);
            this.cbbProduto.MouseLeave += new System.EventHandler(this.cbbProduto_MouseLeave);
            this.cbbProduto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbProduto_MouseMove);
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(334, 252);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(300, 33);
            this.lblProgresso.TabIndex = 0;
            this.lblProgresso.Text = "Por favor, aguarde...";
            this.lblProgresso.Visible = false;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.pgbProgresso.Location = new System.Drawing.Point(324, 285);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(321, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 0;
            this.pgbProgresso.Visible = false;
            // 
            // dtFornProd
            // 
            this.dtFornProd.AllowUserToAddRows = false;
            this.dtFornProd.AllowUserToDeleteRows = false;
            this.dtFornProd.AllowUserToResizeRows = false;
            this.dtFornProd.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtFornProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtFornProd.Location = new System.Drawing.Point(21, 196);
            this.dtFornProd.MultiSelect = false;
            this.dtFornProd.Name = "dtFornProd";
            this.dtFornProd.ReadOnly = true;
            this.dtFornProd.RowHeadersVisible = false;
            this.dtFornProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtFornProd.ShowCellErrors = false;
            this.dtFornProd.ShowCellToolTips = false;
            this.dtFornProd.ShowEditingIcon = false;
            this.dtFornProd.ShowRowErrors = false;
            this.dtFornProd.Size = new System.Drawing.Size(916, 172);
            this.dtFornProd.TabIndex = 17;
            this.dtFornProd.TabStop = false;
            this.dtFornProd.DataSourceChanged += new System.EventHandler(this.dtFornProd_DataSourceChanged);
            this.dtFornProd.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtFornProd_CellEnter);
            this.dtFornProd.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtFornProd_CellFormatting);
            this.dtFornProd.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtFornProd_RowsAdded);
            this.dtFornProd.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtFornProd_RowsRemoved);
            this.dtFornProd.MouseLeave += new System.EventHandler(this.dtFornProd_MouseLeave);
            this.dtFornProd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtFornProd_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(18, 371);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.btnExportarCsv);
            this.grbBox2.Controls.Add(this.rbtnExportarTxt);
            this.grbBox2.Controls.Add(this.btnResumido);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(21, 400);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(916, 51);
            this.grbBox2.TabIndex = 18;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Ações:";
            // 
            // btnExportarCsv
            // 
            this.btnExportarCsv.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarCsv.Image")));
            this.btnExportarCsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarCsv.Location = new System.Drawing.Point(387, 19);
            this.btnExportarCsv.Name = "btnExportarCsv";
            this.btnExportarCsv.Size = new System.Drawing.Size(135, 25);
            this.btnExportarCsv.TabIndex = 20;
            this.btnExportarCsv.Text = "Exp. dados para (.cs&v)";
            this.btnExportarCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEntrada.SetToolTip(this.btnExportarCsv, "Gerar arquivo da grade de dados em (.csv)(Excel).");
            this.btnExportarCsv.UseVisualStyleBackColor = true;
            this.btnExportarCsv.Click += new System.EventHandler(this.btnExportarCsv_Click);
            this.btnExportarCsv.MouseLeave += new System.EventHandler(this.btnExportarCsv_MouseLeave);
            this.btnExportarCsv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExportarCsv_MouseMove);
            // 
            // rbtnExportarTxt
            // 
            this.rbtnExportarTxt.Image = ((System.Drawing.Image)(resources.GetObject("rbtnExportarTxt.Image")));
            this.rbtnExportarTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtnExportarTxt.Location = new System.Drawing.Point(777, 19);
            this.rbtnExportarTxt.Name = "rbtnExportarTxt";
            this.rbtnExportarTxt.Size = new System.Drawing.Size(133, 25);
            this.rbtnExportarTxt.TabIndex = 21;
            this.rbtnExportarTxt.Text = "&Exp. dados para (.txt)";
            this.rbtnExportarTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEntrada.SetToolTip(this.rbtnExportarTxt, "Gerar arquivo da grade de dados em (.txt)(Bloco de Notas).");
            this.rbtnExportarTxt.UseVisualStyleBackColor = true;
            this.rbtnExportarTxt.Click += new System.EventHandler(this.rbtnExportarTxt_Click);
            this.rbtnExportarTxt.MouseLeave += new System.EventHandler(this.rbtnExportarTxt_MouseLeave);
            this.rbtnExportarTxt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnExportarTxt_MouseMove);
            // 
            // btnResumido
            // 
            this.btnResumido.Image = ((System.Drawing.Image)(resources.GetObject("btnResumido.Image")));
            this.btnResumido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResumido.Location = new System.Drawing.Point(6, 19);
            this.btnResumido.Name = "btnResumido";
            this.btnResumido.Size = new System.Drawing.Size(116, 25);
            this.btnResumido.TabIndex = 19;
            this.btnResumido.Text = "&Relatório em PDF";
            this.btnResumido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEntrada.SetToolTip(this.btnResumido, "Relatório das Informações em PDF");
            this.btnResumido.UseVisualStyleBackColor = true;
            this.btnResumido.Click += new System.EventHandler(this.btnResumido_Click);
            this.btnResumido.MouseLeave += new System.EventHandler(this.btnResumido_MouseLeave);
            this.btnResumido.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnResumido_MouseMove);
            // 
            // lblValorQuantidade
            // 
            this.lblValorQuantidade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorQuantidade.BackColor = System.Drawing.Color.White;
            this.lblValorQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorQuantidade.Enabled = false;
            this.lblValorQuantidade.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorQuantidade.ForeColor = System.Drawing.Color.Black;
            this.lblValorQuantidade.Location = new System.Drawing.Point(787, 371);
            this.lblValorQuantidade.Name = "lblValorQuantidade";
            this.lblValorQuantidade.Size = new System.Drawing.Size(150, 26);
            this.lblValorQuantidade.TabIndex = 0;
            this.lblValorQuantidade.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorQuantidade.Click += new System.EventHandler(this.lblValorQuantidade_Click);
            this.lblValorQuantidade.MouseLeave += new System.EventHandler(this.lblValorQuantidade_MouseLeave);
            this.lblValorQuantidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorQuantidade_MouseMove);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblQuantidade.BackColor = System.Drawing.Color.Transparent;
            this.lblQuantidade.Enabled = false;
            this.lblQuantidade.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.ForeColor = System.Drawing.Color.Black;
            this.lblQuantidade.Location = new System.Drawing.Point(604, 370);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(202, 26);
            this.lblQuantidade.TabIndex = 0;
            this.lblQuantidade.Text = "Quantidade dos itens:";
            this.lblQuantidade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ttpEntrada
            // 
            this.ttpEntrada.AutoPopDelay = 5000;
            this.ttpEntrada.InitialDelay = 1000;
            this.ttpEntrada.IsBalloon = true;
            this.ttpEntrada.ReshowDelay = 100;
            this.ttpEntrada.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpEntrada.ToolTipTitle = "Dica:";
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(882, 457);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 22;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEntrada.SetToolTip(this.btnSair, "Sair do Relatório de Entrada de Produtos.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(855, 158);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 16;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEntrada.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.Location = new System.Drawing.Point(21, 457);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 252;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(829, 123);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 236;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // pEnabled
            // 
            this.pEnabled.Controls.Add(this.btnSair);
            this.pEnabled.Controls.Add(this.picbInterrogacao);
            this.pEnabled.Controls.Add(this.grbBox1);
            this.pEnabled.Controls.Add(this.lblValorQuantidade);
            this.pEnabled.Controls.Add(this.lblQuantidade);
            this.pEnabled.Controls.Add(this.lblRegistros);
            this.pEnabled.Controls.Add(this.picbInterrogacao1);
            this.pEnabled.Controls.Add(this.btnPesquisar);
            this.pEnabled.Controls.Add(this.lblProgresso);
            this.pEnabled.Controls.Add(this.pgbProgresso);
            this.pEnabled.Controls.Add(this.dtFornProd);
            this.pEnabled.Controls.Add(this.grbBox2);
            this.pEnabled.Location = new System.Drawing.Point(-9, -40);
            this.pEnabled.Name = "pEnabled";
            this.pEnabled.Size = new System.Drawing.Size(961, 553);
            this.pEnabled.TabIndex = 253;
            // 
            // btnClienteCons
            // 
            this.btnClienteCons.Image = ((System.Drawing.Image)(resources.GetObject("btnClienteCons.Image")));
            this.btnClienteCons.Location = new System.Drawing.Point(884, 69);
            this.btnClienteCons.Name = "btnClienteCons";
            this.btnClienteCons.Size = new System.Drawing.Size(26, 25);
            this.btnClienteCons.TabIndex = 15;
            this.btnClienteCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEntrada.SetToolTip(this.btnClienteCons, "Clique para pesquisar um Consumidor.");
            this.btnClienteCons.UseVisualStyleBackColor = true;
            this.btnClienteCons.Click += new System.EventHandler(this.btnClienteCons_Click);
            this.btnClienteCons.MouseLeave += new System.EventHandler(this.btnClienteCons_MouseLeave);
            this.btnClienteCons.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnClienteCons_MouseMove);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(610, 55);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(76, 13);
            this.lblCliente.TabIndex = 12;
            this.lblCliente.Text = "Consumidor:";
            // 
            // cbbClienteCons
            // 
            this.cbbClienteCons.BackColor = System.Drawing.Color.LightBlue;
            this.cbbClienteCons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbClienteCons.DropDownWidth = 550;
            this.cbbClienteCons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbClienteCons.FormattingEnabled = true;
            this.cbbClienteCons.Location = new System.Drawing.Point(613, 71);
            this.cbbClienteCons.Name = "cbbClienteCons";
            this.cbbClienteCons.Size = new System.Drawing.Size(265, 21);
            this.cbbClienteCons.TabIndex = 14;
            this.cbbClienteCons.DropDown += new System.EventHandler(this.cbbClienteCons_DropDown);
            this.cbbClienteCons.DropDownClosed += new System.EventHandler(this.cbbClienteCons_DropDownClosed);
            this.cbbClienteCons.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbClienteCons_KeyPress);
            this.cbbClienteCons.MouseLeave += new System.EventHandler(this.cbbClienteCons_MouseLeave);
            this.cbbClienteCons.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbClienteCons_MouseMove);
            // 
            // FrmRelEntradasProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(938, 453);
            this.ControlBox = false;
            this.Controls.Add(this.pEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelEntradasProdutos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Entrada de Produtos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRelFornecedoresProd_FormClosing);
            this.Load += new System.EventHandler(this.FrmRelFornecedoresProd_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRelFornecedoresProd_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFornProd)).EndInit();
            this.grbBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.pEnabled.ResumeLayout(false);
            this.pEnabled.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.Label lblDataVenda;
        private System.Windows.Forms.Label lblDatas;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnProcurarProduto;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.ComboBox cbbProduto;
        private System.Windows.Forms.Button btnProcurarFornecedor;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.ComboBox cbbFornecedor;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.Windows.Forms.DataGridView dtFornProd;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnExportarCsv;
        private System.Windows.Forms.Button rbtnExportarTxt;
        private System.Windows.Forms.Button btnResumido;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblValorQuantidade;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.ToolTip ttpEntrada;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.ComboBox cbbTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Panel pEnabled;
        private System.Windows.Forms.MaskedTextBox mtxtHorario1;
        private System.Windows.Forms.MaskedTextBox mtxtHorario;
        private System.Windows.Forms.Button btnPesqDFe;
        private System.Windows.Forms.Label lblCodDevolucao;
        private System.Windows.Forms.TextBox txtCodDFe;
        private System.Windows.Forms.Button btnClienteCons;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbbClienteCons;
    }
}