namespace Seven_Sistema
{
    partial class FrmRelRegistroAtividade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelRegistroAtividade));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.mtxtHorario1 = new System.Windows.Forms.MaskedTextBox();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.cbbpTabelaDestino1 = new System.Windows.Forms.ComboBox();
            this.lblEscolhaTabela = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.mtxtHorario = new System.Windows.Forms.MaskedTextBox();
            this.lblDatas = new System.Windows.Forms.Label();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.rbtnCodRegistro = new System.Windows.Forms.RadioButton();
            this.rbtnUsuario = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.btnpUsuario = new System.Windows.Forms.Button();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.cbbpUsuario = new System.Windows.Forms.ComboBox();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.dtReg = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.btnImprimirRel = new System.Windows.Forms.Button();
            this.btnExportarCsv = new System.Windows.Forms.Button();
            this.rbtnExportarTxt = new System.Windows.Forms.Button();
            this.picbInterrogacao3 = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.ttpReg = new System.Windows.Forms.ToolTip(this.components);
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.pEnabled = new System.Windows.Forms.Panel();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReg)).BeginInit();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao3)).BeginInit();
            this.pEnabled.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.mtxtHorario1);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.cbbpTabelaDestino1);
            this.grbBox1.Controls.Add(this.lblEscolhaTabela);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.mtxtHorario);
            this.grbBox1.Controls.Add(this.lblDatas);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.rbtnCodRegistro);
            this.grbBox1.Controls.Add(this.rbtnUsuario);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.btnpUsuario);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.cbbpUsuario);
            this.grbBox1.Location = new System.Drawing.Point(24, 52);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(760, 108);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // mtxtHorario1
            // 
            this.mtxtHorario1.BackColor = System.Drawing.Color.White;
            this.mtxtHorario1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorario1.Location = new System.Drawing.Point(272, 80);
            this.mtxtHorario1.Mask = "00:00:00";
            this.mtxtHorario1.Name = "mtxtHorario1";
            this.mtxtHorario1.Size = new System.Drawing.Size(58, 20);
            this.mtxtHorario1.TabIndex = 12;
            this.mtxtHorario1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorario1.DoubleClick += new System.EventHandler(this.mtxtHorario1_DoubleClick);
            this.mtxtHorario1.Enter += new System.EventHandler(this.mtxtHorario1_Enter);
            this.mtxtHorario1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorario1_KeyPress);
            this.mtxtHorario1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorario1_KeyUp);
            this.mtxtHorario1.Leave += new System.EventHandler(this.mtxtHorario1_Leave);
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(336, 77);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 13;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpReg.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // cbbpTabelaDestino1
            // 
            this.cbbpTabelaDestino1.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpTabelaDestino1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpTabelaDestino1.DropDownWidth = 180;
            this.cbbpTabelaDestino1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpTabelaDestino1.FormattingEnabled = true;
            this.cbbpTabelaDestino1.Items.AddRange(new object[] {
            "",
            "CLIENTES",
            "CONTAS A PAGAR",
            "CONTAS A RECEBER",
            "DFE",
            "FORNECEDORES",
            "FUNCIONARIOS",
            "FORMAS DE PAGAMENTO",
            "GRUPOS",
            "HISTÓRICO DO CAIXA",
            "INVENTARIO",
            "VENDA",
            "PRODUTOS",
            "SUBGRUPOS",
            "USUARIOS",
            "ORDEM DE SERVICO"});
            this.cbbpTabelaDestino1.Location = new System.Drawing.Point(519, 79);
            this.cbbpTabelaDestino1.Name = "cbbpTabelaDestino1";
            this.cbbpTabelaDestino1.Size = new System.Drawing.Size(235, 21);
            this.cbbpTabelaDestino1.TabIndex = 14;
            this.cbbpTabelaDestino1.DropDown += new System.EventHandler(this.cbbpTabelaDestino1_DropDown);
            this.cbbpTabelaDestino1.DropDownClosed += new System.EventHandler(this.cbbpTabelaDestino1_DropDownClosed);
            this.cbbpTabelaDestino1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpTabelaDestino1_KeyPress);
            this.cbbpTabelaDestino1.MouseLeave += new System.EventHandler(this.cbbpTabelaDestino1_MouseLeave);
            this.cbbpTabelaDestino1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpTabelaDestino1_MouseMove);
            // 
            // lblEscolhaTabela
            // 
            this.lblEscolhaTabela.AutoSize = true;
            this.lblEscolhaTabela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblEscolhaTabela.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblEscolhaTabela.Location = new System.Drawing.Point(516, 63);
            this.lblEscolhaTabela.Name = "lblEscolhaTabela";
            this.lblEscolhaTabela.Size = new System.Drawing.Size(106, 13);
            this.lblEscolhaTabela.TabIndex = 0;
            this.lblEscolhaTabela.Text = "Escolha a tabela:";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(156, 83);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // mtxtHorario
            // 
            this.mtxtHorario.BackColor = System.Drawing.Color.White;
            this.mtxtHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorario.Location = new System.Drawing.Point(93, 80);
            this.mtxtHorario.Mask = "00:00:00";
            this.mtxtHorario.Name = "mtxtHorario";
            this.mtxtHorario.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario.TabIndex = 10;
            this.mtxtHorario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorario.DoubleClick += new System.EventHandler(this.mtxtHorario_DoubleClick);
            this.mtxtHorario.Enter += new System.EventHandler(this.mtxtHorario_Enter);
            this.mtxtHorario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorario_KeyPress);
            this.mtxtHorario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorario_KeyUp);
            this.mtxtHorario.Leave += new System.EventHandler(this.mtxtHorario_Leave);
            // 
            // lblDatas
            // 
            this.lblDatas.AutoSize = true;
            this.lblDatas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDatas.Location = new System.Drawing.Point(6, 64);
            this.lblDatas.Name = "lblDatas";
            this.lblDatas.Size = new System.Drawing.Size(163, 13);
            this.lblDatas.TabIndex = 0;
            this.lblDatas.Text = "Data e Horário do Registro:";
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(188, 80);
            this.mtxtpData1.Mask = "00/00/0000";
            this.mtxtpData1.Name = "mtxtpData1";
            this.mtxtpData1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData1.TabIndex = 11;
            this.mtxtpData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData1.DoubleClick += new System.EventHandler(this.mtxtpData1_DoubleClick);
            this.mtxtpData1.Enter += new System.EventHandler(this.mtxtpData1_Enter);
            this.mtxtpData1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData1_KeyPress);
            this.mtxtpData1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData1_KeyUp);
            this.mtxtpData1.Leave += new System.EventHandler(this.mtxtpData1_Leave);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(73, 44);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 5;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // mtxtpData
            // 
            this.mtxtpData.BackColor = System.Drawing.Color.White;
            this.mtxtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData.Location = new System.Drawing.Point(9, 80);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 9;
            this.mtxtpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData.DoubleClick += new System.EventHandler(this.mtxtpData_DoubleClick);
            this.mtxtpData.Enter += new System.EventHandler(this.mtxtpData_Enter);
            this.mtxtpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData_KeyPress);
            this.mtxtpData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData_KeyUp);
            this.mtxtpData.Leave += new System.EventHandler(this.mtxtpData_Leave);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(479, 22);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(112, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Escolha o usuário:";
            // 
            // rbtnCodRegistro
            // 
            this.rbtnCodRegistro.AutoSize = true;
            this.rbtnCodRegistro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodRegistro.Location = new System.Drawing.Point(73, 21);
            this.rbtnCodRegistro.Name = "rbtnCodRegistro";
            this.rbtnCodRegistro.Size = new System.Drawing.Size(115, 17);
            this.rbtnCodRegistro.TabIndex = 3;
            this.rbtnCodRegistro.Text = "Código do Registro";
            this.rbtnCodRegistro.UseVisualStyleBackColor = true;
            this.rbtnCodRegistro.CheckedChanged += new System.EventHandler(this.rbtnCodRegistro_CheckedChanged);
            this.rbtnCodRegistro.MouseLeave += new System.EventHandler(this.rbtnCodRegistro_MouseLeave);
            this.rbtnCodRegistro.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodRegistro_MouseMove);
            // 
            // rbtnUsuario
            // 
            this.rbtnUsuario.AutoSize = true;
            this.rbtnUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnUsuario.Location = new System.Drawing.Point(6, 21);
            this.rbtnUsuario.Name = "rbtnUsuario";
            this.rbtnUsuario.Size = new System.Drawing.Size(61, 17);
            this.rbtnUsuario.TabIndex = 2;
            this.rbtnUsuario.Text = "Usuário";
            this.rbtnUsuario.UseVisualStyleBackColor = true;
            this.rbtnUsuario.CheckedChanged += new System.EventHandler(this.rbtnUsuario_CheckedChanged);
            this.rbtnUsuario.MouseLeave += new System.EventHandler(this.rbtnUsuario_MouseLeave);
            this.rbtnUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnUsuario_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(6, 44);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 4;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // btnpUsuario
            // 
            this.btnpUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnpUsuario.Image")));
            this.btnpUsuario.Location = new System.Drawing.Point(728, 17);
            this.btnpUsuario.Name = "btnpUsuario";
            this.btnpUsuario.Size = new System.Drawing.Size(26, 25);
            this.btnpUsuario.TabIndex = 8;
            this.btnpUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpReg.SetToolTip(this.btnpUsuario, "Clique para pesquisar um usuário.");
            this.btnpUsuario.UseVisualStyleBackColor = true;
            this.btnpUsuario.Visible = false;
            this.btnpUsuario.Click += new System.EventHandler(this.btnpUsuario_Click);
            this.btnpUsuario.MouseLeave += new System.EventHandler(this.btnpGrupo_MouseLeave);
            this.btnpUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnpGrupo_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpCodigo.Location = new System.Drawing.Point(674, 20);
            this.txtpCodigo.MaxLength = 10;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtpCodigo.TabIndex = 7;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // cbbpUsuario
            // 
            this.cbbpUsuario.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpUsuario.DropDownWidth = 258;
            this.cbbpUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpUsuario.FormattingEnabled = true;
            this.cbbpUsuario.Location = new System.Drawing.Point(597, 19);
            this.cbbpUsuario.Name = "cbbpUsuario";
            this.cbbpUsuario.Size = new System.Drawing.Size(125, 21);
            this.cbbpUsuario.TabIndex = 6;
            this.cbbpUsuario.Visible = false;
            this.cbbpUsuario.DropDown += new System.EventHandler(this.cbbpUsuario_DropDown);
            this.cbbpUsuario.DropDownClosed += new System.EventHandler(this.cbbpUsuario_DropDownClosed);
            this.cbbpUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpUsuario_KeyPress);
            this.cbbpUsuario.MouseLeave += new System.EventHandler(this.cbbpUsuario_MouseLeave);
            this.cbbpUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpUsuario_MouseMove);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(676, 166);
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
            this.btnPesquisar.Location = new System.Drawing.Point(702, 166);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 16;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpReg.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(281, 265);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(300, 33);
            this.lblProgresso.TabIndex = 219;
            this.lblProgresso.Text = "Por favor, aguarde...";
            this.lblProgresso.Visible = false;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.pgbProgresso.Location = new System.Drawing.Point(267, 298);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(321, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 221;
            this.pgbProgresso.Visible = false;
            // 
            // dtReg
            // 
            this.dtReg.AllowUserToAddRows = false;
            this.dtReg.AllowUserToDeleteRows = false;
            this.dtReg.AllowUserToOrderColumns = true;
            this.dtReg.AllowUserToResizeRows = false;
            this.dtReg.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtReg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtReg.Enabled = false;
            this.dtReg.Location = new System.Drawing.Point(24, 204);
            this.dtReg.MultiSelect = false;
            this.dtReg.Name = "dtReg";
            this.dtReg.ReadOnly = true;
            this.dtReg.RowHeadersVisible = false;
            this.dtReg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtReg.ShowCellErrors = false;
            this.dtReg.ShowCellToolTips = false;
            this.dtReg.ShowEditingIcon = false;
            this.dtReg.ShowRowErrors = false;
            this.dtReg.Size = new System.Drawing.Size(760, 172);
            this.dtReg.TabIndex = 17;
            this.dtReg.DataSourceChanged += new System.EventHandler(this.dtReg_DataSourceChanged);
            this.dtReg.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtReg_CellEnter);
            this.dtReg.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtReg_CellFormatting);
            this.dtReg.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtReg_RowsAdded);
            this.dtReg.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtReg_RowsRemoved);
            this.dtReg.MouseLeave += new System.EventHandler(this.dtReg_MouseLeave);
            this.dtReg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtReg_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(21, 379);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.btnImprimirRel);
            this.grbBox2.Controls.Add(this.btnExportarCsv);
            this.grbBox2.Controls.Add(this.rbtnExportarTxt);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(24, 408);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(760, 50);
            this.grbBox2.TabIndex = 18;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Ações";
            // 
            // btnImprimirRel
            // 
            this.btnImprimirRel.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirRel.Image")));
            this.btnImprimirRel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirRel.Location = new System.Drawing.Point(6, 19);
            this.btnImprimirRel.Name = "btnImprimirRel";
            this.btnImprimirRel.Size = new System.Drawing.Size(120, 25);
            this.btnImprimirRel.TabIndex = 19;
            this.btnImprimirRel.Text = "Relatório em PD&F";
            this.btnImprimirRel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpReg.SetToolTip(this.btnImprimirRel, "Clique para gerar em PDF o relatório resumido de Registro de Atividades.");
            this.btnImprimirRel.UseVisualStyleBackColor = true;
            this.btnImprimirRel.Click += new System.EventHandler(this.btnImprimirRel_Click);
            this.btnImprimirRel.MouseLeave += new System.EventHandler(this.btnImprimirRel_MouseLeave);
            this.btnImprimirRel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnImprimirRel_MouseMove);
            // 
            // btnExportarCsv
            // 
            this.btnExportarCsv.Image = ((System.Drawing.Image)(resources.GetObject("btnExportarCsv.Image")));
            this.btnExportarCsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarCsv.Location = new System.Drawing.Point(311, 19);
            this.btnExportarCsv.Name = "btnExportarCsv";
            this.btnExportarCsv.Size = new System.Drawing.Size(135, 25);
            this.btnExportarCsv.TabIndex = 20;
            this.btnExportarCsv.Text = "&Exp. dados para (.csv)";
            this.btnExportarCsv.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpReg.SetToolTip(this.btnExportarCsv, "Gerar arquivo da grade de dados em (.csv)(Excel).");
            this.btnExportarCsv.UseVisualStyleBackColor = true;
            this.btnExportarCsv.Click += new System.EventHandler(this.btnExportarCsv_Click);
            this.btnExportarCsv.MouseLeave += new System.EventHandler(this.btnExportarCsv_MouseLeave);
            this.btnExportarCsv.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExportarCsv_MouseMove);
            // 
            // rbtnExportarTxt
            // 
            this.rbtnExportarTxt.Image = ((System.Drawing.Image)(resources.GetObject("rbtnExportarTxt.Image")));
            this.rbtnExportarTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rbtnExportarTxt.Location = new System.Drawing.Point(621, 19);
            this.rbtnExportarTxt.Name = "rbtnExportarTxt";
            this.rbtnExportarTxt.Size = new System.Drawing.Size(133, 25);
            this.rbtnExportarTxt.TabIndex = 21;
            this.rbtnExportarTxt.Text = "Exp. d&ados para (.txt)";
            this.rbtnExportarTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpReg.SetToolTip(this.rbtnExportarTxt, "Gerar arquivo da grade de dados em (.txt)(Bloco de Notas).");
            this.rbtnExportarTxt.UseVisualStyleBackColor = true;
            this.rbtnExportarTxt.Click += new System.EventHandler(this.rbtnExportarTxt_Click);
            this.rbtnExportarTxt.MouseLeave += new System.EventHandler(this.rbtnExportarTxt_MouseLeave);
            this.rbtnExportarTxt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnExportarTxt_MouseMove);
            // 
            // picbInterrogacao3
            // 
            this.picbInterrogacao3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao3.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao3.Image")));
            this.picbInterrogacao3.Location = new System.Drawing.Point(24, 464);
            this.picbInterrogacao3.Name = "picbInterrogacao3";
            this.picbInterrogacao3.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao3.TabIndex = 225;
            this.picbInterrogacao3.TabStop = false;
            this.picbInterrogacao3.Click += new System.EventHandler(this.picbInterrogacao3_Click);
            this.picbInterrogacao3.MouseLeave += new System.EventHandler(this.picbInterrogacao3_MouseLeave);
            this.picbInterrogacao3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao3_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(729, 464);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 22;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpReg.SetToolTip(this.btnSair, "Sair do Relatório de Registro de Atividades.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.d);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // ttpReg
            // 
            this.ttpReg.AutoPopDelay = 5000;
            this.ttpReg.InitialDelay = 1000;
            this.ttpReg.IsBalloon = true;
            this.ttpReg.ReshowDelay = 100;
            this.ttpReg.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpReg.ToolTipTitle = "Dica:";
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // pEnabled
            // 
            this.pEnabled.Controls.Add(this.btnSair);
            this.pEnabled.Controls.Add(this.picbInterrogacao3);
            this.pEnabled.Controls.Add(this.grbBox2);
            this.pEnabled.Controls.Add(this.lblRegistros);
            this.pEnabled.Controls.Add(this.grbBox1);
            this.pEnabled.Controls.Add(this.btnPesquisar);
            this.pEnabled.Controls.Add(this.picbInterrogacao2);
            this.pEnabled.Controls.Add(this.lblProgresso);
            this.pEnabled.Controls.Add(this.pgbProgresso);
            this.pEnabled.Controls.Add(this.dtReg);
            this.pEnabled.Location = new System.Drawing.Point(-12, -40);
            this.pEnabled.Name = "pEnabled";
            this.pEnabled.Size = new System.Drawing.Size(808, 598);
            this.pEnabled.TabIndex = 226;
            // 
            // FrmRelRegistroAtividade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(784, 460);
            this.ControlBox = false;
            this.Controls.Add(this.pEnabled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelRegistroAtividade";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Registro de Atividades";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRelRegistroAtividade_FormClosing);
            this.Load += new System.EventHandler(this.FrmRelRegistroAtividade_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRelRegistroAtividade_KeyUp);
            this.MouseLeave += new System.EventHandler(this.FrmRelRegistroAtividade_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmRelRegistroAtividade_MouseMove);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReg)).EndInit();
            this.grbBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao3)).EndInit();
            this.pEnabled.ResumeLayout(false);
            this.pEnabled.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnCodRegistro;
        private System.Windows.Forms.RadioButton rbtnUsuario;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.MaskedTextBox mtxtHorario1;
        private System.Windows.Forms.MaskedTextBox mtxtHorario;
        private System.Windows.Forms.Label lblDatas;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.Button btnpUsuario;
        private System.Windows.Forms.ComboBox cbbpUsuario;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.Windows.Forms.DataGridView dtReg;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnExportarCsv;
        private System.Windows.Forms.Button rbtnExportarTxt;
        private System.Windows.Forms.PictureBox picbInterrogacao3;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblEscolhaTabela;
        private System.Windows.Forms.ComboBox cbbpTabelaDestino1;
        private System.Windows.Forms.ToolTip ttpReg;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.Button btnImprimirRel;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.Panel pEnabled;
    }
}