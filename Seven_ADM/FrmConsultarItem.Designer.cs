namespace Seven_Sistema
{
    partial class FrmConsultarItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultarItem));
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.dtitem = new System.Windows.Forms.DataGridView();
            this.lblItem = new System.Windows.Forms.Label();
            this.ttpConsultarPagamento = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtitem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(12, 156);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 3;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(717, 159);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 6;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpConsultarPagamento.SetToolTip(this.btnVoltar, "Sair da Consulta de Itens.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // dtitem
            // 
            this.dtitem.AllowUserToAddRows = false;
            this.dtitem.AllowUserToDeleteRows = false;
            this.dtitem.AllowUserToResizeRows = false;
            this.dtitem.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtitem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtitem.Enabled = false;
            this.dtitem.Location = new System.Drawing.Point(0, 25);
            this.dtitem.MultiSelect = false;
            this.dtitem.Name = "dtitem";
            this.dtitem.ReadOnly = true;
            this.dtitem.RowHeadersVisible = false;
            this.dtitem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtitem.ShowCellErrors = false;
            this.dtitem.ShowCellToolTips = false;
            this.dtitem.ShowEditingIcon = false;
            this.dtitem.ShowRowErrors = false;
            this.dtitem.Size = new System.Drawing.Size(784, 128);
            this.dtitem.TabIndex = 5;
            this.dtitem.DataSourceChanged += new System.EventHandler(this.dtitem_DataSourceChanged);
            this.dtitem.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtitem_CellEnter);
            this.dtitem.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtitem_CellFormatting);
            this.dtitem.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtitem_RowsAdded);
            this.dtitem.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtitem_RowsRemoved);
            this.dtitem.MouseLeave += new System.EventHandler(this.dtitem_MouseLeave);
            this.dtitem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtitem_MouseMove);
            // 
            // lblItem
            // 
            this.lblItem.BackColor = System.Drawing.Color.AliceBlue;
            this.lblItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(0, 1);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(784, 25);
            this.lblItem.TabIndex = 4;
            this.lblItem.Text = "Item(ns)";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // FrmConsultarItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(784, 195);
            this.ControlBox = false;
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.dtitem);
            this.Controls.Add(this.lblItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultarItem";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Itens";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConsultarItemVenda_FormClosing);
            this.Load += new System.EventHandler(this.FrmConsultarItemVenda_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmConsultarItemVenda_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtitem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DataGridView dtitem;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.ToolTip ttpConsultarPagamento;
    }
}