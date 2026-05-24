namespace Seven_ADM
{
    partial class FrmIntegracoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIntegracoes));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnProcurarPagamento = new System.Windows.Forms.Button();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.lblValorAcrescimo = new System.Windows.Forms.Label();
            this.lblValorDesconto = new System.Windows.Forms.Label();
            this.lblCancelada = new System.Windows.Forms.Label();
            this.lblValorTotalReal = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblTotalReal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblAcrescimo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.cbbFormaPagamento = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGerarCupom = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbSituacao = new System.Windows.Forms.ComboBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.mtxtHorarioEmissao1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtHorarioEmissao = new System.Windows.Forms.MaskedTextBox();
            this.lblDataEntrada = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.mtxtpDataEmissao1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpDataEmissao = new System.Windows.Forms.MaskedTextBox();
            this.btnImportar = new System.Windows.Forms.Button();
            this.lblRegFormaPagamento = new System.Windows.Forms.Label();
            this.lblRegItem = new System.Windows.Forms.Label();
            this.lblRegPedido = new System.Windows.Forms.Label();
            this.dtFormaPagamento = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.dtItemPedido = new System.Windows.Forms.DataGridView();
            this.pcibImagemLogo = new System.Windows.Forms.PictureBox();
            this.dtPedido = new System.Windows.Forms.DataGridView();
            this.btnSair = new System.Windows.Forms.Button();
            this.ttpIntegracao = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFormaPagamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtItemPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagemLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPedido)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 538);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.btnProcurarPagamento);
            this.tabPage1.Controls.Add(this.picbInterrogacao1);
            this.tabPage1.Controls.Add(this.lblValorAcrescimo);
            this.tabPage1.Controls.Add(this.lblValorDesconto);
            this.tabPage1.Controls.Add(this.lblCancelada);
            this.tabPage1.Controls.Add(this.lblValorTotalReal);
            this.tabPage1.Controls.Add(this.lblValorTotal);
            this.tabPage1.Controls.Add(this.lblTotalReal);
            this.tabPage1.Controls.Add(this.lblTotal);
            this.tabPage1.Controls.Add(this.lblAcrescimo);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtpCodigo);
            this.tabPage1.Controls.Add(this.lblFormaPagamento);
            this.tabPage1.Controls.Add(this.cbbFormaPagamento);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btnGerarCupom);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cbbSituacao);
            this.tabPage1.Controls.Add(this.btnPesquisar);
            this.tabPage1.Controls.Add(this.btnSelecionarData);
            this.tabPage1.Controls.Add(this.mtxtHorarioEmissao1);
            this.tabPage1.Controls.Add(this.mtxtHorarioEmissao);
            this.tabPage1.Controls.Add(this.lblDataEntrada);
            this.tabPage1.Controls.Add(this.lblAte);
            this.tabPage1.Controls.Add(this.mtxtpDataEmissao1);
            this.tabPage1.Controls.Add(this.mtxtpDataEmissao);
            this.tabPage1.Controls.Add(this.btnImportar);
            this.tabPage1.Controls.Add(this.lblRegFormaPagamento);
            this.tabPage1.Controls.Add(this.lblRegItem);
            this.tabPage1.Controls.Add(this.lblRegPedido);
            this.tabPage1.Controls.Add(this.dtFormaPagamento);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblItem);
            this.tabPage1.Controls.Add(this.dtItemPedido);
            this.tabPage1.Controls.Add(this.pcibImagemLogo);
            this.tabPage1.Controls.Add(this.dtPedido);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(976, 505);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Anota.ai";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnProcurarPagamento
            // 
            this.btnProcurarPagamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcurarPagamento.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarPagamento.Image")));
            this.btnProcurarPagamento.Location = new System.Drawing.Point(724, 16);
            this.btnProcurarPagamento.Name = "btnProcurarPagamento";
            this.btnProcurarPagamento.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarPagamento.TabIndex = 247;
            this.btnProcurarPagamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpIntegracao.SetToolTip(this.btnProcurarPagamento, "Clique para pesquisar uma Forma de Pagamento.");
            this.btnProcurarPagamento.UseVisualStyleBackColor = true;
            this.btnProcurarPagamento.Click += new System.EventHandler(this.btnProcurarPagamento_Click);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(862, 19);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 246;
            this.picbInterrogacao1.TabStop = false;
            // 
            // lblValorAcrescimo
            // 
            this.lblValorAcrescimo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorAcrescimo.BackColor = System.Drawing.Color.White;
            this.lblValorAcrescimo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorAcrescimo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblValorAcrescimo.Enabled = false;
            this.lblValorAcrescimo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorAcrescimo.ForeColor = System.Drawing.Color.Black;
            this.lblValorAcrescimo.Location = new System.Drawing.Point(875, 446);
            this.lblValorAcrescimo.Name = "lblValorAcrescimo";
            this.lblValorAcrescimo.Size = new System.Drawing.Size(95, 26);
            this.lblValorAcrescimo.TabIndex = 244;
            this.lblValorAcrescimo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorAcrescimo.Click += new System.EventHandler(this.lblValorAcrescimo_Click);
            // 
            // lblValorDesconto
            // 
            this.lblValorDesconto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDesconto.BackColor = System.Drawing.Color.White;
            this.lblValorDesconto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDesconto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblValorDesconto.Enabled = false;
            this.lblValorDesconto.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDesconto.ForeColor = System.Drawing.Color.Black;
            this.lblValorDesconto.Location = new System.Drawing.Point(662, 446);
            this.lblValorDesconto.Name = "lblValorDesconto";
            this.lblValorDesconto.Size = new System.Drawing.Size(95, 26);
            this.lblValorDesconto.TabIndex = 242;
            this.lblValorDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorDesconto.Click += new System.EventHandler(this.lblValorDesconto_Click);
            // 
            // lblCancelada
            // 
            this.lblCancelada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCancelada.BackColor = System.Drawing.Color.Transparent;
            this.lblCancelada.Enabled = false;
            this.lblCancelada.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelada.ForeColor = System.Drawing.Color.Black;
            this.lblCancelada.Location = new System.Drawing.Point(551, 445);
            this.lblCancelada.Name = "lblCancelada";
            this.lblCancelada.Size = new System.Drawing.Size(128, 26);
            this.lblCancelada.TabIndex = 243;
            this.lblCancelada.Text = "Descontos (R$):";
            this.lblCancelada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorTotalReal
            // 
            this.lblValorTotalReal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorTotalReal.BackColor = System.Drawing.Color.White;
            this.lblValorTotalReal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotalReal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblValorTotalReal.Enabled = false;
            this.lblValorTotalReal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalReal.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotalReal.Location = new System.Drawing.Point(875, 472);
            this.lblValorTotalReal.Name = "lblValorTotalReal";
            this.lblValorTotalReal.Size = new System.Drawing.Size(95, 26);
            this.lblValorTotalReal.TabIndex = 238;
            this.lblValorTotalReal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotalReal.Click += new System.EventHandler(this.lblValorTotalReal_Click);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorTotal.BackColor = System.Drawing.Color.White;
            this.lblValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblValorTotal.Enabled = false;
            this.lblValorTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotal.Location = new System.Drawing.Point(662, 472);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(95, 26);
            this.lblValorTotal.TabIndex = 239;
            this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotal.Click += new System.EventHandler(this.lblValorTotal_Click);
            // 
            // lblTotalReal
            // 
            this.lblTotalReal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalReal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalReal.Enabled = false;
            this.lblTotalReal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalReal.ForeColor = System.Drawing.Color.Black;
            this.lblTotalReal.Location = new System.Drawing.Point(761, 472);
            this.lblTotalReal.Name = "lblTotalReal";
            this.lblTotalReal.Size = new System.Drawing.Size(135, 26);
            this.lblTotalReal.TabIndex = 240;
            this.lblTotalReal.Text = "Valor Total (R$):";
            this.lblTotalReal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Enabled = false;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(583, 471);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(128, 26);
            this.lblTotal.TabIndex = 241;
            this.lblTotal.Text = "Total  (R$):";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAcrescimo
            // 
            this.lblAcrescimo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAcrescimo.BackColor = System.Drawing.Color.Transparent;
            this.lblAcrescimo.Enabled = false;
            this.lblAcrescimo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcrescimo.ForeColor = System.Drawing.Color.Black;
            this.lblAcrescimo.Location = new System.Drawing.Point(757, 446);
            this.lblAcrescimo.Name = "lblAcrescimo";
            this.lblAcrescimo.Size = new System.Drawing.Size(128, 26);
            this.lblAcrescimo.TabIndex = 245;
            this.lblAcrescimo.Text = "Acréscimos (R$):";
            this.lblAcrescimo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(159, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 87;
            this.label5.Text = "Código:";
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(162, 19);
            this.txtpCodigo.MaxLength = 10;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(47, 20);
            this.txtpCodigo.TabIndex = 2;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormaPagamento.Location = new System.Drawing.Point(570, 3);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(130, 13);
            this.lblFormaPagamento.TabIndex = 84;
            this.lblFormaPagamento.Text = "Forma de Pagamento:";
            // 
            // cbbFormaPagamento
            // 
            this.cbbFormaPagamento.BackColor = System.Drawing.Color.LightBlue;
            this.cbbFormaPagamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFormaPagamento.DropDownWidth = 230;
            this.cbbFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbFormaPagamento.FormattingEnabled = true;
            this.cbbFormaPagamento.Location = new System.Drawing.Point(573, 19);
            this.cbbFormaPagamento.Name = "cbbFormaPagamento";
            this.cbbFormaPagamento.Size = new System.Drawing.Size(145, 21);
            this.cbbFormaPagamento.TabIndex = 7;
            this.cbbFormaPagamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbFormaPagamento_KeyPress);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(895, 417);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 83;
            this.button1.Text = "Associa&r";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpIntegracao.SetToolTip(this.button1, "Clique para associar um item já cadastrada a um item não encontrado.");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGerarCupom
            // 
            this.btnGerarCupom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerarCupom.Image = ((System.Drawing.Image)(resources.GetObject("btnGerarCupom.Image")));
            this.btnGerarCupom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerarCupom.Location = new System.Drawing.Point(895, 243);
            this.btnGerarCupom.Name = "btnGerarCupom";
            this.btnGerarCupom.Size = new System.Drawing.Size(75, 25);
            this.btnGerarCupom.TabIndex = 82;
            this.btnGerarCupom.Text = "&Associar";
            this.btnGerarCupom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpIntegracao.SetToolTip(this.btnGerarCupom, "Clique para associar um item já cadastrada a um item não encontrado.");
            this.btnGerarCupom.UseVisualStyleBackColor = true;
            this.btnGerarCupom.Click += new System.EventHandler(this.btnGerarCupom_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(753, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 80;
            this.label3.Text = "Situação:";
            // 
            // cbbSituacao
            // 
            this.cbbSituacao.BackColor = System.Drawing.Color.LightBlue;
            this.cbbSituacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSituacao.DropDownWidth = 115;
            this.cbbSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSituacao.FormattingEnabled = true;
            this.cbbSituacao.Items.AddRange(new object[] {
            "",
            "PENDENTE",
            "FINALIZADO"});
            this.cbbSituacao.Location = new System.Drawing.Point(756, 19);
            this.cbbSituacao.Name = "cbbSituacao";
            this.cbbSituacao.Size = new System.Drawing.Size(100, 21);
            this.cbbSituacao.TabIndex = 8;
            this.cbbSituacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbSituacao_KeyPress);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPesquisar.Location = new System.Drawing.Point(888, 12);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 9;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpIntegracao.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(541, 16);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 6;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpIntegracao.SetToolTip(this.btnSelecionarData, "Clique para selecionar a data.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            // 
            // mtxtHorarioEmissao1
            // 
            this.mtxtHorarioEmissao1.BackColor = System.Drawing.Color.White;
            this.mtxtHorarioEmissao1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorarioEmissao1.Location = new System.Drawing.Point(478, 19);
            this.mtxtHorarioEmissao1.Mask = "00:00:00";
            this.mtxtHorarioEmissao1.Name = "mtxtHorarioEmissao1";
            this.mtxtHorarioEmissao1.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorarioEmissao1.TabIndex = 6;
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
            this.mtxtHorarioEmissao.Location = new System.Drawing.Point(299, 19);
            this.mtxtHorarioEmissao.Mask = "00:00:00";
            this.mtxtHorarioEmissao.Name = "mtxtHorarioEmissao";
            this.mtxtHorarioEmissao.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorarioEmissao.TabIndex = 4;
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
            this.lblDataEntrada.Location = new System.Drawing.Point(305, 3);
            this.lblDataEntrada.Name = "lblDataEntrada";
            this.lblDataEntrada.Size = new System.Drawing.Size(155, 13);
            this.lblDataEntrada.TabIndex = 77;
            this.lblDataEntrada.Text = "Data e Horário do Pedido:";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(362, 22);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 78;
            this.lblAte.Text = "Até:";
            // 
            // mtxtpDataEmissao1
            // 
            this.mtxtpDataEmissao1.BackColor = System.Drawing.Color.White;
            this.mtxtpDataEmissao1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpDataEmissao1.Location = new System.Drawing.Point(394, 19);
            this.mtxtpDataEmissao1.Mask = "00/00/0000";
            this.mtxtpDataEmissao1.Name = "mtxtpDataEmissao1";
            this.mtxtpDataEmissao1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpDataEmissao1.TabIndex = 5;
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
            this.mtxtpDataEmissao.Location = new System.Drawing.Point(215, 19);
            this.mtxtpDataEmissao.Mask = "00/00/0000";
            this.mtxtpDataEmissao.Name = "mtxtpDataEmissao";
            this.mtxtpDataEmissao.Size = new System.Drawing.Size(78, 20);
            this.mtxtpDataEmissao.TabIndex = 3;
            this.mtxtpDataEmissao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpDataEmissao.DoubleClick += new System.EventHandler(this.mtxtpDataEmissao_DoubleClick);
            this.mtxtpDataEmissao.Enter += new System.EventHandler(this.mtxtpDataEmissao_Enter);
            this.mtxtpDataEmissao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpDataEmissao_KeyPress);
            this.mtxtpDataEmissao.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpDataEmissao_KeyUp);
            this.mtxtpDataEmissao.Leave += new System.EventHandler(this.mtxtpDataEmissao_Leave);
            // 
            // btnImportar
            // 
            this.btnImportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnImportar.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.Image")));
            this.btnImportar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnImportar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnImportar.Location = new System.Drawing.Point(6, 465);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(80, 32);
            this.btnImportar.TabIndex = 76;
            this.btnImportar.Text = "&Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportar.UseVisualStyleBackColor = true;
            // 
            // lblRegFormaPagamento
            // 
            this.lblRegFormaPagamento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegFormaPagamento.BackColor = System.Drawing.Color.Transparent;
            this.lblRegFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRegFormaPagamento.ForeColor = System.Drawing.Color.Black;
            this.lblRegFormaPagamento.Location = new System.Drawing.Point(600, 415);
            this.lblRegFormaPagamento.Name = "lblRegFormaPagamento";
            this.lblRegFormaPagamento.Size = new System.Drawing.Size(163, 16);
            this.lblRegFormaPagamento.TabIndex = 27;
            this.lblRegFormaPagamento.Text = "Forma de Pagamento 0";
            this.lblRegFormaPagamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegItem
            // 
            this.lblRegItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegItem.BackColor = System.Drawing.Color.Transparent;
            this.lblRegItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRegItem.ForeColor = System.Drawing.Color.Black;
            this.lblRegItem.Location = new System.Drawing.Point(600, 240);
            this.lblRegItem.Name = "lblRegItem";
            this.lblRegItem.Size = new System.Drawing.Size(80, 16);
            this.lblRegItem.TabIndex = 26;
            this.lblRegItem.Text = "Itens: 0";
            this.lblRegItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegPedido
            // 
            this.lblRegPedido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegPedido.BackColor = System.Drawing.Color.Transparent;
            this.lblRegPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRegPedido.ForeColor = System.Drawing.Color.Black;
            this.lblRegPedido.Location = new System.Drawing.Point(6, 446);
            this.lblRegPedido.Name = "lblRegPedido";
            this.lblRegPedido.Size = new System.Drawing.Size(160, 16);
            this.lblRegPedido.TabIndex = 25;
            this.lblRegPedido.Text = "Pedidos: 0";
            this.lblRegPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtFormaPagamento
            // 
            this.dtFormaPagamento.AllowUserToAddRows = false;
            this.dtFormaPagamento.AllowUserToDeleteRows = false;
            this.dtFormaPagamento.AllowUserToResizeRows = false;
            this.dtFormaPagamento.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtFormaPagamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtFormaPagamento.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dtFormaPagamento.Enabled = false;
            this.dtFormaPagamento.Location = new System.Drawing.Point(600, 300);
            this.dtFormaPagamento.MultiSelect = false;
            this.dtFormaPagamento.Name = "dtFormaPagamento";
            this.dtFormaPagamento.ReadOnly = true;
            this.dtFormaPagamento.RowHeadersVisible = false;
            this.dtFormaPagamento.RowHeadersWidth = 51;
            this.dtFormaPagamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtFormaPagamento.ShowCellErrors = false;
            this.dtFormaPagamento.ShowCellToolTips = false;
            this.dtFormaPagamento.ShowEditingIcon = false;
            this.dtFormaPagamento.ShowRowErrors = false;
            this.dtFormaPagamento.Size = new System.Drawing.Size(370, 111);
            this.dtFormaPagamento.TabIndex = 24;
            this.dtFormaPagamento.DataSourceChanged += new System.EventHandler(this.dtFormaPagamento_DataSourceChanged);
            this.dtFormaPagamento.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtFormaPagamento_CellEnter);
            this.dtFormaPagamento.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtFormaPagamento_RowsAdded);
            this.dtFormaPagamento.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtFormaPagamento_RowsRemoved);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(600, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 19);
            this.label2.TabIndex = 23;
            this.label2.Text = "Forma de Pagamento";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(600, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "Itens do Pedido";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblItem
            // 
            this.lblItem.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(6, 47);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(588, 19);
            this.lblItem.TabIndex = 21;
            this.lblItem.Text = "Pedido";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtItemPedido
            // 
            this.dtItemPedido.AllowUserToAddRows = false;
            this.dtItemPedido.AllowUserToDeleteRows = false;
            this.dtItemPedido.AllowUserToResizeRows = false;
            this.dtItemPedido.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtItemPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtItemPedido.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dtItemPedido.Enabled = false;
            this.dtItemPedido.Location = new System.Drawing.Point(600, 65);
            this.dtItemPedido.MultiSelect = false;
            this.dtItemPedido.Name = "dtItemPedido";
            this.dtItemPedido.ReadOnly = true;
            this.dtItemPedido.RowHeadersVisible = false;
            this.dtItemPedido.RowHeadersWidth = 51;
            this.dtItemPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtItemPedido.ShowCellErrors = false;
            this.dtItemPedido.ShowCellToolTips = false;
            this.dtItemPedido.ShowEditingIcon = false;
            this.dtItemPedido.ShowRowErrors = false;
            this.dtItemPedido.Size = new System.Drawing.Size(370, 172);
            this.dtItemPedido.TabIndex = 11;
            this.dtItemPedido.DataSourceChanged += new System.EventHandler(this.dtItemPedido_DataSourceChanged);
            this.dtItemPedido.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtItemPedido_CellEnter);
            this.dtItemPedido.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtItemPedido_CellFormatting);
            this.dtItemPedido.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtItemPedido_RowsAdded);
            this.dtItemPedido.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtItemPedido_RowsRemoved);
            // 
            // pcibImagemLogo
            // 
            this.pcibImagemLogo.Image = ((System.Drawing.Image)(resources.GetObject("pcibImagemLogo.Image")));
            this.pcibImagemLogo.Location = new System.Drawing.Point(6, 3);
            this.pcibImagemLogo.Name = "pcibImagemLogo";
            this.pcibImagemLogo.Size = new System.Drawing.Size(150, 40);
            this.pcibImagemLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcibImagemLogo.TabIndex = 18;
            this.pcibImagemLogo.TabStop = false;
            // 
            // dtPedido
            // 
            this.dtPedido.AllowUserToAddRows = false;
            this.dtPedido.AllowUserToDeleteRows = false;
            this.dtPedido.AllowUserToResizeRows = false;
            this.dtPedido.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtPedido.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dtPedido.Enabled = false;
            this.dtPedido.Location = new System.Drawing.Point(6, 65);
            this.dtPedido.MultiSelect = false;
            this.dtPedido.Name = "dtPedido";
            this.dtPedido.ReadOnly = true;
            this.dtPedido.RowHeadersVisible = false;
            this.dtPedido.RowHeadersWidth = 51;
            this.dtPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtPedido.ShowCellErrors = false;
            this.dtPedido.ShowCellToolTips = false;
            this.dtPedido.ShowEditingIcon = false;
            this.dtPedido.ShowRowErrors = false;
            this.dtPedido.Size = new System.Drawing.Size(588, 378);
            this.dtPedido.TabIndex = 10;
            this.dtPedido.DataSourceChanged += new System.EventHandler(this.dtPedido_DataSourceChanged);
            this.dtPedido.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtPedido_CellEnter);
            this.dtPedido.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtPedido_CellFormatting);
            this.dtPedido.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtPedido_RowsAdded);
            this.dtPedido.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtPedido_RowsRemoved);
            // 
            // btnSair
            // 
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(941, 556);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 69;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSair.UseVisualStyleBackColor = true;
            // 
            // ttpIntegracao
            // 
            this.ttpIntegracao.AutoPopDelay = 5000;
            this.ttpIntegracao.InitialDelay = 1000;
            this.ttpIntegracao.IsBalloon = true;
            this.ttpIntegracao.ReshowDelay = 100;
            this.ttpIntegracao.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpIntegracao.ToolTipTitle = "Dica:";
            // 
            // FrmIntegracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1008, 594);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "FrmIntegracoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Integrações";
            this.Load += new System.EventHandler(this.FrmIntegracoes_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmIntegracoes_KeyUp);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFormaPagamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtItemPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagemLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPedido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dtPedido;
        private System.Windows.Forms.PictureBox pcibImagemLogo;
        private System.Windows.Forms.DataGridView dtItemPedido;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtFormaPagamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRegFormaPagamento;
        private System.Windows.Forms.Label lblRegItem;
        private System.Windows.Forms.Label lblRegPedido;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.MaskedTextBox mtxtHorarioEmissao1;
        private System.Windows.Forms.MaskedTextBox mtxtHorarioEmissao;
        private System.Windows.Forms.Label lblDataEntrada;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.MaskedTextBox mtxtpDataEmissao1;
        private System.Windows.Forms.MaskedTextBox mtxtpDataEmissao;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbSituacao;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGerarCupom;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.ComboBox cbbFormaPagamento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.Label lblValorAcrescimo;
        private System.Windows.Forms.Label lblValorDesconto;
        private System.Windows.Forms.Label lblCancelada;
        private System.Windows.Forms.Label lblValorTotalReal;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblTotalReal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblAcrescimo;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnProcurarPagamento;
        private System.Windows.Forms.ToolTip ttpIntegracao;
    }
}