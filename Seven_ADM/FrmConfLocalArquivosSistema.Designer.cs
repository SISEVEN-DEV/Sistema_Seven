namespace Seven_Sistema
{
    partial class FrmConfLocalArquivosSistema
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfLocalArquivosSistema));
            this.ttpNivel = new System.Windows.Forms.ToolTip(this.components);
            this.lblComprovanteContaPagar = new System.Windows.Forms.Label();
            this.txtComprovanteContasaPagar = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.grbBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttpNivel
            // 
            this.ttpNivel.AutoPopDelay = 5000;
            this.ttpNivel.InitialDelay = 1000;
            this.ttpNivel.IsBalloon = true;
            this.ttpNivel.ReshowDelay = 100;
            this.ttpNivel.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpNivel.ToolTipTitle = "Dica:";
            // 
            // lblComprovanteContaPagar
            // 
            this.lblComprovanteContaPagar.AutoSize = true;
            this.lblComprovanteContaPagar.Location = new System.Drawing.Point(6, 22);
            this.lblComprovanteContaPagar.Name = "lblComprovanteContaPagar";
            this.lblComprovanteContaPagar.Size = new System.Drawing.Size(219, 13);
            this.lblComprovanteContaPagar.TabIndex = 0;
            this.lblComprovanteContaPagar.Text = "Salvar Comprovantes de Contas a Pagar em:";
            // 
            // txtComprovanteContasaPagar
            // 
            this.txtComprovanteContasaPagar.BackColor = System.Drawing.Color.White;
            this.txtComprovanteContasaPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComprovanteContasaPagar.Location = new System.Drawing.Point(275, 19);
            this.txtComprovanteContasaPagar.Name = "txtComprovanteContasaPagar";
            this.txtComprovanteContasaPagar.Size = new System.Drawing.Size(235, 20);
            this.txtComprovanteContasaPagar.TabIndex = 1;
            this.txtComprovanteContasaPagar.Enter += new System.EventHandler(this.txtComprovanteContasaPagar_Enter);
            this.txtComprovanteContasaPagar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComprovanteContasaPagar_KeyPress);
            this.txtComprovanteContasaPagar.Leave += new System.EventHandler(this.txtComprovanteContasaPagar_Leave);
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(459, 172);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(70, 32);
            this.btnVoltar.TabIndex = 28;
            this.btnVoltar.Text = "V&oltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(440, 123);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 25);
            this.btnSalvar.TabIndex = 27;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterar.Location = new System.Drawing.Point(364, 123);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 25);
            this.btnAlterar.TabIndex = 26;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnAlterar.MouseLeave += new System.EventHandler(this.btnAlterar_MouseLeave);
            this.btnAlterar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterar_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.txtComprovanteContasaPagar);
            this.grbBox1.Controls.Add(this.lblComprovanteContaPagar);
            this.grbBox1.Controls.Add(this.btnSalvar);
            this.grbBox1.Controls.Add(this.btnAlterar);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(517, 154);
            this.grbBox1.TabIndex = 29;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Configurações:";
            // 
            // FrmConfLocalArquivosSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(743, 424);
            this.ControlBox = false;
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.btnVoltar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfLocalArquivosSistema";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações de Locais de Arquivos do Sistema";
            this.Load += new System.EventHandler(this.FrmCadNivel_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmConfLocalArquivosSistema_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip ttpNivel;
        private System.Windows.Forms.Label lblComprovanteContaPagar;
        private System.Windows.Forms.TextBox txtComprovanteContasaPagar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.GroupBox grbBox1;
    }
}