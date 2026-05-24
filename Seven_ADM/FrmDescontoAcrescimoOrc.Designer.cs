namespace Seven_Sistema
{
    partial class FrmDescontoAcrescimoOrc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDescontoAcrescimoOrc));
            this.txtValorAcrescimo = new System.Windows.Forms.TextBox();
            this.txtValorDesconto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAcrescimoPorc = new System.Windows.Forms.TextBox();
            this.lblAcrescimo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescontoPorc = new System.Windows.Forms.TextBox();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.lblTotalSub = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblValorTotalDescAcresc = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.ttpAdicionar = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtValorAcrescimo
            // 
            this.txtValorAcrescimo.BackColor = System.Drawing.Color.White;
            this.txtValorAcrescimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorAcrescimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorAcrescimo.Location = new System.Drawing.Point(409, 39);
            this.txtValorAcrescimo.MaxLength = 9;
            this.txtValorAcrescimo.Name = "txtValorAcrescimo";
            this.txtValorAcrescimo.Size = new System.Drawing.Size(126, 26);
            this.txtValorAcrescimo.TabIndex = 4;
            this.txtValorAcrescimo.Text = "0,00";
            this.txtValorAcrescimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorAcrescimo.Enter += new System.EventHandler(this.txtValorAcrescimo_Enter);
            this.txtValorAcrescimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorAcrescimo_KeyPress);
            this.txtValorAcrescimo.Leave += new System.EventHandler(this.txtValorAcrescimo_Leave);
            // 
            // txtValorDesconto
            // 
            this.txtValorDesconto.BackColor = System.Drawing.Color.White;
            this.txtValorDesconto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorDesconto.Location = new System.Drawing.Point(140, 39);
            this.txtValorDesconto.MaxLength = 9;
            this.txtValorDesconto.Name = "txtValorDesconto";
            this.txtValorDesconto.Size = new System.Drawing.Size(121, 26);
            this.txtValorDesconto.TabIndex = 2;
            this.txtValorDesconto.Text = "0,00";
            this.txtValorDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorDesconto.Enter += new System.EventHandler(this.txtValorDesconto_Enter);
            this.txtValorDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorDesconto_KeyPress);
            this.txtValorDesconto.Leave += new System.EventHandler(this.txtValorDesconto_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(405, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Acréscimos (R$):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(136, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Descontos (R$):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(381, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "%";
            // 
            // txtAcrescimoPorc
            // 
            this.txtAcrescimoPorc.BackColor = System.Drawing.Color.White;
            this.txtAcrescimoPorc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcrescimoPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcrescimoPorc.Location = new System.Drawing.Point(282, 39);
            this.txtAcrescimoPorc.MaxLength = 6;
            this.txtAcrescimoPorc.Name = "txtAcrescimoPorc";
            this.txtAcrescimoPorc.Size = new System.Drawing.Size(100, 26);
            this.txtAcrescimoPorc.TabIndex = 3;
            this.txtAcrescimoPorc.Text = "0,00";
            this.txtAcrescimoPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAcrescimoPorc.Enter += new System.EventHandler(this.txtAcrescimoPorc_Enter);
            this.txtAcrescimoPorc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcrescimoPorc_KeyPress);
            this.txtAcrescimoPorc.Leave += new System.EventHandler(this.txtAcrescimoPorc_Leave);
            // 
            // lblAcrescimo
            // 
            this.lblAcrescimo.AutoSize = true;
            this.lblAcrescimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcrescimo.Location = new System.Drawing.Point(278, 16);
            this.lblAcrescimo.Name = "lblAcrescimo";
            this.lblAcrescimo.Size = new System.Drawing.Size(95, 20);
            this.lblAcrescimo.TabIndex = 0;
            this.lblAcrescimo.Text = "Acréscimos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "%";
            // 
            // txtDescontoPorc
            // 
            this.txtDescontoPorc.BackColor = System.Drawing.Color.White;
            this.txtDescontoPorc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescontoPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescontoPorc.Location = new System.Drawing.Point(10, 39);
            this.txtDescontoPorc.MaxLength = 6;
            this.txtDescontoPorc.Name = "txtDescontoPorc";
            this.txtDescontoPorc.Size = new System.Drawing.Size(100, 26);
            this.txtDescontoPorc.TabIndex = 1;
            this.txtDescontoPorc.Text = "0,00";
            this.txtDescontoPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescontoPorc.Enter += new System.EventHandler(this.txtDescontoPorc_Enter);
            this.txtDescontoPorc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescontoPorc_KeyPress);
            this.txtDescontoPorc.Leave += new System.EventHandler(this.txtDescontoPorc_Leave);
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesconto.Location = new System.Drawing.Point(6, 16);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(90, 20);
            this.lblDesconto.TabIndex = 0;
            this.lblDesconto.Text = "Descontos:";
            // 
            // lblTotalSub
            // 
            this.lblTotalSub.BackColor = System.Drawing.Color.White;
            this.lblTotalSub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSub.Location = new System.Drawing.Point(6, 91);
            this.lblTotalSub.Name = "lblTotalSub";
            this.lblTotalSub.Size = new System.Drawing.Size(132, 26);
            this.lblTotalSub.TabIndex = 0;
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
            this.lblTotal.Location = new System.Drawing.Point(6, 68);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(94, 20);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total (R$):";
            // 
            // lblValorTotalDescAcresc
            // 
            this.lblValorTotalDescAcresc.BackColor = System.Drawing.Color.White;
            this.lblValorTotalDescAcresc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValorTotalDescAcresc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalDescAcresc.Location = new System.Drawing.Point(403, 91);
            this.lblValorTotalDescAcresc.Name = "lblValorTotalDescAcresc";
            this.lblValorTotalDescAcresc.Size = new System.Drawing.Size(132, 26);
            this.lblValorTotalDescAcresc.TabIndex = 0;
            this.lblValorTotalDescAcresc.Text = "0,00";
            this.lblValorTotalDescAcresc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotalDescAcresc.Click += new System.EventHandler(this.lblValorTotalDescAcresc_Click);
            this.lblValorTotalDescAcresc.MouseLeave += new System.EventHandler(this.lblValorTotalDescAcresc_MouseLeave);
            this.lblValorTotalDescAcresc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotalDescAcresc_MouseMove);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.Location = new System.Drawing.Point(378, 68);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(161, 20);
            this.lblValorTotal.TabIndex = 0;
            this.lblValorTotal.Text = "Total a Pagar (R$):";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalvar.Location = new System.Drawing.Point(416, 140);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(80, 32);
            this.btnSalvar.TabIndex = 5;
            this.btnSalvar.Text = "&Finalizar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAdicionar.SetToolTip(this.btnSalvar, "Salvar dados informados e finalizar o Orçamento.");
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
            this.btnSair.Location = new System.Drawing.Point(502, 140);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAdicionar.SetToolTip(this.btnSair, "Sair de Adicionar Descontos e Acréscimos.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescontoPorc);
            this.groupBox1.Controls.Add(this.lblDesconto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblTotalSub);
            this.groupBox1.Controls.Add(this.lblAcrescimo);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.lblValorTotalDescAcresc);
            this.groupBox1.Controls.Add(this.txtAcrescimoPorc);
            this.groupBox1.Controls.Add(this.lblValorTotal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtValorAcrescimo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtValorDesconto);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 122);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Descontos e Acréscimos:";
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(12, 140);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 34;
            this.picbInterrogacao2.TabStop = false;
            this.picbInterrogacao2.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao2.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // ttpAdicionar
            // 
            this.ttpAdicionar.AutoPopDelay = 5000;
            this.ttpAdicionar.InitialDelay = 1000;
            this.ttpAdicionar.IsBalloon = true;
            this.ttpAdicionar.ReshowDelay = 100;
            this.ttpAdicionar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpAdicionar.ToolTipTitle = "Dica:";
            // 
            // FrmDescontoAcrescimoOrc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(568, 176);
            this.ControlBox = false;
            this.Controls.Add(this.picbInterrogacao2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnSair);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDescontoAcrescimoOrc";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar Descontos e Acréscimos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDescontoAcrescimoOrc_FormClosing);
            this.Load += new System.EventHandler(this.FrmDescontoAcrescimoOrc_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmDescontoAcrescimoOrc_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtValorAcrescimo;
        private System.Windows.Forms.TextBox txtValorDesconto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAcrescimoPorc;
        private System.Windows.Forms.Label lblAcrescimo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescontoPorc;
        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.Label lblTotalSub;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblValorTotalDescAcresc;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.ToolTip ttpAdicionar;
    }
}