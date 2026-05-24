namespace Seven_Sistema
{
    partial class FrmVersao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVersao));
            this.lblLegenda1 = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.rtxtNovidades = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblLegenda1
            // 
            this.lblLegenda1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLegenda1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLegenda1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLegenda1.Location = new System.Drawing.Point(13, 9);
            this.lblLegenda1.Name = "lblLegenda1";
            this.lblLegenda1.Size = new System.Drawing.Size(609, 18);
            this.lblLegenda1.TabIndex = 4;
            this.lblLegenda1.Text = "Novidades - Sistema SEVEN";
            this.lblLegenda1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(567, 567);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 2;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // rtxtNovidades
            // 
            this.rtxtNovidades.Location = new System.Drawing.Point(13, 25);
            this.rtxtNovidades.Name = "rtxtNovidades";
            this.rtxtNovidades.ReadOnly = true;
            this.rtxtNovidades.Size = new System.Drawing.Size(609, 536);
            this.rtxtNovidades.TabIndex = 1;
            this.rtxtNovidades.Text = "";
            this.rtxtNovidades.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.rtxtNovidades_LinkClicked);
            this.rtxtNovidades.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtNovidades_KeyPress);
            this.rtxtNovidades.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rtxtNovidades_KeyUp);
            // 
            // FrmVersao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(634, 611);
            this.ControlBox = false;
            this.Controls.Add(this.lblLegenda1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.rtxtNovidades);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVersao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Versão do Aplicativo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVersao_FormClosing);
            this.Load += new System.EventHandler(this.FrmVersao_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmVersao_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLegenda1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.RichTextBox rtxtNovidades;
    }
}