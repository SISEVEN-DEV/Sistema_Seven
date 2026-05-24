namespace Seven_Sistema
{
    partial class FrmTroco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTroco));
            this.ttpContasPagar = new System.Windows.Forms.ToolTip(this.components);
            this.lblDados = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblValorTroco = new System.Windows.Forms.Label();
            this.lblTroco = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttpContasPagar
            // 
            this.ttpContasPagar.AutoPopDelay = 5000;
            this.ttpContasPagar.InitialDelay = 1000;
            this.ttpContasPagar.IsBalloon = true;
            this.ttpContasPagar.ReshowDelay = 100;
            this.ttpContasPagar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpContasPagar.ToolTipTitle = "Dica:";
            // 
            // lblDados
            // 
            this.lblDados.AutoSize = true;
            this.lblDados.Location = new System.Drawing.Point(86, 40);
            this.lblDados.Name = "lblDados";
            this.lblDados.Size = new System.Drawing.Size(182, 13);
            this.lblDados.TabIndex = 32;
            this.lblDados.Text = "Os dados foram salvos com sucesso.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 39);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(226, 74);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 31;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.lblValorTroco);
            this.panel1.Controls.Add(this.lblTroco);
            this.panel1.Location = new System.Drawing.Point(-1, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 145);
            this.panel1.TabIndex = 33;
            // 
            // lblValorTroco
            // 
            this.lblValorTroco.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblValorTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTroco.ForeColor = System.Drawing.Color.Blue;
            this.lblValorTroco.Location = new System.Drawing.Point(0, 26);
            this.lblValorTroco.Name = "lblValorTroco";
            this.lblValorTroco.Size = new System.Drawing.Size(314, 41);
            this.lblValorTroco.TabIndex = 0;
            this.lblValorTroco.Text = "0,00";
            this.lblValorTroco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTroco
            // 
            this.lblTroco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTroco.Location = new System.Drawing.Point(0, 1);
            this.lblTroco.Name = "lblTroco";
            this.lblTroco.Size = new System.Drawing.Size(314, 20);
            this.lblTroco.TabIndex = 1;
            this.lblTroco.Text = "Troco:";
            this.lblTroco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmTroco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(308, 195);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDados);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTroco";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informação";
            this.Load += new System.EventHandler(this.FrmTroco_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmTroco_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip ttpContasPagar;
        private System.Windows.Forms.Label lblDados;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblValorTroco;
        private System.Windows.Forms.Label lblTroco;
    }
}