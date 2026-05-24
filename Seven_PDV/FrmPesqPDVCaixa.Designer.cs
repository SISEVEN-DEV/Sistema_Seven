namespace Seven_Sistema
{
    partial class FrmPesqPDVCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesqPDVCaixa));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.dtPesquisa = new System.Windows.Forms.DataGridView();
            this.lblPesquisa = new System.Windows.Forms.Label();
            this.ttpPDV = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtPesquisa)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(552, 156);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(70, 32);
            this.btnVoltar.TabIndex = 16;
            this.btnVoltar.Text = "V&oltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPDV.SetToolTip(this.btnVoltar, "Sair da pesquisa de PDVs.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(12, 156);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(164, 26);
            this.lblRegistros.TabIndex = 13;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnIncluir
            // 
            this.btnIncluir.Enabled = false;
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(476, 156);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(70, 32);
            this.btnIncluir.TabIndex = 15;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpPDV.SetToolTip(this.btnIncluir, "Clique para incluir os dados.");
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            this.btnIncluir.MouseLeave += new System.EventHandler(this.btnIncluir_MouseLeave);
            this.btnIncluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnIncluir_MouseMove);
            // 
            // dtPesquisa
            // 
            this.dtPesquisa.AllowUserToAddRows = false;
            this.dtPesquisa.AllowUserToDeleteRows = false;
            this.dtPesquisa.AllowUserToOrderColumns = true;
            this.dtPesquisa.AllowUserToResizeRows = false;
            this.dtPesquisa.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dtPesquisa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtPesquisa.Enabled = false;
            this.dtPesquisa.Location = new System.Drawing.Point(12, 25);
            this.dtPesquisa.MultiSelect = false;
            this.dtPesquisa.Name = "dtPesquisa";
            this.dtPesquisa.ReadOnly = true;
            this.dtPesquisa.RowHeadersVisible = false;
            this.dtPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtPesquisa.ShowCellErrors = false;
            this.dtPesquisa.ShowCellToolTips = false;
            this.dtPesquisa.ShowEditingIcon = false;
            this.dtPesquisa.ShowRowErrors = false;
            this.dtPesquisa.Size = new System.Drawing.Size(610, 128);
            this.dtPesquisa.TabIndex = 14;
            this.dtPesquisa.DataSourceChanged += new System.EventHandler(this.dtPesquisa_DataSourceChanged);
            this.dtPesquisa.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtPesquisa_CellEnter);
            this.dtPesquisa.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtPesquisa_RowsAdded);
            this.dtPesquisa.DoubleClick += new System.EventHandler(this.dtPesquisa_DoubleClick);
            this.dtPesquisa.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtPesquisa_KeyUp);
            this.dtPesquisa.MouseLeave += new System.EventHandler(this.dtPesquisa_MouseLeave);
            this.dtPesquisa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtPesquisa_MouseMove);
            // 
            // lblPesquisa
            // 
            this.lblPesquisa.AutoSize = true;
            this.lblPesquisa.Location = new System.Drawing.Point(9, 9);
            this.lblPesquisa.Name = "lblPesquisa";
            this.lblPesquisa.Size = new System.Drawing.Size(77, 13);
            this.lblPesquisa.TabIndex = 17;
            this.lblPesquisa.Text = "Lista de PDVs:";
            // 
            // ttpPDV
            // 
            this.ttpPDV.AutoPopDelay = 5000;
            this.ttpPDV.InitialDelay = 1000;
            this.ttpPDV.IsBalloon = true;
            this.ttpPDV.ReshowDelay = 100;
            this.ttpPDV.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpPDV.ToolTipTitle = "Dica:";
            // 
            // FrmPesqPDVCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(631, 191);
            this.ControlBox = false;
            this.Controls.Add(this.lblPesquisa);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.dtPesquisa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesqPDVCaixa";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Pesquisar PDVs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPesqPDVCaixa_FormClosing);
            this.Load += new System.EventHandler(this.FrmPesqPDVCaixa_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPesqPDVCaixa_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtPesquisa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.DataGridView dtPesquisa;
        private System.Windows.Forms.Label lblPesquisa;
        private System.Windows.Forms.ToolTip ttpPDV;
    }
}