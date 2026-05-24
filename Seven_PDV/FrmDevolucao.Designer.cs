namespace Seven_Sistema
{
    partial class FrmDevolucao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDevolucao));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelecionarData1 = new System.Windows.Forms.Button();
            this.mtxtHorario1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtHorario = new System.Windows.Forms.MaskedTextBox();
            this.lblAte1 = new System.Windows.Forms.Label();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.rbtnData = new System.Windows.Forms.RadioButton();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.rbtnConsumidor = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.btnpProcurar = new System.Windows.Forms.Button();
            this.cbbpConsumidor = new System.Windows.Forms.ComboBox();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.lblLocalizar = new System.Windows.Forms.Label();
            this.dtVenda = new System.Windows.Forms.DataGridView();
            this.dtItensVenda = new System.Windows.Forms.DataGridView();
            this.dtProd = new System.Windows.Forms.DataGridView();
            this.lblItens = new System.Windows.Forms.Label();
            this.lblProdutos = new System.Windows.Forms.Label();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.lblValorTotalProdutos = new System.Windows.Forms.Label();
            this.lblTotalProduto = new System.Windows.Forms.Label();
            this.lblValorTotalVenda = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblVenda = new System.Windows.Forms.Label();
            this.lblCredito = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblValorNovosItens = new System.Windows.Forms.Label();
            this.lblNovosItens = new System.Windows.Forms.Label();
            this.lblValorCredito = new System.Windows.Forms.Label();
            this.lblCodigoVenda = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.ttpDevolucao = new System.Windows.Forms.ToolTip(this.components);
            this.btnZerar = new System.Windows.Forms.Button();
            this.btnAltQuantidade = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.lblRegistrosVenda = new System.Windows.Forms.Label();
            this.lblRegistrosItem = new System.Windows.Forms.Label();
            this.lblRegistrosProd = new System.Windows.Forms.Label();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.picbInterrogacao3 = new System.Windows.Forms.PictureBox();
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.prtDocumento = new System.Drawing.Printing.PrintDocument();
            this.pEnabled = new System.Windows.Forms.Panel();
            this.lblVendaLeg = new System.Windows.Forms.Label();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtItensVenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProd)).BeginInit();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao3)).BeginInit();
            this.pEnabled.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblAte1);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.rbtnData);
            this.grbBox1.Controls.Add(this.picbInterrogacao2);
            this.grbBox1.Controls.Add(this.rbtnConsumidor);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.btnpProcurar);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.mtxtHorario);
            this.grbBox1.Controls.Add(this.mtxtHorario1);
            this.grbBox1.Controls.Add(this.cbbpConsumidor);
            this.grbBox1.Controls.Add(this.btnSelecionarData1);
            this.grbBox1.Location = new System.Drawing.Point(24, 52);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(760, 81);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar Venda por:";
            // 
            // btnSelecionarData1
            // 
            this.btnSelecionarData1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionarData1.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData1.Image")));
            this.btnSelecionarData1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData1.Location = new System.Drawing.Point(728, 15);
            this.btnSelecionarData1.Name = "btnSelecionarData1";
            this.btnSelecionarData1.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData1.TabIndex = 10;
            this.btnSelecionarData1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnSelecionarData1, "Clique para selecionar as datas.");
            this.btnSelecionarData1.UseVisualStyleBackColor = true;
            this.btnSelecionarData1.Visible = false;
            this.btnSelecionarData1.Click += new System.EventHandler(this.btnSelecionarData1_Click);
            // 
            // mtxtHorario1
            // 
            this.mtxtHorario1.BackColor = System.Drawing.Color.White;
            this.mtxtHorario1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorario1.Location = new System.Drawing.Point(665, 18);
            this.mtxtHorario1.Mask = "00:00:00";
            this.mtxtHorario1.Name = "mtxtHorario1";
            this.mtxtHorario1.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario1.TabIndex = 9;
            this.mtxtHorario1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorario1.Visible = false;
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
            this.mtxtHorario.Location = new System.Drawing.Point(495, 18);
            this.mtxtHorario.Mask = "00:00:00";
            this.mtxtHorario.Name = "mtxtHorario";
            this.mtxtHorario.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario.TabIndex = 7;
            this.mtxtHorario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorario.Visible = false;
            this.mtxtHorario.DoubleClick += new System.EventHandler(this.mtxtHorario_DoubleClick);
            this.mtxtHorario.Enter += new System.EventHandler(this.mtxtHorario_Enter);
            this.mtxtHorario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorario_KeyPress);
            this.mtxtHorario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorario_KeyUp);
            this.mtxtHorario.Leave += new System.EventHandler(this.mtxtHorario_Leave);
            // 
            // lblAte1
            // 
            this.lblAte1.AutoSize = true;
            this.lblAte1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte1.Location = new System.Drawing.Point(554, 21);
            this.lblAte1.Name = "lblAte1";
            this.lblAte1.Size = new System.Drawing.Size(26, 13);
            this.lblAte1.TabIndex = 33;
            this.lblAte1.Text = "Até:";
            this.lblAte1.Visible = false;
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(581, 18);
            this.mtxtpData1.Mask = "00/00/0000";
            this.mtxtpData1.Name = "mtxtpData1";
            this.mtxtpData1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData1.TabIndex = 8;
            this.mtxtpData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData1.Visible = false;
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
            this.mtxtpData.Location = new System.Drawing.Point(411, 18);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 6;
            this.mtxtpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData.Visible = false;
            this.mtxtpData.DoubleClick += new System.EventHandler(this.mtxtpData_DoubleClick);
            this.mtxtpData.Enter += new System.EventHandler(this.mtxtpData_Enter);
            this.mtxtpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData_KeyPress);
            this.mtxtpData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData_KeyUp);
            this.mtxtpData.Leave += new System.EventHandler(this.mtxtpData_Leave);
            // 
            // rbtnData
            // 
            this.rbtnData.AutoSize = true;
            this.rbtnData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnData.Location = new System.Drawing.Point(6, 19);
            this.rbtnData.Name = "rbtnData";
            this.rbtnData.Size = new System.Drawing.Size(48, 17);
            this.rbtnData.TabIndex = 2;
            this.rbtnData.Text = "Data";
            this.rbtnData.UseVisualStyleBackColor = true;
            this.rbtnData.CheckedChanged += new System.EventHandler(this.rbtnData_CheckedChanged);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(646, 45);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 31;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // rbtnConsumidor
            // 
            this.rbtnConsumidor.AutoSize = true;
            this.rbtnConsumidor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnConsumidor.Location = new System.Drawing.Point(72, 19);
            this.rbtnConsumidor.Name = "rbtnConsumidor";
            this.rbtnConsumidor.Size = new System.Drawing.Size(80, 17);
            this.rbtnConsumidor.TabIndex = 3;
            this.rbtnConsumidor.Text = "Consumidor";
            this.rbtnConsumidor.UseVisualStyleBackColor = true;
            this.rbtnConsumidor.CheckedChanged += new System.EventHandler(this.rbtnConsumidor_CheckedChanged);
            this.rbtnConsumidor.MouseLeave += new System.EventHandler(this.rbtnConsumidor_MouseLeave);
            this.rbtnConsumidor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnConsumidor_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(72, 42);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 5;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPesquisar.Location = new System.Drawing.Point(672, 44);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 14;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(6, 42);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 4;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(321, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(84, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite a data:";
            // 
            // btnpProcurar
            // 
            this.btnpProcurar.Image = ((System.Drawing.Image)(resources.GetObject("btnpProcurar.Image")));
            this.btnpProcurar.Location = new System.Drawing.Point(728, 15);
            this.btnpProcurar.Name = "btnpProcurar";
            this.btnpProcurar.Size = new System.Drawing.Size(26, 25);
            this.btnpProcurar.TabIndex = 13;
            this.btnpProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnpProcurar, "Clique para pesquisar um Consumidor.");
            this.btnpProcurar.UseVisualStyleBackColor = true;
            this.btnpProcurar.Visible = false;
            this.btnpProcurar.Click += new System.EventHandler(this.btnpProcurar_Click);
            this.btnpProcurar.MouseLeave += new System.EventHandler(this.btnpProcurar_MouseLeave);
            this.btnpProcurar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnpProcurar_MouseMove);
            // 
            // cbbpConsumidor
            // 
            this.cbbpConsumidor.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpConsumidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpConsumidor.DropDownWidth = 525;
            this.cbbpConsumidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpConsumidor.FormattingEnabled = true;
            this.cbbpConsumidor.Location = new System.Drawing.Point(479, 18);
            this.cbbpConsumidor.Name = "cbbpConsumidor";
            this.cbbpConsumidor.Size = new System.Drawing.Size(243, 21);
            this.cbbpConsumidor.TabIndex = 11;
            this.cbbpConsumidor.Visible = false;
            this.cbbpConsumidor.DropDown += new System.EventHandler(this.cbbpConsumidor_DropDown);
            this.cbbpConsumidor.DropDownClosed += new System.EventHandler(this.cbbpConsumidor_DropDownClosed);
            this.cbbpConsumidor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpConsumidor_KeyPress);
            this.cbbpConsumidor.MouseLeave += new System.EventHandler(this.cbbpConsumidor_MouseLeave);
            this.cbbpConsumidor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpConsumidor_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpCodigo.Location = new System.Drawing.Point(674, 18);
            this.txtpCodigo.MaxLength = 10;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtpCodigo.TabIndex = 12;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // lblLocalizar
            // 
            this.lblLocalizar.AutoSize = true;
            this.lblLocalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblLocalizar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLocalizar.Location = new System.Drawing.Point(25, 16);
            this.lblLocalizar.Name = "lblLocalizar";
            this.lblLocalizar.Size = new System.Drawing.Size(102, 13);
            this.lblLocalizar.TabIndex = 0;
            this.lblLocalizar.Text = "Localizar Venda:";
            // 
            // dtVenda
            // 
            this.dtVenda.AllowUserToAddRows = false;
            this.dtVenda.AllowUserToDeleteRows = false;
            this.dtVenda.AllowUserToResizeRows = false;
            this.dtVenda.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtVenda.Enabled = false;
            this.dtVenda.Location = new System.Drawing.Point(24, 160);
            this.dtVenda.MultiSelect = false;
            this.dtVenda.Name = "dtVenda";
            this.dtVenda.ReadOnly = true;
            this.dtVenda.RowHeadersVisible = false;
            this.dtVenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtVenda.ShowCellErrors = false;
            this.dtVenda.ShowCellToolTips = false;
            this.dtVenda.ShowEditingIcon = false;
            this.dtVenda.ShowRowErrors = false;
            this.dtVenda.Size = new System.Drawing.Size(760, 128);
            this.dtVenda.TabIndex = 15;
            this.dtVenda.DataSourceChanged += new System.EventHandler(this.dtVenda_DataSourceChanged);
            this.dtVenda.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtVenda_CellEnter);
            this.dtVenda.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtVenda_CellFormatting);
            this.dtVenda.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtVenda_RowsAdded);
            this.dtVenda.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtVenda_RowsRemoved);
            this.dtVenda.MouseLeave += new System.EventHandler(this.dtVenda_MouseLeave);
            this.dtVenda.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtVenda_MouseMove);
            // 
            // dtItensVenda
            // 
            this.dtItensVenda.AllowUserToAddRows = false;
            this.dtItensVenda.AllowUserToDeleteRows = false;
            this.dtItensVenda.AllowUserToResizeRows = false;
            this.dtItensVenda.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtItensVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtItensVenda.Enabled = false;
            this.dtItensVenda.Location = new System.Drawing.Point(24, 341);
            this.dtItensVenda.Name = "dtItensVenda";
            this.dtItensVenda.ReadOnly = true;
            this.dtItensVenda.RowHeadersVisible = false;
            this.dtItensVenda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtItensVenda.ShowCellErrors = false;
            this.dtItensVenda.ShowCellToolTips = false;
            this.dtItensVenda.ShowEditingIcon = false;
            this.dtItensVenda.ShowRowErrors = false;
            this.dtItensVenda.Size = new System.Drawing.Size(380, 128);
            this.dtItensVenda.TabIndex = 16;
            this.dtItensVenda.DataSourceChanged += new System.EventHandler(this.dtItensVenda_DataSourceChanged);
            this.dtItensVenda.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtItensVenda_CellEnter);
            this.dtItensVenda.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtItensVenda_CellMouseDoubleClick);
            this.dtItensVenda.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtItensVenda_CellMouseMove);
            this.dtItensVenda.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtItensVenda_RowsAdded);
            this.dtItensVenda.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtItensVenda_RowsRemoved);
            this.dtItensVenda.MouseLeave += new System.EventHandler(this.dtItensVenda_MouseLeave);
            this.dtItensVenda.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtItensVenda_MouseMove);
            // 
            // dtProd
            // 
            this.dtProd.AllowUserToAddRows = false;
            this.dtProd.AllowUserToDeleteRows = false;
            this.dtProd.AllowUserToResizeRows = false;
            this.dtProd.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtProd.Enabled = false;
            this.dtProd.Location = new System.Drawing.Point(410, 341);
            this.dtProd.MultiSelect = false;
            this.dtProd.Name = "dtProd";
            this.dtProd.ReadOnly = true;
            this.dtProd.RowHeadersVisible = false;
            this.dtProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtProd.ShowCellErrors = false;
            this.dtProd.ShowCellToolTips = false;
            this.dtProd.ShowEditingIcon = false;
            this.dtProd.ShowRowErrors = false;
            this.dtProd.Size = new System.Drawing.Size(375, 128);
            this.dtProd.TabIndex = 17;
            this.dtProd.DataSourceChanged += new System.EventHandler(this.dtProd_DataSourceChanged);
            this.dtProd.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtProd_CellEnter);
            this.dtProd.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtProd_RowsAdded);
            this.dtProd.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtProd_RowsRemoved);
            this.dtProd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtProd_KeyUp);
            this.dtProd.MouseLeave += new System.EventHandler(this.dtProd_MouseLeave);
            this.dtProd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtProd_MouseMove);
            // 
            // lblItens
            // 
            this.lblItens.BackColor = System.Drawing.Color.AliceBlue;
            this.lblItens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblItens.ForeColor = System.Drawing.Color.Blue;
            this.lblItens.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblItens.Location = new System.Drawing.Point(24, 317);
            this.lblItens.Name = "lblItens";
            this.lblItens.Size = new System.Drawing.Size(380, 25);
            this.lblItens.TabIndex = 0;
            this.lblItens.Text = "Itens da Venda (Crédito):";
            this.lblItens.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProdutos
            // 
            this.lblProdutos.BackColor = System.Drawing.Color.AliceBlue;
            this.lblProdutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblProdutos.ForeColor = System.Drawing.Color.Red;
            this.lblProdutos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblProdutos.Location = new System.Drawing.Point(410, 317);
            this.lblProdutos.Name = "lblProdutos";
            this.lblProdutos.Size = new System.Drawing.Size(375, 25);
            this.lblProdutos.TabIndex = 0;
            this.lblProdutos.Text = "Produtos (Novos Itens):";
            this.lblProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnIncluir
            // 
            this.btnIncluir.Enabled = false;
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIncluir.Location = new System.Drawing.Point(655, 475);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(62, 25);
            this.btnIncluir.TabIndex = 20;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnIncluir, "Incluir um novo Produto.");
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            this.btnIncluir.MouseLeave += new System.EventHandler(this.btnIncluir_MouseLeave);
            this.btnIncluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnIncluir_MouseMove);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(723, 475);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(62, 25);
            this.btnExcluir.TabIndex = 21;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnExcluir, "Excluir um Produto informado.");
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            this.btnExcluir.MouseLeave += new System.EventHandler(this.btnExcluir_MouseLeave);
            this.btnExcluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluir_MouseMove);
            // 
            // grbBox2
            // 
            this.grbBox2.BackColor = System.Drawing.Color.LightGray;
            this.grbBox2.Controls.Add(this.lblValorTotalProdutos);
            this.grbBox2.Controls.Add(this.lblTotalProduto);
            this.grbBox2.Controls.Add(this.lblValorTotalVenda);
            this.grbBox2.Controls.Add(this.lblValorTotal);
            this.grbBox2.Controls.Add(this.lblVenda);
            this.grbBox2.Controls.Add(this.lblCredito);
            this.grbBox2.Controls.Add(this.lblTotal);
            this.grbBox2.Controls.Add(this.lblValorNovosItens);
            this.grbBox2.Controls.Add(this.lblNovosItens);
            this.grbBox2.Controls.Add(this.lblValorCredito);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(24, 504);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(760, 59);
            this.grbBox2.TabIndex = 22;
            this.grbBox2.TabStop = false;
            // 
            // lblValorTotalProdutos
            // 
            this.lblValorTotalProdutos.BackColor = System.Drawing.Color.White;
            this.lblValorTotalProdutos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotalProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblValorTotalProdutos.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotalProdutos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblValorTotalProdutos.Location = new System.Drawing.Point(164, 29);
            this.lblValorTotalProdutos.Name = "lblValorTotalProdutos";
            this.lblValorTotalProdutos.Size = new System.Drawing.Size(119, 22);
            this.lblValorTotalProdutos.TabIndex = 0;
            this.lblValorTotalProdutos.Text = "0,00";
            this.lblValorTotalProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotalProdutos.Click += new System.EventHandler(this.lblValorTotalProdutos_Click);
            this.lblValorTotalProdutos.MouseLeave += new System.EventHandler(this.lblValorTotalProdutos_MouseLeave);
            this.lblValorTotalProdutos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotalProdutos_MouseMove);
            // 
            // lblTotalProduto
            // 
            this.lblTotalProduto.AutoSize = true;
            this.lblTotalProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotalProduto.Location = new System.Drawing.Point(141, 15);
            this.lblTotalProduto.Name = "lblTotalProduto";
            this.lblTotalProduto.Size = new System.Drawing.Size(146, 13);
            this.lblTotalProduto.TabIndex = 0;
            this.lblTotalProduto.Text = "Total dos Produtos (R$):";
            // 
            // lblValorTotalVenda
            // 
            this.lblValorTotalVenda.BackColor = System.Drawing.Color.White;
            this.lblValorTotalVenda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotalVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblValorTotalVenda.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotalVenda.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblValorTotalVenda.Location = new System.Drawing.Point(6, 29);
            this.lblValorTotalVenda.Name = "lblValorTotalVenda";
            this.lblValorTotalVenda.Size = new System.Drawing.Size(119, 22);
            this.lblValorTotalVenda.TabIndex = 0;
            this.lblValorTotalVenda.Text = "0,00";
            this.lblValorTotalVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotalVenda.Click += new System.EventHandler(this.lblValorTotalVenda_Click);
            this.lblValorTotalVenda.MouseLeave += new System.EventHandler(this.lblValorTotalVenda_MouseLeave);
            this.lblValorTotalVenda.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotalVenda_MouseMove);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.BackColor = System.Drawing.Color.White;
            this.lblValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblValorTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblValorTotal.Location = new System.Drawing.Point(635, 29);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(119, 22);
            this.lblValorTotal.TabIndex = 0;
            this.lblValorTotal.Text = "0,00";
            this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotal.TextChanged += new System.EventHandler(this.lblValorTotal_TextChanged);
            this.lblValorTotal.Click += new System.EventHandler(this.lblValorTotal_Click);
            this.lblValorTotal.MouseLeave += new System.EventHandler(this.lblValorTotal_MouseLeave);
            this.lblValorTotal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotal_MouseMove);
            // 
            // lblVenda
            // 
            this.lblVenda.AutoSize = true;
            this.lblVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblVenda.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVenda.Location = new System.Drawing.Point(2, 16);
            this.lblVenda.Name = "lblVenda";
            this.lblVenda.Size = new System.Drawing.Size(126, 13);
            this.lblVenda.TabIndex = 0;
            this.lblVenda.Text = "Total da Venda (R$):";
            // 
            // lblCredito
            // 
            this.lblCredito.AutoSize = true;
            this.lblCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblCredito.ForeColor = System.Drawing.Color.Blue;
            this.lblCredito.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCredito.Location = new System.Drawing.Point(322, 15);
            this.lblCredito.Name = "lblCredito";
            this.lblCredito.Size = new System.Drawing.Size(79, 13);
            this.lblCredito.TabIndex = 0;
            this.lblCredito.Text = "Crédito (R$):";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotal.Location = new System.Drawing.Point(632, 15);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(94, 13);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Diferença (R$):";
            // 
            // lblValorNovosItens
            // 
            this.lblValorNovosItens.BackColor = System.Drawing.Color.White;
            this.lblValorNovosItens.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorNovosItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblValorNovosItens.ForeColor = System.Drawing.Color.Red;
            this.lblValorNovosItens.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblValorNovosItens.Location = new System.Drawing.Point(473, 29);
            this.lblValorNovosItens.Name = "lblValorNovosItens";
            this.lblValorNovosItens.Size = new System.Drawing.Size(119, 22);
            this.lblValorNovosItens.TabIndex = 0;
            this.lblValorNovosItens.Text = "0,00";
            this.lblValorNovosItens.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorNovosItens.Click += new System.EventHandler(this.lblValorNovosItens_Click);
            this.lblValorNovosItens.MouseLeave += new System.EventHandler(this.lblValorNovosItens_MouseLeave);
            this.lblValorNovosItens.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorNovosItens_MouseMove);
            // 
            // lblNovosItens
            // 
            this.lblNovosItens.AutoSize = true;
            this.lblNovosItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNovosItens.ForeColor = System.Drawing.Color.Red;
            this.lblNovosItens.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNovosItens.Location = new System.Drawing.Point(470, 15);
            this.lblNovosItens.Name = "lblNovosItens";
            this.lblNovosItens.Size = new System.Drawing.Size(107, 13);
            this.lblNovosItens.TabIndex = 0;
            this.lblNovosItens.Text = "Novos Itens (R$):";
            // 
            // lblValorCredito
            // 
            this.lblValorCredito.BackColor = System.Drawing.Color.White;
            this.lblValorCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblValorCredito.ForeColor = System.Drawing.Color.Blue;
            this.lblValorCredito.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblValorCredito.Location = new System.Drawing.Point(325, 29);
            this.lblValorCredito.Name = "lblValorCredito";
            this.lblValorCredito.Size = new System.Drawing.Size(119, 22);
            this.lblValorCredito.TabIndex = 0;
            this.lblValorCredito.Text = "0,00";
            this.lblValorCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorCredito.Click += new System.EventHandler(this.lblValorCredito_Click);
            this.lblValorCredito.MouseLeave += new System.EventHandler(this.lblValorCredito_MouseLeave);
            this.lblValorCredito.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorCredito_MouseMove);
            // 
            // lblCodigoVenda
            // 
            this.lblCodigoVenda.BackColor = System.Drawing.Color.AliceBlue;
            this.lblCodigoVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCodigoVenda.ForeColor = System.Drawing.Color.Black;
            this.lblCodigoVenda.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCodigoVenda.Location = new System.Drawing.Point(201, 322);
            this.lblCodigoVenda.Name = "lblCodigoVenda";
            this.lblCodigoVenda.Size = new System.Drawing.Size(102, 16);
            this.lblCodigoVenda.TabIndex = 0;
            this.lblCodigoVenda.Text = "0";
            this.lblCodigoVenda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCodigoVenda.Visible = false;
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(730, 569);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 24;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnSair, "Sair de Devolução de Produtos.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
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
            // btnZerar
            // 
            this.btnZerar.Enabled = false;
            this.btnZerar.Image = ((System.Drawing.Image)(resources.GetObject("btnZerar.Image")));
            this.btnZerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZerar.Location = new System.Drawing.Point(283, 475);
            this.btnZerar.Name = "btnZerar";
            this.btnZerar.Size = new System.Drawing.Size(121, 25);
            this.btnZerar.TabIndex = 19;
            this.btnZerar.Text = "&Zerar Quantidades";
            this.btnZerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnZerar, "Clique para zerar todas as quantidades dos itens.");
            this.btnZerar.UseVisualStyleBackColor = true;
            this.btnZerar.Click += new System.EventHandler(this.btnZerar_Click);
            this.btnZerar.MouseLeave += new System.EventHandler(this.btnZerar_MouseLeave);
            this.btnZerar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnZerar_MouseMove);
            // 
            // btnAltQuantidade
            // 
            this.btnAltQuantidade.Enabled = false;
            this.btnAltQuantidade.Image = ((System.Drawing.Image)(resources.GetObject("btnAltQuantidade.Image")));
            this.btnAltQuantidade.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAltQuantidade.Location = new System.Drawing.Point(213, 475);
            this.btnAltQuantidade.Name = "btnAltQuantidade";
            this.btnAltQuantidade.Size = new System.Drawing.Size(64, 25);
            this.btnAltQuantidade.TabIndex = 18;
            this.btnAltQuantidade.Text = "&Alterar";
            this.btnAltQuantidade.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnAltQuantidade, "Clique para alterar a quantidade do item selecionado.");
            this.btnAltQuantidade.UseVisualStyleBackColor = true;
            this.btnAltQuantidade.Click += new System.EventHandler(this.btnAltQuantidade_Click);
            this.btnAltQuantidade.MouseLeave += new System.EventHandler(this.btnAltQuantidade_MouseLeave);
            this.btnAltQuantidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAltQuantidade_MouseMove);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Enabled = false;
            this.btnContinuar.Image = ((System.Drawing.Image)(resources.GetObject("btnContinuar.Image")));
            this.btnContinuar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnContinuar.Location = new System.Drawing.Point(24, 569);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(90, 32);
            this.btnContinuar.TabIndex = 23;
            this.btnContinuar.Text = "&Continuar";
            this.btnContinuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDevolucao.SetToolTip(this.btnContinuar, "Clique para prosseguir com a devolução/troca.");
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            this.btnContinuar.MouseLeave += new System.EventHandler(this.btnContinuar_MouseLeave);
            this.btnContinuar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnContinuar_MouseMove);
            // 
            // lblRegistrosVenda
            // 
            this.lblRegistrosVenda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistrosVenda.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistrosVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrosVenda.ForeColor = System.Drawing.Color.Black;
            this.lblRegistrosVenda.Location = new System.Drawing.Point(21, 291);
            this.lblRegistrosVenda.Name = "lblRegistrosVenda";
            this.lblRegistrosVenda.Size = new System.Drawing.Size(160, 26);
            this.lblRegistrosVenda.TabIndex = 0;
            this.lblRegistrosVenda.Text = "Registros: 0";
            this.lblRegistrosVenda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistrosItem
            // 
            this.lblRegistrosItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistrosItem.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistrosItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrosItem.ForeColor = System.Drawing.Color.Black;
            this.lblRegistrosItem.Location = new System.Drawing.Point(21, 472);
            this.lblRegistrosItem.Name = "lblRegistrosItem";
            this.lblRegistrosItem.Size = new System.Drawing.Size(160, 26);
            this.lblRegistrosItem.TabIndex = 0;
            this.lblRegistrosItem.Text = "Registros: 0";
            this.lblRegistrosItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistrosProd
            // 
            this.lblRegistrosProd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistrosProd.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistrosProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrosProd.ForeColor = System.Drawing.Color.Black;
            this.lblRegistrosProd.Location = new System.Drawing.Point(407, 472);
            this.lblRegistrosProd.Name = "lblRegistrosProd";
            this.lblRegistrosProd.Size = new System.Drawing.Size(160, 26);
            this.lblRegistrosProd.TabIndex = 0;
            this.lblRegistrosProd.Text = "Registros: 0";
            this.lblRegistrosProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao1.Location = new System.Drawing.Point(188, 478);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 53;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // picbInterrogacao3
            // 
            this.picbInterrogacao3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao3.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao3.Image")));
            this.picbInterrogacao3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao3.Location = new System.Drawing.Point(629, 478);
            this.picbInterrogacao3.Name = "picbInterrogacao3";
            this.picbInterrogacao3.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao3.TabIndex = 54;
            this.picbInterrogacao3.TabStop = false;
            this.picbInterrogacao3.Click += new System.EventHandler(this.picbInterrogacao3_Click);
            this.picbInterrogacao3.MouseLeave += new System.EventHandler(this.picbInterrogacao3_MouseLeave);
            this.picbInterrogacao3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao3_MouseMove);
            // 
            // prtDocumento
            // 
            this.prtDocumento.DocumentName = "Cupom Não Fiscal";
            // 
            // pEnabled
            // 
            this.pEnabled.Controls.Add(this.lblVendaLeg);
            this.pEnabled.Controls.Add(this.btnSair);
            this.pEnabled.Controls.Add(this.btnContinuar);
            this.pEnabled.Controls.Add(this.lblLocalizar);
            this.pEnabled.Controls.Add(this.picbInterrogacao3);
            this.pEnabled.Controls.Add(this.grbBox2);
            this.pEnabled.Controls.Add(this.grbBox1);
            this.pEnabled.Controls.Add(this.picbInterrogacao1);
            this.pEnabled.Controls.Add(this.dtVenda);
            this.pEnabled.Controls.Add(this.btnAltQuantidade);
            this.pEnabled.Controls.Add(this.btnZerar);
            this.pEnabled.Controls.Add(this.lblRegistrosVenda);
            this.pEnabled.Controls.Add(this.lblRegistrosProd);
            this.pEnabled.Controls.Add(this.dtItensVenda);
            this.pEnabled.Controls.Add(this.lblCodigoVenda);
            this.pEnabled.Controls.Add(this.lblRegistrosItem);
            this.pEnabled.Controls.Add(this.btnExcluir);
            this.pEnabled.Controls.Add(this.lblItens);
            this.pEnabled.Controls.Add(this.btnIncluir);
            this.pEnabled.Controls.Add(this.lblProdutos);
            this.pEnabled.Controls.Add(this.dtProd);
            this.pEnabled.Location = new System.Drawing.Point(-13, -40);
            this.pEnabled.Name = "pEnabled";
            this.pEnabled.Size = new System.Drawing.Size(810, 616);
            this.pEnabled.TabIndex = 55;
            // 
            // lblVendaLeg
            // 
            this.lblVendaLeg.BackColor = System.Drawing.Color.AliceBlue;
            this.lblVendaLeg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVendaLeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblVendaLeg.ForeColor = System.Drawing.Color.Black;
            this.lblVendaLeg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVendaLeg.Location = new System.Drawing.Point(24, 136);
            this.lblVendaLeg.Name = "lblVendaLeg";
            this.lblVendaLeg.Size = new System.Drawing.Size(760, 25);
            this.lblVendaLeg.TabIndex = 0;
            this.lblVendaLeg.Text = "Vendas";
            this.lblVendaLeg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmDevolucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(784, 566);
            this.ControlBox = false;
            this.Controls.Add(this.pEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDevolucao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolução de Produtos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDevolucao_FormClosing);
            this.Load += new System.EventHandler(this.FrmDevolucao_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmDevolucao_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtItensVenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProd)).EndInit();
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao3)).EndInit();
            this.pEnabled.ResumeLayout(false);
            this.pEnabled.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnpProcurar;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.RadioButton rbtnConsumidor;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.ComboBox cbbpConsumidor;
        private System.Windows.Forms.Label lblLocalizar;
        private System.Windows.Forms.DataGridView dtVenda;
        private System.Windows.Forms.DataGridView dtItensVenda;
        private System.Windows.Forms.DataGridView dtProd;
        private System.Windows.Forms.Label lblItens;
        private System.Windows.Forms.Label lblProdutos;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblNovosItens;
        private System.Windows.Forms.Label lblCredito;
        private System.Windows.Forms.Label lblCodigoVenda;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblValorNovosItens;
        private System.Windows.Forms.Label lblValorCredito;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ToolTip ttpDevolucao;
        private System.Windows.Forms.Label lblRegistrosVenda;
        private System.Windows.Forms.Label lblRegistrosItem;
        private System.Windows.Forms.Label lblRegistrosProd;
        private System.Windows.Forms.Label lblValorTotalVenda;
        private System.Windows.Forms.Label lblVenda;
        private System.Windows.Forms.Button btnZerar;
        private System.Windows.Forms.Button btnAltQuantidade;
        private System.Windows.Forms.Label lblValorTotalProdutos;
        private System.Windows.Forms.Label lblTotalProduto;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.PictureBox picbInterrogacao3;
        private System.Windows.Forms.Button btnContinuar;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Drawing.Printing.PrintDocument prtDocumento;
        private System.Windows.Forms.Panel pEnabled;
        private System.Windows.Forms.RadioButton rbtnData;
        private System.Windows.Forms.Button btnSelecionarData1;
        private System.Windows.Forms.MaskedTextBox mtxtHorario1;
        private System.Windows.Forms.MaskedTextBox mtxtHorario;
        private System.Windows.Forms.Label lblAte1;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.Label lblVendaLeg;
    }
}