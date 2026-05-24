namespace Seven_Sistema
{
    partial class FrmRelFluxoCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelFluxoCaixa));
            this.ttpFluxo = new System.Windows.Forms.ToolTip(this.components);
            this.btnRelatorioPDF = new System.Windows.Forms.Button();
            this.btnExportarCsv = new System.Windows.Forms.Button();
            this.rbtnExportarTxt = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnProcurar1 = new System.Windows.Forms.Button();
            this.btnProcurarUsuario = new System.Windows.Forms.Button();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.dtFluxo = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblDatas = new System.Windows.Forms.Label();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.lblCodPDV = new System.Windows.Forms.Label();
            this.cbbCodPDV = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.mtxtHorario1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtHorario = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.cbbUsuario = new System.Windows.Forms.ComboBox();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.lblValorEntrada = new System.Windows.Forms.Label();
            this.lblEntrada = new System.Windows.Forms.Label();
            this.lblValorSaida = new System.Windows.Forms.Label();
            this.lblSaida = new System.Windows.Forms.Label();
            this.lblValorSaldo = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.pEnabled = new System.Windows.Forms.Panel();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cbbpTipo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtFluxo)).BeginInit();
            this.grbBox1.SuspendLayout();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.pEnabled.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttpFluxo
            // 
            this.ttpFluxo.IsBalloon = true;
            this.ttpFluxo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpFluxo.ToolTipTitle = "Dica:";
            // 
            // btnRelatorioPDF
            // 
            this.btnRelatorioPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorioPDF.Image")));
            this.btnRelatorioPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorioPDF.Location = new System.Drawing.Point(6, 19);
            this.btnRelatorioPDF.Name = "btnRelatorioPDF";
            this.btnRelatorioPDF.Size = new System.Drawing.Size(116, 25);
            this.btnRelatorioPDF.TabIndex = 17;
            this.btnRelatorioPDF.Text = "&Relatório em PDF";
            this.btnRelatorioPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFluxo.SetToolTip(this.btnRelatorioPDF, "Relatório das Informações em PDF");
            this.btnRelatorioPDF.UseVisualStyleBackColor = true;
            this.btnRelatorioPDF.Click += new System.EventHandler(this.btnRelatorioPDF_Click);
            this.btnRelatorioPDF.MouseLeave += new System.EventHandler(this.btnImprimir_MouseLeave);
            this.btnRelatorioPDF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnImprimir_MouseMove);
            // 
            // btnExportarCsv
            // 
            this.btnExportarCsv.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarCsv.Image")));
            this.btnExportarCsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarCsv.Location = new System.Drawing.Point(356, 19);
            this.btnExportarCsv.Name = "btnExportarCsv";
            this.btnExportarCsv.Size = new System.Drawing.Size(135, 25);
            this.btnExportarCsv.TabIndex = 18;
            this.btnExportarCsv.Text = "Exp. dados para (.cs&v)";
            this.btnExportarCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFluxo.SetToolTip(this.btnExportarCsv, "Gerar arquivo da grade de dados em (.csv)(Excel).");
            this.btnExportarCsv.UseVisualStyleBackColor = true;
            this.btnExportarCsv.Click += new System.EventHandler(this.btnExportarCsv_Click);
            this.btnExportarCsv.MouseLeave += new System.EventHandler(this.btnExportarCsv_MouseLeave);
            this.btnExportarCsv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExportarCsv_MouseMove);
            // 
            // rbtnExportarTxt
            // 
            this.rbtnExportarTxt.Image = ((System.Drawing.Image)(resources.GetObject("rbtnExportarTxt.Image")));
            this.rbtnExportarTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtnExportarTxt.Location = new System.Drawing.Point(682, 19);
            this.rbtnExportarTxt.Name = "rbtnExportarTxt";
            this.rbtnExportarTxt.Size = new System.Drawing.Size(133, 25);
            this.rbtnExportarTxt.TabIndex = 19;
            this.rbtnExportarTxt.Text = "Exp. d&ados para (.txt)";
            this.rbtnExportarTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFluxo.SetToolTip(this.rbtnExportarTxt, "Gerar arquivo da grade de dados em (.txt)(Bloco de Notas).");
            this.rbtnExportarTxt.UseVisualStyleBackColor = true;
            this.rbtnExportarTxt.Click += new System.EventHandler(this.rbtnExportarTxt_Click);
            this.rbtnExportarTxt.MouseLeave += new System.EventHandler(this.rbtnExportarTxt_MouseLeave);
            this.rbtnExportarTxt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnExportarTxt_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(789, 460);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(54, 32);
            this.btnSair.TabIndex = 20;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFluxo.SetToolTip(this.btnSair, "Sair do Relatório de Fluxo de Caixa.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(761, 140);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 14;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFluxo.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // btnProcurar1
            // 
            this.btnProcurar1.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurar1.Image")));
            this.btnProcurar1.Location = new System.Drawing.Point(791, 53);
            this.btnProcurar1.Name = "btnProcurar1";
            this.btnProcurar1.Size = new System.Drawing.Size(26, 25);
            this.btnProcurar1.TabIndex = 13;
            this.btnProcurar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFluxo.SetToolTip(this.btnProcurar1, "Clique para pesquisar um Computador/PDV.");
            this.btnProcurar1.UseVisualStyleBackColor = true;
            this.btnProcurar1.Click += new System.EventHandler(this.btnProcurar1_Click);
            this.btnProcurar1.MouseLeave += new System.EventHandler(this.btnProcurar1_MouseLeave);
            this.btnProcurar1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurar1_MouseMove);
            // 
            // btnProcurarUsuario
            // 
            this.btnProcurarUsuario.Enabled = false;
            this.btnProcurarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarUsuario.Image")));
            this.btnProcurarUsuario.Location = new System.Drawing.Point(673, 53);
            this.btnProcurarUsuario.Name = "btnProcurarUsuario";
            this.btnProcurarUsuario.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarUsuario.TabIndex = 11;
            this.btnProcurarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFluxo.SetToolTip(this.btnProcurarUsuario, "Clique para pesquisar um Usuário.");
            this.btnProcurarUsuario.UseVisualStyleBackColor = true;
            this.btnProcurarUsuario.Click += new System.EventHandler(this.btnProcurarUsuario_Click);
            this.btnProcurarUsuario.MouseLeave += new System.EventHandler(this.btnProcurarUsuario_MouseLeave);
            this.btnProcurarUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarUsuario_MouseMove);
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(332, 52);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 9;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFluxo.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(293, 251);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(300, 33);
            this.lblProgresso.TabIndex = 0;
            this.lblProgresso.Text = "Por favor, aguarde...";
            this.lblProgresso.Visible = false;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.pgbProgresso.Location = new System.Drawing.Point(284, 284);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(320, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 0;
            this.pgbProgresso.Visible = false;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(19, 375);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtFluxo
            // 
            this.dtFluxo.AllowUserToAddRows = false;
            this.dtFluxo.AllowUserToDeleteRows = false;
            this.dtFluxo.AllowUserToResizeRows = false;
            this.dtFluxo.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtFluxo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtFluxo.Location = new System.Drawing.Point(22, 178);
            this.dtFluxo.MultiSelect = false;
            this.dtFluxo.Name = "dtFluxo";
            this.dtFluxo.ReadOnly = true;
            this.dtFluxo.RowHeadersVisible = false;
            this.dtFluxo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtFluxo.ShowCellErrors = false;
            this.dtFluxo.ShowCellToolTips = false;
            this.dtFluxo.ShowEditingIcon = false;
            this.dtFluxo.ShowRowErrors = false;
            this.dtFluxo.Size = new System.Drawing.Size(821, 194);
            this.dtFluxo.TabIndex = 15;
            this.dtFluxo.DataSourceChanged += new System.EventHandler(this.dtFluxo_DataSourceChanged);
            this.dtFluxo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtFluxo_CellEnter);
            this.dtFluxo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtFluxo_CellFormatting);
            this.dtFluxo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtFluxo_RowsAdded);
            this.dtFluxo.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtFluxo_RowsRemoved);
            this.dtFluxo.MouseLeave += new System.EventHandler(this.dtFluxo_MouseLeave);
            this.dtFluxo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtFluxo_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblTipo);
            this.grbBox1.Controls.Add(this.cbbpTipo);
            this.grbBox1.Controls.Add(this.lblDatas);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.btnProcurar1);
            this.grbBox1.Controls.Add(this.btnProcurarUsuario);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.lblCodPDV);
            this.grbBox1.Controls.Add(this.cbbCodPDV);
            this.grbBox1.Controls.Add(this.lblUsuario);
            this.grbBox1.Controls.Add(this.mtxtHorario1);
            this.grbBox1.Controls.Add(this.mtxtHorario);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.cbbUsuario);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Location = new System.Drawing.Point(22, 50);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(821, 84);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // lblDatas
            // 
            this.lblDatas.AutoSize = true;
            this.lblDatas.Enabled = false;
            this.lblDatas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatas.Location = new System.Drawing.Point(3, 39);
            this.lblDatas.Name = "lblDatas";
            this.lblDatas.Size = new System.Drawing.Size(108, 13);
            this.lblDatas.TabIndex = 0;
            this.lblDatas.Text = "Escolha as datas:";
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(70, 19);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 3;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnDataAbertura_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnData_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnData_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(6, 19);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 2;
            this.rbtnCodigo.TabStop = true;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // lblCodPDV
            // 
            this.lblCodPDV.AutoSize = true;
            this.lblCodPDV.Enabled = false;
            this.lblCodPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodPDV.Location = new System.Drawing.Point(724, 39);
            this.lblCodPDV.Name = "lblCodPDV";
            this.lblCodPDV.Size = new System.Drawing.Size(96, 13);
            this.lblCodPDV.TabIndex = 0;
            this.lblCodPDV.Text = "Escolha o PDV:";
            // 
            // cbbCodPDV
            // 
            this.cbbCodPDV.BackColor = System.Drawing.Color.LightBlue;
            this.cbbCodPDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCodPDV.DropDownWidth = 80;
            this.cbbCodPDV.Enabled = false;
            this.cbbCodPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCodPDV.FormattingEnabled = true;
            this.cbbCodPDV.Location = new System.Drawing.Point(727, 55);
            this.cbbCodPDV.Name = "cbbCodPDV";
            this.cbbCodPDV.Size = new System.Drawing.Size(58, 21);
            this.cbbCodPDV.TabIndex = 12;
            this.cbbCodPDV.DropDown += new System.EventHandler(this.cbbCodPDV_DropDown);
            this.cbbCodPDV.DropDownClosed += new System.EventHandler(this.cbbCodPDV_DropDownClosed);
            this.cbbCodPDV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbCodPDV_KeyPress);
            this.cbbCodPDV.MouseLeave += new System.EventHandler(this.cbbCodPDV_MouseLeave);
            this.cbbCodPDV.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbCodPDV_MouseMove);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Enabled = false;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(551, 39);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(114, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Escolha o Usuário:";
            // 
            // mtxtHorario1
            // 
            this.mtxtHorario1.BackColor = System.Drawing.Color.White;
            this.mtxtHorario1.Enabled = false;
            this.mtxtHorario1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorario1.Location = new System.Drawing.Point(269, 55);
            this.mtxtHorario1.Mask = "00:00:00";
            this.mtxtHorario1.Name = "mtxtHorario1";
            this.mtxtHorario1.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario1.TabIndex = 8;
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
            this.mtxtHorario.Enabled = false;
            this.mtxtHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorario.Location = new System.Drawing.Point(90, 55);
            this.mtxtHorario.Mask = "00:00:00";
            this.mtxtHorario.Name = "mtxtHorario";
            this.mtxtHorario.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario.TabIndex = 6;
            this.mtxtHorario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorario.DoubleClick += new System.EventHandler(this.mtxtHorario_DoubleClick);
            this.mtxtHorario.Enter += new System.EventHandler(this.mtxtHorario_Enter);
            this.mtxtHorario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorario_KeyPress);
            this.mtxtHorario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorario_KeyUp);
            this.mtxtHorario.Leave += new System.EventHandler(this.mtxtHorario_Leave);
            // 
            // mtxtpData
            // 
            this.mtxtpData.BackColor = System.Drawing.Color.White;
            this.mtxtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData.Location = new System.Drawing.Point(6, 55);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 5;
            this.mtxtpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData.DoubleClick += new System.EventHandler(this.mtxtpData_DoubleClick);
            this.mtxtpData.Enter += new System.EventHandler(this.mtxtpData_Enter);
            this.mtxtpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData_KeyPress);
            this.mtxtpData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData_KeyUp);
            this.mtxtpData.Leave += new System.EventHandler(this.mtxtpData_Leave);
            // 
            // cbbUsuario
            // 
            this.cbbUsuario.BackColor = System.Drawing.Color.LightBlue;
            this.cbbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUsuario.DropDownWidth = 180;
            this.cbbUsuario.Enabled = false;
            this.cbbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUsuario.FormattingEnabled = true;
            this.cbbUsuario.Location = new System.Drawing.Point(554, 55);
            this.cbbUsuario.Name = "cbbUsuario";
            this.cbbUsuario.Size = new System.Drawing.Size(113, 21);
            this.cbbUsuario.TabIndex = 10;
            this.cbbUsuario.DropDown += new System.EventHandler(this.cbbUsuario_DropDown);
            this.cbbUsuario.DropDownClosed += new System.EventHandler(this.cbbUsuario_DropDownClosed);
            this.cbbUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbUsuario_KeyPress);
            this.cbbUsuario.MouseLeave += new System.EventHandler(this.cbbUsuario_MouseLeave);
            this.cbbUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbUsuario_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(735, 18);
            this.txtpCodigo.MaxLength = 9;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtpCodigo.TabIndex = 4;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(632, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(97, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite o código:";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(153, 58);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(185, 55);
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
            // lblValorEntrada
            // 
            this.lblValorEntrada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorEntrada.BackColor = System.Drawing.Color.White;
            this.lblValorEntrada.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorEntrada.Enabled = false;
            this.lblValorEntrada.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorEntrada.ForeColor = System.Drawing.Color.Black;
            this.lblValorEntrada.Location = new System.Drawing.Point(299, 376);
            this.lblValorEntrada.Name = "lblValorEntrada";
            this.lblValorEntrada.Size = new System.Drawing.Size(112, 26);
            this.lblValorEntrada.TabIndex = 0;
            this.lblValorEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorEntrada.Click += new System.EventHandler(this.lblValorEntrada_Click);
            this.lblValorEntrada.MouseLeave += new System.EventHandler(this.lblValorEntrada_MouseLeave);
            this.lblValorEntrada.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorEntrada_MouseMove);
            // 
            // lblEntrada
            // 
            this.lblEntrada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEntrada.BackColor = System.Drawing.Color.Transparent;
            this.lblEntrada.Enabled = false;
            this.lblEntrada.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntrada.ForeColor = System.Drawing.Color.Blue;
            this.lblEntrada.Location = new System.Drawing.Point(180, 375);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(187, 26);
            this.lblEntrada.TabIndex = 0;
            this.lblEntrada.Text = "Entradas (R$):";
            this.lblEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorSaida
            // 
            this.lblValorSaida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorSaida.BackColor = System.Drawing.Color.White;
            this.lblValorSaida.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorSaida.Enabled = false;
            this.lblValorSaida.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorSaida.ForeColor = System.Drawing.Color.Black;
            this.lblValorSaida.Location = new System.Drawing.Point(520, 375);
            this.lblValorSaida.Name = "lblValorSaida";
            this.lblValorSaida.Size = new System.Drawing.Size(112, 26);
            this.lblValorSaida.TabIndex = 0;
            this.lblValorSaida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorSaida.Click += new System.EventHandler(this.lblValorSaida_Click);
            this.lblValorSaida.MouseLeave += new System.EventHandler(this.lblValorSaida_MouseLeave);
            this.lblValorSaida.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorSaida_MouseMove);
            // 
            // lblSaida
            // 
            this.lblSaida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSaida.BackColor = System.Drawing.Color.Transparent;
            this.lblSaida.Enabled = false;
            this.lblSaida.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaida.ForeColor = System.Drawing.Color.Red;
            this.lblSaida.Location = new System.Drawing.Point(416, 374);
            this.lblSaida.Name = "lblSaida";
            this.lblSaida.Size = new System.Drawing.Size(128, 26);
            this.lblSaida.TabIndex = 0;
            this.lblSaida.Text = "Saídas  (R$):";
            this.lblSaida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorSaldo
            // 
            this.lblValorSaldo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorSaldo.BackColor = System.Drawing.Color.White;
            this.lblValorSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorSaldo.Enabled = false;
            this.lblValorSaldo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorSaldo.ForeColor = System.Drawing.Color.Black;
            this.lblValorSaldo.Location = new System.Drawing.Point(731, 376);
            this.lblValorSaldo.Name = "lblValorSaldo";
            this.lblValorSaldo.Size = new System.Drawing.Size(112, 26);
            this.lblValorSaldo.TabIndex = 0;
            this.lblValorSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorSaldo.Click += new System.EventHandler(this.lblValorSaldo_Click);
            this.lblValorSaldo.MouseLeave += new System.EventHandler(this.lblValorSaldo_MouseLeave);
            this.lblValorSaldo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorSaldo_MouseMove);
            // 
            // lblSaldo
            // 
            this.lblSaldo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSaldo.BackColor = System.Drawing.Color.Transparent;
            this.lblSaldo.Enabled = false;
            this.lblSaldo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.ForeColor = System.Drawing.Color.Black;
            this.lblSaldo.Location = new System.Drawing.Point(636, 375);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(128, 26);
            this.lblSaldo.TabIndex = 0;
            this.lblSaldo.Text = "Saldo (R$):";
            this.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.btnRelatorioPDF);
            this.grbBox2.Controls.Add(this.btnExportarCsv);
            this.grbBox2.Controls.Add(this.rbtnExportarTxt);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(22, 404);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(821, 50);
            this.grbBox2.TabIndex = 16;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Ações";
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
            this.picbInterrogacao.Location = new System.Drawing.Point(22, 460);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 246;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(735, 140);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 245;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // pEnabled
            // 
            this.pEnabled.Controls.Add(this.lblValorSaldo);
            this.pEnabled.Controls.Add(this.lblSaldo);
            this.pEnabled.Controls.Add(this.lblValorSaida);
            this.pEnabled.Controls.Add(this.lblSaida);
            this.pEnabled.Controls.Add(this.lblValorEntrada);
            this.pEnabled.Controls.Add(this.lblRegistros);
            this.pEnabled.Controls.Add(this.lblEntrada);
            this.pEnabled.Controls.Add(this.btnSair);
            this.pEnabled.Controls.Add(this.picbInterrogacao);
            this.pEnabled.Controls.Add(this.grbBox1);
            this.pEnabled.Controls.Add(this.grbBox2);
            this.pEnabled.Controls.Add(this.picbInterrogacao1);
            this.pEnabled.Controls.Add(this.btnPesquisar);
            this.pEnabled.Controls.Add(this.lblProgresso);
            this.pEnabled.Controls.Add(this.pgbProgresso);
            this.pEnabled.Controls.Add(this.dtFluxo);
            this.pEnabled.Location = new System.Drawing.Point(-10, -38);
            this.pEnabled.Name = "pEnabled";
            this.pEnabled.Size = new System.Drawing.Size(867, 508);
            this.pEnabled.TabIndex = 247;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Enabled = false;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(406, 39);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(36, 13);
            this.lblTipo.TabIndex = 14;
            this.lblTipo.Text = "Tipo:";
            // 
            // cbbpTipo
            // 
            this.cbbpTipo.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpTipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbpTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpTipo.DropDownWidth = 180;
            this.cbbpTipo.Enabled = false;
            this.cbbpTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpTipo.FormattingEnabled = true;
            this.cbbpTipo.Items.AddRange(new object[] {
            "",
            "ENTRADA",
            "SAIDA"});
            this.cbbpTipo.Location = new System.Drawing.Point(409, 55);
            this.cbbpTipo.Name = "cbbpTipo";
            this.cbbpTipo.Size = new System.Drawing.Size(113, 21);
            this.cbbpTipo.TabIndex = 10;
            this.cbbpTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpTipo_KeyPress);
            // 
            // FrmRelFluxoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(844, 457);
            this.ControlBox = false;
            this.Controls.Add(this.pEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelFluxoCaixa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Fluxo de Caixa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRelFluxoCaixa_FormClosing);
            this.Load += new System.EventHandler(this.FrmRelFluxoCaixa_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRelFluxoCaixa_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtFluxo)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.grbBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.pEnabled.ResumeLayout(false);
            this.pEnabled.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttpFluxo;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.DataGridView dtFluxo;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnProcurar1;
        private System.Windows.Forms.Button btnProcurarUsuario;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.Label lblCodPDV;
        private System.Windows.Forms.ComboBox cbbCodPDV;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.MaskedTextBox mtxtHorario1;
        private System.Windows.Forms.MaskedTextBox mtxtHorario;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.ComboBox cbbUsuario;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblValorEntrada;
        private System.Windows.Forms.Label lblEntrada;
        private System.Windows.Forms.Label lblValorSaida;
        private System.Windows.Forms.Label lblSaida;
        private System.Windows.Forms.Label lblValorSaldo;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnRelatorioPDF;
        private System.Windows.Forms.Button btnExportarCsv;
        private System.Windows.Forms.Button rbtnExportarTxt;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.Label lblDatas;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.Panel pEnabled;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cbbpTipo;
    }
}