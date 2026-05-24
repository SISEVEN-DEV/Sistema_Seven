namespace Seven_Sistema
{
    partial class FrmMenuNFSe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuNFSe));
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.dtNFSe = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbSituacao = new System.Windows.Forms.ComboBox();
            this.txtNumeroNF = new System.Windows.Forms.TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.mtxtHorarioEmissao1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtHorarioEmissao = new System.Windows.Forms.MaskedTextBox();
            this.lblDataEntrada = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.mtxtpDataEmissao1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpDataEmissao = new System.Windows.Forms.MaskedTextBox();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.btnAbrirArquivo = new System.Windows.Forms.Button();
            this.btnCopiarChave = new System.Windows.Forms.Button();
            this.rtbRespostas = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSubstituir = new System.Windows.Forms.Button();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnTransmitir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConsultarNFSe = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblResposta = new System.Windows.Forms.Label();
            this.lblChave = new System.Windows.Forms.Label();
            this.mtxtChave = new System.Windows.Forms.MaskedTextBox();
            this.lblValorSituacao = new System.Windows.Forms.Label();
            this.lblCxSituacao = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.ttpMenuNFSe = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNFSe)).BeginInit();
            this.grbBox1.SuspendLayout();
            this.grbBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            this.SuspendLayout();
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao.Location = new System.Drawing.Point(799, 82);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 263;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorTotal.BackColor = System.Drawing.Color.White;
            this.lblValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotal.Enabled = false;
            this.lblValorTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotal.Location = new System.Drawing.Point(812, 294);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(95, 26);
            this.lblValorTotal.TabIndex = 0;
            this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotal.Click += new System.EventHandler(this.lblValorTotal_Click);
            this.lblValorTotal.MouseLeave += new System.EventHandler(this.lblValorTotal_MouseLeave);
            this.lblValorTotal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotal_MouseMove);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Enabled = false;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(663, 294);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(160, 26);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total das NFSe  (R$):";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(9, 294);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(141, 25);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPesquisar.Location = new System.Drawing.Point(825, 82);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 10;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMenuNFSe.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // dtNFSe
            // 
            this.dtNFSe.AllowUserToAddRows = false;
            this.dtNFSe.AllowUserToDeleteRows = false;
            this.dtNFSe.AllowUserToResizeRows = false;
            this.dtNFSe.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtNFSe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtNFSe.Enabled = false;
            this.dtNFSe.Location = new System.Drawing.Point(12, 120);
            this.dtNFSe.MultiSelect = false;
            this.dtNFSe.Name = "dtNFSe";
            this.dtNFSe.ReadOnly = true;
            this.dtNFSe.RowHeadersVisible = false;
            this.dtNFSe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtNFSe.ShowCellErrors = false;
            this.dtNFSe.ShowCellToolTips = false;
            this.dtNFSe.ShowEditingIcon = false;
            this.dtNFSe.ShowRowErrors = false;
            this.dtNFSe.Size = new System.Drawing.Size(895, 172);
            this.dtNFSe.TabIndex = 11;
            this.dtNFSe.TabStop = false;
            this.dtNFSe.DataSourceChanged += new System.EventHandler(this.dtNFSe_DataSourceChanged);
            this.dtNFSe.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtNFSe_CellEnter);
            this.dtNFSe.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtNFSe_CellFormatting);
            this.dtNFSe.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtNFSe_RowsAdded);
            this.dtNFSe.MouseLeave += new System.EventHandler(this.dtNFSe_MouseLeave);
            this.dtNFSe.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtNFSe_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.txtCodigo);
            this.grbBox1.Controls.Add(this.label2);
            this.grbBox1.Controls.Add(this.label1);
            this.grbBox1.Controls.Add(this.cbbSituacao);
            this.grbBox1.Controls.Add(this.txtNumeroNF);
            this.grbBox1.Controls.Add(this.lblNumero);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.mtxtHorarioEmissao1);
            this.grbBox1.Controls.Add(this.mtxtHorarioEmissao);
            this.grbBox1.Controls.Add(this.lblDataEntrada);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.mtxtpDataEmissao1);
            this.grbBox1.Controls.Add(this.mtxtpDataEmissao);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(895, 64);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(6, 32);
            this.txtCodigo.MaxLength = 10;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(89, 20);
            this.txtCodigo.TabIndex = 2;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.Enter += new System.EventHandler(this.txtCodigo_Enter);
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Código da O.S:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(766, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Situação:";
            // 
            // cbbSituacao
            // 
            this.cbbSituacao.BackColor = System.Drawing.Color.LightBlue;
            this.cbbSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSituacao.DropDownWidth = 115;
            this.cbbSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSituacao.FormattingEnabled = true;
            this.cbbSituacao.Items.AddRange(new object[] {
            "",
            "PENDENTE",
            "CANCELADA",
            "TRANSMITIDA"});
            this.cbbSituacao.Location = new System.Drawing.Point(769, 32);
            this.cbbSituacao.Name = "cbbSituacao";
            this.cbbSituacao.Size = new System.Drawing.Size(120, 21);
            this.cbbSituacao.TabIndex = 9;
            this.cbbSituacao.DropDown += new System.EventHandler(this.cbbSituacao_DropDown);
            this.cbbSituacao.DropDownClosed += new System.EventHandler(this.cbbSituacao_DropDownClosed);
            this.cbbSituacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbSituacao_KeyPress);
            this.cbbSituacao.MouseLeave += new System.EventHandler(this.cbbSituacao_MouseLeave);
            this.cbbSituacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbSituacao_MouseMove);
            // 
            // txtNumeroNF
            // 
            this.txtNumeroNF.BackColor = System.Drawing.Color.White;
            this.txtNumeroNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroNF.Location = new System.Drawing.Point(219, 32);
            this.txtNumeroNF.MaxLength = 10;
            this.txtNumeroNF.Name = "txtNumeroNF";
            this.txtNumeroNF.Size = new System.Drawing.Size(89, 20);
            this.txtNumeroNF.TabIndex = 3;
            this.txtNumeroNF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumeroNF.Enter += new System.EventHandler(this.txtNumeroNF_Enter);
            this.txtNumeroNF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroNF_KeyPress);
            this.txtNumeroNF.Leave += new System.EventHandler(this.txtNumeroNF_Leave);
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNumero.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNumero.Location = new System.Drawing.Point(211, 16);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(107, 13);
            this.lblNumero.TabIndex = 0;
            this.lblNumero.Text = "Número da NFSe:";
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(689, 29);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 8;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMenuNFSe.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // mtxtHorarioEmissao1
            // 
            this.mtxtHorarioEmissao1.BackColor = System.Drawing.Color.White;
            this.mtxtHorarioEmissao1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorarioEmissao1.Location = new System.Drawing.Point(626, 32);
            this.mtxtHorarioEmissao1.Mask = "00:00:00";
            this.mtxtHorarioEmissao1.Name = "mtxtHorarioEmissao1";
            this.mtxtHorarioEmissao1.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorarioEmissao1.TabIndex = 7;
            this.mtxtHorarioEmissao1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorarioEmissao1.DoubleClick += new System.EventHandler(this.mtxtHorarioEmissao1_DoubleClick);
            this.mtxtHorarioEmissao1.Enter += new System.EventHandler(this.mtxtHorarioEmissao1_Enter);
            this.mtxtHorarioEmissao1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorarioEmissao1_KeyPress);
            this.mtxtHorarioEmissao1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorarioEmissao1_KeyUp);
            this.mtxtHorarioEmissao1.Leave += new System.EventHandler(this.mtxtHorarioEmissao1_Leave);
            // 
            // mtxtHorarioEmissao
            // 
            this.mtxtHorarioEmissao.BackColor = System.Drawing.Color.White;
            this.mtxtHorarioEmissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorarioEmissao.Location = new System.Drawing.Point(447, 32);
            this.mtxtHorarioEmissao.Mask = "00:00:00";
            this.mtxtHorarioEmissao.Name = "mtxtHorarioEmissao";
            this.mtxtHorarioEmissao.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorarioEmissao.TabIndex = 5;
            this.mtxtHorarioEmissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorarioEmissao.DoubleClick += new System.EventHandler(this.mtxtHorarioEmissao_DoubleClick);
            this.mtxtHorarioEmissao.Enter += new System.EventHandler(this.mtxtHorarioEmissao_Enter);
            this.mtxtHorarioEmissao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorarioEmissao_KeyPress);
            this.mtxtHorarioEmissao.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorarioEmissao_KeyUp);
            this.mtxtHorarioEmissao.Leave += new System.EventHandler(this.mtxtHorarioEmissao_Leave);
            // 
            // lblDataEntrada
            // 
            this.lblDataEntrada.AutoSize = true;
            this.lblDataEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataEntrada.Location = new System.Drawing.Point(478, 16);
            this.lblDataEntrada.Name = "lblDataEntrada";
            this.lblDataEntrada.Size = new System.Drawing.Size(94, 13);
            this.lblDataEntrada.TabIndex = 0;
            this.lblDataEntrada.Text = "Data e Horário:";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(510, 35);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // mtxtpDataEmissao1
            // 
            this.mtxtpDataEmissao1.BackColor = System.Drawing.Color.White;
            this.mtxtpDataEmissao1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpDataEmissao1.Location = new System.Drawing.Point(542, 32);
            this.mtxtpDataEmissao1.Mask = "00/00/0000";
            this.mtxtpDataEmissao1.Name = "mtxtpDataEmissao1";
            this.mtxtpDataEmissao1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpDataEmissao1.TabIndex = 6;
            this.mtxtpDataEmissao1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpDataEmissao1.DoubleClick += new System.EventHandler(this.mtxtpDataEmissao1_DoubleClick);
            this.mtxtpDataEmissao1.Enter += new System.EventHandler(this.mtxtpDataEmissao1_Enter);
            this.mtxtpDataEmissao1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpDataEmissao1_KeyPress);
            this.mtxtpDataEmissao1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpDataEmissao1_KeyUp);
            this.mtxtpDataEmissao1.Leave += new System.EventHandler(this.mtxtpDataEmissao1_Leave);
            // 
            // mtxtpDataEmissao
            // 
            this.mtxtpDataEmissao.BackColor = System.Drawing.Color.White;
            this.mtxtpDataEmissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpDataEmissao.Location = new System.Drawing.Point(363, 32);
            this.mtxtpDataEmissao.Mask = "00/00/0000";
            this.mtxtpDataEmissao.Name = "mtxtpDataEmissao";
            this.mtxtpDataEmissao.Size = new System.Drawing.Size(78, 20);
            this.mtxtpDataEmissao.TabIndex = 4;
            this.mtxtpDataEmissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpDataEmissao.DoubleClick += new System.EventHandler(this.mtxtpDataEmissao_DoubleClick);
            this.mtxtpDataEmissao.Enter += new System.EventHandler(this.mtxtpDataEmissao_Enter);
            this.mtxtpDataEmissao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpDataEmissao_KeyPress);
            this.mtxtpDataEmissao.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpDataEmissao_KeyUp);
            this.mtxtpDataEmissao.Leave += new System.EventHandler(this.mtxtpDataEmissao_Leave);
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.btnAbrirArquivo);
            this.grbBox2.Controls.Add(this.btnCopiarChave);
            this.grbBox2.Controls.Add(this.rtbRespostas);
            this.grbBox2.Controls.Add(this.groupBox1);
            this.grbBox2.Controls.Add(this.lblResposta);
            this.grbBox2.Controls.Add(this.lblChave);
            this.grbBox2.Controls.Add(this.mtxtChave);
            this.grbBox2.Controls.Add(this.lblValorSituacao);
            this.grbBox2.Controls.Add(this.lblCxSituacao);
            this.grbBox2.Location = new System.Drawing.Point(12, 323);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(895, 167);
            this.grbBox2.TabIndex = 12;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Ações:";
            // 
            // btnAbrirArquivo
            // 
            this.btnAbrirArquivo.Enabled = false;
            this.btnAbrirArquivo.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrirArquivo.Image")));
            this.btnAbrirArquivo.Location = new System.Drawing.Point(861, 30);
            this.btnAbrirArquivo.Name = "btnAbrirArquivo";
            this.btnAbrirArquivo.Size = new System.Drawing.Size(26, 25);
            this.btnAbrirArquivo.TabIndex = 15;
            this.btnAbrirArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAbrirArquivo.UseVisualStyleBackColor = true;
            this.btnAbrirArquivo.Visible = false;
            this.btnAbrirArquivo.MouseLeave += new System.EventHandler(this.btnAbrirArquivo_MouseLeave);
            this.btnAbrirArquivo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAbrirArquivo_MouseMove);
            // 
            // btnCopiarChave
            // 
            this.btnCopiarChave.Enabled = false;
            this.btnCopiarChave.Image = ((System.Drawing.Image)(resources.GetObject("btnCopiarChave.Image")));
            this.btnCopiarChave.Location = new System.Drawing.Point(441, 30);
            this.btnCopiarChave.Name = "btnCopiarChave";
            this.btnCopiarChave.Size = new System.Drawing.Size(26, 25);
            this.btnCopiarChave.TabIndex = 13;
            this.btnCopiarChave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCopiarChave.UseVisualStyleBackColor = true;
            this.btnCopiarChave.Visible = false;
            this.btnCopiarChave.MouseLeave += new System.EventHandler(this.btnCopiarChave_MouseLeave);
            this.btnCopiarChave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCopiarChave_MouseMove);
            // 
            // rtbRespostas
            // 
            this.rtbRespostas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbRespostas.Location = new System.Drawing.Point(6, 61);
            this.rtbRespostas.Name = "rtbRespostas";
            this.rtbRespostas.ReadOnly = true;
            this.rtbRespostas.Size = new System.Drawing.Size(433, 97);
            this.rtbRespostas.TabIndex = 17;
            this.rtbRespostas.Text = "";
            this.rtbRespostas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbRespostas_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSubstituir);
            this.groupBox1.Controls.Add(this.picbInterrogacao2);
            this.groupBox1.Controls.Add(this.btnTransmitir);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnConsultarNFSe);
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Location = new System.Drawing.Point(445, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 100);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // btnSubstituir
            // 
            this.btnSubstituir.Enabled = false;
            this.btnSubstituir.Image = ((System.Drawing.Image)(resources.GetObject("btnSubstituir.Image")));
            this.btnSubstituir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSubstituir.Location = new System.Drawing.Point(130, 57);
            this.btnSubstituir.Name = "btnSubstituir";
            this.btnSubstituir.Size = new System.Drawing.Size(85, 32);
            this.btnSubstituir.TabIndex = 271;
            this.btnSubstituir.Text = "&Su&bstituir";
            this.btnSubstituir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMenuNFSe.SetToolTip(this.btnSubstituir, "Clique para Transmitir a NFSe selecionada.");
            this.btnSubstituir.UseVisualStyleBackColor = true;
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(6, 78);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 270;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // btnTransmitir
            // 
            this.btnTransmitir.Enabled = false;
            this.btnTransmitir.Image = ((System.Drawing.Image)(resources.GetObject("btnTransmitir.Image")));
            this.btnTransmitir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnTransmitir.Location = new System.Drawing.Point(86, 19);
            this.btnTransmitir.Name = "btnTransmitir";
            this.btnTransmitir.Size = new System.Drawing.Size(85, 32);
            this.btnTransmitir.TabIndex = 17;
            this.btnTransmitir.Text = "&Transmitir";
            this.btnTransmitir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMenuNFSe.SetToolTip(this.btnTransmitir, "Clique para Transmitir a NFSe selecionada.");
            this.btnTransmitir.UseVisualStyleBackColor = true;
            this.btnTransmitir.Click += new System.EventHandler(this.btnTransmitir_Click);
            this.btnTransmitir.MouseLeave += new System.EventHandler(this.btnTransmitir_MouseLeave);
            this.btnTransmitir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnTransmitir_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.Location = new System.Drawing.Point(297, 19);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancela&r";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            this.btnCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelar_MouseMove);
            // 
            // btnConsultarNFSe
            // 
            this.btnConsultarNFSe.Enabled = false;
            this.btnConsultarNFSe.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultarNFSe.Image")));
            this.btnConsultarNFSe.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnConsultarNFSe.Location = new System.Drawing.Point(177, 19);
            this.btnConsultarNFSe.Name = "btnConsultarNFSe";
            this.btnConsultarNFSe.Size = new System.Drawing.Size(114, 32);
            this.btnConsultarNFSe.TabIndex = 18;
            this.btnConsultarNFSe.Text = "&Consultar NFSe";
            this.btnConsultarNFSe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMenuNFSe.SetToolTip(this.btnConsultarNFSe, "Clique para Consultar a NFSe slecionada.");
            this.btnConsultarNFSe.UseVisualStyleBackColor = true;
            this.btnConsultarNFSe.Click += new System.EventHandler(this.btnConsultarDFe_Click);
            this.btnConsultarNFSe.MouseLeave += new System.EventHandler(this.btnConsultarDFe_MouseLeave);
            this.btnConsultarNFSe.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnConsultarDFe_MouseMove);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnImprimir.Location = new System.Drawing.Point(221, 57);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(116, 32);
            this.btnImprimir.TabIndex = 21;
            this.btnImprimir.Text = "&Imprimir NFSe";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.MouseLeave += new System.EventHandler(this.btnImprimir_MouseLeave);
            this.btnImprimir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnImprimir_MouseMove);
            // 
            // lblResposta
            // 
            this.lblResposta.AutoSize = true;
            this.lblResposta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResposta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblResposta.Location = new System.Drawing.Point(6, 45);
            this.lblResposta.Name = "lblResposta";
            this.lblResposta.Size = new System.Drawing.Size(116, 13);
            this.lblResposta.TabIndex = 0;
            this.lblResposta.Text = "Resposta do Provedor:";
            // 
            // lblChave
            // 
            this.lblChave.AutoSize = true;
            this.lblChave.Enabled = false;
            this.lblChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblChave.Location = new System.Drawing.Point(470, 16);
            this.lblChave.Name = "lblChave";
            this.lblChave.Size = new System.Drawing.Size(41, 13);
            this.lblChave.TabIndex = 0;
            this.lblChave.Text = "Chave:";
            this.lblChave.Visible = false;
            // 
            // mtxtChave
            // 
            this.mtxtChave.BackColor = System.Drawing.Color.White;
            this.mtxtChave.Enabled = false;
            this.mtxtChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtChave.Location = new System.Drawing.Point(473, 32);
            this.mtxtChave.Mask = "00-0000-00,000,000/0000-00-00-000-000,000,000-0-00,000,000-0";
            this.mtxtChave.Name = "mtxtChave";
            this.mtxtChave.ReadOnly = true;
            this.mtxtChave.Size = new System.Drawing.Size(384, 20);
            this.mtxtChave.TabIndex = 14;
            this.mtxtChave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtChave.Visible = false;
            // 
            // lblValorSituacao
            // 
            this.lblValorSituacao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorSituacao.BackColor = System.Drawing.Color.Transparent;
            this.lblValorSituacao.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorSituacao.ForeColor = System.Drawing.Color.Black;
            this.lblValorSituacao.Location = new System.Drawing.Point(34, 19);
            this.lblValorSituacao.Name = "lblValorSituacao";
            this.lblValorSituacao.Size = new System.Drawing.Size(110, 26);
            this.lblValorSituacao.TabIndex = 0;
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
            this.lblCxSituacao.Location = new System.Drawing.Point(6, 22);
            this.lblCxSituacao.Name = "lblCxSituacao";
            this.lblCxSituacao.Size = new System.Drawing.Size(22, 20);
            this.lblCxSituacao.TabIndex = 0;
            this.lblCxSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCxSituacao.Visible = false;
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(852, 496);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 265;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMenuNFSe.SetToolTip(this.btnSair, "Clique para sair do Menu NFSe.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // ttpMenuNFSe
            // 
            this.ttpMenuNFSe.AutoPopDelay = 5000;
            this.ttpMenuNFSe.InitialDelay = 1000;
            this.ttpMenuNFSe.IsBalloon = true;
            this.ttpMenuNFSe.ReshowDelay = 100;
            this.ttpMenuNFSe.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpMenuNFSe.ToolTipTitle = "Dica:";
            // 
            // FrmMenuNFSe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(918, 534);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.dtNFSe);
            this.Controls.Add(this.grbBox2);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenuNFSe";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu NFSe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenuNFSe_FormClosing);
            this.Load += new System.EventHandler(this.FrmMenuNFSe_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmMenuNFSe_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNFSe)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.DataGridView dtNFSe;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbSituacao;
        private System.Windows.Forms.TextBox txtNumeroNF;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.MaskedTextBox mtxtHorarioEmissao1;
        private System.Windows.Forms.MaskedTextBox mtxtHorarioEmissao;
        private System.Windows.Forms.Label lblDataEntrada;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.MaskedTextBox mtxtpDataEmissao1;
        private System.Windows.Forms.MaskedTextBox mtxtpDataEmissao;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnAbrirArquivo;
        private System.Windows.Forms.Button btnCopiarChave;
        private System.Windows.Forms.RichTextBox rtbRespostas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Button btnTransmitir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConsultarNFSe;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblResposta;
        private System.Windows.Forms.Label lblChave;
        private System.Windows.Forms.MaskedTextBox mtxtChave;
        private System.Windows.Forms.Label lblValorSituacao;
        private System.Windows.Forms.Label lblCxSituacao;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip ttpMenuNFSe;
        private System.Windows.Forms.Button btnSubstituir;
    }
}