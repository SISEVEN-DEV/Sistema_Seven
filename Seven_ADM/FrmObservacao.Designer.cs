namespace SIE_7_Sistema
{
    partial class FrmObservacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObservacao));
            this.lblObservacao = new System.Windows.Forms.Label();
            this.rtxtObs = new System.Windows.Forms.RichTextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ttpContasPagar = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblObservacao
            // 
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Location = new System.Drawing.Point(12, 9);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(73, 13);
            this.lblObservacao.TabIndex = 47;
            this.lblObservacao.Text = "Observações:";
            // 
            // rtxtObs
            // 
            this.rtxtObs.BackColor = System.Drawing.Color.White;
            this.rtxtObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtObs.Location = new System.Drawing.Point(12, 25);
            this.rtxtObs.MaxLength = 200;
            this.rtxtObs.Name = "rtxtObs";
            this.rtxtObs.Size = new System.Drawing.Size(738, 32);
            this.rtxtObs.TabIndex = 48;
            this.rtxtObs.Text = "";
            this.rtxtObs.Enter += new System.EventHandler(this.rtxtObs_Enter);
            this.rtxtObs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtObs_KeyPress);
            this.rtxtObs.Leave += new System.EventHandler(this.rtxtObs_Leave);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.Location = new System.Drawing.Point(589, 63);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 53;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpContasPagar.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelar.Location = new System.Drawing.Point(665, 63);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 32);
            this.btnCancelar.TabIndex = 54;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpContasPagar.SetToolTip(this.btnCancelar, "Cancelar opção atual.");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            this.btnCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelar_MouseMove);
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
            // FrmObservacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(757, 99);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblObservacao);
            this.Controls.Add(this.rtxtObs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmObservacao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Observação";
            this.Load += new System.EventHandler(this.FrmObservacao_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmObservacao_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.RichTextBox rtxtObs;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip ttpContasPagar;
    }
}