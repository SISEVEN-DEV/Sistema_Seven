namespace Seven_Sistema
{
    partial class FrmCadOrcamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadOrcamento));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.cbbCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.rbtnServicos = new System.Windows.Forms.GroupBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rbtnProdutos = new System.Windows.Forms.RadioButton();
            this.lblValorTotalReal = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblTotalReal = new System.Windows.Forms.Label();
            this.grbBox3 = new System.Windows.Forms.GroupBox();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnPesquisarProduto = new System.Windows.Forms.Button();
            this.btnIncuir = new System.Windows.Forms.Button();
            this.rbtnBarra = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.txtpBarra = new System.Windows.Forms.TextBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.dtProd = new System.Windows.Forms.DataGridView();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluirItem = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.pcibInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnPesquisarCliente = new System.Windows.Forms.Button();
            this.ttpOrcamento = new System.Windows.Forms.ToolTip(this.components);
            this.btnSelecionarData1 = new System.Windows.Forms.Button();
            this.btnCapturar = new System.Windows.Forms.Button();
            this.btnGerar = new System.Windows.Forms.Button();
            this.btnEnviarZap = new System.Windows.Forms.Button();
            this.btnEnviarEmail = new System.Windows.Forms.Button();
            this.mtxtValidade = new System.Windows.Forms.MaskedTextBox();
            this.lblValidade = new System.Windows.Forms.Label();
            this.lblQtdeCar = new System.Windows.Forms.Label();
            this.rtxtObs = new System.Windows.Forms.TextBox();
            this.mtxtHorario = new System.Windows.Forms.MaskedTextBox();
            this.pEnabled = new System.Windows.Forms.Panel();
            this.lblAsterisco = new System.Windows.Forms.Label();
            this.rbtnServicos.SuspendLayout();
            this.grbBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao2)).BeginInit();
            this.pEnabled.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCodigo.Location = new System.Drawing.Point(38, 67);
            this.txtCodigo.MaxLength = 8;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.ForeColor = System.Drawing.Color.Blue;
            this.lblCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCodigo.Location = new System.Drawing.Point(35, 51);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // cbbCliente
            // 
            this.cbbCliente.BackColor = System.Drawing.Color.LightBlue;
            this.cbbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCliente.DropDownWidth = 725;
            this.cbbCliente.Enabled = false;
            this.cbbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCliente.FormattingEnabled = true;
            this.cbbCliente.Location = new System.Drawing.Point(124, 66);
            this.cbbCliente.Name = "cbbCliente";
            this.cbbCliente.Size = new System.Drawing.Size(525, 21);
            this.cbbCliente.TabIndex = 2;
            this.cbbCliente.DropDown += new System.EventHandler(this.cbbCliente_DropDown);
            this.cbbCliente.SelectedIndexChanged += new System.EventHandler(this.cbbCliente_SelectedIndexChanged);
            this.cbbCliente.DropDownClosed += new System.EventHandler(this.cbbCliente_DropDownClosed);
            this.cbbCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbCliente_KeyPress);
            this.cbbCliente.Leave += new System.EventHandler(this.cbbCliente_Leave);
            this.cbbCliente.MouseLeave += new System.EventHandler(this.cbbCliente_MouseLeave);
            this.cbbCliente.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbCliente_MouseMove);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Enabled = false;
            this.lblCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCliente.Location = new System.Drawing.Point(121, 51);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(65, 13);
            this.lblCliente.TabIndex = 0;
            this.lblCliente.Text = "Consumidor:";
            // 
            // lblObservacao
            // 
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Enabled = false;
            this.lblObservacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblObservacao.Location = new System.Drawing.Point(35, 90);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(73, 13);
            this.lblObservacao.TabIndex = 0;
            this.lblObservacao.Tag = "";
            this.lblObservacao.Text = "Observações:";
            // 
            // rbtnServicos
            // 
            this.rbtnServicos.Controls.Add(this.lblItem);
            this.rbtnServicos.Controls.Add(this.radioButton2);
            this.rbtnServicos.Controls.Add(this.rbtnProdutos);
            this.rbtnServicos.Controls.Add(this.lblValorTotalReal);
            this.rbtnServicos.Controls.Add(this.lblValorTotal);
            this.rbtnServicos.Controls.Add(this.lblTotalReal);
            this.rbtnServicos.Controls.Add(this.grbBox3);
            this.rbtnServicos.Controls.Add(this.lblRegistros);
            this.rbtnServicos.Controls.Add(this.lblValor);
            this.rbtnServicos.Controls.Add(this.dtProd);
            this.rbtnServicos.Enabled = false;
            this.rbtnServicos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnServicos.Location = new System.Drawing.Point(38, 157);
            this.rbtnServicos.Name = "rbtnServicos";
            this.rbtnServicos.Size = new System.Drawing.Size(822, 371);
            this.rbtnServicos.TabIndex = 7;
            this.rbtnServicos.TabStop = false;
            this.rbtnServicos.Text = "Itens do Orçamento:";
            // 
            // lblItem
            // 
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(6, 129);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(810, 16);
            this.lblItem.TabIndex = 0;
            this.lblItem.Text = "Itens:";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton2.Location = new System.Drawing.Point(413, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(66, 17);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Serviços";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbtnProdutos
            // 
            this.rbtnProdutos.AutoSize = true;
            this.rbtnProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnProdutos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnProdutos.Location = new System.Drawing.Point(340, 19);
            this.rbtnProdutos.Name = "rbtnProdutos";
            this.rbtnProdutos.Size = new System.Drawing.Size(67, 17);
            this.rbtnProdutos.TabIndex = 8;
            this.rbtnProdutos.TabStop = true;
            this.rbtnProdutos.Text = "Produtos";
            this.rbtnProdutos.UseVisualStyleBackColor = true;
            this.rbtnProdutos.CheckedChanged += new System.EventHandler(this.rbtnProdutos_CheckedChanged);
            // 
            // lblValorTotalReal
            // 
            this.lblValorTotalReal.BackColor = System.Drawing.Color.White;
            this.lblValorTotalReal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValorTotalReal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalReal.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotalReal.Location = new System.Drawing.Point(666, 342);
            this.lblValorTotalReal.Name = "lblValorTotalReal";
            this.lblValorTotalReal.Size = new System.Drawing.Size(150, 26);
            this.lblValorTotalReal.TabIndex = 0;
            this.lblValorTotalReal.Text = "0,00";
            this.lblValorTotalReal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotalReal.Click += new System.EventHandler(this.label2_Click);
            this.lblValorTotalReal.MouseLeave += new System.EventHandler(this.lblValorTotalReal_MouseLeave);
            this.lblValorTotalReal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotalReal_MouseMove);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.BackColor = System.Drawing.Color.White;
            this.lblValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotal.Location = new System.Drawing.Point(258, 342);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(150, 26);
            this.lblValorTotal.TabIndex = 0;
            this.lblValorTotal.Text = "0,00";
            this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotal.Click += new System.EventHandler(this.lblValorTotal_Click);
            this.lblValorTotal.MouseLeave += new System.EventHandler(this.lblValorTotal_MouseLeave);
            this.lblValorTotal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotal_MouseMove);
            // 
            // lblTotalReal
            // 
            this.lblTotalReal.AutoSize = true;
            this.lblTotalReal.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.lblTotalReal.Location = new System.Drawing.Point(519, 343);
            this.lblTotalReal.Name = "lblTotalReal";
            this.lblTotalReal.Size = new System.Drawing.Size(148, 23);
            this.lblTotalReal.TabIndex = 16;
            this.lblTotalReal.Text = "Total a Pagar (R$):";
            // 
            // grbBox3
            // 
            this.grbBox3.Controls.Add(this.txtpCodigo);
            this.grbBox3.Controls.Add(this.picbInterrogacao2);
            this.grbBox3.Controls.Add(this.btnPesquisarProduto);
            this.grbBox3.Controls.Add(this.btnIncuir);
            this.grbBox3.Controls.Add(this.rbtnBarra);
            this.grbBox3.Controls.Add(this.rbtnCodigo);
            this.grbBox3.Controls.Add(this.lblPesquisar);
            this.grbBox3.Controls.Add(this.txtpBarra);
            this.grbBox3.Location = new System.Drawing.Point(6, 42);
            this.grbBox3.Name = "grbBox3";
            this.grbBox3.Size = new System.Drawing.Size(810, 83);
            this.grbBox3.TabIndex = 10;
            this.grbBox3.TabStop = false;
            this.grbBox3.Text = "Pesquisar por:";
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpCodigo.Location = new System.Drawing.Point(692, 18);
            this.txtpCodigo.MaxLength = 10;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtpCodigo.TabIndex = 14;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtpCodigo_KeyUp);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(708, 44);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 32;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // btnPesquisarProduto
            // 
            this.btnPesquisarProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisarProduto.Image")));
            this.btnPesquisarProduto.Location = new System.Drawing.Point(778, 15);
            this.btnPesquisarProduto.Name = "btnPesquisarProduto";
            this.btnPesquisarProduto.Size = new System.Drawing.Size(26, 25);
            this.btnPesquisarProduto.TabIndex = 15;
            this.btnPesquisarProduto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnPesquisarProduto, "Clique para pesquisar um Produto/Serviço.");
            this.btnPesquisarProduto.UseVisualStyleBackColor = true;
            this.btnPesquisarProduto.Click += new System.EventHandler(this.btnPesquisarProduto_Click);
            this.btnPesquisarProduto.MouseLeave += new System.EventHandler(this.btnPesquisarProduto_MouseLeave);
            this.btnPesquisarProduto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisarProduto_MouseMove);
            // 
            // btnIncuir
            // 
            this.btnIncuir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncuir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncuir.Image")));
            this.btnIncuir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncuir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnIncuir.Location = new System.Drawing.Point(734, 44);
            this.btnIncuir.Name = "btnIncuir";
            this.btnIncuir.Size = new System.Drawing.Size(70, 32);
            this.btnIncuir.TabIndex = 16;
            this.btnIncuir.Text = "&Incluir";
            this.btnIncuir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnIncuir, "Clique para incluir um Produto.");
            this.btnIncuir.UseVisualStyleBackColor = true;
            this.btnIncuir.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnIncuir.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnIncuir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // rbtnBarra
            // 
            this.rbtnBarra.AutoSize = true;
            this.rbtnBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnBarra.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnBarra.Location = new System.Drawing.Point(70, 19);
            this.rbtnBarra.Name = "rbtnBarra";
            this.rbtnBarra.Size = new System.Drawing.Size(106, 17);
            this.rbtnBarra.TabIndex = 12;
            this.rbtnBarra.TabStop = true;
            this.rbtnBarra.Text = "Código de Barras";
            this.rbtnBarra.UseVisualStyleBackColor = true;
            this.rbtnBarra.CheckedChanged += new System.EventHandler(this.rbtnBarra_CheckedChanged);
            this.rbtnBarra.MouseLeave += new System.EventHandler(this.rbtnBarra_MouseLeave);
            this.rbtnBarra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnBarra_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(6, 19);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 11;
            this.rbtnCodigo.TabStop = true;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(589, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(97, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite o código:";
            // 
            // txtpBarra
            // 
            this.txtpBarra.BackColor = System.Drawing.Color.White;
            this.txtpBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpBarra.Location = new System.Drawing.Point(597, 18);
            this.txtpBarra.MaxLength = 60;
            this.txtpBarra.Name = "txtpBarra";
            this.txtpBarra.Size = new System.Drawing.Size(175, 20);
            this.txtpBarra.TabIndex = 13;
            this.txtpBarra.Visible = false;
            this.txtpBarra.Enter += new System.EventHandler(this.txtpBarra_Enter);
            this.txtpBarra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpBarra_KeyPress);
            this.txtpBarra.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtpBarra_KeyUp);
            this.txtpBarra.Leave += new System.EventHandler(this.txtpBarra_Leave);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(3, 342);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.lblValor.Location = new System.Drawing.Point(169, 343);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(87, 23);
            this.lblValor.TabIndex = 0;
            this.lblValor.Text = "Total (R$):";
            // 
            // dtProd
            // 
            this.dtProd.AllowUserToAddRows = false;
            this.dtProd.AllowUserToDeleteRows = false;
            this.dtProd.AllowUserToResizeRows = false;
            this.dtProd.BackgroundColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtProd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtProd.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtProd.Location = new System.Drawing.Point(6, 145);
            this.dtProd.MultiSelect = false;
            this.dtProd.Name = "dtProd";
            this.dtProd.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtProd.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtProd.RowHeadersVisible = false;
            this.dtProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtProd.ShowCellErrors = false;
            this.dtProd.ShowCellToolTips = false;
            this.dtProd.ShowEditingIcon = false;
            this.dtProd.ShowRowErrors = false;
            this.dtProd.Size = new System.Drawing.Size(810, 194);
            this.dtProd.TabIndex = 17;
            this.dtProd.DataSourceChanged += new System.EventHandler(this.dtProd_DataSourceChanged);
            this.dtProd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtProd_CellContentClick);
            this.dtProd.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtProd_CellEnter);
            this.dtProd.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtProd_CellFormatting);
            this.dtProd.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtProd_RowsAdded);
            this.dtProd.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtProd_RowsRemoved);
            this.dtProd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtProd_KeyDown);
            this.dtProd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtProd_KeyPress);
            this.dtProd.MouseLeave += new System.EventHandler(this.dtProd_MouseLeave);
            this.dtProd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtProd_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(811, 534);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 26;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnSair, "Sair do cadastro de Orçamento.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNovo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNovo.Location = new System.Drawing.Point(61, 534);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 32);
            this.btnNovo.TabIndex = 18;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnNovo, "Cadastrar um novo Orçamento.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
            // 
            // btnExcluirItem
            // 
            this.btnExcluirItem.Enabled = false;
            this.btnExcluirItem.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirItem.Image")));
            this.btnExcluirItem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExcluirItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcluirItem.Location = new System.Drawing.Point(225, 534);
            this.btnExcluirItem.Name = "btnExcluirItem";
            this.btnExcluirItem.Size = new System.Drawing.Size(93, 32);
            this.btnExcluirItem.TabIndex = 20;
            this.btnExcluirItem.Text = "&Excluir Item";
            this.btnExcluirItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnExcluirItem, "Excluir o item selecionado.");
            this.btnExcluirItem.UseVisualStyleBackColor = true;
            this.btnExcluirItem.Click += new System.EventHandler(this.btnExcluirItem_Click);
            this.btnExcluirItem.MouseLeave += new System.EventHandler(this.btnExcluirItem_MouseLeave);
            this.btnExcluirItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluirItem_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(301, 492);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancela&r";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnCancelar, "Cancelar Orçamento atual.");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            this.btnCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelar_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalvar.Location = new System.Drawing.Point(415, 534);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(86, 32);
            this.btnSalvar.TabIndex = 22;
            this.btnSalvar.Text = "&Continuar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnSalvar, "Continuar para descontos e acréscimos.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // pcibInterrogacao2
            // 
            this.pcibInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao2.Image")));
            this.pcibInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pcibInterrogacao2.Location = new System.Drawing.Point(35, 534);
            this.pcibInterrogacao2.Name = "pcibInterrogacao2";
            this.pcibInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao2.TabIndex = 51;
            this.pcibInterrogacao2.TabStop = false;
            this.pcibInterrogacao2.Click += new System.EventHandler(this.pcibInterrogacao2_Click);
            this.pcibInterrogacao2.MouseLeave += new System.EventHandler(this.pcibInterrogacao2_MouseLeave);
            this.pcibInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao2_MouseMove);
            // 
            // btnPesquisarCliente
            // 
            this.btnPesquisarCliente.Enabled = false;
            this.btnPesquisarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisarCliente.Image")));
            this.btnPesquisarCliente.Location = new System.Drawing.Point(655, 64);
            this.btnPesquisarCliente.Name = "btnPesquisarCliente";
            this.btnPesquisarCliente.Size = new System.Drawing.Size(26, 25);
            this.btnPesquisarCliente.TabIndex = 3;
            this.btnPesquisarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnPesquisarCliente, "Clique para pesquisar um Consumidor.");
            this.btnPesquisarCliente.UseVisualStyleBackColor = true;
            this.btnPesquisarCliente.Click += new System.EventHandler(this.btnPesquisarCliente_Click);
            this.btnPesquisarCliente.MouseLeave += new System.EventHandler(this.btnPesquisarCliente_MouseLeave);
            this.btnPesquisarCliente.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisarCliente_MouseMove);
            // 
            // ttpOrcamento
            // 
            this.ttpOrcamento.AutoPopDelay = 5000;
            this.ttpOrcamento.InitialDelay = 1000;
            this.ttpOrcamento.IsBalloon = true;
            this.ttpOrcamento.ReshowDelay = 100;
            this.ttpOrcamento.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpOrcamento.ToolTipTitle = "Dica:";
            // 
            // btnSelecionarData1
            // 
            this.btnSelecionarData1.Enabled = false;
            this.btnSelecionarData1.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData1.Image")));
            this.btnSelecionarData1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData1.Location = new System.Drawing.Point(771, 64);
            this.btnSelecionarData1.Name = "btnSelecionarData1";
            this.btnSelecionarData1.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData1.TabIndex = 5;
            this.btnSelecionarData1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnSelecionarData1, "Clique para selecionar uma data.");
            this.btnSelecionarData1.UseVisualStyleBackColor = true;
            this.btnSelecionarData1.Click += new System.EventHandler(this.btnSelecionarData1_Click);
            this.btnSelecionarData1.MouseLeave += new System.EventHandler(this.btnSelecionarData1_MouseLeave);
            this.btnSelecionarData1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData1_MouseMove);
            // 
            // btnCapturar
            // 
            this.btnCapturar.Enabled = false;
            this.btnCapturar.Image = ((System.Drawing.Image)(resources.GetObject("btnCapturar.Image")));
            this.btnCapturar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCapturar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCapturar.Location = new System.Drawing.Point(137, 534);
            this.btnCapturar.Name = "btnCapturar";
            this.btnCapturar.Size = new System.Drawing.Size(82, 32);
            this.btnCapturar.TabIndex = 19;
            this.btnCapturar.Text = "Ca&pturar";
            this.btnCapturar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnCapturar, "Clique para capturar um Orçamento existente.");
            this.btnCapturar.UseVisualStyleBackColor = true;
            this.btnCapturar.Click += new System.EventHandler(this.btnCapturar_Click);
            this.btnCapturar.MouseLeave += new System.EventHandler(this.btnCapturar_MouseLeave);
            this.btnCapturar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCapturar_MouseMove);
            this.btnCapturar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnCapturar_MouseUp);
            // 
            // btnGerar
            // 
            this.btnGerar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGerar.Image")));
            this.btnGerar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnGerar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGerar.Location = new System.Drawing.Point(507, 534);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(90, 32);
            this.btnGerar.TabIndex = 23;
            this.btnGerar.Text = "&Gerar PDF";
            this.btnGerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnGerar, "Clique para gerar em PDF o Orçamento.");
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Visible = false;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // btnEnviarZap
            // 
            this.btnEnviarZap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviarZap.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviarZap.Image")));
            this.btnEnviarZap.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEnviarZap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEnviarZap.Location = new System.Drawing.Point(710, 534);
            this.btnEnviarZap.Name = "btnEnviarZap";
            this.btnEnviarZap.Size = new System.Drawing.Size(95, 32);
            this.btnEnviarZap.TabIndex = 25;
            this.btnEnviarZap.Text = "Enviar &ZAP";
            this.btnEnviarZap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnEnviarZap, "Clique para enviar um whatsapp.");
            this.btnEnviarZap.UseVisualStyleBackColor = true;
            this.btnEnviarZap.Visible = false;
            this.btnEnviarZap.Click += new System.EventHandler(this.btnEnviarZap_Click);
            // 
            // btnEnviarEmail
            // 
            this.btnEnviarEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviarEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviarEmail.Image")));
            this.btnEnviarEmail.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEnviarEmail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEnviarEmail.Location = new System.Drawing.Point(603, 534);
            this.btnEnviarEmail.Name = "btnEnviarEmail";
            this.btnEnviarEmail.Size = new System.Drawing.Size(101, 32);
            this.btnEnviarEmail.TabIndex = 24;
            this.btnEnviarEmail.Text = "Enviar E-&mail";
            this.btnEnviarEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnEnviarEmail, "Clique para enviar um e-mail.");
            this.btnEnviarEmail.UseVisualStyleBackColor = true;
            this.btnEnviarEmail.Visible = false;
            this.btnEnviarEmail.Click += new System.EventHandler(this.btnEnviarEmail_Click);
            // 
            // mtxtValidade
            // 
            this.mtxtValidade.BackColor = System.Drawing.Color.White;
            this.mtxtValidade.Enabled = false;
            this.mtxtValidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtValidade.Location = new System.Drawing.Point(687, 67);
            this.mtxtValidade.Mask = "00/00/0000";
            this.mtxtValidade.Name = "mtxtValidade";
            this.mtxtValidade.Size = new System.Drawing.Size(78, 20);
            this.mtxtValidade.TabIndex = 4;
            this.mtxtValidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtValidade.ValidatingType = typeof(System.DateTime);
            this.mtxtValidade.DoubleClick += new System.EventHandler(this.mtxtValidade_DoubleClick);
            this.mtxtValidade.Enter += new System.EventHandler(this.mtxtValidade_Enter);
            this.mtxtValidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtValidade_KeyPress);
            this.mtxtValidade.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtValidade_KeyUp);
            this.mtxtValidade.Leave += new System.EventHandler(this.mtxtValidade_Leave);
            // 
            // lblValidade
            // 
            this.lblValidade.AutoSize = true;
            this.lblValidade.Enabled = false;
            this.lblValidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblValidade.Location = new System.Drawing.Point(684, 51);
            this.lblValidade.Name = "lblValidade";
            this.lblValidade.Size = new System.Drawing.Size(138, 13);
            this.lblValidade.TabIndex = 0;
            this.lblValidade.Text = "Data e Horário de Validade:";
            // 
            // lblQtdeCar
            // 
            this.lblQtdeCar.Enabled = false;
            this.lblQtdeCar.Location = new System.Drawing.Point(677, 141);
            this.lblQtdeCar.Name = "lblQtdeCar";
            this.lblQtdeCar.Size = new System.Drawing.Size(183, 13);
            this.lblQtdeCar.TabIndex = 0;
            this.lblQtdeCar.Text = "Max. de Caracteres: 0/200";
            this.lblQtdeCar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rtxtObs
            // 
            this.rtxtObs.BackColor = System.Drawing.Color.White;
            this.rtxtObs.Enabled = false;
            this.rtxtObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtObs.Location = new System.Drawing.Point(38, 106);
            this.rtxtObs.MaxLength = 200;
            this.rtxtObs.Multiline = true;
            this.rtxtObs.Name = "rtxtObs";
            this.rtxtObs.Size = new System.Drawing.Size(822, 32);
            this.rtxtObs.TabIndex = 6;
            this.rtxtObs.TextChanged += new System.EventHandler(this.rtxtObs_TextChanged);
            this.rtxtObs.Enter += new System.EventHandler(this.rtxtObs_Enter);
            this.rtxtObs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtObs_KeyPress);
            this.rtxtObs.Leave += new System.EventHandler(this.rtxtObs_Leave);
            // 
            // mtxtHorario
            // 
            this.mtxtHorario.BackColor = System.Drawing.Color.White;
            this.mtxtHorario.Enabled = false;
            this.mtxtHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorario.Location = new System.Drawing.Point(803, 67);
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
            // pEnabled
            // 
            this.pEnabled.Controls.Add(this.lblAsterisco);
            this.pEnabled.Controls.Add(this.btnEnviarZap);
            this.pEnabled.Controls.Add(this.lblObservacao);
            this.pEnabled.Controls.Add(this.lblCodigo);
            this.pEnabled.Controls.Add(this.btnEnviarEmail);
            this.pEnabled.Controls.Add(this.lblCliente);
            this.pEnabled.Controls.Add(this.btnGerar);
            this.pEnabled.Controls.Add(this.rbtnServicos);
            this.pEnabled.Controls.Add(this.btnCapturar);
            this.pEnabled.Controls.Add(this.cbbCliente);
            this.pEnabled.Controls.Add(this.mtxtHorario);
            this.pEnabled.Controls.Add(this.txtCodigo);
            this.pEnabled.Controls.Add(this.rtxtObs);
            this.pEnabled.Controls.Add(this.btnSair);
            this.pEnabled.Controls.Add(this.lblQtdeCar);
            this.pEnabled.Controls.Add(this.btnNovo);
            this.pEnabled.Controls.Add(this.btnSelecionarData1);
            this.pEnabled.Controls.Add(this.btnExcluirItem);
            this.pEnabled.Controls.Add(this.mtxtValidade);
            this.pEnabled.Controls.Add(this.btnSalvar);
            this.pEnabled.Controls.Add(this.lblValidade);
            this.pEnabled.Controls.Add(this.pcibInterrogacao2);
            this.pEnabled.Controls.Add(this.btnPesquisarCliente);
            this.pEnabled.Location = new System.Drawing.Point(-23, -42);
            this.pEnabled.Name = "pEnabled";
            this.pEnabled.Size = new System.Drawing.Size(914, 588);
            this.pEnabled.TabIndex = 55;
            this.pEnabled.Paint += new System.Windows.Forms.PaintEventHandler(this.pEnabled_Paint);
            // 
            // lblAsterisco
            // 
            this.lblAsterisco.AutoSize = true;
            this.lblAsterisco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco.Location = new System.Drawing.Point(181, 48);
            this.lblAsterisco.Name = "lblAsterisco";
            this.lblAsterisco.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco.TabIndex = 52;
            this.lblAsterisco.Text = "*";
            // 
            // FrmCadOrcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(849, 530);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadOrcamento";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Orçamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOrcamento_FormClosing);
            this.Load += new System.EventHandler(this.FrmOrcamento_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmOrcamento_KeyUp);
            this.rbtnServicos.ResumeLayout(false);
            this.rbtnServicos.PerformLayout();
            this.grbBox3.ResumeLayout(false);
            this.grbBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao2)).EndInit();
            this.pEnabled.ResumeLayout(false);
            this.pEnabled.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbbCliente;
        private System.Windows.Forms.GroupBox rbtnServicos;
        private System.Windows.Forms.Button btnPesquisarProduto;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.GroupBox grbBox3;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnBarra;
        private System.Windows.Forms.Button btnIncuir;
        private System.Windows.Forms.TextBox txtpBarra;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.DataGridView dtProd;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluirItem;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.PictureBox pcibInterrogacao2;
        private System.Windows.Forms.Button btnPesquisarCliente;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.ToolTip ttpOrcamento;
        private System.Windows.Forms.Button btnSelecionarData1;
        private System.Windows.Forms.MaskedTextBox mtxtValidade;
        private System.Windows.Forms.Label lblValidade;
        private System.Windows.Forms.Label lblQtdeCar;
        private System.Windows.Forms.TextBox rtxtObs;
        private System.Windows.Forms.Label lblTotalReal;
        private System.Windows.Forms.Label lblValorTotalReal;
        private System.Windows.Forms.MaskedTextBox mtxtHorario;
        private System.Windows.Forms.Button btnCapturar;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton rbtnProdutos;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Button btnEnviarZap;
        private System.Windows.Forms.Button btnEnviarEmail;
        private System.Windows.Forms.Panel pEnabled;
        private System.Windows.Forms.Label lblAsterisco;
    }
}