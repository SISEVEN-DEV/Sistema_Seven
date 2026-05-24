namespace Seven_Sistema
{
    partial class FrmPesqPSPPIX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesqPSPPIX));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.rbtnPIX = new System.Windows.Forms.RadioButton();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.rbtnPSP = new System.Windows.Forms.RadioButton();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.cbbpTipoChave = new System.Windows.Forms.ComboBox();
            this.cbbpPSP = new System.Windows.Forms.ComboBox();
            this.dtPSP = new System.Windows.Forms.DataGridView();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.ttpPSPPIX = new System.Windows.Forms.ToolTip(this.components);
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPSP)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Controls.Add(this.picbInterrogacao2);
            this.grbBox1.Controls.Add(this.rbtnPIX);
            this.grbBox1.Controls.Add(this.btnPesquisar);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.rbtnPSP);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.cbbpTipoChave);
            this.grbBox1.Controls.Add(this.cbbpPSP);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(620, 79);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(107, 42);
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
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(223, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(95, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Escolha o PSP:";
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(506, 44);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 31;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // rbtnPIX
            // 
            this.rbtnPIX.AutoSize = true;
            this.rbtnPIX.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnPIX.Location = new System.Drawing.Point(6, 42);
            this.rbtnPIX.Name = "rbtnPIX";
            this.rbtnPIX.Size = new System.Drawing.Size(95, 17);
            this.rbtnPIX.TabIndex = 4;
            this.rbtnPIX.TabStop = true;
            this.rbtnPIX.Text = "Tipo de Chave";
            this.rbtnPIX.UseVisualStyleBackColor = true;
            this.rbtnPIX.CheckedChanged += new System.EventHandler(this.rbtnPIX_CheckedChanged);
            this.rbtnPIX.MouseLeave += new System.EventHandler(this.rbtnPIX_MouseLeave);
            this.rbtnPIX.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPIX_MouseMove);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisar.Image")));
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPesquisar.Location = new System.Drawing.Point(532, 42);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(82, 32);
            this.btnPesquisar.TabIndex = 9;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPSPPIX.SetToolTip(this.btnPesquisar, "Pesquisar dados no banco.");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            this.btnPesquisar.MouseLeave += new System.EventHandler(this.btnPesquisar_MouseLeave);
            this.btnPesquisar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisar_MouseMove);
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(107, 19);
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
            // rbtnPSP
            // 
            this.rbtnPSP.AutoSize = true;
            this.rbtnPSP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnPSP.Location = new System.Drawing.Point(6, 19);
            this.rbtnPSP.Name = "rbtnPSP";
            this.rbtnPSP.Size = new System.Drawing.Size(46, 17);
            this.rbtnPSP.TabIndex = 2;
            this.rbtnPSP.Text = "PSP";
            this.rbtnPSP.UseVisualStyleBackColor = true;
            this.rbtnPSP.CheckedChanged += new System.EventHandler(this.rbtnPSP_CheckedChanged);
            this.rbtnPSP.MouseLeave += new System.EventHandler(this.rbtnPSP_MouseLeave);
            this.rbtnPSP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPSP_MouseMove);
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpCodigo.Location = new System.Drawing.Point(572, 18);
            this.txtpCodigo.MaxLength = 5;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(42, 20);
            this.txtpCodigo.TabIndex = 8;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtpCodigo.Visible = false;
            this.txtpCodigo.Enter += new System.EventHandler(this.txtpCodigo_Enter);
            this.txtpCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpCodigo_KeyPress);
            this.txtpCodigo.Leave += new System.EventHandler(this.txtpCodigo_Leave);
            // 
            // cbbpTipoChave
            // 
            this.cbbpTipoChave.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpTipoChave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpTipoChave.DropDownWidth = 115;
            this.cbbpTipoChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpTipoChave.FormattingEnabled = true;
            this.cbbpTipoChave.Items.AddRange(new object[] {
            "",
            "ALEATORIA",
            "CELULAR",
            "CNPJ",
            "CPF",
            "EMAIL"});
            this.cbbpTipoChave.Location = new System.Drawing.Point(499, 17);
            this.cbbpTipoChave.Name = "cbbpTipoChave";
            this.cbbpTipoChave.Size = new System.Drawing.Size(115, 21);
            this.cbbpTipoChave.TabIndex = 7;
            this.cbbpTipoChave.DropDown += new System.EventHandler(this.cbbpTipoChave_DropDown);
            this.cbbpTipoChave.DropDownClosed += new System.EventHandler(this.cbbpTipoChave_DropDownClosed);
            this.cbbpTipoChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpTipoChave_KeyPress);
            this.cbbpTipoChave.MouseLeave += new System.EventHandler(this.cbbpTipoChave_MouseLeave);
            this.cbbpTipoChave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpTipoChave_MouseMove);
            // 
            // cbbpPSP
            // 
            this.cbbpPSP.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpPSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpPSP.DropDownWidth = 290;
            this.cbbpPSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbbpPSP.FormattingEnabled = true;
            this.cbbpPSP.Items.AddRange(new object[] {
            "",
            "MERCADO PAGO"});
            this.cbbpPSP.Location = new System.Drawing.Point(324, 17);
            this.cbbpPSP.Name = "cbbpPSP";
            this.cbbpPSP.Size = new System.Drawing.Size(290, 21);
            this.cbbpPSP.TabIndex = 6;
            this.cbbpPSP.DropDown += new System.EventHandler(this.cbbpPSP_DropDown);
            this.cbbpPSP.DropDownClosed += new System.EventHandler(this.cbbpPSP_DropDownClosed);
            this.cbbpPSP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpPSP_KeyPress);
            this.cbbpPSP.MouseLeave += new System.EventHandler(this.cbbpPSP_MouseLeave);
            this.cbbpPSP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpPSP_MouseMove);
            // 
            // dtPSP
            // 
            this.dtPSP.AllowUserToAddRows = false;
            this.dtPSP.AllowUserToDeleteRows = false;
            this.dtPSP.AllowUserToResizeRows = false;
            this.dtPSP.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtPSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtPSP.Enabled = false;
            this.dtPSP.Location = new System.Drawing.Point(12, 97);
            this.dtPSP.MultiSelect = false;
            this.dtPSP.Name = "dtPSP";
            this.dtPSP.ReadOnly = true;
            this.dtPSP.RowHeadersVisible = false;
            this.dtPSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtPSP.ShowCellErrors = false;
            this.dtPSP.ShowCellToolTips = false;
            this.dtPSP.ShowEditingIcon = false;
            this.dtPSP.ShowRowErrors = false;
            this.dtPSP.Size = new System.Drawing.Size(620, 172);
            this.dtPSP.TabIndex = 10;
            this.dtPSP.DataSourceChanged += new System.EventHandler(this.dtPSP_DataSourceChanged);
            this.dtPSP.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtPSP_CellEnter);
            this.dtPSP.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtPSP_RowsAdded);
            this.dtPSP.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtPSP_RowsRemoved);
            this.dtPSP.DoubleClick += new System.EventHandler(this.dtPSP_DoubleClick);
            this.dtPSP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtPSP_KeyDown);
            this.dtPSP.MouseLeave += new System.EventHandler(this.dtPSP_MouseLeave);
            this.dtPSP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtPSP_MouseMove);
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(577, 275);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 12;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPSPPIX.SetToolTip(this.btnVoltar, "Sair de Pesquisar PSP/PIX.");
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
            this.btnIncluir.Location = new System.Drawing.Point(501, 275);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(70, 32);
            this.btnIncluir.TabIndex = 11;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPSPPIX.SetToolTip(this.btnIncluir, "Clique para incluir os dados.");
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
            this.lblRegistros.Location = new System.Drawing.Point(9, 272);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(164, 26);
            this.lblRegistros.TabIndex = 143;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ttpPSPPIX
            // 
            this.ttpPSPPIX.AutoPopDelay = 5000;
            this.ttpPSPPIX.InitialDelay = 1000;
            this.ttpPSPPIX.IsBalloon = true;
            this.ttpPSPPIX.ReshowDelay = 100;
            this.ttpPSPPIX.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpPSPPIX.ToolTipTitle = "Dica:";
            // 
            // FrmPesqPSPPIX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(643, 312);
            this.ControlBox = false;
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.dtPSP);
            this.Controls.Add(this.grbBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesqPSPPIX";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar PSP/PIX";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPesqPSPPIX_FormClosing);
            this.Load += new System.EventHandler(this.FrmPesqPSPPIX_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPesqPSPPIX_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtPSP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.Label lblPesquisar;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.RadioButton rbtnPIX;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.RadioButton rbtnPSP;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.ComboBox cbbpTipoChave;
        private System.Windows.Forms.ComboBox cbbpPSP;
        private System.Windows.Forms.DataGridView dtPSP;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.ToolTip ttpPSPPIX;
    }
}