namespace Seven_Sistema
{
    partial class FrmRelGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelGrupo));
            this.ttpGrupo = new System.Windows.Forms.ToolTip(this.components);
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnExportarCsv = new System.Windows.Forms.Button();
            this.btnImprimirRel = new System.Windows.Forms.Button();
            this.rbtnExportarTxt = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblAte = new System.Windows.Forms.Label();
            this.lblDatas = new System.Windows.Forms.Label();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.rbtnTabelaDestino = new System.Windows.Forms.RadioButton();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.rbtnPalavraChave = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnDescricao = new System.Windows.Forms.RadioButton();
            this.cbbpTabelaDestino = new System.Windows.Forms.ComboBox();
            this.txtpDescricao = new System.Windows.Forms.TextBox();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.txtpPalavraChave = new System.Windows.Forms.TextBox();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.dtGrupo = new System.Windows.Forms.DataGridView();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.picbInterrogacao3 = new System.Windows.Forms.PictureBox();
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.pEnabled = new System.Windows.Forms.Panel();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrupo)).BeginInit();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao3)).BeginInit();
            this.pEnabled.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttpGrupo
            // 
            this.ttpGrupo.AutoPopDelay = 5000;
            this.ttpGrupo.InitialDelay = 1000;
            this.ttpGrupo.IsBalloon = true;
            this.ttpGrupo.ReshowDelay = 100;
            this.ttpGrupo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpGrupo.ToolTipTitle = "Dica:";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPesquisar.Location = new System.Drawing.Point(568, 162);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 11;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpGrupo.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
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
            this.btnExportarCsv.TabIndex = 17;
            this.btnExportarCsv.Text = "&Exp. dados para (.csv)";
            this.btnExportarCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpGrupo.SetToolTip(this.btnExportarCsv, "Gerar arquivo da grade de dados em (.csv)(Excel).");
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
            this.btnImprimirRel.TabIndex = 14;
            this.btnImprimirRel.Text = "Relatório em PD&F";
            this.btnImprimirRel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpGrupo.SetToolTip(this.btnImprimirRel, "Clique para imprimir o relatório resumido da grade de dados em formato PDF.");
            this.btnImprimirRel.UseVisualStyleBackColor = true;
            this.btnImprimirRel.Click += new System.EventHandler(this.btnImprimirRel_Click);
            this.btnImprimirRel.MouseLeave += new System.EventHandler(this.btnImprimirRel_MouseLeave);
            this.btnImprimirRel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnImprimirRel_MouseMove);
            // 
            // rbtnExportarTxt
            // 
            this.rbtnExportarTxt.Image = ((System.Drawing.Image)(resources.GetObject("rbtnExportarTxt.Image")));
            this.rbtnExportarTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtnExportarTxt.Location = new System.Drawing.Point(327, 19);
            this.rbtnExportarTxt.Name = "rbtnExportarTxt";
            this.rbtnExportarTxt.Size = new System.Drawing.Size(133, 25);
            this.rbtnExportarTxt.TabIndex = 16;
            this.rbtnExportarTxt.Text = "Exp. d&ados para (.txt)";
            this.rbtnExportarTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpGrupo.SetToolTip(this.rbtnExportarTxt, "Gerar arquivo da grade de dados em (.txt)(Bloco de Notas).");
            this.rbtnExportarTxt.UseVisualStyleBackColor = true;
            this.rbtnExportarTxt.Click += new System.EventHandler(this.rbtnExportarTxt_Click);
            this.rbtnExportarTxt.MouseLeave += new System.EventHandler(this.rbtnExportarTxt_MouseLeave);
            this.rbtnExportarTxt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnExportarTxt_MouseMove);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(142, 19);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(170, 25);
            this.btnImprimir.TabIndex = 15;
            this.btnImprimir.Text = "&Relatório do Registro em PDF";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpGrupo.SetToolTip(this.btnImprimir, "Clique para gerar em PDF o relatório completo de Grupos.");
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            this.btnImprimir.MouseLeave += new System.EventHandler(this.btnImprimir_MouseLeave);
            this.btnImprimir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnImprimir_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(595, 460);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 18;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpGrupo.SetToolTip(this.btnSair, "Sair do Relatório de Grupos.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(206, 74);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 15;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpGrupo.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.lblDatas);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.rbtnTabelaDestino);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.rbtnPalavraChave);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnDescricao);
            this.grbBox1.Controls.Add(this.cbbpTabelaDestino);
            this.grbBox1.Controls.Add(this.txtpDescricao);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.txtpPalavraChave);
            this.grbBox1.Location = new System.Drawing.Point(30, 52);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(620, 104);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(90, 80);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // lblDatas
            // 
            this.lblDatas.AutoSize = true;
            this.lblDatas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDatas.Location = new System.Drawing.Point(3, 61);
            this.lblDatas.Name = "lblDatas";
            this.lblDatas.Size = new System.Drawing.Size(110, 13);
            this.lblDatas.TabIndex = 0;
            this.lblDatas.Text = "Data de Cadastro:";
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(122, 77);
            this.mtxtpData1.Mask = "00/00/0000";
            this.mtxtpData1.Name = "mtxtpData1";
            this.mtxtpData1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData1.TabIndex = 12;
            this.mtxtpData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData1.DoubleClick += new System.EventHandler(this.mtxtpData1_DoubleClick);
            this.mtxtpData1.Enter += new System.EventHandler(this.mtxtpData1_Enter);
            this.mtxtpData1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtpData1_KeyDown);
            this.mtxtpData1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData1_KeyPress);
            this.mtxtpData1.Leave += new System.EventHandler(this.mtxtpData1_Leave);
            // 
            // rbtnTabelaDestino
            // 
            this.rbtnTabelaDestino.AutoSize = true;
            this.rbtnTabelaDestino.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTabelaDestino.Location = new System.Drawing.Point(6, 41);
            this.rbtnTabelaDestino.Name = "rbtnTabelaDestino";
            this.rbtnTabelaDestino.Size = new System.Drawing.Size(58, 17);
            this.rbtnTabelaDestino.TabIndex = 5;
            this.rbtnTabelaDestino.TabStop = true;
            this.rbtnTabelaDestino.Text = "Tabela";
            this.rbtnTabelaDestino.UseVisualStyleBackColor = true;
            this.rbtnTabelaDestino.CheckedChanged += new System.EventHandler(this.rbtnTabelaDestino_CheckedChanged);
            this.rbtnTabelaDestino.MouseLeave += new System.EventHandler(this.rbtnTabelaDestino_MouseLeave);
            this.rbtnTabelaDestino.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTabelaDestino_MouseMove);
            // 
            // mtxtpData
            // 
            this.mtxtpData.BackColor = System.Drawing.Color.White;
            this.mtxtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData.Location = new System.Drawing.Point(6, 77);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 11;
            this.mtxtpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData.DoubleClick += new System.EventHandler(this.mtxtpData_DoubleClick);
            this.mtxtpData.Enter += new System.EventHandler(this.mtxtpData_Enter);
            this.mtxtpData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtpData_KeyDown);
            this.mtxtpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData_KeyPress);
            this.mtxtpData.Leave += new System.EventHandler(this.mtxtpData_Leave);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(186, 19);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 4;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(254, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(114, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite a descrição:";
            // 
            // rbtnPalavraChave
            // 
            this.rbtnPalavraChave.AutoSize = true;
            this.rbtnPalavraChave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnPalavraChave.Location = new System.Drawing.Point(86, 42);
            this.rbtnPalavraChave.Name = "rbtnPalavraChave";
            this.rbtnPalavraChave.Size = new System.Drawing.Size(95, 17);
            this.rbtnPalavraChave.TabIndex = 6;
            this.rbtnPalavraChave.TabStop = true;
            this.rbtnPalavraChave.Text = "Palavra-Chave";
            this.rbtnPalavraChave.UseVisualStyleBackColor = true;
            this.rbtnPalavraChave.CheckedChanged += new System.EventHandler(this.rbtnPalavraChave_CheckedChanged);
            this.rbtnPalavraChave.MouseLeave += new System.EventHandler(this.rbtnPalavraChave_MouseLeave);
            this.rbtnPalavraChave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPalavraChave_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(86, 19);
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
            // rbtnDescricao
            // 
            this.rbtnDescricao.AutoSize = true;
            this.rbtnDescricao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnDescricao.Location = new System.Drawing.Point(6, 19);
            this.rbtnDescricao.Name = "rbtnDescricao";
            this.rbtnDescricao.Size = new System.Drawing.Size(73, 17);
            this.rbtnDescricao.TabIndex = 2;
            this.rbtnDescricao.Text = "Descrição";
            this.rbtnDescricao.UseVisualStyleBackColor = true;
            this.rbtnDescricao.CheckedChanged += new System.EventHandler(this.rbtnDescricao_CheckedChanged);
            this.rbtnDescricao.MouseLeave += new System.EventHandler(this.rbtnDescricao_MouseLeave);
            this.rbtnDescricao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnDescricao_MouseMove);
            // 
            // cbbpTabelaDestino
            // 
            this.cbbpTabelaDestino.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpTabelaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpTabelaDestino.DropDownWidth = 180;
            this.cbbpTabelaDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpTabelaDestino.FormattingEnabled = true;
            this.cbbpTabelaDestino.Items.AddRange(new object[] {
            "",
            "CONTAS A PAGAR",
            "CONTAS A RECEBER",
            "PRODUTOS"});
            this.cbbpTabelaDestino.Location = new System.Drawing.Point(434, 18);
            this.cbbpTabelaDestino.Name = "cbbpTabelaDestino";
            this.cbbpTabelaDestino.Size = new System.Drawing.Size(180, 21);
            this.cbbpTabelaDestino.TabIndex = 8;
            this.cbbpTabelaDestino.Visible = false;
            this.cbbpTabelaDestino.DropDown += new System.EventHandler(this.cbbpTabelaDestino_DropDown);
            this.cbbpTabelaDestino.DropDownClosed += new System.EventHandler(this.cbbpTabelaDestino_DropDownClosed);
            this.cbbpTabelaDestino.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpTabelaDestino_KeyPress);
            this.cbbpTabelaDestino.MouseLeave += new System.EventHandler(this.cbbpTabelaDestino_MouseLeave);
            this.cbbpTabelaDestino.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpTabelaDestino_MouseMove);
            // 
            // txtpDescricao
            // 
            this.txtpDescricao.BackColor = System.Drawing.Color.White;
            this.txtpDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpDescricao.Location = new System.Drawing.Point(374, 18);
            this.txtpDescricao.MaxLength = 60;
            this.txtpDescricao.Name = "txtpDescricao";
            this.txtpDescricao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpDescricao.Size = new System.Drawing.Size(240, 20);
            this.txtpDescricao.TabIndex = 7;
            this.txtpDescricao.Enter += new System.EventHandler(this.txtpDescricao_Enter);
            this.txtpDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpDescricao_KeyPress);
            this.txtpDescricao.Leave += new System.EventHandler(this.txtpDescricao_Leave);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpCodigo.Location = new System.Drawing.Point(572, 18);
            this.txtpCodigo.MaxLength = 5;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(42, 20);
            this.txtpCodigo.TabIndex = 10;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // txtpPalavraChave
            // 
            this.txtpPalavraChave.BackColor = System.Drawing.Color.White;
            this.txtpPalavraChave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpPalavraChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpPalavraChave.Location = new System.Drawing.Point(534, 18);
            this.txtpPalavraChave.MaxLength = 10;
            this.txtpPalavraChave.Name = "txtpPalavraChave";
            this.txtpPalavraChave.Size = new System.Drawing.Size(80, 20);
            this.txtpPalavraChave.TabIndex = 9;
            this.txtpPalavraChave.Visible = false;
            this.txtpPalavraChave.Enter += new System.EventHandler(this.txtpPalavraChave_Enter);
            this.txtpPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpPalavraChave_KeyPress);
            this.txtpPalavraChave.Leave += new System.EventHandler(this.txtpPalavraChave_Leave);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(542, 162);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 31;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // dtGrupo
            // 
            this.dtGrupo.AllowUserToAddRows = false;
            this.dtGrupo.AllowUserToDeleteRows = false;
            this.dtGrupo.AllowUserToResizeRows = false;
            this.dtGrupo.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtGrupo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrupo.Enabled = false;
            this.dtGrupo.Location = new System.Drawing.Point(30, 200);
            this.dtGrupo.MultiSelect = false;
            this.dtGrupo.Name = "dtGrupo";
            this.dtGrupo.ReadOnly = true;
            this.dtGrupo.RowHeadersVisible = false;
            this.dtGrupo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrupo.ShowCellErrors = false;
            this.dtGrupo.ShowCellToolTips = false;
            this.dtGrupo.ShowEditingIcon = false;
            this.dtGrupo.ShowRowErrors = false;
            this.dtGrupo.Size = new System.Drawing.Size(620, 172);
            this.dtGrupo.TabIndex = 12;
            this.dtGrupo.DataSourceChanged += new System.EventHandler(this.dtGrupo_DataSourceChanged);
            this.dtGrupo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrupo_CellEnter);
            this.dtGrupo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtGrupo_RowsAdded);
            this.dtGrupo.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtGrupo_RowsRemoved);
            this.dtGrupo.MouseLeave += new System.EventHandler(this.dtGrupo_MouseLeave);
            this.dtGrupo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtGrupo_MouseMove);
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.btnExportarCsv);
            this.grbBox2.Controls.Add(this.btnImprimirRel);
            this.grbBox2.Controls.Add(this.rbtnExportarTxt);
            this.grbBox2.Controls.Add(this.btnImprimir);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(30, 404);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(620, 50);
            this.grbBox2.TabIndex = 13;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Ações";
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(27, 391);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picbInterrogacao3
            // 
            this.picbInterrogacao3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao3.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao3.Image")));
            this.picbInterrogacao3.Location = new System.Drawing.Point(30, 460);
            this.picbInterrogacao3.Name = "picbInterrogacao3";
            this.picbInterrogacao3.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao3.TabIndex = 211;
            this.picbInterrogacao3.TabStop = false;
            this.picbInterrogacao3.Click += new System.EventHandler(this.picbInterrogacao3_Click);
            this.picbInterrogacao3.MouseLeave += new System.EventHandler(this.picbInterrogacao3_MouseLeave);
            this.picbInterrogacao3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao3_MouseMove);
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
            this.lblProgresso.Location = new System.Drawing.Point(190, 258);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(300, 33);
            this.lblProgresso.TabIndex = 219;
            this.lblProgresso.Text = "Por favor, aguarde...";
            this.lblProgresso.Visible = false;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.pgbProgresso.Location = new System.Drawing.Point(180, 291);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(321, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 220;
            this.pgbProgresso.Visible = false;
            // 
            // pEnabled
            // 
            this.pEnabled.Controls.Add(this.picbInterrogacao3);
            this.pEnabled.Controls.Add(this.lblProgresso);
            this.pEnabled.Controls.Add(this.btnSair);
            this.pEnabled.Controls.Add(this.grbBox1);
            this.pEnabled.Controls.Add(this.grbBox2);
            this.pEnabled.Controls.Add(this.lblRegistros);
            this.pEnabled.Controls.Add(this.pgbProgresso);
            this.pEnabled.Controls.Add(this.picbInterrogacao2);
            this.pEnabled.Controls.Add(this.btnPesquisar);
            this.pEnabled.Controls.Add(this.dtGrupo);
            this.pEnabled.Location = new System.Drawing.Point(-18, -40);
            this.pEnabled.Name = "pEnabled";
            this.pEnabled.Size = new System.Drawing.Size(678, 586);
            this.pEnabled.TabIndex = 16;
            // 
            // FrmRelGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(644, 457);
            this.ControlBox = false;
            this.Controls.Add(this.pEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelGrupo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Grupos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRelGrupo_FormClosing);
            this.Load += new System.EventHandler(this.FrmRelGrupo_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRelGrupo_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrupo)).EndInit();
            this.grbBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao3)).EndInit();
            this.pEnabled.ResumeLayout(false);
            this.pEnabled.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttpGrupo;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.RadioButton rbtnPalavraChave;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnDescricao;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.TextBox txtpPalavraChave;
        private System.Windows.Forms.TextBox txtpDescricao;
        private System.Windows.Forms.DataGridView dtGrupo;
        private System.Windows.Forms.Label lblDatas;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnExportarCsv;
        private System.Windows.Forms.Button btnImprimirRel;
        private System.Windows.Forms.Button rbtnExportarTxt;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox picbInterrogacao3;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.Windows.Forms.RadioButton rbtnTabelaDestino;
        private System.Windows.Forms.ComboBox cbbpTabelaDestino;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.Panel pEnabled;
    }
}