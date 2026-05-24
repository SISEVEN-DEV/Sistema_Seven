namespace Seven_Sistema
{
    partial class FrmAtualizacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAtualizacao));
            this.btnSair = new System.Windows.Forms.Button();
            this.btnBaixarInstalar = new System.Windows.Forms.Button();
            this.ttpAtualizacao = new System.Windows.Forms.ToolTip(this.components);
            this.lblLegenda1 = new System.Windows.Forms.Label();
            this.lblLegenda2 = new System.Windows.Forms.Label();
            this.rtxtNovidades = new System.Windows.Forms.RichTextBox();
            this.lblLegenda3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(378, 435);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAtualizacao.SetToolTip(this.btnSair, "Sair de Atualização do Software.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnBaixarInstalar
            // 
            this.btnBaixarInstalar.Image = ((System.Drawing.Image)(resources.GetObject("btnBaixarInstalar.Image")));
            this.btnBaixarInstalar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnBaixarInstalar.Location = new System.Drawing.Point(15, 435);
            this.btnBaixarInstalar.Name = "btnBaixarInstalar";
            this.btnBaixarInstalar.Size = new System.Drawing.Size(114, 32);
            this.btnBaixarInstalar.TabIndex = 2;
            this.btnBaixarInstalar.Text = "&Baixar e Instalar";
            this.btnBaixarInstalar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAtualizacao.SetToolTip(this.btnBaixarInstalar, "Clique para baixar e instalar as atualizações dispovíveis.");
            this.btnBaixarInstalar.UseVisualStyleBackColor = true;
            this.btnBaixarInstalar.Click += new System.EventHandler(this.btnBaixarInstalar_Click);
            this.btnBaixarInstalar.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.btnBaixarInstalar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // ttpAtualizacao
            // 
            this.ttpAtualizacao.AutoPopDelay = 5000;
            this.ttpAtualizacao.InitialDelay = 1000;
            this.ttpAtualizacao.IsBalloon = true;
            this.ttpAtualizacao.ReshowDelay = 100;
            this.ttpAtualizacao.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpAtualizacao.ToolTipTitle = "Dica:";
            // 
            // lblLegenda1
            // 
            this.lblLegenda1.AutoSize = true;
            this.lblLegenda1.Location = new System.Drawing.Point(12, 17);
            this.lblLegenda1.Name = "lblLegenda1";
            this.lblLegenda1.Size = new System.Drawing.Size(296, 13);
            this.lblLegenda1.TabIndex = 0;
            this.lblLegenda1.Text = "Uma atualização para o seu Sistema SEVEN está disponível.";
            // 
            // lblLegenda2
            // 
            this.lblLegenda2.AutoSize = true;
            this.lblLegenda2.Location = new System.Drawing.Point(12, 72);
            this.lblLegenda2.Name = "lblLegenda2";
            this.lblLegenda2.Size = new System.Drawing.Size(217, 13);
            this.lblLegenda2.TabIndex = 0;
            this.lblLegenda2.Text = "Deseja aplicar esta nova atualização agora?";
            // 
            // rtxtNovidades
            // 
            this.rtxtNovidades.Location = new System.Drawing.Point(15, 160);
            this.rtxtNovidades.Name = "rtxtNovidades";
            this.rtxtNovidades.Size = new System.Drawing.Size(417, 269);
            this.rtxtNovidades.TabIndex = 1;
            this.rtxtNovidades.Text = "";
            this.rtxtNovidades.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtxtNovidades_LinkClicked);
            this.rtxtNovidades.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtNovidades_KeyPress);
            // 
            // lblLegenda3
            // 
            this.lblLegenda3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLegenda3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegenda3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLegenda3.Location = new System.Drawing.Point(15, 144);
            this.lblLegenda3.Name = "lblLegenda3";
            this.lblLegenda3.Size = new System.Drawing.Size(418, 18);
            this.lblLegenda3.TabIndex = 0;
            this.lblLegenda3.Text = "Novidades - Sistema SEVEN";
            this.lblLegenda3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Todas as outras janelas serão fechadas.";
            // 
            // FrmAtualizacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(449, 473);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLegenda3);
            this.Controls.Add(this.lblLegenda2);
            this.Controls.Add(this.lblLegenda1);
            this.Controls.Add(this.btnBaixarInstalar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.rtxtNovidades);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAtualizacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema SEVEN";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAtualizacao_FormClosing);
            this.Load += new System.EventHandler(this.FrmConfPDV_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmAtualizacao_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnBaixarInstalar;
        private System.Windows.Forms.ToolTip ttpAtualizacao;
        private System.Windows.Forms.Label lblLegenda1;
        private System.Windows.Forms.Label lblLegenda2;
        private System.Windows.Forms.RichTextBox rtxtNovidades;
        private System.Windows.Forms.Label lblLegenda3;
        private System.Windows.Forms.Label label1;
    }
}