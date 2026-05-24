namespace Seven_Sistema
{
    partial class FrmPesqConsumidor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesqConsumidor));
            this.pcibAjudaFoto = new System.Windows.Forms.PictureBox();
            this.lblLegendaImagem = new System.Windows.Forms.Label();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.pcibImagem = new System.Windows.Forms.PictureBox();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnIE = new System.Windows.Forms.RadioButton();
            this.rbtnCNPJ = new System.Windows.Forms.RadioButton();
            this.rbtnPalavraChave = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnCPFResponsavel = new System.Windows.Forms.RadioButton();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnNomeAluno = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.rbtnRG = new System.Windows.Forms.RadioButton();
            this.rbtnCPF = new System.Windows.Forms.RadioButton();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.mtxtpCPF = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpCelular = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpTelefone = new System.Windows.Forms.MaskedTextBox();
            this.txtpRG = new System.Windows.Forms.TextBox();
            this.txtpNome = new System.Windows.Forms.TextBox();
            this.mtxtpCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.txtpPalavraChave = new System.Windows.Forms.TextBox();
            this.dtClie = new System.Windows.Forms.DataGridView();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.ttpCliente = new System.Windows.Forms.ToolTip(this.components);
            this.btnCadastrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcibAjudaFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClie)).BeginInit();
            this.SuspendLayout();
            // 
            // pcibAjudaFoto
            // 
            this.pcibAjudaFoto.BackColor = System.Drawing.Color.White;
            this.pcibAjudaFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibAjudaFoto.Enabled = false;
            this.pcibAjudaFoto.Image = ((System.Drawing.Image)(resources.GetObject("pcibAjudaFoto.Image")));
            this.pcibAjudaFoto.Location = new System.Drawing.Point(147, 206);
            this.pcibAjudaFoto.Name = "pcibAjudaFoto";
            this.pcibAjudaFoto.Size = new System.Drawing.Size(20, 20);
            this.pcibAjudaFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibAjudaFoto.TabIndex = 91;
            this.pcibAjudaFoto.TabStop = false;
            this.pcibAjudaFoto.Click += new System.EventHandler(this.pcibAjudaFoto_Click);
            this.pcibAjudaFoto.MouseLeave += new System.EventHandler(this.pcibAjudaFoto_MouseLeave);
            this.pcibAjudaFoto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibAjudaFoto_MouseMove);
            // 
            // lblLegendaImagem
            // 
            this.lblLegendaImagem.Location = new System.Drawing.Point(15, 140);
            this.lblLegendaImagem.Name = "lblLegendaImagem";
            this.lblLegendaImagem.Size = new System.Drawing.Size(148, 45);
            this.lblLegendaImagem.TabIndex = 0;
            this.lblLegendaImagem.Text = "Sem imagem para este registro.";
            this.lblLegendaImagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLegendaImagem.Visible = false;
            this.lblLegendaImagem.Click += new System.EventHandler(this.lblLegendaImagem_Click);
            this.lblLegendaImagem.MouseLeave += new System.EventHandler(this.lblLegendaImagem_MouseLeave);
            this.lblLegendaImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblLegendaImagem_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(9, 229);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pcibImagem
            // 
            this.pcibImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibImagem.Enabled = false;
            this.pcibImagem.Location = new System.Drawing.Point(12, 97);
            this.pcibImagem.Name = "pcibImagem";
            this.pcibImagem.Size = new System.Drawing.Size(155, 129);
            this.pcibImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcibImagem.TabIndex = 92;
            this.pcibImagem.TabStop = false;
            this.pcibImagem.Click += new System.EventHandler(this.pcibImagem_Click);
            this.pcibImagem.MouseLeave += new System.EventHandler(this.pcibImagem_MouseLeave);
            this.pcibImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibImagem_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnIE);
            this.grbBox1.Controls.Add(this.rbtnCNPJ);
            this.grbBox1.Controls.Add(this.rbtnPalavraChave);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnCPFResponsavel);
            this.grbBox1.Controls.Add(this.picbInterrogacao1);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnNomeAluno);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.rbtnRG);
            this.grbBox1.Controls.Add(this.rbtnCPF);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.mtxtpCPF);
            this.grbBox1.Controls.Add(this.mtxtpCelular);
            this.grbBox1.Controls.Add(this.mtxtpTelefone);
            this.grbBox1.Controls.Add(this.mtxtpCNPJ);
            this.grbBox1.Controls.Add(this.txtpPalavraChave);
            this.grbBox1.Controls.Add(this.txtpRG);
            this.grbBox1.Controls.Add(this.txtpNome);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(810, 79);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnIE
            // 
            this.rbtnIE.AutoSize = true;
            this.rbtnIE.Location = new System.Drawing.Point(6, 42);
            this.rbtnIE.Name = "rbtnIE";
            this.rbtnIE.Size = new System.Drawing.Size(112, 17);
            this.rbtnIE.TabIndex = 4;
            this.rbtnIE.TabStop = true;
            this.rbtnIE.Text = "Inscrição Estadual";
            this.rbtnIE.UseVisualStyleBackColor = true;
            this.rbtnIE.CheckedChanged += new System.EventHandler(this.rbtnIE_CheckedChanged);
            this.rbtnIE.MouseLeave += new System.EventHandler(this.rbtnIE_MouseLeave);
            this.rbtnIE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnIE_MouseMove);
            // 
            // rbtnCNPJ
            // 
            this.rbtnCNPJ.AutoSize = true;
            this.rbtnCNPJ.Location = new System.Drawing.Point(197, 42);
            this.rbtnCNPJ.Name = "rbtnCNPJ";
            this.rbtnCNPJ.Size = new System.Drawing.Size(52, 17);
            this.rbtnCNPJ.TabIndex = 6;
            this.rbtnCNPJ.TabStop = true;
            this.rbtnCNPJ.Text = "CNPJ";
            this.rbtnCNPJ.UseVisualStyleBackColor = true;
            this.rbtnCNPJ.CheckedChanged += new System.EventHandler(this.rbtnCNPJ_CheckedChanged);
            this.rbtnCNPJ.MouseLeave += new System.EventHandler(this.rbtnCNPJ_MouseLeave);
            this.rbtnCNPJ.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCNPJ_MouseMove);
            // 
            // rbtnPalavraChave
            // 
            this.rbtnPalavraChave.AutoSize = true;
            this.rbtnPalavraChave.Location = new System.Drawing.Point(369, 42);
            this.rbtnPalavraChave.Name = "rbtnPalavraChave";
            this.rbtnPalavraChave.Size = new System.Drawing.Size(95, 17);
            this.rbtnPalavraChave.TabIndex = 8;
            this.rbtnPalavraChave.TabStop = true;
            this.rbtnPalavraChave.Text = "Palavra-Chave";
            this.rbtnPalavraChave.UseVisualStyleBackColor = true;
            this.rbtnPalavraChave.CheckedChanged += new System.EventHandler(this.rbtnPalavraChave_CheckedChanged);
            this.rbtnPalavraChave.MouseLeave += new System.EventHandler(this.rbtnPalavraChave_MouseLeave);
            this.rbtnPalavraChave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPalavraChave_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Location = new System.Drawing.Point(470, 42);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 9;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // rbtnCPFResponsavel
            // 
            this.rbtnCPFResponsavel.AutoSize = true;
            this.rbtnCPFResponsavel.Location = new System.Drawing.Point(255, 42);
            this.rbtnCPFResponsavel.Name = "rbtnCPFResponsavel";
            this.rbtnCPFResponsavel.Size = new System.Drawing.Size(108, 17);
            this.rbtnCPFResponsavel.TabIndex = 7;
            this.rbtnCPFResponsavel.TabStop = true;
            this.rbtnCPFResponsavel.Text = "CPF (Pai ou Mãe)";
            this.rbtnCPFResponsavel.UseVisualStyleBackColor = true;
            this.rbtnCPFResponsavel.CheckedChanged += new System.EventHandler(this.rbtnCPFResponsavel_CheckedChanged);
            this.rbtnCPFResponsavel.MouseLeave += new System.EventHandler(this.rbtnCPFResponsavel_MouseLeave);
            this.rbtnCPFResponsavel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCPFResponsavel_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(693, 44);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 35;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(719, 44);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(85, 32);
            this.btnPesquisar.TabIndex = 15;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCliente.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Location = new System.Drawing.Point(133, 19);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 2;
            this.rbtnCodigo.TabStop = true;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // rbtnNomeAluno
            // 
            this.rbtnNomeAluno.AutoSize = true;
            this.rbtnNomeAluno.Location = new System.Drawing.Point(6, 19);
            this.rbtnNomeAluno.Name = "rbtnNomeAluno";
            this.rbtnNomeAluno.Size = new System.Drawing.Size(121, 17);
            this.rbtnNomeAluno.TabIndex = 1;
            this.rbtnNomeAluno.Text = "Nome/Razão Social";
            this.rbtnNomeAluno.UseVisualStyleBackColor = true;
            this.rbtnNomeAluno.CheckedChanged += new System.EventHandler(this.rbtnNomeAluno_CheckedChanged);
            this.rbtnNomeAluno.MouseLeave += new System.EventHandler(this.rbtnNomeAluno_MouseLeave);
            this.rbtnNomeAluno.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnNomeAluno_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(348, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(163, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite o nome/razão social:";
            // 
            // rbtnRG
            // 
            this.rbtnRG.AutoSize = true;
            this.rbtnRG.Location = new System.Drawing.Point(133, 42);
            this.rbtnRG.Name = "rbtnRG";
            this.rbtnRG.Size = new System.Drawing.Size(41, 17);
            this.rbtnRG.TabIndex = 5;
            this.rbtnRG.TabStop = true;
            this.rbtnRG.Text = "RG";
            this.rbtnRG.UseVisualStyleBackColor = true;
            this.rbtnRG.CheckedChanged += new System.EventHandler(this.rbtnRG_CheckedChanged);
            this.rbtnRG.MouseLeave += new System.EventHandler(this.rbtnRG_MouseLeave);
            this.rbtnRG.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnRG_MouseMove);
            // 
            // rbtnCPF
            // 
            this.rbtnCPF.AutoSize = true;
            this.rbtnCPF.Location = new System.Drawing.Point(197, 19);
            this.rbtnCPF.Name = "rbtnCPF";
            this.rbtnCPF.Size = new System.Drawing.Size(45, 17);
            this.rbtnCPF.TabIndex = 3;
            this.rbtnCPF.TabStop = true;
            this.rbtnCPF.Text = "CPF";
            this.rbtnCPF.UseVisualStyleBackColor = true;
            this.rbtnCPF.CheckedChanged += new System.EventHandler(this.rbtnCPF_CheckedChanged);
            this.rbtnCPF.MouseLeave += new System.EventHandler(this.rbtnCPF_MouseLeave);
            this.rbtnCPF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCPF_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(726, 18);
            this.txtpCodigo.MaxLength = 10;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(78, 20);
            this.txtpCodigo.TabIndex = 14;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // mtxtpCPF
            // 
            this.mtxtpCPF.BackColor = System.Drawing.Color.White;
            this.mtxtpCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpCPF.Location = new System.Drawing.Point(709, 18);
            this.mtxtpCPF.Mask = "000,000,000-00";
            this.mtxtpCPF.Name = "mtxtpCPF";
            this.mtxtpCPF.Size = new System.Drawing.Size(95, 20);
            this.mtxtpCPF.TabIndex = 13;
            this.mtxtpCPF.Visible = false;
            this.mtxtpCPF.Enter += new System.EventHandler(this.mtxtpCPF_Enter);
            this.mtxtpCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpCPF_KeyPress);
            this.mtxtpCPF.Leave += new System.EventHandler(this.mtxtpCPF_Leave);
            // 
            // mtxtpCelular
            // 
            this.mtxtpCelular.BackColor = System.Drawing.Color.White;
            this.mtxtpCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpCelular.Location = new System.Drawing.Point(704, 18);
            this.mtxtpCelular.Mask = "(00) 00000-0000";
            this.mtxtpCelular.Name = "mtxtpCelular";
            this.mtxtpCelular.Size = new System.Drawing.Size(100, 20);
            this.mtxtpCelular.TabIndex = 12;
            this.mtxtpCelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtpCelular.Visible = false;
            this.mtxtpCelular.Enter += new System.EventHandler(this.mtxtpCelular_Enter);
            this.mtxtpCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpCelular_KeyPress);
            this.mtxtpCelular.Leave += new System.EventHandler(this.mtxtpCelular_Leave);
            // 
            // mtxtpTelefone
            // 
            this.mtxtpTelefone.BackColor = System.Drawing.Color.White;
            this.mtxtpTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpTelefone.Location = new System.Drawing.Point(710, 18);
            this.mtxtpTelefone.Mask = "(00) 0000-0000";
            this.mtxtpTelefone.Name = "mtxtpTelefone";
            this.mtxtpTelefone.Size = new System.Drawing.Size(94, 20);
            this.mtxtpTelefone.TabIndex = 11;
            this.mtxtpTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtpTelefone.Visible = false;
            this.mtxtpTelefone.Enter += new System.EventHandler(this.mtxtpTelefone_Enter);
            this.mtxtpTelefone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpTelefone_KeyPress);
            this.mtxtpTelefone.Leave += new System.EventHandler(this.mtxtpTelefone_Leave);
            // 
            // txtpRG
            // 
            this.txtpRG.BackColor = System.Drawing.Color.White;
            this.txtpRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpRG.Location = new System.Drawing.Point(684, 18);
            this.txtpRG.MaxLength = 20;
            this.txtpRG.Name = "txtpRG";
            this.txtpRG.Size = new System.Drawing.Size(120, 20);
            this.txtpRG.TabIndex = 11;
            this.txtpRG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpRG.Visible = false;
            this.txtpRG.Enter += new System.EventHandler(this.txtpRG_Enter);
            this.txtpRG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpRG_KeyPress);
            this.txtpRG.Leave += new System.EventHandler(this.txtpRG_Leave);
            // 
            // txtpNome
            // 
            this.txtpNome.BackColor = System.Drawing.Color.White;
            this.txtpNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpNome.Location = new System.Drawing.Point(517, 18);
            this.txtpNome.MaxLength = 60;
            this.txtpNome.Name = "txtpNome";
            this.txtpNome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpNome.Size = new System.Drawing.Size(286, 20);
            this.txtpNome.TabIndex = 10;
            this.txtpNome.Enter += new System.EventHandler(this.txtpNome_Enter);
            this.txtpNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpNome_KeyPress);
            this.txtpNome.Leave += new System.EventHandler(this.txtpNome_Leave);
            // 
            // mtxtpCNPJ
            // 
            this.mtxtpCNPJ.BackColor = System.Drawing.Color.White;
            this.mtxtpCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.mtxtpCNPJ.Location = new System.Drawing.Point(681, 18);
            this.mtxtpCNPJ.Mask = "00,000,000/0000-00";
            this.mtxtpCNPJ.Name = "mtxtpCNPJ";
            this.mtxtpCNPJ.Size = new System.Drawing.Size(123, 20);
            this.mtxtpCNPJ.TabIndex = 14;
            this.mtxtpCNPJ.Visible = false;
            this.mtxtpCNPJ.Enter += new System.EventHandler(this.mtxtpCNPJ_Enter);
            this.mtxtpCNPJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpCNPJ_KeyPress);
            this.mtxtpCNPJ.Leave += new System.EventHandler(this.mtxtpCNPJ_Leave);
            // 
            // txtpPalavraChave
            // 
            this.txtpPalavraChave.BackColor = System.Drawing.Color.White;
            this.txtpPalavraChave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpPalavraChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpPalavraChave.Location = new System.Drawing.Point(726, 18);
            this.txtpPalavraChave.MaxLength = 10;
            this.txtpPalavraChave.Name = "txtpPalavraChave";
            this.txtpPalavraChave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpPalavraChave.Size = new System.Drawing.Size(78, 20);
            this.txtpPalavraChave.TabIndex = 11;
            this.txtpPalavraChave.Visible = false;
            this.txtpPalavraChave.Enter += new System.EventHandler(this.txtpPalavraChave_Enter);
            this.txtpPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpPalavraChave_KeyPress);
            this.txtpPalavraChave.Leave += new System.EventHandler(this.txtpPalavraChave_Leave);
            // 
            // dtClie
            // 
            this.dtClie.AllowUserToAddRows = false;
            this.dtClie.AllowUserToDeleteRows = false;
            this.dtClie.AllowUserToOrderColumns = true;
            this.dtClie.AllowUserToResizeRows = false;
            this.dtClie.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtClie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtClie.Enabled = false;
            this.dtClie.Location = new System.Drawing.Point(173, 98);
            this.dtClie.MultiSelect = false;
            this.dtClie.Name = "dtClie";
            this.dtClie.ReadOnly = true;
            this.dtClie.RowHeadersVisible = false;
            this.dtClie.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtClie.ShowCellErrors = false;
            this.dtClie.ShowCellToolTips = false;
            this.dtClie.ShowEditingIcon = false;
            this.dtClie.ShowRowErrors = false;
            this.dtClie.Size = new System.Drawing.Size(649, 172);
            this.dtClie.TabIndex = 16;
            this.dtClie.DataSourceChanged += new System.EventHandler(this.dtClie_DataSourceChanged);
            this.dtClie.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtClie_CellEnter);
            this.dtClie.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtClie_RowsAdded);
            this.dtClie.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtClie_RowsRemoved);
            this.dtClie.DoubleClick += new System.EventHandler(this.dtClie_DoubleClick);
            this.dtClie.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtClie_KeyDown);
            this.dtClie.MouseLeave += new System.EventHandler(this.dtClie_MouseLeave);
            this.dtClie.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtClie_MouseMove);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Enabled = false;
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(691, 276);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(70, 32);
            this.btnIncluir.TabIndex = 18;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCliente.SetToolTip(this.btnIncluir, "Clique para incluir os dados.");
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            this.btnIncluir.MouseLeave += new System.EventHandler(this.btnIncluir_MouseLeave);
            this.btnIncluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnIncluir_MouseMove);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(767, 276);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 19;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCliente.SetToolTip(this.btnVoltar, "Sair do Pesquisar Consumidor.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // ttpCliente
            // 
            this.ttpCliente.AutoPopDelay = 5000;
            this.ttpCliente.InitialDelay = 1000;
            this.ttpCliente.IsBalloon = true;
            this.ttpCliente.ReshowDelay = 100;
            this.ttpCliente.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpCliente.ToolTipTitle = "Dica:";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastrar.Image")));
            this.btnCadastrar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCadastrar.Location = new System.Drawing.Point(599, 276);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(86, 32);
            this.btnCadastrar.TabIndex = 17;
            this.btnCadastrar.Text = "&Cadastrar";
            this.btnCadastrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCliente.SetToolTip(this.btnCadastrar, "Clique para cadastrar um Consumidor.");
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Visible = false;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            this.btnCadastrar.MouseLeave += new System.EventHandler(this.btnCadastrar_MouseLeave);
            this.btnCadastrar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCadastrar_MouseMove);
            // 
            // FrmPesqConsumidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(834, 313);
            this.ControlBox = false;
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.pcibAjudaFoto);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.lblLegendaImagem);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.pcibImagem);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.dtClie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesqConsumidor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Consumidor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPesqCliente_FormClosing);
            this.Load += new System.EventHandler(this.FrmPesqCliente_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPesqCliente_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pcibAjudaFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagem)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtClie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcibAjudaFoto;
        private System.Windows.Forms.Label lblLegendaImagem;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.PictureBox pcibImagem;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnIE;
        private System.Windows.Forms.RadioButton rbtnCNPJ;
        private System.Windows.Forms.RadioButton rbtnPalavraChave;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnCPFResponsavel;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnNomeAluno;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.RadioButton rbtnRG;
        private System.Windows.Forms.RadioButton rbtnCPF;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.MaskedTextBox mtxtpCPF;
        private System.Windows.Forms.TextBox txtpPalavraChave;
        private System.Windows.Forms.MaskedTextBox mtxtpCelular;
        private System.Windows.Forms.MaskedTextBox mtxtpTelefone;
        private System.Windows.Forms.TextBox txtpRG;
        private System.Windows.Forms.TextBox txtpNome;
        private System.Windows.Forms.MaskedTextBox mtxtpCNPJ;
        private System.Windows.Forms.DataGridView dtClie;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.ToolTip ttpCliente;
        private System.Windows.Forms.Button btnCadastrar;
    }
}