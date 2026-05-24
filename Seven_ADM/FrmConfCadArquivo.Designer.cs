namespace SIE_7_Sistema
{
    partial class FrmConfCadArquivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfCadArquivo));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.chkbExcluirArquivo = new System.Windows.Forms.CheckBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.chkbpermitirSelVarArq = new System.Windows.Forms.CheckBox();
            this.grbBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.chkbpermitirSelVarArq);
            this.grbBox1.Controls.Add(this.btnSalvar);
            this.grbBox1.Controls.Add(this.btnAlterar);
            this.grbBox1.Controls.Add(this.chkbExcluirArquivo);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(330, 99);
            this.grbBox1.TabIndex = 3;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Configurações:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(254, 65);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 25);
            this.btnSalvar.TabIndex = 16;
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
            this.btnAlterar.Location = new System.Drawing.Point(178, 65);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(70, 25);
            this.btnAlterar.TabIndex = 15;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnAlterar.MouseLeave += new System.EventHandler(this.btnAlterar_MouseLeave);
            this.btnAlterar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterar_MouseMove);
            // 
            // chkbExcluirArquivo
            // 
            this.chkbExcluirArquivo.AutoSize = true;
            this.chkbExcluirArquivo.Location = new System.Drawing.Point(6, 19);
            this.chkbExcluirArquivo.Name = "chkbExcluirArquivo";
            this.chkbExcluirArquivo.Size = new System.Drawing.Size(150, 17);
            this.chkbExcluirArquivo.TabIndex = 17;
            this.chkbExcluirArquivo.Text = "Excluir arquivo do diretório";
            this.chkbExcluirArquivo.UseVisualStyleBackColor = true;
            this.chkbExcluirArquivo.MouseLeave += new System.EventHandler(this.chkbExcluirArquivo_MouseLeave);
            this.chkbExcluirArquivo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbExcluirArquivo_MouseMove);
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(272, 117);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(70, 32);
            this.btnVoltar.TabIndex = 19;
            this.btnVoltar.Text = "V&oltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // chkbpermitirSelVarArq
            // 
            this.chkbpermitirSelVarArq.AutoSize = true;
            this.chkbpermitirSelVarArq.Location = new System.Drawing.Point(6, 42);
            this.chkbpermitirSelVarArq.Name = "chkbpermitirSelVarArq";
            this.chkbpermitirSelVarArq.Size = new System.Drawing.Size(217, 17);
            this.chkbpermitirSelVarArq.TabIndex = 18;
            this.chkbpermitirSelVarArq.Text = "Permitir selecionar todo o tipo de arquivo";
            this.chkbpermitirSelVarArq.UseVisualStyleBackColor = true;
            this.chkbpermitirSelVarArq.MouseLeave += new System.EventHandler(this.chkbpermitirSelVarArq_MouseLeave);
            this.chkbpermitirSelVarArq.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbpermitirSelVarArq_MouseMove);
            // 
            // FrmConfCadArquivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(355, 161);
            this.ControlBox = false;
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfCadArquivo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações de Cadastro de Arquivos";
            this.Load += new System.EventHandler(this.FrmConfCadArquivo_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmConfCadArquivo_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.CheckBox chkbExcluirArquivo;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.CheckBox chkbpermitirSelVarArq;
    }
}