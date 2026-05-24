namespace Seven_Sistema
{
    partial class FrmPagamentoDFe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPagamentoDFe));
            this.grbBox3 = new System.Windows.Forms.GroupBox();
            this.txtValorPagamento = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnNaoPresencial = new System.Windows.Forms.RadioButton();
            this.rbtnInternet = new System.Windows.Forms.RadioButton();
            this.rbtnPresencial = new System.Windows.Forms.RadioButton();
            this.chkbConsumidor = new System.Windows.Forms.CheckBox();
            this.lblValorDiferencaTroco = new System.Windows.Forms.Label();
            this.lblListaFormasPagamento = new System.Windows.Forms.Label();
            this.lblValorTotalPago = new System.Windows.Forms.Label();
            this.lblTotalPago = new System.Windows.Forms.Label();
            this.cbbFormaPagamento = new System.Windows.Forms.ComboBox();
            this.lblAsterisco3 = new System.Windows.Forms.Label();
            this.lblAsterisco2 = new System.Windows.Forms.Label();
            this.lblValorPago = new System.Windows.Forms.Label();
            this.btnExcluirReg = new System.Windows.Forms.Button();
            this.btnSalvarPagamento = new System.Windows.Forms.Button();
            this.dtFormaPagamento = new System.Windows.Forms.DataGridView();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.btnProcurarForma = new System.Windows.Forms.Button();
            this.lblDiferencaTroco = new System.Windows.Forms.Label();
            this.pcibInterrogacao = new System.Windows.Forms.PictureBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.ttpPagamentoDFe = new System.Windows.Forms.ToolTip(this.components);
            this.grbBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFormaPagamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox3
            // 
            this.grbBox3.Controls.Add(this.txtValorPagamento);
            this.grbBox3.Controls.Add(this.groupBox1);
            this.grbBox3.Controls.Add(this.lblValorDiferencaTroco);
            this.grbBox3.Controls.Add(this.lblListaFormasPagamento);
            this.grbBox3.Controls.Add(this.lblValorTotalPago);
            this.grbBox3.Controls.Add(this.lblTotalPago);
            this.grbBox3.Controls.Add(this.cbbFormaPagamento);
            this.grbBox3.Controls.Add(this.lblAsterisco3);
            this.grbBox3.Controls.Add(this.lblAsterisco2);
            this.grbBox3.Controls.Add(this.lblValorPago);
            this.grbBox3.Controls.Add(this.btnExcluirReg);
            this.grbBox3.Controls.Add(this.btnSalvarPagamento);
            this.grbBox3.Controls.Add(this.dtFormaPagamento);
            this.grbBox3.Controls.Add(this.lblFormaPagamento);
            this.grbBox3.Controls.Add(this.btnProcurarForma);
            this.grbBox3.Controls.Add(this.lblDiferencaTroco);
            this.grbBox3.Location = new System.Drawing.Point(12, 12);
            this.grbBox3.Name = "grbBox3";
            this.grbBox3.Size = new System.Drawing.Size(642, 265);
            this.grbBox3.TabIndex = 1;
            this.grbBox3.TabStop = false;
            this.grbBox3.Text = "Pagamento:";
            // 
            // txtValorPagamento
            // 
            this.txtValorPagamento.BackColor = System.Drawing.Color.White;
            this.txtValorPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorPagamento.Location = new System.Drawing.Point(469, 14);
            this.txtValorPagamento.MaxLength = 9;
            this.txtValorPagamento.Name = "txtValorPagamento";
            this.txtValorPagamento.Size = new System.Drawing.Size(92, 20);
            this.txtValorPagamento.TabIndex = 4;
            this.txtValorPagamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorPagamento.DoubleClick += new System.EventHandler(this.txtValorPagamento_DoubleClick);
            this.txtValorPagamento.Enter += new System.EventHandler(this.txtValorPagamento_Enter);
            this.txtValorPagamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorPagamento_KeyPress);
            this.txtValorPagamento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtValorPagamento_KeyUp);
            this.txtValorPagamento.Leave += new System.EventHandler(this.txtValorPagamento_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnNaoPresencial);
            this.groupBox1.Controls.Add(this.rbtnInternet);
            this.groupBox1.Controls.Add(this.rbtnPresencial);
            this.groupBox1.Controls.Add(this.chkbConsumidor);
            this.groupBox1.Location = new System.Drawing.Point(6, 213);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 45);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Outras Informações:";
            // 
            // rbtnNaoPresencial
            // 
            this.rbtnNaoPresencial.AutoSize = true;
            this.rbtnNaoPresencial.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnNaoPresencial.Location = new System.Drawing.Point(477, 19);
            this.rbtnNaoPresencial.Name = "rbtnNaoPresencial";
            this.rbtnNaoPresencial.Size = new System.Drawing.Size(145, 17);
            this.rbtnNaoPresencial.TabIndex = 12;
            this.rbtnNaoPresencial.Text = "Operação não Presencial";
            this.rbtnNaoPresencial.UseVisualStyleBackColor = true;
            this.rbtnNaoPresencial.MouseLeave += new System.EventHandler(this.rbtnNaoPresencial_MouseLeave);
            this.rbtnNaoPresencial.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnNaoPresencial_MouseMove);
            // 
            // rbtnInternet
            // 
            this.rbtnInternet.AutoSize = true;
            this.rbtnInternet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnInternet.Location = new System.Drawing.Point(332, 19);
            this.rbtnInternet.Name = "rbtnInternet";
            this.rbtnInternet.Size = new System.Drawing.Size(134, 17);
            this.rbtnInternet.TabIndex = 11;
            this.rbtnInternet.Text = "Operação pela Internet";
            this.rbtnInternet.UseVisualStyleBackColor = true;
            this.rbtnInternet.MouseLeave += new System.EventHandler(this.rbtnInternet_MouseLeave);
            this.rbtnInternet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnInternet_MouseMove);
            // 
            // rbtnPresencial
            // 
            this.rbtnPresencial.AutoSize = true;
            this.rbtnPresencial.Checked = true;
            this.rbtnPresencial.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnPresencial.Location = new System.Drawing.Point(195, 19);
            this.rbtnPresencial.Name = "rbtnPresencial";
            this.rbtnPresencial.Size = new System.Drawing.Size(124, 17);
            this.rbtnPresencial.TabIndex = 10;
            this.rbtnPresencial.TabStop = true;
            this.rbtnPresencial.Text = "Operação Presencial";
            this.rbtnPresencial.UseVisualStyleBackColor = true;
            this.rbtnPresencial.MouseLeave += new System.EventHandler(this.rbtnPresencial_MouseLeave);
            this.rbtnPresencial.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPresencial_MouseMove);
            // 
            // chkbConsumidor
            // 
            this.chkbConsumidor.AutoSize = true;
            this.chkbConsumidor.Location = new System.Drawing.Point(8, 19);
            this.chkbConsumidor.Name = "chkbConsumidor";
            this.chkbConsumidor.Size = new System.Drawing.Size(170, 17);
            this.chkbConsumidor.TabIndex = 9;
            this.chkbConsumidor.Text = "Venda para Consumidor Final?";
            this.chkbConsumidor.UseVisualStyleBackColor = true;
            this.chkbConsumidor.MouseLeave += new System.EventHandler(this.chkbConsumidor_MouseLeave);
            this.chkbConsumidor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbConsumidor_MouseMove);
            // 
            // lblValorDiferencaTroco
            // 
            this.lblValorDiferencaTroco.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDiferencaTroco.BackColor = System.Drawing.Color.White;
            this.lblValorDiferencaTroco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDiferencaTroco.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDiferencaTroco.ForeColor = System.Drawing.Color.Black;
            this.lblValorDiferencaTroco.Location = new System.Drawing.Point(379, 183);
            this.lblValorDiferencaTroco.Name = "lblValorDiferencaTroco";
            this.lblValorDiferencaTroco.Size = new System.Drawing.Size(97, 26);
            this.lblValorDiferencaTroco.TabIndex = 0;
            this.lblValorDiferencaTroco.Text = "0,00";
            this.lblValorDiferencaTroco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorDiferencaTroco.Click += new System.EventHandler(this.lblValorDiferencaTroco_Click);
            this.lblValorDiferencaTroco.MouseLeave += new System.EventHandler(this.lblValorDiferencaTroco_MouseLeave);
            this.lblValorDiferencaTroco.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorDiferencaTroco_MouseMove);
            // 
            // lblListaFormasPagamento
            // 
            this.lblListaFormasPagamento.AutoSize = true;
            this.lblListaFormasPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaFormasPagamento.Location = new System.Drawing.Point(3, 36);
            this.lblListaFormasPagamento.Name = "lblListaFormasPagamento";
            this.lblListaFormasPagamento.Size = new System.Drawing.Size(80, 13);
            this.lblListaFormasPagamento.TabIndex = 0;
            this.lblListaFormasPagamento.Text = "Pagamentos:";
            // 
            // lblValorTotalPago
            // 
            this.lblValorTotalPago.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorTotalPago.BackColor = System.Drawing.Color.White;
            this.lblValorTotalPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotalPago.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalPago.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotalPago.Location = new System.Drawing.Point(141, 183);
            this.lblValorTotalPago.Name = "lblValorTotalPago";
            this.lblValorTotalPago.Size = new System.Drawing.Size(97, 26);
            this.lblValorTotalPago.TabIndex = 0;
            this.lblValorTotalPago.Text = "0,00";
            this.lblValorTotalPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotalPago.Click += new System.EventHandler(this.lblValorTotalPago_Click);
            this.lblValorTotalPago.MouseLeave += new System.EventHandler(this.lblValorTotalPago_MouseLeave);
            this.lblValorTotalPago.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotalPago_MouseMove);
            // 
            // lblTotalPago
            // 
            this.lblTotalPago.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalPago.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPago.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPago.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPago.Location = new System.Drawing.Point(6, 183);
            this.lblTotalPago.Name = "lblTotalPago";
            this.lblTotalPago.Size = new System.Drawing.Size(132, 26);
            this.lblTotalPago.TabIndex = 0;
            this.lblTotalPago.Text = "Total Pago (R$):";
            this.lblTotalPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbbFormaPagamento
            // 
            this.cbbFormaPagamento.BackColor = System.Drawing.Color.LightBlue;
            this.cbbFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFormaPagamento.DropDownWidth = 350;
            this.cbbFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbFormaPagamento.FormattingEnabled = true;
            this.cbbFormaPagamento.Location = new System.Drawing.Point(127, 13);
            this.cbbFormaPagamento.Name = "cbbFormaPagamento";
            this.cbbFormaPagamento.Size = new System.Drawing.Size(215, 21);
            this.cbbFormaPagamento.TabIndex = 2;
            this.cbbFormaPagamento.DropDown += new System.EventHandler(this.cbbFormaPagamento_DropDown);
            this.cbbFormaPagamento.DropDownClosed += new System.EventHandler(this.cbbFormaPagamento_DropDownClosed);
            this.cbbFormaPagamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbFormaPagamento_KeyPress);
            this.cbbFormaPagamento.MouseLeave += new System.EventHandler(this.cbbFormaPagamento_MouseLeave);
            this.cbbFormaPagamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbFormaPagamento_MouseMove);
            // 
            // lblAsterisco3
            // 
            this.lblAsterisco3.AutoSize = true;
            this.lblAsterisco3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco3.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco3.Location = new System.Drawing.Point(458, 12);
            this.lblAsterisco3.Name = "lblAsterisco3";
            this.lblAsterisco3.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco3.TabIndex = 0;
            this.lblAsterisco3.Text = "*";
            // 
            // lblAsterisco2
            // 
            this.lblAsterisco2.AutoSize = true;
            this.lblAsterisco2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco2.Location = new System.Drawing.Point(115, 12);
            this.lblAsterisco2.Name = "lblAsterisco2";
            this.lblAsterisco2.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco2.TabIndex = 0;
            this.lblAsterisco2.Text = "*";
            // 
            // lblValorPago
            // 
            this.lblValorPago.AutoSize = true;
            this.lblValorPago.Location = new System.Drawing.Point(378, 17);
            this.lblValorPago.Name = "lblValorPago";
            this.lblValorPago.Size = new System.Drawing.Size(85, 13);
            this.lblValorPago.TabIndex = 0;
            this.lblValorPago.Text = "Valor Pago (R$):";
            // 
            // btnExcluirReg
            // 
            this.btnExcluirReg.Enabled = false;
            this.btnExcluirReg.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirReg.Image")));
            this.btnExcluirReg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluirReg.Location = new System.Drawing.Point(527, 186);
            this.btnExcluirReg.Name = "btnExcluirReg";
            this.btnExcluirReg.Size = new System.Drawing.Size(107, 25);
            this.btnExcluirReg.TabIndex = 7;
            this.btnExcluirReg.Text = "&Excluir Registro";
            this.btnExcluirReg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPagamentoDFe.SetToolTip(this.btnExcluirReg, "Excluir uma Forma de Pagamento informada.");
            this.btnExcluirReg.UseVisualStyleBackColor = true;
            this.btnExcluirReg.Click += new System.EventHandler(this.btnExcluirReg_Click);
            this.btnExcluirReg.MouseLeave += new System.EventHandler(this.btnExcluirReg_MouseLeave);
            this.btnExcluirReg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluirReg_MouseMove);
            // 
            // btnSalvarPagamento
            // 
            this.btnSalvarPagamento.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvarPagamento.Image")));
            this.btnSalvarPagamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvarPagamento.Location = new System.Drawing.Point(569, 10);
            this.btnSalvarPagamento.Name = "btnSalvarPagamento";
            this.btnSalvarPagamento.Size = new System.Drawing.Size(65, 25);
            this.btnSalvarPagamento.TabIndex = 5;
            this.btnSalvarPagamento.Text = "&Incluir";
            this.btnSalvarPagamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPagamentoDFe.SetToolTip(this.btnSalvarPagamento, "Incluir o dado da Forma de Pagamento informada.");
            this.btnSalvarPagamento.UseVisualStyleBackColor = true;
            this.btnSalvarPagamento.Click += new System.EventHandler(this.btnSalvarPagamento_Click);
            this.btnSalvarPagamento.MouseLeave += new System.EventHandler(this.btnSalvarPagamento_MouseLeave);
            this.btnSalvarPagamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvarPagamento_MouseMove);
            // 
            // dtFormaPagamento
            // 
            this.dtFormaPagamento.AllowUserToAddRows = false;
            this.dtFormaPagamento.AllowUserToDeleteRows = false;
            this.dtFormaPagamento.AllowUserToResizeRows = false;
            this.dtFormaPagamento.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtFormaPagamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtFormaPagamento.Location = new System.Drawing.Point(6, 52);
            this.dtFormaPagamento.MultiSelect = false;
            this.dtFormaPagamento.Name = "dtFormaPagamento";
            this.dtFormaPagamento.ReadOnly = true;
            this.dtFormaPagamento.RowHeadersVisible = false;
            this.dtFormaPagamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtFormaPagamento.ShowCellErrors = false;
            this.dtFormaPagamento.ShowCellToolTips = false;
            this.dtFormaPagamento.ShowEditingIcon = false;
            this.dtFormaPagamento.ShowRowErrors = false;
            this.dtFormaPagamento.Size = new System.Drawing.Size(628, 128);
            this.dtFormaPagamento.TabIndex = 6;
            this.dtFormaPagamento.DataSourceChanged += new System.EventHandler(this.dtFormaPagamento_DataSourceChanged);
            this.dtFormaPagamento.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtFormaPagamento_CellEnter);
            this.dtFormaPagamento.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtFormaPagamento_RowsAdded);
            this.dtFormaPagamento.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtFormaPagamento_RowsRemoved);
            this.dtFormaPagamento.MouseLeave += new System.EventHandler(this.dtFormaPagamento_MouseLeave);
            this.dtFormaPagamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtFormaPagamento_MouseMove);
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Location = new System.Drawing.Point(9, 16);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(111, 13);
            this.lblFormaPagamento.TabIndex = 0;
            this.lblFormaPagamento.Text = "Forma de Pagamento:";
            // 
            // btnProcurarForma
            // 
            this.btnProcurarForma.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarForma.Image")));
            this.btnProcurarForma.Location = new System.Drawing.Point(348, 11);
            this.btnProcurarForma.Name = "btnProcurarForma";
            this.btnProcurarForma.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarForma.TabIndex = 3;
            this.btnProcurarForma.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPagamentoDFe.SetToolTip(this.btnProcurarForma, "Clique para pesquisar uma Forma de Pagamento.");
            this.btnProcurarForma.UseVisualStyleBackColor = true;
            this.btnProcurarForma.Click += new System.EventHandler(this.btnProcurarForma_Click);
            this.btnProcurarForma.MouseLeave += new System.EventHandler(this.btnProcurarForma_MouseLeave);
            this.btnProcurarForma.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarForma_MouseMove);
            // 
            // lblDiferencaTroco
            // 
            this.lblDiferencaTroco.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDiferencaTroco.BackColor = System.Drawing.Color.Transparent;
            this.lblDiferencaTroco.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferencaTroco.ForeColor = System.Drawing.Color.Red;
            this.lblDiferencaTroco.Location = new System.Drawing.Point(246, 183);
            this.lblDiferencaTroco.Name = "lblDiferencaTroco";
            this.lblDiferencaTroco.Size = new System.Drawing.Size(129, 26);
            this.lblDiferencaTroco.TabIndex = 0;
            this.lblDiferencaTroco.Text = "Diferença (R$):";
            this.lblDiferencaTroco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pcibInterrogacao
            // 
            this.pcibInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao.Image")));
            this.pcibInterrogacao.Location = new System.Drawing.Point(12, 283);
            this.pcibInterrogacao.Name = "pcibInterrogacao";
            this.pcibInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao.TabIndex = 119;
            this.pcibInterrogacao.TabStop = false;
            this.pcibInterrogacao.Click += new System.EventHandler(this.pcibInterrogacao_Click);
            this.pcibInterrogacao.MouseLeave += new System.EventHandler(this.pcibInterrogacao_MouseLeave);
            this.pcibInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(599, 283);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(55, 32);
            this.btnSalvar.TabIndex = 13;
            this.btnSalvar.Text = "&Sair";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPagamentoDFe.SetToolTip(this.btnSalvar, "Sair de Pagamento DFe.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // ttpPagamentoDFe
            // 
            this.ttpPagamentoDFe.AutoPopDelay = 5000;
            this.ttpPagamentoDFe.InitialDelay = 1000;
            this.ttpPagamentoDFe.IsBalloon = true;
            this.ttpPagamentoDFe.ReshowDelay = 100;
            this.ttpPagamentoDFe.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpPagamentoDFe.ToolTipTitle = "Dica:";
            // 
            // FrmPagamentoDFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(669, 321);
            this.ControlBox = false;
            this.Controls.Add(this.grbBox3);
            this.Controls.Add(this.pcibInterrogacao);
            this.Controls.Add(this.btnSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPagamentoDFe";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagamento de DFe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPagamentoDFe_FormClosing);
            this.Load += new System.EventHandler(this.FrmPagDFe_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPagamentoDFe_KeyUp);
            this.grbBox3.ResumeLayout(false);
            this.grbBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFormaPagamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox3;
        private System.Windows.Forms.Label lblValorDiferencaTroco;
        private System.Windows.Forms.Label lblListaFormasPagamento;
        private System.Windows.Forms.Label lblValorTotalPago;
        private System.Windows.Forms.Label lblTotalPago;
        private System.Windows.Forms.ComboBox cbbFormaPagamento;
        private System.Windows.Forms.Label lblAsterisco3;
        private System.Windows.Forms.Label lblAsterisco2;
        private System.Windows.Forms.Label lblValorPago;
        private System.Windows.Forms.Button btnExcluirReg;
        private System.Windows.Forms.Button btnSalvarPagamento;
        private System.Windows.Forms.TextBox txtValorPagamento;
        private System.Windows.Forms.DataGridView dtFormaPagamento;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.Button btnProcurarForma;
        private System.Windows.Forms.Label lblDiferencaTroco;
        private System.Windows.Forms.PictureBox pcibInterrogacao;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.CheckBox chkbConsumidor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnNaoPresencial;
        private System.Windows.Forms.RadioButton rbtnInternet;
        private System.Windows.Forms.RadioButton rbtnPresencial;
        private System.Windows.Forms.ToolTip ttpPagamentoDFe;
    }
}