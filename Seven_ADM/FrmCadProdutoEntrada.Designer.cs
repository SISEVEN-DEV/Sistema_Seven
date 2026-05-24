namespace Seven_Sistema
{
    partial class FrmCadProdutoEntrada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadProdutoEntrada));
            this.dtEstoque = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblAst2 = new System.Windows.Forms.Label();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.lblDataCompra = new System.Windows.Forms.Label();
            this.lblAst1 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.mtxtDataCompra = new System.Windows.Forms.MaskedTextBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.btnpProcurar = new System.Windows.Forms.Button();
            this.cbbFornecedor = new System.Windows.Forms.ComboBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.lblHistorico = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.pcibInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.ttpEstoque = new System.Windows.Forms.ToolTip(this.components);
            this.btnExcluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtEstoque)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao2)).BeginInit();
            this.SuspendLayout();
            // 
            // dtEstoque
            // 
            this.dtEstoque.AllowUserToAddRows = false;
            this.dtEstoque.AllowUserToDeleteRows = false;
            this.dtEstoque.AllowUserToResizeRows = false;
            this.dtEstoque.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtEstoque.Enabled = false;
            this.dtEstoque.Location = new System.Drawing.Point(12, 25);
            this.dtEstoque.MultiSelect = false;
            this.dtEstoque.Name = "dtEstoque";
            this.dtEstoque.ReadOnly = true;
            this.dtEstoque.RowHeadersVisible = false;
            this.dtEstoque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtEstoque.ShowCellErrors = false;
            this.dtEstoque.ShowCellToolTips = false;
            this.dtEstoque.ShowEditingIcon = false;
            this.dtEstoque.ShowRowErrors = false;
            this.dtEstoque.Size = new System.Drawing.Size(580, 128);
            this.dtEstoque.TabIndex = 1;
            this.dtEstoque.DataSourceChanged += new System.EventHandler(this.dtEstoque_DataSourceChanged);
            this.dtEstoque.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtEstoque_CellEnter);
            this.dtEstoque.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtEstoque_CellFormatting);
            this.dtEstoque.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtEstoque_RowsAdded);
            this.dtEstoque.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtEstoque_RowsRemoved);
            this.dtEstoque.MouseLeave += new System.EventHandler(this.dtEstoque_MouseLeave);
            this.dtEstoque.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtEstoque_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblAst2);
            this.grbBox1.Controls.Add(this.lblFornecedor);
            this.grbBox1.Controls.Add(this.lblDataCompra);
            this.grbBox1.Controls.Add(this.lblAst1);
            this.grbBox1.Controls.Add(this.txtQuantidade);
            this.grbBox1.Controls.Add(this.mtxtDataCompra);
            this.grbBox1.Controls.Add(this.lblQuantidade);
            this.grbBox1.Controls.Add(this.btnpProcurar);
            this.grbBox1.Controls.Add(this.cbbFornecedor);
            this.grbBox1.Enabled = false;
            this.grbBox1.Location = new System.Drawing.Point(12, 185);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(580, 64);
            this.grbBox1.TabIndex = 2;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Cadastrar e excluir:";
            // 
            // lblAst2
            // 
            this.lblAst2.AutoSize = true;
            this.lblAst2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAst2.ForeColor = System.Drawing.Color.Red;
            this.lblAst2.Location = new System.Drawing.Point(83, 13);
            this.lblAst2.Name = "lblAst2";
            this.lblAst2.Size = new System.Drawing.Size(13, 15);
            this.lblAst2.TabIndex = 0;
            this.lblAst2.Text = "*";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblFornecedor.Location = new System.Drawing.Point(99, 16);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(64, 13);
            this.lblFornecedor.TabIndex = 0;
            this.lblFornecedor.Tag = "";
            this.lblFornecedor.Text = "Fornecedor:";
            // 
            // lblDataCompra
            // 
            this.lblDataCompra.AutoSize = true;
            this.lblDataCompra.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDataCompra.Location = new System.Drawing.Point(0, 16);
            this.lblDataCompra.Name = "lblDataCompra";
            this.lblDataCompra.Size = new System.Drawing.Size(88, 13);
            this.lblDataCompra.TabIndex = 0;
            this.lblDataCompra.Tag = "";
            this.lblDataCompra.Text = "Data de Entrada:";
            // 
            // lblAst1
            // 
            this.lblAst1.AutoSize = true;
            this.lblAst1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAst1.ForeColor = System.Drawing.Color.Red;
            this.lblAst1.Location = new System.Drawing.Point(525, 13);
            this.lblAst1.Name = "lblAst1";
            this.lblAst1.Size = new System.Drawing.Size(13, 15);
            this.lblAst1.TabIndex = 0;
            this.lblAst1.Text = "*";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BackColor = System.Drawing.Color.White;
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtQuantidade.Location = new System.Drawing.Point(468, 32);
            this.txtQuantidade.MaxLength = 10;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(106, 20);
            this.txtQuantidade.TabIndex = 8;
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantidade.Enter += new System.EventHandler(this.txtQuantidade_Enter);
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            this.txtQuantidade.Leave += new System.EventHandler(this.txtQuantidade_Leave);
            // 
            // mtxtDataCompra
            // 
            this.mtxtDataCompra.BackColor = System.Drawing.Color.White;
            this.mtxtDataCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtDataCompra.Location = new System.Drawing.Point(4, 32);
            this.mtxtDataCompra.Mask = "00/00/0000";
            this.mtxtDataCompra.Name = "mtxtDataCompra";
            this.mtxtDataCompra.Size = new System.Drawing.Size(80, 20);
            this.mtxtDataCompra.TabIndex = 3;
            this.mtxtDataCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtDataCompra.DoubleClick += new System.EventHandler(this.mtxtDataCompra_DoubleClick);
            this.mtxtDataCompra.Enter += new System.EventHandler(this.mtxtDataCompra_Enter);
            this.mtxtDataCompra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtDataCompra_KeyDown);
            this.mtxtDataCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtDataCompra_KeyPress);
            this.mtxtDataCompra.Leave += new System.EventHandler(this.mtxtDataCompra_Leave);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblQuantidade.Location = new System.Drawing.Point(465, 16);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(65, 13);
            this.lblQuantidade.TabIndex = 0;
            this.lblQuantidade.Tag = "";
            this.lblQuantidade.Text = "Quantidade:";
            // 
            // btnpProcurar
            // 
            this.btnpProcurar.Image = ((System.Drawing.Image)(resources.GetObject("btnpProcurar.Image")));
            this.btnpProcurar.Location = new System.Drawing.Point(436, 30);
            this.btnpProcurar.Name = "btnpProcurar";
            this.btnpProcurar.Size = new System.Drawing.Size(26, 25);
            this.btnpProcurar.TabIndex = 5;
            this.btnpProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEstoque.SetToolTip(this.btnpProcurar, "Clique para pesquisar um fornecedor.");
            this.btnpProcurar.UseVisualStyleBackColor = true;
            this.btnpProcurar.Click += new System.EventHandler(this.btnpProcurar_Click);
            this.btnpProcurar.MouseLeave += new System.EventHandler(this.btnpProcurar_MouseLeave);
            this.btnpProcurar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnpProcurar_MouseMove);
            // 
            // cbbFornecedor
            // 
            this.cbbFornecedor.BackColor = System.Drawing.Color.LightBlue;
            this.cbbFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFornecedor.DropDownWidth = 550;
            this.cbbFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbFornecedor.FormattingEnabled = true;
            this.cbbFornecedor.Location = new System.Drawing.Point(102, 32);
            this.cbbFornecedor.Name = "cbbFornecedor";
            this.cbbFornecedor.Size = new System.Drawing.Size(328, 21);
            this.cbbFornecedor.TabIndex = 4;
            this.cbbFornecedor.DropDown += new System.EventHandler(this.cbbFornecedor_DropDown);
            this.cbbFornecedor.DropDownClosed += new System.EventHandler(this.cbbFornecedor_DropDownClosed);
            this.cbbFornecedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbFornecedor_KeyPress);
            this.cbbFornecedor.MouseLeave += new System.EventHandler(this.cbbFornecedor_MouseLeave);
            this.cbbFornecedor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbFornecedor_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(9, 156);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHistorico
            // 
            this.lblHistorico.AutoSize = true;
            this.lblHistorico.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblHistorico.Location = new System.Drawing.Point(12, 9);
            this.lblHistorico.Name = "lblHistorico";
            this.lblHistorico.Size = new System.Drawing.Size(289, 13);
            this.lblHistorico.TabIndex = 0;
            this.lblHistorico.Tag = "";
            this.lblHistorico.Text = "Histórico de entradas deste Produto (Entradas no cadastro):";
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(540, 255);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 13;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEstoque.SetToolTip(this.btnSair, "CLique para sair do Cadastro de Entrada de Produto.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // pcibInterrogacao2
            // 
            this.pcibInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao2.Image")));
            this.pcibInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pcibInterrogacao2.Location = new System.Drawing.Point(12, 255);
            this.pcibInterrogacao2.Name = "pcibInterrogacao2";
            this.pcibInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao2.TabIndex = 113;
            this.pcibInterrogacao2.TabStop = false;
            this.pcibInterrogacao2.Click += new System.EventHandler(this.pcibInterrogacao2_Click);
            this.pcibInterrogacao2.MouseLeave += new System.EventHandler(this.pcibInterrogacao2_MouseLeave);
            this.pcibInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao2_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelar.Location = new System.Drawing.Point(309, 255);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEstoque.SetToolTip(this.btnCancelar, "Cancelar opção atual.");
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
            this.btnSalvar.Location = new System.Drawing.Point(400, 255);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 12;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEstoque.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNovo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNovo.Location = new System.Drawing.Point(38, 255);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(70, 32);
            this.btnNovo.TabIndex = 9;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEstoque.SetToolTip(this.btnNovo, "Cadastrar uma nova Entrada.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
            // 
            // ttpEstoque
            // 
            this.ttpEstoque.AutoPopDelay = 5000;
            this.ttpEstoque.InitialDelay = 1000;
            this.ttpEstoque.IsBalloon = true;
            this.ttpEstoque.ReshowDelay = 100;
            this.ttpEstoque.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpEstoque.ToolTipTitle = "Dica:";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExcluir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcluir.Location = new System.Drawing.Point(158, 255);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(70, 32);
            this.btnExcluir.TabIndex = 10;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpEstoque.SetToolTip(this.btnExcluir, "Excluir uma Entrada cadastrada.");
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            this.btnExcluir.MouseLeave += new System.EventHandler(this.btnExcluir_MouseLeave);
            this.btnExcluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluir_MouseMove);
            // 
            // FrmCadProdutoEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(604, 295);
            this.ControlBox = false;
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.pcibInterrogacao2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.lblHistorico);
            this.Controls.Add(this.dtEstoque);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadProdutoEntrada";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Entrada de Produto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCadProdutoEntrada_FormClosing);
            this.Load += new System.EventHandler(this.FrmCadProdutoEstoque_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadProdutoEstoque_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtEstoque)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtEstoque;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.ComboBox cbbFornecedor;
        private System.Windows.Forms.Button btnpProcurar;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label lblDataCompra;
        private System.Windows.Forms.MaskedTextBox mtxtDataCompra;
        private System.Windows.Forms.Label lblHistorico;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox pcibInterrogacao2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ToolTip ttpEstoque;
        private System.Windows.Forms.Label lblAst1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label lblAst2;
    }
}