namespace Seven_Sistema
{
    partial class FrmPesqUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesqUsuario));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.dtUsuario = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnFuncionario = new System.Windows.Forms.RadioButton();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnpProcurar = new System.Windows.Forms.Button();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbtnNomeUsuario = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.txtpNomeUsuario = new System.Windows.Forms.TextBox();
            this.cbbpFuncionario = new System.Windows.Forms.ComboBox();
            this.ttpUser = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtUsuario)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(463, 238);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(70, 32);
            this.btnVoltar.TabIndex = 59;
            this.btnVoltar.Text = "&Voltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUser.SetToolTip(this.btnVoltar, "Clique para voltar ao menu anterior.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Enabled = false;
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(387, 238);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(70, 32);
            this.btnIncluir.TabIndex = 58;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUser.SetToolTip(this.btnIncluir, "Clique para incluir os dados.");
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            this.btnIncluir.MouseLeave += new System.EventHandler(this.btnIncluir_MouseLeave);
            this.btnIncluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnIncluir_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(12, 235);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 60;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtUsuario
            // 
            this.dtUsuario.AllowUserToAddRows = false;
            this.dtUsuario.AllowUserToDeleteRows = false;
            this.dtUsuario.AllowUserToResizeRows = false;
            this.dtUsuario.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dtUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtUsuario.Enabled = false;
            this.dtUsuario.Location = new System.Drawing.Point(12, 104);
            this.dtUsuario.MultiSelect = false;
            this.dtUsuario.Name = "dtUsuario";
            this.dtUsuario.ReadOnly = true;
            this.dtUsuario.RowHeadersVisible = false;
            this.dtUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtUsuario.ShowCellErrors = false;
            this.dtUsuario.ShowCellToolTips = false;
            this.dtUsuario.ShowEditingIcon = false;
            this.dtUsuario.ShowRowErrors = false;
            this.dtUsuario.Size = new System.Drawing.Size(521, 128);
            this.dtUsuario.TabIndex = 57;
            this.dtUsuario.DataSourceChanged += new System.EventHandler(this.dtUsuario_DataSourceChanged);
            this.dtUsuario.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtUsuario_CellEnter);
            this.dtUsuario.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtUsuario_CellFormatting);
            this.dtUsuario.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtUsuario_RowsAdded);
            this.dtUsuario.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtUsuario_RowsRemoved);
            this.dtUsuario.DoubleClick += new System.EventHandler(this.dtUsuario_DoubleClick);
            this.dtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtUsuario_KeyDown);
            this.dtUsuario.MouseLeave += new System.EventHandler(this.dtUsuario_MouseLeave);
            this.dtUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtUsuario_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnFuncionario);
            this.grbBox1.Controls.Add(this.picbInterrogacao2);
            this.grbBox1.Controls.Add(this.btnpProcurar);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnNomeUsuario);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.txtpNomeUsuario);
            this.grbBox1.Controls.Add(this.cbbpFuncionario);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(521, 86);
            this.grbBox1.TabIndex = 56;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(156, 42);
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
            // rbtnFuncionario
            // 
            this.rbtnFuncionario.AutoSize = true;
            this.rbtnFuncionario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnFuncionario.Location = new System.Drawing.Point(70, 42);
            this.rbtnFuncionario.Name = "rbtnFuncionario";
            this.rbtnFuncionario.Size = new System.Drawing.Size(80, 17);
            this.rbtnFuncionario.TabIndex = 4;
            this.rbtnFuncionario.TabStop = true;
            this.rbtnFuncionario.Text = "Funcionário";
            this.rbtnFuncionario.UseVisualStyleBackColor = true;
            this.rbtnFuncionario.CheckedChanged += new System.EventHandler(this.rbtnFuncionario_CheckedChanged);
            this.rbtnFuncionario.MouseLeave += new System.EventHandler(this.rbtnFuncionario_MouseLeave);
            this.rbtnFuncionario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnFuncionario_MouseMove);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(407, 45);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 31;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // btnpProcurar
            // 
            this.btnpProcurar.Image = ((System.Drawing.Image)(resources.GetObject("btnpProcurar.Image")));
            this.btnpProcurar.Location = new System.Drawing.Point(489, 16);
            this.btnpProcurar.Name = "btnpProcurar";
            this.btnpProcurar.Size = new System.Drawing.Size(26, 25);
            this.btnpProcurar.TabIndex = 9;
            this.btnpProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUser.SetToolTip(this.btnpProcurar, "Clique para pesquisar um Funcionário.");
            this.btnpProcurar.UseVisualStyleBackColor = true;
            this.btnpProcurar.Visible = false;
            this.btnpProcurar.Click += new System.EventHandler(this.btnpProcurar_Click);
            this.btnpProcurar.MouseLeave += new System.EventHandler(this.btnpProcurar_MouseLeave);
            this.btnpProcurar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnpProcurar_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(6, 42);
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
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPesquisar.Location = new System.Drawing.Point(433, 45);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 10;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUser.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // rbtnNomeUsuario
            // 
            this.rbtnNomeUsuario.AutoSize = true;
            this.rbtnNomeUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnNomeUsuario.Location = new System.Drawing.Point(6, 19);
            this.rbtnNomeUsuario.Name = "rbtnNomeUsuario";
            this.rbtnNomeUsuario.Size = new System.Drawing.Size(107, 17);
            this.rbtnNomeUsuario.TabIndex = 2;
            this.rbtnNomeUsuario.Text = "Nome de Usuário";
            this.rbtnNomeUsuario.UseVisualStyleBackColor = true;
            this.rbtnNomeUsuario.CheckedChanged += new System.EventHandler(this.rbtnNomeUsuario_CheckedChanged);
            this.rbtnNomeUsuario.MouseLeave += new System.EventHandler(this.rbtnNomeUsuario_MouseLeave);
            this.rbtnNomeUsuario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnNomeUsuario_MouseMove);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(256, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(152, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite o nome do usuário:";
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(470, 18);
            this.txtpCodigo.MaxLength = 5;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(45, 20);
            this.txtpCodigo.TabIndex = 9;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // txtpNomeUsuario
            // 
            this.txtpNomeUsuario.BackColor = System.Drawing.Color.White;
            this.txtpNomeUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpNomeUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpNomeUsuario.Location = new System.Drawing.Point(414, 18);
            this.txtpNomeUsuario.MaxLength = 10;
            this.txtpNomeUsuario.Name = "txtpNomeUsuario";
            this.txtpNomeUsuario.Size = new System.Drawing.Size(101, 20);
            this.txtpNomeUsuario.TabIndex = 8;
            this.txtpNomeUsuario.Enter += new System.EventHandler(this.txtpNomeUsuario_Enter);
            this.txtpNomeUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpNomeUsuario_KeyPress);
            this.txtpNomeUsuario.Leave += new System.EventHandler(this.txtpNomeUsuario_Leave);
            // 
            // cbbpFuncionario
            // 
            this.cbbpFuncionario.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpFuncionario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpFuncionario.DropDownWidth = 500;
            this.cbbpFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpFuncionario.FormattingEnabled = true;
            this.cbbpFuncionario.Location = new System.Drawing.Point(253, 18);
            this.cbbpFuncionario.Name = "cbbpFuncionario";
            this.cbbpFuncionario.Size = new System.Drawing.Size(230, 21);
            this.cbbpFuncionario.TabIndex = 6;
            this.cbbpFuncionario.Visible = false;
            this.cbbpFuncionario.DropDown += new System.EventHandler(this.cbbpFuncionario_DropDown);
            this.cbbpFuncionario.DropDownClosed += new System.EventHandler(this.cbbpFuncionario_DropDownClosed);
            this.cbbpFuncionario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpFuncionario_KeyPress);
            this.cbbpFuncionario.MouseLeave += new System.EventHandler(this.cbbpFuncionario_MouseLeave);
            this.cbbpFuncionario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpFuncionario_MouseMove);
            // 
            // ttpUser
            // 
            this.ttpUser.AutoPopDelay = 5000;
            this.ttpUser.InitialDelay = 1000;
            this.ttpUser.IsBalloon = true;
            this.ttpUser.ReshowDelay = 100;
            this.ttpUser.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpUser.ToolTipTitle = "Dica:";
            // 
            // FrmPesqUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(540, 270);
            this.ControlBox = false;
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.dtUsuario);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesqUsuario";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Usuários";
            this.Load += new System.EventHandler(this.FrmPesqUsuario_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPesqUsuario_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtUsuario)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.DataGridView dtUsuario;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnFuncionario;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.Button btnpProcurar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnNomeUsuario;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.TextBox txtpNomeUsuario;
        private System.Windows.Forms.ComboBox cbbpFuncionario;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.ToolTip ttpUser;
    }
}