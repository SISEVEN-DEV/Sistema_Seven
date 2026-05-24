namespace Seven_Sistema
{
    partial class FrmCadDFeParcelamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadDFeParcelamento));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblItem = new System.Windows.Forms.Label();
            this.dtItens = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.txtValorDocumento = new System.Windows.Forms.TextBox();
            this.lblAsterisco8 = new System.Windows.Forms.Label();
            this.lblValorDocumento = new System.Windows.Forms.Label();
            this.btnPesquisarData = new System.Windows.Forms.Button();
            this.lblAsterisco4 = new System.Windows.Forms.Label();
            this.lblDataVencimento = new System.Windows.Forms.Label();
            this.mtxtDataVencimento = new System.Windows.Forms.MaskedTextBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblDiferenca = new System.Windows.Forms.Label();
            this.ttpItem = new System.Windows.Forms.ToolTip(this.components);
            this.lblTotalNF = new System.Windows.Forms.Label();
            this.lblTotalParcelamento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtItens)).BeginInit();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar.Location = new System.Drawing.Point(417, 418);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 81;
            this.btnVoltar.Text = "Sai&r";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpItem.SetToolTip(this.btnVoltar, "Sair do cadastro de Parcelamento de DFe.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            // 
            // lblItem
            // 
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(12, 9);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(455, 14);
            this.lblItem.TabIndex = 0;
            this.lblItem.Text = "Itens:";
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
            this.dtItens.Location = new System.Drawing.Point(15, 26);
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
            this.dtItens.Size = new System.Drawing.Size(452, 238);
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
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.txtValorDocumento);
            this.grbBox1.Controls.Add(this.lblAsterisco8);
            this.grbBox1.Controls.Add(this.lblValorDocumento);
            this.grbBox1.Controls.Add(this.btnPesquisarData);
            this.grbBox1.Controls.Add(this.lblAsterisco4);
            this.grbBox1.Controls.Add(this.lblDataVencimento);
            this.grbBox1.Controls.Add(this.mtxtDataVencimento);
            this.grbBox1.Enabled = false;
            this.grbBox1.Location = new System.Drawing.Point(15, 352);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(454, 60);
            this.grbBox1.TabIndex = 2;
            this.grbBox1.TabStop = false;
            // 
            // txtValorDocumento
            // 
            this.txtValorDocumento.BackColor = System.Drawing.Color.White;
            this.txtValorDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorDocumento.Location = new System.Drawing.Point(354, 32);
            this.txtValorDocumento.MaxLength = 15;
            this.txtValorDocumento.Name = "txtValorDocumento";
            this.txtValorDocumento.Size = new System.Drawing.Size(92, 20);
            this.txtValorDocumento.TabIndex = 91;
            this.txtValorDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorDocumento.Enter += new System.EventHandler(this.txtValorDocumento_Enter);
            this.txtValorDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorDocumento_KeyPress);
            this.txtValorDocumento.Leave += new System.EventHandler(this.txtValorDocumento_Leave);
            // 
            // lblAsterisco8
            // 
            this.lblAsterisco8.AutoSize = true;
            this.lblAsterisco8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco8.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco8.Location = new System.Drawing.Point(403, 14);
            this.lblAsterisco8.Name = "lblAsterisco8";
            this.lblAsterisco8.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco8.TabIndex = 0;
            this.lblAsterisco8.Text = "*";
            // 
            // lblValorDocumento
            // 
            this.lblValorDocumento.AutoSize = true;
            this.lblValorDocumento.Location = new System.Drawing.Point(351, 16);
            this.lblValorDocumento.Name = "lblValorDocumento";
            this.lblValorDocumento.Size = new System.Drawing.Size(57, 13);
            this.lblValorDocumento.TabIndex = 0;
            this.lblValorDocumento.Text = "Valor (R$):";
            // 
            // btnPesquisarData
            // 
            this.btnPesquisarData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisarData.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisarData.Image")));
            this.btnPesquisarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisarData.Location = new System.Drawing.Point(90, 29);
            this.btnPesquisarData.Name = "btnPesquisarData";
            this.btnPesquisarData.Size = new System.Drawing.Size(26, 25);
            this.btnPesquisarData.TabIndex = 4;
            this.btnPesquisarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpItem.SetToolTip(this.btnPesquisarData, "Clique para selecionar as datas.");
            this.btnPesquisarData.UseVisualStyleBackColor = true;
            this.btnPesquisarData.Click += new System.EventHandler(this.btnPesquisarData_Click);
            // 
            // lblAsterisco4
            // 
            this.lblAsterisco4.AutoSize = true;
            this.lblAsterisco4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco4.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco4.Location = new System.Drawing.Point(105, 14);
            this.lblAsterisco4.Name = "lblAsterisco4";
            this.lblAsterisco4.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco4.TabIndex = 0;
            this.lblAsterisco4.Text = "*";
            // 
            // lblDataVencimento
            // 
            this.lblDataVencimento.AutoSize = true;
            this.lblDataVencimento.Location = new System.Drawing.Point(3, 16);
            this.lblDataVencimento.Name = "lblDataVencimento";
            this.lblDataVencimento.Size = new System.Drawing.Size(107, 13);
            this.lblDataVencimento.TabIndex = 0;
            this.lblDataVencimento.Text = "Data de Vencimento:";
            // 
            // mtxtDataVencimento
            // 
            this.mtxtDataVencimento.BackColor = System.Drawing.Color.White;
            this.mtxtDataVencimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtDataVencimento.Location = new System.Drawing.Point(6, 32);
            this.mtxtDataVencimento.Mask = "00/00/0000";
            this.mtxtDataVencimento.Name = "mtxtDataVencimento";
            this.mtxtDataVencimento.Size = new System.Drawing.Size(78, 20);
            this.mtxtDataVencimento.TabIndex = 3;
            this.mtxtDataVencimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxtDataVencimento.ValidatingType = typeof(System.DateTime);
            this.mtxtDataVencimento.DoubleClick += new System.EventHandler(this.mtxtDataVencimento_DoubleClick);
            this.mtxtDataVencimento.Enter += new System.EventHandler(this.mtxtDataVencimento_Enter);
            this.mtxtDataVencimento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtxtDataVencimento_KeyDown);
            this.mtxtDataVencimento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtDataVencimento_KeyPress);
            this.mtxtDataVencimento.Leave += new System.EventHandler(this.mtxtDataVencimento_Leave);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(10, 267);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(115, 16);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.Location = new System.Drawing.Point(236, 418);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 87;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpItem.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(15, 418);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 88;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAlterar.Location = new System.Drawing.Point(41, 418);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 32);
            this.btnAlterar.TabIndex = 89;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpItem.SetToolTip(this.btnAlterar, "Alterar um Parcelamento cadastrado.");
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizar.Image = ((System.Drawing.Image)(resources.GetObject("btnFinalizar.Image")));
            this.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFinalizar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFinalizar.Location = new System.Drawing.Point(331, 418);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(80, 32);
            this.btnFinalizar.TabIndex = 90;
            this.btnFinalizar.Text = "&Finalizar";
            this.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpItem.SetToolTip(this.btnFinalizar, "Clique para Finalizar o parcelamento do DFe.");
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.Location = new System.Drawing.Point(145, 418);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 91;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpItem.SetToolTip(this.btnCancelar, "Cancelar a opção atual.");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblDiferenca
            // 
            this.lblDiferenca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDiferenca.BackColor = System.Drawing.Color.Transparent;
            this.lblDiferenca.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferenca.ForeColor = System.Drawing.Color.Red;
            this.lblDiferenca.Location = new System.Drawing.Point(12, 331);
            this.lblDiferenca.Name = "lblDiferenca";
            this.lblDiferenca.Size = new System.Drawing.Size(455, 22);
            this.lblDiferenca.TabIndex = 0;
            this.lblDiferenca.Text = "Diferença: 0,00";
            this.lblDiferenca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ttpItem
            // 
            this.ttpItem.AutoPopDelay = 5000;
            this.ttpItem.InitialDelay = 1000;
            this.ttpItem.IsBalloon = true;
            this.ttpItem.ReshowDelay = 100;
            this.ttpItem.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpItem.ToolTipTitle = "Dica:";
            // 
            // lblTotalNF
            // 
            this.lblTotalNF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalNF.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalNF.ForeColor = System.Drawing.Color.Black;
            this.lblTotalNF.Location = new System.Drawing.Point(12, 287);
            this.lblTotalNF.Name = "lblTotalNF";
            this.lblTotalNF.Size = new System.Drawing.Size(455, 22);
            this.lblTotalNF.TabIndex = 92;
            this.lblTotalNF.Text = "Total da NF: 0,00";
            this.lblTotalNF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalParcelamento
            // 
            this.lblTotalParcelamento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalParcelamento.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalParcelamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalParcelamento.ForeColor = System.Drawing.Color.Black;
            this.lblTotalParcelamento.Location = new System.Drawing.Point(12, 309);
            this.lblTotalParcelamento.Name = "lblTotalParcelamento";
            this.lblTotalParcelamento.Size = new System.Drawing.Size(455, 22);
            this.lblTotalParcelamento.TabIndex = 93;
            this.lblTotalParcelamento.Text = "Total dos Parcelamentos: 0,00";
            this.lblTotalParcelamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmCadDFeParcelamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(474, 452);
            this.ControlBox = false;
            this.Controls.Add(this.lblTotalParcelamento);
            this.Controls.Add(this.lblTotalNF);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.picbInterrogacao1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.dtItens);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblDiferenca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadDFeParcelamento";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parcelamento de DFe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCadDFeParcelamento_FormClosing);
            this.Load += new System.EventHandler(this.FrmContatoFeedBack_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadDFeParcelamento_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtItens)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.DataGridView dtItens;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnPesquisarData;
        private System.Windows.Forms.Label lblAsterisco4;
        private System.Windows.Forms.Label lblDataVencimento;
        private System.Windows.Forms.MaskedTextBox mtxtDataVencimento;
        private System.Windows.Forms.TextBox txtValorDocumento;
        private System.Windows.Forms.Label lblAsterisco8;
        private System.Windows.Forms.Label lblValorDocumento;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblDiferenca;
        private System.Windows.Forms.ToolTip ttpItem;
        private System.Windows.Forms.Label lblTotalNF;
        private System.Windows.Forms.Label lblTotalParcelamento;
    }
}