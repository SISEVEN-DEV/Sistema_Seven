namespace Seven_Sistema
{
    partial class FrmPesqDFe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesqDFe));
            this.lblRegistros = new System.Windows.Forms.Label();
            this.dtPesquisa = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnChave = new System.Windows.Forms.RadioButton();
            this.lblAte = new System.Windows.Forms.Label();
            this.rbtnNumeroNF = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnDataEmissao = new System.Windows.Forms.RadioButton();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.txtpPalavraChave = new System.Windows.Forms.TextBox();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.mtxtChave = new System.Windows.Forms.MaskedTextBox();
            this.btnConsultarItens = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.ttpDFe = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtPesquisa)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(9, 272);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(164, 26);
            this.lblRegistros.TabIndex = 152;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtPesquisa
            // 
            this.dtPesquisa.AllowUserToAddRows = false;
            this.dtPesquisa.AllowUserToDeleteRows = false;
            this.dtPesquisa.AllowUserToOrderColumns = true;
            this.dtPesquisa.AllowUserToResizeRows = false;
            this.dtPesquisa.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtPesquisa.Enabled = false;
            this.dtPesquisa.Location = new System.Drawing.Point(12, 97);
            this.dtPesquisa.MultiSelect = false;
            this.dtPesquisa.Name = "dtPesquisa";
            this.dtPesquisa.ReadOnly = true;
            this.dtPesquisa.RowHeadersVisible = false;
            this.dtPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtPesquisa.ShowCellErrors = false;
            this.dtPesquisa.ShowCellToolTips = false;
            this.dtPesquisa.ShowEditingIcon = false;
            this.dtPesquisa.ShowRowErrors = false;
            this.dtPesquisa.Size = new System.Drawing.Size(739, 172);
            this.dtPesquisa.TabIndex = 14;
            this.dtPesquisa.DataSourceChanged += new System.EventHandler(this.dtPesquisa_DataSourceChanged);
            this.dtPesquisa.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtPesquisa_CellEnter);
            this.dtPesquisa.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtPesquisa_CellFormatting);
            this.dtPesquisa.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtPesquisa_RowsAdded);
            this.dtPesquisa.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtPesquisa_RowsRemoved);
            this.dtPesquisa.DoubleClick += new System.EventHandler(this.dtPesquisa_DoubleClick);
            this.dtPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtPesquisa_KeyDown);
            this.dtPesquisa.MouseLeave += new System.EventHandler(this.dtPesquisa_MouseLeave);
            this.dtPesquisa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtPesquisa_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnChave);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.rbtnNumeroNF);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnDataEmissao);
            this.grbBox1.Controls.Add(this.picbInterrogacao1);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.txtpPalavraChave);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.mtxtChave);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(739, 79);
            this.grbBox1.TabIndex = 147;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnChave
            // 
            this.rbtnChave.AutoSize = true;
            this.rbtnChave.Location = new System.Drawing.Point(114, 40);
            this.rbtnChave.Name = "rbtnChave";
            this.rbtnChave.Size = new System.Drawing.Size(56, 17);
            this.rbtnChave.TabIndex = 36;
            this.rbtnChave.Text = "Chave";
            this.rbtnChave.UseVisualStyleBackColor = true;
            this.rbtnChave.CheckedChanged += new System.EventHandler(this.rbtnChave_CheckedChanged);
            this.rbtnChave.MouseLeave += new System.EventHandler(this.rbtnChave_MouseLeave);
            this.rbtnChave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnChave_MouseMove);
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(591, 19);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // rbtnNumeroNF
            // 
            this.rbtnNumeroNF.AutoSize = true;
            this.rbtnNumeroNF.Location = new System.Drawing.Point(6, 40);
            this.rbtnNumeroNF.Name = "rbtnNumeroNF";
            this.rbtnNumeroNF.Size = new System.Drawing.Size(94, 17);
            this.rbtnNumeroNF.TabIndex = 4;
            this.rbtnNumeroNF.Text = "Número da NF";
            this.rbtnNumeroNF.UseVisualStyleBackColor = true;
            this.rbtnNumeroNF.CheckedChanged += new System.EventHandler(this.rbtnNumeroNF_CheckedChanged);
            this.rbtnNumeroNF.MouseLeave += new System.EventHandler(this.rbtnConsumidor_MouseLeave);
            this.rbtnNumeroNF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnConsumidor_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Location = new System.Drawing.Point(178, 17);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 5;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Location = new System.Drawing.Point(114, 17);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 3;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // rbtnDataEmissao
            // 
            this.rbtnDataEmissao.AutoSize = true;
            this.rbtnDataEmissao.Location = new System.Drawing.Point(6, 17);
            this.rbtnDataEmissao.Name = "rbtnDataEmissao";
            this.rbtnDataEmissao.Size = new System.Drawing.Size(105, 17);
            this.rbtnDataEmissao.TabIndex = 2;
            this.rbtnDataEmissao.Text = "Data de Emissão";
            this.rbtnDataEmissao.UseVisualStyleBackColor = true;
            this.rbtnDataEmissao.CheckedChanged += new System.EventHandler(this.rbtnDataCriacao_CheckedChanged);
            this.rbtnDataEmissao.MouseLeave += new System.EventHandler(this.rbtnDataCriacao_MouseLeave);
            this.rbtnDataEmissao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnDataCriacao_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(622, 42);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 35;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(648, 42);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(85, 32);
            this.btnPesquisar.TabIndex = 13;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDFe.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(405, 19);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(96, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite as datas:";
            // 
            // mtxtpData
            // 
            this.mtxtpData.BackColor = System.Drawing.Color.White;
            this.mtxtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData.Location = new System.Drawing.Point(507, 16);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 6;
            this.mtxtpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData.DoubleClick += new System.EventHandler(this.mtxtpData_DoubleClick);
            this.mtxtpData.Enter += new System.EventHandler(this.mtxtpData_Enter);
            this.mtxtpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData_KeyPress);
            this.mtxtpData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData_KeyUp);
            this.mtxtpData.Leave += new System.EventHandler(this.mtxtpData_Leave);
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(623, 16);
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
            // txtpPalavraChave
            // 
            this.txtpPalavraChave.BackColor = System.Drawing.Color.White;
            this.txtpPalavraChave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpPalavraChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpPalavraChave.Location = new System.Drawing.Point(655, 16);
            this.txtpPalavraChave.MaxLength = 10;
            this.txtpPalavraChave.Name = "txtpPalavraChave";
            this.txtpPalavraChave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpPalavraChave.Size = new System.Drawing.Size(78, 20);
            this.txtpPalavraChave.TabIndex = 15;
            this.txtpPalavraChave.Visible = false;
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(653, 16);
            this.txtpCodigo.MaxLength = 10;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtpCodigo.TabIndex = 8;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(707, 13);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 10;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDFe.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // mtxtChave
            // 
            this.mtxtChave.BackColor = System.Drawing.Color.White;
            this.mtxtChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtChave.Location = new System.Drawing.Point(349, 16);
            this.mtxtChave.Mask = "00-0000-00,000,000/0000-00-00-000-000,000,000-0-00,000,000-0";
            this.mtxtChave.Name = "mtxtChave";
            this.mtxtChave.Size = new System.Drawing.Size(384, 20);
            this.mtxtChave.TabIndex = 12;
            this.mtxtChave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtChave.Visible = false;
            this.mtxtChave.Enter += new System.EventHandler(this.mtxtChave_Enter);
            this.mtxtChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtChave_KeyPress);
            this.mtxtChave.Leave += new System.EventHandler(this.mtxtChave_Leave);
            // 
            // btnConsultarItens
            // 
            this.btnConsultarItens.Enabled = false;
            this.btnConsultarItens.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultarItens.Image")));
            this.btnConsultarItens.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultarItens.Location = new System.Drawing.Point(322, 275);
            this.btnConsultarItens.Name = "btnConsultarItens";
            this.btnConsultarItens.Size = new System.Drawing.Size(105, 25);
            this.btnConsultarItens.TabIndex = 15;
            this.btnConsultarItens.Text = "&Consultar Itens";
            this.btnConsultarItens.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDFe.SetToolTip(this.btnConsultarItens, "Clique para consultar os itens do registro selecionado.");
            this.btnConsultarItens.UseVisualStyleBackColor = true;
            this.btnConsultarItens.Click += new System.EventHandler(this.btnConsultarItens_Click);
            this.btnConsultarItens.MouseLeave += new System.EventHandler(this.btnConsultarItens_MouseLeave);
            this.btnConsultarItens.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnConsultarItens_MouseMove);
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(696, 275);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 17;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDFe.SetToolTip(this.btnVoltar, "Sair de Pesquisar DFe.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Enabled = false;
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(620, 275);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(70, 32);
            this.btnIncluir.TabIndex = 16;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpDFe.SetToolTip(this.btnIncluir, "Clique para incluir os dados.");
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            this.btnIncluir.MouseLeave += new System.EventHandler(this.btnIncluir_MouseLeave);
            this.btnIncluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnIncluir_MouseMove);
            // 
            // ttpDFe
            // 
            this.ttpDFe.AutoPopDelay = 5000;
            this.ttpDFe.InitialDelay = 1000;
            this.ttpDFe.IsBalloon = true;
            this.ttpDFe.ReshowDelay = 100;
            this.ttpDFe.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpDFe.ToolTipTitle = "Dica:";
            // 
            // FrmPesqDFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(760, 313);
            this.ControlBox = false;
            this.Controls.Add(this.btnConsultarItens);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.dtPesquisa);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesqDFe";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar DFe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPesqDFe_FormClosing);
            this.Load += new System.EventHandler(this.FrmPesqDFe_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPesqDFe_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtPesquisa)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConsultarItens;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.DataGridView dtPesquisa;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.RadioButton rbtnNumeroNF;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnDataEmissao;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.TextBox txtpPalavraChave;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.ToolTip ttpDFe;
        private System.Windows.Forms.RadioButton rbtnChave;
        private System.Windows.Forms.MaskedTextBox mtxtChave;
    }
}