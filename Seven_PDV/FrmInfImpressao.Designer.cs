namespace Seven_Sistema
{
    partial class FrmInfImpressao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInfImpressao));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.chkbMostrarLogo = new System.Windows.Forms.CheckBox();
            this.lblAsterisco2 = new System.Windows.Forms.Label();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.lblAsterisco = new System.Windows.Forms.Label();
            this.lblTipoImp = new System.Windows.Forms.Label();
            this.cbbTipoImpressao = new System.Windows.Forms.ComboBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblNumCopia = new System.Windows.Forms.Label();
            this.txtNCopia = new System.Windows.Forms.TextBox();
            this.lblImp = new System.Windows.Forms.Label();
            this.cbbImpressoras = new System.Windows.Forms.ComboBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.pcibInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.ttpInfImp = new System.Windows.Forms.ToolTip(this.components);
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao2)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.chkbMostrarLogo);
            this.grbBox1.Controls.Add(this.lblAsterisco2);
            this.grbBox1.Controls.Add(this.lblAsterisco1);
            this.grbBox1.Controls.Add(this.lblAsterisco);
            this.grbBox1.Controls.Add(this.lblTipoImp);
            this.grbBox1.Controls.Add(this.cbbTipoImpressao);
            this.grbBox1.Controls.Add(this.btnImprimir);
            this.grbBox1.Controls.Add(this.lblNumCopia);
            this.grbBox1.Controls.Add(this.txtNCopia);
            this.grbBox1.Controls.Add(this.lblImp);
            this.grbBox1.Controls.Add(this.cbbImpressoras);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(515, 93);
            this.grbBox1.TabIndex = 0;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Ações:";
            // 
            // chkbMostrarLogo
            // 
            this.chkbMostrarLogo.AutoSize = true;
            this.chkbMostrarLogo.Location = new System.Drawing.Point(6, 59);
            this.chkbMostrarLogo.Name = "chkbMostrarLogo";
            this.chkbMostrarLogo.Size = new System.Drawing.Size(181, 17);
            this.chkbMostrarLogo.TabIndex = 4;
            this.chkbMostrarLogo.Text = "Mostrar logo-marca na impressão";
            this.chkbMostrarLogo.UseVisualStyleBackColor = true;
            this.chkbMostrarLogo.MouseLeave += new System.EventHandler(this.chkbMostrarLogo_MouseLeave);
            this.chkbMostrarLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbMostrarLogo_MouseMove);
            // 
            // lblAsterisco2
            // 
            this.lblAsterisco2.AutoSize = true;
            this.lblAsterisco2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco2.Location = new System.Drawing.Point(497, 14);
            this.lblAsterisco2.Name = "lblAsterisco2";
            this.lblAsterisco2.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco2.TabIndex = 0;
            this.lblAsterisco2.Text = "*";
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(273, 14);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // lblAsterisco
            // 
            this.lblAsterisco.AutoSize = true;
            this.lblAsterisco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco.Location = new System.Drawing.Point(94, 14);
            this.lblAsterisco.Name = "lblAsterisco";
            this.lblAsterisco.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco.TabIndex = 0;
            this.lblAsterisco.Text = "*";
            // 
            // lblTipoImp
            // 
            this.lblTipoImp.AutoSize = true;
            this.lblTipoImp.Location = new System.Drawing.Point(3, 16);
            this.lblTipoImp.Name = "lblTipoImp";
            this.lblTipoImp.Size = new System.Drawing.Size(96, 13);
            this.lblTipoImp.TabIndex = 0;
            this.lblTipoImp.Text = "Tipo de impressão:";
            // 
            // cbbTipoImpressao
            // 
            this.cbbTipoImpressao.BackColor = System.Drawing.Color.LightBlue;
            this.cbbTipoImpressao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoImpressao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTipoImpressao.FormattingEnabled = true;
            this.cbbTipoImpressao.Items.AddRange(new object[] {
            "A4",
            "Impressora Térmica (58mm)",
            "Impressora Térmica (80mm)",
            "Impressora Matricial",
            "PDF (A4)",
            "PDF Impressora Térmica (58mm)",
            "PDF Impressora Térmica (80mm)"});
            this.cbbTipoImpressao.Location = new System.Drawing.Point(6, 32);
            this.cbbTipoImpressao.Name = "cbbTipoImpressao";
            this.cbbTipoImpressao.Size = new System.Drawing.Size(207, 21);
            this.cbbTipoImpressao.TabIndex = 1;
            this.cbbTipoImpressao.DropDown += new System.EventHandler(this.cbbTipoImpressao_DropDown);
            this.cbbTipoImpressao.SelectedIndexChanged += new System.EventHandler(this.cbbTipoImpressao_SelectedIndexChanged);
            this.cbbTipoImpressao.DropDownClosed += new System.EventHandler(this.cbbTipoImpressao_DropDownClosed);
            this.cbbTipoImpressao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbTipoImpressao_KeyPress);
            this.cbbTipoImpressao.MouseLeave += new System.EventHandler(this.cbbTipoImpressao_MouseLeave);
            this.cbbTipoImpressao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbTipoImpressao_MouseMove);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnImprimir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnImprimir.Location = new System.Drawing.Point(417, 59);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(91, 32);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "&Gerar PDF";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInfImp.SetToolTip(this.btnImprimir, "Imprimir documento.");
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            this.btnImprimir.MouseLeave += new System.EventHandler(this.btnImprimir_MouseLeave);
            this.btnImprimir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnImprimir_MouseMove);
            // 
            // lblNumCopia
            // 
            this.lblNumCopia.AutoSize = true;
            this.lblNumCopia.Location = new System.Drawing.Point(431, 16);
            this.lblNumCopia.Name = "lblNumCopia";
            this.lblNumCopia.Size = new System.Drawing.Size(71, 13);
            this.lblNumCopia.TabIndex = 0;
            this.lblNumCopia.Text = "Nº de cópias:";
            // 
            // txtNCopia
            // 
            this.txtNCopia.BackColor = System.Drawing.Color.White;
            this.txtNCopia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNCopia.Location = new System.Drawing.Point(431, 33);
            this.txtNCopia.MaxLength = 5;
            this.txtNCopia.Name = "txtNCopia";
            this.txtNCopia.Size = new System.Drawing.Size(77, 20);
            this.txtNCopia.TabIndex = 3;
            this.txtNCopia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNCopia.Enter += new System.EventHandler(this.txtNCopia_Enter);
            this.txtNCopia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNCopia_KeyPress);
            this.txtNCopia.Leave += new System.EventHandler(this.txtNCopia_Leave);
            // 
            // lblImp
            // 
            this.lblImp.AutoSize = true;
            this.lblImp.Location = new System.Drawing.Point(216, 16);
            this.lblImp.Name = "lblImp";
            this.lblImp.Size = new System.Drawing.Size(62, 13);
            this.lblImp.TabIndex = 0;
            this.lblImp.Text = "Imprimir em:";
            // 
            // cbbImpressoras
            // 
            this.cbbImpressoras.BackColor = System.Drawing.Color.LightBlue;
            this.cbbImpressoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbImpressoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbImpressoras.FormattingEnabled = true;
            this.cbbImpressoras.Location = new System.Drawing.Point(219, 32);
            this.cbbImpressoras.Name = "cbbImpressoras";
            this.cbbImpressoras.Size = new System.Drawing.Size(206, 21);
            this.cbbImpressoras.TabIndex = 2;
            this.cbbImpressoras.DropDown += new System.EventHandler(this.cbbImpressoras_DropDown);
            this.cbbImpressoras.DropDownClosed += new System.EventHandler(this.cbbImpressoras_DropDownClosed);
            this.cbbImpressoras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbImpressoras_KeyPress);
            this.cbbImpressoras.MouseLeave += new System.EventHandler(this.cbbImpressoras_MouseLeave);
            this.cbbImpressoras.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbImpressoras_MouseMove);
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(472, 111);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 6;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInfImp.SetToolTip(this.btnVoltar, "Voltar ao menu anterior.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // pcibInterrogacao2
            // 
            this.pcibInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao2.Image")));
            this.pcibInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pcibInterrogacao2.Location = new System.Drawing.Point(12, 111);
            this.pcibInterrogacao2.Name = "pcibInterrogacao2";
            this.pcibInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao2.TabIndex = 52;
            this.pcibInterrogacao2.TabStop = false;
            this.pcibInterrogacao2.Click += new System.EventHandler(this.pcibInterrogacao2_Click);
            this.pcibInterrogacao2.MouseLeave += new System.EventHandler(this.pcibInterrogacao2_MouseLeave);
            this.pcibInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao2_MouseMove);
            // 
            // ttpInfImp
            // 
            this.ttpInfImp.AutoPopDelay = 5000;
            this.ttpInfImp.InitialDelay = 1000;
            this.ttpInfImp.IsBalloon = true;
            this.ttpInfImp.ReshowDelay = 100;
            this.ttpInfImp.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpInfImp.ToolTipTitle = "Dica:";
            // 
            // FrmInfImpressao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(537, 148);
            this.ControlBox = false;
            this.Controls.Add(this.pcibInterrogacao2);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInfImpressao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informações de Impressão";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInfImpressao_FormClosing);
            this.Load += new System.EventHandler(this.FrmInfImpressao_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmInfImpressao_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblImp;
        private System.Windows.Forms.ComboBox cbbImpressoras;
        private System.Windows.Forms.Label lblNumCopia;
        private System.Windows.Forms.TextBox txtNCopia;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblTipoImp;
        private System.Windows.Forms.ComboBox cbbTipoImpressao;
        private System.Windows.Forms.Label lblAsterisco2;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.Label lblAsterisco;
        private System.Windows.Forms.CheckBox chkbMostrarLogo;
        private System.Windows.Forms.PictureBox pcibInterrogacao2;
        private System.Windows.Forms.ToolTip ttpInfImp;
    }
}