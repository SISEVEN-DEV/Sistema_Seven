namespace Seven_Sistema
{
    partial class FrmCapOrcamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCapOrcamento));
            this.lblCodOrcamento = new System.Windows.Forms.Label();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblAsterisco = new System.Windows.Forms.Label();
            this.ttpOrcamento = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodOrcamento
            // 
            this.lblCodOrcamento.AutoSize = true;
            this.lblCodOrcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodOrcamento.Location = new System.Drawing.Point(7, 15);
            this.lblCodOrcamento.Name = "lblCodOrcamento";
            this.lblCodOrcamento.Size = new System.Drawing.Size(168, 20);
            this.lblCodOrcamento.TabIndex = 0;
            this.lblCodOrcamento.Text = "Código do Orçamento:";
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.Location = new System.Drawing.Point(148, 44);
            this.picbInterrogacao.Name = "picbInterrogacao";
            this.picbInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao.TabIndex = 99;
            this.picbInterrogacao.TabStop = false;
            this.picbInterrogacao.Click += new System.EventHandler(this.picbInterrogacao_Click);
            this.picbInterrogacao.MouseLeave += new System.EventHandler(this.picbInterrogacao_MouseLeave);
            this.picbInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalvar.Location = new System.Drawing.Point(174, 44);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(72, 32);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(252, 44);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(70, 32);
            this.btnVoltar.TabIndex = 3;
            this.btnVoltar.Text = "&Voltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOrcamento.SetToolTip(this.btnVoltar, "Voltar ao menu anterior.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(186, 12);
            this.txtCodigo.MaxLength = 10;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(136, 26);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.Enter += new System.EventHandler(this.txtCodigo_Enter);
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // lblAsterisco
            // 
            this.lblAsterisco.AutoSize = true;
            this.lblAsterisco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsterisco.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco.Location = new System.Drawing.Point(169, 13);
            this.lblAsterisco.Name = "lblAsterisco";
            this.lblAsterisco.Size = new System.Drawing.Size(15, 20);
            this.lblAsterisco.TabIndex = 0;
            this.lblAsterisco.Text = "*";
            // 
            // ttpOrcamento
            // 
            this.ttpOrcamento.AutoPopDelay = 5000;
            this.ttpOrcamento.InitialDelay = 1000;
            this.ttpOrcamento.IsBalloon = true;
            this.ttpOrcamento.ReshowDelay = 100;
            this.ttpOrcamento.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpOrcamento.ToolTipTitle = "Dica:";
            // 
            // FrmCapOrcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(327, 79);
            this.ControlBox = false;
            this.Controls.Add(this.lblAsterisco);
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodOrcamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCapOrcamento";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capturar um Orçamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCapOrcamento_FormClosing);
            this.Load += new System.EventHandler(this.FrmCapOrcamento_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCapOrcamento_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodOrcamento;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblAsterisco;
        private System.Windows.Forms.ToolTip ttpOrcamento;
    }
}