namespace Seven_Sistema
{
    partial class FrmRelSangriaSuprimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelSangriaSuprimento));
            this.ttpRelSangSup = new System.Windows.Forms.ToolTip(this.components);
            this.btnProcurar1 = new System.Windows.Forms.Button();
            this.btnProcurarUsuario = new System.Windows.Forms.Button();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnCupomSangSup = new System.Windows.Forms.Button();
            this.btnRelatorioPDF = new System.Windows.Forms.Button();
            this.btnExportarCsv = new System.Windows.Forms.Button();
            this.rbtnExportarTxt = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.dtSangSup = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblDatas = new System.Windows.Forms.Label();
            this.rbtnDescricao = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.lblCodPDV = new System.Windows.Forms.Label();
            this.cbbCodPDV = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.mtxtHorario1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtHorario = new System.Windows.Forms.MaskedTextBox();
            this.cbbUsuario = new System.Windows.Forms.ComboBox();
            this.lblAte = new System.Windows.Forms.Label();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.txtpDescricao = new System.Windows.Forms.TextBox();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.lblValorSangria = new System.Windows.Forms.Label();
            this.lblSangria = new System.Windows.Forms.Label();
            this.lblValorSuprimento = new System.Windows.Forms.Label();
            this.lblSuprimento = new System.Windows.Forms.Label();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.picbInterrogacao3 = new System.Windows.Forms.PictureBox();
            this.pEnabled = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtSangSup)).BeginInit();
            this.grbBox1.SuspendLayout();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao3)).BeginInit();
            this.pEnabled.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttpRelSangSup
            // 
            this.ttpRelSangSup.AutoPopDelay = 5000;
            this.ttpRelSangSup.InitialDelay = 1000;
            this.ttpRelSangSup.IsBalloon = true;
            this.ttpRelSangSup.ReshowDelay = 100;
            this.ttpRelSangSup.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpRelSangSup.ToolTipTitle = "Dica:";
            // 
            // btnProcurar1
            // 
            this.btnProcurar1.Enabled = false;
            this.btnProcurar1.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurar1.Image")));
            this.btnProcurar1.Location = new System.Drawing.Point(676, 53);
            this.btnProcurar1.Name = "btnProcurar1";
            this.btnProcurar1.Size = new System.Drawing.Size(26, 25);
            this.btnProcurar1.TabIndex = 15;
            this.btnProcurar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpRelSangSup.SetToolTip(this.btnProcurar1, "Clique para pesquisar um Computador/PDV.");
            this.btnProcurar1.UseVisualStyleBackColor = true;
            this.btnProcurar1.Click += new System.EventHandler(this.btnProcurar1_Click);
            this.btnProcurar1.MouseLeave += new System.EventHandler(this.btnProcurar1_MouseLeave);
            this.btnProcurar1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurar1_MouseMove);
            // 
            // btnProcurarUsuario
            // 
            this.btnProcurarUsuario.Enabled = false;
            this.btnProcurarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarUsuario.Image")));
            this.btnProcurarUsuario.Location = new System.Drawing.Point(559, 53);
            this.btnProcurarUsuario.Name = "btnProcurarUsuario";
            this.btnProcurarUsuario.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarUsuario.TabIndex = 13;
            this.btnProcurarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpRelSangSup.SetToolTip(this.btnProcurarUsuario, "Clique para pesquisar um Usuário.");
            this.btnProcurarUsuario.UseVisualStyleBackColor = true;
            this.btnProcurarUsuario.Click += new System.EventHandler(this.btnProcurarUsuario_Click);
            this.btnProcurarUsuario.MouseLeave += new System.EventHandler(this.btnProcurarUsuario_MouseLeave);
            this.btnProcurarUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarUsuario_MouseMove);
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(334, 52);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 11;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpRelSangSup.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(652, 140);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 16;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpRelSangSup.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // btnCupomSangSup
            // 
            this.btnCupomSangSup.Image = ((System.Drawing.Image)(resources.GetObject("btnCupomSangSup.Image")));
            this.btnCupomSangSup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCupomSangSup.Location = new System.Drawing.Point(149, 19);
            this.btnCupomSangSup.Name = "btnCupomSangSup";
            this.btnCupomSangSup.Size = new System.Drawing.Size(178, 25);
            this.btnCupomSangSup.TabIndex = 20;
            this.btnCupomSangSup.Text = "&Cupom da Sangria/Suprimento";
            this.btnCupomSangSup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpRelSangSup.SetToolTip(this.btnCupomSangSup, "Clique para gerar em PDF o cupom do registro selecionado.");
            this.btnCupomSangSup.UseVisualStyleBackColor = true;
            this.btnCupomSangSup.Click += new System.EventHandler(this.btnCupomSangSup_Click);
            this.btnCupomSangSup.MouseLeave += new System.EventHandler(this.btnCupomSangSup_MouseLeave);
            this.btnCupomSangSup.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCupomSangSup_MouseMove);
            // 
            // btnRelatorioPDF
            // 
            this.btnRelatorioPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorioPDF.Image")));
            this.btnRelatorioPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorioPDF.Location = new System.Drawing.Point(6, 19);
            this.btnRelatorioPDF.Name = "btnRelatorioPDF";
            this.btnRelatorioPDF.Size = new System.Drawing.Size(116, 25);
            this.btnRelatorioPDF.TabIndex = 19;
            this.btnRelatorioPDF.Text = "&Relatório em PDF";
            this.btnRelatorioPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpRelSangSup.SetToolTip(this.btnRelatorioPDF, "Relatório das Informações em PDF");
            this.btnRelatorioPDF.UseVisualStyleBackColor = true;
            this.btnRelatorioPDF.Click += new System.EventHandler(this.btnRelatorioPDF_Click);
            this.btnRelatorioPDF.MouseLeave += new System.EventHandler(this.btnRelatorioPDF_MouseLeave);
            this.btnRelatorioPDF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRelatorioPDF_MouseMove);
            // 
            // btnExportarCsv
            // 
            this.btnExportarCsv.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarCsv.Image")));
            this.btnExportarCsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarCsv.Location = new System.Drawing.Point(347, 19);
            this.btnExportarCsv.Name = "btnExportarCsv";
            this.btnExportarCsv.Size = new System.Drawing.Size(135, 25);
            this.btnExportarCsv.TabIndex = 21;
            this.btnExportarCsv.Text = "Exp. dados para (.cs&v)";
            this.btnExportarCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpRelSangSup.SetToolTip(this.btnExportarCsv, "Gerar arquivo da grade de dados em (.csv)(Excel).");
            this.btnExportarCsv.UseVisualStyleBackColor = true;
            this.btnExportarCsv.Click += new System.EventHandler(this.btnExportarCsv_Click);
            this.btnExportarCsv.MouseLeave += new System.EventHandler(this.btnExportarCsv_MouseLeave);
            this.btnExportarCsv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExportarCsv_MouseMove);
            // 
            // rbtnExportarTxt
            // 
            this.rbtnExportarTxt.Image = ((System.Drawing.Image)(resources.GetObject("rbtnExportarTxt.Image")));
            this.rbtnExportarTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtnExportarTxt.Location = new System.Drawing.Point(494, 19);
            this.rbtnExportarTxt.Name = "rbtnExportarTxt";
            this.rbtnExportarTxt.Size = new System.Drawing.Size(133, 25);
            this.rbtnExportarTxt.TabIndex = 22;
            this.rbtnExportarTxt.Text = "Exp. d&ados para (.txt)";
            this.rbtnExportarTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpRelSangSup.SetToolTip(this.rbtnExportarTxt, "Gerar arquivo da grade de dados em (.txt)(Bloco de Notas).");
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
            this.btnSair.Location = new System.Drawing.Point(677, 438);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(54, 32);
            this.btnSair.TabIndex = 24;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpRelSangSup.SetToolTip(this.btnSair, "Sair do Relatório de Sangria e Suprimento.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(637, 19);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(65, 25);
            this.btnExcluir.TabIndex = 23;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpRelSangSup.SetToolTip(this.btnExcluir, "Clique para excluir uma sangria/suprimento cadastrada.");
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            this.btnExcluir.MouseLeave += new System.EventHandler(this.btnExcluir_MouseLeave);
            this.btnExcluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluir_MouseMove);
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(237, 236);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(300, 33);
            this.lblProgresso.TabIndex = 198;
            this.lblProgresso.Text = "Por favor, aguarde...";
            this.lblProgresso.Visible = false;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.pgbProgresso.Location = new System.Drawing.Point(228, 269);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(320, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 199;
            this.pgbProgresso.Visible = false;
            // 
            // dtSangSup
            // 
            this.dtSangSup.AllowUserToAddRows = false;
            this.dtSangSup.AllowUserToDeleteRows = false;
            this.dtSangSup.AllowUserToResizeRows = false;
            this.dtSangSup.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtSangSup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtSangSup.Enabled = false;
            this.dtSangSup.Location = new System.Drawing.Point(26, 178);
            this.dtSangSup.MultiSelect = false;
            this.dtSangSup.Name = "dtSangSup";
            this.dtSangSup.ReadOnly = true;
            this.dtSangSup.RowHeadersVisible = false;
            this.dtSangSup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtSangSup.ShowCellErrors = false;
            this.dtSangSup.ShowCellToolTips = false;
            this.dtSangSup.ShowEditingIcon = false;
            this.dtSangSup.ShowRowErrors = false;
            this.dtSangSup.Size = new System.Drawing.Size(708, 172);
            this.dtSangSup.TabIndex = 17;
            this.dtSangSup.DataSourceChanged += new System.EventHandler(this.dtSangSup_DataSourceChanged);
            this.dtSangSup.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtSangSup_CellEnter);
            this.dtSangSup.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtSangSup_CellFormatting);
            this.dtSangSup.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtSangSup_RowsAdded);
            this.dtSangSup.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtSangSup_RowsRemoved);
            this.dtSangSup.MouseLeave += new System.EventHandler(this.dtSangSup_MouseLeave);
            this.dtSangSup.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtSangSup_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(23, 353);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 200;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblDatas);
            this.grbBox1.Controls.Add(this.rbtnDescricao);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.btnProcurar1);
            this.grbBox1.Controls.Add(this.btnProcurarUsuario);
            this.grbBox1.Controls.Add(this.lblCodPDV);
            this.grbBox1.Controls.Add(this.cbbCodPDV);
            this.grbBox1.Controls.Add(this.lblUsuario);
            this.grbBox1.Controls.Add(this.mtxtHorario1);
            this.grbBox1.Controls.Add(this.mtxtHorario);
            this.grbBox1.Controls.Add(this.cbbUsuario);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.txtpDescricao);
            this.grbBox1.Location = new System.Drawing.Point(26, 50);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(708, 84);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // lblDatas
            // 
            this.lblDatas.AutoSize = true;
            this.lblDatas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatas.Location = new System.Drawing.Point(2, 39);
            this.lblDatas.Name = "lblDatas";
            this.lblDatas.Size = new System.Drawing.Size(228, 13);
            this.lblDatas.TabIndex = 0;
            this.lblDatas.Text = "Data e Horário da Sangria/Suprimento:";
            // 
            // rbtnDescricao
            // 
            this.rbtnDescricao.AutoSize = true;
            this.rbtnDescricao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnDescricao.Location = new System.Drawing.Point(6, 19);
            this.rbtnDescricao.Name = "rbtnDescricao";
            this.rbtnDescricao.Size = new System.Drawing.Size(73, 17);
            this.rbtnDescricao.TabIndex = 2;
            this.rbtnDescricao.TabStop = true;
            this.rbtnDescricao.Text = "Descrição";
            this.rbtnDescricao.UseVisualStyleBackColor = true;
            this.rbtnDescricao.CheckedChanged += new System.EventHandler(this.rbtnDescricao_CheckedChanged);
            this.rbtnDescricao.MouseLeave += new System.EventHandler(this.rbtnDescricao_MouseLeave);
            this.rbtnDescricao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnDescricao_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(149, 19);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 4;
            this.rbtnTodos.Text = "Todas";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnData_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnData_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnData_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(85, 19);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 3;
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
            this.lblCodPDV.Location = new System.Drawing.Point(609, 39);
            this.lblCodPDV.Name = "lblCodPDV";
            this.lblCodPDV.Size = new System.Drawing.Size(84, 13);
            this.lblCodPDV.TabIndex = 0;
            this.lblCodPDV.Text = "Cód. do PDV:";
            // 
            // cbbCodPDV
            // 
            this.cbbCodPDV.BackColor = System.Drawing.Color.LightBlue;
            this.cbbCodPDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCodPDV.DropDownWidth = 80;
            this.cbbCodPDV.Enabled = false;
            this.cbbCodPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCodPDV.FormattingEnabled = true;
            this.cbbCodPDV.Location = new System.Drawing.Point(612, 55);
            this.cbbCodPDV.Name = "cbbCodPDV";
            this.cbbCodPDV.Size = new System.Drawing.Size(58, 21);
            this.cbbCodPDV.TabIndex = 14;
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
            this.lblUsuario.Location = new System.Drawing.Point(437, 39);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(54, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuário:";
            // 
            // mtxtHorario1
            // 
            this.mtxtHorario1.BackColor = System.Drawing.Color.White;
            this.mtxtHorario1.Enabled = false;
            this.mtxtHorario1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorario1.Location = new System.Drawing.Point(271, 55);
            this.mtxtHorario1.Mask = "00:00:00";
            this.mtxtHorario1.Name = "mtxtHorario1";
            this.mtxtHorario1.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario1.TabIndex = 10;
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
            this.mtxtHorario.Location = new System.Drawing.Point(92, 55);
            this.mtxtHorario.Mask = "00:00:00";
            this.mtxtHorario.Name = "mtxtHorario";
            this.mtxtHorario.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario.TabIndex = 8;
            this.mtxtHorario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorario.DoubleClick += new System.EventHandler(this.mtxtHorario_DoubleClick);
            this.mtxtHorario.Enter += new System.EventHandler(this.mtxtHorario_Enter);
            this.mtxtHorario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorario_KeyPress);
            this.mtxtHorario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorario_KeyUp);
            this.mtxtHorario.Leave += new System.EventHandler(this.mtxtHorario_Leave);
            // 
            // cbbUsuario
            // 
            this.cbbUsuario.BackColor = System.Drawing.Color.LightBlue;
            this.cbbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUsuario.DropDownWidth = 180;
            this.cbbUsuario.Enabled = false;
            this.cbbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUsuario.FormattingEnabled = true;
            this.cbbUsuario.Location = new System.Drawing.Point(440, 55);
            this.cbbUsuario.Name = "cbbUsuario";
            this.cbbUsuario.Size = new System.Drawing.Size(113, 21);
            this.cbbUsuario.TabIndex = 12;
            this.cbbUsuario.DropDown += new System.EventHandler(this.cbbUsuario_DropDown);
            this.cbbUsuario.DropDownClosed += new System.EventHandler(this.cbbUsuario_DropDownClosed);
            this.cbbUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbUsuario_KeyPress);
            this.cbbUsuario.MouseLeave += new System.EventHandler(this.cbbUsuario_MouseLeave);
            this.cbbUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbUsuario_MouseMove);
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(155, 58);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(362, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(114, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite a descrição:";
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(622, 18);
            this.txtpCodigo.MaxLength = 9;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtpCodigo.TabIndex = 6;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(187, 55);
            this.mtxtpData1.Mask = "00/00/0000";
            this.mtxtpData1.Name = "mtxtpData1";
            this.mtxtpData1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData1.TabIndex = 9;
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
            this.mtxtpData.Location = new System.Drawing.Point(8, 55);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 7;
            this.mtxtpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData.DoubleClick += new System.EventHandler(this.mtxtpData_DoubleClick);
            this.mtxtpData.Enter += new System.EventHandler(this.mtxtpData_Enter);
            this.mtxtpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData_KeyPress);
            this.mtxtpData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData_KeyUp);
            this.mtxtpData.Leave += new System.EventHandler(this.mtxtpData_Leave);
            // 
            // txtpDescricao
            // 
            this.txtpDescricao.BackColor = System.Drawing.Color.White;
            this.txtpDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpDescricao.Location = new System.Drawing.Point(482, 18);
            this.txtpDescricao.MaxLength = 60;
            this.txtpDescricao.Name = "txtpDescricao";
            this.txtpDescricao.Size = new System.Drawing.Size(220, 20);
            this.txtpDescricao.TabIndex = 5;
            this.txtpDescricao.Enter += new System.EventHandler(this.txtpDescricao_Enter);
            this.txtpDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpDescricao_KeyPress);
            this.txtpDescricao.Leave += new System.EventHandler(this.txtpDescricao_Leave);
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.btnExcluir);
            this.grbBox2.Controls.Add(this.btnCupomSangSup);
            this.grbBox2.Controls.Add(this.btnRelatorioPDF);
            this.grbBox2.Controls.Add(this.btnExportarCsv);
            this.grbBox2.Controls.Add(this.rbtnExportarTxt);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(26, 382);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(708, 50);
            this.grbBox2.TabIndex = 18;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Ações";
            // 
            // lblValorSangria
            // 
            this.lblValorSangria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorSangria.BackColor = System.Drawing.Color.White;
            this.lblValorSangria.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorSangria.Enabled = false;
            this.lblValorSangria.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorSangria.ForeColor = System.Drawing.Color.Black;
            this.lblValorSangria.Location = new System.Drawing.Point(619, 352);
            this.lblValorSangria.Name = "lblValorSangria";
            this.lblValorSangria.Size = new System.Drawing.Size(112, 26);
            this.lblValorSangria.TabIndex = 206;
            this.lblValorSangria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorSangria.Click += new System.EventHandler(this.lblValorSangria_Click);
            this.lblValorSangria.MouseLeave += new System.EventHandler(this.lblValorSangria_MouseLeave);
            this.lblValorSangria.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorSangria_MouseMove);
            // 
            // lblSangria
            // 
            this.lblSangria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSangria.BackColor = System.Drawing.Color.Transparent;
            this.lblSangria.Enabled = false;
            this.lblSangria.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSangria.ForeColor = System.Drawing.Color.Red;
            this.lblSangria.Location = new System.Drawing.Point(501, 351);
            this.lblSangria.Name = "lblSangria";
            this.lblSangria.Size = new System.Drawing.Size(128, 26);
            this.lblSangria.TabIndex = 207;
            this.lblSangria.Text = "Sangrias  (R$):";
            this.lblSangria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorSuprimento
            // 
            this.lblValorSuprimento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorSuprimento.BackColor = System.Drawing.Color.White;
            this.lblValorSuprimento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorSuprimento.Enabled = false;
            this.lblValorSuprimento.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorSuprimento.ForeColor = System.Drawing.Color.Black;
            this.lblValorSuprimento.Location = new System.Drawing.Point(367, 353);
            this.lblValorSuprimento.Name = "lblValorSuprimento";
            this.lblValorSuprimento.Size = new System.Drawing.Size(112, 26);
            this.lblValorSuprimento.TabIndex = 208;
            this.lblValorSuprimento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorSuprimento.Click += new System.EventHandler(this.lblValorSuprimento_Click);
            this.lblValorSuprimento.MouseLeave += new System.EventHandler(this.lblValorSuprimento_MouseLeave);
            this.lblValorSuprimento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorSuprimento_MouseMove);
            // 
            // lblSuprimento
            // 
            this.lblSuprimento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSuprimento.BackColor = System.Drawing.Color.Transparent;
            this.lblSuprimento.Enabled = false;
            this.lblSuprimento.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuprimento.ForeColor = System.Drawing.Color.Blue;
            this.lblSuprimento.Location = new System.Drawing.Point(219, 352);
            this.lblSuprimento.Name = "lblSuprimento";
            this.lblSuprimento.Size = new System.Drawing.Size(187, 26);
            this.lblSuprimento.TabIndex = 209;
            this.lblSuprimento.Text = "Suprimentos (R$):";
            this.lblSuprimento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(626, 140);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 238;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // picbInterrogacao3
            // 
            this.picbInterrogacao3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao3.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao3.Image")));
            this.picbInterrogacao3.Location = new System.Drawing.Point(26, 438);
            this.picbInterrogacao3.Name = "picbInterrogacao3";
            this.picbInterrogacao3.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao3.TabIndex = 241;
            this.picbInterrogacao3.TabStop = false;
            this.picbInterrogacao3.Click += new System.EventHandler(this.picbInterrogacao3_Click);
            this.picbInterrogacao3.MouseLeave += new System.EventHandler(this.picbInterrogacao3_MouseLeave);
            this.picbInterrogacao3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao3_MouseMove);
            // 
            // pEnabled
            // 
            this.pEnabled.Controls.Add(this.btnSair);
            this.pEnabled.Controls.Add(this.picbInterrogacao3);
            this.pEnabled.Controls.Add(this.grbBox1);
            this.pEnabled.Controls.Add(this.lblValorSangria);
            this.pEnabled.Controls.Add(this.grbBox2);
            this.pEnabled.Controls.Add(this.picbInterrogacao1);
            this.pEnabled.Controls.Add(this.lblSangria);
            this.pEnabled.Controls.Add(this.btnPesquisar);
            this.pEnabled.Controls.Add(this.lblValorSuprimento);
            this.pEnabled.Controls.Add(this.lblProgresso);
            this.pEnabled.Controls.Add(this.lblSuprimento);
            this.pEnabled.Controls.Add(this.pgbProgresso);
            this.pEnabled.Controls.Add(this.dtSangSup);
            this.pEnabled.Controls.Add(this.lblRegistros);
            this.pEnabled.Location = new System.Drawing.Point(-14, -38);
            this.pEnabled.Name = "pEnabled";
            this.pEnabled.Size = new System.Drawing.Size(757, 578);
            this.pEnabled.TabIndex = 242;
            // 
            // FrmRelSangriaSuprimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(731, 438);
            this.ControlBox = false;
            this.Controls.Add(this.pEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelSangriaSuprimento";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Sangria e Suprimento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRelSangriaSuprimento_FormClosing);
            this.Load += new System.EventHandler(this.FrmMovContsaPagar_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRelSangriaSuprimento_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtSangSup)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.grbBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao3)).EndInit();
            this.pEnabled.ResumeLayout(false);
            this.pEnabled.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttpRelSangSup;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.Windows.Forms.DataGridView dtSangSup;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnDescricao;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.Button btnProcurar1;
        private System.Windows.Forms.Button btnProcurarUsuario;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.Label lblCodPDV;
        private System.Windows.Forms.ComboBox cbbCodPDV;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.MaskedTextBox mtxtHorario1;
        private System.Windows.Forms.MaskedTextBox mtxtHorario;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.ComboBox cbbUsuario;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnRelatorioPDF;
        private System.Windows.Forms.Button btnExportarCsv;
        private System.Windows.Forms.Button rbtnExportarTxt;
        private System.Windows.Forms.TextBox txtpDescricao;
        private System.Windows.Forms.Button btnCupomSangSup;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblValorSangria;
        private System.Windows.Forms.Label lblSangria;
        private System.Windows.Forms.Label lblValorSuprimento;
        private System.Windows.Forms.Label lblSuprimento;
        private System.Windows.Forms.Label lblDatas;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.PictureBox picbInterrogacao3;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Panel pEnabled;
    }
}