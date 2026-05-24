namespace Seven_Sistema
{
    partial class FrmSistema
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSistema));
            this.panCabecalho = new System.Windows.Forms.Panel();
            this.lblMensagemTopo = new System.Windows.Forms.Label();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.panTabela = new System.Windows.Forms.Panel();
            this.btnCalculadora = new System.Windows.Forms.Button();
            this.dtItems = new System.Windows.Forms.DataGridView();
            this.lblContAtiva = new System.Windows.Forms.Label();
            this.btnTipoVenda = new System.Windows.Forms.Button();
            this.btnTabela = new System.Windows.Forms.Button();
            this.lblTipo = new System.Windows.Forms.Label();
            this.btnExcluirCliente = new System.Windows.Forms.Button();
            this.btnExcluirItem = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.panProdutos = new System.Windows.Forms.Panel();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.btnAlterarValorUnitario = new System.Windows.Forms.Button();
            this.btnAlterarQuantidade = new System.Windows.Forms.Button();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.lblUnitario = new System.Windows.Forms.Label();
            this.txtUnitario = new System.Windows.Forms.TextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.btnProcurarProd = new System.Windows.Forms.Button();
            this.lblProduto = new System.Windows.Forms.Label();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.panTotalProdutos = new System.Windows.Forms.Panel();
            this.lblTotalProdutos = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.panQuantidade = new System.Windows.Forms.Panel();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblQuantidadeItem = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tstbBarraDaEsquerda = new System.Windows.Forms.ToolStripTextBox();
            this.aplicativoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.licençaDoAplicativoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarLicençaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aplicarLicençaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layoutPDVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mudarUsuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desenvolvedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.caporcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quantidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capturarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devolucaoF8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outrasOpçõesF12ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pausarCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contasAReceberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contasAPagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orçamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devoluçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sangriaSuprimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.históricoDoCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adicionarObservaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNFeNFCeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panMenuImagem = new System.Windows.Forms.Panel();
            this.lblLegendaImagem = new System.Windows.Forms.Label();
            this.lblImagemProduto = new System.Windows.Forms.Label();
            this.pcibImagemProduto = new System.Windows.Forms.PictureBox();
            this.sttBarraInf = new System.Windows.Forms.StatusStrip();
            this.tslblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblEmpresa = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblVersao = new System.Windows.Forms.ToolStripStatusLabel();
            this.ttpPDV = new System.Windows.Forms.ToolTip(this.components);
            this.prtDocumento = new System.Drawing.Printing.PrintDocument();
            this.timerTabela = new System.Windows.Forms.Timer(this.components);
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.TemporizadorVersao = new System.Windows.Forms.Timer(this.components);
            this.bckwInicio = new System.ComponentModel.BackgroundWorker();
            this.TemporizadorLogin = new System.Windows.Forms.Timer(this.components);
            this.panCabecalho.SuspendLayout();
            this.panTabela.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            this.panProdutos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.grbBox1.SuspendLayout();
            this.panTotalProdutos.SuspendLayout();
            this.panQuantidade.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panMenuImagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagemProduto)).BeginInit();
            this.sttBarraInf.SuspendLayout();
            this.SuspendLayout();
            // 
            // panCabecalho
            // 
            this.panCabecalho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panCabecalho.BackColor = System.Drawing.Color.LightGray;
            this.panCabecalho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panCabecalho.Controls.Add(this.lblMensagemTopo);
            this.panCabecalho.Controls.Add(this.lblProgresso);
            this.panCabecalho.Location = new System.Drawing.Point(16, 34);
            this.panCabecalho.Name = "panCabecalho";
            this.panCabecalho.Size = new System.Drawing.Size(1340, 65);
            this.panCabecalho.TabIndex = 1;
            // 
            // lblMensagemTopo
            // 
            this.lblMensagemTopo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMensagemTopo.Font = new System.Drawing.Font("Calibri", 44.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagemTopo.ForeColor = System.Drawing.Color.Blue;
            this.lblMensagemTopo.Location = new System.Drawing.Point(0, 0);
            this.lblMensagemTopo.Name = "lblMensagemTopo";
            this.lblMensagemTopo.Size = new System.Drawing.Size(1338, 63);
            this.lblMensagemTopo.TabIndex = 3;
            this.lblMensagemTopo.Text = "CAIXA LIVRE";
            this.lblMensagemTopo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProgresso
            // 
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft PhagsPa", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(0, 0);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(1338, 63);
            this.lblProgresso.TabIndex = 220;
            this.lblProgresso.Text = "Transmitindo, por favor, aguarde...";
            this.lblProgresso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProgresso.Visible = false;
            // 
            // panTabela
            // 
            this.panTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTabela.BackColor = System.Drawing.Color.LightGray;
            this.panTabela.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTabela.Controls.Add(this.btnCalculadora);
            this.panTabela.Controls.Add(this.dtItems);
            this.panTabela.Controls.Add(this.lblContAtiva);
            this.panTabela.Controls.Add(this.btnTipoVenda);
            this.panTabela.Controls.Add(this.btnTabela);
            this.panTabela.Controls.Add(this.lblTipo);
            this.panTabela.Controls.Add(this.btnExcluirCliente);
            this.panTabela.Controls.Add(this.btnExcluirItem);
            this.panTabela.Controls.Add(this.lblCliente);
            this.panTabela.Location = new System.Drawing.Point(407, 105);
            this.panTabela.Name = "panTabela";
            this.panTabela.Size = new System.Drawing.Size(948, 394);
            this.panTabela.TabIndex = 2;
            // 
            // btnCalculadora
            // 
            this.btnCalculadora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculadora.Image = ((System.Drawing.Image)(resources.GetObject("btnCalculadora.Image")));
            this.btnCalculadora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalculadora.Location = new System.Drawing.Point(594, 364);
            this.btnCalculadora.Name = "btnCalculadora";
            this.btnCalculadora.Size = new System.Drawing.Size(100, 25);
            this.btnCalculadora.TabIndex = 37;
            this.btnCalculadora.Text = "Calcu&ladora";
            this.btnCalculadora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPDV.SetToolTip(this.btnCalculadora, "Clique para exibir a calculadora do windows.");
            this.btnCalculadora.UseVisualStyleBackColor = true;
            this.btnCalculadora.Click += new System.EventHandler(this.btnCalculadora_Click);
            this.btnCalculadora.MouseLeave += new System.EventHandler(this.btnCalculadora_MouseLeave);
            this.btnCalculadora.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCalculadora_MouseMove);
            // 
            // dtItems
            // 
            this.dtItems.AllowUserToAddRows = false;
            this.dtItems.AllowUserToDeleteRows = false;
            this.dtItems.AllowUserToResizeRows = false;
            this.dtItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtItems.BackgroundColor = System.Drawing.Color.LightGray;
            this.dtItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtItems.ColumnHeadersHeight = 29;
            this.dtItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtItems.Location = new System.Drawing.Point(8, 21);
            this.dtItems.MultiSelect = false;
            this.dtItems.Name = "dtItems";
            this.dtItems.ReadOnly = true;
            this.dtItems.RowHeadersVisible = false;
            this.dtItems.RowHeadersWidth = 51;
            this.dtItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtItems.ShowCellErrors = false;
            this.dtItems.ShowCellToolTips = false;
            this.dtItems.ShowEditingIcon = false;
            this.dtItems.ShowRowErrors = false;
            this.dtItems.Size = new System.Drawing.Size(940, 336);
            this.dtItems.StandardTab = true;
            this.dtItems.TabIndex = 0;
            this.dtItems.DataSourceChanged += new System.EventHandler(this.dtItems_DataSourceChanged);
            this.dtItems.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtItems_CellEnter);
            this.dtItems.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtItems_ColumnHeaderMouseClick);
            this.dtItems.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtItems_RowsAdded);
            this.dtItems.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtItems_RowsRemoved);
            this.dtItems.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtItems_KeyUp);
            this.dtItems.MouseLeave += new System.EventHandler(this.dtItems_MouseLeave);
            this.dtItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtItems_MouseMove);
            // 
            // lblContAtiva
            // 
            this.lblContAtiva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContAtiva.AutoSize = true;
            this.lblContAtiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblContAtiva.ForeColor = System.Drawing.Color.Red;
            this.lblContAtiva.Location = new System.Drawing.Point(807, 2);
            this.lblContAtiva.Name = "lblContAtiva";
            this.lblContAtiva.Size = new System.Drawing.Size(136, 16);
            this.lblContAtiva.TabIndex = 36;
            this.lblContAtiva.Text = "Contingência Ativa";
            this.lblContAtiva.Visible = false;
            // 
            // btnTipoVenda
            // 
            this.btnTipoVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTipoVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTipoVenda.Image = ((System.Drawing.Image)(resources.GetObject("btnTipoVenda.Image")));
            this.btnTipoVenda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTipoVenda.Location = new System.Drawing.Point(700, 364);
            this.btnTipoVenda.Name = "btnTipoVenda";
            this.btnTipoVenda.Size = new System.Drawing.Size(70, 25);
            this.btnTipoVenda.TabIndex = 35;
            this.btnTipoVenda.Text = "Tipo";
            this.btnTipoVenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPDV.SetToolTip(this.btnTipoVenda, "Clique mudar o tipo de documento da venda.");
            this.btnTipoVenda.UseVisualStyleBackColor = true;
            this.btnTipoVenda.Click += new System.EventHandler(this.btnTipoVenda_Click);
            this.btnTipoVenda.MouseLeave += new System.EventHandler(this.btnTipoVenda_MouseLeave);
            this.btnTipoVenda.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnTipoVenda_MouseMove);
            // 
            // btnTabela
            // 
            this.btnTabela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTabela.Enabled = false;
            this.btnTabela.Image = ((System.Drawing.Image)(resources.GetObject("btnTabela.Image")));
            this.btnTabela.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTabela.Location = new System.Drawing.Point(865, 364);
            this.btnTabela.Name = "btnTabela";
            this.btnTabela.Size = new System.Drawing.Size(78, 25);
            this.btnTabela.TabIndex = 34;
            this.btnTabela.Text = "Tabela [1]";
            this.btnTabela.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPDV.SetToolTip(this.btnTabela, "Clique para realizar uma venda enquanto a \'Tabela [1]\' está pendente com uma vend" +
        "a, devolução ou orçamento.");
            this.btnTabela.UseVisualStyleBackColor = true;
            this.btnTabela.Click += new System.EventHandler(this.btnTabela_Click);
            this.btnTabela.MouseLeave += new System.EventHandler(this.btnTabela_MouseLeave);
            this.btnTabela.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnTabela_MouseMove);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(0, 2);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(260, 16);
            this.lblTipo.TabIndex = 33;
            this.lblTipo.Text = "DAV (Documento Auxiliar de Venda):";
            // 
            // btnExcluirCliente
            // 
            this.btnExcluirCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcluirCliente.Enabled = false;
            this.btnExcluirCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirCliente.Image")));
            this.btnExcluirCliente.Location = new System.Drawing.Point(3, 364);
            this.btnExcluirCliente.Name = "btnExcluirCliente";
            this.btnExcluirCliente.Size = new System.Drawing.Size(26, 25);
            this.btnExcluirCliente.TabIndex = 32;
            this.btnExcluirCliente.Text = "        &z";
            this.btnExcluirCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPDV.SetToolTip(this.btnExcluirCliente, "Clique para remover o consumidor informado.");
            this.btnExcluirCliente.UseVisualStyleBackColor = true;
            this.btnExcluirCliente.Click += new System.EventHandler(this.btnExcluirCliente_Click);
            this.btnExcluirCliente.MouseLeave += new System.EventHandler(this.btnExcluirCliente_MouseLeave);
            this.btnExcluirCliente.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluirCliente_MouseMove);
            // 
            // btnExcluirItem
            // 
            this.btnExcluirItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluirItem.Enabled = false;
            this.btnExcluirItem.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirItem.Image")));
            this.btnExcluirItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluirItem.Location = new System.Drawing.Point(776, 364);
            this.btnExcluirItem.Name = "btnExcluirItem";
            this.btnExcluirItem.Size = new System.Drawing.Size(83, 25);
            this.btnExcluirItem.TabIndex = 8;
            this.btnExcluirItem.Text = "&Excluir Item";
            this.btnExcluirItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPDV.SetToolTip(this.btnExcluirItem, "Clique para excluir o item selecionado.");
            this.btnExcluirItem.UseVisualStyleBackColor = true;
            this.btnExcluirItem.Click += new System.EventHandler(this.btnExcluirItem_Click);
            this.btnExcluirItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnExcluirItem_KeyUp);
            this.btnExcluirItem.MouseLeave += new System.EventHandler(this.btnExcluirItem_MouseLeave);
            this.btnExcluirItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluirItem_MouseMove);
            // 
            // lblCliente
            // 
            this.lblCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCliente.AutoSize = true;
            this.lblCliente.Enabled = false;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(32, 367);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(215, 16);
            this.lblCliente.TabIndex = 9;
            this.lblCliente.Text = "Consumidor: Não identificado.";
            this.lblCliente.Click += new System.EventHandler(this.lblCliente_Click);
            this.lblCliente.MouseLeave += new System.EventHandler(this.lblCliente_MouseLeave);
            this.lblCliente.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblCliente_MouseMove);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(211, 0);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 32;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // panProdutos
            // 
            this.panProdutos.BackColor = System.Drawing.Color.LightGray;
            this.panProdutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panProdutos.Controls.Add(this.picbInterrogacao1);
            this.panProdutos.Controls.Add(this.grbBox1);
            this.panProdutos.Controls.Add(this.btnProcurarProd);
            this.panProdutos.Controls.Add(this.lblProduto);
            this.panProdutos.Controls.Add(this.txtProduto);
            this.panProdutos.Location = new System.Drawing.Point(16, 105);
            this.panProdutos.Name = "panProdutos";
            this.panProdutos.Size = new System.Drawing.Size(385, 246);
            this.panProdutos.TabIndex = 3;
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao1.Location = new System.Drawing.Point(360, 3);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 34;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.pictureBox2_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.pcibInterrogacao2_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao2_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnAlterarValorUnitario);
            this.grbBox1.Controls.Add(this.picbInterrogacao2);
            this.grbBox1.Controls.Add(this.btnAlterarQuantidade);
            this.grbBox1.Controls.Add(this.txtQuantidade);
            this.grbBox1.Controls.Add(this.lblUnitario);
            this.grbBox1.Controls.Add(this.txtUnitario);
            this.grbBox1.Controls.Add(this.lblQuantidade);
            this.grbBox1.Location = new System.Drawing.Point(7, 84);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(245, 153);
            this.grbBox1.TabIndex = 3;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Dados/Ações no item selecionado:";
            // 
            // btnAlterarValorUnitario
            // 
            this.btnAlterarValorUnitario.Enabled = false;
            this.btnAlterarValorUnitario.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterarValorUnitario.Image")));
            this.btnAlterarValorUnitario.Location = new System.Drawing.Point(166, 105);
            this.btnAlterarValorUnitario.Name = "btnAlterarValorUnitario";
            this.btnAlterarValorUnitario.Size = new System.Drawing.Size(65, 44);
            this.btnAlterarValorUnitario.TabIndex = 33;
            this.btnAlterarValorUnitario.Text = "\r\n\r\n&U";
            this.ttpPDV.SetToolTip(this.btnAlterarValorUnitario, "Clique para alterar o valor unitário do item selecionado.");
            this.btnAlterarValorUnitario.UseVisualStyleBackColor = true;
            this.btnAlterarValorUnitario.Click += new System.EventHandler(this.button1_Click_2);
            this.btnAlterarValorUnitario.MouseLeave += new System.EventHandler(this.btnAlterarValorUnitario_MouseLeave);
            this.btnAlterarValorUnitario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterarValorUnitario_MouseMove);
            // 
            // btnAlterarQuantidade
            // 
            this.btnAlterarQuantidade.Enabled = false;
            this.btnAlterarQuantidade.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterarQuantidade.Image")));
            this.btnAlterarQuantidade.Location = new System.Drawing.Point(166, 35);
            this.btnAlterarQuantidade.Name = "btnAlterarQuantidade";
            this.btnAlterarQuantidade.Size = new System.Drawing.Size(65, 44);
            this.btnAlterarQuantidade.TabIndex = 7;
            this.btnAlterarQuantidade.Text = "\r\n\r\n&Q\r\n";
            this.ttpPDV.SetToolTip(this.btnAlterarQuantidade, "Clique para alterar a quantidade do item selecionado.");
            this.btnAlterarQuantidade.UseVisualStyleBackColor = true;
            this.btnAlterarQuantidade.Click += new System.EventHandler(this.btnAlterarQuantidade_Click);
            this.btnAlterarQuantidade.MouseLeave += new System.EventHandler(this.btnAlterarQuantidade_MouseLeave);
            this.btnAlterarQuantidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterarQuantidade_MouseMove);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BackColor = System.Drawing.Color.White;
            this.txtQuantidade.Enabled = false;
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.Location = new System.Drawing.Point(6, 35);
            this.txtQuantidade.MaxLength = 10;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(154, 44);
            this.txtQuantidade.TabIndex = 3;
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantidade.Enter += new System.EventHandler(this.txtQuantidade_Enter);
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            this.txtQuantidade.Leave += new System.EventHandler(this.txtQuantidade_Leave);
            // 
            // lblUnitario
            // 
            this.lblUnitario.AutoSize = true;
            this.lblUnitario.Enabled = false;
            this.lblUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitario.ForeColor = System.Drawing.Color.Black;
            this.lblUnitario.Location = new System.Drawing.Point(6, 82);
            this.lblUnitario.Name = "lblUnitario";
            this.lblUnitario.Size = new System.Drawing.Size(124, 20);
            this.lblUnitario.TabIndex = 6;
            this.lblUnitario.Text = "Valor Unitário:";
            // 
            // txtUnitario
            // 
            this.txtUnitario.BackColor = System.Drawing.Color.White;
            this.txtUnitario.Enabled = false;
            this.txtUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitario.Location = new System.Drawing.Point(6, 105);
            this.txtUnitario.MaxLength = 10;
            this.txtUnitario.Name = "txtUnitario";
            this.txtUnitario.Size = new System.Drawing.Size(154, 44);
            this.txtUnitario.TabIndex = 5;
            this.txtUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnitario.Enter += new System.EventHandler(this.txtUnitario_Enter);
            this.txtUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnitario_KeyPress);
            this.txtUnitario.Leave += new System.EventHandler(this.txtUnitario_Leave);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Enabled = false;
            this.lblQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.ForeColor = System.Drawing.Color.Black;
            this.lblQuantidade.Location = new System.Drawing.Point(6, 12);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(107, 20);
            this.lblQuantidade.TabIndex = 4;
            this.lblQuantidade.Text = "Quantidade:";
            // 
            // btnProcurarProd
            // 
            this.btnProcurarProd.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarProd.Image")));
            this.btnProcurarProd.Location = new System.Drawing.Point(315, 24);
            this.btnProcurarProd.Name = "btnProcurarProd";
            this.btnProcurarProd.Size = new System.Drawing.Size(65, 44);
            this.btnProcurarProd.TabIndex = 2;
            this.ttpPDV.SetToolTip(this.btnProcurarProd, "Clique para adicionar/pesquisar um item.");
            this.btnProcurarProd.UseVisualStyleBackColor = true;
            this.btnProcurarProd.Click += new System.EventHandler(this.btnProcurarProd_Click);
            this.btnProcurarProd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnProcurarProd_KeyUp);
            this.btnProcurarProd.MouseLeave += new System.EventHandler(this.btnProcurarProd_MouseLeave);
            this.btnProcurarProd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarProd_MouseMove);
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(13, 7);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(77, 20);
            this.lblProduto.TabIndex = 1;
            this.lblProduto.Text = "Produto:";
            // 
            // txtProduto
            // 
            this.txtProduto.BackColor = System.Drawing.Color.White;
            this.txtProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduto.Location = new System.Drawing.Point(17, 32);
            this.txtProduto.MaxLength = 60;
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(292, 30);
            this.txtProduto.TabIndex = 0;
            this.txtProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProduto.Enter += new System.EventHandler(this.txtProduto_Enter);
            this.txtProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProduto_KeyDown);
            this.txtProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduto_KeyPress);
            this.txtProduto.Leave += new System.EventHandler(this.txtProduto_Leave);
            // 
            // panTotalProdutos
            // 
            this.panTotalProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTotalProdutos.BackColor = System.Drawing.Color.LightGray;
            this.panTotalProdutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTotalProdutos.Controls.Add(this.lblTotalProdutos);
            this.panTotalProdutos.Controls.Add(this.lblValorTotal);
            this.panTotalProdutos.Location = new System.Drawing.Point(622, 505);
            this.panTotalProdutos.Name = "panTotalProdutos";
            this.panTotalProdutos.Size = new System.Drawing.Size(733, 118);
            this.panTotalProdutos.TabIndex = 4;
            // 
            // lblTotalProdutos
            // 
            this.lblTotalProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProdutos.Location = new System.Drawing.Point(492, 0);
            this.lblTotalProdutos.Name = "lblTotalProdutos";
            this.lblTotalProdutos.Size = new System.Drawing.Size(235, 20);
            this.lblTotalProdutos.TabIndex = 0;
            this.lblTotalProdutos.Text = "Total dos produtos:";
            this.lblTotalProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblValorTotal.Font = new System.Drawing.Font("Calibri", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.ForeColor = System.Drawing.Color.Red;
            this.lblValorTotal.Location = new System.Drawing.Point(81, 27);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(668, 89);
            this.lblValorTotal.TabIndex = 1;
            this.lblValorTotal.Text = "R$  0,00";
            this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panQuantidade
            // 
            this.panQuantidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panQuantidade.BackColor = System.Drawing.Color.LightGray;
            this.panQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panQuantidade.Controls.Add(this.lblItem);
            this.panQuantidade.Controls.Add(this.lblQuantidadeItem);
            this.panQuantidade.Location = new System.Drawing.Point(407, 505);
            this.panQuantidade.Name = "panQuantidade";
            this.panQuantidade.Size = new System.Drawing.Size(209, 118);
            this.panQuantidade.TabIndex = 5;
            // 
            // lblItem
            // 
            this.lblItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(147, 0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(57, 20);
            this.lblItem.TabIndex = 1;
            this.lblItem.Text = "Itens:";
            // 
            // lblQuantidadeItem
            // 
            this.lblQuantidadeItem.Font = new System.Drawing.Font("Calibri", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeItem.Location = new System.Drawing.Point(19, 27);
            this.lblQuantidadeItem.Name = "lblQuantidadeItem";
            this.lblQuantidadeItem.Size = new System.Drawing.Size(207, 89);
            this.lblQuantidadeItem.TabIndex = 2;
            this.lblQuantidadeItem.Text = "0";
            this.lblQuantidadeItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstbBarraDaEsquerda,
            this.aplicativoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.caporcToolStripMenuItem,
            this.quantidadeToolStripMenuItem,
            this.cancelarToolStripMenuItem,
            this.clienteToolStripMenuItem,
            this.capturarToolStripMenuItem,
            this.devolucaoF8ToolStripMenuItem,
            this.outrasOpçõesF12ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1364, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tstbBarraDaEsquerda
            // 
            this.tstbBarraDaEsquerda.BackColor = System.Drawing.SystemColors.Control;
            this.tstbBarraDaEsquerda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tstbBarraDaEsquerda.Enabled = false;
            this.tstbBarraDaEsquerda.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tstbBarraDaEsquerda.MaxLength = 0;
            this.tstbBarraDaEsquerda.Name = "tstbBarraDaEsquerda";
            this.tstbBarraDaEsquerda.ReadOnly = true;
            this.tstbBarraDaEsquerda.Size = new System.Drawing.Size(10, 24);
            // 
            // aplicativoToolStripMenuItem
            // 
            this.aplicativoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.licençaDoAplicativoToolStripMenuItem,
            this.layoutPDVToolStripMenuItem,
            this.mudarUsuárioToolStripMenuItem,
            this.desenvolvedorToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.aplicativoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aplicativoToolStripMenuItem.Image")));
            this.aplicativoToolStripMenuItem.Name = "aplicativoToolStripMenuItem";
            this.aplicativoToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.aplicativoToolStripMenuItem.Text = "Aplica&tivo";
            this.aplicativoToolStripMenuItem.Click += new System.EventHandler(this.aplicativoToolStripMenuItem_Click);
            this.aplicativoToolStripMenuItem.MouseLeave += new System.EventHandler(this.aplicativoToolStripMenuItem_MouseLeave);
            this.aplicativoToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.aplicativoToolStripMenuItem_MouseMove);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(187, 22);
            this.toolStripMenuItem3.Text = "Atualizações";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            this.toolStripMenuItem3.MouseLeave += new System.EventHandler(this.toolStripMenuItem3_MouseLeave);
            this.toolStripMenuItem3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem3_MouseMove);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem4.Image")));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(187, 22);
            this.toolStripMenuItem4.Text = "Backup";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            this.toolStripMenuItem4.MouseLeave += new System.EventHandler(this.toolStripMenuItem4_MouseLeave);
            this.toolStripMenuItem4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem4_MouseMove);
            // 
            // licençaDoAplicativoToolStripMenuItem
            // 
            this.licençaDoAplicativoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarLicençaToolStripMenuItem,
            this.aplicarLicençaToolStripMenuItem});
            this.licençaDoAplicativoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("licençaDoAplicativoToolStripMenuItem.Image")));
            this.licençaDoAplicativoToolStripMenuItem.Name = "licençaDoAplicativoToolStripMenuItem";
            this.licençaDoAplicativoToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.licençaDoAplicativoToolStripMenuItem.Text = "Licença do Aplicativo";
            this.licençaDoAplicativoToolStripMenuItem.MouseLeave += new System.EventHandler(this.licençaDoAplicativoToolStripMenuItem_MouseLeave);
            this.licençaDoAplicativoToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.licençaDoAplicativoToolStripMenuItem_MouseMove);
            // 
            // consultarLicençaToolStripMenuItem
            // 
            this.consultarLicençaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consultarLicençaToolStripMenuItem.Image")));
            this.consultarLicençaToolStripMenuItem.Name = "consultarLicençaToolStripMenuItem";
            this.consultarLicençaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.consultarLicençaToolStripMenuItem.Text = "Consultar Licença";
            this.consultarLicençaToolStripMenuItem.Click += new System.EventHandler(this.consultarLicençaToolStripMenuItem_Click);
            this.consultarLicençaToolStripMenuItem.MouseLeave += new System.EventHandler(this.consultarLicençaToolStripMenuItem_MouseLeave);
            this.consultarLicençaToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.consultarLicençaToolStripMenuItem_MouseMove);
            // 
            // aplicarLicençaToolStripMenuItem
            // 
            this.aplicarLicençaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aplicarLicençaToolStripMenuItem.Image")));
            this.aplicarLicençaToolStripMenuItem.Name = "aplicarLicençaToolStripMenuItem";
            this.aplicarLicençaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.aplicarLicençaToolStripMenuItem.Text = "Aplicar Licença";
            this.aplicarLicençaToolStripMenuItem.Click += new System.EventHandler(this.aplicarLicençaToolStripMenuItem_Click);
            this.aplicarLicençaToolStripMenuItem.MouseLeave += new System.EventHandler(this.aplicarLicençaToolStripMenuItem_MouseLeave);
            this.aplicarLicençaToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.aplicarLicençaToolStripMenuItem_MouseMove);
            // 
            // layoutPDVToolStripMenuItem
            // 
            this.layoutPDVToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("layoutPDVToolStripMenuItem.Image")));
            this.layoutPDVToolStripMenuItem.Name = "layoutPDVToolStripMenuItem";
            this.layoutPDVToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.layoutPDVToolStripMenuItem.Text = "Layout PDV";
            this.layoutPDVToolStripMenuItem.Click += new System.EventHandler(this.layoutPDVToolStripMenuItem_Click);
            this.layoutPDVToolStripMenuItem.MouseLeave += new System.EventHandler(this.layoutPDVToolStripMenuItem_MouseLeave);
            this.layoutPDVToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.layoutPDVToolStripMenuItem_MouseMove);
            // 
            // mudarUsuárioToolStripMenuItem
            // 
            this.mudarUsuárioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mudarUsuárioToolStripMenuItem.Image")));
            this.mudarUsuárioToolStripMenuItem.Name = "mudarUsuárioToolStripMenuItem";
            this.mudarUsuárioToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.mudarUsuárioToolStripMenuItem.Text = "Mudar de Usuário";
            this.mudarUsuárioToolStripMenuItem.Click += new System.EventHandler(this.mudarUsuárioToolStripMenuItem_Click);
            this.mudarUsuárioToolStripMenuItem.MouseLeave += new System.EventHandler(this.mudarUsuárioToolStripMenuItem_MouseLeave);
            this.mudarUsuárioToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mudarUsuárioToolStripMenuItem_MouseMove);
            // 
            // desenvolvedorToolStripMenuItem
            // 
            this.desenvolvedorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("desenvolvedorToolStripMenuItem.Image")));
            this.desenvolvedorToolStripMenuItem.Name = "desenvolvedorToolStripMenuItem";
            this.desenvolvedorToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.desenvolvedorToolStripMenuItem.Text = "Sobre";
            this.desenvolvedorToolStripMenuItem.Click += new System.EventHandler(this.desenvolvedorToolStripMenuItem_Click);
            this.desenvolvedorToolStripMenuItem.MouseLeave += new System.EventHandler(this.desenvolvedorToolStripMenuItem_MouseLeave);
            this.desenvolvedorToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.desenvolvedorToolStripMenuItem_MouseMove);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sairToolStripMenuItem.Image")));
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            this.sairToolStripMenuItem.MouseLeave += new System.EventHandler(this.sairToolStripMenuItem_MouseLeave);
            this.sairToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sairToolStripMenuItem_MouseMove);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.AutoToolTip = true;
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(110, 24);
            this.toolStripMenuItem1.Text = "1 - &Ajuda [F1]";
            this.toolStripMenuItem1.ToolTipText = "Clique para abrir o arquivo de ajuda.";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            this.toolStripMenuItem1.MouseLeave += new System.EventHandler(this.toolStripMenuItem1_MouseLeave);
            this.toolStripMenuItem1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem1_MouseMove);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.AutoToolTip = true;
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(140, 24);
            this.toolStripMenuItem2.Text = "2 - &Pagamento [F2]";
            this.toolStripMenuItem2.ToolTipText = "Clique para finalizar a venda com forma de pagamento.";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            this.toolStripMenuItem2.MouseLeave += new System.EventHandler(this.toolStripMenuItem2_MouseLeave);
            this.toolStripMenuItem2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStripMenuItem2_MouseMove);
            // 
            // caporcToolStripMenuItem
            // 
            this.caporcToolStripMenuItem.AutoToolTip = true;
            this.caporcToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("caporcToolStripMenuItem.Image")));
            this.caporcToolStripMenuItem.Name = "caporcToolStripMenuItem";
            this.caporcToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.caporcToolStripMenuItem.Text = "3 - O&rçamento [F3]";
            this.caporcToolStripMenuItem.ToolTipText = "Clique para finalizar a venda com forma duplicata.";
            this.caporcToolStripMenuItem.Click += new System.EventHandler(this.duplicataToolStripMenuItem_Click);
            this.caporcToolStripMenuItem.MouseLeave += new System.EventHandler(this.duplicataToolStripMenuItem_MouseLeave);
            this.caporcToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.duplicataToolStripMenuItem_MouseMove);
            // 
            // quantidadeToolStripMenuItem
            // 
            this.quantidadeToolStripMenuItem.AutoToolTip = true;
            this.quantidadeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quantidadeToolStripMenuItem.Image")));
            this.quantidadeToolStripMenuItem.Name = "quantidadeToolStripMenuItem";
            this.quantidadeToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.quantidadeToolStripMenuItem.Text = "4 - &Quantidade [F4]";
            this.quantidadeToolStripMenuItem.ToolTipText = "Clique para adicionar quantidade ao item.";
            this.quantidadeToolStripMenuItem.Click += new System.EventHandler(this.quantidadeToolStripMenuItem_Click);
            this.quantidadeToolStripMenuItem.MouseLeave += new System.EventHandler(this.quantidadeToolStripMenuItem_MouseLeave);
            this.quantidadeToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.quantidadeToolStripMenuItem_MouseMove);
            // 
            // cancelarToolStripMenuItem
            // 
            this.cancelarToolStripMenuItem.AutoToolTip = true;
            this.cancelarToolStripMenuItem.Enabled = false;
            this.cancelarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cancelarToolStripMenuItem.Image")));
            this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
            this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.cancelarToolStripMenuItem.Text = "5 - &Cancelar [F5]";
            this.cancelarToolStripMenuItem.ToolTipText = "Clique para cancelar a venda.";
            this.cancelarToolStripMenuItem.Click += new System.EventHandler(this.cancelarToolStripMenuItem_Click);
            this.cancelarToolStripMenuItem.MouseLeave += new System.EventHandler(this.cancelarToolStripMenuItem_MouseLeave);
            this.cancelarToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cancelarToolStripMenuItem_MouseMove);
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.AutoToolTip = true;
            this.clienteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clienteToolStripMenuItem.Image")));
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.clienteToolStripMenuItem.Text = "6 - Con&sumidor [F6]";
            this.clienteToolStripMenuItem.ToolTipText = "Clique para adicionar um cliente a venda.";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            this.clienteToolStripMenuItem.MouseLeave += new System.EventHandler(this.clienteToolStripMenuItem_MouseLeave);
            this.clienteToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.clienteToolStripMenuItem_MouseMove);
            // 
            // capturarToolStripMenuItem
            // 
            this.capturarToolStripMenuItem.AutoToolTip = true;
            this.capturarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("capturarToolStripMenuItem.Image")));
            this.capturarToolStripMenuItem.Name = "capturarToolStripMenuItem";
            this.capturarToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.capturarToolStripMenuItem.Text = "7 - Capt&urar [F7]";
            this.capturarToolStripMenuItem.ToolTipText = "Clique para Capturar um Orçamento.";
            this.capturarToolStripMenuItem.Click += new System.EventHandler(this.produtoToolStripMenuItem_Click);
            this.capturarToolStripMenuItem.MouseLeave += new System.EventHandler(this.produtoToolStripMenuItem_MouseLeave);
            this.capturarToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.produtoToolStripMenuItem_MouseMove);
            // 
            // devolucaoF8ToolStripMenuItem
            // 
            this.devolucaoF8ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("devolucaoF8ToolStripMenuItem.Image")));
            this.devolucaoF8ToolStripMenuItem.Name = "devolucaoF8ToolStripMenuItem";
            this.devolucaoF8ToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.devolucaoF8ToolStripMenuItem.Text = "8 - &Devolução [F8]";
            this.devolucaoF8ToolStripMenuItem.Click += new System.EventHandler(this.outrasOpçõesF12ToolStripMenuItem_Click);
            this.devolucaoF8ToolStripMenuItem.MouseLeave += new System.EventHandler(this.outrasOpçõesF12ToolStripMenuItem_MouseLeave);
            this.devolucaoF8ToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.outrasOpçõesF12ToolStripMenuItem_MouseMove);
            // 
            // outrasOpçõesF12ToolStripMenuItem1
            // 
            this.outrasOpçõesF12ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirCaixaToolStripMenuItem,
            this.pausarCaixaToolStripMenuItem,
            this.fecharCaixaToolStripMenuItem,
            this.contasAReceberToolStripMenuItem,
            this.contasAPagarToolStripMenuItem,
            this.vendasToolStripMenuItem,
            this.orçamentosToolStripMenuItem,
            this.devoluçõesToolStripMenuItem,
            this.sangriaSuprimentoToolStripMenuItem,
            this.históricoDoCaixaToolStripMenuItem,
            this.adicionarObservaçãoToolStripMenuItem,
            this.menuNFeNFCeToolStripMenuItem});
            this.outrasOpçõesF12ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("outrasOpçõesF12ToolStripMenuItem1.Image")));
            this.outrasOpçõesF12ToolStripMenuItem1.Name = "outrasOpçõesF12ToolStripMenuItem1";
            this.outrasOpçõesF12ToolStripMenuItem1.Size = new System.Drawing.Size(157, 24);
            this.outrasOpçõesF12ToolStripMenuItem1.Text = "9 - &Outras Opções [F9]";
            this.outrasOpçõesF12ToolStripMenuItem1.DropDownOpened += new System.EventHandler(this.outrasOpçõesF12ToolStripMenuItem1_DropDownOpened);
            this.outrasOpçõesF12ToolStripMenuItem1.Click += new System.EventHandler(this.outrasOpçõesF12ToolStripMenuItem1_Click);
            this.outrasOpçõesF12ToolStripMenuItem1.MouseLeave += new System.EventHandler(this.outrasOpçõesF12ToolStripMenuItem1_MouseLeave);
            this.outrasOpçõesF12ToolStripMenuItem1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.outrasOpçõesF12ToolStripMenuItem1_MouseMove);
            // 
            // abrirCaixaToolStripMenuItem
            // 
            this.abrirCaixaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("abrirCaixaToolStripMenuItem.Image")));
            this.abrirCaixaToolStripMenuItem.Name = "abrirCaixaToolStripMenuItem";
            this.abrirCaixaToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.abrirCaixaToolStripMenuItem.Text = "Abrir Caixa";
            this.abrirCaixaToolStripMenuItem.Click += new System.EventHandler(this.abrirCaixaToolStripMenuItem_Click);
            this.abrirCaixaToolStripMenuItem.MouseLeave += new System.EventHandler(this.abrirCaixaToolStripMenuItem_MouseLeave);
            this.abrirCaixaToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.abrirCaixaToolStripMenuItem_MouseMove);
            // 
            // pausarCaixaToolStripMenuItem
            // 
            this.pausarCaixaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pausarCaixaToolStripMenuItem.Image")));
            this.pausarCaixaToolStripMenuItem.Name = "pausarCaixaToolStripMenuItem";
            this.pausarCaixaToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.pausarCaixaToolStripMenuItem.Text = "Pausar/Retomar Caixa";
            this.pausarCaixaToolStripMenuItem.Click += new System.EventHandler(this.pausarCaixaToolStripMenuItem_Click);
            this.pausarCaixaToolStripMenuItem.MouseLeave += new System.EventHandler(this.pausarCaixaToolStripMenuItem_MouseLeave);
            this.pausarCaixaToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pausarCaixaToolStripMenuItem_MouseMove);
            // 
            // fecharCaixaToolStripMenuItem
            // 
            this.fecharCaixaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fecharCaixaToolStripMenuItem.Image")));
            this.fecharCaixaToolStripMenuItem.Name = "fecharCaixaToolStripMenuItem";
            this.fecharCaixaToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.fecharCaixaToolStripMenuItem.Text = "Fechar Caixa";
            this.fecharCaixaToolStripMenuItem.Click += new System.EventHandler(this.fecharCaixaToolStripMenuItem_Click);
            this.fecharCaixaToolStripMenuItem.MouseLeave += new System.EventHandler(this.fecharCaixaToolStripMenuItem_MouseLeave);
            this.fecharCaixaToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fecharCaixaToolStripMenuItem_MouseMove);
            // 
            // contasAReceberToolStripMenuItem
            // 
            this.contasAReceberToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("contasAReceberToolStripMenuItem.Image")));
            this.contasAReceberToolStripMenuItem.Name = "contasAReceberToolStripMenuItem";
            this.contasAReceberToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.contasAReceberToolStripMenuItem.Text = "Contas a Receber";
            this.contasAReceberToolStripMenuItem.Click += new System.EventHandler(this.contasAReceberToolStripMenuItem_Click);
            this.contasAReceberToolStripMenuItem.MouseLeave += new System.EventHandler(this.contasAReceberToolStripMenuItem_MouseLeave);
            this.contasAReceberToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.contasAReceberToolStripMenuItem_MouseMove);
            // 
            // contasAPagarToolStripMenuItem
            // 
            this.contasAPagarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("contasAPagarToolStripMenuItem.Image")));
            this.contasAPagarToolStripMenuItem.Name = "contasAPagarToolStripMenuItem";
            this.contasAPagarToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.contasAPagarToolStripMenuItem.Text = "Contas a Pagar";
            this.contasAPagarToolStripMenuItem.Click += new System.EventHandler(this.contasAPagarToolStripMenuItem_Click);
            this.contasAPagarToolStripMenuItem.MouseLeave += new System.EventHandler(this.contasAPagarToolStripMenuItem_MouseLeave);
            this.contasAPagarToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.contasAPagarToolStripMenuItem_MouseMove);
            // 
            // vendasToolStripMenuItem
            // 
            this.vendasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("vendasToolStripMenuItem.Image")));
            this.vendasToolStripMenuItem.Name = "vendasToolStripMenuItem";
            this.vendasToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.vendasToolStripMenuItem.Text = "Vendas";
            this.vendasToolStripMenuItem.Click += new System.EventHandler(this.vendasToolStripMenuItem_Click);
            this.vendasToolStripMenuItem.MouseLeave += new System.EventHandler(this.vendasToolStripMenuItem_MouseLeave);
            this.vendasToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.vendasToolStripMenuItem_MouseMove);
            // 
            // orçamentosToolStripMenuItem
            // 
            this.orçamentosToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("orçamentosToolStripMenuItem.Image")));
            this.orçamentosToolStripMenuItem.Name = "orçamentosToolStripMenuItem";
            this.orçamentosToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.orçamentosToolStripMenuItem.Text = "Orçamentos";
            this.orçamentosToolStripMenuItem.Click += new System.EventHandler(this.orçamentosToolStripMenuItem_Click);
            this.orçamentosToolStripMenuItem.MouseLeave += new System.EventHandler(this.orçamentosToolStripMenuItem_MouseLeave);
            this.orçamentosToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.orçamentosToolStripMenuItem_MouseMove);
            // 
            // devoluçõesToolStripMenuItem
            // 
            this.devoluçõesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("devoluçõesToolStripMenuItem.Image")));
            this.devoluçõesToolStripMenuItem.Name = "devoluçõesToolStripMenuItem";
            this.devoluçõesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.devoluçõesToolStripMenuItem.Text = "Devoluções";
            this.devoluçõesToolStripMenuItem.Click += new System.EventHandler(this.devoluçõesToolStripMenuItem_Click);
            this.devoluçõesToolStripMenuItem.MouseLeave += new System.EventHandler(this.devoluçõesToolStripMenuItem_MouseLeave);
            this.devoluçõesToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.devoluçõesToolStripMenuItem_MouseMove);
            // 
            // sangriaSuprimentoToolStripMenuItem
            // 
            this.sangriaSuprimentoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sangriaSuprimentoToolStripMenuItem.Image")));
            this.sangriaSuprimentoToolStripMenuItem.Name = "sangriaSuprimentoToolStripMenuItem";
            this.sangriaSuprimentoToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.sangriaSuprimentoToolStripMenuItem.Text = "Sangria/Suprimento";
            this.sangriaSuprimentoToolStripMenuItem.Click += new System.EventHandler(this.sangriaSuprimentoToolStripMenuItem_Click);
            this.sangriaSuprimentoToolStripMenuItem.MouseLeave += new System.EventHandler(this.sangriaSuprimentoToolStripMenuItem_MouseLeave);
            this.sangriaSuprimentoToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sangriaSuprimentoToolStripMenuItem_MouseMove);
            // 
            // históricoDoCaixaToolStripMenuItem
            // 
            this.históricoDoCaixaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("históricoDoCaixaToolStripMenuItem.Image")));
            this.históricoDoCaixaToolStripMenuItem.Name = "históricoDoCaixaToolStripMenuItem";
            this.históricoDoCaixaToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.históricoDoCaixaToolStripMenuItem.Text = "Histórico do Caixa";
            this.históricoDoCaixaToolStripMenuItem.Click += new System.EventHandler(this.históricoDoCaixaToolStripMenuItem_Click);
            this.históricoDoCaixaToolStripMenuItem.MouseLeave += new System.EventHandler(this.históricoDoCaixaToolStripMenuItem_MouseLeave);
            this.históricoDoCaixaToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.históricoDoCaixaToolStripMenuItem_MouseMove);
            // 
            // adicionarObservaçãoToolStripMenuItem
            // 
            this.adicionarObservaçãoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("adicionarObservaçãoToolStripMenuItem.Image")));
            this.adicionarObservaçãoToolStripMenuItem.Name = "adicionarObservaçãoToolStripMenuItem";
            this.adicionarObservaçãoToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.adicionarObservaçãoToolStripMenuItem.Text = "Adicionar Observação";
            this.adicionarObservaçãoToolStripMenuItem.Click += new System.EventHandler(this.adicionarObservaçãoToolStripMenuItem_Click);
            this.adicionarObservaçãoToolStripMenuItem.MouseLeave += new System.EventHandler(this.adicionarObservaçãoToolStripMenuItem_MouseLeave);
            this.adicionarObservaçãoToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.adicionarObservaçãoToolStripMenuItem_MouseMove);
            // 
            // menuNFeNFCeToolStripMenuItem
            // 
            this.menuNFeNFCeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("menuNFeNFCeToolStripMenuItem.Image")));
            this.menuNFeNFCeToolStripMenuItem.Name = "menuNFeNFCeToolStripMenuItem";
            this.menuNFeNFCeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.menuNFeNFCeToolStripMenuItem.Text = "Menu NFe/NFCe";
            this.menuNFeNFCeToolStripMenuItem.Click += new System.EventHandler(this.menuNFeNFCeToolStripMenuItem_Click);
            this.menuNFeNFCeToolStripMenuItem.MouseLeave += new System.EventHandler(this.menuNFeNFCeToolStripMenuItem_MouseLeave);
            this.menuNFeNFCeToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menuNFeNFCeToolStripMenuItem_MouseMove);
            // 
            // panMenuImagem
            // 
            this.panMenuImagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panMenuImagem.BackColor = System.Drawing.Color.LightGray;
            this.panMenuImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panMenuImagem.Controls.Add(this.lblLegendaImagem);
            this.panMenuImagem.Controls.Add(this.lblImagemProduto);
            this.panMenuImagem.Controls.Add(this.pcibImagemProduto);
            this.panMenuImagem.Location = new System.Drawing.Point(16, 357);
            this.panMenuImagem.Name = "panMenuImagem";
            this.panMenuImagem.Size = new System.Drawing.Size(385, 267);
            this.panMenuImagem.TabIndex = 8;
            // 
            // lblLegendaImagem
            // 
            this.lblLegendaImagem.AutoSize = true;
            this.lblLegendaImagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegendaImagem.Location = new System.Drawing.Point(62, 135);
            this.lblLegendaImagem.Name = "lblLegendaImagem";
            this.lblLegendaImagem.Size = new System.Drawing.Size(264, 20);
            this.lblLegendaImagem.TabIndex = 17;
            this.lblLegendaImagem.Text = "Sem imagem para este registro.";
            this.lblLegendaImagem.Visible = false;
            this.lblLegendaImagem.Click += new System.EventHandler(this.lblLegendaImagem_Click);
            this.lblLegendaImagem.MouseLeave += new System.EventHandler(this.lblLegendaImagem_MouseLeave);
            this.lblLegendaImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblLegendaImagem_MouseMove);
            // 
            // lblImagemProduto
            // 
            this.lblImagemProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImagemProduto.Location = new System.Drawing.Point(62, 2);
            this.lblImagemProduto.Name = "lblImagemProduto";
            this.lblImagemProduto.Size = new System.Drawing.Size(278, 20);
            this.lblImagemProduto.TabIndex = 8;
            this.lblImagemProduto.Text = "Imagem do Produto:";
            this.lblImagemProduto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pcibImagemProduto
            // 
            this.pcibImagemProduto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pcibImagemProduto.Location = new System.Drawing.Point(0, 25);
            this.pcibImagemProduto.Name = "pcibImagemProduto";
            this.pcibImagemProduto.Size = new System.Drawing.Size(383, 240);
            this.pcibImagemProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcibImagemProduto.TabIndex = 0;
            this.pcibImagemProduto.TabStop = false;
            this.pcibImagemProduto.Click += new System.EventHandler(this.pcibImagemProduto_Click);
            this.pcibImagemProduto.MouseLeave += new System.EventHandler(this.pcibImagemProduto_MouseLeave);
            this.pcibImagemProduto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibImagemProduto_MouseMove);
            // 
            // sttBarraInf
            // 
            this.sttBarraInf.BackColor = System.Drawing.SystemColors.Control;
            this.sttBarraInf.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sttBarraInf.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblUsuario,
            this.tslblEmpresa,
            this.tslblVersao});
            this.sttBarraInf.Location = new System.Drawing.Point(0, 627);
            this.sttBarraInf.Name = "sttBarraInf";
            this.sttBarraInf.Size = new System.Drawing.Size(1364, 25);
            this.sttBarraInf.TabIndex = 9;
            // 
            // tslblUsuario
            // 
            this.tslblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslblUsuario.Image = ((System.Drawing.Image)(resources.GetObject("tslblUsuario.Image")));
            this.tslblUsuario.Name = "tslblUsuario";
            this.tslblUsuario.Size = new System.Drawing.Size(69, 20);
            this.tslblUsuario.Text = "Usuário";
            this.tslblUsuario.ToolTipText = "Clique para ver informações do usuário que está atualmente logado ao sistema.";
            this.tslblUsuario.Click += new System.EventHandler(this.tslblUsuario_Click);
            this.tslblUsuario.MouseLeave += new System.EventHandler(this.tslblUsuario_MouseLeave);
            this.tslblUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tslblUsuario_MouseMove);
            // 
            // tslblEmpresa
            // 
            this.tslblEmpresa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslblEmpresa.Image = ((System.Drawing.Image)(resources.GetObject("tslblEmpresa.Image")));
            this.tslblEmpresa.Name = "tslblEmpresa";
            this.tslblEmpresa.Size = new System.Drawing.Size(1178, 20);
            this.tslblEmpresa.Spring = true;
            this.tslblEmpresa.Text = "Empresa";
            this.tslblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tslblEmpresa.ToolTipText = "Clique para ver os dados de sua empresa.";
            this.tslblEmpresa.Click += new System.EventHandler(this.tslblEmpresa_Click);
            this.tslblEmpresa.MouseLeave += new System.EventHandler(this.tslblEmpresa_MouseLeave);
            this.tslblEmpresa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tslblEmpresa_MouseMove);
            // 
            // tslblVersao
            // 
            this.tslblVersao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslblVersao.Image = ((System.Drawing.Image)(resources.GetObject("tslblVersao.Image")));
            this.tslblVersao.Name = "tslblVersao";
            this.tslblVersao.Size = new System.Drawing.Size(102, 20);
            this.tslblVersao.Text = "Versão/NPDV";
            this.tslblVersao.ToolTipText = "Clique para ver informações sobre a atual versão deste programa.";
            this.tslblVersao.Click += new System.EventHandler(this.tslblVersao_Click);
            this.tslblVersao.MouseLeave += new System.EventHandler(this.tslblVersao_MouseLeave);
            this.tslblVersao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tslblVersao_MouseMove);
            // 
            // ttpPDV
            // 
            this.ttpPDV.AutoPopDelay = 5000;
            this.ttpPDV.InitialDelay = 1000;
            this.ttpPDV.IsBalloon = true;
            this.ttpPDV.ReshowDelay = 100;
            this.ttpPDV.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpPDV.ToolTipTitle = "Dica:";
            // 
            // prtDocumento
            // 
            this.prtDocumento.DocumentName = "Impressão de Documento, Aguarde...";
            this.prtDocumento.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prtDocumento_PrintPage);
            // 
            // timerTabela
            // 
            this.timerTabela.Interval = 1000;
            this.timerTabela.Tick += new System.EventHandler(this.timerTabela_Tick);
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // TemporizadorVersao
            // 
            this.TemporizadorVersao.Interval = 1000;
            this.TemporizadorVersao.Tick += new System.EventHandler(this.TemporizadorVersao_Tick);
            // 
            // bckwInicio
            // 
            this.bckwInicio.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwInicio_DoWork);
            this.bckwInicio.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwInicio_RunWorkerCompleted);
            // 
            // TemporizadorLogin
            // 
            this.TemporizadorLogin.Interval = 1000;
            this.TemporizadorLogin.Tick += new System.EventHandler(this.TemporizadorLogin_Tick);
            // 
            // FrmSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1364, 652);
            this.Controls.Add(this.sttBarraInf);
            this.Controls.Add(this.panQuantidade);
            this.Controls.Add(this.panTotalProdutos);
            this.Controls.Add(this.panProdutos);
            this.Controls.Add(this.panTabela);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panMenuImagem);
            this.Controls.Add(this.panCabecalho);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema SEVEN - PDV";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSistema_FormClosing);
            this.Load += new System.EventHandler(this.FrmSistema_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSistema_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmSistema_KeyUp);
            this.panCabecalho.ResumeLayout(false);
            this.panTabela.ResumeLayout(false);
            this.panTabela.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            this.panProdutos.ResumeLayout(false);
            this.panProdutos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.panTotalProdutos.ResumeLayout(false);
            this.panQuantidade.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panMenuImagem.ResumeLayout(false);
            this.panMenuImagem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagemProduto)).EndInit();
            this.sttBarraInf.ResumeLayout(false);
            this.sttBarraInf.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panCabecalho;
        private System.Windows.Forms.Panel panTabela;
        private System.Windows.Forms.Panel panProdutos;
        private System.Windows.Forms.Panel panTotalProdutos;
        private System.Windows.Forms.Panel panQuantidade;
        private System.Windows.Forms.DataGridView dtItems;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lblTotalProdutos;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblQuantidadeItem;
        private System.Windows.Forms.Button btnProcurarProd;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.Label lblUnitario;
        private System.Windows.Forms.TextBox txtUnitario;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Panel panMenuImagem;
        private System.Windows.Forms.Label lblImagemProduto;
        private System.Windows.Forms.PictureBox pcibImagemProduto;
        private System.Windows.Forms.ToolStripMenuItem aplicativoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem caporcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quantidadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capturarToolStripMenuItem;
        private System.Windows.Forms.StatusStrip sttBarraInf;
        private System.Windows.Forms.ToolStripStatusLabel tslblUsuario;
        private System.Windows.Forms.ToolStripStatusLabel tslblEmpresa;
        private System.Windows.Forms.ToolStripStatusLabel tslblVersao;
        private System.Windows.Forms.Label lblMensagemTopo;
        private System.Windows.Forms.Button btnAlterarQuantidade;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolTip ttpPDV;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnExcluirItem;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Button btnExcluirCliente;
        private System.Windows.Forms.Label lblLegendaImagem;
        private System.Windows.Forms.ToolStripMenuItem mudarUsuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devolucaoF8ToolStripMenuItem;
        private System.Windows.Forms.Button btnAlterarValorUnitario;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.ToolStripMenuItem outrasOpçõesF12ToolStripMenuItem1;
        private System.Windows.Forms.Label lblTipo;
        private System.Drawing.Printing.PrintDocument prtDocumento;
        private System.Windows.Forms.ToolStripMenuItem sangriaSuprimentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem históricoDoCaixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contasAReceberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirCaixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharCaixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contasAPagarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pausarCaixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adicionarObservaçãoToolStripMenuItem;
        private System.Windows.Forms.Button btnTabela;
        private System.Windows.Forms.Timer timerTabela;
        private System.Windows.Forms.ToolStripMenuItem vendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tstbBarraDaEsquerda;
        private System.Windows.Forms.ToolStripMenuItem orçamentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devoluçõesToolStripMenuItem;
        private System.Windows.Forms.Button btnTipoVenda;
        private System.Windows.Forms.ToolStripMenuItem menuNFeNFCeToolStripMenuItem;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.Label lblContAtiva;
        private System.Windows.Forms.Button btnCalculadora;
        private System.Windows.Forms.ToolStripMenuItem licençaDoAplicativoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarLicençaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aplicarLicençaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem desenvolvedorToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.Timer TemporizadorVersao;
        private System.Windows.Forms.ToolStripMenuItem layoutPDVToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bckwInicio;
        private System.Windows.Forms.Timer TemporizadorLogin;
    }
}

