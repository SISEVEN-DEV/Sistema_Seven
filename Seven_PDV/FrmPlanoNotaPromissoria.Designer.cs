namespace Seven_Sistema
{
    partial class FrmPlanoNotaPromissoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlanoNotaPromissoria));
            this.ttpUser = new System.Windows.Forms.ToolTip(this.components);
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDescricaoForma1 = new System.Windows.Forms.Label();
            this.lblResultado1 = new System.Windows.Forms.Label();
            this.txtJurosAtrasoPorc = new System.Windows.Forms.TextBox();
            this.txtJurosPorc = new System.Windows.Forms.TextBox();
            this.lblJuros = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblValorPagar = new System.Windows.Forms.Label();
            this.lblPorcentagem3 = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblJurosAtraso = new System.Windows.Forms.Label();
            this.txtParcela = new System.Windows.Forms.TextBox();
            this.lblParcela = new System.Windows.Forms.Label();
            this.lblPorcentagem1 = new System.Windows.Forms.Label();
            this.txtEntradaPorc = new System.Windows.Forms.TextBox();
            this.lblEntrada = new System.Windows.Forms.Label();
            this.lblPorcentagem2 = new System.Windows.Forms.Label();
            this.lblTotalSub = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttpUser
            // 
            this.ttpUser.AutoPopDelay = 5000;
            this.ttpUser.InitialDelay = 1000;
            this.ttpUser.IsBalloon = true;
            this.ttpUser.ReshowDelay = 100;
            this.ttpUser.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpUser.ToolTipTitle = "Dica:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalvar.Location = new System.Drawing.Point(439, 304);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(72, 32);
            this.btnSalvar.TabIndex = 29;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUser.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(517, 304);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 30;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpUser.SetToolTip(this.btnSair, "Sair de Criar Forma de Pagamento de Nota Promissória.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.lblValorTotal);
            this.grbBox2.Controls.Add(this.label4);
            this.grbBox2.Controls.Add(this.label3);
            this.grbBox2.Controls.Add(this.label1);
            this.grbBox2.Controls.Add(this.picbInterrogacao1);
            this.grbBox2.Controls.Add(this.groupBox1);
            this.grbBox2.Controls.Add(this.txtJurosAtrasoPorc);
            this.grbBox2.Controls.Add(this.txtJurosPorc);
            this.grbBox2.Controls.Add(this.lblJuros);
            this.grbBox2.Controls.Add(this.label2);
            this.grbBox2.Controls.Add(this.lblValorPagar);
            this.grbBox2.Controls.Add(this.lblPorcentagem3);
            this.grbBox2.Controls.Add(this.lblJurosAtraso);
            this.grbBox2.Controls.Add(this.txtParcela);
            this.grbBox2.Controls.Add(this.lblParcela);
            this.grbBox2.Controls.Add(this.lblPorcentagem1);
            this.grbBox2.Controls.Add(this.txtEntradaPorc);
            this.grbBox2.Controls.Add(this.lblEntrada);
            this.grbBox2.Controls.Add(this.lblPorcentagem2);
            this.grbBox2.Location = new System.Drawing.Point(12, 58);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(560, 240);
            this.grbBox2.TabIndex = 12;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Cadastrar:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(498, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(323, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 98;
            this.label3.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(201, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 97;
            this.label1.Text = "*";
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(6, 214);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 96;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDescricaoForma1);
            this.groupBox1.Controls.Add(this.lblResultado1);
            this.groupBox1.Location = new System.Drawing.Point(9, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 73);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // lblDescricaoForma1
            // 
            this.lblDescricaoForma1.AutoSize = true;
            this.lblDescricaoForma1.Location = new System.Drawing.Point(245, 0);
            this.lblDescricaoForma1.Name = "lblDescricaoForma1";
            this.lblDescricaoForma1.Size = new System.Drawing.Size(49, 13);
            this.lblDescricaoForma1.TabIndex = 27;
            this.lblDescricaoForma1.Text = "Resumo:";
            // 
            // lblResultado1
            // 
            this.lblResultado1.BackColor = System.Drawing.Color.Transparent;
            this.lblResultado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado1.ForeColor = System.Drawing.Color.Black;
            this.lblResultado1.Location = new System.Drawing.Point(6, 16);
            this.lblResultado1.Name = "lblResultado1";
            this.lblResultado1.Size = new System.Drawing.Size(538, 46);
            this.lblResultado1.TabIndex = 26;
            this.lblResultado1.Text = "1 x 35,00";
            this.lblResultado1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResultado1.Click += new System.EventHandler(this.lblResultado1_Click);
            this.lblResultado1.MouseLeave += new System.EventHandler(this.lblResultado1_MouseLeave);
            this.lblResultado1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblResultado1_MouseMove);
            // 
            // txtJurosAtrasoPorc
            // 
            this.txtJurosAtrasoPorc.BackColor = System.Drawing.Color.White;
            this.txtJurosAtrasoPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJurosAtrasoPorc.Location = new System.Drawing.Point(444, 32);
            this.txtJurosAtrasoPorc.MaxLength = 7;
            this.txtJurosAtrasoPorc.Name = "txtJurosAtrasoPorc";
            this.txtJurosAtrasoPorc.Size = new System.Drawing.Size(90, 20);
            this.txtJurosAtrasoPorc.TabIndex = 24;
            this.txtJurosAtrasoPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtJurosAtrasoPorc.Enter += new System.EventHandler(this.txtJurosAtrasoPorc_Enter);
            this.txtJurosAtrasoPorc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJurosAtrasoPorc_KeyPress);
            this.txtJurosAtrasoPorc.Leave += new System.EventHandler(this.txtJurosAtrasoPorc_Leave);
            // 
            // txtJurosPorc
            // 
            this.txtJurosPorc.BackColor = System.Drawing.Color.White;
            this.txtJurosPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJurosPorc.Location = new System.Drawing.Point(296, 32);
            this.txtJurosPorc.MaxLength = 7;
            this.txtJurosPorc.Name = "txtJurosPorc";
            this.txtJurosPorc.Size = new System.Drawing.Size(90, 20);
            this.txtJurosPorc.TabIndex = 23;
            this.txtJurosPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtJurosPorc.Enter += new System.EventHandler(this.txtJurosPorc_Enter);
            this.txtJurosPorc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJurosPorc_KeyPress);
            this.txtJurosPorc.Leave += new System.EventHandler(this.txtJurosPorc_Leave);
            // 
            // lblJuros
            // 
            this.lblJuros.AutoSize = true;
            this.lblJuros.Location = new System.Drawing.Point(292, 14);
            this.lblJuros.Name = "lblJuros";
            this.lblJuros.Size = new System.Drawing.Size(36, 13);
            this.lblJuros.TabIndex = 0;
            this.lblJuros.Text = "Multa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(58, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "*";
            // 
            // lblValorPagar
            // 
            this.lblValorPagar.BackColor = System.Drawing.Color.Transparent;
            this.lblValorPagar.Font = new System.Drawing.Font("Calibri", 60F, System.Drawing.FontStyle.Bold);
            this.lblValorPagar.ForeColor = System.Drawing.Color.Red;
            this.lblValorPagar.Location = new System.Drawing.Point(32, 145);
            this.lblValorPagar.Name = "lblValorPagar";
            this.lblValorPagar.Size = new System.Drawing.Size(522, 92);
            this.lblValorPagar.TabIndex = 27;
            this.lblValorPagar.Text = "0,00";
            this.lblValorPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorPagar.Click += new System.EventHandler(this.lblValorPagar_Click);
            this.lblValorPagar.MouseLeave += new System.EventHandler(this.lblValorPagar_MouseLeave);
            this.lblValorPagar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorPagar_MouseMove);
            // 
            // lblPorcentagem3
            // 
            this.lblPorcentagem3.AutoSize = true;
            this.lblPorcentagem3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentagem3.Location = new System.Drawing.Point(534, 33);
            this.lblPorcentagem3.Name = "lblPorcentagem3";
            this.lblPorcentagem3.Size = new System.Drawing.Size(19, 16);
            this.lblPorcentagem3.TabIndex = 0;
            this.lblPorcentagem3.Text = "%";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.Location = new System.Drawing.Point(369, 134);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(185, 20);
            this.lblValorTotal.TabIndex = 28;
            this.lblValorTotal.Text = "Entrada a Pagar (R$):";
            // 
            // lblJurosAtraso
            // 
            this.lblJurosAtraso.AutoSize = true;
            this.lblJurosAtraso.Location = new System.Drawing.Point(441, 15);
            this.lblJurosAtraso.Name = "lblJurosAtraso";
            this.lblJurosAtraso.Size = new System.Drawing.Size(62, 13);
            this.lblJurosAtraso.TabIndex = 0;
            this.lblJurosAtraso.Text = "Juros Mora:";
            // 
            // txtParcela
            // 
            this.txtParcela.BackColor = System.Drawing.Color.White;
            this.txtParcela.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParcela.Location = new System.Drawing.Point(9, 32);
            this.txtParcela.MaxLength = 3;
            this.txtParcela.Name = "txtParcela";
            this.txtParcela.Size = new System.Drawing.Size(90, 20);
            this.txtParcela.TabIndex = 18;
            this.txtParcela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtParcela.Enter += new System.EventHandler(this.txtParcela_Enter);
            this.txtParcela.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtParcela_KeyPress);
            this.txtParcela.Leave += new System.EventHandler(this.txtParcela_Leave);
            // 
            // lblParcela
            // 
            this.lblParcela.AutoSize = true;
            this.lblParcela.Location = new System.Drawing.Point(6, 16);
            this.lblParcela.Name = "lblParcela";
            this.lblParcela.Size = new System.Drawing.Size(57, 13);
            this.lblParcela.TabIndex = 0;
            this.lblParcela.Text = "Parcela(s):";
            // 
            // lblPorcentagem1
            // 
            this.lblPorcentagem1.AutoSize = true;
            this.lblPorcentagem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentagem1.Location = new System.Drawing.Point(252, 33);
            this.lblPorcentagem1.Name = "lblPorcentagem1";
            this.lblPorcentagem1.Size = new System.Drawing.Size(19, 16);
            this.lblPorcentagem1.TabIndex = 0;
            this.lblPorcentagem1.Text = "%";
            // 
            // txtEntradaPorc
            // 
            this.txtEntradaPorc.BackColor = System.Drawing.Color.White;
            this.txtEntradaPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntradaPorc.Location = new System.Drawing.Point(162, 32);
            this.txtEntradaPorc.MaxLength = 7;
            this.txtEntradaPorc.Name = "txtEntradaPorc";
            this.txtEntradaPorc.Size = new System.Drawing.Size(90, 20);
            this.txtEntradaPorc.TabIndex = 19;
            this.txtEntradaPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEntradaPorc.Enter += new System.EventHandler(this.txtEntradaPorc_Enter);
            this.txtEntradaPorc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEntradaPorc_KeyPress);
            this.txtEntradaPorc.Leave += new System.EventHandler(this.txtEntradaPorc_Leave);
            // 
            // lblEntrada
            // 
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Location = new System.Drawing.Point(159, 16);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(47, 13);
            this.lblEntrada.TabIndex = 0;
            this.lblEntrada.Text = "Entrada:";
            // 
            // lblPorcentagem2
            // 
            this.lblPorcentagem2.AutoSize = true;
            this.lblPorcentagem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentagem2.Location = new System.Drawing.Point(386, 33);
            this.lblPorcentagem2.Name = "lblPorcentagem2";
            this.lblPorcentagem2.Size = new System.Drawing.Size(19, 16);
            this.lblPorcentagem2.TabIndex = 0;
            this.lblPorcentagem2.Text = "%";
            // 
            // lblTotalSub
            // 
            this.lblTotalSub.BackColor = System.Drawing.Color.White;
            this.lblTotalSub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSub.Location = new System.Drawing.Point(12, 29);
            this.lblTotalSub.Name = "lblTotalSub";
            this.lblTotalSub.Size = new System.Drawing.Size(135, 26);
            this.lblTotalSub.TabIndex = 25;
            this.lblTotalSub.Text = "0,00";
            this.lblTotalSub.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalSub.Click += new System.EventHandler(this.lblTotalSub_Click);
            this.lblTotalSub.MouseLeave += new System.EventHandler(this.lblTotalSub_MouseLeave);
            this.lblTotalSub.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTotalSub_MouseMove);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(8, 7);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(94, 20);
            this.lblTotal.TabIndex = 26;
            this.lblTotal.Text = "Total (R$):";
            // 
            // FrmPlanoNotaPromissoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(584, 338);
            this.ControlBox = false;
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.lblTotalSub);
            this.Controls.Add(this.grbBox2);
            this.Controls.Add(this.lblTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPlanoNotaPromissoria";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criar Forma de Pagamento rápida de Nota Promissória";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPlanoNotaPromissoria_FormClosing);
            this.Load += new System.EventHandler(this.FrmPesqUsuario_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPlanoNotaPromissoria_KeyUp);
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip ttpUser;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.TextBox txtJurosAtrasoPorc;
        private System.Windows.Forms.TextBox txtJurosPorc;
        private System.Windows.Forms.Label lblJuros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPorcentagem3;
        private System.Windows.Forms.Label lblJurosAtraso;
        private System.Windows.Forms.TextBox txtParcela;
        private System.Windows.Forms.Label lblParcela;
        private System.Windows.Forms.Label lblPorcentagem1;
        private System.Windows.Forms.TextBox txtEntradaPorc;
        private System.Windows.Forms.Label lblEntrada;
        private System.Windows.Forms.Label lblPorcentagem2;
        private System.Windows.Forms.Label lblTotalSub;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblValorPagar;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblResultado1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblDescricaoForma1;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}