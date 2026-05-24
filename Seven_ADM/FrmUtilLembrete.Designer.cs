namespace Seven_Sistema
{
    partial class FrmUtilLembrete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUtilLembrete));
            this.lblValorHorario = new System.Windows.Forms.Label();
            this.lblValorDescricao = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnAdiar = new System.Windows.Forms.Button();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.TempoLabel = new System.Windows.Forms.Timer(this.components);
            this.ttpLembrete = new System.Windows.Forms.ToolTip(this.components);
            this.btnOBservacao = new System.Windows.Forms.Button();
            this.lblValorDataVencimento = new System.Windows.Forms.Label();
            this.TempoSom = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblValorHorario
            // 
            this.lblValorHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorHorario.ForeColor = System.Drawing.Color.Red;
            this.lblValorHorario.Location = new System.Drawing.Point(12, 9);
            this.lblValorHorario.Name = "lblValorHorario";
            this.lblValorHorario.Size = new System.Drawing.Size(341, 105);
            this.lblValorHorario.TabIndex = 0;
            this.lblValorHorario.Text = "00:00";
            this.lblValorHorario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValorDescricao
            // 
            this.lblValorDescricao.BackColor = System.Drawing.Color.White;
            this.lblValorDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValorDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDescricao.Location = new System.Drawing.Point(12, 127);
            this.lblValorDescricao.Name = "lblValorDescricao";
            this.lblValorDescricao.Size = new System.Drawing.Size(341, 64);
            this.lblValorDescricao.TabIndex = 1;
            this.lblValorDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblValorDescricao.MouseLeave += new System.EventHandler(this.lblValorDescricao_MouseLeave);
            this.lblValorDescricao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorDescricao_MouseMove);
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(151, 112);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 2;
            this.lblDescricao.Text = "Descrição:";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Image = ((System.Drawing.Image)(resources.GetObject("btnFinalizar.Image")));
            this.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnFinalizar.Location = new System.Drawing.Point(12, 194);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(80, 32);
            this.btnFinalizar.TabIndex = 199;
            this.btnFinalizar.Text = "&Finalizar";
            this.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnFinalizar, "Clique para finalizar o lembrete.");
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            this.btnFinalizar.MouseLeave += new System.EventHandler(this.btnFinalizar_MouseLeave);
            this.btnFinalizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnFinalizar_MouseMove);
            // 
            // btnAdiar
            // 
            this.btnAdiar.Image = ((System.Drawing.Image)(resources.GetObject("btnAdiar.Image")));
            this.btnAdiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdiar.Location = new System.Drawing.Point(289, 194);
            this.btnAdiar.Name = "btnAdiar";
            this.btnAdiar.Size = new System.Drawing.Size(64, 32);
            this.btnAdiar.TabIndex = 200;
            this.btnAdiar.Text = "&Adiar";
            this.btnAdiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnAdiar, "Clique para adiar a finalização do lembrete.");
            this.btnAdiar.UseVisualStyleBackColor = true;
            this.btnAdiar.Click += new System.EventHandler(this.btnAdiar_Click);
            this.btnAdiar.MouseLeave += new System.EventHandler(this.btnAdiar_MouseLeave);
            this.btnAdiar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAdiar_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(12, 104);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 201;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // TempoLabel
            // 
            this.TempoLabel.Interval = 1000;
            this.TempoLabel.Tick += new System.EventHandler(this.TemporalizadorLabel_Tick);
            // 
            // ttpLembrete
            // 
            this.ttpLembrete.AutoPopDelay = 5000;
            this.ttpLembrete.InitialDelay = 1000;
            this.ttpLembrete.IsBalloon = true;
            this.ttpLembrete.ReshowDelay = 100;
            this.ttpLembrete.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpLembrete.ToolTipTitle = "Dica:";
            // 
            // btnOBservacao
            // 
            this.btnOBservacao.Image = ((System.Drawing.Image)(resources.GetObject("btnOBservacao.Image")));
            this.btnOBservacao.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnOBservacao.Location = new System.Drawing.Point(139, 194);
            this.btnOBservacao.Name = "btnOBservacao";
            this.btnOBservacao.Size = new System.Drawing.Size(105, 32);
            this.btnOBservacao.TabIndex = 204;
            this.btnOBservacao.Text = "&Observações";
            this.btnOBservacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnOBservacao, "Clique para finalizar o lembrete.");
            this.btnOBservacao.UseVisualStyleBackColor = true;
            this.btnOBservacao.Click += new System.EventHandler(this.btnOBservacao_Click);
            this.btnOBservacao.MouseLeave += new System.EventHandler(this.btnOBservacao_MouseLeave);
            this.btnOBservacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOBservacao_MouseMove);
            // 
            // lblValorDataVencimento
            // 
            this.lblValorDataVencimento.Location = new System.Drawing.Point(9, 9);
            this.lblValorDataVencimento.Name = "lblValorDataVencimento";
            this.lblValorDataVencimento.Size = new System.Drawing.Size(344, 13);
            this.lblValorDataVencimento.TabIndex = 203;
            this.lblValorDataVencimento.Text = "Data:";
            // 
            // TempoSom
            // 
            this.TempoSom.Interval = 10000;
            this.TempoSom.Tick += new System.EventHandler(this.TempoSom_Tick);
            // 
            // FrmUtilLembrete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(365, 232);
            this.ControlBox = false;
            this.Controls.Add(this.btnOBservacao);
            this.Controls.Add(this.lblValorDataVencimento);
            this.Controls.Add(this.picbInterrogacao1);
            this.Controls.Add(this.btnAdiar);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblValorDescricao);
            this.Controls.Add(this.lblValorHorario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUtilLembrete";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lembrete";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUtilLembrete_FormClosing);
            this.Load += new System.EventHandler(this.FrmAlarme_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPesquisarTipoIndicacao_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValorHorario;
        private System.Windows.Forms.Label lblValorDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnAdiar;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Timer TempoLabel;
        private System.Windows.Forms.ToolTip ttpLembrete;
        private System.Windows.Forms.Label lblValorDataVencimento;
        private System.Windows.Forms.Button btnOBservacao;
        private System.Windows.Forms.Timer TempoSom;
    }
}