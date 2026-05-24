namespace Seven_Sistema
{
    partial class FrmRelProdInv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelProdInv));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnBarra = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnProduto = new System.Windows.Forms.RadioButton();
            this.btnProcurarProduto = new System.Windows.Forms.Button();
            this.lblPesquisa = new System.Windows.Forms.Label();
            this.txtpBarra = new System.Windows.Forms.TextBox();
            this.cbbProduto = new System.Windows.Forms.ComboBox();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.dtProd = new System.Windows.Forms.DataGridView();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUltSaldoAtual = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtUltCusto = new System.Windows.Forms.TextBox();
            this.txtUltTotal = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNCM = new System.Windows.Forms.TextBox();
            this.btnProcurarProdutoServico = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAsterisco2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbProdutoServico = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.grbBox4 = new System.Windows.Forms.GroupBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustoMedio = new System.Windows.Forms.TextBox();
            this.txtTotalMedio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbUM = new System.Windows.Forms.ComboBox();
            this.grbBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInvTotalAtual = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInvSaldoAtual = new System.Windows.Forms.TextBox();
            this.lblSaldoAtual = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInvCustoMedioAtual = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.ttpProd = new System.Windows.Forms.ToolTip(this.components);
            this.lblTotalMedio = new System.Windows.Forms.Label();
            this.lblMedio = new System.Windows.Forms.Label();
            this.lblTotalAtual = new System.Windows.Forms.Label();
            this.lblAtual = new System.Windows.Forms.Label();
            this.lblTotalInv = new System.Windows.Forms.Label();
            this.lblInv = new System.Windows.Forms.Label();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProd)).BeginInit();
            this.grbBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbBox4.SuspendLayout();
            this.grbBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnBarra);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnProduto);
            this.grbBox1.Controls.Add(this.btnProcurarProduto);
            this.grbBox1.Controls.Add(this.lblPesquisa);
            this.grbBox1.Controls.Add(this.txtpBarra);
            this.grbBox1.Controls.Add(this.cbbProduto);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(775, 59);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnBarra
            // 
            this.rbtnBarra.AutoSize = true;
            this.rbtnBarra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnBarra.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnBarra.Location = new System.Drawing.Point(74, 19);
            this.rbtnBarra.Name = "rbtnBarra";
            this.rbtnBarra.Size = new System.Drawing.Size(106, 17);
            this.rbtnBarra.TabIndex = 6;
            this.rbtnBarra.Text = "Código de Barras";
            this.rbtnBarra.UseVisualStyleBackColor = true;
            this.rbtnBarra.CheckedChanged += new System.EventHandler(this.rbtnBarra_CheckedChanged);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(186, 19);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 3;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // rbtnProduto
            // 
            this.rbtnProduto.AutoSize = true;
            this.rbtnProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnProduto.Location = new System.Drawing.Point(6, 19);
            this.rbtnProduto.Name = "rbtnProduto";
            this.rbtnProduto.Size = new System.Drawing.Size(62, 17);
            this.rbtnProduto.TabIndex = 2;
            this.rbtnProduto.Text = "Produto";
            this.rbtnProduto.UseVisualStyleBackColor = true;
            this.rbtnProduto.CheckedChanged += new System.EventHandler(this.rbtnDescricao_CheckedChanged);
            this.rbtnProduto.MouseLeave += new System.EventHandler(this.rbtnDescricao_MouseLeave);
            this.rbtnProduto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnDescricao_MouseMove);
            // 
            // btnProcurarProduto
            // 
            this.btnProcurarProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarProduto.Image")));
            this.btnProcurarProduto.Location = new System.Drawing.Point(741, 29);
            this.btnProcurarProduto.Name = "btnProcurarProduto";
            this.btnProcurarProduto.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarProduto.TabIndex = 5;
            this.btnProcurarProduto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProd.SetToolTip(this.btnProcurarProduto, "Clique para pesquisar um Produto.");
            this.btnProcurarProduto.UseVisualStyleBackColor = true;
            this.btnProcurarProduto.Click += new System.EventHandler(this.btnProcurarProduto_Click);
            this.btnProcurarProduto.MouseLeave += new System.EventHandler(this.btnProcurarProduto_MouseLeave);
            this.btnProcurarProduto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarProduto_MouseMove);
            // 
            // lblPesquisa
            // 
            this.lblPesquisa.AutoSize = true;
            this.lblPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisa.Location = new System.Drawing.Point(416, 16);
            this.lblPesquisa.Name = "lblPesquisa";
            this.lblPesquisa.Size = new System.Drawing.Size(55, 13);
            this.lblPesquisa.TabIndex = 0;
            this.lblPesquisa.Text = "Produto:";
            // 
            // txtpBarra
            // 
            this.txtpBarra.BackColor = System.Drawing.Color.White;
            this.txtpBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpBarra.Location = new System.Drawing.Point(420, 33);
            this.txtpBarra.MaxLength = 60;
            this.txtpBarra.Name = "txtpBarra";
            this.txtpBarra.Size = new System.Drawing.Size(347, 20);
            this.txtpBarra.TabIndex = 11;
            this.txtpBarra.Visible = false;
            this.txtpBarra.Enter += new System.EventHandler(this.txtpBarra_Enter);
            this.txtpBarra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpBarra_KeyPress);
            this.txtpBarra.Leave += new System.EventHandler(this.txtpBarra_Leave);
            // 
            // cbbProduto
            // 
            this.cbbProduto.BackColor = System.Drawing.Color.LightBlue;
            this.cbbProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProduto.DropDownWidth = 550;
            this.cbbProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbProduto.FormattingEnabled = true;
            this.cbbProduto.Location = new System.Drawing.Point(419, 32);
            this.cbbProduto.Name = "cbbProduto";
            this.cbbProduto.Size = new System.Drawing.Size(316, 21);
            this.cbbProduto.TabIndex = 4;
            this.cbbProduto.DropDown += new System.EventHandler(this.cbbProduto_DropDown);
            this.cbbProduto.DropDownClosed += new System.EventHandler(this.cbbProduto_DropDownClosed);
            this.cbbProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbProduto_KeyPress);
            this.cbbProduto.MouseLeave += new System.EventHandler(this.cbbProduto_MouseLeave);
            this.cbbProduto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbProduto_MouseMove);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(679, 78);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 31;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPesquisar.Location = new System.Drawing.Point(705, 77);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 6;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProd.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(12, 268);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 16);
            this.lblRegistros.TabIndex = 93;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtProd
            // 
            this.dtProd.AllowUserToAddRows = false;
            this.dtProd.AllowUserToDeleteRows = false;
            this.dtProd.AllowUserToResizeRows = false;
            this.dtProd.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtProd.Enabled = false;
            this.dtProd.Location = new System.Drawing.Point(12, 115);
            this.dtProd.MultiSelect = false;
            this.dtProd.Name = "dtProd";
            this.dtProd.ReadOnly = true;
            this.dtProd.RowHeadersVisible = false;
            this.dtProd.RowHeadersWidth = 51;
            this.dtProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtProd.ShowCellErrors = false;
            this.dtProd.ShowCellToolTips = false;
            this.dtProd.ShowEditingIcon = false;
            this.dtProd.ShowRowErrors = false;
            this.dtProd.Size = new System.Drawing.Size(775, 150);
            this.dtProd.TabIndex = 7;
            this.dtProd.DataSourceChanged += new System.EventHandler(this.dtProd_DataSourceChanged);
            this.dtProd.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtProd_CellEnter);
            this.dtProd.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtProd_RowsAdded);
            this.dtProd.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtProd_RowsRemoved);
            this.dtProd.MouseLeave += new System.EventHandler(this.dtProd_MouseLeave);
            this.dtProd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtProd_MouseMove);
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.groupBox1);
            this.grbBox2.Controls.Add(this.label13);
            this.grbBox2.Controls.Add(this.txtNCM);
            this.grbBox2.Controls.Add(this.btnProcurarProdutoServico);
            this.grbBox2.Controls.Add(this.label7);
            this.grbBox2.Controls.Add(this.lblAsterisco2);
            this.grbBox2.Controls.Add(this.label6);
            this.grbBox2.Controls.Add(this.cbbProdutoServico);
            this.grbBox2.Controls.Add(this.lblTipo);
            this.grbBox2.Controls.Add(this.grbBox4);
            this.grbBox2.Controls.Add(this.cbbUM);
            this.grbBox2.Controls.Add(this.grbBox3);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(12, 297);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(775, 126);
            this.grbBox2.TabIndex = 8;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Cadastrar, alterar e excluir:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUltSaldoAtual);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtUltCusto);
            this.groupBox1.Controls.Add(this.txtUltTotal);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(524, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 63);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estoque Atual:";
            // 
            // txtUltSaldoAtual
            // 
            this.txtUltSaldoAtual.BackColor = System.Drawing.Color.White;
            this.txtUltSaldoAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtUltSaldoAtual.Location = new System.Drawing.Point(6, 32);
            this.txtUltSaldoAtual.MaxLength = 10;
            this.txtUltSaldoAtual.Name = "txtUltSaldoAtual";
            this.txtUltSaldoAtual.ReadOnly = true;
            this.txtUltSaldoAtual.Size = new System.Drawing.Size(75, 20);
            this.txtUltSaldoAtual.TabIndex = 16;
            this.txtUltSaldoAtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUltSaldoAtual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUltSaldoAtual_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(3, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 0;
            this.label10.Tag = "";
            this.label10.Text = "Saldo:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(82, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 0;
            this.label12.Tag = "";
            this.label12.Text = "Último Custo:";
            // 
            // txtUltCusto
            // 
            this.txtUltCusto.BackColor = System.Drawing.Color.White;
            this.txtUltCusto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtUltCusto.Location = new System.Drawing.Point(85, 32);
            this.txtUltCusto.MaxLength = 10;
            this.txtUltCusto.Name = "txtUltCusto";
            this.txtUltCusto.ReadOnly = true;
            this.txtUltCusto.Size = new System.Drawing.Size(75, 20);
            this.txtUltCusto.TabIndex = 17;
            this.txtUltCusto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUltCusto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUltCusto_KeyPress);
            // 
            // txtUltTotal
            // 
            this.txtUltTotal.BackColor = System.Drawing.Color.White;
            this.txtUltTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtUltTotal.Location = new System.Drawing.Point(164, 32);
            this.txtUltTotal.MaxLength = 10;
            this.txtUltTotal.Name = "txtUltTotal";
            this.txtUltTotal.ReadOnly = true;
            this.txtUltTotal.Size = new System.Drawing.Size(75, 20);
            this.txtUltTotal.TabIndex = 18;
            this.txtUltTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUltTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUltTotal_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Blue;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(153, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 0;
            this.label14.Tag = "";
            this.label14.Text = "Total Medio Atual:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(626, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 55;
            this.label13.Text = "NCM:";
            // 
            // txtNCM
            // 
            this.txtNCM.BackColor = System.Drawing.Color.White;
            this.txtNCM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtNCM.Location = new System.Drawing.Point(629, 32);
            this.txtNCM.MaxLength = 8;
            this.txtNCM.Name = "txtNCM";
            this.txtNCM.ReadOnly = true;
            this.txtNCM.Size = new System.Drawing.Size(74, 20);
            this.txtNCM.TabIndex = 11;
            this.txtNCM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNCM.Enter += new System.EventHandler(this.txtNCM_Enter);
            this.txtNCM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNCM_KeyPress);
            this.txtNCM.Leave += new System.EventHandler(this.txtNCM_Leave);
            // 
            // btnProcurarProdutoServico
            // 
            this.btnProcurarProdutoServico.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarProdutoServico.Image")));
            this.btnProcurarProdutoServico.Location = new System.Drawing.Point(597, 29);
            this.btnProcurarProdutoServico.Name = "btnProcurarProdutoServico";
            this.btnProcurarProdutoServico.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarProdutoServico.TabIndex = 10;
            this.btnProcurarProdutoServico.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProd.SetToolTip(this.btnProcurarProdutoServico, "Clique para pesquisar um Produto.");
            this.btnProcurarProdutoServico.UseVisualStyleBackColor = true;
            this.btnProcurarProdutoServico.Click += new System.EventHandler(this.btnProcurarProdutoServico_Click);
            this.btnProcurarProdutoServico.MouseLeave += new System.EventHandler(this.btnProcurarProdutoServico_MouseLeave);
            this.btnProcurarProdutoServico.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarProdutoServico_MouseMove);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(48, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "*";
            // 
            // lblAsterisco2
            // 
            this.lblAsterisco2.AutoSize = true;
            this.lblAsterisco2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco2.Location = new System.Drawing.Point(728, 12);
            this.lblAsterisco2.Name = "lblAsterisco2";
            this.lblAsterisco2.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco2.TabIndex = 0;
            this.lblAsterisco2.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 0;
            this.label6.Tag = "";
            this.label6.Text = "Produto:";
            // 
            // cbbProdutoServico
            // 
            this.cbbProdutoServico.BackColor = System.Drawing.Color.LightBlue;
            this.cbbProdutoServico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProdutoServico.DropDownWidth = 550;
            this.cbbProdutoServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbProdutoServico.FormattingEnabled = true;
            this.cbbProdutoServico.Location = new System.Drawing.Point(6, 32);
            this.cbbProdutoServico.Name = "cbbProdutoServico";
            this.cbbProdutoServico.Size = new System.Drawing.Size(585, 21);
            this.cbbProdutoServico.TabIndex = 9;
            this.cbbProdutoServico.DropDown += new System.EventHandler(this.cbbProdutoServico_DropDown);
            this.cbbProdutoServico.DropDownClosed += new System.EventHandler(this.cbbProdutoServico_DropDownClosed);
            this.cbbProdutoServico.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbProdutoServico_KeyPress);
            this.cbbProdutoServico.Leave += new System.EventHandler(this.cbbProdutoServico_Leave);
            this.cbbProdutoServico.MouseLeave += new System.EventHandler(this.cbbProdutoServico_MouseLeave);
            this.cbbProdutoServico.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbProdutoServico_MouseMove);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTipo.Location = new System.Drawing.Point(706, 16);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(27, 13);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "UM:";
            // 
            // grbBox4
            // 
            this.grbBox4.Controls.Add(this.txtQuantidade);
            this.grbBox4.Controls.Add(this.label4);
            this.grbBox4.Controls.Add(this.label5);
            this.grbBox4.Controls.Add(this.txtCustoMedio);
            this.grbBox4.Controls.Add(this.txtTotalMedio);
            this.grbBox4.Controls.Add(this.label2);
            this.grbBox4.Location = new System.Drawing.Point(276, 55);
            this.grbBox4.Name = "grbBox4";
            this.grbBox4.Size = new System.Drawing.Size(242, 63);
            this.grbBox4.TabIndex = 15;
            this.grbBox4.TabStop = false;
            this.grbBox4.Text = "Estoque:";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BackColor = System.Drawing.Color.White;
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtQuantidade.Location = new System.Drawing.Point(6, 32);
            this.txtQuantidade.MaxLength = 10;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.ReadOnly = true;
            this.txtQuantidade.Size = new System.Drawing.Size(75, 20);
            this.txtQuantidade.TabIndex = 16;
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaldo_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(3, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 0;
            this.label4.Tag = "";
            this.label4.Text = "Qtde. Entradas:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(82, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 0;
            this.label5.Tag = "";
            this.label5.Text = "Custo Médio:";
            // 
            // txtCustoMedio
            // 
            this.txtCustoMedio.BackColor = System.Drawing.Color.White;
            this.txtCustoMedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCustoMedio.Location = new System.Drawing.Point(85, 32);
            this.txtCustoMedio.MaxLength = 10;
            this.txtCustoMedio.Name = "txtCustoMedio";
            this.txtCustoMedio.ReadOnly = true;
            this.txtCustoMedio.Size = new System.Drawing.Size(75, 20);
            this.txtCustoMedio.TabIndex = 17;
            this.txtCustoMedio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCustoMedio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCusto_KeyPress);
            // 
            // txtTotalMedio
            // 
            this.txtTotalMedio.BackColor = System.Drawing.Color.White;
            this.txtTotalMedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalMedio.Location = new System.Drawing.Point(164, 32);
            this.txtTotalMedio.MaxLength = 10;
            this.txtTotalMedio.Name = "txtTotalMedio";
            this.txtTotalMedio.ReadOnly = true;
            this.txtTotalMedio.Size = new System.Drawing.Size(75, 20);
            this.txtTotalMedio.TabIndex = 18;
            this.txtTotalMedio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalMedio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotal_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(161, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Tag = "";
            this.label2.Text = "Total Médio:";
            // 
            // cbbUM
            // 
            this.cbbUM.BackColor = System.Drawing.Color.LightBlue;
            this.cbbUM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbbUM.FormattingEnabled = true;
            this.cbbUM.Items.AddRange(new object[] {
            "",
            "UN",
            "CX",
            "KG",
            "M",
            "VD",
            "FR",
            "TB",
            "AP",
            "GA",
            "SC",
            "LT",
            "AM",
            "FL",
            "RL",
            "PT"});
            this.cbbUM.Location = new System.Drawing.Point(709, 32);
            this.cbbUM.Name = "cbbUM";
            this.cbbUM.Size = new System.Drawing.Size(50, 21);
            this.cbbUM.TabIndex = 12;
            this.cbbUM.DropDown += new System.EventHandler(this.cbbUM_DropDown);
            this.cbbUM.DropDownClosed += new System.EventHandler(this.cbbUM_DropDownClosed);
            this.cbbUM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbUM_KeyPress);
            this.cbbUM.Leave += new System.EventHandler(this.cbbUM_Leave);
            this.cbbUM.MouseLeave += new System.EventHandler(this.cbbUM_MouseLeave);
            this.cbbUM.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbUM_MouseMove);
            // 
            // grbBox3
            // 
            this.grbBox3.Controls.Add(this.label11);
            this.grbBox3.Controls.Add(this.label8);
            this.grbBox3.Controls.Add(this.txtInvTotalAtual);
            this.grbBox3.Controls.Add(this.label3);
            this.grbBox3.Controls.Add(this.txtInvSaldoAtual);
            this.grbBox3.Controls.Add(this.lblSaldoAtual);
            this.grbBox3.Controls.Add(this.label1);
            this.grbBox3.Controls.Add(this.txtInvCustoMedioAtual);
            this.grbBox3.Location = new System.Drawing.Point(6, 55);
            this.grbBox3.Name = "grbBox3";
            this.grbBox3.Size = new System.Drawing.Size(270, 63);
            this.grbBox3.TabIndex = 12;
            this.grbBox3.TabStop = false;
            this.grbBox3.Text = "Inventário:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(172, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(59, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "*";
            // 
            // txtInvTotalAtual
            // 
            this.txtInvTotalAtual.BackColor = System.Drawing.Color.White;
            this.txtInvTotalAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtInvTotalAtual.Location = new System.Drawing.Point(189, 32);
            this.txtInvTotalAtual.MaxLength = 10;
            this.txtInvTotalAtual.Name = "txtInvTotalAtual";
            this.txtInvTotalAtual.ReadOnly = true;
            this.txtInvTotalAtual.Size = new System.Drawing.Size(75, 20);
            this.txtInvTotalAtual.TabIndex = 15;
            this.txtInvTotalAtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInvTotalAtual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstoqueTotal_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(186, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 0;
            this.label3.Tag = "";
            this.label3.Text = "Total Inv.:";
            // 
            // txtInvSaldoAtual
            // 
            this.txtInvSaldoAtual.BackColor = System.Drawing.Color.White;
            this.txtInvSaldoAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtInvSaldoAtual.Location = new System.Drawing.Point(3, 32);
            this.txtInvSaldoAtual.MaxLength = 10;
            this.txtInvSaldoAtual.Name = "txtInvSaldoAtual";
            this.txtInvSaldoAtual.Size = new System.Drawing.Size(75, 20);
            this.txtInvSaldoAtual.TabIndex = 13;
            this.txtInvSaldoAtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInvSaldoAtual.Enter += new System.EventHandler(this.txtSaldoAtual_Enter);
            this.txtInvSaldoAtual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaldoAtual_KeyPress);
            this.txtInvSaldoAtual.Leave += new System.EventHandler(this.txtSaldoAtual_Leave);
            // 
            // lblSaldoAtual
            // 
            this.lblSaldoAtual.AutoSize = true;
            this.lblSaldoAtual.ForeColor = System.Drawing.Color.Black;
            this.lblSaldoAtual.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSaldoAtual.Location = new System.Drawing.Point(0, 16);
            this.lblSaldoAtual.Name = "lblSaldoAtual";
            this.lblSaldoAtual.Size = new System.Drawing.Size(64, 13);
            this.lblSaldoAtual.TabIndex = 39;
            this.lblSaldoAtual.Tag = "";
            this.lblSaldoAtual.Text = "Saldo Atual:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(81, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "";
            this.label1.Text = "Custo Médio Atual:";
            // 
            // txtInvCustoMedioAtual
            // 
            this.txtInvCustoMedioAtual.BackColor = System.Drawing.Color.White;
            this.txtInvCustoMedioAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtInvCustoMedioAtual.Location = new System.Drawing.Point(91, 32);
            this.txtInvCustoMedioAtual.MaxLength = 10;
            this.txtInvCustoMedioAtual.Name = "txtInvCustoMedioAtual";
            this.txtInvCustoMedioAtual.Size = new System.Drawing.Size(75, 20);
            this.txtInvCustoMedioAtual.TabIndex = 14;
            this.txtInvCustoMedioAtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInvCustoMedioAtual.Enter += new System.EventHandler(this.txtCustoAtual_Enter);
            this.txtInvCustoMedioAtual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txtInvCustoMedioAtual.Leave += new System.EventHandler(this.txtCustoAtual_Leave);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(732, 429);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 24;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProd.SetToolTip(this.btnSair, "Sair do Inventário de Produtos.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao.Location = new System.Drawing.Point(12, 429);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 100;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(432, 429);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProd.SetToolTip(this.btnCancelar, "Cancelar a opção atual.");
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
            this.btnSalvar.Location = new System.Drawing.Point(522, 429);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 23;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProd.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExcluir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcluir.Location = new System.Drawing.Point(190, 429);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(70, 32);
            this.btnExcluir.TabIndex = 21;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProd.SetToolTip(this.btnExcluir, "Excluir um Produto cadastrado.");
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            this.btnExcluir.MouseLeave += new System.EventHandler(this.btnExcluir_MouseLeave);
            this.btnExcluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluir_MouseMove);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAlterar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAlterar.Location = new System.Drawing.Point(114, 429);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 32);
            this.btnAlterar.TabIndex = 20;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProd.SetToolTip(this.btnAlterar, "Alterar um Produto cadastrado.");
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnAlterar.MouseLeave += new System.EventHandler(this.btnAlterar_MouseLeave);
            this.btnAlterar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterar_MouseMove);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNovo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNovo.Location = new System.Drawing.Point(38, 430);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 32);
            this.btnNovo.TabIndex = 19;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProd.SetToolTip(this.btnNovo, "Cadastrar um novo Produto.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
            // 
            // ttpProd
            // 
            this.ttpProd.AutoPopDelay = 5000;
            this.ttpProd.InitialDelay = 1000;
            this.ttpProd.IsBalloon = true;
            this.ttpProd.ReshowDelay = 100;
            this.ttpProd.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpProd.ToolTipTitle = "Dica:";
            // 
            // lblTotalMedio
            // 
            this.lblTotalMedio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalMedio.BackColor = System.Drawing.Color.White;
            this.lblTotalMedio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalMedio.Enabled = false;
            this.lblTotalMedio.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMedio.ForeColor = System.Drawing.Color.Black;
            this.lblTotalMedio.Location = new System.Drawing.Point(504, 268);
            this.lblTotalMedio.Name = "lblTotalMedio";
            this.lblTotalMedio.Size = new System.Drawing.Size(95, 26);
            this.lblTotalMedio.TabIndex = 0;
            this.lblTotalMedio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalMedio.Click += new System.EventHandler(this.lblValorTotalReal_Click);
            this.lblTotalMedio.MouseLeave += new System.EventHandler(this.lblValorTotalReal_MouseLeave);
            this.lblTotalMedio.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotalReal_MouseMove);
            // 
            // lblMedio
            // 
            this.lblMedio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMedio.BackColor = System.Drawing.Color.Transparent;
            this.lblMedio.Enabled = false;
            this.lblMedio.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblMedio.ForeColor = System.Drawing.Color.Black;
            this.lblMedio.Location = new System.Drawing.Point(412, 268);
            this.lblMedio.Name = "lblMedio";
            this.lblMedio.Size = new System.Drawing.Size(146, 26);
            this.lblMedio.TabIndex = 0;
            this.lblMedio.Text = "Total Médio:";
            this.lblMedio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalAtual
            // 
            this.lblTotalAtual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalAtual.BackColor = System.Drawing.Color.White;
            this.lblTotalAtual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalAtual.Enabled = false;
            this.lblTotalAtual.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAtual.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAtual.Location = new System.Drawing.Point(691, 268);
            this.lblTotalAtual.Name = "lblTotalAtual";
            this.lblTotalAtual.Size = new System.Drawing.Size(95, 26);
            this.lblTotalAtual.TabIndex = 0;
            this.lblTotalAtual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalAtual.Click += new System.EventHandler(this.label10_Click);
            this.lblTotalAtual.MouseLeave += new System.EventHandler(this.label10_MouseLeave);
            this.lblTotalAtual.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label10_MouseMove);
            // 
            // lblAtual
            // 
            this.lblAtual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAtual.BackColor = System.Drawing.Color.Transparent;
            this.lblAtual.Enabled = false;
            this.lblAtual.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblAtual.ForeColor = System.Drawing.Color.Black;
            this.lblAtual.Location = new System.Drawing.Point(605, 268);
            this.lblAtual.Name = "lblAtual";
            this.lblAtual.Size = new System.Drawing.Size(146, 26);
            this.lblAtual.TabIndex = 0;
            this.lblAtual.Text = "Total Atual:";
            this.lblAtual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalInv
            // 
            this.lblTotalInv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalInv.BackColor = System.Drawing.Color.White;
            this.lblTotalInv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalInv.Enabled = false;
            this.lblTotalInv.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalInv.ForeColor = System.Drawing.Color.Black;
            this.lblTotalInv.Location = new System.Drawing.Point(311, 268);
            this.lblTotalInv.Name = "lblTotalInv";
            this.lblTotalInv.Size = new System.Drawing.Size(95, 26);
            this.lblTotalInv.TabIndex = 101;
            this.lblTotalInv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalInv.Click += new System.EventHandler(this.lblTotalInv_Click);
            this.lblTotalInv.MouseLeave += new System.EventHandler(this.lblTotalInv_MouseLeave);
            this.lblTotalInv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTotalInv_MouseMove);
            // 
            // lblInv
            // 
            this.lblInv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblInv.BackColor = System.Drawing.Color.Transparent;
            this.lblInv.Enabled = false;
            this.lblInv.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblInv.ForeColor = System.Drawing.Color.Black;
            this.lblInv.Location = new System.Drawing.Point(240, 268);
            this.lblInv.Name = "lblInv";
            this.lblInv.Size = new System.Drawing.Size(146, 26);
            this.lblInv.TabIndex = 102;
            this.lblInv.Text = "Total Inv:";
            this.lblInv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmRelProdInv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(800, 469);
            this.ControlBox = false;
            this.Controls.Add(this.lblTotalInv);
            this.Controls.Add(this.lblTotalAtual);
            this.Controls.Add(this.lblAtual);
            this.Controls.Add(this.lblTotalMedio);
            this.Controls.Add(this.lblMedio);
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.picbInterrogacao2);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox2);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.dtProd);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.lblInv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelProdInv";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventário de Produtos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRelProdInv_FormClosing);
            this.Load += new System.EventHandler(this.FrmRelProdInv_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRelProdInv_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtProd)).EndInit();
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbBox4.ResumeLayout(false);
            this.grbBox4.PerformLayout();
            this.grbBox3.ResumeLayout(false);
            this.grbBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.DataGridView dtProd;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Label lblSaldoAtual;
        private System.Windows.Forms.TextBox txtInvSaldoAtual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInvCustoMedioAtual;
        private System.Windows.Forms.GroupBox grbBox3;
        private System.Windows.Forms.TextBox txtInvTotalAtual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grbBox4;
        private System.Windows.Forms.TextBox txtTotalMedio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustoMedio;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnProcurarProduto;
        private System.Windows.Forms.Label lblPesquisa;
        private System.Windows.Forms.ComboBox cbbProduto;
        private System.Windows.Forms.RadioButton rbtnProduto;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.ToolTip ttpProd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbProdutoServico;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAsterisco2;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cbbUM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnProcurarProdutoServico;
        private System.Windows.Forms.Label lblTotalMedio;
        private System.Windows.Forms.Label lblMedio;
        private System.Windows.Forms.Label lblTotalAtual;
        private System.Windows.Forms.Label lblAtual;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNCM;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUltSaldoAtual;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtUltCusto;
        private System.Windows.Forms.TextBox txtUltTotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotalInv;
        private System.Windows.Forms.Label lblInv;
        private System.Windows.Forms.TextBox txtpBarra;
        private System.Windows.Forms.RadioButton rbtnBarra;
    }
}