namespace Seven_Sistema
{
    partial class FrmConsultarPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultarPagamento));
            this.lblLegenda = new System.Windows.Forms.Label();
            this.dtPagamento = new System.Windows.Forms.DataGridView();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.ttpConsultarPagamento = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtPagamento)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLegenda
            // 
            this.lblLegenda.BackColor = System.Drawing.Color.AliceBlue;
            this.lblLegenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLegenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegenda.Location = new System.Drawing.Point(1, 0);
            this.lblLegenda.Name = "lblLegenda";
            this.lblLegenda.Size = new System.Drawing.Size(783, 25);
            this.lblLegenda.TabIndex = 0;
            this.lblLegenda.Text = "Pagamento(s)";
            this.lblLegenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtPagamento
            // 
            this.dtPagamento.AllowUserToAddRows = false;
            this.dtPagamento.AllowUserToDeleteRows = false;
            this.dtPagamento.AllowUserToResizeRows = false;
            this.dtPagamento.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtPagamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtPagamento.Enabled = false;
            this.dtPagamento.Location = new System.Drawing.Point(1, 24);
            this.dtPagamento.MultiSelect = false;
            this.dtPagamento.Name = "dtPagamento";
            this.dtPagamento.ReadOnly = true;
            this.dtPagamento.RowHeadersVisible = false;
            this.dtPagamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtPagamento.ShowCellErrors = false;
            this.dtPagamento.ShowCellToolTips = false;
            this.dtPagamento.ShowEditingIcon = false;
            this.dtPagamento.ShowRowErrors = false;
            this.dtPagamento.Size = new System.Drawing.Size(783, 128);
            this.dtPagamento.TabIndex = 1;
            this.dtPagamento.DataSourceChanged += new System.EventHandler(this.dtPagamento_DataSourceChanged);
            this.dtPagamento.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtPagamento_CellEnter);
            this.dtPagamento.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtPagamento_CellFormatting);
            this.dtPagamento.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtFormaPagamento_RowsAdded);
            this.dtPagamento.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtPagamento_RowsRemoved);
            this.dtPagamento.MouseLeave += new System.EventHandler(this.dtPagamento_MouseLeave);
            this.dtPagamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtPagamento_MouseMove);
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(717, 158);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 2;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpConsultarPagamento.SetToolTip(this.btnVoltar, "Sair da Consulta de Pagamentos.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(12, 155);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ttpConsultarPagamento
            // 
            this.ttpConsultarPagamento.AutoPopDelay = 5000;
            this.ttpConsultarPagamento.InitialDelay = 1000;
            this.ttpConsultarPagamento.IsBalloon = true;
            this.ttpConsultarPagamento.ReshowDelay = 100;
            this.ttpConsultarPagamento.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpConsultarPagamento.ToolTipTitle = "Dica:";
            // 
            // FrmConsultarPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(784, 193);
            this.ControlBox = false;
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.dtPagamento);
            this.Controls.Add(this.lblLegenda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultarPagamento";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Pagamentos";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOpeConsultarPagamentoContaReceber_FormClosing);
            this.Load += new System.EventHandler(this.FrmOpeConsultarPagamentoContaReceber_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmOpeConsultarPagamentoContaReceber_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtPagamento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLegenda;
        private System.Windows.Forms.DataGridView dtPagamento;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.ToolTip ttpConsultarPagamento;
    }
}