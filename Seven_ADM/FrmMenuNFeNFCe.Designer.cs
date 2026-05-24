namespace Seven_Sistema
{
    partial class FrmMenuNFeNFCe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuNFeNFCe));
            this.ttpMenuNFeNFCe = new System.Windows.Forms.ToolTip(this.components);
            this.btnCopiarChave = new System.Windows.Forms.Button();
            this.btnTransmitir = new System.Windows.Forms.Button();
            this.btnStatusSefaz = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnInutilizar = new System.Windows.Forms.Button();
            this.btnConsultarDFe = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCartaCorrecao = new System.Windows.Forms.Button();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnAbrirArquivo = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbSituacao = new System.Windows.Forms.ComboBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtNumeroNF = new System.Windows.Forms.TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.cbbModelo = new System.Windows.Forms.ComboBox();
            this.mtxtHorarioEmissao1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtHorarioEmissao = new System.Windows.Forms.MaskedTextBox();
            this.lblDataEntrada = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.mtxtpDataEmissao1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpDataEmissao = new System.Windows.Forms.MaskedTextBox();
            this.dtDFE = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pcibDelete = new System.Windows.Forms.PictureBox();
            this.pcibCross = new System.Windows.Forms.PictureBox();
            this.pcibTick = new System.Windows.Forms.PictureBox();
            this.rtbRespostas = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.lblResposta = new System.Windows.Forms.Label();
            this.lblChave = new System.Windows.Forms.Label();
            this.mtxtChave = new System.Windows.Forms.MaskedTextBox();
            this.lblValorSituacao = new System.Windows.Forms.Label();
            this.lblValorTotalReal = new System.Windows.Forms.Label();
            this.lblTotalReal = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDFE)).BeginInit();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibCross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibTick)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.SuspendLayout();
            // 
            // ttpMenuNFeNFCe
            // 
            this.ttpMenuNFeNFCe.AutoPopDelay = 5000;
            this.ttpMenuNFeNFCe.InitialDelay = 1000;
            this.ttpMenuNFeNFCe.IsBalloon = true;
            this.ttpMenuNFeNFCe.ReshowDelay = 100;
            this.ttpMenuNFeNFCe.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpMenuNFeNFCe.ToolTipTitle = "Dica:";
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
            this.ttpMenuNFeNFCe.SetToolTip(this.btnCopiarChave, "Cópiar campo Chave par a área de trasnferência.");
            this.btnCopiarChave.UseVisualStyleBackColor = true;
            this.btnCopiarChave.Click += new System.EventHandler(this.btnAdicionarEstoque_Click);
            this.btnCopiarChave.MouseLeave += new System.EventHandler(this.btnCopiarChave_MouseLeave);
            this.btnCopiarChave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCopiarChave_MouseMove);
            // 
            // btnTransmitir
            // 
            this.btnTransmitir.Enabled = false;
            this.btnTransmitir.Image = ((System.Drawing.Image)(resources.GetObject("btnTransmitir.Image")));
            this.btnTransmitir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnTransmitir.Location = new System.Drawing.Point(39, 19);
            this.btnTransmitir.Name = "btnTransmitir";
            this.btnTransmitir.Size = new System.Drawing.Size(85, 32);
            this.btnTransmitir.TabIndex = 17;
            this.btnTransmitir.Text = "&Transmitir";
            this.btnTransmitir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMenuNFeNFCe.SetToolTip(this.btnTransmitir, "Clique para Transmitir o DFe selecionado.");
            this.btnTransmitir.UseVisualStyleBackColor = true;
            this.btnTransmitir.Click += new System.EventHandler(this.btnTransmitir_Click);
            this.btnTransmitir.MouseLeave += new System.EventHandler(this.btnTransmitir_MouseLeave);
            this.btnTransmitir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnTransmitir_MouseMove);
            // 
            // btnStatusSefaz
            // 
            this.btnStatusSefaz.Image = ((System.Drawing.Image)(resources.GetObject("btnStatusSefaz.Image")));
            this.btnStatusSefaz.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnStatusSefaz.Location = new System.Drawing.Point(163, 57);
            this.btnStatusSefaz.Name = "btnStatusSefaz";
            this.btnStatusSefaz.Size = new System.Drawing.Size(114, 32);
            this.btnStatusSefaz.TabIndex = 22;
            this.btnStatusSefaz.Text = "Consultar Stat&us";
            this.btnStatusSefaz.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMenuNFeNFCe.SetToolTip(this.btnStatusSefaz, "Clique para Consultar o serviço da SEFAZ.");
            this.btnStatusSefaz.UseVisualStyleBackColor = true;
            this.btnStatusSefaz.Click += new System.EventHandler(this.btnStatusSefaz_Click);
            this.btnStatusSefaz.MouseLeave += new System.EventHandler(this.btnStatusSefaz_MouseLeave);
            this.btnStatusSefaz.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnStatusSefaz_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.Location = new System.Drawing.Point(326, 19);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancela&r";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMenuNFeNFCe.SetToolTip(this.btnCancelar, "Clique para Cancelar o DFe selecionado.");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            this.btnCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelar_MouseMove);
            // 
            // btnInutilizar
            // 
            this.btnInutilizar.Enabled = false;
            this.btnInutilizar.Image = ((System.Drawing.Image)(resources.GetObject("btnInutilizar.Image")));
            this.btnInutilizar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnInutilizar.Location = new System.Drawing.Point(241, 19);
            this.btnInutilizar.Name = "btnInutilizar";
            this.btnInutilizar.Size = new System.Drawing.Size(81, 32);
            this.btnInutilizar.TabIndex = 19;
            this.btnInutilizar.Text = "I&nutilizar";
            this.btnInutilizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMenuNFeNFCe.SetToolTip(this.btnInutilizar, "Clique para Inutilizar o DFe selecionado.");
            this.btnInutilizar.UseVisualStyleBackColor = true;
            this.btnInutilizar.Click += new System.EventHandler(this.btnInutilizar_Click);
            this.btnInutilizar.MouseLeave += new System.EventHandler(this.btnInutilizar_MouseLeave);
            this.btnInutilizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnInutilizar_MouseMove);
            // 
            // btnConsultarDFe
            // 
            this.btnConsultarDFe.Enabled = false;
            this.btnConsultarDFe.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultarDFe.Image")));
            this.btnConsultarDFe.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnConsultarDFe.Location = new System.Drawing.Point(129, 19);
            this.btnConsultarDFe.Name = "btnConsultarDFe";
            this.btnConsultarDFe.Size = new System.Drawing.Size(106, 32);
            this.btnConsultarDFe.TabIndex = 18;
            this.btnConsultarDFe.Text = "&Consultar DFe";
            this.btnConsultarDFe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMenuNFeNFCe.SetToolTip(this.btnConsultarDFe, "Clique para Consultar o DFe slecionado.");
            this.btnConsultarDFe.UseVisualStyleBackColor = true;
            this.btnConsultarDFe.Click += new System.EventHandler(this.btnConsultarDFe_Click);
            this.btnConsultarDFe.MouseLeave += new System.EventHandler(this.btnConsultarDFe_MouseLeave);
            this.btnConsultarDFe.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnConsultarDFe_MouseMove);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnImprimir.Location = new System.Drawing.Point(41, 57);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(116, 32);
            this.btnImprimir.TabIndex = 21;
            this.btnImprimir.Text = "&Imprimir DANFE";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMenuNFeNFCe.SetToolTip(this.btnImprimir, "Clique para Imprimir o DFe selecionado.");
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            this.btnImprimir.MouseLeave += new System.EventHandler(this.btnImprimir_MouseLeave);
            this.btnImprimir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnImprimir_MouseMove);
            // 
            // btnCartaCorrecao
            // 
            this.btnCartaCorrecao.Enabled = false;
            this.btnCartaCorrecao.Image = ((System.Drawing.Image)(resources.GetObject("btnCartaCorrecao.Image")));
            this.btnCartaCorrecao.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCartaCorrecao.Location = new System.Drawing.Point(283, 57);
            this.btnCartaCorrecao.Name = "btnCartaCorrecao";
            this.btnCartaCorrecao.Size = new System.Drawing.Size(128, 32);
            this.btnCartaCorrecao.TabIndex = 23;
            this.btnCartaCorrecao.Text = "Carta &de Correção";
            this.btnCartaCorrecao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMenuNFeNFCe.SetToolTip(this.btnCartaCorrecao, "Clique para realizar a Carta de Correção do DFe selecionado.");
            this.btnCartaCorrecao.UseVisualStyleBackColor = true;
            this.btnCartaCorrecao.Click += new System.EventHandler(this.btnCartaCorrecao_Click);
            this.btnCartaCorrecao.MouseLeave += new System.EventHandler(this.btnCartaCorrecao_MouseLeave);
            this.btnCartaCorrecao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCartaCorrecao_MouseMove);
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
            this.ttpMenuNFeNFCe.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
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
            this.ttpMenuNFeNFCe.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // btnAbrirArquivo
            // 
            this.btnAbrirArquivo.Enabled = false;
            this.btnAbrirArquivo.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrirArquivo.Image")));
            this.btnAbrirArquivo.Location = new System.Drawing.Point(861, 30);
            this.btnAbrirArquivo.Name = "btnAbrirArquivo";
            this.btnAbrirArquivo.Size = new System.Drawing.Size(26, 25);
            this.btnAbrirArquivo.TabIndex = 17;
            this.btnAbrirArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMenuNFeNFCe.SetToolTip(this.btnAbrirArquivo, "Clique para abrir/Localizar o XML do DFe selecionado.");
            this.btnAbrirArquivo.UseVisualStyleBackColor = true;
            this.btnAbrirArquivo.Click += new System.EventHandler(this.btnAbrirArquivo_Click);
            this.btnAbrirArquivo.MouseLeave += new System.EventHandler(this.btnAbrirArquivo_MouseLeave);
            this.btnAbrirArquivo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAbrirArquivo_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(853, 497);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 24;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMenuNFeNFCe.SetToolTip(this.btnSair, "Clique para sair do Menu NFe/NFCe.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.label1);
            this.grbBox1.Controls.Add(this.cbbSituacao);
            this.grbBox1.Controls.Add(this.lblModelo);
            this.grbBox1.Controls.Add(this.txtNumeroNF);
            this.grbBox1.Controls.Add(this.lblNumero);
            this.grbBox1.Controls.Add(this.cbbModelo);
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
            "DENEGADA",
            "CANCELADA",
            "INUTILIZADA",
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
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelo.Location = new System.Drawing.Point(6, 16);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(52, 13);
            this.lblModelo.TabIndex = 0;
            this.lblModelo.Text = "Modelo:";
            // 
            // txtNumeroNF
            // 
            this.txtNumeroNF.BackColor = System.Drawing.Color.White;
            this.txtNumeroNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroNF.Location = new System.Drawing.Point(214, 32);
            this.txtNumeroNF.MaxLength = 10;
            this.txtNumeroNF.Name = "txtNumeroNF";
            this.txtNumeroNF.Size = new System.Drawing.Size(80, 20);
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
            this.lblNumero.Size = new System.Drawing.Size(92, 13);
            this.lblNumero.TabIndex = 0;
            this.lblNumero.Text = "Número da NF:";
            // 
            // cbbModelo
            // 
            this.cbbModelo.BackColor = System.Drawing.Color.LightBlue;
            this.cbbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbModelo.DropDownWidth = 115;
            this.cbbModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbModelo.FormattingEnabled = true;
            this.cbbModelo.Items.AddRange(new object[] {
            "",
            "MODELO 55 (NFe)",
            "MODELO 65 (NFCe)"});
            this.cbbModelo.Location = new System.Drawing.Point(9, 32);
            this.cbbModelo.Name = "cbbModelo";
            this.cbbModelo.Size = new System.Drawing.Size(144, 21);
            this.cbbModelo.TabIndex = 2;
            this.cbbModelo.DropDown += new System.EventHandler(this.cbbModelo_DropDown);
            this.cbbModelo.DropDownClosed += new System.EventHandler(this.cbbModelo_DropDownClosed);
            this.cbbModelo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbModelo_KeyPress);
            this.cbbModelo.MouseLeave += new System.EventHandler(this.cbbModelo_MouseLeave);
            this.cbbModelo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbModelo_MouseMove);
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
            // dtDFE
            // 
            this.dtDFE.AllowUserToAddRows = false;
            this.dtDFE.AllowUserToDeleteRows = false;
            this.dtDFE.AllowUserToResizeRows = false;
            this.dtDFE.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtDFE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDFE.Enabled = false;
            this.dtDFE.Location = new System.Drawing.Point(12, 120);
            this.dtDFE.MultiSelect = false;
            this.dtDFE.Name = "dtDFE";
            this.dtDFE.ReadOnly = true;
            this.dtDFE.RowHeadersVisible = false;
            this.dtDFE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtDFE.ShowCellErrors = false;
            this.dtDFE.ShowCellToolTips = false;
            this.dtDFE.ShowEditingIcon = false;
            this.dtDFE.ShowRowErrors = false;
            this.dtDFE.Size = new System.Drawing.Size(895, 172);
            this.dtDFE.TabIndex = 11;
            this.dtDFE.TabStop = false;
            this.dtDFE.DataSourceChanged += new System.EventHandler(this.dtDFE_DataSourceChanged);
            this.dtDFE.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtDFE_CellEnter);
            this.dtDFE.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtDFE_CellFormatting);
            this.dtDFE.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtDFE_DataBindingComplete);
            this.dtDFE.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtDFE_RowsAdded);
            this.dtDFE.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtDFE_RowsRemoved);
            this.dtDFE.EnabledChanged += new System.EventHandler(this.dtDFE_EnabledChanged);
            this.dtDFE.MouseLeave += new System.EventHandler(this.dtDFE_MouseLeave);
            this.dtDFE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtDFE_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(10, 297);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(141, 25);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.pcibTick);
            this.grbBox2.Controls.Add(this.btnAbrirArquivo);
            this.grbBox2.Controls.Add(this.btnCopiarChave);
            this.grbBox2.Controls.Add(this.rtbRespostas);
            this.grbBox2.Controls.Add(this.groupBox1);
            this.grbBox2.Controls.Add(this.lblResposta);
            this.grbBox2.Controls.Add(this.lblChave);
            this.grbBox2.Controls.Add(this.mtxtChave);
            this.grbBox2.Controls.Add(this.lblValorSituacao);
            this.grbBox2.Controls.Add(this.pictureBox1);
            this.grbBox2.Controls.Add(this.pcibDelete);
            this.grbBox2.Controls.Add(this.pcibCross);
            this.grbBox2.Location = new System.Drawing.Point(12, 324);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(895, 167);
            this.grbBox2.TabIndex = 12;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Ações:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 233;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pcibDelete
            // 
            this.pcibDelete.Image = ((System.Drawing.Image)(resources.GetObject("pcibDelete.Image")));
            this.pcibDelete.Location = new System.Drawing.Point(9, 19);
            this.pcibDelete.Name = "pcibDelete";
            this.pcibDelete.Size = new System.Drawing.Size(27, 25);
            this.pcibDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcibDelete.TabIndex = 232;
            this.pcibDelete.TabStop = false;
            this.pcibDelete.Visible = false;
            // 
            // pcibCross
            // 
            this.pcibCross.Image = ((System.Drawing.Image)(resources.GetObject("pcibCross.Image")));
            this.pcibCross.Location = new System.Drawing.Point(9, 19);
            this.pcibCross.Name = "pcibCross";
            this.pcibCross.Size = new System.Drawing.Size(27, 25);
            this.pcibCross.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcibCross.TabIndex = 231;
            this.pcibCross.TabStop = false;
            this.pcibCross.Visible = false;
            // 
            // pcibTick
            // 
            this.pcibTick.Image = ((System.Drawing.Image)(resources.GetObject("pcibTick.Image")));
            this.pcibTick.Location = new System.Drawing.Point(9, 19);
            this.pcibTick.Name = "pcibTick";
            this.pcibTick.Size = new System.Drawing.Size(27, 25);
            this.pcibTick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcibTick.TabIndex = 227;
            this.pcibTick.TabStop = false;
            this.pcibTick.Visible = false;
            // 
            // rtbRespostas
            // 
            this.rtbRespostas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbRespostas.Location = new System.Drawing.Point(6, 61);
            this.rtbRespostas.Name = "rtbRespostas";
            this.rtbRespostas.ReadOnly = true;
            this.rtbRespostas.Size = new System.Drawing.Size(433, 97);
            this.rtbRespostas.TabIndex = 15;
            this.rtbRespostas.Text = "";
            this.rtbRespostas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbRespostas_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picbInterrogacao2);
            this.groupBox1.Controls.Add(this.btnCartaCorrecao);
            this.groupBox1.Controls.Add(this.btnTransmitir);
            this.groupBox1.Controls.Add(this.btnStatusSefaz);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnInutilizar);
            this.groupBox1.Controls.Add(this.btnConsultarDFe);
            this.groupBox1.Controls.Add(this.btnImprimir);
            this.groupBox1.Location = new System.Drawing.Point(445, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 100);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(6, 19);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 270;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.pictureBox1_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // lblResposta
            // 
            this.lblResposta.AutoSize = true;
            this.lblResposta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResposta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblResposta.Location = new System.Drawing.Point(6, 45);
            this.lblResposta.Name = "lblResposta";
            this.lblResposta.Size = new System.Drawing.Size(107, 13);
            this.lblResposta.TabIndex = 0;
            this.lblResposta.Text = "Resposta da SEFAZ:";
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
            this.mtxtChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtChave_KeyPress);
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
            // lblValorTotalReal
            // 
            this.lblValorTotalReal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorTotalReal.BackColor = System.Drawing.Color.White;
            this.lblValorTotalReal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotalReal.Enabled = false;
            this.lblValorTotalReal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalReal.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotalReal.Location = new System.Drawing.Point(429, 295);
            this.lblValorTotalReal.Name = "lblValorTotalReal";
            this.lblValorTotalReal.Size = new System.Drawing.Size(95, 26);
            this.lblValorTotalReal.TabIndex = 0;
            this.lblValorTotalReal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotalReal.Click += new System.EventHandler(this.lblValorTotalReal_Click);
            this.lblValorTotalReal.MouseLeave += new System.EventHandler(this.lblValorTotalReal_MouseLeave);
            this.lblValorTotalReal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotalReal_MouseMove);
            // 
            // lblTotalReal
            // 
            this.lblTotalReal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalReal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalReal.Enabled = false;
            this.lblTotalReal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalReal.ForeColor = System.Drawing.Color.Black;
            this.lblTotalReal.Location = new System.Drawing.Point(253, 295);
            this.lblTotalReal.Name = "lblTotalReal";
            this.lblTotalReal.Size = new System.Drawing.Size(179, 26);
            this.lblTotalReal.TabIndex = 0;
            this.lblTotalReal.Text = "Total dos Produtos (R$):";
            this.lblTotalReal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorTotal.BackColor = System.Drawing.Color.White;
            this.lblValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotal.Enabled = false;
            this.lblValorTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotal.Location = new System.Drawing.Point(813, 295);
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
            this.lblTotal.Location = new System.Drawing.Point(685, 294);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(139, 26);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total das NF (R$):";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.picbInterrogacao.TabIndex = 254;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao1.Location = new System.Drawing.Point(12, 497);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 269;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
            this.btnLimpar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpar.Location = new System.Drawing.Point(12, 82);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(95, 25);
            this.btnLimpar.TabIndex = 270;
            this.btnLimpar.Text = "&Limpar Filtros";
            this.btnLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // FrmMenuNFeNFCe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(920, 534);
            this.ControlBox = false;
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.picbInterrogacao1);
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblValorTotalReal);
            this.Controls.Add(this.lblTotalReal);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox2);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.dtDFE);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenuNFeNFCe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu NFe/NFCe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMenuNFeNFCe_FormClosing);
            this.Load += new System.EventHandler(this.FrmConfEnviarEmail_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmMenuNFeNFCe_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDFE)).EndInit();
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibCross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibTick)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttpMenuNFeNFCe;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.TextBox txtNumeroNF;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.ComboBox cbbModelo;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.MaskedTextBox mtxtHorarioEmissao1;
        private System.Windows.Forms.MaskedTextBox mtxtHorarioEmissao;
        private System.Windows.Forms.Label lblDataEntrada;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.MaskedTextBox mtxtpDataEmissao1;
        private System.Windows.Forms.MaskedTextBox mtxtpDataEmissao;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.DataGridView dtDFE;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Label lblValorSituacao;
        private System.Windows.Forms.Button btnStatusSefaz;
        private System.Windows.Forms.Button btnTransmitir;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnInutilizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnConsultarDFe;
        private System.Windows.Forms.Label lblValorTotalReal;
        private System.Windows.Forms.Label lblTotalReal;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbSituacao;
        private System.Windows.Forms.Label lblChave;
        private System.Windows.Forms.MaskedTextBox mtxtChave;
        private System.Windows.Forms.Label lblResposta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbRespostas;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnCopiarChave;
        private System.Windows.Forms.Button btnCartaCorrecao;
        private System.Windows.Forms.Button btnAbrirArquivo;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.PictureBox pcibTick;
        private System.Windows.Forms.PictureBox pcibCross;
        private System.Windows.Forms.PictureBox pcibDelete;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLimpar;
    }
}