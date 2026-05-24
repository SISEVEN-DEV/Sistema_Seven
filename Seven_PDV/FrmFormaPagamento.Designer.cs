namespace Seven_Sistema
{
    partial class FrmFormaPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFormaPagamento));
            this.lblDesconto = new System.Windows.Forms.Label();
            this.txtDescontoPorc = new System.Windows.Forms.TextBox();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAcrescimo = new System.Windows.Forms.TextBox();
            this.txtAcrescimoPorc = new System.Windows.Forms.TextBox();
            this.lblAcrescimo = new System.Windows.Forms.Label();
            this.cbbForma1 = new System.Windows.Forms.ComboBox();
            this.cbbForma2 = new System.Windows.Forms.ComboBox();
            this.cbbForma3 = new System.Windows.Forms.ComboBox();
            this.cbbForma4 = new System.Windows.Forms.ComboBox();
            this.txtValor1 = new System.Windows.Forms.TextBox();
            this.txtCodigo1 = new System.Windows.Forms.TextBox();
            this.txtCodigo2 = new System.Windows.Forms.TextBox();
            this.txtCodigo3 = new System.Windows.Forms.TextBox();
            this.txtValor2 = new System.Windows.Forms.TextBox();
            this.txtValor3 = new System.Windows.Forms.TextBox();
            this.txtValor4 = new System.Windows.Forms.TextBox();
            this.btnProcurar1 = new System.Windows.Forms.Button();
            this.btnProcurar2 = new System.Windows.Forms.Button();
            this.btnProcurar3 = new System.Windows.Forms.Button();
            this.btnProcurar4 = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.btnObservacao = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnNovaNotaPromissoria = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblAsterisco3 = new System.Windows.Forms.Label();
            this.lblAsterisco2 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblValorPago = new System.Windows.Forms.Label();
            this.lblFormaDePagamento = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnRemover1 = new System.Windows.Forms.Button();
            this.btnRemover4 = new System.Windows.Forms.Button();
            this.btnRemover3 = new System.Windows.Forms.Button();
            this.btnRemover2 = new System.Windows.Forms.Button();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblValorPagar = new System.Windows.Forms.Label();
            this.ttpForma = new System.Windows.Forms.ToolTip(this.components);
            this.btnSair = new System.Windows.Forms.Button();
            this.btnInformações = new System.Windows.Forms.Button();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.lblTotalSub = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblDifTroco = new System.Windows.Forms.Label();
            this.lblDT = new System.Windows.Forms.Label();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesconto.Location = new System.Drawing.Point(8, 4);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(90, 20);
            this.lblDesconto.TabIndex = 0;
            this.lblDesconto.Text = "Descontos:";
            // 
            // txtDescontoPorc
            // 
            this.txtDescontoPorc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescontoPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescontoPorc.Location = new System.Drawing.Point(12, 27);
            this.txtDescontoPorc.MaxLength = 6;
            this.txtDescontoPorc.Name = "txtDescontoPorc";
            this.txtDescontoPorc.Size = new System.Drawing.Size(100, 26);
            this.txtDescontoPorc.TabIndex = 1;
            this.txtDescontoPorc.Text = "0,00";
            this.txtDescontoPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescontoPorc.TextChanged += new System.EventHandler(this.txtDescontoPorc_TextChanged);
            this.txtDescontoPorc.Enter += new System.EventHandler(this.txtDescontoPorc_Enter);
            this.txtDescontoPorc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescontoPorc_KeyPress);
            this.txtDescontoPorc.Leave += new System.EventHandler(this.txtDescontoPorc_Leave);
            // 
            // txtDesconto
            // 
            this.txtDesconto.BackColor = System.Drawing.Color.White;
            this.txtDesconto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesconto.Location = new System.Drawing.Point(224, 27);
            this.txtDesconto.MaxLength = 9;
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(136, 26);
            this.txtDesconto.TabIndex = 2;
            this.txtDesconto.Text = "0,00";
            this.txtDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDesconto.TextChanged += new System.EventHandler(this.txtDesconto_TextChanged);
            this.txtDesconto.Enter += new System.EventHandler(this.txtDesconto_Enter);
            this.txtDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesconto_KeyPress);
            this.txtDesconto.Leave += new System.EventHandler(this.txtDesconto_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(629, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "%";
            // 
            // txtAcrescimo
            // 
            this.txtAcrescimo.BackColor = System.Drawing.Color.White;
            this.txtAcrescimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcrescimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcrescimo.Location = new System.Drawing.Point(736, 27);
            this.txtAcrescimo.MaxLength = 9;
            this.txtAcrescimo.Name = "txtAcrescimo";
            this.txtAcrescimo.Size = new System.Drawing.Size(136, 26);
            this.txtAcrescimo.TabIndex = 4;
            this.txtAcrescimo.Text = "0,00";
            this.txtAcrescimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAcrescimo.TextChanged += new System.EventHandler(this.txtAcrescimo_TextChanged);
            this.txtAcrescimo.Enter += new System.EventHandler(this.txtAcrescimo_Enter);
            this.txtAcrescimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcrescimo_KeyPress);
            this.txtAcrescimo.Leave += new System.EventHandler(this.txtAcrescimo_Leave);
            // 
            // txtAcrescimoPorc
            // 
            this.txtAcrescimoPorc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcrescimoPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcrescimoPorc.Location = new System.Drawing.Point(529, 27);
            this.txtAcrescimoPorc.MaxLength = 6;
            this.txtAcrescimoPorc.Name = "txtAcrescimoPorc";
            this.txtAcrescimoPorc.Size = new System.Drawing.Size(100, 26);
            this.txtAcrescimoPorc.TabIndex = 3;
            this.txtAcrescimoPorc.Text = "0,00";
            this.txtAcrescimoPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAcrescimoPorc.TextChanged += new System.EventHandler(this.txtAcrescimoPorc_TextChanged);
            this.txtAcrescimoPorc.Enter += new System.EventHandler(this.txtAcrescimoPorc_Enter);
            this.txtAcrescimoPorc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcrescimoPorc_KeyPress);
            this.txtAcrescimoPorc.Leave += new System.EventHandler(this.txtAcrescimoPorc_Leave);
            // 
            // lblAcrescimo
            // 
            this.lblAcrescimo.AutoSize = true;
            this.lblAcrescimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcrescimo.Location = new System.Drawing.Point(525, 4);
            this.lblAcrescimo.Name = "lblAcrescimo";
            this.lblAcrescimo.Size = new System.Drawing.Size(95, 20);
            this.lblAcrescimo.TabIndex = 0;
            this.lblAcrescimo.Text = "Acréscimos:";
            // 
            // cbbForma1
            // 
            this.cbbForma1.BackColor = System.Drawing.Color.LightBlue;
            this.cbbForma1.DropDownHeight = 200;
            this.cbbForma1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbForma1.DropDownWidth = 720;
            this.cbbForma1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.cbbForma1.FormattingEnabled = true;
            this.cbbForma1.IntegralHeight = false;
            this.cbbForma1.Location = new System.Drawing.Point(100, 70);
            this.cbbForma1.Name = "cbbForma1";
            this.cbbForma1.Size = new System.Drawing.Size(459, 45);
            this.cbbForma1.TabIndex = 7;
            this.cbbForma1.DropDown += new System.EventHandler(this.cbbForma1_DropDown);
            this.cbbForma1.SelectedIndexChanged += new System.EventHandler(this.cbbForma1_SelectedIndexChanged);
            this.cbbForma1.DropDownClosed += new System.EventHandler(this.cbbForma1_DropDownClosed);
            this.cbbForma1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbForma1_KeyPress);
            this.cbbForma1.Leave += new System.EventHandler(this.cbbForma1_Leave);
            this.cbbForma1.MouseLeave += new System.EventHandler(this.cbbForma1_MouseLeave);
            this.cbbForma1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbForma1_MouseMove);
            // 
            // cbbForma2
            // 
            this.cbbForma2.BackColor = System.Drawing.Color.LightBlue;
            this.cbbForma2.DropDownHeight = 200;
            this.cbbForma2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbForma2.DropDownWidth = 520;
            this.cbbForma2.Enabled = false;
            this.cbbForma2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.cbbForma2.FormattingEnabled = true;
            this.cbbForma2.IntegralHeight = false;
            this.cbbForma2.Location = new System.Drawing.Point(100, 121);
            this.cbbForma2.Name = "cbbForma2";
            this.cbbForma2.Size = new System.Drawing.Size(459, 45);
            this.cbbForma2.TabIndex = 12;
            this.cbbForma2.DropDown += new System.EventHandler(this.cbbForma2_DropDown);
            this.cbbForma2.DropDownClosed += new System.EventHandler(this.cbbForma2_DropDownClosed);
            this.cbbForma2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbForma2_KeyPress);
            this.cbbForma2.Leave += new System.EventHandler(this.cbbForma2_Leave);
            this.cbbForma2.MouseLeave += new System.EventHandler(this.cbbForma2_MouseLeave);
            this.cbbForma2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbForma2_MouseMove);
            // 
            // cbbForma3
            // 
            this.cbbForma3.BackColor = System.Drawing.Color.LightBlue;
            this.cbbForma3.DropDownHeight = 200;
            this.cbbForma3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbForma3.DropDownWidth = 520;
            this.cbbForma3.Enabled = false;
            this.cbbForma3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.cbbForma3.FormattingEnabled = true;
            this.cbbForma3.IntegralHeight = false;
            this.cbbForma3.Location = new System.Drawing.Point(100, 172);
            this.cbbForma3.Name = "cbbForma3";
            this.cbbForma3.Size = new System.Drawing.Size(459, 45);
            this.cbbForma3.TabIndex = 17;
            this.cbbForma3.DropDown += new System.EventHandler(this.cbbForma3_DropDown);
            this.cbbForma3.DropDownClosed += new System.EventHandler(this.cbbForma3_DropDownClosed);
            this.cbbForma3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbForma3_KeyPress);
            this.cbbForma3.Leave += new System.EventHandler(this.cbbForma3_Leave);
            this.cbbForma3.MouseLeave += new System.EventHandler(this.cbbForma3_MouseLeave);
            this.cbbForma3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbForma3_MouseMove);
            // 
            // cbbForma4
            // 
            this.cbbForma4.BackColor = System.Drawing.Color.LightBlue;
            this.cbbForma4.DropDownHeight = 200;
            this.cbbForma4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbForma4.DropDownWidth = 520;
            this.cbbForma4.Enabled = false;
            this.cbbForma4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.cbbForma4.FormattingEnabled = true;
            this.cbbForma4.IntegralHeight = false;
            this.cbbForma4.Location = new System.Drawing.Point(100, 223);
            this.cbbForma4.Name = "cbbForma4";
            this.cbbForma4.Size = new System.Drawing.Size(459, 45);
            this.cbbForma4.TabIndex = 22;
            this.cbbForma4.DropDown += new System.EventHandler(this.cbbForma4_DropDown);
            this.cbbForma4.DropDownClosed += new System.EventHandler(this.cbbForma4_DropDownClosed);
            this.cbbForma4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbForma4_KeyPress);
            this.cbbForma4.Leave += new System.EventHandler(this.cbbForma4_Leave);
            this.cbbForma4.MouseLeave += new System.EventHandler(this.cbbForma4_MouseLeave);
            this.cbbForma4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbForma4_MouseMove);
            // 
            // txtValor1
            // 
            this.txtValor1.BackColor = System.Drawing.Color.White;
            this.txtValor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.txtValor1.Location = new System.Drawing.Point(621, 70);
            this.txtValor1.MaxLength = 18;
            this.txtValor1.Name = "txtValor1";
            this.txtValor1.Size = new System.Drawing.Size(178, 44);
            this.txtValor1.TabIndex = 9;
            this.txtValor1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor1.TextChanged += new System.EventHandler(this.txtValor1_TextChanged);
            this.txtValor1.Enter += new System.EventHandler(this.txtValor1_Enter);
            this.txtValor1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor1_KeyPress);
            this.txtValor1.Leave += new System.EventHandler(this.txtValor1_Leave);
            // 
            // txtCodigo1
            // 
            this.txtCodigo1.BackColor = System.Drawing.Color.White;
            this.txtCodigo1.Enabled = false;
            this.txtCodigo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.txtCodigo1.Location = new System.Drawing.Point(33, 122);
            this.txtCodigo1.MaxLength = 5;
            this.txtCodigo1.Name = "txtCodigo1";
            this.txtCodigo1.Size = new System.Drawing.Size(61, 44);
            this.txtCodigo1.TabIndex = 11;
            this.txtCodigo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo1.Enter += new System.EventHandler(this.txtDescricao2_Enter);
            this.txtCodigo1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao2_KeyPress);
            this.txtCodigo1.Leave += new System.EventHandler(this.txtDescricao2_Leave);
            // 
            // txtCodigo2
            // 
            this.txtCodigo2.BackColor = System.Drawing.Color.White;
            this.txtCodigo2.Enabled = false;
            this.txtCodigo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.txtCodigo2.Location = new System.Drawing.Point(33, 173);
            this.txtCodigo2.MaxLength = 5;
            this.txtCodigo2.Name = "txtCodigo2";
            this.txtCodigo2.Size = new System.Drawing.Size(61, 44);
            this.txtCodigo2.TabIndex = 16;
            this.txtCodigo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo2.Enter += new System.EventHandler(this.txtDescricao3_Enter);
            this.txtCodigo2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao3_KeyPress);
            this.txtCodigo2.Leave += new System.EventHandler(this.txtDescricao3_Leave);
            // 
            // txtCodigo3
            // 
            this.txtCodigo3.BackColor = System.Drawing.Color.White;
            this.txtCodigo3.Enabled = false;
            this.txtCodigo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.txtCodigo3.Location = new System.Drawing.Point(33, 224);
            this.txtCodigo3.MaxLength = 5;
            this.txtCodigo3.Name = "txtCodigo3";
            this.txtCodigo3.Size = new System.Drawing.Size(61, 44);
            this.txtCodigo3.TabIndex = 21;
            this.txtCodigo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo3.Enter += new System.EventHandler(this.txtDescricao4_Enter);
            this.txtCodigo3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao4_KeyPress);
            this.txtCodigo3.Leave += new System.EventHandler(this.txtDescricao4_Leave);
            // 
            // txtValor2
            // 
            this.txtValor2.BackColor = System.Drawing.Color.White;
            this.txtValor2.Enabled = false;
            this.txtValor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.txtValor2.Location = new System.Drawing.Point(621, 122);
            this.txtValor2.MaxLength = 18;
            this.txtValor2.Name = "txtValor2";
            this.txtValor2.Size = new System.Drawing.Size(178, 44);
            this.txtValor2.TabIndex = 14;
            this.txtValor2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor2.TextChanged += new System.EventHandler(this.txtValor2_TextChanged);
            this.txtValor2.Enter += new System.EventHandler(this.txtValor2_Enter);
            this.txtValor2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor2_KeyPress);
            this.txtValor2.Leave += new System.EventHandler(this.txtValor2_Leave);
            // 
            // txtValor3
            // 
            this.txtValor3.BackColor = System.Drawing.Color.White;
            this.txtValor3.Enabled = false;
            this.txtValor3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.txtValor3.Location = new System.Drawing.Point(621, 172);
            this.txtValor3.MaxLength = 19;
            this.txtValor3.Name = "txtValor3";
            this.txtValor3.Size = new System.Drawing.Size(178, 44);
            this.txtValor3.TabIndex = 19;
            this.txtValor3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor3.TextChanged += new System.EventHandler(this.txtValor3_TextChanged);
            this.txtValor3.Enter += new System.EventHandler(this.txtValor3_Enter);
            this.txtValor3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor3_KeyPress);
            this.txtValor3.Leave += new System.EventHandler(this.txtValor3_Leave);
            // 
            // txtValor4
            // 
            this.txtValor4.BackColor = System.Drawing.Color.White;
            this.txtValor4.Enabled = false;
            this.txtValor4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.txtValor4.Location = new System.Drawing.Point(622, 222);
            this.txtValor4.MaxLength = 18;
            this.txtValor4.Name = "txtValor4";
            this.txtValor4.Size = new System.Drawing.Size(178, 44);
            this.txtValor4.TabIndex = 24;
            this.txtValor4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor4.TextChanged += new System.EventHandler(this.txtValor4_TextChanged);
            this.txtValor4.Enter += new System.EventHandler(this.txtValor4_Enter);
            this.txtValor4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor4_KeyPress);
            this.txtValor4.Leave += new System.EventHandler(this.txtValor4_Leave);
            // 
            // btnProcurar1
            // 
            this.btnProcurar1.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurar1.Image")));
            this.btnProcurar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnProcurar1.Location = new System.Drawing.Point(565, 70);
            this.btnProcurar1.Name = "btnProcurar1";
            this.btnProcurar1.Size = new System.Drawing.Size(50, 45);
            this.btnProcurar1.TabIndex = 0;
            this.btnProcurar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpForma.SetToolTip(this.btnProcurar1, "Clique para pesquisar a 1ª Forma de Pagamento.");
            this.btnProcurar1.UseVisualStyleBackColor = true;
            this.btnProcurar1.Click += new System.EventHandler(this.btnProcurar1_Click);
            this.btnProcurar1.MouseLeave += new System.EventHandler(this.btnProcurar1_MouseLeave);
            this.btnProcurar1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurar1_MouseMove);
            // 
            // btnProcurar2
            // 
            this.btnProcurar2.Enabled = false;
            this.btnProcurar2.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurar2.Image")));
            this.btnProcurar2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnProcurar2.Location = new System.Drawing.Point(565, 122);
            this.btnProcurar2.Name = "btnProcurar2";
            this.btnProcurar2.Size = new System.Drawing.Size(50, 45);
            this.btnProcurar2.TabIndex = 0;
            this.btnProcurar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpForma.SetToolTip(this.btnProcurar2, "Clique para pesquisar a 2ª Forma de Pagamento.");
            this.btnProcurar2.UseVisualStyleBackColor = true;
            this.btnProcurar2.Click += new System.EventHandler(this.btnProcurar2_Click);
            this.btnProcurar2.MouseLeave += new System.EventHandler(this.btnProcurar2_MouseLeave);
            this.btnProcurar2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurar2_MouseMove);
            // 
            // btnProcurar3
            // 
            this.btnProcurar3.Enabled = false;
            this.btnProcurar3.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurar3.Image")));
            this.btnProcurar3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnProcurar3.Location = new System.Drawing.Point(565, 173);
            this.btnProcurar3.Name = "btnProcurar3";
            this.btnProcurar3.Size = new System.Drawing.Size(50, 45);
            this.btnProcurar3.TabIndex = 0;
            this.btnProcurar3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpForma.SetToolTip(this.btnProcurar3, "Clique para pesquisar a 3ª Forma de Pagamento.");
            this.btnProcurar3.UseVisualStyleBackColor = true;
            this.btnProcurar3.Click += new System.EventHandler(this.btnProcurar3_Click);
            this.btnProcurar3.MouseLeave += new System.EventHandler(this.btnProcurar3_MouseLeave);
            this.btnProcurar3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurar3_MouseMove);
            // 
            // btnProcurar4
            // 
            this.btnProcurar4.Enabled = false;
            this.btnProcurar4.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurar4.Image")));
            this.btnProcurar4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnProcurar4.Location = new System.Drawing.Point(565, 223);
            this.btnProcurar4.Name = "btnProcurar4";
            this.btnProcurar4.Size = new System.Drawing.Size(50, 45);
            this.btnProcurar4.TabIndex = 0;
            this.btnProcurar4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpForma.SetToolTip(this.btnProcurar4, "Clique para pesquisar a 4ª Forma de Pagamento.");
            this.btnProcurar4.UseVisualStyleBackColor = true;
            this.btnProcurar4.Click += new System.EventHandler(this.btnProcurar4_Click);
            this.btnProcurar4.MouseLeave += new System.EventHandler(this.btnProcurar4_MouseLeave);
            this.btnProcurar4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurar4_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnObservacao);
            this.grbBox1.Controls.Add(this.txtCodigo);
            this.grbBox1.Controls.Add(this.btnNovaNotaPromissoria);
            this.grbBox1.Controls.Add(this.label5);
            this.grbBox1.Controls.Add(this.lblAsterisco3);
            this.grbBox1.Controls.Add(this.lblAsterisco2);
            this.grbBox1.Controls.Add(this.lbl4);
            this.grbBox1.Controls.Add(this.lbl3);
            this.grbBox1.Controls.Add(this.lbl2);
            this.grbBox1.Controls.Add(this.lbl1);
            this.grbBox1.Controls.Add(this.lblValorPago);
            this.grbBox1.Controls.Add(this.lblFormaDePagamento);
            this.grbBox1.Controls.Add(this.lblCodigo);
            this.grbBox1.Controls.Add(this.btnRemover1);
            this.grbBox1.Controls.Add(this.btnRemover4);
            this.grbBox1.Controls.Add(this.btnRemover3);
            this.grbBox1.Controls.Add(this.btnRemover2);
            this.grbBox1.Controls.Add(this.btnProcurar1);
            this.grbBox1.Controls.Add(this.btnProcurar4);
            this.grbBox1.Controls.Add(this.cbbForma1);
            this.grbBox1.Controls.Add(this.btnProcurar3);
            this.grbBox1.Controls.Add(this.cbbForma2);
            this.grbBox1.Controls.Add(this.btnProcurar2);
            this.grbBox1.Controls.Add(this.cbbForma3);
            this.grbBox1.Controls.Add(this.cbbForma4);
            this.grbBox1.Controls.Add(this.txtValor4);
            this.grbBox1.Controls.Add(this.txtValor3);
            this.grbBox1.Controls.Add(this.txtValor1);
            this.grbBox1.Controls.Add(this.txtValor2);
            this.grbBox1.Controls.Add(this.txtCodigo1);
            this.grbBox1.Controls.Add(this.txtCodigo3);
            this.grbBox1.Controls.Add(this.txtCodigo2);
            this.grbBox1.Location = new System.Drawing.Point(12, 59);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(860, 280);
            this.grbBox1.TabIndex = 5;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Formas de Pagamento:";
            // 
            // btnObservacao
            // 
            this.btnObservacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnObservacao.Image = ((System.Drawing.Image)(resources.GetObject("btnObservacao.Image")));
            this.btnObservacao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnObservacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnObservacao.Location = new System.Drawing.Point(255, 19);
            this.btnObservacao.Name = "btnObservacao";
            this.btnObservacao.Size = new System.Drawing.Size(100, 25);
            this.btnObservacao.TabIndex = 29;
            this.btnObservacao.Text = "&Observações";
            this.btnObservacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpForma.SetToolTip(this.btnObservacao, "Adicionar observação na venda atual.");
            this.btnObservacao.UseVisualStyleBackColor = true;
            this.btnObservacao.Click += new System.EventHandler(this.btnObservacao_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.txtCodigo.Location = new System.Drawing.Point(33, 70);
            this.txtCodigo.MaxLength = 5;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(61, 44);
            this.txtCodigo.TabIndex = 6;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.Enter += new System.EventHandler(this.txtDescricao1_Enter);
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao1_KeyPress);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // btnNovaNotaPromissoria
            // 
            this.btnNovaNotaPromissoria.Image = ((System.Drawing.Image)(resources.GetObject("btnNovaNotaPromissoria.Image")));
            this.btnNovaNotaPromissoria.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovaNotaPromissoria.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNovaNotaPromissoria.Location = new System.Drawing.Point(6, 19);
            this.btnNovaNotaPromissoria.Name = "btnNovaNotaPromissoria";
            this.btnNovaNotaPromissoria.Size = new System.Drawing.Size(243, 25);
            this.btnNovaNotaPromissoria.TabIndex = 28;
            this.btnNovaNotaPromissoria.Text = "Criar &Nota Promissória Definida Pelo Usuário";
            this.btnNovaNotaPromissoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpForma.SetToolTip(this.btnNovaNotaPromissoria, "Criar Forma de Pagamento rápida de Nota Promissória.");
            this.btnNovaNotaPromissoria.UseVisualStyleBackColor = true;
            this.btnNovaNotaPromissoria.Click += new System.EventHandler(this.btnNovaNotaPromissoria_Click);
            this.btnNovaNotaPromissoria.MouseLeave += new System.EventHandler(this.btnNovaNotaPromissoria_MouseLeave);
            this.btnNovaNotaPromissoria.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovaNotaPromissoria_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(20, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "*";
            // 
            // lblAsterisco3
            // 
            this.lblAsterisco3.AutoSize = true;
            this.lblAsterisco3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco3.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco3.Location = new System.Drawing.Point(736, 44);
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
            this.lblAsterisco2.Location = new System.Drawing.Point(255, 46);
            this.lblAsterisco2.Name = "lblAsterisco2";
            this.lblAsterisco2.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco2.TabIndex = 0;
            this.lblAsterisco2.Text = "*";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Enabled = false;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(3, 234);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(25, 24);
            this.lbl4.TabIndex = 0;
            this.lbl4.Text = "4:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Enabled = false;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(3, 183);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(25, 24);
            this.lbl3.TabIndex = 0;
            this.lbl3.Text = "3:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Enabled = false;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(3, 132);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(25, 24);
            this.lbl2.TabIndex = 0;
            this.lbl2.Text = "2:";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(3, 80);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(25, 24);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "1:";
            // 
            // lblValorPago
            // 
            this.lblValorPago.AutoSize = true;
            this.lblValorPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorPago.Location = new System.Drawing.Point(617, 46);
            this.lblValorPago.Name = "lblValorPago";
            this.lblValorPago.Size = new System.Drawing.Size(126, 20);
            this.lblValorPago.TabIndex = 0;
            this.lblValorPago.Text = "Valor Pago (R$):";
            // 
            // lblFormaDePagamento
            // 
            this.lblFormaDePagamento.AutoSize = true;
            this.lblFormaDePagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormaDePagamento.Location = new System.Drawing.Point(95, 47);
            this.lblFormaDePagamento.Name = "lblFormaDePagamento";
            this.lblFormaDePagamento.Size = new System.Drawing.Size(167, 20);
            this.lblFormaDePagamento.TabIndex = 0;
            this.lblFormaDePagamento.Text = "Forma de Pagamento:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(23, 47);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(63, 20);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // btnRemover1
            // 
            this.btnRemover1.Image = ((System.Drawing.Image)(resources.GetObject("btnRemover1.Image")));
            this.btnRemover1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemover1.Location = new System.Drawing.Point(805, 69);
            this.btnRemover1.Name = "btnRemover1";
            this.btnRemover1.Size = new System.Drawing.Size(50, 45);
            this.btnRemover1.TabIndex = 10;
            this.btnRemover1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpForma.SetToolTip(this.btnRemover1, "Limpar 1ª Forma de Pagamento.");
            this.btnRemover1.UseVisualStyleBackColor = true;
            this.btnRemover1.Click += new System.EventHandler(this.btnRemover1_Click);
            this.btnRemover1.MouseLeave += new System.EventHandler(this.btnRemover1_MouseLeave);
            this.btnRemover1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRemover1_MouseMove);
            // 
            // btnRemover4
            // 
            this.btnRemover4.Enabled = false;
            this.btnRemover4.Image = ((System.Drawing.Image)(resources.GetObject("btnRemover4.Image")));
            this.btnRemover4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemover4.Location = new System.Drawing.Point(805, 221);
            this.btnRemover4.Name = "btnRemover4";
            this.btnRemover4.Size = new System.Drawing.Size(50, 45);
            this.btnRemover4.TabIndex = 25;
            this.btnRemover4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpForma.SetToolTip(this.btnRemover4, "Limpar 4ª Forma de Pagamento.");
            this.btnRemover4.UseVisualStyleBackColor = true;
            this.btnRemover4.Click += new System.EventHandler(this.btnRemover4_Click);
            this.btnRemover4.MouseLeave += new System.EventHandler(this.btnRemover4_MouseLeave);
            this.btnRemover4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRemover4_MouseMove);
            // 
            // btnRemover3
            // 
            this.btnRemover3.Enabled = false;
            this.btnRemover3.Image = ((System.Drawing.Image)(resources.GetObject("btnRemover3.Image")));
            this.btnRemover3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemover3.Location = new System.Drawing.Point(805, 171);
            this.btnRemover3.Name = "btnRemover3";
            this.btnRemover3.Size = new System.Drawing.Size(50, 45);
            this.btnRemover3.TabIndex = 20;
            this.btnRemover3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpForma.SetToolTip(this.btnRemover3, "Limpar 3ª Forma de Pagamento.");
            this.btnRemover3.UseVisualStyleBackColor = true;
            this.btnRemover3.Click += new System.EventHandler(this.btnRemover3_Click);
            this.btnRemover3.MouseLeave += new System.EventHandler(this.btnRemover3_MouseLeave);
            this.btnRemover3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRemover3_MouseMove);
            // 
            // btnRemover2
            // 
            this.btnRemover2.Enabled = false;
            this.btnRemover2.Image = ((System.Drawing.Image)(resources.GetObject("btnRemover2.Image")));
            this.btnRemover2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemover2.Location = new System.Drawing.Point(805, 121);
            this.btnRemover2.Name = "btnRemover2";
            this.btnRemover2.Size = new System.Drawing.Size(50, 45);
            this.btnRemover2.TabIndex = 15;
            this.btnRemover2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpForma.SetToolTip(this.btnRemover2, "Limpar 2ª Forma de Pagamento.");
            this.btnRemover2.UseVisualStyleBackColor = true;
            this.btnRemover2.Click += new System.EventHandler(this.btnRemover2_Click);
            this.btnRemover2.MouseLeave += new System.EventHandler(this.btnRemover2_MouseLeave);
            this.btnRemover2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRemover2_MouseMove);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblValorTotal.Location = new System.Drawing.Point(314, 341);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(260, 31);
            this.lblValorTotal.TabIndex = 0;
            this.lblValorTotal.Text = "Total a pagar (R$):";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalvar.Location = new System.Drawing.Point(733, 418);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(80, 32);
            this.btnSalvar.TabIndex = 26;
            this.btnSalvar.Text = " &Finalizar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpForma.SetToolTip(this.btnSalvar, "Salvar dados informados e finalizar a Venda.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(220, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Descontos (R$):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(732, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Acréscimos (R$):";
            // 
            // lblValorPagar
            // 
            this.lblValorPagar.BackColor = System.Drawing.Color.White;
            this.lblValorPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValorPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblValorPagar.Location = new System.Drawing.Point(320, 373);
            this.lblValorPagar.Name = "lblValorPagar";
            this.lblValorPagar.Size = new System.Drawing.Size(231, 42);
            this.lblValorPagar.TabIndex = 0;
            this.lblValorPagar.Text = "0,00";
            this.lblValorPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorPagar.Click += new System.EventHandler(this.lblValorPagar_Click);
            this.lblValorPagar.MouseLeave += new System.EventHandler(this.lblValorPagar_MouseLeave);
            this.lblValorPagar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorPagar_MouseMove);
            // 
            // ttpForma
            // 
            this.ttpForma.AutoPopDelay = 5000;
            this.ttpForma.InitialDelay = 1000;
            this.ttpForma.IsBalloon = true;
            this.ttpForma.ReshowDelay = 100;
            this.ttpForma.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpForma.ToolTipTitle = "Dica:";
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(819, 418);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 27;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpForma.SetToolTip(this.btnSair, "Sair de Formas de Pagamento");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave_1);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove_1);
            // 
            // btnInformações
            // 
            this.btnInformações.Image = ((System.Drawing.Image)(resources.GetObject("btnInformações.Image")));
            this.btnInformações.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnInformações.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnInformações.Location = new System.Drawing.Point(557, 378);
            this.btnInformações.Name = "btnInformações";
            this.btnInformações.Size = new System.Drawing.Size(33, 32);
            this.btnInformações.TabIndex = 76;
            this.btnInformações.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpForma.SetToolTip(this.btnInformações, "Clique para pesquisar a 1ª Forma de Pagamento.");
            this.btnInformações.UseVisualStyleBackColor = true;
            this.btnInformações.Click += new System.EventHandler(this.button1_Click);
            this.btnInformações.MouseLeave += new System.EventHandler(this.btnInformações_MouseLeave);
            this.btnInformações.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnInformações_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(707, 418);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 75;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // lblTotalSub
            // 
            this.lblTotalSub.BackColor = System.Drawing.Color.White;
            this.lblTotalSub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSub.Location = new System.Drawing.Point(10, 373);
            this.lblTotalSub.Name = "lblTotalSub";
            this.lblTotalSub.Size = new System.Drawing.Size(231, 42);
            this.lblTotalSub.TabIndex = 0;
            this.lblTotalSub.Text = "0,00";
            this.lblTotalSub.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalSub.Click += new System.EventHandler(this.lblTotal1_Click);
            this.lblTotalSub.MouseLeave += new System.EventHandler(this.lblTotalSub_MouseLeave);
            this.lblTotalSub.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTotalSub_MouseMove);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(6, 341);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(154, 31);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total (R$):";
            // 
            // lblDifTroco
            // 
            this.lblDifTroco.BackColor = System.Drawing.Color.White;
            this.lblDifTroco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDifTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblDifTroco.ForeColor = System.Drawing.Color.Red;
            this.lblDifTroco.Location = new System.Drawing.Point(641, 373);
            this.lblDifTroco.Name = "lblDifTroco";
            this.lblDifTroco.Size = new System.Drawing.Size(231, 42);
            this.lblDifTroco.TabIndex = 0;
            this.lblDifTroco.Text = "-0,00";
            this.lblDifTroco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDifTroco.Click += new System.EventHandler(this.lblDifTroco_Click);
            this.lblDifTroco.MouseLeave += new System.EventHandler(this.lblDifTroco_MouseLeave);
            this.lblDifTroco.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblDifTroco_MouseMove);
            // 
            // lblDT
            // 
            this.lblDT.AutoSize = true;
            this.lblDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblDT.ForeColor = System.Drawing.Color.Red;
            this.lblDT.Location = new System.Drawing.Point(635, 341);
            this.lblDT.Name = "lblDT";
            this.lblDT.Size = new System.Drawing.Size(214, 31);
            this.lblDT.TabIndex = 0;
            this.lblDT.Text = "Diferença (R$):";
            // 
            // FrmFormaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(884, 458);
            this.ControlBox = false;
            this.Controls.Add(this.btnInformações);
            this.Controls.Add(this.lblDifTroco);
            this.Controls.Add(this.lblDT);
            this.Controls.Add(this.txtAcrescimo);
            this.Controls.Add(this.txtDesconto);
            this.Controls.Add(this.lblTotalSub);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.picbInterrogacao1);
            this.Controls.Add(this.lblValorPagar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAcrescimoPorc);
            this.Controls.Add(this.lblAcrescimo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescontoPorc);
            this.Controls.Add(this.lblDesconto);
            this.Controls.Add(this.btnSair);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFormaPagamento";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formas de Pagamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFormaPagamento_FormClosing);
            this.Load += new System.EventHandler(this.FrmFormaPagamento_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmFormaPagamento_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.TextBox txtDescontoPorc;
        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAcrescimo;
        private System.Windows.Forms.TextBox txtAcrescimoPorc;
        private System.Windows.Forms.Label lblAcrescimo;
        private System.Windows.Forms.ComboBox cbbForma1;
        private System.Windows.Forms.ComboBox cbbForma2;
        private System.Windows.Forms.ComboBox cbbForma3;
        private System.Windows.Forms.ComboBox cbbForma4;
        private System.Windows.Forms.TextBox txtValor1;
        private System.Windows.Forms.TextBox txtCodigo1;
        private System.Windows.Forms.TextBox txtCodigo2;
        private System.Windows.Forms.TextBox txtCodigo3;
        private System.Windows.Forms.TextBox txtValor2;
        private System.Windows.Forms.TextBox txtValor3;
        private System.Windows.Forms.TextBox txtValor4;
        private System.Windows.Forms.Button btnProcurar1;
        private System.Windows.Forms.Button btnProcurar2;
        private System.Windows.Forms.Button btnProcurar3;
        private System.Windows.Forms.Button btnProcurar4;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblValorPagar;
        private System.Windows.Forms.Button btnRemover1;
        private System.Windows.Forms.Button btnRemover4;
        private System.Windows.Forms.Button btnRemover3;
        private System.Windows.Forms.Button btnRemover2;
        private System.Windows.Forms.Label lblValorPago;
        private System.Windows.Forms.Label lblFormaDePagamento;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.ToolTip ttpForma;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblTotalSub;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblAsterisco3;
        private System.Windows.Forms.Label lblAsterisco2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDifTroco;
        private System.Windows.Forms.Label lblDT;
        private System.Windows.Forms.Button btnInformações;
        private System.Windows.Forms.Button btnNovaNotaPromissoria;
        private System.Windows.Forms.Button btnObservacao;
    }
}