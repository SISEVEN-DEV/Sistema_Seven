namespace SIE_7_Sistema
{
    partial class FrmBaixaTituloContasPagar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaixaTituloContasPagar));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblValorParcela = new System.Windows.Forms.Label();
            this.lblParcela = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.lblNdocumento = new System.Windows.Forms.Label();
            this.lblDataDesconto = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.grbBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblValorTotalDocumento = new System.Windows.Forms.Label();
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.lblMoraValor = new System.Windows.Forms.Label();
            this.lblValorTitulo = new System.Windows.Forms.Label();
            this.lblDiasDeAtraso = new System.Windows.Forms.Label();
            this.lblVTitulo = new System.Windows.Forms.Label();
            this.lblMulta = new System.Windows.Forms.Label();
            this.lblValorMulta = new System.Windows.Forms.Label();
            this.lblTotalPagar = new System.Windows.Forms.Label();
            this.lblValorDesconto = new System.Windows.Forms.Label();
            this.lblVTotalTitulo = new System.Windows.Forms.Label();
            this.lblMora = new System.Windows.Forms.Label();
            this.lblAposVencimento = new System.Windows.Forms.Label();
            this.lblValorMora = new System.Windows.Forms.Label();
            this.lblMultaValor = new System.Windows.Forms.Label();
            this.lblDescontoValor = new System.Windows.Forms.Label();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.lblDataRecebimento = new System.Windows.Forms.Label();
            this.cbbTipoPagamento = new System.Windows.Forms.ComboBox();
            this.lblTipoPagamento = new System.Windows.Forms.Label();
            this.mtxtDataRecebimento = new System.Windows.Forms.MaskedTextBox();
            this.lblValorDataDesconto = new System.Windows.Forms.Label();
            this.lblDataEmissao = new System.Windows.Forms.Label();
            this.lblDataVencimento = new System.Windows.Forms.Label();
            this.lblValorDataEmissao = new System.Windows.Forms.Label();
            this.lblValorDataVencimento = new System.Windows.Forms.Label();
            this.ttpBaixaTitulo = new System.Windows.Forms.ToolTip(this.components);
            this.btnProcurarForma = new System.Windows.Forms.Button();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.btnRenegociada = new System.Windows.Forms.Button();
            this.btnAdicObservacao = new System.Windows.Forms.Button();
            this.btnAviso = new System.Windows.Forms.Button();
            this.pcibInterrogacao = new System.Windows.Forms.PictureBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grbBox1.SuspendLayout();
            this.grbBox2.SuspendLayout();
            this.grbBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblValorParcela);
            this.grbBox1.Controls.Add(this.lblParcela);
            this.grbBox1.Controls.Add(this.lblDocumento);
            this.grbBox1.Controls.Add(this.lblNdocumento);
            this.grbBox1.Controls.Add(this.lblDataDesconto);
            this.grbBox1.Controls.Add(this.grbBox2);
            this.grbBox1.Controls.Add(this.lblValorDataDesconto);
            this.grbBox1.Controls.Add(this.lblDataEmissao);
            this.grbBox1.Controls.Add(this.lblDataVencimento);
            this.grbBox1.Controls.Add(this.lblValorDataEmissao);
            this.grbBox1.Controls.Add(this.lblValorDataVencimento);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(669, 331);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Informações:";
            // 
            // lblValorParcela
            // 
            this.lblValorParcela.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorParcela.BackColor = System.Drawing.Color.LightGray;
            this.lblValorParcela.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorParcela.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorParcela.Location = new System.Drawing.Point(595, 16);
            this.lblValorParcela.Name = "lblValorParcela";
            this.lblValorParcela.Size = new System.Drawing.Size(68, 22);
            this.lblValorParcela.TabIndex = 3;
            this.lblValorParcela.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblParcela
            // 
            this.lblParcela.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblParcela.BackColor = System.Drawing.Color.Transparent;
            this.lblParcela.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParcela.ForeColor = System.Drawing.Color.Black;
            this.lblParcela.Location = new System.Drawing.Point(542, 13);
            this.lblParcela.Name = "lblParcela";
            this.lblParcela.Size = new System.Drawing.Size(57, 26);
            this.lblParcela.TabIndex = 2;
            this.lblParcela.Text = "Parcela:";
            this.lblParcela.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDocumento
            // 
            this.lblDocumento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDocumento.BackColor = System.Drawing.Color.Transparent;
            this.lblDocumento.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocumento.ForeColor = System.Drawing.Color.Black;
            this.lblDocumento.Location = new System.Drawing.Point(6, 13);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(110, 26);
            this.lblDocumento.TabIndex = 0;
            this.lblDocumento.Text = "Nº do Documento:";
            this.lblDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNdocumento
            // 
            this.lblNdocumento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNdocumento.BackColor = System.Drawing.Color.LightGray;
            this.lblNdocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNdocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNdocumento.Location = new System.Drawing.Point(116, 16);
            this.lblNdocumento.Name = "lblNdocumento";
            this.lblNdocumento.Size = new System.Drawing.Size(179, 22);
            this.lblNdocumento.TabIndex = 0;
            this.lblNdocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDataDesconto
            // 
            this.lblDataDesconto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDataDesconto.BackColor = System.Drawing.Color.Transparent;
            this.lblDataDesconto.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataDesconto.ForeColor = System.Drawing.Color.Black;
            this.lblDataDesconto.Location = new System.Drawing.Point(468, 40);
            this.lblDataDesconto.Name = "lblDataDesconto";
            this.lblDataDesconto.Size = new System.Drawing.Size(86, 26);
            this.lblDataDesconto.TabIndex = 0;
            this.lblDataDesconto.Text = "Desconto Até:";
            this.lblDataDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.btnProcurarForma);
            this.grbBox2.Controls.Add(this.btnSelecionarData);
            this.grbBox2.Controls.Add(this.grbBox3);
            this.grbBox2.Controls.Add(this.lblDataRecebimento);
            this.grbBox2.Controls.Add(this.cbbTipoPagamento);
            this.grbBox2.Controls.Add(this.lblTipoPagamento);
            this.grbBox2.Controls.Add(this.mtxtDataRecebimento);
            this.grbBox2.Location = new System.Drawing.Point(9, 71);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(649, 254);
            this.grbBox2.TabIndex = 1;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Pagamento:";
            // 
            // grbBox3
            // 
            this.grbBox3.Controls.Add(this.btnRenegociada);
            this.grbBox3.Controls.Add(this.label1);
            this.grbBox3.Controls.Add(this.lblValorTotalDocumento);
            this.grbBox3.Controls.Add(this.btnAdicObservacao);
            this.grbBox3.Controls.Add(this.txtValorPago);
            this.grbBox3.Controls.Add(this.btnAviso);
            this.grbBox3.Controls.Add(this.lblMoraValor);
            this.grbBox3.Controls.Add(this.lblValorTitulo);
            this.grbBox3.Controls.Add(this.lblDiasDeAtraso);
            this.grbBox3.Controls.Add(this.lblVTitulo);
            this.grbBox3.Controls.Add(this.lblMulta);
            this.grbBox3.Controls.Add(this.lblValorMulta);
            this.grbBox3.Controls.Add(this.lblTotalPagar);
            this.grbBox3.Controls.Add(this.lblValorDesconto);
            this.grbBox3.Controls.Add(this.lblVTotalTitulo);
            this.grbBox3.Controls.Add(this.lblMora);
            this.grbBox3.Controls.Add(this.lblAposVencimento);
            this.grbBox3.Controls.Add(this.lblValorMora);
            this.grbBox3.Controls.Add(this.lblMultaValor);
            this.grbBox3.Controls.Add(this.lblDescontoValor);
            this.grbBox3.Controls.Add(this.lblDesconto);
            this.grbBox3.Location = new System.Drawing.Point(9, 39);
            this.grbBox3.Name = "grbBox3";
            this.grbBox3.Size = new System.Drawing.Size(631, 208);
            this.grbBox3.TabIndex = 5;
            this.grbBox3.TabStop = false;
            this.grbBox3.Text = "Ações:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(100, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Antes do vencimento:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorTotalDocumento
            // 
            this.lblValorTotalDocumento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorTotalDocumento.BackColor = System.Drawing.Color.LightGray;
            this.lblValorTotalDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotalDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalDocumento.Location = new System.Drawing.Point(465, 141);
            this.lblValorTotalDocumento.Name = "lblValorTotalDocumento";
            this.lblValorTotalDocumento.Size = new System.Drawing.Size(160, 28);
            this.lblValorTotalDocumento.TabIndex = 0;
            this.lblValorTotalDocumento.Text = "0,00";
            this.lblValorTotalDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtValorPago
            // 
            this.txtValorPago.BackColor = System.Drawing.Color.White;
            this.txtValorPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.txtValorPago.Location = new System.Drawing.Point(465, 173);
            this.txtValorPago.MaxLength = 17;
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Size = new System.Drawing.Size(160, 31);
            this.txtValorPago.TabIndex = 6;
            this.txtValorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorPago.TextChanged += new System.EventHandler(this.txtValorPago_TextChanged);
            this.txtValorPago.DoubleClick += new System.EventHandler(this.txtValorPago_DoubleClick);
            this.txtValorPago.Enter += new System.EventHandler(this.txtValorPago_Enter);
            this.txtValorPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorPago_KeyPress);
            this.txtValorPago.Leave += new System.EventHandler(this.txtValorPago_Leave);
            // 
            // lblMoraValor
            // 
            this.lblMoraValor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMoraValor.BackColor = System.Drawing.Color.Transparent;
            this.lblMoraValor.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoraValor.ForeColor = System.Drawing.Color.Black;
            this.lblMoraValor.Location = new System.Drawing.Point(212, 86);
            this.lblMoraValor.Name = "lblMoraValor";
            this.lblMoraValor.Size = new System.Drawing.Size(195, 26);
            this.lblMoraValor.TabIndex = 0;
            this.lblMoraValor.Text = "Juros (a.m) de: 0%.";
            this.lblMoraValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorTitulo
            // 
            this.lblValorTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorTitulo.BackColor = System.Drawing.Color.LightGray;
            this.lblValorTitulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTitulo.Location = new System.Drawing.Point(465, 109);
            this.lblValorTitulo.Name = "lblValorTitulo";
            this.lblValorTitulo.Size = new System.Drawing.Size(160, 28);
            this.lblValorTitulo.TabIndex = 0;
            this.lblValorTitulo.Text = "0,00";
            this.lblValorTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiasDeAtraso
            // 
            this.lblDiasDeAtraso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDiasDeAtraso.AutoSize = true;
            this.lblDiasDeAtraso.BackColor = System.Drawing.Color.Transparent;
            this.lblDiasDeAtraso.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiasDeAtraso.ForeColor = System.Drawing.Color.Black;
            this.lblDiasDeAtraso.Location = new System.Drawing.Point(212, 45);
            this.lblDiasDeAtraso.Name = "lblDiasDeAtraso";
            this.lblDiasDeAtraso.Size = new System.Drawing.Size(65, 15);
            this.lblDiasDeAtraso.TabIndex = 0;
            this.lblDiasDeAtraso.Text = "DiasAtraso";
            this.lblDiasDeAtraso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDiasDeAtraso.Visible = false;
            // 
            // lblVTitulo
            // 
            this.lblVTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblVTitulo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblVTitulo.Location = new System.Drawing.Point(341, 109);
            this.lblVTitulo.Name = "lblVTitulo";
            this.lblVTitulo.Size = new System.Drawing.Size(120, 26);
            this.lblVTitulo.TabIndex = 0;
            this.lblVTitulo.Text = "Subtotal (R$):";
            this.lblVTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMulta
            // 
            this.lblMulta.AutoSize = true;
            this.lblMulta.Location = new System.Drawing.Point(30, 69);
            this.lblMulta.Name = "lblMulta";
            this.lblMulta.Size = new System.Drawing.Size(65, 13);
            this.lblMulta.TabIndex = 0;
            this.lblMulta.Text = "Multa +(R$):";
            // 
            // lblValorMulta
            // 
            this.lblValorMulta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorMulta.BackColor = System.Drawing.Color.LightGray;
            this.lblValorMulta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorMulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorMulta.Location = new System.Drawing.Point(101, 63);
            this.lblValorMulta.Name = "lblValorMulta";
            this.lblValorMulta.Size = new System.Drawing.Size(105, 22);
            this.lblValorMulta.TabIndex = 0;
            this.lblValorMulta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalPagar
            // 
            this.lblTotalPagar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalPagar.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPagar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagar.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPagar.Location = new System.Drawing.Point(321, 174);
            this.lblTotalPagar.Name = "lblTotalPagar";
            this.lblTotalPagar.Size = new System.Drawing.Size(140, 26);
            this.lblTotalPagar.TabIndex = 0;
            this.lblTotalPagar.Text = "Valor pago (R$):";
            this.lblTotalPagar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValorDesconto
            // 
            this.lblValorDesconto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDesconto.BackColor = System.Drawing.Color.LightGray;
            this.lblValorDesconto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDesconto.Location = new System.Drawing.Point(101, 23);
            this.lblValorDesconto.Name = "lblValorDesconto";
            this.lblValorDesconto.Size = new System.Drawing.Size(105, 22);
            this.lblValorDesconto.TabIndex = 0;
            this.lblValorDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVTotalTitulo
            // 
            this.lblVTotalTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVTotalTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblVTotalTitulo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVTotalTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblVTotalTitulo.Location = new System.Drawing.Point(366, 141);
            this.lblVTotalTitulo.Name = "lblVTotalTitulo";
            this.lblVTotalTitulo.Size = new System.Drawing.Size(93, 26);
            this.lblVTotalTitulo.TabIndex = 0;
            this.lblVTotalTitulo.Text = "Total (R$):";
            this.lblVTotalTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMora
            // 
            this.lblMora.AutoSize = true;
            this.lblMora.Location = new System.Drawing.Point(5, 93);
            this.lblMora.Name = "lblMora";
            this.lblMora.Size = new System.Drawing.Size(90, 13);
            this.lblMora.TabIndex = 0;
            this.lblMora.Text = "Juros (a.m) +(R$):";
            // 
            // lblAposVencimento
            // 
            this.lblAposVencimento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAposVencimento.AutoSize = true;
            this.lblAposVencimento.BackColor = System.Drawing.Color.Transparent;
            this.lblAposVencimento.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAposVencimento.ForeColor = System.Drawing.Color.Red;
            this.lblAposVencimento.Location = new System.Drawing.Point(100, 45);
            this.lblAposVencimento.Name = "lblAposVencimento";
            this.lblAposVencimento.Size = new System.Drawing.Size(106, 15);
            this.lblAposVencimento.TabIndex = 0;
            this.lblAposVencimento.Text = "Após vencimento:";
            this.lblAposVencimento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorMora
            // 
            this.lblValorMora.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorMora.BackColor = System.Drawing.Color.LightGray;
            this.lblValorMora.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorMora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorMora.Location = new System.Drawing.Point(101, 87);
            this.lblValorMora.Name = "lblValorMora";
            this.lblValorMora.Size = new System.Drawing.Size(105, 22);
            this.lblValorMora.TabIndex = 0;
            this.lblValorMora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMultaValor
            // 
            this.lblMultaValor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMultaValor.BackColor = System.Drawing.Color.Transparent;
            this.lblMultaValor.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMultaValor.ForeColor = System.Drawing.Color.Black;
            this.lblMultaValor.Location = new System.Drawing.Point(212, 62);
            this.lblMultaValor.Name = "lblMultaValor";
            this.lblMultaValor.Size = new System.Drawing.Size(195, 26);
            this.lblMultaValor.TabIndex = 0;
            this.lblMultaValor.Text = "Multa de: 0%.";
            this.lblMultaValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescontoValor
            // 
            this.lblDescontoValor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescontoValor.BackColor = System.Drawing.Color.Transparent;
            this.lblDescontoValor.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescontoValor.ForeColor = System.Drawing.Color.Black;
            this.lblDescontoValor.Location = new System.Drawing.Point(212, 21);
            this.lblDescontoValor.Name = "lblDescontoValor";
            this.lblDescontoValor.Size = new System.Drawing.Size(195, 26);
            this.lblDescontoValor.TabIndex = 0;
            this.lblDescontoValor.Text = "Desconto de: 0%.";
            this.lblDescontoValor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Location = new System.Drawing.Point(13, 28);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(82, 13);
            this.lblDesconto.TabIndex = 0;
            this.lblDesconto.Text = "Desconto -(R$):";
            // 
            // lblDataRecebimento
            // 
            this.lblDataRecebimento.AutoSize = true;
            this.lblDataRecebimento.Location = new System.Drawing.Point(6, 16);
            this.lblDataRecebimento.Name = "lblDataRecebimento";
            this.lblDataRecebimento.Size = new System.Drawing.Size(104, 13);
            this.lblDataRecebimento.TabIndex = 0;
            this.lblDataRecebimento.Text = "Data de pagamento:";
            // 
            // cbbTipoPagamento
            // 
            this.cbbTipoPagamento.BackColor = System.Drawing.Color.LightBlue;
            this.cbbTipoPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTipoPagamento.FormattingEnabled = true;
            this.cbbTipoPagamento.Location = new System.Drawing.Point(348, 13);
            this.cbbTipoPagamento.Name = "cbbTipoPagamento";
            this.cbbTipoPagamento.Size = new System.Drawing.Size(260, 21);
            this.cbbTipoPagamento.TabIndex = 3;
            this.cbbTipoPagamento.DropDown += new System.EventHandler(this.cbbTipoPagamento_DropDown);
            this.cbbTipoPagamento.SelectedIndexChanged += new System.EventHandler(this.cbbTipoPagamento_SelectedIndexChanged);
            this.cbbTipoPagamento.DropDownClosed += new System.EventHandler(this.cbbTipoPagamento_DropDownClosed);
            this.cbbTipoPagamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbTipoPagamento_KeyPress);
            this.cbbTipoPagamento.MouseLeave += new System.EventHandler(this.cbbTipoPagamento_MouseLeave);
            this.cbbTipoPagamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbTipoPagamento_MouseMove);
            // 
            // lblTipoPagamento
            // 
            this.lblTipoPagamento.AutoSize = true;
            this.lblTipoPagamento.Location = new System.Drawing.Point(232, 16);
            this.lblTipoPagamento.Name = "lblTipoPagamento";
            this.lblTipoPagamento.Size = new System.Drawing.Size(110, 13);
            this.lblTipoPagamento.TabIndex = 0;
            this.lblTipoPagamento.Text = "Forma de pagamento:";
            // 
            // mtxtDataRecebimento
            // 
            this.mtxtDataRecebimento.BackColor = System.Drawing.Color.White;
            this.mtxtDataRecebimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtDataRecebimento.Location = new System.Drawing.Point(116, 13);
            this.mtxtDataRecebimento.Mask = "00/00/0000";
            this.mtxtDataRecebimento.Name = "mtxtDataRecebimento";
            this.mtxtDataRecebimento.Size = new System.Drawing.Size(78, 20);
            this.mtxtDataRecebimento.TabIndex = 2;
            this.mtxtDataRecebimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtDataRecebimento.ValidatingType = typeof(System.DateTime);
            this.mtxtDataRecebimento.DoubleClick += new System.EventHandler(this.mtxtDataRecebimento_DoubleClick);
            this.mtxtDataRecebimento.Enter += new System.EventHandler(this.mtxtDataRecebimento_Enter);
            this.mtxtDataRecebimento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtDataRecebimento_KeyPress);
            this.mtxtDataRecebimento.Leave += new System.EventHandler(this.mtxtDataRecebimento_Leave);
            // 
            // lblValorDataDesconto
            // 
            this.lblValorDataDesconto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDataDesconto.BackColor = System.Drawing.Color.LightGray;
            this.lblValorDataDesconto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDataDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDataDesconto.Location = new System.Drawing.Point(555, 43);
            this.lblValorDataDesconto.Name = "lblValorDataDesconto";
            this.lblValorDataDesconto.Size = new System.Drawing.Size(108, 22);
            this.lblValorDataDesconto.TabIndex = 0;
            this.lblValorDataDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataEmissao
            // 
            this.lblDataEmissao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDataEmissao.BackColor = System.Drawing.Color.Transparent;
            this.lblDataEmissao.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataEmissao.ForeColor = System.Drawing.Color.Black;
            this.lblDataEmissao.Location = new System.Drawing.Point(6, 40);
            this.lblDataEmissao.Name = "lblDataEmissao";
            this.lblDataEmissao.Size = new System.Drawing.Size(100, 26);
            this.lblDataEmissao.TabIndex = 0;
            this.lblDataEmissao.Text = "Data de Emissão:";
            this.lblDataEmissao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDataVencimento
            // 
            this.lblDataVencimento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDataVencimento.BackColor = System.Drawing.Color.Transparent;
            this.lblDataVencimento.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataVencimento.ForeColor = System.Drawing.Color.Black;
            this.lblDataVencimento.Location = new System.Drawing.Point(224, 40);
            this.lblDataVencimento.Name = "lblDataVencimento";
            this.lblDataVencimento.Size = new System.Drawing.Size(122, 26);
            this.lblDataVencimento.TabIndex = 0;
            this.lblDataVencimento.Text = "Data de Vencimento:";
            this.lblDataVencimento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorDataEmissao
            // 
            this.lblValorDataEmissao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDataEmissao.BackColor = System.Drawing.Color.LightGray;
            this.lblValorDataEmissao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDataEmissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDataEmissao.Location = new System.Drawing.Point(116, 43);
            this.lblValorDataEmissao.Name = "lblValorDataEmissao";
            this.lblValorDataEmissao.Size = new System.Drawing.Size(108, 22);
            this.lblValorDataEmissao.TabIndex = 0;
            this.lblValorDataEmissao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValorDataVencimento
            // 
            this.lblValorDataVencimento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDataVencimento.BackColor = System.Drawing.Color.LightGray;
            this.lblValorDataVencimento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDataVencimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDataVencimento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblValorDataVencimento.Location = new System.Drawing.Point(348, 43);
            this.lblValorDataVencimento.Name = "lblValorDataVencimento";
            this.lblValorDataVencimento.Size = new System.Drawing.Size(108, 22);
            this.lblValorDataVencimento.TabIndex = 0;
            this.lblValorDataVencimento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ttpBaixaTitulo
            // 
            this.ttpBaixaTitulo.IsBalloon = true;
            this.ttpBaixaTitulo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpBaixaTitulo.ToolTipTitle = "Dica:";
            // 
            // btnProcurarForma
            // 
            this.btnProcurarForma.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarForma.Image")));
            this.btnProcurarForma.Location = new System.Drawing.Point(614, 10);
            this.btnProcurarForma.Name = "btnProcurarForma";
            this.btnProcurarForma.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarForma.TabIndex = 4;
            this.btnProcurarForma.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixaTitulo.SetToolTip(this.btnProcurarForma, "Clique para pesquisar uma forma de pagamento.");
            this.btnProcurarForma.UseVisualStyleBackColor = true;
            this.btnProcurarForma.Click += new System.EventHandler(this.btnProcurarForma_Click);
            this.btnProcurarForma.MouseLeave += new System.EventHandler(this.btnProcurarForma_MouseLeave);
            this.btnProcurarForma.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarForma_MouseMove);
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(200, 10);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 111;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixaTitulo.SetToolTip(this.btnSelecionarData, "Clique para selecionar a data.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // btnRenegociada
            // 
            this.btnRenegociada.Image = ((System.Drawing.Image)(resources.GetObject("btnRenegociada.Image")));
            this.btnRenegociada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenegociada.Location = new System.Drawing.Point(188, 179);
            this.btnRenegociada.Name = "btnRenegociada";
            this.btnRenegociada.Size = new System.Drawing.Size(98, 25);
            this.btnRenegociada.TabIndex = 109;
            this.btnRenegociada.Text = "&Renegociada";
            this.btnRenegociada.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixaTitulo.SetToolTip(this.btnRenegociada, "Clique informar que esta conta a pagar vai ser renegociada.");
            this.btnRenegociada.UseVisualStyleBackColor = true;
            this.btnRenegociada.Click += new System.EventHandler(this.btnRenegociada_Click);
            this.btnRenegociada.MouseLeave += new System.EventHandler(this.btnRenegociada_MouseLeave);
            this.btnRenegociada.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRenegociada_MouseMove);
            // 
            // btnAdicObservacao
            // 
            this.btnAdicObservacao.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicObservacao.Image")));
            this.btnAdicObservacao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdicObservacao.Location = new System.Drawing.Point(38, 179);
            this.btnAdicObservacao.Name = "btnAdicObservacao";
            this.btnAdicObservacao.Size = new System.Drawing.Size(144, 25);
            this.btnAdicObservacao.TabIndex = 8;
            this.btnAdicObservacao.Text = "Adicionar &Observações";
            this.btnAdicObservacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixaTitulo.SetToolTip(this.btnAdicObservacao, "Clique para adicionar uma observação.");
            this.btnAdicObservacao.UseVisualStyleBackColor = true;
            this.btnAdicObservacao.Click += new System.EventHandler(this.btnAdicObservacao_Click);
            this.btnAdicObservacao.MouseLeave += new System.EventHandler(this.btnAdicObservacao_MouseLeave);
            this.btnAdicObservacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAdicObservacao_MouseMove);
            // 
            // btnAviso
            // 
            this.btnAviso.Image = ((System.Drawing.Image)(resources.GetObject("btnAviso.Image")));
            this.btnAviso.Location = new System.Drawing.Point(6, 179);
            this.btnAviso.Name = "btnAviso";
            this.btnAviso.Size = new System.Drawing.Size(26, 25);
            this.btnAviso.TabIndex = 7;
            this.btnAviso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixaTitulo.SetToolTip(this.btnAviso, "Clique para visualizar informações sobre o calculo das contas.");
            this.btnAviso.UseVisualStyleBackColor = true;
            this.btnAviso.Click += new System.EventHandler(this.btnMora_Click);
            this.btnAviso.MouseLeave += new System.EventHandler(this.btnMora_MouseLeave);
            this.btnAviso.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMora_MouseMove);
            // 
            // pcibInterrogacao
            // 
            this.pcibInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao.Image")));
            this.pcibInterrogacao.Location = new System.Drawing.Point(494, 349);
            this.pcibInterrogacao.Name = "pcibInterrogacao";
            this.pcibInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao.TabIndex = 108;
            this.pcibInterrogacao.TabStop = false;
            this.pcibInterrogacao.Click += new System.EventHandler(this.pcibInterrogacao_Click);
            this.pcibInterrogacao.MouseLeave += new System.EventHandler(this.pcibInterrogacao_MouseLeave);
            this.pcibInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(520, 349);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 35);
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixaTitulo.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(596, 349);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 35);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixaTitulo.SetToolTip(this.btnCancelar, "Cancelar opção atual.");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            this.btnCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelar_MouseMove);
            // 
            // FrmBaixaTituloContasPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(690, 387);
            this.ControlBox = false;
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.pcibInterrogacao);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBaixaTituloContasPagar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baixa de Conta a Pagar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBaixaTituloContasPagar_FormClosing);
            this.Load += new System.EventHandler(this.FrmBaixaTituloContasPagar_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmBaixaTituloContasPagar_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            this.grbBox3.ResumeLayout(false);
            this.grbBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Label lblValorDesconto;
        private System.Windows.Forms.Label lblValorMulta;
        private System.Windows.Forms.Label lblVTotalTitulo;
        private System.Windows.Forms.Label lblAposVencimento;
        private System.Windows.Forms.Label lblTotalPagar;
        private System.Windows.Forms.Label lblMultaValor;
        private System.Windows.Forms.Label lblDescontoValor;
        private System.Windows.Forms.Label lblMulta;
        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.Label lblDataEmissao;
        private System.Windows.Forms.Label lblValorDataVencimento;
        private System.Windows.Forms.Label lblValorDataEmissao;
        private System.Windows.Forms.Label lblDataVencimento;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblTipoPagamento;
        private System.Windows.Forms.ComboBox cbbTipoPagamento;
        private System.Windows.Forms.MaskedTextBox mtxtDataRecebimento;
        private System.Windows.Forms.Label lblDataRecebimento;
        private System.Windows.Forms.ToolTip ttpBaixaTitulo;
        private System.Windows.Forms.PictureBox pcibInterrogacao;
        private System.Windows.Forms.Label lblValorMora;
        private System.Windows.Forms.Label lblMora;
        private System.Windows.Forms.TextBox txtValorPago;
        private System.Windows.Forms.Label lblValorTitulo;
        private System.Windows.Forms.Label lblVTitulo;
        private System.Windows.Forms.Label lblDataDesconto;
        private System.Windows.Forms.Label lblValorDataDesconto;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Label lblNdocumento;
        private System.Windows.Forms.Label lblDiasDeAtraso;
        private System.Windows.Forms.GroupBox grbBox3;
        private System.Windows.Forms.Label lblMoraValor;
        private System.Windows.Forms.Button btnAdicObservacao;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.Button btnAviso;
        private System.Windows.Forms.Label lblValorTotalDocumento;
        private System.Windows.Forms.Button btnProcurarForma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRenegociada;
        private System.Windows.Forms.Label lblValorParcela;
        private System.Windows.Forms.Label lblParcela;
    }
}