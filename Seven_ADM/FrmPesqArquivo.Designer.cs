namespace SIE_7_Sistema
{
    partial class FrmPesqArquivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesqArquivo));
            this.dtArquivo = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnPalavraChave = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnNomeAluno = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.txtpPalavraChave = new System.Windows.Forms.TextBox();
            this.cbbpTipoTabela = new System.Windows.Forms.ComboBox();
            this.txtpDescricao = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnAbrirArquivo = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.pcibInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.ttpArquivo = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtArquivo)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao2)).BeginInit();
            this.SuspendLayout();
            // 
            // dtArquivo
            // 
            this.dtArquivo.AllowUserToAddRows = false;
            this.dtArquivo.AllowUserToDeleteRows = false;
            this.dtArquivo.AllowUserToOrderColumns = true;
            this.dtArquivo.AllowUserToResizeRows = false;
            this.dtArquivo.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtArquivo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtArquivo.Location = new System.Drawing.Point(12, 99);
            this.dtArquivo.MultiSelect = false;
            this.dtArquivo.Name = "dtArquivo";
            this.dtArquivo.ReadOnly = true;
            this.dtArquivo.RowHeadersVisible = false;
            this.dtArquivo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtArquivo.ShowCellErrors = false;
            this.dtArquivo.ShowCellToolTips = false;
            this.dtArquivo.ShowEditingIcon = false;
            this.dtArquivo.ShowRowErrors = false;
            this.dtArquivo.Size = new System.Drawing.Size(690, 128);
            this.dtArquivo.TabIndex = 11;
            this.dtArquivo.DataSourceChanged += new System.EventHandler(this.dtArquivo_DataSourceChanged);
            this.dtArquivo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtArquivo_CellEnter);
            this.dtArquivo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtArquivo_RowsAdded);
            this.dtArquivo.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtArquivo_RowsRemoved);
            this.dtArquivo.MouseLeave += new System.EventHandler(this.dtArquivo_MouseLeave);
            this.dtArquivo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtArquivo_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnPalavraChave);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.picbInterrogacao1);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnNomeAluno);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.txtpPalavraChave);
            this.grbBox1.Controls.Add(this.cbbpTipoTabela);
            this.grbBox1.Controls.Add(this.txtpDescricao);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(690, 81);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnPalavraChave
            // 
            this.rbtnPalavraChave.AutoSize = true;
            this.rbtnPalavraChave.Location = new System.Drawing.Point(149, 19);
            this.rbtnPalavraChave.Name = "rbtnPalavraChave";
            this.rbtnPalavraChave.Size = new System.Drawing.Size(94, 17);
            this.rbtnPalavraChave.TabIndex = 4;
            this.rbtnPalavraChave.TabStop = true;
            this.rbtnPalavraChave.Text = "Palavra-chave";
            this.rbtnPalavraChave.UseVisualStyleBackColor = true;
            this.rbtnPalavraChave.CheckedChanged += new System.EventHandler(this.rbtnPalavraChave_CheckedChanged);
            this.rbtnPalavraChave.MouseLeave += new System.EventHandler(this.rbtnPalavraChave_MouseLeave);
            this.rbtnPalavraChave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPalavraChave_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.Location = new System.Drawing.Point(6, 42);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 5;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(573, 44);
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
            this.btnPesquisar.Location = new System.Drawing.Point(599, 44);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(85, 32);
            this.btnPesquisar.TabIndex = 10;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpArquivo.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.Location = new System.Drawing.Point(85, 19);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 3;
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
            this.rbtnNomeAluno.Checked = true;
            this.rbtnNomeAluno.Location = new System.Drawing.Point(6, 19);
            this.rbtnNomeAluno.Name = "rbtnNomeAluno";
            this.rbtnNomeAluno.Size = new System.Drawing.Size(73, 17);
            this.rbtnNomeAluno.TabIndex = 2;
            this.rbtnNomeAluno.TabStop = true;
            this.rbtnNomeAluno.Text = "Descrição";
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
            this.lblPesquisar.Location = new System.Drawing.Point(249, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(114, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite a descrição:";
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(642, 18);
            this.txtpCodigo.MaxLength = 5;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(42, 20);
            this.txtpCodigo.TabIndex = 9;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // txtpPalavraChave
            // 
            this.txtpPalavraChave.BackColor = System.Drawing.Color.White;
            this.txtpPalavraChave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpPalavraChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpPalavraChave.Location = new System.Drawing.Point(606, 18);
            this.txtpPalavraChave.MaxLength = 10;
            this.txtpPalavraChave.Name = "txtpPalavraChave";
            this.txtpPalavraChave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpPalavraChave.Size = new System.Drawing.Size(78, 20);
            this.txtpPalavraChave.TabIndex = 8;
            this.txtpPalavraChave.Visible = false;
            this.txtpPalavraChave.Enter += new System.EventHandler(this.txtpPalavraChave_Enter);
            this.txtpPalavraChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpPalavraChave_KeyPress);
            this.txtpPalavraChave.Leave += new System.EventHandler(this.txtpPalavraChave_Leave);
            // 
            // cbbpTipoTabela
            // 
            this.cbbpTipoTabela.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpTipoTabela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpTipoTabela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpTipoTabela.FormattingEnabled = true;
            this.cbbpTipoTabela.Items.AddRange(new object[] {
            "ALUNO",
            "FORNECEDOR",
            "FUNCIONARIO",
            "AMBAS"});
            this.cbbpTipoTabela.Location = new System.Drawing.Point(444, 18);
            this.cbbpTipoTabela.Name = "cbbpTipoTabela";
            this.cbbpTipoTabela.Size = new System.Drawing.Size(240, 21);
            this.cbbpTipoTabela.TabIndex = 7;
            this.cbbpTipoTabela.Visible = false;
            this.cbbpTipoTabela.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpTipoTabela_KeyPress);
            // 
            // txtpDescricao
            // 
            this.txtpDescricao.BackColor = System.Drawing.Color.White;
            this.txtpDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpDescricao.Location = new System.Drawing.Point(369, 18);
            this.txtpDescricao.MaxLength = 60;
            this.txtpDescricao.Name = "txtpDescricao";
            this.txtpDescricao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtpDescricao.Size = new System.Drawing.Size(315, 20);
            this.txtpDescricao.TabIndex = 6;
            this.txtpDescricao.Enter += new System.EventHandler(this.txtpDescricao_Enter);
            this.txtpDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpDescricao_KeyPress);
            this.txtpDescricao.Leave += new System.EventHandler(this.txtpDescricao_Leave);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(43, -48);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(55, 17);
            this.radioButton1.TabIndex = 28;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Todos";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // btnAbrirArquivo
            // 
            this.btnAbrirArquivo.Enabled = false;
            this.btnAbrirArquivo.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrirArquivo.Image")));
            this.btnAbrirArquivo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAbrirArquivo.Location = new System.Drawing.Point(541, 233);
            this.btnAbrirArquivo.Name = "btnAbrirArquivo";
            this.btnAbrirArquivo.Size = new System.Drawing.Size(100, 32);
            this.btnAbrirArquivo.TabIndex = 12;
            this.btnAbrirArquivo.Text = "A&brir Arquivo";
            this.btnAbrirArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpArquivo.SetToolTip(this.btnAbrirArquivo, "Abrir o arquivo contido na caixa de texto caminho do arquivo.");
            this.btnAbrirArquivo.UseVisualStyleBackColor = true;
            this.btnAbrirArquivo.Click += new System.EventHandler(this.btnAbrirArquivo_Click);
            this.btnAbrirArquivo.MouseLeave += new System.EventHandler(this.btnAbrirArquivo_MouseLeave);
            this.btnAbrirArquivo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAbrirArquivo_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSair.Location = new System.Drawing.Point(647, 233);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 13;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpArquivo.SetToolTip(this.btnSair, "Sair da pesquisa de arquivo.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(9, 230);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 31;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pcibInterrogacao2
            // 
            this.pcibInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao2.Image")));
            this.pcibInterrogacao2.Location = new System.Drawing.Point(515, 233);
            this.pcibInterrogacao2.Name = "pcibInterrogacao2";
            this.pcibInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao2.TabIndex = 36;
            this.pcibInterrogacao2.TabStop = false;
            this.pcibInterrogacao2.Click += new System.EventHandler(this.pcibInterrogacao2_Click);
            this.pcibInterrogacao2.MouseLeave += new System.EventHandler(this.pcibInterrogacao2_MouseLeave);
            this.pcibInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao2_MouseMove);
            // 
            // ttpArquivo
            // 
            this.ttpArquivo.AutoPopDelay = 5000;
            this.ttpArquivo.InitialDelay = 1000;
            this.ttpArquivo.IsBalloon = true;
            this.ttpArquivo.ReshowDelay = 100;
            this.ttpArquivo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpArquivo.ToolTipTitle = "Dica:";
            // 
            // FrmPesqArquivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(714, 277);
            this.ControlBox = false;
            this.Controls.Add(this.pcibInterrogacao2);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.btnAbrirArquivo);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.dtArquivo);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesqArquivo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Arquivos";
            this.Load += new System.EventHandler(this.FrmPesqArquivo_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPesqArquivo_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtArquivo)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtArquivo;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnPalavraChave;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnNomeAluno;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.TextBox txtpPalavraChave;
        private System.Windows.Forms.ComboBox cbbpTipoTabela;
        private System.Windows.Forms.TextBox txtpDescricao;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btnAbrirArquivo;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.PictureBox pcibInterrogacao2;
        private System.Windows.Forms.ToolTip ttpArquivo;

    }
}