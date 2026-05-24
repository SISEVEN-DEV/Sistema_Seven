namespace Seven_Sistema
{
    partial class FrmPesqComputadorPDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesqComputadorPDV));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.dtCompPDV = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.cbbTipo = new System.Windows.Forms.ComboBox();
            this.rbtnTipo = new System.Windows.Forms.RadioButton();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbtnNome = new System.Windows.Forms.RadioButton();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.txtpNome = new System.Windows.Forms.TextBox();
            this.ttpComp = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtCompPDV)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(480, 282);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 10;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComp.SetToolTip(this.btnVoltar, "Sair de Pesquisar Computador/PDV.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Enabled = false;
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(404, 282);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(70, 32);
            this.btnIncluir.TabIndex = 9;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComp.SetToolTip(this.btnIncluir, "Clique para incluir os dados.");
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
            this.lblRegistros.Location = new System.Drawing.Point(9, 279);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 18;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtCompPDV
            // 
            this.dtCompPDV.AllowUserToAddRows = false;
            this.dtCompPDV.AllowUserToDeleteRows = false;
            this.dtCompPDV.AllowUserToResizeRows = false;
            this.dtCompPDV.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtCompPDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtCompPDV.Enabled = false;
            this.dtCompPDV.Location = new System.Drawing.Point(12, 104);
            this.dtCompPDV.MultiSelect = false;
            this.dtCompPDV.Name = "dtCompPDV";
            this.dtCompPDV.ReadOnly = true;
            this.dtCompPDV.RowHeadersVisible = false;
            this.dtCompPDV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtCompPDV.ShowCellErrors = false;
            this.dtCompPDV.ShowCellToolTips = false;
            this.dtCompPDV.ShowEditingIcon = false;
            this.dtCompPDV.ShowRowErrors = false;
            this.dtCompPDV.Size = new System.Drawing.Size(521, 172);
            this.dtCompPDV.TabIndex = 8;
            this.dtCompPDV.DataSourceChanged += new System.EventHandler(this.dtCompPDV_DataSourceChanged);
            this.dtCompPDV.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtCompPDV_CellEnter);
            this.dtCompPDV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtCompPDV_RowsAdded);
            this.dtCompPDV.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtCompPDV_RowsRemoved);
            this.dtCompPDV.DoubleClick += new System.EventHandler(this.dtCompPDV_DoubleClick);
            this.dtCompPDV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtCompPDV_KeyDown);
            this.dtCompPDV.MouseLeave += new System.EventHandler(this.dtCompPDV_MouseLeave);
            this.dtCompPDV.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtCompPDV_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.cbbTipo);
            this.grbBox1.Controls.Add(this.rbtnTipo);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.picbInterrogacao2);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnNome);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.txtpNome);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(521, 86);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // cbbTipo
            // 
            this.cbbTipo.BackColor = System.Drawing.Color.LightBlue;
            this.cbbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipo.DropDownWidth = 180;
            this.cbbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTipo.FormattingEnabled = true;
            this.cbbTipo.Items.AddRange(new object[] {
            "SERVIDOR",
            "TERMINAL"});
            this.cbbTipo.Location = new System.Drawing.Point(402, 18);
            this.cbbTipo.Name = "cbbTipo";
            this.cbbTipo.Size = new System.Drawing.Size(113, 21);
            this.cbbTipo.TabIndex = 34;
            this.cbbTipo.DropDown += new System.EventHandler(this.cbbTipo_DropDown);
            this.cbbTipo.DropDownClosed += new System.EventHandler(this.cbbTipo_DropDownClosed);
            this.cbbTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbTipo_KeyPress);
            this.cbbTipo.MouseLeave += new System.EventHandler(this.cbbTipo_MouseLeave);
            this.cbbTipo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbTipo_MouseMove);
            // 
            // rbtnTipo
            // 
            this.rbtnTipo.AutoSize = true;
            this.rbtnTipo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTipo.Location = new System.Drawing.Point(7, 42);
            this.rbtnTipo.Name = "rbtnTipo";
            this.rbtnTipo.Size = new System.Drawing.Size(46, 17);
            this.rbtnTipo.TabIndex = 33;
            this.rbtnTipo.TabStop = true;
            this.rbtnTipo.Text = "Tipo";
            this.rbtnTipo.UseVisualStyleBackColor = true;
            this.rbtnTipo.CheckedChanged += new System.EventHandler(this.rbtnTipo_CheckedChanged);
            this.rbtnTipo.MouseLeave += new System.EventHandler(this.rbtnTipo_MouseLeave);
            this.rbtnTipo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTipo_MouseMove);
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(65, 42);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 4;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            this.rbtnTodos.CheckedChanged += new System.EventHandler(this.rbtnTodos_CheckedChanged_1);
            this.rbtnTodos.MouseLeave += new System.EventHandler(this.rbtnTodos_MouseLeave);
            this.rbtnTodos.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTodos_MouseMove);
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
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(65, 19);
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
            this.btnPesquisar.TabIndex = 7;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComp.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // rbtnNome
            // 
            this.rbtnNome.AutoSize = true;
            this.rbtnNome.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnNome.Location = new System.Drawing.Point(6, 19);
            this.rbtnNome.Name = "rbtnNome";
            this.rbtnNome.Size = new System.Drawing.Size(53, 17);
            this.rbtnNome.TabIndex = 2;
            this.rbtnNome.Text = "Nome";
            this.rbtnNome.UseVisualStyleBackColor = true;
            this.rbtnNome.CheckedChanged += new System.EventHandler(this.rbtnNome_CheckedChanged);
            this.rbtnNome.MouseLeave += new System.EventHandler(this.rbtnNome_MouseLeave);
            this.rbtnNome.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnNome_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(468, 18);
            this.txtpCodigo.MaxLength = 5;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(45, 20);
            this.txtpCodigo.TabIndex = 6;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(207, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(89, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite o nome:";
            // 
            // txtpNome
            // 
            this.txtpNome.BackColor = System.Drawing.Color.White;
            this.txtpNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtpNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpNome.Location = new System.Drawing.Point(299, 18);
            this.txtpNome.MaxLength = 60;
            this.txtpNome.Name = "txtpNome";
            this.txtpNome.Size = new System.Drawing.Size(215, 20);
            this.txtpNome.TabIndex = 5;
            this.txtpNome.Enter += new System.EventHandler(this.txtpNome_Enter);
            this.txtpNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpNome_KeyPress);
            this.txtpNome.Leave += new System.EventHandler(this.txtpNome_Leave);
            // 
            // ttpComp
            // 
            this.ttpComp.AutoPopDelay = 5000;
            this.ttpComp.InitialDelay = 1000;
            this.ttpComp.IsBalloon = true;
            this.ttpComp.ReshowDelay = 100;
            this.ttpComp.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpComp.ToolTipTitle = "Dica:";
            // 
            // FrmPesqComputadorPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(545, 320);
            this.ControlBox = false;
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.dtCompPDV);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesqComputadorPDV";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Computador/PDV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPesqComputadorPDV_FormClosing);
            this.Load += new System.EventHandler(this.FrmPesqComputadorPDV_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPesqComputadorPDV_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtCompPDV)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.DataGridView dtCompPDV;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnNome;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.TextBox txtpNome;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.RadioButton rbtnTipo;
        private System.Windows.Forms.ComboBox cbbTipo;
        private System.Windows.Forms.ToolTip ttpComp;
    }
}