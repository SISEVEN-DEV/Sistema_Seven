namespace Seven_ADM
{
    partial class FrmAssociarItemDFe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAssociarItemDFe));
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbProduto = new System.Windows.Forms.ComboBox();
            this.btnpProcurarDestinatario = new System.Windows.Forms.Button();
            this.lblNome_Desc = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.dtItens = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.lblValorSituacao = new System.Windows.Forms.Label();
            this.lblCxSituacao = new System.Windows.Forms.Label();
            this.ttpAssociar = new System.Windows.Forms.ToolTip(this.components);
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Informações do Item:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalvar.Location = new System.Drawing.Point(245, 404);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAssociar.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnSair
            // 
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(534, 404);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 9;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAssociar.SetToolTip(this.btnSair, "Sair de Associar Itens.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.label13);
            this.grbBox1.Controls.Add(this.txtQuantidade);
            this.grbBox1.Controls.Add(this.label2);
            this.grbBox1.Controls.Add(this.label3);
            this.grbBox1.Controls.Add(this.cbbProduto);
            this.grbBox1.Controls.Add(this.btnpProcurarDestinatario);
            this.grbBox1.Controls.Add(this.lblNome_Desc);
            this.grbBox1.Controls.Add(this.txtDescricao);
            this.grbBox1.Controls.Add(this.txtCodigo);
            this.grbBox1.Controls.Add(this.lblCodigo);
            this.grbBox1.Enabled = false;
            this.grbBox1.Location = new System.Drawing.Point(7, 292);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(579, 106);
            this.grbBox1.TabIndex = 2;
            this.grbBox1.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(478, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 40;
            this.label13.Text = "Quantidade:";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BackColor = System.Drawing.Color.White;
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtQuantidade.Location = new System.Drawing.Point(481, 33);
            this.txtQuantidade.MaxLength = 10;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.ReadOnly = true;
            this.txtQuantidade.Size = new System.Drawing.Size(92, 20);
            this.txtQuantidade.TabIndex = 5;
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Produto:";
            // 
            // cbbProduto
            // 
            this.cbbProduto.BackColor = System.Drawing.Color.LightBlue;
            this.cbbProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbbProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProduto.DropDownWidth = 550;
            this.cbbProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbProduto.FormattingEnabled = true;
            this.cbbProduto.Location = new System.Drawing.Point(8, 72);
            this.cbbProduto.Name = "cbbProduto";
            this.cbbProduto.Size = new System.Drawing.Size(526, 21);
            this.cbbProduto.TabIndex = 6;
            this.cbbProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbProduto_KeyPress);
            // 
            // btnpProcurarDestinatario
            // 
            this.btnpProcurarDestinatario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnpProcurarDestinatario.Image = ((System.Drawing.Image)(resources.GetObject("btnpProcurarDestinatario.Image")));
            this.btnpProcurarDestinatario.Location = new System.Drawing.Point(540, 69);
            this.btnpProcurarDestinatario.Name = "btnpProcurarDestinatario";
            this.btnpProcurarDestinatario.Size = new System.Drawing.Size(26, 25);
            this.btnpProcurarDestinatario.TabIndex = 7;
            this.btnpProcurarDestinatario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAssociar.SetToolTip(this.btnpProcurarDestinatario, "Clique para pesquisar um Produto.");
            this.btnpProcurarDestinatario.UseVisualStyleBackColor = true;
            this.btnpProcurarDestinatario.Click += new System.EventHandler(this.btnpProcurarDestinatario_Click);
            // 
            // lblNome_Desc
            // 
            this.lblNome_Desc.AutoSize = true;
            this.lblNome_Desc.ForeColor = System.Drawing.Color.Blue;
            this.lblNome_Desc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNome_Desc.Location = new System.Drawing.Point(82, 16);
            this.lblNome_Desc.Name = "lblNome_Desc";
            this.lblNome_Desc.Size = new System.Drawing.Size(96, 13);
            this.lblNome_Desc.TabIndex = 0;
            this.lblNome_Desc.Text = "Descrição do Item:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDescricao.Location = new System.Drawing.Point(82, 33);
            this.txtDescricao.MaxLength = 120;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ReadOnly = true;
            this.txtDescricao.Size = new System.Drawing.Size(393, 20);
            this.txtDescricao.TabIndex = 4;
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCodigo.Location = new System.Drawing.Point(9, 33);
            this.txtCodigo.MaxLength = 8;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(67, 20);
            this.txtCodigo.TabIndex = 3;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.ForeColor = System.Drawing.Color.Blue;
            this.lblCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCodigo.Location = new System.Drawing.Point(6, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(70, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Cód. do Item:";
            // 
            // lblItem
            // 
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(7, 9);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(582, 14);
            this.lblItem.TabIndex = 25;
            this.lblItem.Text = "Itens sem Código de Barras:";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtItens
            // 
            this.dtItens.AllowUserToAddRows = false;
            this.dtItens.AllowUserToDeleteRows = false;
            this.dtItens.AllowUserToResizeRows = false;
            this.dtItens.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtItens.Enabled = false;
            this.dtItens.Location = new System.Drawing.Point(7, 25);
            this.dtItens.MultiSelect = false;
            this.dtItens.Name = "dtItens";
            this.dtItens.ReadOnly = true;
            this.dtItens.RowHeadersVisible = false;
            this.dtItens.RowHeadersWidth = 51;
            this.dtItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtItens.ShowCellErrors = false;
            this.dtItens.ShowCellToolTips = false;
            this.dtItens.ShowEditingIcon = false;
            this.dtItens.ShowRowErrors = false;
            this.dtItens.Size = new System.Drawing.Size(582, 238);
            this.dtItens.TabIndex = 1;
            this.dtItens.TabStop = false;
            this.dtItens.DataSourceChanged += new System.EventHandler(this.dtItens_DataSourceChanged);
            this.dtItens.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtItens_CellEnter);
            this.dtItens.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtItens_CellFormatting);
            this.dtItens.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtItens_RowsAdded);
            this.dtItens.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtItens_RowsRemoved);
            this.dtItens.MouseLeave += new System.EventHandler(this.dtItens_MouseLeave);
            this.dtItens.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtItens_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(429, 266);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 16);
            this.lblRegistros.TabIndex = 27;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblValorSituacao
            // 
            this.lblValorSituacao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorSituacao.BackColor = System.Drawing.Color.Transparent;
            this.lblValorSituacao.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorSituacao.ForeColor = System.Drawing.Color.Black;
            this.lblValorSituacao.Location = new System.Drawing.Point(35, 263);
            this.lblValorSituacao.Name = "lblValorSituacao";
            this.lblValorSituacao.Size = new System.Drawing.Size(206, 26);
            this.lblValorSituacao.TabIndex = 28;
            this.lblValorSituacao.Text = "Situação";
            this.lblValorSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblValorSituacao.Visible = false;
            // 
            // lblCxSituacao
            // 
            this.lblCxSituacao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCxSituacao.BackColor = System.Drawing.Color.White;
            this.lblCxSituacao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCxSituacao.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCxSituacao.ForeColor = System.Drawing.Color.Black;
            this.lblCxSituacao.Location = new System.Drawing.Point(7, 266);
            this.lblCxSituacao.Name = "lblCxSituacao";
            this.lblCxSituacao.Size = new System.Drawing.Size(22, 20);
            this.lblCxSituacao.TabIndex = 29;
            this.lblCxSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCxSituacao.Visible = false;
            // 
            // ttpAssociar
            // 
            this.ttpAssociar.AutoPopDelay = 5000;
            this.ttpAssociar.InitialDelay = 1000;
            this.ttpAssociar.IsBalloon = true;
            this.ttpAssociar.ReshowDelay = 100;
            this.ttpAssociar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpAssociar.ToolTipTitle = "Dica:";
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao.Location = new System.Drawing.Point(7, 404);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 105;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            // 
            // FrmAssociarItemDFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(601, 441);
            this.ControlBox = false;
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.lblValorSituacao);
            this.Controls.Add(this.lblCxSituacao);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.dtItens);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAssociarItemDFe";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Associar Itens sem Código de Barras do DFe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAssociarItemDFe_FormClosing);
            this.Load += new System.EventHandler(this.FrmAssociarItemDFe_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmAssociarItemDFe_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblNome_Desc;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbProduto;
        private System.Windows.Forms.Button btnpProcurarDestinatario;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.DataGridView dtItens;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label lblValorSituacao;
        private System.Windows.Forms.Label lblCxSituacao;
        private System.Windows.Forms.ToolTip ttpAssociar;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtQuantidade;
    }
}