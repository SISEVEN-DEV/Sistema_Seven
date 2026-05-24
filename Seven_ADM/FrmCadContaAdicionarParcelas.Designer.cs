namespace Seven_Sistema
{
    partial class FrmCadContaAdicionarParcelas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadContaAdicionarParcelas));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.txtNParcela = new System.Windows.Forms.TextBox();
            this.cbbPDias = new System.Windows.Forms.ComboBox();
            this.lblDias = new System.Windows.Forms.Label();
            this.lblMultiplicar = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.ttpMultiplicar = new System.Windows.Forms.ToolTip(this.components);
            this.pcibInterrogacao = new System.Windows.Forms.PictureBox();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.txtNParcela);
            this.grbBox1.Controls.Add(this.cbbPDias);
            this.grbBox1.Controls.Add(this.lblDias);
            this.grbBox1.Controls.Add(this.lblMultiplicar);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(186, 73);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Ações:";
            this.grbBox1.Enter += new System.EventHandler(this.grbBox1_Enter);
            // 
            // txtNParcela
            // 
            this.txtNParcela.BackColor = System.Drawing.Color.White;
            this.txtNParcela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNParcela.Location = new System.Drawing.Point(125, 13);
            this.txtNParcela.MaxLength = 5;
            this.txtNParcela.Name = "txtNParcela";
            this.txtNParcela.Size = new System.Drawing.Size(52, 20);
            this.txtNParcela.TabIndex = 3;
            this.txtNParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNParcela.Enter += new System.EventHandler(this.txtNParcela_Enter);
            this.txtNParcela.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNParcela_KeyPress);
            this.txtNParcela.Leave += new System.EventHandler(this.txtNParcela_Leave);
            // 
            // cbbPDias
            // 
            this.cbbPDias.BackColor = System.Drawing.Color.LightBlue;
            this.cbbPDias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPDias.FormattingEnabled = true;
            this.cbbPDias.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cbbPDias.Location = new System.Drawing.Point(125, 39);
            this.cbbPDias.Name = "cbbPDias";
            this.cbbPDias.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbbPDias.Size = new System.Drawing.Size(52, 21);
            this.cbbPDias.TabIndex = 5;
            this.cbbPDias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbPDias_KeyPress);
            this.cbbPDias.MouseLeave += new System.EventHandler(this.cbbPDias_MouseLeave);
            this.cbbPDias.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbPDias_MouseMove);
            // 
            // lblDias
            // 
            this.lblDias.AutoSize = true;
            this.lblDias.Location = new System.Drawing.Point(29, 42);
            this.lblDias.Name = "lblDias";
            this.lblDias.Size = new System.Drawing.Size(90, 13);
            this.lblDias.TabIndex = 4;
            this.lblDias.Text = "Intervalo de Dias:";
            // 
            // lblMultiplicar
            // 
            this.lblMultiplicar.AutoSize = true;
            this.lblMultiplicar.Location = new System.Drawing.Point(22, 16);
            this.lblMultiplicar.Name = "lblMultiplicar";
            this.lblMultiplicar.Size = new System.Drawing.Size(98, 13);
            this.lblMultiplicar.TabIndex = 2;
            this.lblMultiplicar.Text = "Adicionar Parcelas:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar.Location = new System.Drawing.Point(143, 91);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 7;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMultiplicar.SetToolTip(this.btnVoltar, "Voltar para o cadastro de contas.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(57, 91);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 25);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "&Adicionar";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpMultiplicar.SetToolTip(this.btnOK, "Multiplicar a conta selecionada.");
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.MouseLeave += new System.EventHandler(this.btnOK_MouseLeave);
            this.btnOK.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOK_MouseMove);
            // 
            // ttpMultiplicar
            // 
            this.ttpMultiplicar.AutoPopDelay = 5000;
            this.ttpMultiplicar.InitialDelay = 1000;
            this.ttpMultiplicar.IsBalloon = true;
            this.ttpMultiplicar.ReshowDelay = 100;
            this.ttpMultiplicar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpMultiplicar.ToolTipTitle = "Dica:";
            // 
            // pcibInterrogacao
            // 
            this.pcibInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao.Image")));
            this.pcibInterrogacao.Location = new System.Drawing.Point(31, 91);
            this.pcibInterrogacao.Name = "pcibInterrogacao";
            this.pcibInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao.TabIndex = 78;
            this.pcibInterrogacao.TabStop = false;
            this.pcibInterrogacao.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pcibInterrogacao.MouseLeave += new System.EventHandler(this.pcibInterrogacao_MouseLeave);
            this.pcibInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao_MouseMove);
            // 
            // FrmCadContaAdicionarParcelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(213, 128);
            this.ControlBox = false;
            this.Controls.Add(this.pcibInterrogacao);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadContaAdicionarParcelas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Parcelas";
            this.ttpMultiplicar.SetToolTip(this, "Sair de Adicionar Parcelas.");
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMultiplicar_FormClosing);
            this.Load += new System.EventHandler(this.FrmMultiplicar_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmMultiplicar_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.ComboBox cbbPDias;
        private System.Windows.Forms.Label lblDias;
        private System.Windows.Forms.Label lblMultiplicar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ToolTip ttpMultiplicar;
        private System.Windows.Forms.TextBox txtNParcela;
        private System.Windows.Forms.PictureBox pcibInterrogacao;
    }
}