namespace Seven_Sistema
{
    partial class FrmPrecificarItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrecificarItems));
            this.dtItens = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblUltCustoUnit = new System.Windows.Forms.Label();
            this.txtUltCusto = new System.Windows.Forms.TextBox();
            this.lblPrecoAtual = new System.Windows.Forms.Label();
            this.txtPrecoAtual = new System.Windows.Forms.TextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNovoPreco = new System.Windows.Forms.TextBox();
            this.lblNovoPreco = new System.Windows.Forms.Label();
            this.txtMargem = new System.Windows.Forms.TextBox();
            this.lblMargem = new System.Windows.Forms.Label();
            this.lblCustoUnitario = new System.Windows.Forms.Label();
            this.txtCustoUnitario = new System.Windows.Forms.TextBox();
            this.lblPreco = new System.Windows.Forms.Label();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.lblCustoTotal = new System.Windows.Forms.Label();
            this.txtCustoTotal = new System.Windows.Forms.TextBox();
            this.lblNome_Desc = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblValorSituacao = new System.Windows.Forms.Label();
            this.lblCxSituacao = new System.Windows.Forms.Label();
            this.ttpPrecificar = new System.Windows.Forms.ToolTip(this.components);
            this.btnLimpar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtItens)).BeginInit();
            this.grbBox1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtItens
            // 
            this.dtItens.AllowUserToAddRows = false;
            this.dtItens.AllowUserToDeleteRows = false;
            this.dtItens.AllowUserToResizeRows = false;
            this.dtItens.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtItens.Enabled = false;
            this.dtItens.Location = new System.Drawing.Point(12, 25);
            this.dtItens.MultiSelect = false;
            this.dtItens.Name = "dtItens";
            this.dtItens.ReadOnly = true;
            this.dtItens.RowHeadersVisible = false;
            this.dtItens.RowHeadersWidth = 51;
            this.dtItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtItens.ShowCellErrors = false;
            this.dtItens.ShowCellToolTips = false;
            this.dtItens.ShowEditingIcon = false;
            this.dtItens.ShowRowErrors = false;
            this.dtItens.Size = new System.Drawing.Size(760, 238);
            this.dtItens.TabIndex = 1;
            this.dtItens.TabStop = false;
            this.dtItens.DataSourceChanged += new System.EventHandler(this.dtItens_DataSourceChanged);
            this.dtItens.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtItens_CellEnter);
            this.dtItens.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtItens_CellFormatting);
            this.dtItens.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtItens_RowsAdded);
            this.dtItens.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtItens_RowsRemoved);
            this.dtItens.MouseLeave += new System.EventHandler(this.dtItens_MouseLeave);
            this.dtItens.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtItens_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblUltCustoUnit);
            this.grbBox1.Controls.Add(this.txtUltCusto);
            this.grbBox1.Controls.Add(this.lblPrecoAtual);
            this.grbBox1.Controls.Add(this.txtPrecoAtual);
            this.grbBox1.Controls.Add(this.lblQuantidade);
            this.grbBox1.Controls.Add(this.txtQuantidade);
            this.grbBox1.Controls.Add(this.groupBox1);
            this.grbBox1.Controls.Add(this.lblCustoUnitario);
            this.grbBox1.Controls.Add(this.txtCustoUnitario);
            this.grbBox1.Controls.Add(this.lblPreco);
            this.grbBox1.Controls.Add(this.lblCustoTotal);
            this.grbBox1.Controls.Add(this.txtPreco);
            this.grbBox1.Controls.Add(this.txtCustoTotal);
            this.grbBox1.Controls.Add(this.lblNome_Desc);
            this.grbBox1.Controls.Add(this.txtDescricao);
            this.grbBox1.Controls.Add(this.txtCodigo);
            this.grbBox1.Controls.Add(this.lblCodigo);
            this.grbBox1.Enabled = false;
            this.grbBox1.Location = new System.Drawing.Point(12, 292);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(760, 106);
            this.grbBox1.TabIndex = 2;
            this.grbBox1.TabStop = false;
            // 
            // lblUltCustoUnit
            // 
            this.lblUltCustoUnit.AutoSize = true;
            this.lblUltCustoUnit.ForeColor = System.Drawing.Color.Blue;
            this.lblUltCustoUnit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUltCustoUnit.Location = new System.Drawing.Point(94, 56);
            this.lblUltCustoUnit.Name = "lblUltCustoUnit";
            this.lblUltCustoUnit.Size = new System.Drawing.Size(69, 13);
            this.lblUltCustoUnit.TabIndex = 44;
            this.lblUltCustoUnit.Tag = "";
            this.lblUltCustoUnit.Text = "Último Custo:";
            // 
            // txtUltCusto
            // 
            this.txtUltCusto.BackColor = System.Drawing.Color.White;
            this.txtUltCusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtUltCusto.Location = new System.Drawing.Point(97, 72);
            this.txtUltCusto.MaxLength = 10;
            this.txtUltCusto.Name = "txtUltCusto";
            this.txtUltCusto.ReadOnly = true;
            this.txtUltCusto.Size = new System.Drawing.Size(75, 20);
            this.txtUltCusto.TabIndex = 6;
            this.txtUltCusto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUltCusto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUltCusto_KeyPress_1);
            // 
            // lblPrecoAtual
            // 
            this.lblPrecoAtual.AutoSize = true;
            this.lblPrecoAtual.ForeColor = System.Drawing.Color.Blue;
            this.lblPrecoAtual.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPrecoAtual.Location = new System.Drawing.Point(6, 56);
            this.lblPrecoAtual.Name = "lblPrecoAtual";
            this.lblPrecoAtual.Size = new System.Drawing.Size(65, 13);
            this.lblPrecoAtual.TabIndex = 42;
            this.lblPrecoAtual.Tag = "";
            this.lblPrecoAtual.Text = "Preço Atual:";
            // 
            // txtPrecoAtual
            // 
            this.txtPrecoAtual.BackColor = System.Drawing.Color.White;
            this.txtPrecoAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPrecoAtual.Location = new System.Drawing.Point(9, 72);
            this.txtPrecoAtual.MaxLength = 10;
            this.txtPrecoAtual.Name = "txtPrecoAtual";
            this.txtPrecoAtual.ReadOnly = true;
            this.txtPrecoAtual.Size = new System.Drawing.Size(75, 20);
            this.txtPrecoAtual.TabIndex = 5;
            this.txtPrecoAtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecoAtual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecoAtual_KeyPress);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.ForeColor = System.Drawing.Color.Blue;
            this.lblQuantidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblQuantidade.Location = new System.Drawing.Point(184, 56);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(65, 13);
            this.lblQuantidade.TabIndex = 0;
            this.lblQuantidade.Tag = "";
            this.lblQuantidade.Text = "Quantidade:";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BackColor = System.Drawing.Color.White;
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtQuantidade.Location = new System.Drawing.Point(187, 72);
            this.txtQuantidade.MaxLength = 10;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.ReadOnly = true;
            this.txtQuantidade.Size = new System.Drawing.Size(75, 20);
            this.txtQuantidade.TabIndex = 7;
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNovoPreco);
            this.groupBox1.Controls.Add(this.lblNovoPreco);
            this.groupBox1.Controls.Add(this.txtMargem);
            this.groupBox1.Controls.Add(this.lblMargem);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(572, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 82);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // txtNovoPreco
            // 
            this.txtNovoPreco.BackColor = System.Drawing.Color.White;
            this.txtNovoPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtNovoPreco.Location = new System.Drawing.Point(101, 33);
            this.txtNovoPreco.MaxLength = 10;
            this.txtNovoPreco.Name = "txtNovoPreco";
            this.txtNovoPreco.Size = new System.Drawing.Size(75, 20);
            this.txtNovoPreco.TabIndex = 12;
            this.txtNovoPreco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNovoPreco.Enter += new System.EventHandler(this.txtNovoPreco_Enter);
            this.txtNovoPreco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNovoPreco_KeyPress);
            this.txtNovoPreco.Leave += new System.EventHandler(this.txtNovoPreco_Leave);
            // 
            // lblNovoPreco
            // 
            this.lblNovoPreco.AutoSize = true;
            this.lblNovoPreco.ForeColor = System.Drawing.Color.Black;
            this.lblNovoPreco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNovoPreco.Location = new System.Drawing.Point(98, 16);
            this.lblNovoPreco.Name = "lblNovoPreco";
            this.lblNovoPreco.Size = new System.Drawing.Size(67, 13);
            this.lblNovoPreco.TabIndex = 0;
            this.lblNovoPreco.Tag = "";
            this.lblNovoPreco.Text = "Novo Preço:";
            // 
            // txtMargem
            // 
            this.txtMargem.BackColor = System.Drawing.Color.White;
            this.txtMargem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtMargem.Location = new System.Drawing.Point(9, 33);
            this.txtMargem.MaxLength = 10;
            this.txtMargem.Name = "txtMargem";
            this.txtMargem.Size = new System.Drawing.Size(75, 20);
            this.txtMargem.TabIndex = 11;
            this.txtMargem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMargem.Enter += new System.EventHandler(this.txtMargem_Enter);
            this.txtMargem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMargem_KeyPress);
            this.txtMargem.Leave += new System.EventHandler(this.txtMargem_Leave);
            // 
            // lblMargem
            // 
            this.lblMargem.AutoSize = true;
            this.lblMargem.ForeColor = System.Drawing.Color.Black;
            this.lblMargem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMargem.Location = new System.Drawing.Point(6, 17);
            this.lblMargem.Name = "lblMargem";
            this.lblMargem.Size = new System.Drawing.Size(65, 13);
            this.lblMargem.TabIndex = 0;
            this.lblMargem.Tag = "";
            this.lblMargem.Text = "Margem (%):";
            // 
            // lblCustoUnitario
            // 
            this.lblCustoUnitario.AutoSize = true;
            this.lblCustoUnitario.ForeColor = System.Drawing.Color.Blue;
            this.lblCustoUnitario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCustoUnitario.Location = new System.Drawing.Point(396, 56);
            this.lblCustoUnitario.Name = "lblCustoUnitario";
            this.lblCustoUnitario.Size = new System.Drawing.Size(73, 13);
            this.lblCustoUnitario.TabIndex = 0;
            this.lblCustoUnitario.Tag = "";
            this.lblCustoUnitario.Text = "Custo Unitário";
            // 
            // txtCustoUnitario
            // 
            this.txtCustoUnitario.BackColor = System.Drawing.Color.White;
            this.txtCustoUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCustoUnitario.Location = new System.Drawing.Point(399, 72);
            this.txtCustoUnitario.MaxLength = 10;
            this.txtCustoUnitario.Name = "txtCustoUnitario";
            this.txtCustoUnitario.ReadOnly = true;
            this.txtCustoUnitario.Size = new System.Drawing.Size(75, 20);
            this.txtCustoUnitario.TabIndex = 9;
            this.txtCustoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCustoUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNovoCusto_KeyPress);
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.ForeColor = System.Drawing.Color.Blue;
            this.lblPreco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPreco.Location = new System.Drawing.Point(279, 56);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(92, 13);
            this.lblPreco.TabIndex = 0;
            this.lblPreco.Text = "Preço de Compra:";
            // 
            // txtPreco
            // 
            this.txtPreco.BackColor = System.Drawing.Color.White;
            this.txtPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPreco.Location = new System.Drawing.Point(282, 72);
            this.txtPreco.MaxLength = 15;
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.ReadOnly = true;
            this.txtPreco.Size = new System.Drawing.Size(92, 20);
            this.txtPreco.TabIndex = 8;
            this.txtPreco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPreco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPreco_KeyPress);
            // 
            // lblCustoTotal
            // 
            this.lblCustoTotal.AutoSize = true;
            this.lblCustoTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblCustoTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCustoTotal.Location = new System.Drawing.Point(488, 56);
            this.lblCustoTotal.Name = "lblCustoTotal";
            this.lblCustoTotal.Size = new System.Drawing.Size(64, 13);
            this.lblCustoTotal.TabIndex = 0;
            this.lblCustoTotal.Tag = "";
            this.lblCustoTotal.Text = "Custo Total:";
            // 
            // txtCustoTotal
            // 
            this.txtCustoTotal.BackColor = System.Drawing.Color.White;
            this.txtCustoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCustoTotal.Location = new System.Drawing.Point(491, 72);
            this.txtCustoTotal.MaxLength = 10;
            this.txtCustoTotal.Name = "txtCustoTotal";
            this.txtCustoTotal.ReadOnly = true;
            this.txtCustoTotal.Size = new System.Drawing.Size(75, 20);
            this.txtCustoTotal.TabIndex = 10;
            this.txtCustoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCustoTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUltCusto_KeyPress);
            // 
            // lblNome_Desc
            // 
            this.lblNome_Desc.AutoSize = true;
            this.lblNome_Desc.ForeColor = System.Drawing.Color.Blue;
            this.lblNome_Desc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNome_Desc.Location = new System.Drawing.Point(92, 17);
            this.lblNome_Desc.Name = "lblNome_Desc";
            this.lblNome_Desc.Size = new System.Drawing.Size(58, 13);
            this.lblNome_Desc.TabIndex = 0;
            this.lblNome_Desc.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDescricao.Location = new System.Drawing.Point(95, 33);
            this.txtDescricao.MaxLength = 120;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ReadOnly = true;
            this.txtDescricao.Size = new System.Drawing.Size(471, 20);
            this.txtDescricao.TabIndex = 4;
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCodigo.Location = new System.Drawing.Point(9, 33);
            this.txtCodigo.MaxLength = 8;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtCodigo.TabIndex = 3;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.ForeColor = System.Drawing.Color.Blue;
            this.lblCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCodigo.Location = new System.Drawing.Point(6, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(331, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Informações do Item:";
            // 
            // btnSair
            // 
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(717, 404);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 16;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPrecificar.SetToolTip(this.btnSair, "Sair de Precificar Itens.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // lblItem
            // 
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(12, 9);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(760, 14);
            this.lblItem.TabIndex = 0;
            this.lblItem.Text = "Itens:";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(612, 266);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 16);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalvar.Location = new System.Drawing.Point(402, 404);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 15;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPrecificar.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // lblValorSituacao
            // 
            this.lblValorSituacao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorSituacao.BackColor = System.Drawing.Color.Transparent;
            this.lblValorSituacao.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorSituacao.ForeColor = System.Drawing.Color.Black;
            this.lblValorSituacao.Location = new System.Drawing.Point(40, 266);
            this.lblValorSituacao.Name = "lblValorSituacao";
            this.lblValorSituacao.Size = new System.Drawing.Size(110, 26);
            this.lblValorSituacao.TabIndex = 14;
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
            this.lblCxSituacao.Location = new System.Drawing.Point(12, 269);
            this.lblCxSituacao.Name = "lblCxSituacao";
            this.lblCxSituacao.Size = new System.Drawing.Size(22, 20);
            this.lblCxSituacao.TabIndex = 15;
            this.lblCxSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCxSituacao.Visible = false;
            // 
            // ttpPrecificar
            // 
            this.ttpPrecificar.AutoPopDelay = 5000;
            this.ttpPrecificar.InitialDelay = 1000;
            this.ttpPrecificar.IsBalloon = true;
            this.ttpPrecificar.ReshowDelay = 100;
            this.ttpPrecificar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpPrecificar.ToolTipTitle = "Dica:";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.Enabled = false;
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnLimpar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLimpar.Location = new System.Drawing.Point(324, 404);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(72, 32);
            this.btnLimpar.TabIndex = 14;
            this.btnLimpar.Text = "&Limpar";
            this.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPrecificar.SetToolTip(this.btnLimpar, "Limpar dados informados.");
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmPrecificarItems
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.ControlBox = false;
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.lblValorSituacao);
            this.Controls.Add(this.lblCxSituacao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.dtItens);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrecificarItems";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Precificar Itens";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAtualizarPrecoItem_FormClosing);
            this.Load += new System.EventHandler(this.FrmAtualizarPrecoItem_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPrecificarItems_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtItens)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dtItens;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNome_Desc;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblCustoTotal;
        private System.Windows.Forms.TextBox txtCustoTotal;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCustoUnitario;
        private System.Windows.Forms.TextBox txtCustoUnitario;
        private System.Windows.Forms.TextBox txtNovoPreco;
        private System.Windows.Forms.Label lblNovoPreco;
        private System.Windows.Forms.TextBox txtMargem;
        private System.Windows.Forms.Label lblMargem;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblValorSituacao;
        private System.Windows.Forms.Label lblCxSituacao;
        private System.Windows.Forms.ToolTip ttpPrecificar;
        private System.Windows.Forms.Label lblUltCustoUnit;
        private System.Windows.Forms.TextBox txtUltCusto;
        private System.Windows.Forms.Label lblPrecoAtual;
        private System.Windows.Forms.TextBox txtPrecoAtual;
        private System.Windows.Forms.Button btnLimpar;
    }
}