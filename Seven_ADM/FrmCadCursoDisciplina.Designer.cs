namespace SIE_7_Sistema
{
    partial class FrmCadCursoDisciplina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadCursoDisciplina));
            this.clbDisciplinas = new System.Windows.Forms.CheckedListBox();
            this.lblDisciplina = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblNaoExistemDisciplina = new System.Windows.Forms.Label();
            this.ttpAdDisciplina = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // clbDisciplinas
            // 
            this.clbDisciplinas.BackColor = System.Drawing.Color.White;
            this.clbDisciplinas.CheckOnClick = true;
            this.clbDisciplinas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbDisciplinas.FormattingEnabled = true;
            this.clbDisciplinas.HorizontalScrollbar = true;
            this.clbDisciplinas.Items.AddRange(new object[] {
            ""});
            this.clbDisciplinas.Location = new System.Drawing.Point(12, 25);
            this.clbDisciplinas.Name = "clbDisciplinas";
            this.clbDisciplinas.Size = new System.Drawing.Size(364, 109);
            this.clbDisciplinas.TabIndex = 1;
            this.clbDisciplinas.MouseLeave += new System.EventHandler(this.clbDisciplinas_MouseLeave);
            this.clbDisciplinas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.clbDisciplinas_MouseMove);
            // 
            // lblDisciplina
            // 
            this.lblDisciplina.AutoSize = true;
            this.lblDisciplina.Location = new System.Drawing.Point(12, 9);
            this.lblDisciplina.Name = "lblDisciplina";
            this.lblDisciplina.Size = new System.Drawing.Size(60, 13);
            this.lblDisciplina.TabIndex = 0;
            this.lblDisciplina.Text = "Disciplinas:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar.Location = new System.Drawing.Point(301, 140);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 25);
            this.btnVoltar.TabIndex = 3;
            this.btnVoltar.Text = "     &Voltar";
            this.ttpAdDisciplina.SetToolTip(this.btnVoltar, "Voltar ao menu anterior.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(231, 140);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(64, 25);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&Salvar";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAdDisciplina.SetToolTip(this.btnOK, "Salvar dados informados.");
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.MouseLeave += new System.EventHandler(this.btnOK_MouseLeave);
            this.btnOK.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOK_MouseMove);
            // 
            // lblNaoExistemDisciplina
            // 
            this.lblNaoExistemDisciplina.AutoSize = true;
            this.lblNaoExistemDisciplina.BackColor = System.Drawing.Color.Transparent;
            this.lblNaoExistemDisciplina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaoExistemDisciplina.Location = new System.Drawing.Point(34, 71);
            this.lblNaoExistemDisciplina.Name = "lblNaoExistemDisciplina";
            this.lblNaoExistemDisciplina.Size = new System.Drawing.Size(318, 16);
            this.lblNaoExistemDisciplina.TabIndex = 0;
            this.lblNaoExistemDisciplina.Text = "Não existem disciplinas cadastradas neste sistema.";
            this.lblNaoExistemDisciplina.Visible = false;
            // 
            // ttpAdDisciplina
            // 
            this.ttpAdDisciplina.AutoPopDelay = 5000;
            this.ttpAdDisciplina.InitialDelay = 1000;
            this.ttpAdDisciplina.IsBalloon = true;
            this.ttpAdDisciplina.ReshowDelay = 100;
            this.ttpAdDisciplina.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpAdDisciplina.ToolTipTitle = "Dica:";
            // 
            // FrmCadCursoDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(388, 177);
            this.ControlBox = false;
            this.Controls.Add(this.lblNaoExistemDisciplina);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblDisciplina);
            this.Controls.Add(this.clbDisciplinas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadCursoDisciplina";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Disciplinas";
            this.Load += new System.EventHandler(this.FrmCadCursoDisciplina_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadCursoDisciplina_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbDisciplinas;
        private System.Windows.Forms.Label lblDisciplina;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblNaoExistemDisciplina;
        private System.Windows.Forms.ToolTip ttpAdDisciplina;
    }
}