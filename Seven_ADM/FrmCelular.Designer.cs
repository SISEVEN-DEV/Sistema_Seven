namespace Seven_Sistema
{
    partial class FrmCelular
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCelular));
            this.mtxtCelular = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnProcurarCliente = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnEnviarZap = new System.Windows.Forms.Button();
            this.ttpCelular = new System.Windows.Forms.ToolTip(this.components);
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.SuspendLayout();
            // 
            // mtxtCelular
            // 
            this.mtxtCelular.BackColor = System.Drawing.Color.White;
            this.mtxtCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.mtxtCelular.Location = new System.Drawing.Point(6, 32);
            this.mtxtCelular.Mask = "(00) 00000-0000";
            this.mtxtCelular.Name = "mtxtCelular";
            this.mtxtCelular.Size = new System.Drawing.Size(102, 20);
            this.mtxtCelular.TabIndex = 4;
            this.mtxtCelular.Enter += new System.EventHandler(this.mtxtCelular_Enter);
            this.mtxtCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtCelular_KeyPress);
            this.mtxtCelular.Leave += new System.EventHandler(this.mtxtCelular_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Celular:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnProcurarCliente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.mtxtCelular);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 60);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // btnProcurarCliente
            // 
            this.btnProcurarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarCliente.Image")));
            this.btnProcurarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcurarCliente.Location = new System.Drawing.Point(114, 29);
            this.btnProcurarCliente.Name = "btnProcurarCliente";
            this.btnProcurarCliente.Size = new System.Drawing.Size(124, 25);
            this.btnProcurarCliente.TabIndex = 7;
            this.btnProcurarCliente.Text = "&Cliente/Consumidor";
            this.btnProcurarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCelular.SetToolTip(this.btnProcurarCliente, "Clique para pesquisar um Cliente/Consumidor.");
            this.btnProcurarCliente.UseVisualStyleBackColor = true;
            this.btnProcurarCliente.Click += new System.EventHandler(this.btnProcurarCliente_Click);
            this.btnProcurarCliente.MouseLeave += new System.EventHandler(this.btnProcurarCliente_MouseLeave);
            this.btnProcurarCliente.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarCliente_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(207, 78);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 12;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCelular.SetToolTip(this.btnSair, "Clique para sair de Adicionar Celular.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnEnviarZap
            // 
            this.btnEnviarZap.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviarZap.Image")));
            this.btnEnviarZap.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEnviarZap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEnviarZap.Location = new System.Drawing.Point(106, 78);
            this.btnEnviarZap.Name = "btnEnviarZap";
            this.btnEnviarZap.Size = new System.Drawing.Size(95, 32);
            this.btnEnviarZap.TabIndex = 28;
            this.btnEnviarZap.Text = "Enviar &ZAP";
            this.btnEnviarZap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCelular.SetToolTip(this.btnEnviarZap, "Clique para enviar um whatsapp.");
            this.btnEnviarZap.UseVisualStyleBackColor = true;
            this.btnEnviarZap.Click += new System.EventHandler(this.btnEnviarZap_Click);
            this.btnEnviarZap.MouseLeave += new System.EventHandler(this.btnEnviarZap_MouseLeave);
            this.btnEnviarZap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEnviarZap_MouseMove);
            // 
            // ttpCelular
            // 
            this.ttpCelular.AutoPopDelay = 5000;
            this.ttpCelular.InitialDelay = 1000;
            this.ttpCelular.IsBalloon = true;
            this.ttpCelular.ReshowDelay = 100;
            this.ttpCelular.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpCelular.ToolTipTitle = "Dica:";
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(12, 78);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 237;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // FrmCelular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(276, 116);
            this.ControlBox = false;
            this.Controls.Add(this.picbInterrogacao1);
            this.Controls.Add(this.btnEnviarZap);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCelular";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Celular";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCelular_FormClosing);
            this.Load += new System.EventHandler(this.FrmCelular_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCelular_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtxtCelular;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnProcurarCliente;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnEnviarZap;
        private System.Windows.Forms.ToolTip ttpCelular;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
    }
}