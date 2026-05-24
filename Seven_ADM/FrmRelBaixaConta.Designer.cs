namespace Seven_Sistema
{
    partial class FrmRelBaixaConta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelBaixaConta));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblNDocumento = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValorParcela = new System.Windows.Forms.Label();
            this.lbldocumento = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblValorCodigo = new System.Windows.Forms.Label();
            this.lblDataDesconto = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.chkbIgnorarMulta = new System.Windows.Forms.CheckBox();
            this.chkbIgnorarJurosAM = new System.Windows.Forms.CheckBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.lblValorParcialPago = new System.Windows.Forms.Label();
            this.lblParcialPago = new System.Windows.Forms.Label();
            this.mtxtDataPagamento = new System.Windows.Forms.MaskedTextBox();
            this.lblValorRealDocumento = new System.Windows.Forms.Label();
            this.grbBox3 = new System.Windows.Forms.GroupBox();
            this.lblValorDiferencaTroco = new System.Windows.Forms.Label();
            this.lblListaFormasPagamento = new System.Windows.Forms.Label();
            this.lblValorTotalPago = new System.Windows.Forms.Label();
            this.lblTotalPago = new System.Windows.Forms.Label();
            this.cbbFormaPagamento = new System.Windows.Forms.ComboBox();
            this.lblAsterisco2 = new System.Windows.Forms.Label();
            this.btnExcluirReg = new System.Windows.Forms.Button();
            this.btnSalvarPagamento = new System.Windows.Forms.Button();
            this.txtValorPagamento = new System.Windows.Forms.TextBox();
            this.dtFormaPagamento = new System.Windows.Forms.DataGridView();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.btnProcurarForma = new System.Windows.Forms.Button();
            this.lblDiferencaTroco = new System.Windows.Forms.Label();
            this.lblAsterisco3 = new System.Windows.Forms.Label();
            this.lblValorPago = new System.Windows.Forms.Label();
            this.lblAntesVencimento = new System.Windows.Forms.Label();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.lblAposVencimento = new System.Windows.Forms.Label();
            this.lblJurosAMPorcValor = new System.Windows.Forms.Label();
            this.lblJurosAm = new System.Windows.Forms.Label();
            this.lblValorJurosAm = new System.Windows.Forms.Label();
            this.lblMultaPorcValor = new System.Windows.Forms.Label();
            this.lblDiasDeAtraso = new System.Windows.Forms.Label();
            this.lblValorDesconto = new System.Windows.Forms.Label();
            this.lblDescontoPorcValor = new System.Windows.Forms.Label();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.lblValorMulta = new System.Windows.Forms.Label();
            this.lblMulta = new System.Windows.Forms.Label();
            this.lblValorReal = new System.Windows.Forms.Label();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.lblDataPagamento = new System.Windows.Forms.Label();
            this.lblValorDocumento = new System.Windows.Forms.Label();
            this.lblValorDataDesconto = new System.Windows.Forms.Label();
            this.lblDataEmissao = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblDataVencimento = new System.Windows.Forms.Label();
            this.lblValorDataEmissao = new System.Windows.Forms.Label();
            this.lblValorDataVencimento = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.pcibInterrogacao = new System.Windows.Forms.PictureBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.ttpBaixaContaPagar = new System.Windows.Forms.ToolTip(this.components);
            this.grbBox1.SuspendLayout();
            this.grbBox2.SuspendLayout();
            this.grbBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFormaPagamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblNDocumento);
            this.grbBox1.Controls.Add(this.label2);
            this.grbBox1.Controls.Add(this.lblValorParcela);
            this.grbBox1.Controls.Add(this.lbldocumento);
            this.grbBox1.Controls.Add(this.lblCodigo);
            this.grbBox1.Controls.Add(this.lblValorCodigo);
            this.grbBox1.Controls.Add(this.lblDataDesconto);
            this.grbBox1.Controls.Add(this.grbBox2);
            this.grbBox1.Controls.Add(this.lblValorDocumento);
            this.grbBox1.Controls.Add(this.lblValorDataDesconto);
            this.grbBox1.Controls.Add(this.lblDataEmissao);
            this.grbBox1.Controls.Add(this.lblValor);
            this.grbBox1.Controls.Add(this.lblDataVencimento);
            this.grbBox1.Controls.Add(this.lblValorDataEmissao);
            this.grbBox1.Controls.Add(this.lblValorDataVencimento);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(677, 434);
            this.grbBox1.TabIndex = 0;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Informações da Conta a Pagar:";
            this.grbBox1.Enter += new System.EventHandler(this.grbBox1_Enter);
            // 
            // lblNDocumento
            // 
            this.lblNDocumento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNDocumento.BackColor = System.Drawing.Color.White;
            this.lblNDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNDocumento.Location = new System.Drawing.Point(131, 18);
            this.lblNDocumento.Name = "lblNDocumento";
            this.lblNDocumento.Size = new System.Drawing.Size(91, 22);
            this.lblNDocumento.TabIndex = 0;
            this.lblNDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNDocumento.Click += new System.EventHandler(this.lblNDocumento_Click);
            this.lblNDocumento.MouseLeave += new System.EventHandler(this.lblNDocumento_MouseLeave);
            this.lblNDocumento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblNDocumento_MouseMove);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(221, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "/";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorParcela
            // 
            this.lblValorParcela.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorParcela.BackColor = System.Drawing.Color.White;
            this.lblValorParcela.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorParcela.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorParcela.Location = new System.Drawing.Point(232, 18);
            this.lblValorParcela.Name = "lblValorParcela";
            this.lblValorParcela.Size = new System.Drawing.Size(41, 22);
            this.lblValorParcela.TabIndex = 0;
            this.lblValorParcela.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorParcela.Click += new System.EventHandler(this.lblValorParcela_Click);
            this.lblValorParcela.MouseLeave += new System.EventHandler(this.lblValorParcela_MouseLeave);
            this.lblValorParcela.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorParcela_MouseMove);
            // 
            // lbldocumento
            // 
            this.lbldocumento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbldocumento.BackColor = System.Drawing.Color.Transparent;
            this.lbldocumento.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldocumento.ForeColor = System.Drawing.Color.Black;
            this.lbldocumento.Location = new System.Drawing.Point(6, 16);
            this.lbldocumento.Name = "lbldocumento";
            this.lbldocumento.Size = new System.Drawing.Size(110, 26);
            this.lbldocumento.TabIndex = 0;
            this.lbldocumento.Text = "Nº do Documento:";
            this.lbldocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCodigo
            // 
            this.lblCodigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCodigo.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.Black;
            this.lblCodigo.Location = new System.Drawing.Point(298, 14);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(48, 26);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorCodigo
            // 
            this.lblValorCodigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorCodigo.BackColor = System.Drawing.Color.White;
            this.lblValorCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorCodigo.Location = new System.Drawing.Point(352, 18);
            this.lblValorCodigo.Name = "lblValorCodigo";
            this.lblValorCodigo.Size = new System.Drawing.Size(81, 22);
            this.lblValorCodigo.TabIndex = 0;
            this.lblValorCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorCodigo.Click += new System.EventHandler(this.lblValorCodigo_Click);
            this.lblValorCodigo.MouseLeave += new System.EventHandler(this.lblValorCodigo_MouseLeave);
            this.lblValorCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorCodigo_MouseMove);
            // 
            // lblDataDesconto
            // 
            this.lblDataDesconto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDataDesconto.BackColor = System.Drawing.Color.Transparent;
            this.lblDataDesconto.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataDesconto.ForeColor = System.Drawing.Color.Black;
            this.lblDataDesconto.Location = new System.Drawing.Point(463, 43);
            this.lblDataDesconto.Name = "lblDataDesconto";
            this.lblDataDesconto.Size = new System.Drawing.Size(86, 26);
            this.lblDataDesconto.TabIndex = 0;
            this.lblDataDesconto.Text = "Desconto Até:";
            this.lblDataDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.chkbIgnorarMulta);
            this.grbBox2.Controls.Add(this.chkbIgnorarJurosAM);
            this.grbBox2.Controls.Add(this.btnAplicar);
            this.grbBox2.Controls.Add(this.lblValorParcialPago);
            this.grbBox2.Controls.Add(this.lblParcialPago);
            this.grbBox2.Controls.Add(this.mtxtDataPagamento);
            this.grbBox2.Controls.Add(this.lblValorRealDocumento);
            this.grbBox2.Controls.Add(this.grbBox3);
            this.grbBox2.Controls.Add(this.lblAntesVencimento);
            this.grbBox2.Controls.Add(this.btnSelecionarData);
            this.grbBox2.Controls.Add(this.lblAposVencimento);
            this.grbBox2.Controls.Add(this.lblJurosAMPorcValor);
            this.grbBox2.Controls.Add(this.lblJurosAm);
            this.grbBox2.Controls.Add(this.lblValorJurosAm);
            this.grbBox2.Controls.Add(this.lblMultaPorcValor);
            this.grbBox2.Controls.Add(this.lblDiasDeAtraso);
            this.grbBox2.Controls.Add(this.lblValorDesconto);
            this.grbBox2.Controls.Add(this.lblDescontoPorcValor);
            this.grbBox2.Controls.Add(this.lblDesconto);
            this.grbBox2.Controls.Add(this.lblValorMulta);
            this.grbBox2.Controls.Add(this.lblMulta);
            this.grbBox2.Controls.Add(this.lblValorReal);
            this.grbBox2.Controls.Add(this.lblAsterisco1);
            this.grbBox2.Controls.Add(this.lblDataPagamento);
            this.grbBox2.Location = new System.Drawing.Point(9, 71);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(659, 357);
            this.grbBox2.TabIndex = 1;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Informações de Pagamento:";
            // 
            // chkbIgnorarMulta
            // 
            this.chkbIgnorarMulta.AutoSize = true;
            this.chkbIgnorarMulta.Enabled = false;
            this.chkbIgnorarMulta.Location = new System.Drawing.Point(544, 13);
            this.chkbIgnorarMulta.Name = "chkbIgnorarMulta";
            this.chkbIgnorarMulta.Size = new System.Drawing.Size(88, 17);
            this.chkbIgnorarMulta.TabIndex = 8;
            this.chkbIgnorarMulta.Text = "Ignorar Multa";
            this.chkbIgnorarMulta.Visible = false;
            this.chkbIgnorarMulta.CheckedChanged += new System.EventHandler(this.chkbIgnorarMulta_CheckedChanged);
            this.chkbIgnorarMulta.MouseLeave += new System.EventHandler(this.chkbIgnorarMulta_MouseLeave);
            this.chkbIgnorarMulta.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbIgnorarMulta_MouseMove);
            // 
            // chkbIgnorarJurosAM
            // 
            this.chkbIgnorarJurosAM.AutoSize = true;
            this.chkbIgnorarJurosAM.Enabled = false;
            this.chkbIgnorarJurosAM.Location = new System.Drawing.Point(544, 36);
            this.chkbIgnorarJurosAM.Name = "chkbIgnorarJurosAM";
            this.chkbIgnorarJurosAM.Size = new System.Drawing.Size(113, 17);
            this.chkbIgnorarJurosAM.TabIndex = 7;
            this.chkbIgnorarJurosAM.Text = "Ignorar Juros (a.m)";
            this.chkbIgnorarJurosAM.UseVisualStyleBackColor = true;
            this.chkbIgnorarJurosAM.Visible = false;
            this.chkbIgnorarJurosAM.CheckedChanged += new System.EventHandler(this.chkbIgnorarJurosAM_CheckedChanged);
            this.chkbIgnorarJurosAM.MouseLeave += new System.EventHandler(this.chkbIgnorarJurosAM_MouseLeave);
            this.chkbIgnorarJurosAM.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbIgnorarJurosAM_MouseMove);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Image = ((System.Drawing.Image)(resources.GetObject("btnAplicar.Image")));
            this.btnAplicar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAplicar.Location = new System.Drawing.Point(232, 10);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(26, 25);
            this.btnAplicar.TabIndex = 4;
            this.btnAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixaContaPagar.SetToolTip(this.btnAplicar, "Clique para selecionar as datas.");
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.MouseLeave += new System.EventHandler(this.btnAplicar_MouseLeave);
            this.btnAplicar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAplicar_MouseMove);
            // 
            // lblValorParcialPago
            // 
            this.lblValorParcialPago.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorParcialPago.BackColor = System.Drawing.Color.White;
            this.lblValorParcialPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorParcialPago.Enabled = false;
            this.lblValorParcialPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorParcialPago.ForeColor = System.Drawing.Color.Red;
            this.lblValorParcialPago.Location = new System.Drawing.Point(548, 91);
            this.lblValorParcialPago.Name = "lblValorParcialPago";
            this.lblValorParcialPago.Size = new System.Drawing.Size(105, 22);
            this.lblValorParcialPago.TabIndex = 0;
            this.lblValorParcialPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorParcialPago.Click += new System.EventHandler(this.lblValorParcialPago_Click);
            this.lblValorParcialPago.MouseLeave += new System.EventHandler(this.lblValorParcialPago_MouseLeave);
            this.lblValorParcialPago.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorParcialPago_MouseMove);
            // 
            // lblParcialPago
            // 
            this.lblParcialPago.AutoSize = true;
            this.lblParcialPago.Enabled = false;
            this.lblParcialPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParcialPago.ForeColor = System.Drawing.Color.Black;
            this.lblParcialPago.Location = new System.Drawing.Point(406, 95);
            this.lblParcialPago.Name = "lblParcialPago";
            this.lblParcialPago.Size = new System.Drawing.Size(144, 13);
            this.lblParcialPago.TabIndex = 0;
            this.lblParcialPago.Text = "Valor Parcial Pago (R$):";
            // 
            // mtxtDataPagamento
            // 
            this.mtxtDataPagamento.BackColor = System.Drawing.Color.White;
            this.mtxtDataPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtDataPagamento.Location = new System.Drawing.Point(116, 13);
            this.mtxtDataPagamento.Mask = "00/00/0000";
            this.mtxtDataPagamento.Name = "mtxtDataPagamento";
            this.mtxtDataPagamento.Size = new System.Drawing.Size(78, 20);
            this.mtxtDataPagamento.TabIndex = 2;
            this.mtxtDataPagamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtDataPagamento.ValidatingType = typeof(System.DateTime);
            this.mtxtDataPagamento.DoubleClick += new System.EventHandler(this.mtxtDataPagamento_DoubleClick);
            this.mtxtDataPagamento.Enter += new System.EventHandler(this.mtxtDataPagamento_Enter);
            this.mtxtDataPagamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtDataPagamento_KeyPress);
            this.mtxtDataPagamento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtDataPagamento_KeyUp);
            this.mtxtDataPagamento.Leave += new System.EventHandler(this.mtxtDataPagamento_Leave);
            // 
            // lblValorRealDocumento
            // 
            this.lblValorRealDocumento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorRealDocumento.BackColor = System.Drawing.Color.White;
            this.lblValorRealDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorRealDocumento.Enabled = false;
            this.lblValorRealDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorRealDocumento.ForeColor = System.Drawing.Color.Red;
            this.lblValorRealDocumento.Location = new System.Drawing.Point(548, 113);
            this.lblValorRealDocumento.Name = "lblValorRealDocumento";
            this.lblValorRealDocumento.Size = new System.Drawing.Size(105, 22);
            this.lblValorRealDocumento.TabIndex = 0;
            this.lblValorRealDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorRealDocumento.Click += new System.EventHandler(this.lblValorRealDocumento_Click);
            this.lblValorRealDocumento.MouseLeave += new System.EventHandler(this.lblValorRealDocumento_MouseLeave);
            this.lblValorRealDocumento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorRealDocumento_MouseMove);
            // 
            // grbBox3
            // 
            this.grbBox3.Controls.Add(this.lblValorDiferencaTroco);
            this.grbBox3.Controls.Add(this.lblListaFormasPagamento);
            this.grbBox3.Controls.Add(this.lblValorTotalPago);
            this.grbBox3.Controls.Add(this.lblTotalPago);
            this.grbBox3.Controls.Add(this.cbbFormaPagamento);
            this.grbBox3.Controls.Add(this.lblAsterisco2);
            this.grbBox3.Controls.Add(this.btnExcluirReg);
            this.grbBox3.Controls.Add(this.btnSalvarPagamento);
            this.grbBox3.Controls.Add(this.txtValorPagamento);
            this.grbBox3.Controls.Add(this.dtFormaPagamento);
            this.grbBox3.Controls.Add(this.lblFormaPagamento);
            this.grbBox3.Controls.Add(this.btnProcurarForma);
            this.grbBox3.Controls.Add(this.lblDiferencaTroco);
            this.grbBox3.Controls.Add(this.lblAsterisco3);
            this.grbBox3.Controls.Add(this.lblValorPago);
            this.grbBox3.Location = new System.Drawing.Point(9, 138);
            this.grbBox3.Name = "grbBox3";
            this.grbBox3.Size = new System.Drawing.Size(642, 213);
            this.grbBox3.TabIndex = 6;
            this.grbBox3.TabStop = false;
            this.grbBox3.Text = "Pagamento:";
            // 
            // lblValorDiferencaTroco
            // 
            this.lblValorDiferencaTroco.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDiferencaTroco.BackColor = System.Drawing.Color.White;
            this.lblValorDiferencaTroco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDiferencaTroco.Enabled = false;
            this.lblValorDiferencaTroco.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDiferencaTroco.ForeColor = System.Drawing.Color.Black;
            this.lblValorDiferencaTroco.Location = new System.Drawing.Point(378, 183);
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
            this.lblListaFormasPagamento.Enabled = false;
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
            this.lblValorTotalPago.Enabled = false;
            this.lblValorTotalPago.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalPago.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotalPago.Location = new System.Drawing.Point(140, 183);
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
            this.lblTotalPago.Enabled = false;
            this.lblTotalPago.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPago.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPago.Location = new System.Drawing.Point(2, 183);
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
            this.cbbFormaPagamento.Enabled = false;
            this.cbbFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbFormaPagamento.FormattingEnabled = true;
            this.cbbFormaPagamento.Location = new System.Drawing.Point(127, 13);
            this.cbbFormaPagamento.Name = "cbbFormaPagamento";
            this.cbbFormaPagamento.Size = new System.Drawing.Size(215, 21);
            this.cbbFormaPagamento.TabIndex = 7;
            this.cbbFormaPagamento.DropDown += new System.EventHandler(this.cbbFormaPagamento_DropDown);
            this.cbbFormaPagamento.DropDownClosed += new System.EventHandler(this.cbbFormaPagamento_DropDownClosed);
            this.cbbFormaPagamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbFormaPagamento_KeyPress);
            this.cbbFormaPagamento.Leave += new System.EventHandler(this.cbbFormaPagamento_Leave);
            this.cbbFormaPagamento.MouseLeave += new System.EventHandler(this.cbbFormaPagamento_MouseLeave);
            this.cbbFormaPagamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbFormaPagamento_MouseMove);
            // 
            // lblAsterisco2
            // 
            this.lblAsterisco2.AutoSize = true;
            this.lblAsterisco2.Enabled = false;
            this.lblAsterisco2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco2.Location = new System.Drawing.Point(117, 13);
            this.lblAsterisco2.Name = "lblAsterisco2";
            this.lblAsterisco2.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco2.TabIndex = 0;
            this.lblAsterisco2.Text = "*";
            // 
            // btnExcluirReg
            // 
            this.btnExcluirReg.Enabled = false;
            this.btnExcluirReg.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirReg.Image")));
            this.btnExcluirReg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluirReg.Location = new System.Drawing.Point(527, 186);
            this.btnExcluirReg.Name = "btnExcluirReg";
            this.btnExcluirReg.Size = new System.Drawing.Size(107, 25);
            this.btnExcluirReg.TabIndex = 12;
            this.btnExcluirReg.Text = "&Excluir Registro";
            this.btnExcluirReg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixaContaPagar.SetToolTip(this.btnExcluirReg, "Excluir uma Forma de Pagamento informada.");
            this.btnExcluirReg.UseVisualStyleBackColor = true;
            this.btnExcluirReg.Click += new System.EventHandler(this.btnExcluirReg_Click);
            this.btnExcluirReg.MouseLeave += new System.EventHandler(this.btnExcluirReg_MouseLeave);
            this.btnExcluirReg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluirReg_MouseMove);
            // 
            // btnSalvarPagamento
            // 
            this.btnSalvarPagamento.Enabled = false;
            this.btnSalvarPagamento.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvarPagamento.Image")));
            this.btnSalvarPagamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvarPagamento.Location = new System.Drawing.Point(569, 10);
            this.btnSalvarPagamento.Name = "btnSalvarPagamento";
            this.btnSalvarPagamento.Size = new System.Drawing.Size(65, 25);
            this.btnSalvarPagamento.TabIndex = 10;
            this.btnSalvarPagamento.Text = "&Incluir";
            this.btnSalvarPagamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixaContaPagar.SetToolTip(this.btnSalvarPagamento, "Incluir o dado da Forma de Pagamento informada.");
            this.btnSalvarPagamento.UseVisualStyleBackColor = true;
            this.btnSalvarPagamento.Click += new System.EventHandler(this.btnSalvarPagamento_Click);
            this.btnSalvarPagamento.MouseLeave += new System.EventHandler(this.btnSalvarPagamento_MouseLeave);
            this.btnSalvarPagamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvarPagamento_MouseMove);
            // 
            // txtValorPagamento
            // 
            this.txtValorPagamento.BackColor = System.Drawing.Color.White;
            this.txtValorPagamento.Enabled = false;
            this.txtValorPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorPagamento.Location = new System.Drawing.Point(471, 13);
            this.txtValorPagamento.MaxLength = 9;
            this.txtValorPagamento.Name = "txtValorPagamento";
            this.txtValorPagamento.Size = new System.Drawing.Size(92, 20);
            this.txtValorPagamento.TabIndex = 9;
            this.txtValorPagamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorPagamento.DoubleClick += new System.EventHandler(this.txtValorPagamento_DoubleClick);
            this.txtValorPagamento.Enter += new System.EventHandler(this.txtValorPagamento_Enter);
            this.txtValorPagamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorPagamento_KeyPress);
            this.txtValorPagamento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtValorPagamento_KeyUp);
            this.txtValorPagamento.Leave += new System.EventHandler(this.txtValorPagamento_Leave);
            // 
            // dtFormaPagamento
            // 
            this.dtFormaPagamento.AllowUserToAddRows = false;
            this.dtFormaPagamento.AllowUserToDeleteRows = false;
            this.dtFormaPagamento.AllowUserToResizeRows = false;
            this.dtFormaPagamento.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtFormaPagamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtFormaPagamento.Enabled = false;
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
            this.dtFormaPagamento.TabIndex = 11;
            this.dtFormaPagamento.DataSourceChanged += new System.EventHandler(this.dtFormaPagamento_DataSourceChanged);
            this.dtFormaPagamento.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtFormaPagamento_CellEnter);
            this.dtFormaPagamento.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtFormaPagamento_CellFormatting);
            this.dtFormaPagamento.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtFormaPagamento_RowsAdded);
            this.dtFormaPagamento.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtFormaPagamento_RowsRemoved);
            this.dtFormaPagamento.MouseLeave += new System.EventHandler(this.dtFormaPagamento_MouseLeave);
            this.dtFormaPagamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtFormaPagamento_MouseMove);
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Enabled = false;
            this.lblFormaPagamento.Location = new System.Drawing.Point(11, 16);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(111, 13);
            this.lblFormaPagamento.TabIndex = 0;
            this.lblFormaPagamento.Text = "Forma de Pagamento:";
            // 
            // btnProcurarForma
            // 
            this.btnProcurarForma.Enabled = false;
            this.btnProcurarForma.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarForma.Image")));
            this.btnProcurarForma.Location = new System.Drawing.Point(348, 11);
            this.btnProcurarForma.Name = "btnProcurarForma";
            this.btnProcurarForma.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarForma.TabIndex = 8;
            this.btnProcurarForma.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixaContaPagar.SetToolTip(this.btnProcurarForma, "Clique para pesquisar uma Forma de Pagamento.");
            this.btnProcurarForma.UseVisualStyleBackColor = true;
            this.btnProcurarForma.Click += new System.EventHandler(this.btnProcurarForma_Click);
            this.btnProcurarForma.MouseLeave += new System.EventHandler(this.btnProcurarForma_MouseLeave);
            this.btnProcurarForma.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarForma_MouseMove);
            // 
            // lblDiferencaTroco
            // 
            this.lblDiferencaTroco.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDiferencaTroco.BackColor = System.Drawing.Color.Transparent;
            this.lblDiferencaTroco.Enabled = false;
            this.lblDiferencaTroco.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferencaTroco.ForeColor = System.Drawing.Color.Red;
            this.lblDiferencaTroco.Location = new System.Drawing.Point(245, 183);
            this.lblDiferencaTroco.Name = "lblDiferencaTroco";
            this.lblDiferencaTroco.Size = new System.Drawing.Size(129, 26);
            this.lblDiferencaTroco.TabIndex = 0;
            this.lblDiferencaTroco.Text = "Diferença (R$):";
            this.lblDiferencaTroco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAsterisco3
            // 
            this.lblAsterisco3.AutoSize = true;
            this.lblAsterisco3.Enabled = false;
            this.lblAsterisco3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco3.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco3.Location = new System.Drawing.Point(460, 13);
            this.lblAsterisco3.Name = "lblAsterisco3";
            this.lblAsterisco3.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco3.TabIndex = 0;
            this.lblAsterisco3.Text = "*";
            // 
            // lblValorPago
            // 
            this.lblValorPago.AutoSize = true;
            this.lblValorPago.Enabled = false;
            this.lblValorPago.Location = new System.Drawing.Point(380, 16);
            this.lblValorPago.Name = "lblValorPago";
            this.lblValorPago.Size = new System.Drawing.Size(85, 13);
            this.lblValorPago.TabIndex = 0;
            this.lblValorPago.Text = "Valor Pago (R$):";
            // 
            // lblAntesVencimento
            // 
            this.lblAntesVencimento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAntesVencimento.AutoSize = true;
            this.lblAntesVencimento.BackColor = System.Drawing.Color.Transparent;
            this.lblAntesVencimento.Enabled = false;
            this.lblAntesVencimento.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAntesVencimento.ForeColor = System.Drawing.Color.Black;
            this.lblAntesVencimento.Location = new System.Drawing.Point(113, 36);
            this.lblAntesVencimento.Name = "lblAntesVencimento";
            this.lblAntesVencimento.Size = new System.Drawing.Size(128, 15);
            this.lblAntesVencimento.TabIndex = 0;
            this.lblAntesVencimento.Text = "Antes do vencimento:";
            this.lblAntesVencimento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(200, 10);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 3;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixaContaPagar.SetToolTip(this.btnSelecionarData, "Clique para selecionar uma data.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // lblAposVencimento
            // 
            this.lblAposVencimento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAposVencimento.AutoSize = true;
            this.lblAposVencimento.BackColor = System.Drawing.Color.Transparent;
            this.lblAposVencimento.Enabled = false;
            this.lblAposVencimento.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAposVencimento.ForeColor = System.Drawing.Color.Black;
            this.lblAposVencimento.Location = new System.Drawing.Point(113, 73);
            this.lblAposVencimento.Name = "lblAposVencimento";
            this.lblAposVencimento.Size = new System.Drawing.Size(106, 15);
            this.lblAposVencimento.TabIndex = 0;
            this.lblAposVencimento.Text = "Após vencimento:";
            this.lblAposVencimento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblJurosAMPorcValor
            // 
            this.lblJurosAMPorcValor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblJurosAMPorcValor.BackColor = System.Drawing.Color.Transparent;
            this.lblJurosAMPorcValor.Enabled = false;
            this.lblJurosAMPorcValor.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJurosAMPorcValor.ForeColor = System.Drawing.Color.Black;
            this.lblJurosAMPorcValor.Location = new System.Drawing.Point(227, 112);
            this.lblJurosAMPorcValor.Name = "lblJurosAMPorcValor";
            this.lblJurosAMPorcValor.Size = new System.Drawing.Size(139, 26);
            this.lblJurosAMPorcValor.TabIndex = 0;
            this.lblJurosAMPorcValor.Text = "Juros (a.m) de: 0,00%.";
            this.lblJurosAMPorcValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblJurosAm
            // 
            this.lblJurosAm.AutoSize = true;
            this.lblJurosAm.Enabled = false;
            this.lblJurosAm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJurosAm.ForeColor = System.Drawing.Color.Black;
            this.lblJurosAm.Location = new System.Drawing.Point(4, 119);
            this.lblJurosAm.Name = "lblJurosAm";
            this.lblJurosAm.Size = new System.Drawing.Size(112, 13);
            this.lblJurosAm.TabIndex = 0;
            this.lblJurosAm.Text = "Juros (a.m) + (R$):";
            // 
            // lblValorJurosAm
            // 
            this.lblValorJurosAm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorJurosAm.BackColor = System.Drawing.Color.White;
            this.lblValorJurosAm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorJurosAm.Enabled = false;
            this.lblValorJurosAm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorJurosAm.ForeColor = System.Drawing.Color.Red;
            this.lblValorJurosAm.Location = new System.Drawing.Point(116, 113);
            this.lblValorJurosAm.Name = "lblValorJurosAm";
            this.lblValorJurosAm.Size = new System.Drawing.Size(105, 22);
            this.lblValorJurosAm.TabIndex = 0;
            this.lblValorJurosAm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorJurosAm.Click += new System.EventHandler(this.lblValorJurosAm_Click);
            this.lblValorJurosAm.MouseLeave += new System.EventHandler(this.lblValorJurosAm_MouseLeave);
            this.lblValorJurosAm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorJurosAm_MouseMove);
            // 
            // lblMultaPorcValor
            // 
            this.lblMultaPorcValor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMultaPorcValor.BackColor = System.Drawing.Color.Transparent;
            this.lblMultaPorcValor.Enabled = false;
            this.lblMultaPorcValor.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMultaPorcValor.ForeColor = System.Drawing.Color.Black;
            this.lblMultaPorcValor.Location = new System.Drawing.Point(225, 88);
            this.lblMultaPorcValor.Name = "lblMultaPorcValor";
            this.lblMultaPorcValor.Size = new System.Drawing.Size(195, 26);
            this.lblMultaPorcValor.TabIndex = 0;
            this.lblMultaPorcValor.Text = "Multa de: 0,00%.";
            this.lblMultaPorcValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDiasDeAtraso
            // 
            this.lblDiasDeAtraso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDiasDeAtraso.AutoSize = true;
            this.lblDiasDeAtraso.BackColor = System.Drawing.Color.Transparent;
            this.lblDiasDeAtraso.Enabled = false;
            this.lblDiasDeAtraso.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiasDeAtraso.ForeColor = System.Drawing.Color.Red;
            this.lblDiasDeAtraso.Location = new System.Drawing.Point(231, 73);
            this.lblDiasDeAtraso.Name = "lblDiasDeAtraso";
            this.lblDiasDeAtraso.Size = new System.Drawing.Size(65, 15);
            this.lblDiasDeAtraso.TabIndex = 0;
            this.lblDiasDeAtraso.Text = "DiasAtraso";
            this.lblDiasDeAtraso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDiasDeAtraso.Visible = false;
            // 
            // lblValorDesconto
            // 
            this.lblValorDesconto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDesconto.BackColor = System.Drawing.Color.White;
            this.lblValorDesconto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDesconto.Enabled = false;
            this.lblValorDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDesconto.ForeColor = System.Drawing.Color.Blue;
            this.lblValorDesconto.Location = new System.Drawing.Point(116, 51);
            this.lblValorDesconto.Name = "lblValorDesconto";
            this.lblValorDesconto.Size = new System.Drawing.Size(105, 22);
            this.lblValorDesconto.TabIndex = 0;
            this.lblValorDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorDesconto.Click += new System.EventHandler(this.lblValorDesconto_Click);
            this.lblValorDesconto.MouseLeave += new System.EventHandler(this.lblValorDesconto_MouseLeave);
            this.lblValorDesconto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorDesconto_MouseMove);
            // 
            // lblDescontoPorcValor
            // 
            this.lblDescontoPorcValor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescontoPorcValor.BackColor = System.Drawing.Color.Transparent;
            this.lblDescontoPorcValor.Enabled = false;
            this.lblDescontoPorcValor.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescontoPorcValor.ForeColor = System.Drawing.Color.Black;
            this.lblDescontoPorcValor.Location = new System.Drawing.Point(227, 49);
            this.lblDescontoPorcValor.Name = "lblDescontoPorcValor";
            this.lblDescontoPorcValor.Size = new System.Drawing.Size(195, 26);
            this.lblDescontoPorcValor.TabIndex = 0;
            this.lblDescontoPorcValor.Text = "Desconto de: 0,00%.";
            this.lblDescontoPorcValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Enabled = false;
            this.lblDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesconto.ForeColor = System.Drawing.Color.Black;
            this.lblDesconto.Location = new System.Drawing.Point(16, 56);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(101, 13);
            this.lblDesconto.TabIndex = 0;
            this.lblDesconto.Text = "Desconto - (R$):";
            // 
            // lblValorMulta
            // 
            this.lblValorMulta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorMulta.BackColor = System.Drawing.Color.White;
            this.lblValorMulta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorMulta.Enabled = false;
            this.lblValorMulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorMulta.ForeColor = System.Drawing.Color.Red;
            this.lblValorMulta.Location = new System.Drawing.Point(116, 88);
            this.lblValorMulta.Name = "lblValorMulta";
            this.lblValorMulta.Size = new System.Drawing.Size(105, 25);
            this.lblValorMulta.TabIndex = 0;
            this.lblValorMulta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorMulta.Click += new System.EventHandler(this.lblValorMulta_Click);
            this.lblValorMulta.MouseLeave += new System.EventHandler(this.lblValorMulta_MouseLeave);
            this.lblValorMulta.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorMulta_MouseMove);
            // 
            // lblMulta
            // 
            this.lblMulta.AutoSize = true;
            this.lblMulta.Enabled = false;
            this.lblMulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMulta.ForeColor = System.Drawing.Color.Black;
            this.lblMulta.Location = new System.Drawing.Point(36, 95);
            this.lblMulta.Name = "lblMulta";
            this.lblMulta.Size = new System.Drawing.Size(81, 13);
            this.lblMulta.TabIndex = 0;
            this.lblMulta.Text = "Multa + (R$):";
            // 
            // lblValorReal
            // 
            this.lblValorReal.AutoSize = true;
            this.lblValorReal.Enabled = false;
            this.lblValorReal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorReal.ForeColor = System.Drawing.Color.Black;
            this.lblValorReal.Location = new System.Drawing.Point(394, 119);
            this.lblValorReal.Name = "lblValorReal";
            this.lblValorReal.Size = new System.Drawing.Size(156, 13);
            this.lblValorReal.TabIndex = 0;
            this.lblValorReal.Text = "Valor Restante Atual (R$):";
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(105, 12);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // lblDataPagamento
            // 
            this.lblDataPagamento.AutoSize = true;
            this.lblDataPagamento.Location = new System.Drawing.Point(5, 16);
            this.lblDataPagamento.Name = "lblDataPagamento";
            this.lblDataPagamento.Size = new System.Drawing.Size(105, 13);
            this.lblDataPagamento.TabIndex = 0;
            this.lblDataPagamento.Text = "Data de Pagamento:";
            // 
            // lblValorDocumento
            // 
            this.lblValorDocumento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDocumento.BackColor = System.Drawing.Color.White;
            this.lblValorDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDocumento.Location = new System.Drawing.Point(332, 44);
            this.lblValorDocumento.Name = "lblValorDocumento";
            this.lblValorDocumento.Size = new System.Drawing.Size(101, 22);
            this.lblValorDocumento.TabIndex = 0;
            this.lblValorDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorDocumento.Click += new System.EventHandler(this.lblValorDocumento_Click);
            this.lblValorDocumento.MouseLeave += new System.EventHandler(this.lblValorDocumento_MouseLeave);
            this.lblValorDocumento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorDocumento_MouseMove);
            // 
            // lblValorDataDesconto
            // 
            this.lblValorDataDesconto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDataDesconto.BackColor = System.Drawing.Color.White;
            this.lblValorDataDesconto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDataDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDataDesconto.Location = new System.Drawing.Point(553, 46);
            this.lblValorDataDesconto.Name = "lblValorDataDesconto";
            this.lblValorDataDesconto.Size = new System.Drawing.Size(119, 22);
            this.lblValorDataDesconto.TabIndex = 0;
            this.lblValorDataDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblValorDataDesconto.Click += new System.EventHandler(this.lblValorDataDesconto_Click);
            this.lblValorDataDesconto.MouseLeave += new System.EventHandler(this.lblValorDataDesconto_MouseLeave);
            this.lblValorDataDesconto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorDataDesconto_MouseMove);
            // 
            // lblDataEmissao
            // 
            this.lblDataEmissao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDataEmissao.BackColor = System.Drawing.Color.Transparent;
            this.lblDataEmissao.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataEmissao.ForeColor = System.Drawing.Color.Black;
            this.lblDataEmissao.Location = new System.Drawing.Point(453, 14);
            this.lblDataEmissao.Name = "lblDataEmissao";
            this.lblDataEmissao.Size = new System.Drawing.Size(100, 26);
            this.lblDataEmissao.TabIndex = 0;
            this.lblDataEmissao.Text = "Data de Emissão:";
            this.lblDataEmissao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.Color.Black;
            this.lblValor.Location = new System.Drawing.Point(265, 49);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(64, 15);
            this.lblValor.TabIndex = 0;
            this.lblValor.Text = "Valor (R$):";
            // 
            // lblDataVencimento
            // 
            this.lblDataVencimento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDataVencimento.BackColor = System.Drawing.Color.Transparent;
            this.lblDataVencimento.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataVencimento.ForeColor = System.Drawing.Color.Black;
            this.lblDataVencimento.Location = new System.Drawing.Point(6, 41);
            this.lblDataVencimento.Name = "lblDataVencimento";
            this.lblDataVencimento.Size = new System.Drawing.Size(122, 26);
            this.lblDataVencimento.TabIndex = 0;
            this.lblDataVencimento.Text = "Data de Vencimento:";
            this.lblDataVencimento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorDataEmissao
            // 
            this.lblValorDataEmissao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDataEmissao.BackColor = System.Drawing.Color.White;
            this.lblValorDataEmissao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDataEmissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDataEmissao.Location = new System.Drawing.Point(553, 17);
            this.lblValorDataEmissao.Name = "lblValorDataEmissao";
            this.lblValorDataEmissao.Size = new System.Drawing.Size(119, 22);
            this.lblValorDataEmissao.TabIndex = 0;
            this.lblValorDataEmissao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblValorDataEmissao.Click += new System.EventHandler(this.lblValorDataEmissao_Click);
            this.lblValorDataEmissao.MouseLeave += new System.EventHandler(this.lblValorDataEmissao_MouseLeave);
            this.lblValorDataEmissao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorDataEmissao_MouseMove);
            // 
            // lblValorDataVencimento
            // 
            this.lblValorDataVencimento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDataVencimento.BackColor = System.Drawing.Color.White;
            this.lblValorDataVencimento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDataVencimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDataVencimento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblValorDataVencimento.Location = new System.Drawing.Point(132, 44);
            this.lblValorDataVencimento.Name = "lblValorDataVencimento";
            this.lblValorDataVencimento.Size = new System.Drawing.Size(108, 22);
            this.lblValorDataVencimento.TabIndex = 0;
            this.lblValorDataVencimento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblValorDataVencimento.Click += new System.EventHandler(this.lblValorDataVencimento_Click);
            this.lblValorDataVencimento.MouseLeave += new System.EventHandler(this.lblValorDataVencimento_MouseLeave);
            this.lblValorDataVencimento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorDataVencimento_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(634, 452);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 14;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixaContaPagar.SetToolTip(this.btnSair, "Sair de Baixa do Registro.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // pcibInterrogacao
            // 
            this.pcibInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao.Image")));
            this.pcibInterrogacao.Location = new System.Drawing.Point(531, 452);
            this.pcibInterrogacao.Name = "pcibInterrogacao";
            this.pcibInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao.TabIndex = 115;
            this.pcibInterrogacao.TabStop = false;
            this.pcibInterrogacao.Click += new System.EventHandler(this.pcibInterrogacao_Click);
            this.pcibInterrogacao.MouseLeave += new System.EventHandler(this.pcibInterrogacao_MouseLeave);
            this.pcibInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(557, 452);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 13;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixaContaPagar.SetToolTip(this.btnSalvar, "Salvar os dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // ttpBaixaContaPagar
            // 
            this.ttpBaixaContaPagar.AutoPopDelay = 5000;
            this.ttpBaixaContaPagar.InitialDelay = 1000;
            this.ttpBaixaContaPagar.IsBalloon = true;
            this.ttpBaixaContaPagar.ReshowDelay = 100;
            this.ttpBaixaContaPagar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpBaixaContaPagar.ToolTipTitle = "Dica:";
            // 
            // FrmRelBaixaConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(702, 488);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.pcibInterrogacao);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelBaixaConta";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baixar Registro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOpeFormBaixaContaPagar_FormClosing);
            this.Load += new System.EventHandler(this.FrmOpeFormBaixaContaPagar_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmOpeFormBaixaContaPagar_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            this.grbBox3.ResumeLayout(false);
            this.grbBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFormaPagamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblNDocumento;
        private System.Windows.Forms.Label lbldocumento;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblValorCodigo;
        private System.Windows.Forms.Label lblDataDesconto;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Label lblValorParcialPago;
        private System.Windows.Forms.Label lblParcialPago;
        private System.Windows.Forms.MaskedTextBox mtxtDataPagamento;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.Label lblValorReal;
        private System.Windows.Forms.Label lblValorRealDocumento;
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
        private System.Windows.Forms.Label lblAntesVencimento;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.Label lblDataPagamento;
        private System.Windows.Forms.Label lblAposVencimento;
        private System.Windows.Forms.Label lblJurosAMPorcValor;
        private System.Windows.Forms.Label lblJurosAm;
        private System.Windows.Forms.Label lblValorJurosAm;
        private System.Windows.Forms.Label lblMultaPorcValor;
        private System.Windows.Forms.Label lblDiasDeAtraso;
        private System.Windows.Forms.Label lblValorDesconto;
        private System.Windows.Forms.Label lblDescontoPorcValor;
        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.Label lblValorMulta;
        private System.Windows.Forms.Label lblMulta;
        private System.Windows.Forms.Label lblValorDocumento;
        private System.Windows.Forms.Label lblValorDataDesconto;
        private System.Windows.Forms.Label lblDataEmissao;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblDataVencimento;
        private System.Windows.Forms.Label lblValorDataEmissao;
        private System.Windows.Forms.Label lblValorDataVencimento;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox pcibInterrogacao;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ToolTip ttpBaixaContaPagar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblValorParcela;
        private System.Windows.Forms.CheckBox chkbIgnorarMulta;
        private System.Windows.Forms.CheckBox chkbIgnorarJurosAM;
    }
}