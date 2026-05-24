namespace Seven_Sistema
{
    partial class FrmSistemaBigPicture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSistemaBigPicture));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ttpPDV = new System.Windows.Forms.ToolTip(this.components);
            this.btnProcurarProd = new System.Windows.Forms.Button();
            this.btnAlterarValorUnitario = new System.Windows.Forms.Button();
            this.btnAlterarQuantidade = new System.Windows.Forms.Button();
            this.pPanel2 = new System.Windows.Forms.Panel();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblValorTotalItem = new System.Windows.Forms.Label();
            this.lblQuantidadeItem = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCabecalhoNota = new System.Windows.Forms.Label();
            this.lblDescCliente = new System.Windows.Forms.Label();
            this.dtItems = new System.Windows.Forms.DataGridView();
            this.lblCabecalhoNota1 = new System.Windows.Forms.Label();
            this.lblTotalProdutos = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.lblUnitario = new System.Windows.Forms.Label();
            this.txtUnitario = new System.Windows.Forms.TextBox();
            this.lblQuant = new System.Windows.Forms.Label();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblValorTotalunit = new System.Windows.Forms.Label();
            this.lblProduto = new System.Windows.Forms.Label();
            this.pPanel1 = new System.Windows.Forms.Panel();
            this.lblCalculadora = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblSair = new System.Windows.Forms.Label();
            this.lblContAtiva = new System.Windows.Forms.Label();
            this.lblAjuda = new System.Windows.Forms.Label();
            this.lblVersao = new System.Windows.Forms.Label();
            this.lblPDV = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblTipoVenda = new System.Windows.Forms.Label();
            this.pPanel3 = new System.Windows.Forms.Panel();
            this.lblData = new System.Windows.Forms.Label();
            this.lblOutros = new System.Windows.Forms.Label();
            this.lblPagamento = new System.Windows.Forms.Label();
            this.lblCancelar = new System.Windows.Forms.Label();
            this.lblConsumidor = new System.Windows.Forms.Label();
            this.lblDevolucao = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.lblOrcamento = new System.Windows.Forms.Label();
            this.lblCapturar = new System.Windows.Forms.Label();
            this.lblMensagemTopo = new System.Windows.Forms.Label();
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.prtDocumento = new System.Drawing.Printing.PrintDocument();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.tData = new System.Windows.Forms.Timer(this.components);
            this.pPanelCaixaLivre = new System.Windows.Forms.Panel();
            this.lblCliquePressione = new System.Windows.Forms.Label();
            this.lblDataCaixaLivre = new System.Windows.Forms.Label();
            this.tInativo = new System.Windows.Forms.Timer(this.components);
            this.pPanelCaixaFechado = new System.Windows.Forms.Panel();
            this.lblCliquePressione2 = new System.Windows.Forms.Label();
            this.lblDataCaixaFechado = new System.Windows.Forms.Label();
            this.TemporizadorVersao = new System.Windows.Forms.Timer(this.components);
            this.bckwInicio = new System.ComponentModel.BackgroundWorker();
            this.TemporizadorLogin = new System.Windows.Forms.Timer(this.components);
            this.pPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtItems)).BeginInit();
            this.pPanel1.SuspendLayout();
            this.pPanel3.SuspendLayout();
            this.pPanelCaixaLivre.SuspendLayout();
            this.pPanelCaixaFechado.SuspendLayout();
            this.SuspendLayout();
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
            // btnProcurarProd
            // 
            this.btnProcurarProd.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarProd.Image")));
            this.btnProcurarProd.Location = new System.Drawing.Point(436, 23);
            this.btnProcurarProd.Name = "btnProcurarProd";
            this.btnProcurarProd.Size = new System.Drawing.Size(65, 44);
            this.btnProcurarProd.TabIndex = 2;
            this.ttpPDV.SetToolTip(this.btnProcurarProd, "Clique para adicionar/pesquisar um item.");
            this.btnProcurarProd.UseVisualStyleBackColor = true;
            this.btnProcurarProd.Click += new System.EventHandler(this.btnProcurarProd_Click);
            this.btnProcurarProd.MouseLeave += new System.EventHandler(this.btnProcurarProd_MouseLeave);
            this.btnProcurarProd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarProd_MouseMove);
            // 
            // btnAlterarValorUnitario
            // 
            this.btnAlterarValorUnitario.Enabled = false;
            this.btnAlterarValorUnitario.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterarValorUnitario.Image")));
            this.btnAlterarValorUnitario.Location = new System.Drawing.Point(436, 93);
            this.btnAlterarValorUnitario.Name = "btnAlterarValorUnitario";
            this.btnAlterarValorUnitario.Size = new System.Drawing.Size(65, 44);
            this.btnAlterarValorUnitario.TabIndex = 6;
            this.btnAlterarValorUnitario.Text = "\r\n\r\n&U";
            this.ttpPDV.SetToolTip(this.btnAlterarValorUnitario, "Clique para alterar o valor unitário do item selecionado.");
            this.btnAlterarValorUnitario.UseVisualStyleBackColor = true;
            this.btnAlterarValorUnitario.Click += new System.EventHandler(this.btnAlterarValorUnitario_Click);
            this.btnAlterarValorUnitario.MouseLeave += new System.EventHandler(this.btnAlterarValorUnitario_MouseLeave);
            this.btnAlterarValorUnitario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterarValorUnitario_MouseMove);
            // 
            // btnAlterarQuantidade
            // 
            this.btnAlterarQuantidade.Enabled = false;
            this.btnAlterarQuantidade.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterarQuantidade.Image")));
            this.btnAlterarQuantidade.Location = new System.Drawing.Point(184, 93);
            this.btnAlterarQuantidade.Name = "btnAlterarQuantidade";
            this.btnAlterarQuantidade.Size = new System.Drawing.Size(65, 44);
            this.btnAlterarQuantidade.TabIndex = 4;
            this.btnAlterarQuantidade.Text = "\r\n\r\n&Q\r\n";
            this.ttpPDV.SetToolTip(this.btnAlterarQuantidade, "Clique para alterar a quantidade do item selecionado.");
            this.btnAlterarQuantidade.UseVisualStyleBackColor = true;
            this.btnAlterarQuantidade.Click += new System.EventHandler(this.btnAlterarQuantidade_Click);
            this.btnAlterarQuantidade.MouseLeave += new System.EventHandler(this.btnAlterarQuantidade_MouseLeave);
            this.btnAlterarQuantidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterarQuantidade_MouseMove);
            // 
            // pPanel2
            // 
            this.pPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pPanel2.Controls.Add(this.lblItem);
            this.pPanel2.Controls.Add(this.lblValorTotalItem);
            this.pPanel2.Controls.Add(this.lblQuantidadeItem);
            this.pPanel2.Controls.Add(this.panel1);
            this.pPanel2.Controls.Add(this.lblTotalProdutos);
            this.pPanel2.Controls.Add(this.btnAlterarValorUnitario);
            this.pPanel2.Controls.Add(this.btnAlterarQuantidade);
            this.pPanel2.Controls.Add(this.txtQuantidade);
            this.pPanel2.Controls.Add(this.lblUnitario);
            this.pPanel2.Controls.Add(this.txtUnitario);
            this.pPanel2.Controls.Add(this.lblQuant);
            this.pPanel2.Controls.Add(this.btnProcurarProd);
            this.pPanel2.Controls.Add(this.txtProduto);
            this.pPanel2.Controls.Add(this.lblValorTotal);
            this.pPanel2.Controls.Add(this.lblValorTotalunit);
            this.pPanel2.Controls.Add(this.lblProduto);
            this.pPanel2.Location = new System.Drawing.Point(12, 206);
            this.pPanel2.Name = "pPanel2";
            this.pPanel2.Size = new System.Drawing.Size(1240, 379);
            this.pPanel2.TabIndex = 0;
            this.pPanel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pPanel2_MouseMove);
            // 
            // lblItem
            // 
            this.lblItem.Enabled = false;
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblItem.Location = new System.Drawing.Point(259, 140);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(61, 24);
            this.lblItem.TabIndex = 0;
            this.lblItem.Text = "Itens:";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorTotalItem
            // 
            this.lblValorTotalItem.AutoSize = true;
            this.lblValorTotalItem.Enabled = false;
            this.lblValorTotalItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalItem.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotalItem.Location = new System.Drawing.Point(3, 140);
            this.lblValorTotalItem.Name = "lblValorTotalItem";
            this.lblValorTotalItem.Size = new System.Drawing.Size(207, 20);
            this.lblValorTotalItem.TabIndex = 0;
            this.lblValorTotalItem.Text = "Valor Total do Item (R$):";
            // 
            // lblQuantidadeItem
            // 
            this.lblQuantidadeItem.Enabled = false;
            this.lblQuantidadeItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.lblQuantidadeItem.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblQuantidadeItem.Location = new System.Drawing.Point(263, 157);
            this.lblQuantidadeItem.Name = "lblQuantidadeItem";
            this.lblQuantidadeItem.Size = new System.Drawing.Size(238, 66);
            this.lblQuantidadeItem.TabIndex = 0;
            this.lblQuantidadeItem.Text = "0";
            this.lblQuantidadeItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQuantidadeItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblQuantidadeItem_MouseMove);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblCabecalhoNota);
            this.panel1.Controls.Add(this.lblDescCliente);
            this.panel1.Controls.Add(this.dtItems);
            this.panel1.Controls.Add(this.lblCabecalhoNota1);
            this.panel1.Location = new System.Drawing.Point(507, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 353);
            this.panel1.TabIndex = 49;
            // 
            // lblCabecalhoNota
            // 
            this.lblCabecalhoNota.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCabecalhoNota.BackColor = System.Drawing.Color.PapayaWhip;
            this.lblCabecalhoNota.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblCabecalhoNota.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecalhoNota.Location = new System.Drawing.Point(3, 4);
            this.lblCabecalhoNota.Name = "lblCabecalhoNota";
            this.lblCabecalhoNota.Size = new System.Drawing.Size(724, 77);
            this.lblCabecalhoNota.TabIndex = 0;
            this.lblCabecalhoNota.Text = "-------------------------------------------\r\n  ** NFe **\r\n-----------------------" +
    "--------------------";
            this.lblCabecalhoNota.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCabecalhoNota.UseMnemonic = false;
            this.lblCabecalhoNota.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblCabecalhoNota_MouseMove);
            // 
            // lblDescCliente
            // 
            this.lblDescCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescCliente.BackColor = System.Drawing.Color.PapayaWhip;
            this.lblDescCliente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblDescCliente.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescCliente.Location = new System.Drawing.Point(3, 81);
            this.lblDescCliente.Name = "lblDescCliente";
            this.lblDescCliente.Size = new System.Drawing.Size(724, 52);
            this.lblDescCliente.TabIndex = 0;
            this.lblDescCliente.Text = "Consumidor: Não Identificado.";
            this.lblDescCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDescCliente.UseMnemonic = false;
            this.lblDescCliente.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblDescCliente_MouseMove);
            // 
            // dtItems
            // 
            this.dtItems.AllowUserToAddRows = false;
            this.dtItems.AllowUserToDeleteRows = false;
            this.dtItems.AllowUserToResizeColumns = false;
            this.dtItems.AllowUserToResizeRows = false;
            this.dtItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtItems.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.dtItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtItems.ColumnHeadersHeight = 29;
            this.dtItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtItems.ColumnHeadersVisible = false;
            this.dtItems.Cursor = System.Windows.Forms.Cursors.IBeam;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PapayaWhip;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtItems.EnableHeadersVisualStyles = false;
            this.dtItems.GridColor = System.Drawing.Color.PapayaWhip;
            this.dtItems.Location = new System.Drawing.Point(2, 179);
            this.dtItems.MultiSelect = false;
            this.dtItems.Name = "dtItems";
            this.dtItems.ReadOnly = true;
            this.dtItems.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtItems.RowHeadersVisible = false;
            this.dtItems.RowHeadersWidth = 51;
            this.dtItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtItems.ShowCellErrors = false;
            this.dtItems.ShowCellToolTips = false;
            this.dtItems.ShowEditingIcon = false;
            this.dtItems.ShowRowErrors = false;
            this.dtItems.Size = new System.Drawing.Size(725, 171);
            this.dtItems.StandardTab = true;
            this.dtItems.TabIndex = 7;
            this.dtItems.DataSourceChanged += new System.EventHandler(this.dtItems_DataSourceChanged);
            this.dtItems.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtItems_CellEnter);
            this.dtItems.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtItems_RowsAdded);
            this.dtItems.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtItems_KeyUp);
            this.dtItems.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtItems_MouseMove);
            // 
            // lblCabecalhoNota1
            // 
            this.lblCabecalhoNota1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCabecalhoNota1.BackColor = System.Drawing.Color.PapayaWhip;
            this.lblCabecalhoNota1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblCabecalhoNota1.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCabecalhoNota1.Location = new System.Drawing.Point(3, 119);
            this.lblCabecalhoNota1.Name = "lblCabecalhoNota1";
            this.lblCabecalhoNota1.Size = new System.Drawing.Size(724, 230);
            this.lblCabecalhoNota1.TabIndex = 0;
            this.lblCabecalhoNota1.Text = "-------------------------------------------\r\n# Cód  Descrição   Qtde Un Vl.Unit V" +
    "l.Total";
            this.lblCabecalhoNota1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCabecalhoNota1.UseMnemonic = false;
            this.lblCabecalhoNota1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblCabecalhoNota1_MouseMove);
            // 
            // lblTotalProdutos
            // 
            this.lblTotalProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalProdutos.Enabled = false;
            this.lblTotalProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProdutos.Location = new System.Drawing.Point(3, 221);
            this.lblTotalProdutos.Name = "lblTotalProdutos";
            this.lblTotalProdutos.Size = new System.Drawing.Size(317, 32);
            this.lblTotalProdutos.TabIndex = 0;
            this.lblTotalProdutos.Text = "Valor Total dos produtos (R$):";
            this.lblTotalProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BackColor = System.Drawing.Color.White;
            this.txtQuantidade.Enabled = false;
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.Location = new System.Drawing.Point(3, 93);
            this.txtQuantidade.MaxLength = 10;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(175, 44);
            this.txtQuantidade.TabIndex = 3;
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantidade.Enter += new System.EventHandler(this.txtQuantidade_Enter);
            this.txtQuantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuantidade_KeyDown);
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            this.txtQuantidade.Leave += new System.EventHandler(this.txtQuantidade_Leave);
            // 
            // lblUnitario
            // 
            this.lblUnitario.AutoSize = true;
            this.lblUnitario.Enabled = false;
            this.lblUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitario.ForeColor = System.Drawing.Color.Black;
            this.lblUnitario.Location = new System.Drawing.Point(251, 70);
            this.lblUnitario.Name = "lblUnitario";
            this.lblUnitario.Size = new System.Drawing.Size(164, 20);
            this.lblUnitario.TabIndex = 0;
            this.lblUnitario.Text = "Valor Unitário (R$):";
            // 
            // txtUnitario
            // 
            this.txtUnitario.BackColor = System.Drawing.Color.White;
            this.txtUnitario.Enabled = false;
            this.txtUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnitario.Location = new System.Drawing.Point(255, 93);
            this.txtUnitario.MaxLength = 10;
            this.txtUnitario.Name = "txtUnitario";
            this.txtUnitario.Size = new System.Drawing.Size(175, 44);
            this.txtUnitario.TabIndex = 5;
            this.txtUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnitario.Enter += new System.EventHandler(this.txtUnitario_Enter);
            this.txtUnitario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUnitario_KeyDown);
            this.txtUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnitario_KeyPress);
            this.txtUnitario.Leave += new System.EventHandler(this.txtUnitario_Leave);
            // 
            // lblQuant
            // 
            this.lblQuant.AutoSize = true;
            this.lblQuant.Enabled = false;
            this.lblQuant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuant.ForeColor = System.Drawing.Color.Black;
            this.lblQuant.Location = new System.Drawing.Point(3, 70);
            this.lblQuant.Name = "lblQuant";
            this.lblQuant.Size = new System.Drawing.Size(107, 20);
            this.lblQuant.TabIndex = 0;
            this.lblQuant.Text = "Quantidade:";
            // 
            // txtProduto
            // 
            this.txtProduto.BackColor = System.Drawing.Color.White;
            this.txtProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduto.Location = new System.Drawing.Point(-10, 23);
            this.txtProduto.MaxLength = 60;
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(440, 44);
            this.txtProduto.TabIndex = 1;
            this.txtProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtProduto.Enter += new System.EventHandler(this.txtProduto_Enter);
            this.txtProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProduto_KeyDown);
            this.txtProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduto_KeyPress);
            this.txtProduto.Leave += new System.EventHandler(this.txtProduto_Leave);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblValorTotal.Enabled = false;
            this.lblValorTotal.Font = new System.Drawing.Font("Calibri", 81.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblValorTotal.Location = new System.Drawing.Point(-16, 253);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(530, 125);
            this.lblValorTotal.TabIndex = 0;
            this.lblValorTotal.Text = "0,00";
            this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValorTotal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotal_MouseMove);
            // 
            // lblValorTotalunit
            // 
            this.lblValorTotalunit.Enabled = false;
            this.lblValorTotalunit.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalunit.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblValorTotalunit.Location = new System.Drawing.Point(3, 157);
            this.lblValorTotalunit.Name = "lblValorTotalunit";
            this.lblValorTotalunit.Size = new System.Drawing.Size(254, 66);
            this.lblValorTotalunit.TabIndex = 0;
            this.lblValorTotalunit.Text = "0,00";
            this.lblValorTotalunit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValorTotalunit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotalunit_MouseMove);
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(3, 0);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(77, 20);
            this.lblProduto.TabIndex = 0;
            this.lblProduto.Text = "Produto:";
            // 
            // pPanel1
            // 
            this.pPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pPanel1.BackColor = System.Drawing.Color.DimGray;
            this.pPanel1.Controls.Add(this.lblCalculadora);
            this.pPanel1.Controls.Add(this.lblUsuario);
            this.pPanel1.Controls.Add(this.lblSair);
            this.pPanel1.Controls.Add(this.lblContAtiva);
            this.pPanel1.Controls.Add(this.lblAjuda);
            this.pPanel1.Controls.Add(this.lblVersao);
            this.pPanel1.Controls.Add(this.lblPDV);
            this.pPanel1.Controls.Add(this.lblEmpresa);
            this.pPanel1.Controls.Add(this.lblTipoVenda);
            this.pPanel1.Location = new System.Drawing.Point(-3, -11);
            this.pPanel1.Name = "pPanel1";
            this.pPanel1.Size = new System.Drawing.Size(1308, 90);
            this.pPanel1.TabIndex = 2;
            this.pPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pPanel1_MouseMove);
            // 
            // lblCalculadora
            // 
            this.lblCalculadora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCalculadora.AutoSize = true;
            this.lblCalculadora.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCalculadora.ForeColor = System.Drawing.Color.White;
            this.lblCalculadora.Location = new System.Drawing.Point(815, 20);
            this.lblCalculadora.Name = "lblCalculadora";
            this.lblCalculadora.Size = new System.Drawing.Size(151, 18);
            this.lblCalculadora.TabIndex = 1;
            this.lblCalculadora.Text = "[ F10 ] Calculadora";
            this.lblCalculadora.Click += new System.EventHandler(this.label1_Click_1);
            this.lblCalculadora.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.lblCalculadora.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(18, 50);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(67, 18);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.Click += new System.EventHandler(this.lblUsuario_Click);
            this.lblUsuario.MouseLeave += new System.EventHandler(this.lblUsuario_MouseLeave);
            this.lblUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblUsuario_MouseMove);
            // 
            // lblSair
            // 
            this.lblSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSair.AutoSize = true;
            this.lblSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSair.ForeColor = System.Drawing.Color.White;
            this.lblSair.Location = new System.Drawing.Point(1163, 20);
            this.lblSair.Name = "lblSair";
            this.lblSair.Size = new System.Drawing.Size(92, 18);
            this.lblSair.TabIndex = 0;
            this.lblSair.Text = "[ Esc ] Sair";
            this.lblSair.Click += new System.EventHandler(this.lblSair_Click);
            this.lblSair.MouseLeave += new System.EventHandler(this.lblSair_MouseLeave);
            this.lblSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblSair_MouseMove);
            // 
            // lblContAtiva
            // 
            this.lblContAtiva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContAtiva.AutoSize = true;
            this.lblContAtiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblContAtiva.ForeColor = System.Drawing.Color.Red;
            this.lblContAtiva.Location = new System.Drawing.Point(1119, 68);
            this.lblContAtiva.Name = "lblContAtiva";
            this.lblContAtiva.Size = new System.Drawing.Size(136, 16);
            this.lblContAtiva.TabIndex = 0;
            this.lblContAtiva.Text = "Contingência Ativa";
            this.lblContAtiva.Visible = false;
            // 
            // lblAjuda
            // 
            this.lblAjuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAjuda.AutoSize = true;
            this.lblAjuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAjuda.ForeColor = System.Drawing.Color.White;
            this.lblAjuda.Location = new System.Drawing.Point(716, 20);
            this.lblAjuda.Name = "lblAjuda";
            this.lblAjuda.Size = new System.Drawing.Size(93, 18);
            this.lblAjuda.TabIndex = 0;
            this.lblAjuda.Text = "[ F1 ] Ajuda";
            this.lblAjuda.Click += new System.EventHandler(this.lblAjuda_Click);
            this.lblAjuda.MouseLeave += new System.EventHandler(this.lblAjuda_MouseLeave);
            this.lblAjuda.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblAjuda_MouseMove);
            // 
            // lblVersao
            // 
            this.lblVersao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersao.AutoSize = true;
            this.lblVersao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersao.ForeColor = System.Drawing.Color.White;
            this.lblVersao.Location = new System.Drawing.Point(18, 68);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(111, 18);
            this.lblVersao.TabIndex = 0;
            this.lblVersao.Text = "Versao/NPDV";
            this.lblVersao.Click += new System.EventHandler(this.lblVersao_Click);
            this.lblVersao.MouseLeave += new System.EventHandler(this.lblVersao_MouseLeave);
            this.lblVersao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblVersao_MouseMove);
            // 
            // lblPDV
            // 
            this.lblPDV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPDV.AutoSize = true;
            this.lblPDV.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPDV.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblPDV.Location = new System.Drawing.Point(11, 10);
            this.lblPDV.Name = "lblPDV";
            this.lblPDV.Size = new System.Drawing.Size(79, 42);
            this.lblPDV.TabIndex = 0;
            this.lblPDV.Text = "PDV";
            this.lblPDV.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblPDV_MouseMove);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.ForeColor = System.Drawing.Color.White;
            this.lblEmpresa.Location = new System.Drawing.Point(15, 41);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(1240, 33);
            this.lblEmpresa.TabIndex = 0;
            this.lblEmpresa.Text = "Empresa";
            this.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmpresa.Click += new System.EventHandler(this.lblEmpresa_Click);
            // 
            // lblTipoVenda
            // 
            this.lblTipoVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTipoVenda.AutoSize = true;
            this.lblTipoVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoVenda.ForeColor = System.Drawing.Color.White;
            this.lblTipoVenda.Location = new System.Drawing.Point(972, 20);
            this.lblTipoVenda.Name = "lblTipoVenda";
            this.lblTipoVenda.Size = new System.Drawing.Size(185, 18);
            this.lblTipoVenda.TabIndex = 0;
            this.lblTipoVenda.Text = "[ Home ] Tipo de Venda";
            this.lblTipoVenda.Click += new System.EventHandler(this.lblTipoVenda_Click);
            this.lblTipoVenda.MouseLeave += new System.EventHandler(this.lblTipoVenda_MouseLeave);
            this.lblTipoVenda.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTipoVenda_MouseMove);
            // 
            // pPanel3
            // 
            this.pPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPanel3.Controls.Add(this.lblData);
            this.pPanel3.Controls.Add(this.lblOutros);
            this.pPanel3.Controls.Add(this.lblPagamento);
            this.pPanel3.Controls.Add(this.lblCancelar);
            this.pPanel3.Controls.Add(this.lblConsumidor);
            this.pPanel3.Controls.Add(this.lblDevolucao);
            this.pPanel3.Controls.Add(this.lblQuantidade);
            this.pPanel3.Controls.Add(this.lblOrcamento);
            this.pPanel3.Controls.Add(this.lblCapturar);
            this.pPanel3.Location = new System.Drawing.Point(-3, 591);
            this.pPanel3.Name = "pPanel3";
            this.pPanel3.Size = new System.Drawing.Size(1267, 100);
            this.pPanel3.TabIndex = 5;
            this.pPanel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pPanel3_MouseMove);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblData.Location = new System.Drawing.Point(3, 5);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(48, 20);
            this.lblData.TabIndex = 0;
            this.lblData.Text = "Data";
            this.lblData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblData_MouseMove);
            // 
            // lblOutros
            // 
            this.lblOutros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOutros.AutoSize = true;
            this.lblOutros.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblOutros.Location = new System.Drawing.Point(867, 34);
            this.lblOutros.Name = "lblOutros";
            this.lblOutros.Size = new System.Drawing.Size(158, 29);
            this.lblOutros.TabIndex = 0;
            this.lblOutros.Text = "[ F9 ] Outros";
            this.lblOutros.Click += new System.EventHandler(this.lblOutros_Click);
            this.lblOutros.MouseLeave += new System.EventHandler(this.lblOutros_MouseLeave);
            this.lblOutros.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblOutros_MouseMove);
            // 
            // lblPagamento
            // 
            this.lblPagamento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPagamento.AutoSize = true;
            this.lblPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagamento.Location = new System.Drawing.Point(215, 5);
            this.lblPagamento.Name = "lblPagamento";
            this.lblPagamento.Size = new System.Drawing.Size(212, 29);
            this.lblPagamento.TabIndex = 0;
            this.lblPagamento.Text = "[ F2 ] Pagamento";
            this.lblPagamento.Click += new System.EventHandler(this.lblPagamento_Click);
            this.lblPagamento.MouseLeave += new System.EventHandler(this.lblPagamento_MouseLeave);
            this.lblPagamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblPagamento_MouseMove);
            // 
            // lblCancelar
            // 
            this.lblCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCancelar.AutoSize = true;
            this.lblCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblCancelar.Location = new System.Drawing.Point(868, 5);
            this.lblCancelar.Name = "lblCancelar";
            this.lblCancelar.Size = new System.Drawing.Size(184, 29);
            this.lblCancelar.TabIndex = 0;
            this.lblCancelar.Text = "[ F5 ] Cancelar";
            this.lblCancelar.Click += new System.EventHandler(this.lblCancelar_Click);
            this.lblCancelar.MouseLeave += new System.EventHandler(this.lblCancelar_MouseLeave);
            this.lblCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblCancelar_MouseMove);
            // 
            // lblConsumidor
            // 
            this.lblConsumidor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblConsumidor.AutoSize = true;
            this.lblConsumidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblConsumidor.Location = new System.Drawing.Point(215, 34);
            this.lblConsumidor.Name = "lblConsumidor";
            this.lblConsumidor.Size = new System.Drawing.Size(221, 29);
            this.lblConsumidor.TabIndex = 0;
            this.lblConsumidor.Text = "[ F6 ] Consumidor";
            this.lblConsumidor.Click += new System.EventHandler(this.lblConsumidor_Click);
            this.lblConsumidor.MouseLeave += new System.EventHandler(this.lblConsumidor_MouseLeave);
            this.lblConsumidor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblConsumidor_MouseMove);
            // 
            // lblDevolucao
            // 
            this.lblDevolucao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDevolucao.AutoSize = true;
            this.lblDevolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblDevolucao.Location = new System.Drawing.Point(646, 34);
            this.lblDevolucao.Name = "lblDevolucao";
            this.lblDevolucao.Size = new System.Drawing.Size(203, 29);
            this.lblDevolucao.TabIndex = 0;
            this.lblDevolucao.Text = "[ F8 ] Devolução";
            this.lblDevolucao.Click += new System.EventHandler(this.lblDevolucao_Click);
            this.lblDevolucao.MouseLeave += new System.EventHandler(this.lblDevolucao_MouseLeave);
            this.lblDevolucao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblDevolucao_MouseMove);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblQuantidade.Location = new System.Drawing.Point(647, 5);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(215, 29);
            this.lblQuantidade.TabIndex = 0;
            this.lblQuantidade.Text = "[ F4 ] Quantidade";
            this.lblQuantidade.Click += new System.EventHandler(this.lblQuantidade_Click);
            this.lblQuantidade.MouseLeave += new System.EventHandler(this.lblQuantidade_MouseLeave);
            this.lblQuantidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblQuantidade_MouseMove);
            // 
            // lblOrcamento
            // 
            this.lblOrcamento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrcamento.AutoSize = true;
            this.lblOrcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblOrcamento.Location = new System.Drawing.Point(433, 5);
            this.lblOrcamento.Name = "lblOrcamento";
            this.lblOrcamento.Size = new System.Drawing.Size(208, 29);
            this.lblOrcamento.TabIndex = 0;
            this.lblOrcamento.Text = "[ F3 ] Orçamento";
            this.lblOrcamento.Click += new System.EventHandler(this.lblOrcamento_Click);
            this.lblOrcamento.MouseLeave += new System.EventHandler(this.lblOrcamento_MouseLeave);
            this.lblOrcamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblOrcamento_MouseMove);
            // 
            // lblCapturar
            // 
            this.lblCapturar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCapturar.AutoSize = true;
            this.lblCapturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblCapturar.Location = new System.Drawing.Point(432, 34);
            this.lblCapturar.Name = "lblCapturar";
            this.lblCapturar.Size = new System.Drawing.Size(180, 29);
            this.lblCapturar.TabIndex = 0;
            this.lblCapturar.Text = "[ F7 ] Capturar";
            this.lblCapturar.Click += new System.EventHandler(this.lblCapturar_Click);
            this.lblCapturar.MouseLeave += new System.EventHandler(this.lblCapturar_MouseLeave);
            this.lblCapturar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblCapturar_MouseMove);
            // 
            // lblMensagemTopo
            // 
            this.lblMensagemTopo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensagemTopo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagemTopo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMensagemTopo.Location = new System.Drawing.Point(12, 78);
            this.lblMensagemTopo.Name = "lblMensagemTopo";
            this.lblMensagemTopo.Size = new System.Drawing.Size(1240, 198);
            this.lblMensagemTopo.TabIndex = 46;
            this.lblMensagemTopo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblMensagemTopo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblMensagemTopo_MouseMove);
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // prtDocumento
            // 
            this.prtDocumento.DocumentName = "Impressão de Documento, Aguarde...";
            this.prtDocumento.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prtDocumento_PrintPage);
            // 
            // lblProgresso
            // 
            this.lblProgresso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft PhagsPa", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(12, 78);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(1240, 128);
            this.lblProgresso.TabIndex = 0;
            this.lblProgresso.Text = "Transmitindo, por favor, aguarde...";
            this.lblProgresso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProgresso.Visible = false;
            // 
            // tData
            // 
            this.tData.Interval = 1000;
            this.tData.Tick += new System.EventHandler(this.tData_Tick);
            // 
            // pPanelCaixaLivre
            // 
            this.pPanelCaixaLivre.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pPanelCaixaLivre.BackgroundImage")));
            this.pPanelCaixaLivre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pPanelCaixaLivre.Controls.Add(this.lblCliquePressione);
            this.pPanelCaixaLivre.Controls.Add(this.lblDataCaixaLivre);
            this.pPanelCaixaLivre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPanelCaixaLivre.Location = new System.Drawing.Point(0, 0);
            this.pPanelCaixaLivre.Name = "pPanelCaixaLivre";
            this.pPanelCaixaLivre.Size = new System.Drawing.Size(1264, 681);
            this.pPanelCaixaLivre.TabIndex = 0;
            this.pPanelCaixaLivre.VisibleChanged += new System.EventHandler(this.pPanelProtetorTela_VisibleChanged);
            this.pPanelCaixaLivre.Click += new System.EventHandler(this.pPanelProtetorTela_Click);
            this.pPanelCaixaLivre.DoubleClick += new System.EventHandler(this.pPanelProtetorTela_DoubleClick);
            // 
            // lblCliquePressione
            // 
            this.lblCliquePressione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCliquePressione.BackColor = System.Drawing.Color.Transparent;
            this.lblCliquePressione.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliquePressione.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCliquePressione.Location = new System.Drawing.Point(9, 580);
            this.lblCliquePressione.Name = "lblCliquePressione";
            this.lblCliquePressione.Size = new System.Drawing.Size(1240, 38);
            this.lblCliquePressione.TabIndex = 2;
            this.lblCliquePressione.Text = "Clique ou pressione qualquer tecla para continuar.";
            this.lblCliquePressione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCliquePressione.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblDataCaixaLivre
            // 
            this.lblDataCaixaLivre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataCaixaLivre.BackColor = System.Drawing.Color.Transparent;
            this.lblDataCaixaLivre.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataCaixaLivre.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDataCaixaLivre.Location = new System.Drawing.Point(12, 617);
            this.lblDataCaixaLivre.Name = "lblDataCaixaLivre";
            this.lblDataCaixaLivre.Size = new System.Drawing.Size(1240, 38);
            this.lblDataCaixaLivre.TabIndex = 0;
            this.lblDataCaixaLivre.Text = "Data";
            this.lblDataCaixaLivre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDataCaixaLivre.Click += new System.EventHandler(this.lblDataCaixaLivre_Click);
            // 
            // tInativo
            // 
            this.tInativo.Interval = 1000;
            this.tInativo.Tick += new System.EventHandler(this.tInativo_Tick);
            // 
            // pPanelCaixaFechado
            // 
            this.pPanelCaixaFechado.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pPanelCaixaFechado.BackgroundImage")));
            this.pPanelCaixaFechado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pPanelCaixaFechado.Controls.Add(this.lblCliquePressione2);
            this.pPanelCaixaFechado.Controls.Add(this.lblDataCaixaFechado);
            this.pPanelCaixaFechado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPanelCaixaFechado.Location = new System.Drawing.Point(0, 0);
            this.pPanelCaixaFechado.Name = "pPanelCaixaFechado";
            this.pPanelCaixaFechado.Size = new System.Drawing.Size(1264, 681);
            this.pPanelCaixaFechado.TabIndex = 0;
            this.pPanelCaixaFechado.VisibleChanged += new System.EventHandler(this.pPanelCaixaFechado_VisibleChanged);
            this.pPanelCaixaFechado.Click += new System.EventHandler(this.pPanelCaixaFechado_Click);
            this.pPanelCaixaFechado.DoubleClick += new System.EventHandler(this.pPanelCaixaFechado_DoubleClick);
            // 
            // lblCliquePressione2
            // 
            this.lblCliquePressione2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCliquePressione2.BackColor = System.Drawing.Color.Transparent;
            this.lblCliquePressione2.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliquePressione2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCliquePressione2.Location = new System.Drawing.Point(12, 579);
            this.lblCliquePressione2.Name = "lblCliquePressione2";
            this.lblCliquePressione2.Size = new System.Drawing.Size(1240, 38);
            this.lblCliquePressione2.TabIndex = 1;
            this.lblCliquePressione2.Text = "Clique ou pressione qualquer tecla para continuar.";
            this.lblCliquePressione2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCliquePressione2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblDataCaixaFechado
            // 
            this.lblDataCaixaFechado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataCaixaFechado.BackColor = System.Drawing.Color.Transparent;
            this.lblDataCaixaFechado.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataCaixaFechado.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDataCaixaFechado.Location = new System.Drawing.Point(12, 617);
            this.lblDataCaixaFechado.Name = "lblDataCaixaFechado";
            this.lblDataCaixaFechado.Size = new System.Drawing.Size(1240, 38);
            this.lblDataCaixaFechado.TabIndex = 0;
            this.lblDataCaixaFechado.Text = "Data";
            this.lblDataCaixaFechado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDataCaixaFechado.Click += new System.EventHandler(this.lblDataCaixaFechado_Click);
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
            // FrmSistemaBigPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pPanel2);
            this.Controls.Add(this.pPanel3);
            this.Controls.Add(this.pPanel1);
            this.Controls.Add(this.lblProgresso);
            this.Controls.Add(this.lblMensagemTopo);
            this.Controls.Add(this.pPanelCaixaLivre);
            this.Controls.Add(this.pPanelCaixaFechado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSistemaBigPicture";
            this.Text = "Sistema SEVEN - PDV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSistemaBigPicture_FormClosing);
            this.Load += new System.EventHandler(this.FrmPesqPDVCaixa_Load);
            this.EnabledChanged += new System.EventHandler(this.FrmSistemaBigPicture_EnabledChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSistemaBigPicture_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmSistemaBigPicture_KeyUp);
            this.pPanel2.ResumeLayout(false);
            this.pPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtItems)).EndInit();
            this.pPanel1.ResumeLayout(false);
            this.pPanel1.PerformLayout();
            this.pPanel3.ResumeLayout(false);
            this.pPanel3.PerformLayout();
            this.pPanelCaixaLivre.ResumeLayout(false);
            this.pPanelCaixaFechado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttpPDV;
        private System.Windows.Forms.Panel pPanel2;
        private System.Windows.Forms.Panel pPanel1;
        private System.Windows.Forms.Panel pPanel3;
        private System.Windows.Forms.Label lblOutros;
        private System.Windows.Forms.Label lblPagamento;
        private System.Windows.Forms.Label lblCancelar;
        private System.Windows.Forms.Label lblConsumidor;
        private System.Windows.Forms.Label lblDevolucao;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label lblOrcamento;
        private System.Windows.Forms.Label lblCapturar;
        private System.Windows.Forms.Label lblPDV;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnProcurarProd;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.Button btnAlterarValorUnitario;
        private System.Windows.Forms.Button btnAlterarQuantidade;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblUnitario;
        private System.Windows.Forms.TextBox txtUnitario;
        private System.Windows.Forms.Label lblQuant;
        private System.Windows.Forms.Label lblTotalProdutos;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblQuantidadeItem;
        private System.Windows.Forms.Label lblMensagemTopo;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblAjuda;
        private System.Windows.Forms.Label lblSair;
        private System.Windows.Forms.Label lblContAtiva;
        private System.Windows.Forms.Label lblTipoVenda;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.Label lblCabecalhoNota;
        private System.Windows.Forms.DataGridView dtItems;
        private System.Drawing.Printing.PrintDocument prtDocumento;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.Label lblDescCliente;
        private System.Windows.Forms.Label lblCabecalhoNota1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblValorTotalunit;
        private System.Windows.Forms.Label lblValorTotalItem;
        private System.Windows.Forms.Timer tData;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Panel pPanelCaixaLivre;
        private System.Windows.Forms.Label lblDataCaixaLivre;
        private System.Windows.Forms.Timer tInativo;
        private System.Windows.Forms.Panel pPanelCaixaFechado;
        private System.Windows.Forms.Label lblDataCaixaFechado;
        private System.Windows.Forms.Label lblCliquePressione2;
        private System.Windows.Forms.Timer TemporizadorVersao;
        private System.Windows.Forms.Label lblCliquePressione;
        private System.Windows.Forms.Label lblCalculadora;
        private System.ComponentModel.BackgroundWorker bckwInicio;
        private System.Windows.Forms.Timer TemporizadorLogin;
    }
}