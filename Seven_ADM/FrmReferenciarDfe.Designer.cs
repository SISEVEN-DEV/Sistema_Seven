namespace Seven_Sistema
{
    partial class FrmReferenciarDfe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReferenciarDfe));
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.dtRef = new System.Windows.Forms.DataGridView();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.btnpProcurarDFe = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblChave = new System.Windows.Forms.Label();
            this.mtxtChave = new System.Windows.Forms.MaskedTextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ttpReferenciaDFe = new System.Windows.Forms.ToolTip(this.components);
            this.btnSair = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtRef)).BeginInit();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAlterar
            // 
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAlterar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAlterar.Location = new System.Drawing.Point(112, 242);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 32);
            this.btnAlterar.TabIndex = 7;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpReferenciaDFe.SetToolTip(this.btnAlterar, "Alterar uma Referência cadastrada.");
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnAlterar.MouseLeave += new System.EventHandler(this.btnAlterar_MouseLeave);
            this.btnAlterar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterar_MouseMove);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExcluir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExcluir.Location = new System.Drawing.Point(188, 242);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(74, 32);
            this.btnExcluir.TabIndex = 8;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpReferenciaDFe.SetToolTip(this.btnExcluir, "Excluir uma Referência cadastrada.");
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            this.btnExcluir.MouseLeave += new System.EventHandler(this.btnExcluirItem_MouseLeave);
            this.btnExcluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluirItem_MouseMove);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnNovo.Location = new System.Drawing.Point(38, 242);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(68, 32);
            this.btnNovo.TabIndex = 6;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpReferenciaDFe.SetToolTip(this.btnNovo, "Cadastrar uma nova Referência.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnIncluir_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnIncluir_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnIncluir_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalvar.Location = new System.Drawing.Point(359, 242);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 10;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpReferenciaDFe.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // dtRef
            // 
            this.dtRef.AllowUserToAddRows = false;
            this.dtRef.AllowUserToDeleteRows = false;
            this.dtRef.AllowUserToResizeRows = false;
            this.dtRef.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtRef.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtRef.Enabled = false;
            this.dtRef.Location = new System.Drawing.Point(12, 12);
            this.dtRef.MultiSelect = false;
            this.dtRef.Name = "dtRef";
            this.dtRef.ReadOnly = true;
            this.dtRef.RowHeadersVisible = false;
            this.dtRef.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtRef.ShowCellErrors = false;
            this.dtRef.ShowCellToolTips = false;
            this.dtRef.ShowEditingIcon = false;
            this.dtRef.ShowRowErrors = false;
            this.dtRef.Size = new System.Drawing.Size(478, 128);
            this.dtRef.TabIndex = 1;
            this.dtRef.DataSourceChanged += new System.EventHandler(this.dtRef_DataSourceChanged);
            this.dtRef.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtRef_CellEnter);
            this.dtRef.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtRef_RowsAdded);
            this.dtRef.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtRef_RowsRemoved);
            this.dtRef.MouseLeave += new System.EventHandler(this.dtRef_MouseLeave);
            this.dtRef.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtRef_MouseMove);
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.btnpProcurarDFe);
            this.grbBox2.Controls.Add(this.label2);
            this.grbBox2.Controls.Add(this.lblChave);
            this.grbBox2.Controls.Add(this.mtxtChave);
            this.grbBox2.Controls.Add(this.txtCodigo);
            this.grbBox2.Controls.Add(this.lblCodigo);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(12, 172);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(478, 64);
            this.grbBox2.TabIndex = 2;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Cadastrar, alterar e excluir:";
            // 
            // btnpProcurarDFe
            // 
            this.btnpProcurarDFe.Image = ((System.Drawing.Image)(resources.GetObject("btnpProcurarDFe.Image")));
            this.btnpProcurarDFe.Location = new System.Drawing.Point(445, 29);
            this.btnpProcurarDFe.Name = "btnpProcurarDFe";
            this.btnpProcurarDFe.Size = new System.Drawing.Size(26, 25);
            this.btnpProcurarDFe.TabIndex = 5;
            this.btnpProcurarDFe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpReferenciaDFe.SetToolTip(this.btnpProcurarDFe, "Clique para pesquisar um DFe.");
            this.btnpProcurarDFe.UseVisualStyleBackColor = true;
            this.btnpProcurarDFe.Click += new System.EventHandler(this.btnpProcurarDFe_Click);
            this.btnpProcurarDFe.MouseLeave += new System.EventHandler(this.btnpProcurarDFe_MouseLeave);
            this.btnpProcurarDFe.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnpProcurarDFe_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(88, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "*";
            // 
            // lblChave
            // 
            this.lblChave.AutoSize = true;
            this.lblChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblChave.Location = new System.Drawing.Point(52, 16);
            this.lblChave.Name = "lblChave";
            this.lblChave.Size = new System.Drawing.Size(41, 13);
            this.lblChave.TabIndex = 0;
            this.lblChave.Text = "Chave:";
            // 
            // mtxtChave
            // 
            this.mtxtChave.BackColor = System.Drawing.Color.White;
            this.mtxtChave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtChave.Location = new System.Drawing.Point(55, 32);
            this.mtxtChave.Mask = "00-0000-00,000,000/0000-00-00-000-000,000,000-0-00,000,000-0";
            this.mtxtChave.Name = "mtxtChave";
            this.mtxtChave.Size = new System.Drawing.Size(384, 20);
            this.mtxtChave.TabIndex = 4;
            this.mtxtChave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtChave.Enter += new System.EventHandler(this.mtxtChave_Enter);
            this.mtxtChave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtChave_KeyPress);
            this.mtxtChave.Leave += new System.EventHandler(this.mtxtChave_Leave);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCodigo.Location = new System.Drawing.Point(6, 32);
            this.txtCodigo.MaxLength = 8;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(43, 20);
            this.txtCodigo.TabIndex = 3;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.ForeColor = System.Drawing.Color.Black;
            this.lblCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCodigo.Location = new System.Drawing.Point(3, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao.Location = new System.Drawing.Point(12, 242);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 96;
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
            this.btnCancelar.Location = new System.Drawing.Point(268, 242);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpReferenciaDFe.SetToolTip(this.btnCancelar, "Cancelar opção atual.");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            this.btnCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelar_MouseMove);
            // 
            // ttpReferenciaDFe
            // 
            this.ttpReferenciaDFe.AutoPopDelay = 5000;
            this.ttpReferenciaDFe.InitialDelay = 1000;
            this.ttpReferenciaDFe.IsBalloon = true;
            this.ttpReferenciaDFe.ReshowDelay = 100;
            this.ttpReferenciaDFe.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpReferenciaDFe.ToolTipTitle = "Dica:";
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(435, 242);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 11;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpReferenciaDFe.SetToolTip(this.btnSair, "Sair de Referenciar DFe.");
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
            this.lblRegistros.Location = new System.Drawing.Point(9, 143);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmReferenciarDfe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(502, 280);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.grbBox2);
            this.Controls.Add(this.dtRef);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnNovo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReferenciarDfe";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Referenciar DFe";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmReferenciarDfe_FormClosing);
            this.Load += new System.EventHandler(this.FrmReferenciarDfe_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmReferenciarDfe_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtRef)).EndInit();
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridView dtRef;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblChave;
        private System.Windows.Forms.MaskedTextBox mtxtChave;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip ttpReferenciaDFe;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnpProcurarDFe;
    }
}