namespace Seven_Sistema
{
    partial class FrmFluxoCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFluxoCaixa));
            this.lblLocalizar = new System.Windows.Forms.Label();
            this.dtFluxo = new System.Windows.Forms.DataGridView();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.ttpFluxoCaixa = new System.Windows.Forms.ToolTip(this.components);
            this.lblProgresso = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.lblValorSaldo = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblValorSaida = new System.Windows.Forms.Label();
            this.lblSaida = new System.Windows.Forms.Label();
            this.lblValorEntrada = new System.Windows.Forms.Label();
            this.lblEntrada = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtFluxo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLocalizar
            // 
            this.lblLocalizar.AutoSize = true;
            this.lblLocalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblLocalizar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLocalizar.Location = new System.Drawing.Point(12, 9);
            this.lblLocalizar.Name = "lblLocalizar";
            this.lblLocalizar.Size = new System.Drawing.Size(313, 13);
            this.lblLocalizar.TabIndex = 0;
            this.lblLocalizar.Text = "Informações do fluxo deste caixa com o usuário atual:";
            // 
            // dtFluxo
            // 
            this.dtFluxo.AllowUserToAddRows = false;
            this.dtFluxo.AllowUserToDeleteRows = false;
            this.dtFluxo.AllowUserToResizeRows = false;
            this.dtFluxo.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dtFluxo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtFluxo.Location = new System.Drawing.Point(15, 25);
            this.dtFluxo.MultiSelect = false;
            this.dtFluxo.Name = "dtFluxo";
            this.dtFluxo.ReadOnly = true;
            this.dtFluxo.RowHeadersVisible = false;
            this.dtFluxo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtFluxo.ShowCellErrors = false;
            this.dtFluxo.ShowCellToolTips = false;
            this.dtFluxo.ShowEditingIcon = false;
            this.dtFluxo.ShowRowErrors = false;
            this.dtFluxo.Size = new System.Drawing.Size(826, 194);
            this.dtFluxo.TabIndex = 1;
            this.dtFluxo.DataSourceChanged += new System.EventHandler(this.dtFluxo_DataSourceChanged);
            this.dtFluxo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtFluxo_CellEnter);
            this.dtFluxo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtFluxo_CellFormatting);
            this.dtFluxo.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtFluxo_RowsAdded);
            this.dtFluxo.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtFluxo_RowsRemoved);
            this.dtFluxo.MouseLeave += new System.EventHandler(this.dtFluxo_MouseLeave);
            this.dtFluxo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtFluxo_MouseMove);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.Color.Black;
            this.lblRegistros.Location = new System.Drawing.Point(12, 221);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(160, 26);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Registros: 0";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(771, 251);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(70, 32);
            this.btnVoltar.TabIndex = 3;
            this.btnVoltar.Text = "&Voltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpFluxoCaixa.SetToolTip(this.btnVoltar, "Voltar ao menu anterior.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // ttpFluxoCaixa
            // 
            this.ttpFluxoCaixa.AutoPopDelay = 5000;
            this.ttpFluxoCaixa.InitialDelay = 1000;
            this.ttpFluxoCaixa.IsBalloon = true;
            this.ttpFluxoCaixa.ReshowDelay = 100;
            this.ttpFluxoCaixa.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpFluxoCaixa.ToolTipTitle = "Dica:";
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(244, 85);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(300, 33);
            this.lblProgresso.TabIndex = 235;
            this.lblProgresso.Text = "Por favor, aguarde...";
            this.lblProgresso.Visible = false;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.pgbProgresso.Location = new System.Drawing.Point(235, 118);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(320, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 236;
            this.pgbProgresso.Visible = false;
            // 
            // lblValorSaldo
            // 
            this.lblValorSaldo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorSaldo.BackColor = System.Drawing.Color.White;
            this.lblValorSaldo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorSaldo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorSaldo.ForeColor = System.Drawing.Color.Black;
            this.lblValorSaldo.Location = new System.Drawing.Point(729, 222);
            this.lblValorSaldo.Name = "lblValorSaldo";
            this.lblValorSaldo.Size = new System.Drawing.Size(112, 26);
            this.lblValorSaldo.TabIndex = 237;
            this.lblValorSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorSaldo.Click += new System.EventHandler(this.lblValorSaldo_Click);
            this.lblValorSaldo.MouseLeave += new System.EventHandler(this.lblValorSaldo_MouseLeave);
            this.lblValorSaldo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorSaldo_MouseMove);
            // 
            // lblSaldo
            // 
            this.lblSaldo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSaldo.BackColor = System.Drawing.Color.Transparent;
            this.lblSaldo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.ForeColor = System.Drawing.Color.Black;
            this.lblSaldo.Location = new System.Drawing.Point(634, 221);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(128, 26);
            this.lblSaldo.TabIndex = 238;
            this.lblSaldo.Text = "Saldo (R$):";
            this.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorSaida
            // 
            this.lblValorSaida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorSaida.BackColor = System.Drawing.Color.White;
            this.lblValorSaida.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorSaida.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorSaida.ForeColor = System.Drawing.Color.Black;
            this.lblValorSaida.Location = new System.Drawing.Point(518, 221);
            this.lblValorSaida.Name = "lblValorSaida";
            this.lblValorSaida.Size = new System.Drawing.Size(112, 26);
            this.lblValorSaida.TabIndex = 239;
            this.lblValorSaida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorSaida.Click += new System.EventHandler(this.lblValorSaida_Click);
            this.lblValorSaida.MouseLeave += new System.EventHandler(this.lblValorSaida_MouseLeave);
            this.lblValorSaida.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorSaida_MouseMove);
            // 
            // lblSaida
            // 
            this.lblSaida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSaida.BackColor = System.Drawing.Color.Transparent;
            this.lblSaida.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaida.ForeColor = System.Drawing.Color.Red;
            this.lblSaida.Location = new System.Drawing.Point(414, 220);
            this.lblSaida.Name = "lblSaida";
            this.lblSaida.Size = new System.Drawing.Size(128, 26);
            this.lblSaida.TabIndex = 240;
            this.lblSaida.Text = "Saídas  (R$):";
            this.lblSaida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorEntrada
            // 
            this.lblValorEntrada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorEntrada.BackColor = System.Drawing.Color.White;
            this.lblValorEntrada.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorEntrada.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorEntrada.ForeColor = System.Drawing.Color.Black;
            this.lblValorEntrada.Location = new System.Drawing.Point(297, 222);
            this.lblValorEntrada.Name = "lblValorEntrada";
            this.lblValorEntrada.Size = new System.Drawing.Size(112, 26);
            this.lblValorEntrada.TabIndex = 241;
            this.lblValorEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorEntrada.Click += new System.EventHandler(this.lblValorEntrada_Click);
            this.lblValorEntrada.MouseLeave += new System.EventHandler(this.lblValorEntrada_MouseLeave);
            this.lblValorEntrada.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorEntrada_MouseMove);
            // 
            // lblEntrada
            // 
            this.lblEntrada.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEntrada.BackColor = System.Drawing.Color.Transparent;
            this.lblEntrada.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntrada.ForeColor = System.Drawing.Color.Blue;
            this.lblEntrada.Location = new System.Drawing.Point(178, 221);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(187, 26);
            this.lblEntrada.TabIndex = 242;
            this.lblEntrada.Text = "Entradas (R$):";
            this.lblEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmFluxoCaixa
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(853, 289);
            this.ControlBox = false;
            this.Controls.Add(this.lblValorSaldo);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.lblValorSaida);
            this.Controls.Add(this.lblSaida);
            this.Controls.Add(this.lblValorEntrada);
            this.Controls.Add(this.lblEntrada);
            this.Controls.Add(this.lblProgresso);
            this.Controls.Add(this.pgbProgresso);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.dtFluxo);
            this.Controls.Add(this.lblLocalizar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFluxoCaixa";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fluxo de Caixa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmFluxoCaixa_FormClosing);
            this.Load += new System.EventHandler(this.FrmFluxoCaixa_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmFluxoCaixa_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtFluxo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLocalizar;
        private System.Windows.Forms.DataGridView dtFluxo;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.ToolTip ttpFluxoCaixa;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.Label lblValorSaldo;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblValorSaida;
        private System.Windows.Forms.Label lblSaida;
        private System.Windows.Forms.Label lblValorEntrada;
        private System.Windows.Forms.Label lblEntrada;
    }
}