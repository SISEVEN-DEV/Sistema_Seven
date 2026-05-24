namespace Seven_Sistema
{
    partial class FrmRelUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelUsuario));
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.ttpUsuario = new System.Windows.Forms.ToolTip(this.components);
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnExportarCsv = new System.Windows.Forms.Button();
            this.btnImprimirRel = new System.Windows.Forms.Button();
            this.rbtnExportarTxt = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnpProcurar = new System.Windows.Forms.Button();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.dtUsuario = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnFuncionario = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnNomeUsuario = new System.Windows.Forms.RadioButton();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.txtpNomeUsuario = new System.Windows.Forms.TextBox();
            this.cbbpFuncionario = new System.Windows.Forms.ComboBox();
            this.picbInterrogacao3 = new System.Windows.Forms.PictureBox();
            this.pPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtUsuario)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao3)).BeginInit();
            this.pPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.WorkerSupportsCancellation = true;
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // ttpUsuario
            // 
            this.ttpUsuario.AutoPopDelay = 5000;
            this.ttpUsuario.InitialDelay = 1000;
            this.ttpUsuario.IsBalloon = true;
            this.ttpUsuario.ReshowDelay = 100;
            this.ttpUsuario.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpUsuario.ToolTipTitle = "Dica:";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPesquisar.Location = new System.Drawing.Point(562, 116);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 10;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // btnExportarCsv
            // 
            this.btnExportarCsv.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarCsv.Image")));
            this.btnExportarCsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarCsv.Location = new System.Drawing.Point(479, 19);
            this.btnExportarCsv.Name = "btnExportarCsv";
            this.btnExportarCsv.Size = new System.Drawing.Size(135, 25);
            this.btnExportarCsv.TabIndex = 15;
            this.btnExportarCsv.Text = "&Exp. dados para (.csv)";
            this.btnExportarCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.btnExportarCsv, "Gerar arquivo da grade de dados em (.csv)(Excel).");
            this.btnExportarCsv.UseVisualStyleBackColor = true;
            this.btnExportarCsv.Click += new System.EventHandler(this.btnExportarCsv_Click);
            this.btnExportarCsv.MouseLeave += new System.EventHandler(this.btnExportarCsv_MouseLeave);
            this.btnExportarCsv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExportarCsv_MouseMove);
            // 
            // btnImprimirRel
            // 
            this.btnImprimirRel.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirRel.Image")));
            this.btnImprimirRel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirRel.Location = new System.Drawing.Point(6, 19);
            this.btnImprimirRel.Name = "btnImprimirRel";
            this.btnImprimirRel.Size = new System.Drawing.Size(120, 25);
            this.btnImprimirRel.TabIndex = 13;
            this.btnImprimirRel.Text = "Relatório em PD&F";
            this.btnImprimirRel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.btnImprimirRel, "Clique para gerar em PDF o relatório resumido de Usuários.");
            this.btnImprimirRel.UseVisualStyleBackColor = true;
            this.btnImprimirRel.Click += new System.EventHandler(this.btnImprimirRel_Click);
            this.btnImprimirRel.MouseLeave += new System.EventHandler(this.btnImprimirRel_MouseLeave);
            this.btnImprimirRel.MouseHover += new System.EventHandler(this.btnImprimirRel_MouseHover);
            this.btnImprimirRel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnImprimirRel_MouseMove);
            // 
            // rbtnExportarTxt
            // 
            this.rbtnExportarTxt.Image = ((System.Drawing.Image)(resources.GetObject("rbtnExportarTxt.Image")));
            this.rbtnExportarTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtnExportarTxt.Location = new System.Drawing.Point(253, 19);
            this.rbtnExportarTxt.Name = "rbtnExportarTxt";
            this.rbtnExportarTxt.Size = new System.Drawing.Size(133, 25);
            this.rbtnExportarTxt.TabIndex = 14;
            this.rbtnExportarTxt.Text = "Exp. d&ados para (.txt)";
            this.rbtnExportarTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.rbtnExportarTxt, "Gerar arquivo da grade de dados em (.txt)(Bloco de Notas).");
            this.rbtnExportarTxt.UseVisualStyleBackColor = true;
            this.rbtnExportarTxt.Click += new System.EventHandler(this.rbtnExportarTxt_Click);
            this.rbtnExportarTxt.MouseLeave += new System.EventHandler(this.rbtnExportarTxt_MouseLeave);
            this.rbtnExportarTxt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnExportarTxt_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(589, 414);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 16;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.btnSair, "Sair do Relatório de Usuários.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnpProcurar
            // 
            this.btnpProcurar.Image = ((System.Drawing.Image)(resources.GetObject("btnpProcurar.Image")));
            this.btnpProcurar.Location = new System.Drawing.Point(588, 16);
            this.btnpProcurar.Name = "btnpProcurar";
            this.btnpProcurar.Size = new System.Drawing.Size(26, 25);
            this.btnpProcurar.TabIndex = 9;
            this.btnpProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUsuario.SetToolTip(this.btnpProcurar, "Clique para pesquisar um funcionário.");
            this.btnpProcurar.UseVisualStyleBackColor = true;
            this.btnpProcurar.Visible = false;
            this.btnpProcurar.Click += new System.EventHandler(this.btnpProcurar_Click);
            this.btnpProcurar.MouseLeave += new System.EventHandler(this.btnpProcurar_MouseLeave);
            this.btnpProcurar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnpProcurar_MouseMove);
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(184, 215);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(300, 33);
            this.lblProgresso.TabIndex = 227;
            this.lblProgresso.Text = "Por favor, aguarde...";
            this.lblProgresso.Visible = false;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.pgbProgresso.Location = new System.Drawing.Point(174, 248);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(321, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 228;
            this.pgbProgresso.Visible = false;
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(536, 116);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 226;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(21, 329);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.btnExportarCsv);
            this.grbBox2.Controls.Add(this.btnImprimirRel);
            this.grbBox2.Controls.Add(this.rbtnExportarTxt);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(24, 358);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(620, 50);
            this.grbBox2.TabIndex = 12;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Ações";
            // 
            // dtUsuario
            // 
            this.dtUsuario.AllowUserToAddRows = false;
            this.dtUsuario.AllowUserToDeleteRows = false;
            this.dtUsuario.AllowUserToResizeRows = false;
            this.dtUsuario.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtUsuario.Enabled = false;
            this.dtUsuario.Location = new System.Drawing.Point(24, 154);
            this.dtUsuario.MultiSelect = false;
            this.dtUsuario.Name = "dtUsuario";
            this.dtUsuario.ReadOnly = true;
            this.dtUsuario.RowHeadersVisible = false;
            this.dtUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtUsuario.ShowCellErrors = false;
            this.dtUsuario.ShowCellToolTips = false;
            this.dtUsuario.ShowEditingIcon = false;
            this.dtUsuario.ShowRowErrors = false;
            this.dtUsuario.Size = new System.Drawing.Size(620, 172);
            this.dtUsuario.TabIndex = 11;
            this.dtUsuario.DataSourceChanged += new System.EventHandler(this.dtUsuario_DataSourceChanged);
            this.dtUsuario.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtUsuario_CellEnter);
            this.dtUsuario.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtUsuario_CellFormatting);
            this.dtUsuario.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtGrupo_RowsAdded);
            this.dtUsuario.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtUsuario_RowsRemoved);
            this.dtUsuario.MouseLeave += new System.EventHandler(this.dtUsuario_MouseLeave);
            this.dtUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtUsuario_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.btnpProcurar);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnFuncionario);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnNomeUsuario);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.txtpNomeUsuario);
            this.grbBox1.Controls.Add(this.cbbpFuncionario);
            this.grbBox1.Location = new System.Drawing.Point(24, 45);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(620, 65);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(418, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(89, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite o nome:";
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(91, 42);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 5;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // rbtnFuncionario
            // 
            this.rbtnFuncionario.AutoSize = true;
            this.rbtnFuncionario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnFuncionario.Location = new System.Drawing.Point(6, 42);
            this.rbtnFuncionario.Name = "rbtnFuncionario";
            this.rbtnFuncionario.Size = new System.Drawing.Size(80, 17);
            this.rbtnFuncionario.TabIndex = 4;
            this.rbtnFuncionario.Text = "Funcionário";
            this.rbtnFuncionario.UseVisualStyleBackColor = true;
            this.rbtnFuncionario.CheckedChanged += new System.EventHandler(this.rbtnFuncionario_CheckedChanged);
            this.rbtnFuncionario.MouseLeave += new System.EventHandler(this.rbtnFuncionario_MouseLeave);
            this.rbtnFuncionario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnFuncionario_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(91, 19);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 3;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // rbtnNomeUsuario
            // 
            this.rbtnNomeUsuario.AutoSize = true;
            this.rbtnNomeUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnNomeUsuario.Location = new System.Drawing.Point(6, 19);
            this.rbtnNomeUsuario.Name = "rbtnNomeUsuario";
            this.rbtnNomeUsuario.Size = new System.Drawing.Size(53, 17);
            this.rbtnNomeUsuario.TabIndex = 2;
            this.rbtnNomeUsuario.Text = "Nome";
            this.rbtnNomeUsuario.UseVisualStyleBackColor = true;
            this.rbtnNomeUsuario.CheckedChanged += new System.EventHandler(this.rbtnNomeUsuario_CheckedChanged);
            this.rbtnNomeUsuario.MouseLeave += new System.EventHandler(this.rbtnNomeUsuario_MouseLeave);
            this.rbtnNomeUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnNomeUsuario_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(569, 18);
            this.txtpCodigo.MaxLength = 5;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(45, 20);
            this.txtpCodigo.TabIndex = 8;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // txtpNomeUsuario
            // 
            this.txtpNomeUsuario.BackColor = System.Drawing.Color.White;
            this.txtpNomeUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpNomeUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpNomeUsuario.Location = new System.Drawing.Point(513, 18);
            this.txtpNomeUsuario.MaxLength = 10;
            this.txtpNomeUsuario.Name = "txtpNomeUsuario";
            this.txtpNomeUsuario.Size = new System.Drawing.Size(101, 20);
            this.txtpNomeUsuario.TabIndex = 7;
            this.txtpNomeUsuario.Enter += new System.EventHandler(this.txtpNomeUsuario_Enter);
            this.txtpNomeUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpNomeUsuario_KeyPress);
            this.txtpNomeUsuario.Leave += new System.EventHandler(this.txtpNomeUsuario_Leave);
            // 
            // cbbpFuncionario
            // 
            this.cbbpFuncionario.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpFuncionario.DropDownWidth = 500;
            this.cbbpFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpFuncionario.FormattingEnabled = true;
            this.cbbpFuncionario.Location = new System.Drawing.Point(352, 18);
            this.cbbpFuncionario.Name = "cbbpFuncionario";
            this.cbbpFuncionario.Size = new System.Drawing.Size(230, 21);
            this.cbbpFuncionario.TabIndex = 6;
            this.cbbpFuncionario.Visible = false;
            this.cbbpFuncionario.DropDown += new System.EventHandler(this.cbbpFuncionario_DropDown);
            this.cbbpFuncionario.DropDownClosed += new System.EventHandler(this.cbbpFuncionario_DropDownClosed);
            this.cbbpFuncionario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpFuncionario_KeyPress);
            this.cbbpFuncionario.MouseLeave += new System.EventHandler(this.cbbpFuncionario_MouseLeave);
            this.cbbpFuncionario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpFuncionario_MouseMove);
            // 
            // picbInterrogacao3
            // 
            this.picbInterrogacao3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao3.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao3.Image")));
            this.picbInterrogacao3.Location = new System.Drawing.Point(24, 414);
            this.picbInterrogacao3.Name = "picbInterrogacao3";
            this.picbInterrogacao3.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao3.TabIndex = 229;
            this.picbInterrogacao3.TabStop = false;
            this.picbInterrogacao3.Click += new System.EventHandler(this.picbInterrogacao3_Click);
            this.picbInterrogacao3.MouseLeave += new System.EventHandler(this.picbInterrogacao3_MouseLeave);
            this.picbInterrogacao3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao3_MouseMove);
            // 
            // pPanel
            // 
            this.pPanel.Controls.Add(this.picbInterrogacao3);
            this.pPanel.Controls.Add(this.btnSair);
            this.pPanel.Controls.Add(this.grbBox1);
            this.pPanel.Controls.Add(this.btnPesquisar);
            this.pPanel.Controls.Add(this.grbBox2);
            this.pPanel.Controls.Add(this.lblRegistros);
            this.pPanel.Controls.Add(this.lblProgresso);
            this.pPanel.Controls.Add(this.dtUsuario);
            this.pPanel.Controls.Add(this.pgbProgresso);
            this.pPanel.Controls.Add(this.picbInterrogacao2);
            this.pPanel.Location = new System.Drawing.Point(-12, -33);
            this.pPanel.Name = "pPanel";
            this.pPanel.Size = new System.Drawing.Size(677, 586);
            this.pPanel.TabIndex = 230;
            // 
            // FrmRelUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(643, 418);
            this.ControlBox = false;
            this.Controls.Add(this.pPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelUsuario";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Usuários";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRelUsuario_FormClosing);
            this.Load += new System.EventHandler(this.FrmRelUsuario_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRelUsuario_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            this.grbBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtUsuario)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao3)).EndInit();
            this.pPanel.ResumeLayout(false);
            this.pPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.ToolTip ttpUsuario;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnExportarCsv;
        private System.Windows.Forms.Button btnImprimirRel;
        private System.Windows.Forms.Button rbtnExportarTxt;
        private System.Windows.Forms.DataGridView dtUsuario;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnFuncionario;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnNomeUsuario;
        private System.Windows.Forms.Button btnpProcurar;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.ComboBox cbbpFuncionario;
        private System.Windows.Forms.TextBox txtpNomeUsuario;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao3;
        private System.Windows.Forms.Panel pPanel;
    }
}