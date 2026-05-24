namespace Seven_Sistema
{
    partial class FrmRelInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelInventario));
            this.dtInv = new System.Windows.Forms.DataGridView();
            this.lblItem = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.lblValorSituacao = new System.Windows.Forms.Label();
            this.lblCxSituacao = new System.Windows.Forms.Label();
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.btnZerarEstoque = new System.Windows.Forms.Button();
            this.btnAjustarInventario = new System.Windows.Forms.Button();
            this.btnAtualizarEstoque = new System.Windows.Forms.Button();
            this.btnItens = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.ttpInv = new System.Windows.Forms.ToolTip(this.components);
            this.btnRelatorioPositivo = new System.Windows.Forms.Button();
            this.btnRelatorioZerado = new System.Windows.Forms.Button();
            this.btnRelatorioNegativo = new System.Windows.Forms.Button();
            this.btnRelatorioTodos = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.pcibInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.pEnabled = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtInv)).BeginInit();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao2)).BeginInit();
            this.pEnabled.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtInv
            // 
            this.dtInv.AllowUserToAddRows = false;
            this.dtInv.AllowUserToDeleteRows = false;
            this.dtInv.AllowUserToResizeRows = false;
            this.dtInv.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtInv.Location = new System.Drawing.Point(27, 68);
            this.dtInv.MultiSelect = false;
            this.dtInv.Name = "dtInv";
            this.dtInv.ReadOnly = true;
            this.dtInv.RowHeadersVisible = false;
            this.dtInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtInv.ShowCellErrors = false;
            this.dtInv.ShowCellToolTips = false;
            this.dtInv.ShowEditingIcon = false;
            this.dtInv.ShowRowErrors = false;
            this.dtInv.Size = new System.Drawing.Size(760, 349);
            this.dtInv.TabIndex = 1;
            this.dtInv.DataSourceChanged += new System.EventHandler(this.dtInv_DataSourceChanged);
            this.dtInv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtInv_CellEnter);
            this.dtInv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtInv_CellFormatting);
            this.dtInv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtInv_RowsAdded);
            this.dtInv.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtInv_RowsRemoved);
            this.dtInv.MouseLeave += new System.EventHandler(this.dtInv_MouseLeave);
            this.dtInv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtInv_MouseMove);
            // 
            // lblItem
            // 
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(27, 46);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(760, 19);
            this.lblItem.TabIndex = 32;
            this.lblItem.Text = "INVENTÁRIOS:";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.btnFinalizar);
            this.grbBox2.Controls.Add(this.lblValorSituacao);
            this.grbBox2.Controls.Add(this.lblCxSituacao);
            this.grbBox2.Controls.Add(this.btnSincronizar);
            this.grbBox2.Controls.Add(this.btnZerarEstoque);
            this.grbBox2.Controls.Add(this.btnAjustarInventario);
            this.grbBox2.Controls.Add(this.btnAtualizarEstoque);
            this.grbBox2.Controls.Add(this.btnItens);
            this.grbBox2.Controls.Add(this.btnExcluir);
            this.grbBox2.Controls.Add(this.btnNovo);
            this.grbBox2.Location = new System.Drawing.Point(27, 450);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(760, 98);
            this.grbBox2.TabIndex = 6;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Ações";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Enabled = false;
            this.btnFinalizar.Image = ((System.Drawing.Image)(resources.GetObject("btnFinalizar.Image")));
            this.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFinalizar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFinalizar.Location = new System.Drawing.Point(615, 19);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(139, 32);
            this.btnFinalizar.TabIndex = 10;
            this.btnFinalizar.Text = "&Finalizar Inventário";
            this.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInv.SetToolTip(this.btnFinalizar, "Clique para afinalizar um Inventário selecionado.");
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            this.btnFinalizar.MouseLeave += new System.EventHandler(this.btnFinalizar_MouseLeave);
            this.btnFinalizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnFinalizar_MouseMove);
            // 
            // lblValorSituacao
            // 
            this.lblValorSituacao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorSituacao.BackColor = System.Drawing.Color.Transparent;
            this.lblValorSituacao.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorSituacao.ForeColor = System.Drawing.Color.Black;
            this.lblValorSituacao.Location = new System.Drawing.Point(34, 40);
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
            this.lblCxSituacao.Location = new System.Drawing.Point(6, 43);
            this.lblCxSituacao.Name = "lblCxSituacao";
            this.lblCxSituacao.Size = new System.Drawing.Size(22, 20);
            this.lblCxSituacao.TabIndex = 15;
            this.lblCxSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCxSituacao.Visible = false;
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.Enabled = false;
            this.btnSincronizar.Image = ((System.Drawing.Image)(resources.GetObject("btnSincronizar.Image")));
            this.btnSincronizar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSincronizar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSincronizar.Location = new System.Drawing.Point(285, 57);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(164, 32);
            this.btnSincronizar.TabIndex = 12;
            this.btnSincronizar.Text = "&Sincronizar Estoque Atual";
            this.btnSincronizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInv.SetToolTip(this.btnSincronizar, "Clique para Sincronizar todo o Estoque do sistema com o inventário atual.");
            this.btnSincronizar.UseVisualStyleBackColor = true;
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);
            this.btnSincronizar.MouseLeave += new System.EventHandler(this.btnSincronizar_MouseLeave);
            this.btnSincronizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSincronizar_MouseMove);
            // 
            // btnZerarEstoque
            // 
            this.btnZerarEstoque.Image = ((System.Drawing.Image)(resources.GetObject("btnZerarEstoque.Image")));
            this.btnZerarEstoque.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnZerarEstoque.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZerarEstoque.Location = new System.Drawing.Point(615, 57);
            this.btnZerarEstoque.Name = "btnZerarEstoque";
            this.btnZerarEstoque.Size = new System.Drawing.Size(139, 32);
            this.btnZerarEstoque.TabIndex = 14;
            this.btnZerarEstoque.Text = "&Zerar Todo Estoque";
            this.btnZerarEstoque.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInv.SetToolTip(this.btnZerarEstoque, "Clique para Zerar todo o Estoque do sistema.");
            this.btnZerarEstoque.UseVisualStyleBackColor = true;
            this.btnZerarEstoque.Click += new System.EventHandler(this.button1_Click);
            this.btnZerarEstoque.MouseLeave += new System.EventHandler(this.btnZerarEstoque_MouseLeave);
            this.btnZerarEstoque.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnZerarEstoque_MouseMove);
            // 
            // btnAjustarInventario
            // 
            this.btnAjustarInventario.Enabled = false;
            this.btnAjustarInventario.Image = ((System.Drawing.Image)(resources.GetObject("btnAjustarInventario.Image")));
            this.btnAjustarInventario.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAjustarInventario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAjustarInventario.Location = new System.Drawing.Point(455, 19);
            this.btnAjustarInventario.Name = "btnAjustarInventario";
            this.btnAjustarInventario.Size = new System.Drawing.Size(154, 32);
            this.btnAjustarInventario.TabIndex = 9;
            this.btnAjustarInventario.Text = "     Ajustar In&ventário";
            this.ttpInv.SetToolTip(this.btnAjustarInventario, "Clique para ajustar o Inventário selecionado.");
            this.btnAjustarInventario.UseVisualStyleBackColor = true;
            this.btnAjustarInventario.Click += new System.EventHandler(this.button4_Click);
            this.btnAjustarInventario.MouseLeave += new System.EventHandler(this.button4_MouseLeave);
            this.btnAjustarInventario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button4_MouseMove);
            // 
            // btnAtualizarEstoque
            // 
            this.btnAtualizarEstoque.Image = ((System.Drawing.Image)(resources.GetObject("btnAtualizarEstoque.Image")));
            this.btnAtualizarEstoque.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAtualizarEstoque.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAtualizarEstoque.Location = new System.Drawing.Point(455, 57);
            this.btnAtualizarEstoque.Name = "btnAtualizarEstoque";
            this.btnAtualizarEstoque.Size = new System.Drawing.Size(154, 32);
            this.btnAtualizarEstoque.TabIndex = 13;
            this.btnAtualizarEstoque.Text = "&Atualizar Todo Estoque";
            this.btnAtualizarEstoque.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInv.SetToolTip(this.btnAtualizarEstoque, "Clique para atualizar todo o Estoque do sistema.");
            this.btnAtualizarEstoque.UseVisualStyleBackColor = true;
            this.btnAtualizarEstoque.Click += new System.EventHandler(this.btnAtualizarEstoque_Click);
            this.btnAtualizarEstoque.MouseLeave += new System.EventHandler(this.btnAtualizarEstoque_MouseLeave);
            this.btnAtualizarEstoque.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAtualizarEstoque_MouseMove);
            // 
            // btnItens
            // 
            this.btnItens.Enabled = false;
            this.btnItens.Image = ((System.Drawing.Image)(resources.GetObject("btnItens.Image")));
            this.btnItens.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnItens.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnItens.Location = new System.Drawing.Point(285, 19);
            this.btnItens.Name = "btnItens";
            this.btnItens.Size = new System.Drawing.Size(164, 32);
            this.btnItens.TabIndex = 8;
            this.btnItens.Text = "Alterar &Itens do Inventário";
            this.btnItens.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInv.SetToolTip(this.btnItens, "Clique para alterar Itens de um Inventário selecionado.");
            this.btnItens.UseVisualStyleBackColor = true;
            this.btnItens.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnItens.MouseLeave += new System.EventHandler(this.btnAlterar_MouseLeave);
            this.btnItens.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterar_MouseMove);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExcluir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcluir.Location = new System.Drawing.Point(162, 57);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(117, 32);
            this.btnExcluir.TabIndex = 11;
            this.btnExcluir.Text = "      &Excluir";
            this.ttpInv.SetToolTip(this.btnExcluir, "Clique para excluir o Inventário selecionado.");
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluirItem_Click);
            this.btnExcluir.MouseLeave += new System.EventHandler(this.btnExcluirItem_MouseLeave);
            this.btnExcluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluirItem_MouseMove);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNovo.Location = new System.Drawing.Point(162, 19);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(117, 32);
            this.btnNovo.TabIndex = 7;
            this.btnNovo.Text = "&Novo Inventário";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInv.SetToolTip(this.btnNovo, "Clique para gerar um novo Inventário.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnIncluir_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnIncluir_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnIncluir_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(27, 418);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(196, 25);
            this.lblRegistros.TabIndex = 34;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ttpInv
            // 
            this.ttpInv.AutoPopDelay = 5000;
            this.ttpInv.InitialDelay = 1000;
            this.ttpInv.IsBalloon = true;
            this.ttpInv.ReshowDelay = 100;
            this.ttpInv.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpInv.ToolTipTitle = "Dica:";
            // 
            // btnRelatorioPositivo
            // 
            this.btnRelatorioPositivo.Enabled = false;
            this.btnRelatorioPositivo.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorioPositivo.Image")));
            this.btnRelatorioPositivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorioPositivo.Location = new System.Drawing.Point(356, 419);
            this.btnRelatorioPositivo.Name = "btnRelatorioPositivo";
            this.btnRelatorioPositivo.Size = new System.Drawing.Size(138, 25);
            this.btnRelatorioPositivo.TabIndex = 3;
            this.btnRelatorioPositivo.Text = "Relatório dos &Positivos";
            this.btnRelatorioPositivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInv.SetToolTip(this.btnRelatorioPositivo, "Clique para gerar em PDF o relatório positivo do Inventário selecionado.");
            this.btnRelatorioPositivo.UseVisualStyleBackColor = true;
            this.btnRelatorioPositivo.Click += new System.EventHandler(this.btnRelatorioPositivo_Click);
            this.btnRelatorioPositivo.MouseLeave += new System.EventHandler(this.btnRelatorioPositivo_MouseLeave);
            this.btnRelatorioPositivo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRelatorioPositivo_MouseMove);
            // 
            // btnRelatorioZerado
            // 
            this.btnRelatorioZerado.Enabled = false;
            this.btnRelatorioZerado.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorioZerado.Image")));
            this.btnRelatorioZerado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorioZerado.Location = new System.Drawing.Point(500, 419);
            this.btnRelatorioZerado.Name = "btnRelatorioZerado";
            this.btnRelatorioZerado.Size = new System.Drawing.Size(135, 25);
            this.btnRelatorioZerado.TabIndex = 4;
            this.btnRelatorioZerado.Text = "Relatório dos Zera&dos";
            this.btnRelatorioZerado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInv.SetToolTip(this.btnRelatorioZerado, "Clique para gerar em PDF o relatório zerado do Inventário selecionado.");
            this.btnRelatorioZerado.UseVisualStyleBackColor = true;
            this.btnRelatorioZerado.Click += new System.EventHandler(this.btnRelatorioZerado_Click);
            this.btnRelatorioZerado.MouseLeave += new System.EventHandler(this.btnRelatorioZerado_MouseLeave);
            this.btnRelatorioZerado.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRelatorioZerado_MouseMove);
            // 
            // btnRelatorioNegativo
            // 
            this.btnRelatorioNegativo.Enabled = false;
            this.btnRelatorioNegativo.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorioNegativo.Image")));
            this.btnRelatorioNegativo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorioNegativo.Location = new System.Drawing.Point(641, 419);
            this.btnRelatorioNegativo.Name = "btnRelatorioNegativo";
            this.btnRelatorioNegativo.Size = new System.Drawing.Size(146, 25);
            this.btnRelatorioNegativo.TabIndex = 5;
            this.btnRelatorioNegativo.Text = "Relatório dos Ne&gativos";
            this.btnRelatorioNegativo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInv.SetToolTip(this.btnRelatorioNegativo, "Clique para gerar em PDF o relatório negativo do Inventário selecionado.");
            this.btnRelatorioNegativo.UseVisualStyleBackColor = true;
            this.btnRelatorioNegativo.Click += new System.EventHandler(this.btnRelatorioNegativo_Click);
            this.btnRelatorioNegativo.MouseLeave += new System.EventHandler(this.btnRelatorioNegativo_MouseLeave);
            this.btnRelatorioNegativo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRelatorioNegativo_MouseMove);
            // 
            // btnRelatorioTodos
            // 
            this.btnRelatorioTodos.Enabled = false;
            this.btnRelatorioTodos.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorioTodos.Image")));
            this.btnRelatorioTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorioTodos.Location = new System.Drawing.Point(226, 419);
            this.btnRelatorioTodos.Name = "btnRelatorioTodos";
            this.btnRelatorioTodos.Size = new System.Drawing.Size(124, 25);
            this.btnRelatorioTodos.TabIndex = 2;
            this.btnRelatorioTodos.Text = "Relatório &Completo";
            this.btnRelatorioTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInv.SetToolTip(this.btnRelatorioTodos, "Clique para gerar em PDF o relatório completo do Inventário selecionado.");
            this.btnRelatorioTodos.UseVisualStyleBackColor = true;
            this.btnRelatorioTodos.Click += new System.EventHandler(this.btnRelatorioTodos_Click);
            this.btnRelatorioTodos.MouseLeave += new System.EventHandler(this.btnRelatorioTodos_MouseLeave);
            this.btnRelatorioTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRelatorioTodos_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(732, 554);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 15;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInv.SetToolTip(this.btnSair, "Clique para sair do Inventário de Produtos.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(263, 222);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(300, 33);
            this.lblProgresso.TabIndex = 72;
            this.lblProgresso.Text = "Por favor, aguarde...";
            this.lblProgresso.Visible = false;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.pgbProgresso.Location = new System.Drawing.Point(253, 254);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(321, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 73;
            this.pgbProgresso.Visible = false;
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // pcibInterrogacao2
            // 
            this.pcibInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao2.Image")));
            this.pcibInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pcibInterrogacao2.Location = new System.Drawing.Point(27, 554);
            this.pcibInterrogacao2.Name = "pcibInterrogacao2";
            this.pcibInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao2.TabIndex = 71;
            this.pcibInterrogacao2.TabStop = false;
            this.pcibInterrogacao2.Click += new System.EventHandler(this.pcibInterrogacao2_Click);
            this.pcibInterrogacao2.MouseLeave += new System.EventHandler(this.pcibInterrogacao2_MouseLeave);
            this.pcibInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao2_MouseMove);
            // 
            // pEnabled
            // 
            this.pEnabled.Controls.Add(this.btnSair);
            this.pEnabled.Controls.Add(this.pcibInterrogacao2);
            this.pEnabled.Controls.Add(this.btnRelatorioPositivo);
            this.pEnabled.Controls.Add(this.lblProgresso);
            this.pEnabled.Controls.Add(this.grbBox2);
            this.pEnabled.Controls.Add(this.btnRelatorioZerado);
            this.pEnabled.Controls.Add(this.lblItem);
            this.pEnabled.Controls.Add(this.btnRelatorioNegativo);
            this.pEnabled.Controls.Add(this.btnRelatorioTodos);
            this.pEnabled.Controls.Add(this.pgbProgresso);
            this.pEnabled.Controls.Add(this.dtInv);
            this.pEnabled.Controls.Add(this.lblRegistros);
            this.pEnabled.Location = new System.Drawing.Point(-15, -37);
            this.pEnabled.Name = "pEnabled";
            this.pEnabled.Size = new System.Drawing.Size(815, 617);
            this.pEnabled.TabIndex = 74;
            // 
            // FrmRelInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(784, 552);
            this.ControlBox = false;
            this.Controls.Add(this.pEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelInventario";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventário de Produtos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInventario_FormClosing);
            this.Load += new System.EventHandler(this.FrmInventario_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmInventario_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtInv)).EndInit();
            this.grbBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao2)).EndInit();
            this.pEnabled.ResumeLayout(false);
            this.pEnabled.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dtInv;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnItens;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnRelatorioTodos;
        private System.Windows.Forms.PictureBox pcibInterrogacao2;
        private System.Windows.Forms.ToolTip ttpInv;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.Button btnAtualizarEstoque;
        private System.Windows.Forms.Button btnRelatorioNegativo;
        private System.Windows.Forms.Button btnRelatorioZerado;
        private System.Windows.Forms.Button btnRelatorioPositivo;
        private System.Windows.Forms.Button btnAjustarInventario;
        private System.Windows.Forms.Button btnZerarEstoque;
        private System.Windows.Forms.Panel pEnabled;
        private System.Windows.Forms.Button btnSincronizar;
        private System.Windows.Forms.Label lblValorSituacao;
        private System.Windows.Forms.Label lblCxSituacao;
        private System.Windows.Forms.Button btnFinalizar;
    }
}