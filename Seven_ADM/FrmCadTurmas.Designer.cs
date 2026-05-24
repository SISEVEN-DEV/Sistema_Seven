namespace SIE_7_Sistema
{
    partial class FrmCadTurmas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadTurmas));
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.lblQtdAluno = new System.Windows.Forms.Label();
            this.grbBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mtxtDataInicio = new System.Windows.Forms.MaskedTextBox();
            this.lblDataFim = new System.Windows.Forms.Label();
            this.mtxtDataFim = new System.Windows.Forms.MaskedTextBox();
            this.lblDataIni = new System.Windows.Forms.Label();
            this.lblInAtivo = new System.Windows.Forms.Label();
            this.cbbInAtivo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeTurma = new System.Windows.Forms.TextBox();
            this.cbbNomeCurso = new System.Windows.Forms.ComboBox();
            this.txtQtdeAluno = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblQtdeAluno = new System.Windows.Forms.Label();
            this.lblProfessor = new System.Windows.Forms.Label();
            this.lblLocal = new System.Windows.Forms.Label();
            this.cbbLocal = new System.Windows.Forms.ComboBox();
            this.lblNomeTurma = new System.Windows.Forms.Label();
            this.txtProfessor = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.dtTurma = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnNomeProf = new System.Windows.Forms.RadioButton();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnNomeTurma = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.rbtnDia = new System.Windows.Forms.RadioButton();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.cbbpDiaSemana = new System.Windows.Forms.ComboBox();
            this.txtpNome = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.grbBox2.SuspendLayout();
            this.grbBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTurma)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.lblQtdAluno);
            this.grbBox2.Controls.Add(this.grbBox3);
            this.grbBox2.Controls.Add(this.lblInAtivo);
            this.grbBox2.Controls.Add(this.cbbInAtivo);
            this.grbBox2.Controls.Add(this.label2);
            this.grbBox2.Controls.Add(this.txtNomeTurma);
            this.grbBox2.Controls.Add(this.cbbNomeCurso);
            this.grbBox2.Controls.Add(this.txtQtdeAluno);
            this.grbBox2.Controls.Add(this.lblCodigo);
            this.grbBox2.Controls.Add(this.lblQtdeAluno);
            this.grbBox2.Controls.Add(this.lblProfessor);
            this.grbBox2.Controls.Add(this.lblLocal);
            this.grbBox2.Controls.Add(this.cbbLocal);
            this.grbBox2.Controls.Add(this.lblNomeTurma);
            this.grbBox2.Controls.Add(this.txtProfessor);
            this.grbBox2.Controls.Add(this.txtCodigo);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(12, 253);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(866, 163);
            this.grbBox2.TabIndex = 50;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Cadastrar, alterar, excluir e visualizar dados:";
            // 
            // lblQtdAluno
            // 
            this.lblQtdAluno.AutoSize = true;
            this.lblQtdAluno.Location = new System.Drawing.Point(307, 114);
            this.lblQtdAluno.Name = "lblQtdAluno";
            this.lblQtdAluno.Size = new System.Drawing.Size(71, 13);
            this.lblQtdAluno.TabIndex = 29;
            this.lblQtdAluno.Text = "Qtde. Alunos:";
            // 
            // grbBox3
            // 
            this.grbBox3.Controls.Add(this.pictureBox1);
            this.grbBox3.Controls.Add(this.mtxtDataInicio);
            this.grbBox3.Controls.Add(this.lblDataFim);
            this.grbBox3.Controls.Add(this.mtxtDataFim);
            this.grbBox3.Controls.Add(this.lblDataIni);
            this.grbBox3.Location = new System.Drawing.Point(6, 98);
            this.grbBox3.Name = "grbBox3";
            this.grbBox3.Size = new System.Drawing.Size(195, 60);
            this.grbBox3.TabIndex = 28;
            this.grbBox3.TabStop = false;
            this.grbBox3.Text = "Início e Términio da turma:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(169, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 80;
            this.pictureBox1.TabStop = false;
            // 
            // mtxtDataInicio
            // 
            this.mtxtDataInicio.Location = new System.Drawing.Point(6, 32);
            this.mtxtDataInicio.Mask = "00,00,0000";
            this.mtxtDataInicio.Name = "mtxtDataInicio";
            this.mtxtDataInicio.Size = new System.Drawing.Size(60, 20);
            this.mtxtDataInicio.TabIndex = 16;
            // 
            // lblDataFim
            // 
            this.lblDataFim.AutoSize = true;
            this.lblDataFim.Location = new System.Drawing.Point(84, 16);
            this.lblDataFim.Name = "lblDataFim";
            this.lblDataFim.Size = new System.Drawing.Size(89, 13);
            this.lblDataFim.TabIndex = 24;
            this.lblDataFim.Text = "Data de termínio:";
            // 
            // mtxtDataFim
            // 
            this.mtxtDataFim.Location = new System.Drawing.Point(87, 31);
            this.mtxtDataFim.Mask = "00,00,0000";
            this.mtxtDataFim.Name = "mtxtDataFim";
            this.mtxtDataFim.Size = new System.Drawing.Size(60, 20);
            this.mtxtDataFim.TabIndex = 25;
            // 
            // lblDataIni
            // 
            this.lblDataIni.AutoSize = true;
            this.lblDataIni.Location = new System.Drawing.Point(3, 16);
            this.lblDataIni.Name = "lblDataIni";
            this.lblDataIni.Size = new System.Drawing.Size(78, 13);
            this.lblDataIni.TabIndex = 17;
            this.lblDataIni.Text = "Data de Início:";
            // 
            // lblInAtivo
            // 
            this.lblInAtivo.AutoSize = true;
            this.lblInAtivo.Location = new System.Drawing.Point(207, 114);
            this.lblInAtivo.Name = "lblInAtivo";
            this.lblInAtivo.Size = new System.Drawing.Size(71, 13);
            this.lblInAtivo.TabIndex = 27;
            this.lblInAtivo.Text = "Ativo/Inativo:";
            // 
            // cbbInAtivo
            // 
            this.cbbInAtivo.BackColor = System.Drawing.Color.Coral;
            this.cbbInAtivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbInAtivo.FormattingEnabled = true;
            this.cbbInAtivo.Location = new System.Drawing.Point(210, 130);
            this.cbbInAtivo.Name = "cbbInAtivo";
            this.cbbInAtivo.Size = new System.Drawing.Size(94, 21);
            this.cbbInAtivo.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(492, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Nome da turma:";
            // 
            // txtNomeTurma
            // 
            this.txtNomeTurma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeTurma.Location = new System.Drawing.Point(495, 33);
            this.txtNomeTurma.MaxLength = 100;
            this.txtNomeTurma.Name = "txtNomeTurma";
            this.txtNomeTurma.Size = new System.Drawing.Size(357, 20);
            this.txtNomeTurma.TabIndex = 21;
            // 
            // cbbNomeCurso
            // 
            this.cbbNomeCurso.BackColor = System.Drawing.Color.LightSalmon;
            this.cbbNomeCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNomeCurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNomeCurso.FormattingEnabled = true;
            this.cbbNomeCurso.Location = new System.Drawing.Point(89, 32);
            this.cbbNomeCurso.Name = "cbbNomeCurso";
            this.cbbNomeCurso.Size = new System.Drawing.Size(400, 21);
            this.cbbNomeCurso.TabIndex = 18;
            // 
            // txtQtdeAluno
            // 
            this.txtQtdeAluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtdeAluno.Location = new System.Drawing.Point(310, 130);
            this.txtQtdeAluno.MaxLength = 5;
            this.txtQtdeAluno.Name = "txtQtdeAluno";
            this.txtQtdeAluno.Size = new System.Drawing.Size(90, 20);
            this.txtQtdeAluno.TabIndex = 15;
            this.txtQtdeAluno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtdeAluno.Enter += new System.EventHandler(this.txtQtdeAluno_Enter);
            this.txtQtdeAluno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtdeAluno_KeyPress);
            this.txtQtdeAluno.Leave += new System.EventHandler(this.txtQtdeAluno_Leave);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 14;
            this.lblCodigo.Text = "Código:";
            // 
            // lblQtdeAluno
            // 
            this.lblQtdeAluno.AutoSize = true;
            this.lblQtdeAluno.Location = new System.Drawing.Point(653, 40);
            this.lblQtdeAluno.Name = "lblQtdeAluno";
            this.lblQtdeAluno.Size = new System.Drawing.Size(90, 13);
            this.lblQtdeAluno.TabIndex = 13;
            this.lblQtdeAluno.Text = "Qtd. de Alunos:  *";
            // 
            // lblProfessor
            // 
            this.lblProfessor.AutoSize = true;
            this.lblProfessor.Location = new System.Drawing.Point(434, 56);
            this.lblProfessor.Name = "lblProfessor";
            this.lblProfessor.Size = new System.Drawing.Size(107, 13);
            this.lblProfessor.TabIndex = 12;
            this.lblProfessor.Text = "Professor/Instrutor:  *";
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Location = new System.Drawing.Point(6, 56);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(46, 13);
            this.lblLocal.TabIndex = 8;
            this.lblLocal.Text = "Local:  *";
            // 
            // cbbLocal
            // 
            this.cbbLocal.BackColor = System.Drawing.Color.LightSalmon;
            this.cbbLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLocal.FormattingEnabled = true;
            this.cbbLocal.Location = new System.Drawing.Point(6, 71);
            this.cbbLocal.Name = "cbbLocal";
            this.cbbLocal.Size = new System.Drawing.Size(425, 21);
            this.cbbLocal.TabIndex = 7;
            this.cbbLocal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbLocal_KeyPress);
            this.cbbLocal.MouseLeave += new System.EventHandler(this.cbbLocal_MouseLeave);
            this.cbbLocal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbLocal_MouseMove);
            // 
            // lblNomeTurma
            // 
            this.lblNomeTurma.AutoSize = true;
            this.lblNomeTurma.Location = new System.Drawing.Point(86, 16);
            this.lblNomeTurma.Name = "lblNomeTurma";
            this.lblNomeTurma.Size = new System.Drawing.Size(93, 13);
            this.lblNomeTurma.TabIndex = 6;
            this.lblNomeTurma.Text = "Nome do Curso:  *";
            // 
            // txtProfessor
            // 
            this.txtProfessor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProfessor.Location = new System.Drawing.Point(437, 71);
            this.txtProfessor.MaxLength = 100;
            this.txtProfessor.Name = "txtProfessor";
            this.txtProfessor.Size = new System.Drawing.Size(415, 20);
            this.txtProfessor.TabIndex = 4;
            this.txtProfessor.Enter += new System.EventHandler(this.txtProfessor_Enter);
            this.txtProfessor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProfessor_KeyPress);
            this.txtProfessor.Leave += new System.EventHandler(this.txtProfessor_Leave);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(6, 32);
            this.txtCodigo.MaxLength = 10;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(77, 20);
            this.txtCodigo.TabIndex = 3;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtTurma
            // 
            this.dtTurma.AllowUserToAddRows = false;
            this.dtTurma.AllowUserToDeleteRows = false;
            this.dtTurma.AllowUserToResizeColumns = false;
            this.dtTurma.AllowUserToResizeRows = false;
            this.dtTurma.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtTurma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtTurma.Location = new System.Drawing.Point(12, 97);
            this.dtTurma.MultiSelect = false;
            this.dtTurma.Name = "dtTurma";
            this.dtTurma.ReadOnly = true;
            this.dtTurma.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtTurma.ShowCellErrors = false;
            this.dtTurma.ShowCellToolTips = false;
            this.dtTurma.ShowEditingIcon = false;
            this.dtTurma.ShowRowErrors = false;
            this.dtTurma.Size = new System.Drawing.Size(866, 150);
            this.dtTurma.TabIndex = 48;
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnNomeProf);
            this.grbBox1.Controls.Add(this.picbInterrogacao1);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnNomeTurma);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.rbtnDia);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.cbbpDiaSemana);
            this.grbBox1.Controls.Add(this.txtpNome);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(866, 79);
            this.grbBox1.TabIndex = 47;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Location = new System.Drawing.Point(70, 42);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 37;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // rbtnNomeProf
            // 
            this.rbtnNomeProf.AutoSize = true;
            this.rbtnNomeProf.Location = new System.Drawing.Point(109, 19);
            this.rbtnNomeProf.Name = "rbtnNomeProf";
            this.rbtnNomeProf.Size = new System.Drawing.Size(114, 17);
            this.rbtnNomeProf.TabIndex = 36;
            this.rbtnNomeProf.Text = "Nome do professor";
            this.rbtnNomeProf.UseVisualStyleBackColor = true;
            this.rbtnNomeProf.CheckedChanged += new System.EventHandler(this.rbtnNomeProf_CheckedChanged);
            this.rbtnNomeProf.MouseLeave += new System.EventHandler(this.rbtnNomeProf_MouseLeave);
            this.rbtnNomeProf.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnNomeProf_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(502, 42);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 35;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(778, 44);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 30);
            this.btnPesquisar.TabIndex = 15;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Location = new System.Drawing.Point(6, 42);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 3;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            this.rbtnCodigo.CheckedChanged += new System.EventHandler(this.rbtnCodigo_CheckedChanged);
            this.rbtnCodigo.MouseLeave += new System.EventHandler(this.rbtnCodigo_MouseLeave);
            this.rbtnCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnCodigo_MouseMove);
            // 
            // rbtnNomeTurma
            // 
            this.rbtnNomeTurma.AutoSize = true;
            this.rbtnNomeTurma.Checked = true;
            this.rbtnNomeTurma.Location = new System.Drawing.Point(6, 19);
            this.rbtnNomeTurma.Name = "rbtnNomeTurma";
            this.rbtnNomeTurma.Size = new System.Drawing.Size(97, 17);
            this.rbtnNomeTurma.TabIndex = 2;
            this.rbtnNomeTurma.TabStop = true;
            this.rbtnNomeTurma.Text = "Nome da turma";
            this.rbtnNomeTurma.UseVisualStyleBackColor = true;
            this.rbtnNomeTurma.CheckedChanged += new System.EventHandler(this.rbtnNomeTurma_CheckedChanged);
            this.rbtnNomeTurma.MouseLeave += new System.EventHandler(this.rbtnNomeTurma_MouseLeave);
            this.rbtnNomeTurma.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnNomeTurma_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(352, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(144, 13);
            this.lblPesquisar.TabIndex = 9;
            this.lblPesquisar.Text = "Digite o Nome da turma:";
            // 
            // rbtnDia
            // 
            this.rbtnDia.AutoSize = true;
            this.rbtnDia.Location = new System.Drawing.Point(228, 19);
            this.rbtnDia.Name = "rbtnDia";
            this.rbtnDia.Size = new System.Drawing.Size(96, 17);
            this.rbtnDia.TabIndex = 5;
            this.rbtnDia.Text = "Dia da semana";
            this.rbtnDia.UseVisualStyleBackColor = true;
            this.rbtnDia.CheckedChanged += new System.EventHandler(this.rbtnDia_CheckedChanged);
            this.rbtnDia.MouseLeave += new System.EventHandler(this.rbtnDia_MouseLeave);
            this.rbtnDia.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnDia_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(783, 18);
            this.txtpCodigo.MaxLength = 10;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(77, 20);
            this.txtpCodigo.TabIndex = 14;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // cbbpDiaSemana
            // 
            this.cbbpDiaSemana.BackColor = System.Drawing.Color.LightSalmon;
            this.cbbpDiaSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpDiaSemana.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpDiaSemana.FormattingEnabled = true;
            this.cbbpDiaSemana.Items.AddRange(new object[] {
            "DOMINGO",
            "SEGUNDA",
            "TERÇA",
            "QUARTA",
            "QUINTA",
            "SEXTA",
            "SÁBADO"});
            this.cbbpDiaSemana.Location = new System.Drawing.Point(730, 18);
            this.cbbpDiaSemana.Name = "cbbpDiaSemana";
            this.cbbpDiaSemana.Size = new System.Drawing.Size(130, 21);
            this.cbbpDiaSemana.TabIndex = 16;
            this.cbbpDiaSemana.Visible = false;
            this.cbbpDiaSemana.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpDiaSemana_KeyPress);
            this.cbbpDiaSemana.MouseLeave += new System.EventHandler(this.cbbpDiaSemana_MouseLeave);
            this.cbbpDiaSemana.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpDiaSemana_MouseMove);
            // 
            // txtpNome
            // 
            this.txtpNome.BackColor = System.Drawing.Color.White;
            this.txtpNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpNome.Location = new System.Drawing.Point(502, 18);
            this.txtpNome.MaxLength = 100;
            this.txtpNome.Name = "txtpNome";
            this.txtpNome.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpNome.Size = new System.Drawing.Size(358, 20);
            this.txtpNome.TabIndex = 10;
            this.txtpNome.Enter += new System.EventHandler(this.txtpNome_Enter);
            this.txtpNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpNome_KeyPress);
            this.txtpNome.Leave += new System.EventHandler(this.txtpNome_Leave);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(823, 422);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 35);
            this.btnSair.TabIndex = 79;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.Location = new System.Drawing.Point(449, 422);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 35);
            this.btnCancelar.TabIndex = 77;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnSalvar.Location = new System.Drawing.Point(540, 422);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 35);
            this.btnSalvar.TabIndex = 78;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.Location = new System.Drawing.Point(12, 422);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 73;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExcluir.Location = new System.Drawing.Point(190, 422);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(70, 35);
            this.btnExcluir.TabIndex = 76;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnAlterar.Location = new System.Drawing.Point(114, 422);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 35);
            this.btnAlterar.TabIndex = 75;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnAlterar.MouseLeave += new System.EventHandler(this.btnAlterar_MouseLeave);
            this.btnAlterar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterar_MouseMove);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNovo.Location = new System.Drawing.Point(38, 422);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 35);
            this.btnNovo.TabIndex = 74;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
            // 
            // FrmCadTurmas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(890, 463);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.picbInterrogacao2);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.grbBox2);
            this.Controls.Add(this.dtTurma);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "FrmCadTurmas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Turmas";
            this.Load += new System.EventHandler(this.FrmCadTurmas_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadTurmas_KeyUp);
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            this.grbBox3.ResumeLayout(false);
            this.grbBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTurma)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.DataGridView dtTurma;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnDia;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnNomeTurma;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.TextBox txtpNome;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.TextBox txtQtdeAluno;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblQtdeAluno;
        private System.Windows.Forms.Label lblProfessor;
        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.ComboBox cbbLocal;
        private System.Windows.Forms.Label lblNomeTurma;
        private System.Windows.Forms.TextBox txtProfessor;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.RadioButton rbtnNomeProf;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.ComboBox cbbpDiaSemana;
        private System.Windows.Forms.ComboBox cbbNomeCurso;
        private System.Windows.Forms.Label lblDataIni;
        private System.Windows.Forms.MaskedTextBox mtxtDataInicio;
        private System.Windows.Forms.Label lblInAtivo;
        private System.Windows.Forms.ComboBox cbbInAtivo;
        private System.Windows.Forms.MaskedTextBox mtxtDataFim;
        private System.Windows.Forms.Label lblDataFim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeTurma;
        private System.Windows.Forms.GroupBox grbBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblQtdAluno;
    }
}