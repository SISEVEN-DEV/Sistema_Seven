namespace Seven_Sistema
{
    partial class FrmPesqProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesqProduto));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.pcibAjudaFoto = new System.Windows.Forms.PictureBox();
            this.dtProd = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.lblLegendaImagem = new System.Windows.Forms.Label();
            this.pcibImagem = new System.Windows.Forms.PictureBox();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.btnpProcurarSub1 = new System.Windows.Forms.Button();
            this.cbbpSubGrupo = new System.Windows.Forms.ComboBox();
            this.lblSubGrupo1 = new System.Windows.Forms.Label();
            this.rbtnReferencia = new System.Windows.Forms.RadioButton();
            this.btnpProcurar = new System.Windows.Forms.Button();
            this.rbtnPalavraChave = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.rbtnGrupo = new System.Windows.Forms.RadioButton();
            this.rbtnBarra = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnDescricao = new System.Windows.Forms.RadioButton();
            this.txtpPalavraChave = new System.Windows.Forms.TextBox();
            this.cbbpGrupo = new System.Windows.Forms.ComboBox();
            this.txtpDescricao = new System.Windows.Forms.TextBox();
            this.txtpBarra = new System.Windows.Forms.TextBox();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.ttpProd = new System.Windows.Forms.ToolTip(this.components);
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.lblSaldoAtual = new System.Windows.Forms.Label();
            this.lblValorSaldo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcibAjudaFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(718, 282);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 103;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProd.SetToolTip(this.btnVoltar, "Sair de Pesquisar Produtos.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Enabled = false;
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(642, 282);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(70, 32);
            this.btnIncluir.TabIndex = 102;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProd.SetToolTip(this.btnIncluir, "Clique para incluir os dados.");
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            this.btnIncluir.MouseLeave += new System.EventHandler(this.btnIncluir_MouseLeave);
            this.btnIncluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnIncluir_MouseMove);
            // 
            // pcibAjudaFoto
            // 
            this.pcibAjudaFoto.BackColor = System.Drawing.Color.White;
            this.pcibAjudaFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibAjudaFoto.Image = ((System.Drawing.Image)(resources.GetObject("pcibAjudaFoto.Image")));
            this.pcibAjudaFoto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pcibAjudaFoto.Location = new System.Drawing.Point(147, 212);
            this.pcibAjudaFoto.Name = "pcibAjudaFoto";
            this.pcibAjudaFoto.Size = new System.Drawing.Size(20, 20);
            this.pcibAjudaFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibAjudaFoto.TabIndex = 106;
            this.pcibAjudaFoto.TabStop = false;
            this.pcibAjudaFoto.Click += new System.EventHandler(this.pcibAjudaFoto_Click);
            this.pcibAjudaFoto.MouseLeave += new System.EventHandler(this.pcibAjudaFoto_MouseLeave);
            this.pcibAjudaFoto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibAjudaFoto_MouseMove);
            // 
            // dtProd
            // 
            this.dtProd.AllowUserToAddRows = false;
            this.dtProd.AllowUserToDeleteRows = false;
            this.dtProd.AllowUserToResizeRows = false;
            this.dtProd.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtProd.Enabled = false;
            this.dtProd.Location = new System.Drawing.Point(173, 104);
            this.dtProd.MultiSelect = false;
            this.dtProd.Name = "dtProd";
            this.dtProd.ReadOnly = true;
            this.dtProd.RowHeadersVisible = false;
            this.dtProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtProd.ShowCellErrors = false;
            this.dtProd.ShowCellToolTips = false;
            this.dtProd.ShowEditingIcon = false;
            this.dtProd.ShowRowErrors = false;
            this.dtProd.Size = new System.Drawing.Size(599, 172);
            this.dtProd.TabIndex = 101;
            this.dtProd.DataSourceChanged += new System.EventHandler(this.dtProd_DataSourceChanged);
            this.dtProd.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtProd_CellEnter);
            this.dtProd.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtProd_CellFormatting);
            this.dtProd.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtProd_CellLeave);
            this.dtProd.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtProd_RowsAdded);
            this.dtProd.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtProd_RowsRemoved);
            this.dtProd.DoubleClick += new System.EventHandler(this.dtProd_DoubleClick);
            this.dtProd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtProd_KeyDown);
            this.dtProd.MouseLeave += new System.EventHandler(this.dtProd_MouseLeave);
            this.dtProd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtProd_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(12, 235);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 99;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLegendaImagem
            // 
            this.lblLegendaImagem.Location = new System.Drawing.Point(17, 145);
            this.lblLegendaImagem.Name = "lblLegendaImagem";
            this.lblLegendaImagem.Size = new System.Drawing.Size(148, 45);
            this.lblLegendaImagem.TabIndex = 100;
            this.lblLegendaImagem.Text = "Sem imagem para este registro.";
            this.lblLegendaImagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLegendaImagem.Visible = false;
            this.lblLegendaImagem.Click += new System.EventHandler(this.lblLegendaImagem_Click);
            this.lblLegendaImagem.MouseLeave += new System.EventHandler(this.lblLegendaImagem_MouseLeave);
            this.lblLegendaImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblLegendaImagem_MouseMove);
            // 
            // pcibImagem
            // 
            this.pcibImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibImagem.Location = new System.Drawing.Point(12, 104);
            this.pcibImagem.Name = "pcibImagem";
            this.pcibImagem.Size = new System.Drawing.Size(155, 128);
            this.pcibImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcibImagem.TabIndex = 105;
            this.pcibImagem.TabStop = false;
            this.pcibImagem.Click += new System.EventHandler(this.pcibImagem_Click);
            this.pcibImagem.MouseLeave += new System.EventHandler(this.pcibImagem_MouseLeave);
            this.pcibImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibImagem_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnpProcurarSub1);
            this.grbBox1.Controls.Add(this.cbbpSubGrupo);
            this.grbBox1.Controls.Add(this.lblSubGrupo1);
            this.grbBox1.Controls.Add(this.rbtnReferencia);
            this.grbBox1.Controls.Add(this.btnpProcurar);
            this.grbBox1.Controls.Add(this.rbtnPalavraChave);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.picbInterrogacao2);
            this.grbBox1.Controls.Add(this.rbtnGrupo);
            this.grbBox1.Controls.Add(this.rbtnBarra);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnDescricao);
            this.grbBox1.Controls.Add(this.txtpPalavraChave);
            this.grbBox1.Controls.Add(this.cbbpGrupo);
            this.grbBox1.Controls.Add(this.txtpDescricao);
            this.grbBox1.Controls.Add(this.txtpBarra);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(760, 86);
            this.grbBox1.TabIndex = 104;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // btnpProcurarSub1
            // 
            this.btnpProcurarSub1.Enabled = false;
            this.btnpProcurarSub1.Image = ((System.Drawing.Image)(resources.GetObject("btnpProcurarSub1.Image")));
            this.btnpProcurarSub1.Location = new System.Drawing.Point(613, 41);
            this.btnpProcurarSub1.Name = "btnpProcurarSub1";
            this.btnpProcurarSub1.Size = new System.Drawing.Size(26, 25);
            this.btnpProcurarSub1.TabIndex = 15;
            this.btnpProcurarSub1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProd.SetToolTip(this.btnpProcurarSub1, "Clique para pesquisar um sub-grupo.");
            this.btnpProcurarSub1.UseVisualStyleBackColor = true;
            this.btnpProcurarSub1.Visible = false;
            this.btnpProcurarSub1.Click += new System.EventHandler(this.btnpProcurarSub1_Click);
            this.btnpProcurarSub1.MouseLeave += new System.EventHandler(this.btnpProcurarSub1_MouseLeave);
            this.btnpProcurarSub1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnpProcurarSub1_MouseMove);
            // 
            // cbbpSubGrupo
            // 
            this.cbbpSubGrupo.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpSubGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpSubGrupo.Enabled = false;
            this.cbbpSubGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpSubGrupo.FormattingEnabled = true;
            this.cbbpSubGrupo.Location = new System.Drawing.Point(364, 43);
            this.cbbpSubGrupo.Name = "cbbpSubGrupo";
            this.cbbpSubGrupo.Size = new System.Drawing.Size(243, 21);
            this.cbbpSubGrupo.TabIndex = 14;
            this.cbbpSubGrupo.Visible = false;
            this.cbbpSubGrupo.DropDown += new System.EventHandler(this.cbbpSubGrupo_DropDown);
            this.cbbpSubGrupo.DropDownClosed += new System.EventHandler(this.cbbpSubGrupo_DropDownClosed);
            this.cbbpSubGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpSubGrupo_KeyPress);
            this.cbbpSubGrupo.MouseLeave += new System.EventHandler(this.cbbpSubGrupo_MouseLeave);
            this.cbbpSubGrupo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpSubGrupo_MouseMove);
            // 
            // lblSubGrupo1
            // 
            this.lblSubGrupo1.AutoSize = true;
            this.lblSubGrupo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSubGrupo1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSubGrupo1.Location = new System.Drawing.Point(231, 47);
            this.lblSubGrupo1.Name = "lblSubGrupo1";
            this.lblSubGrupo1.Size = new System.Drawing.Size(127, 13);
            this.lblSubGrupo1.TabIndex = 0;
            this.lblSubGrupo1.Text = "Escolha o sub-grupo:";
            this.lblSubGrupo1.Visible = false;
            // 
            // rbtnReferencia
            // 
            this.rbtnReferencia.AutoSize = true;
            this.rbtnReferencia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnReferencia.Location = new System.Drawing.Point(6, 65);
            this.rbtnReferencia.Name = "rbtnReferencia";
            this.rbtnReferencia.Size = new System.Drawing.Size(77, 17);
            this.rbtnReferencia.TabIndex = 6;
            this.rbtnReferencia.TabStop = true;
            this.rbtnReferencia.Text = "Referência";
            this.rbtnReferencia.UseVisualStyleBackColor = true;
            this.rbtnReferencia.CheckedChanged += new System.EventHandler(this.rbtnReferencia_CheckedChanged);
            this.rbtnReferencia.MouseLeave += new System.EventHandler(this.rbtnReferencia_MouseLeave);
            this.rbtnReferencia.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnReferencia_MouseMove);
            // 
            // btnpProcurar
            // 
            this.btnpProcurar.Image = ((System.Drawing.Image)(resources.GetObject("btnpProcurar.Image")));
            this.btnpProcurar.Location = new System.Drawing.Point(728, 15);
            this.btnpProcurar.Name = "btnpProcurar";
            this.btnpProcurar.Size = new System.Drawing.Size(26, 25);
            this.btnpProcurar.TabIndex = 13;
            this.btnpProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProd.SetToolTip(this.btnpProcurar, "Clique para pesquisar um grupo.");
            this.btnpProcurar.UseVisualStyleBackColor = true;
            this.btnpProcurar.Visible = false;
            this.btnpProcurar.Click += new System.EventHandler(this.btnpProcurar_Click);
            this.btnpProcurar.MouseLeave += new System.EventHandler(this.btnpProcurar_MouseLeave);
            this.btnpProcurar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnpProcurar_MouseMove);
            // 
            // rbtnPalavraChave
            // 
            this.rbtnPalavraChave.AutoSize = true;
            this.rbtnPalavraChave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnPalavraChave.Location = new System.Drawing.Point(89, 41);
            this.rbtnPalavraChave.Name = "rbtnPalavraChave";
            this.rbtnPalavraChave.Size = new System.Drawing.Size(95, 17);
            this.rbtnPalavraChave.TabIndex = 5;
            this.rbtnPalavraChave.TabStop = true;
            this.rbtnPalavraChave.Text = "Palavra-Chave";
            this.rbtnPalavraChave.UseVisualStyleBackColor = true;
            this.rbtnPalavraChave.CheckedChanged += new System.EventHandler(this.rbtnPalavraChave_CheckedChanged);
            this.rbtnPalavraChave.MouseLeave += new System.EventHandler(this.rbtnPalavraChave_MouseLeave);
            this.rbtnPalavraChave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPalavraChave_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(341, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(114, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite a descrição:";
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(646, 44);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 31;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // rbtnGrupo
            // 
            this.rbtnGrupo.AutoSize = true;
            this.rbtnGrupo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnGrupo.Location = new System.Drawing.Point(89, 65);
            this.rbtnGrupo.Name = "rbtnGrupo";
            this.rbtnGrupo.Size = new System.Drawing.Size(117, 17);
            this.rbtnGrupo.TabIndex = 7;
            this.rbtnGrupo.TabStop = true;
            this.rbtnGrupo.Text = "Grupo e Sub-Grupo";
            this.rbtnGrupo.UseVisualStyleBackColor = true;
            this.rbtnGrupo.CheckedChanged += new System.EventHandler(this.rbtnGrupo_CheckedChanged);
            this.rbtnGrupo.MouseLeave += new System.EventHandler(this.rbtnGrupo_MouseLeave);
            this.rbtnGrupo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnGrupo_MouseMove);
            // 
            // rbtnBarra
            // 
            this.rbtnBarra.AutoSize = true;
            this.rbtnBarra.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnBarra.Location = new System.Drawing.Point(89, 19);
            this.rbtnBarra.Name = "rbtnBarra";
            this.rbtnBarra.Size = new System.Drawing.Size(106, 17);
            this.rbtnBarra.TabIndex = 2;
            this.rbtnBarra.TabStop = true;
            this.rbtnBarra.Text = "Código de Barras";
            this.rbtnBarra.UseVisualStyleBackColor = true;
            this.rbtnBarra.CheckedChanged += new System.EventHandler(this.rbtnBarra_CheckedChanged);
            this.rbtnBarra.MouseLeave += new System.EventHandler(this.rbtnBarra_MouseLeave);
            this.rbtnBarra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnBarra_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(201, 19);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 3;
            this.rbtnTodos.TabStop = true;
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
            this.btnPesquisar.TabIndex = 16;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProd.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(6, 41);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 4;
            this.rbtnCodigo.TabStop = true;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // rbtnDescricao
            // 
            this.rbtnDescricao.AutoSize = true;
            this.rbtnDescricao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnDescricao.Location = new System.Drawing.Point(6, 19);
            this.rbtnDescricao.Name = "rbtnDescricao";
            this.rbtnDescricao.Size = new System.Drawing.Size(73, 17);
            this.rbtnDescricao.TabIndex = 1;
            this.rbtnDescricao.Text = "Descrição";
            this.rbtnDescricao.UseVisualStyleBackColor = true;
            this.rbtnDescricao.CheckedChanged += new System.EventHandler(this.rbtnDescricao_CheckedChanged);
            this.rbtnDescricao.MouseLeave += new System.EventHandler(this.rbtnDescricao_MouseLeave);
            this.rbtnDescricao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnDescricao_MouseMove);
            // 
            // txtpPalavraChave
            // 
            this.txtpPalavraChave.BackColor = System.Drawing.Color.White;
            this.txtpPalavraChave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpPalavraChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpPalavraChave.Location = new System.Drawing.Point(674, 18);
            this.txtpPalavraChave.MaxLength = 10;
            this.txtpPalavraChave.Name = "txtpPalavraChave";
            this.txtpPalavraChave.Size = new System.Drawing.Size(80, 20);
            this.txtpPalavraChave.TabIndex = 11;
            this.txtpPalavraChave.Visible = false;
            this.txtpPalavraChave.Enter += new System.EventHandler(this.txtpPalavraChave_Enter);
            this.txtpPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpPalavraChave_KeyPress);
            this.txtpPalavraChave.Leave += new System.EventHandler(this.txtpPalavraChave_Leave);
            // 
            // cbbpGrupo
            // 
            this.cbbpGrupo.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpGrupo.FormattingEnabled = true;
            this.cbbpGrupo.Location = new System.Drawing.Point(479, 18);
            this.cbbpGrupo.Name = "cbbpGrupo";
            this.cbbpGrupo.Size = new System.Drawing.Size(243, 21);
            this.cbbpGrupo.TabIndex = 9;
            this.cbbpGrupo.Visible = false;
            this.cbbpGrupo.DropDown += new System.EventHandler(this.cbbpGrupo_DropDown);
            this.cbbpGrupo.SelectedIndexChanged += new System.EventHandler(this.cbbpGrupo_SelectedIndexChanged);
            this.cbbpGrupo.DropDownClosed += new System.EventHandler(this.cbbpGrupo_DropDownClosed);
            this.cbbpGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpGrupo_KeyPress);
            this.cbbpGrupo.MouseLeave += new System.EventHandler(this.cbbpGrupo_MouseLeave);
            this.cbbpGrupo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpGrupo_MouseMove);
            // 
            // txtpDescricao
            // 
            this.txtpDescricao.BackColor = System.Drawing.Color.White;
            this.txtpDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpDescricao.Location = new System.Drawing.Point(464, 18);
            this.txtpDescricao.MaxLength = 60;
            this.txtpDescricao.Name = "txtpDescricao";
            this.txtpDescricao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpDescricao.Size = new System.Drawing.Size(290, 20);
            this.txtpDescricao.TabIndex = 8;
            this.txtpDescricao.Enter += new System.EventHandler(this.txtpDescricao_Enter);
            this.txtpDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpDescricao_KeyPress);
            this.txtpDescricao.Leave += new System.EventHandler(this.txtpDescricao_Leave);
            // 
            // txtpBarra
            // 
            this.txtpBarra.BackColor = System.Drawing.Color.White;
            this.txtpBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpBarra.Location = new System.Drawing.Point(579, 18);
            this.txtpBarra.MaxLength = 60;
            this.txtpBarra.Name = "txtpBarra";
            this.txtpBarra.Size = new System.Drawing.Size(175, 20);
            this.txtpBarra.TabIndex = 10;
            this.txtpBarra.Visible = false;
            this.txtpBarra.Enter += new System.EventHandler(this.txtpBarra_Enter);
            this.txtpBarra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpBarra_KeyPress);
            this.txtpBarra.Leave += new System.EventHandler(this.txtpBarra_Leave);
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
            // ttpProd
            // 
            this.ttpProd.AutoPopDelay = 5000;
            this.ttpProd.InitialDelay = 1000;
            this.ttpProd.IsBalloon = true;
            this.ttpProd.ReshowDelay = 100;
            this.ttpProd.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpProd.ToolTipTitle = "Dica:";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastrar.Image")));
            this.btnCadastrar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCadastrar.Location = new System.Drawing.Point(550, 282);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(86, 32);
            this.btnCadastrar.TabIndex = 107;
            this.btnCadastrar.Text = "&Cadastrar";
            this.btnCadastrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProd.SetToolTip(this.btnCadastrar, "Clique para cadastrar um Produto.");
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Visible = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            this.btnCadastrar.MouseLeave += new System.EventHandler(this.btnCadastrar_MouseLeave);
            this.btnCadastrar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCadastrar_MouseMove);
            // 
            // lblSaldoAtual
            // 
            this.lblSaldoAtual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSaldoAtual.BackColor = System.Drawing.Color.Transparent;
            this.lblSaldoAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoAtual.ForeColor = System.Drawing.Color.Black;
            this.lblSaldoAtual.Location = new System.Drawing.Point(170, 279);
            this.lblSaldoAtual.Name = "lblSaldoAtual";
            this.lblSaldoAtual.Size = new System.Drawing.Size(99, 26);
            this.lblSaldoAtual.TabIndex = 108;
            this.lblSaldoAtual.Text = "Saldo Atual:";
            this.lblSaldoAtual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSaldoAtual.Visible = false;
            // 
            // lblValorSaldo
            // 
            this.lblValorSaldo.BackColor = System.Drawing.Color.LightGray;
            this.lblValorSaldo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblValorSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorSaldo.ForeColor = System.Drawing.Color.Red;
            this.lblValorSaldo.Location = new System.Drawing.Point(265, 280);
            this.lblValorSaldo.Name = "lblValorSaldo";
            this.lblValorSaldo.Size = new System.Drawing.Size(115, 26);
            this.lblValorSaldo.TabIndex = 109;
            this.lblValorSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValorSaldo.Visible = false;
            this.lblValorSaldo.Click += new System.EventHandler(this.lblValorSaldo_Click);
            // 
            // FrmPesqProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(785, 320);
            this.ControlBox = false;
            this.Controls.Add(this.lblSaldoAtual);
            this.Controls.Add(this.lblValorSaldo);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.pcibAjudaFoto);
            this.Controls.Add(this.dtProd);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.lblLegendaImagem);
            this.Controls.Add(this.pcibImagem);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesqProduto";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Produtos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPesqProduto_FormClosing);
            this.Load += new System.EventHandler(this.FrmPesqProduto_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPesqProduto_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pcibAjudaFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.PictureBox pcibAjudaFoto;
        private System.Windows.Forms.DataGridView dtProd;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label lblLegendaImagem;
        private System.Windows.Forms.PictureBox pcibImagem;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnpProcurarSub1;
        private System.Windows.Forms.ComboBox cbbpSubGrupo;
        private System.Windows.Forms.Label lblSubGrupo1;
        private System.Windows.Forms.RadioButton rbtnReferencia;
        private System.Windows.Forms.Button btnpProcurar;
        private System.Windows.Forms.RadioButton rbtnPalavraChave;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.RadioButton rbtnGrupo;
        private System.Windows.Forms.RadioButton rbtnBarra;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnDescricao;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.TextBox txtpPalavraChave;
        private System.Windows.Forms.TextBox txtpBarra;
        private System.Windows.Forms.TextBox txtpDescricao;
        private System.Windows.Forms.ComboBox cbbpGrupo;
        private System.Windows.Forms.ToolTip ttpProd;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Label lblSaldoAtual;
        private System.Windows.Forms.Label lblValorSaldo;
    }
}