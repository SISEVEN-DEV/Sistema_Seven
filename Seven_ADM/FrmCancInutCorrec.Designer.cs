namespace Seven_Sistema
{
    partial class FrmCancInutCorrec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCancInutCorrec));
            this.lblDescricao = new System.Windows.Forms.Label();
            this.picbInterrogacao = new System.Windows.Forms.PictureBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.txtJustificativa = new System.Windows.Forms.TextBox();
            this.lblAsterisco = new System.Windows.Forms.Label();
            this.ttpJust = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.Location = new System.Drawing.Point(12, 15);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(109, 20);
            this.lblDescricao.TabIndex = 0;
            this.lblDescricao.Text = "Justificativa:";
            // 
            // picbInterrogacao
            // 
            this.picbInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao.Image")));
            this.picbInterrogacao.Location = new System.Drawing.Point(404, 44);
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
            this.btnSalvar.Location = new System.Drawing.Point(430, 44);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(72, 32);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpJust.SetToolTip(this.btnSalvar, "Clique para salvar o dado informado.");
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
            this.btnVoltar.Location = new System.Drawing.Point(508, 44);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 3;
            this.btnVoltar.Text = "Sai&r";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpJust.SetToolTip(this.btnVoltar, "Sair de Justificativa de Cancelamento.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // txtJustificativa
            // 
            this.txtJustificativa.BackColor = System.Drawing.Color.White;
            this.txtJustificativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJustificativa.Location = new System.Drawing.Point(127, 12);
            this.txtJustificativa.MaxLength = 100;
            this.txtJustificativa.Name = "txtJustificativa";
            this.txtJustificativa.Size = new System.Drawing.Size(436, 26);
            this.txtJustificativa.TabIndex = 1;
            this.txtJustificativa.Enter += new System.EventHandler(this.txtValor_Enter);
            this.txtJustificativa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValor_KeyPress);
            this.txtJustificativa.Leave += new System.EventHandler(this.txtValor_Leave);
            // 
            // lblAsterisco
            // 
            this.lblAsterisco.AutoSize = true;
            this.lblAsterisco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco.Location = new System.Drawing.Point(114, 13);
            this.lblAsterisco.Name = "lblAsterisco";
            this.lblAsterisco.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco.TabIndex = 100;
            this.lblAsterisco.Text = "*";
            // 
            // ttpJust
            // 
            this.ttpJust.AutoPopDelay = 5000;
            this.ttpJust.InitialDelay = 1000;
            this.ttpJust.IsBalloon = true;
            this.ttpJust.ReshowDelay = 100;
            this.ttpJust.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpJust.ToolTipTitle = "Dica:";
            // 
            // FrmCancInutCorrec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(572, 82);
            this.ControlBox = false;
            this.Controls.Add(this.txtJustificativa);
            this.Controls.Add(this.lblAsterisco);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.picbInterrogacao);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnVoltar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCancInutCorrec";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Justificativa de Cancelamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCancelamentoVenda_FormClosing);
            this.Load += new System.EventHandler(this.FrmCancelamentoVenda_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCancelamentoVenda_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.PictureBox picbInterrogacao;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.TextBox txtJustificativa;
        private System.Windows.Forms.Label lblAsterisco;
        private System.Windows.Forms.ToolTip ttpJust;
    }
}