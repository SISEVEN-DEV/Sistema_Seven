namespace Seven_Sistema
{
    partial class FrmInvAjustarInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInvAjustarInventario));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblAsterisco2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSubGrupo1 = new System.Windows.Forms.Label();
            this.cbbpSubGrupo = new System.Windows.Forms.ComboBox();
            this.cbbpGrupo = new System.Windows.Forms.ComboBox();
            this.btnpProcurar = new System.Windows.Forms.Button();
            this.btnpProcurarSub1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtnSaldo = new System.Windows.Forms.RadioButton();
            this.rbtnQuantidade = new System.Windows.Forms.RadioButton();
            this.txtMultiplicador = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.ttpAjustar = new System.Windows.Forms.ToolTip(this.components);
            this.grbBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblAsterisco2);
            this.grbBox1.Controls.Add(this.label2);
            this.grbBox1.Controls.Add(this.lblSubGrupo1);
            this.grbBox1.Controls.Add(this.cbbpSubGrupo);
            this.grbBox1.Controls.Add(this.cbbpGrupo);
            this.grbBox1.Controls.Add(this.btnpProcurar);
            this.grbBox1.Controls.Add(this.btnpProcurarSub1);
            this.grbBox1.Controls.Add(this.label3);
            this.grbBox1.Controls.Add(this.rbtnSaldo);
            this.grbBox1.Controls.Add(this.rbtnQuantidade);
            this.grbBox1.Controls.Add(this.txtMultiplicador);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(576, 81);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Ajuste:";
            // 
            // lblAsterisco2
            // 
            this.lblAsterisco2.AutoSize = true;
            this.lblAsterisco2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco2.Location = new System.Drawing.Point(523, 22);
            this.lblAsterisco2.Name = "lblAsterisco2";
            this.lblAsterisco2.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco2.TabIndex = 9;
            this.lblAsterisco2.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(25, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Grupo:";
            // 
            // lblSubGrupo1
            // 
            this.lblSubGrupo1.AutoSize = true;
            this.lblSubGrupo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSubGrupo1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSubGrupo1.Location = new System.Drawing.Point(2, 53);
            this.lblSubGrupo1.Name = "lblSubGrupo1";
            this.lblSubGrupo1.Size = new System.Drawing.Size(69, 13);
            this.lblSubGrupo1.TabIndex = 0;
            this.lblSubGrupo1.Text = "Sub-grupo:";
            // 
            // cbbpSubGrupo
            // 
            this.cbbpSubGrupo.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpSubGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpSubGrupo.DropDownWidth = 550;
            this.cbbpSubGrupo.Enabled = false;
            this.cbbpSubGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpSubGrupo.FormattingEnabled = true;
            this.cbbpSubGrupo.Location = new System.Drawing.Point(77, 49);
            this.cbbpSubGrupo.Name = "cbbpSubGrupo";
            this.cbbpSubGrupo.Size = new System.Drawing.Size(243, 21);
            this.cbbpSubGrupo.TabIndex = 4;
            this.cbbpSubGrupo.DropDown += new System.EventHandler(this.cbbpSubGrupo_DropDown);
            this.cbbpSubGrupo.DropDownClosed += new System.EventHandler(this.cbbpSubGrupo_DropDownClosed);
            this.cbbpSubGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpSubGrupo_KeyPress);
            this.cbbpSubGrupo.MouseLeave += new System.EventHandler(this.cbbpSubGrupo_MouseLeave);
            this.cbbpSubGrupo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpSubGrupo_MouseMove);
            // 
            // cbbpGrupo
            // 
            this.cbbpGrupo.BackColor = System.Drawing.Color.LightBlue;
            this.cbbpGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbpGrupo.DropDownWidth = 550;
            this.cbbpGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbpGrupo.FormattingEnabled = true;
            this.cbbpGrupo.Location = new System.Drawing.Point(77, 19);
            this.cbbpGrupo.Name = "cbbpGrupo";
            this.cbbpGrupo.Size = new System.Drawing.Size(243, 21);
            this.cbbpGrupo.TabIndex = 2;
            this.cbbpGrupo.DropDown += new System.EventHandler(this.cbbpGrupo_DropDown);
            this.cbbpGrupo.SelectedIndexChanged += new System.EventHandler(this.cbbpGrupo_SelectedIndexChanged);
            this.cbbpGrupo.DropDownClosed += new System.EventHandler(this.cbbpGrupo_DropDownClosed);
            this.cbbpGrupo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbpGrupo_KeyPress);
            this.cbbpGrupo.MouseLeave += new System.EventHandler(this.cbbpGrupo_MouseLeave);
            this.cbbpGrupo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbpGrupo_MouseMove);
            // 
            // btnpProcurar
            // 
            this.btnpProcurar.Image = ((System.Drawing.Image)(resources.GetObject("btnpProcurar.Image")));
            this.btnpProcurar.Location = new System.Drawing.Point(326, 16);
            this.btnpProcurar.Name = "btnpProcurar";
            this.btnpProcurar.Size = new System.Drawing.Size(26, 25);
            this.btnpProcurar.TabIndex = 3;
            this.btnpProcurar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAjustar.SetToolTip(this.btnpProcurar, "Clique para pesquisar um grupo.");
            this.btnpProcurar.UseVisualStyleBackColor = true;
            this.btnpProcurar.Click += new System.EventHandler(this.btnpProcurar_Click);
            this.btnpProcurar.MouseLeave += new System.EventHandler(this.btnpProcurar_MouseLeave);
            this.btnpProcurar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnpProcurar_MouseMove);
            // 
            // btnpProcurarSub1
            // 
            this.btnpProcurarSub1.Enabled = false;
            this.btnpProcurarSub1.Image = ((System.Drawing.Image)(resources.GetObject("btnpProcurarSub1.Image")));
            this.btnpProcurarSub1.Location = new System.Drawing.Point(326, 47);
            this.btnpProcurarSub1.Name = "btnpProcurarSub1";
            this.btnpProcurarSub1.Size = new System.Drawing.Size(26, 25);
            this.btnpProcurarSub1.TabIndex = 5;
            this.btnpProcurarSub1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAjustar.SetToolTip(this.btnpProcurarSub1, "Clique para pesquisar um sub-grupo.");
            this.btnpProcurarSub1.UseVisualStyleBackColor = true;
            this.btnpProcurarSub1.Click += new System.EventHandler(this.btnpProcurarSub1_Click);
            this.btnpProcurarSub1.MouseLeave += new System.EventHandler(this.btnpProcurarSub1_MouseLeave);
            this.btnpProcurarSub1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnpProcurarSub1_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(474, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Adicionar:";
            // 
            // rbtnSaldo
            // 
            this.rbtnSaldo.AutoSize = true;
            this.rbtnSaldo.Location = new System.Drawing.Point(358, 51);
            this.rbtnSaldo.Name = "rbtnSaldo";
            this.rbtnSaldo.Size = new System.Drawing.Size(52, 17);
            this.rbtnSaldo.TabIndex = 7;
            this.rbtnSaldo.TabStop = true;
            this.rbtnSaldo.Text = "Saldo";
            this.rbtnSaldo.UseVisualStyleBackColor = true;
            this.rbtnSaldo.MouseLeave += new System.EventHandler(this.rbtnSaldo_MouseLeave);
            this.rbtnSaldo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnSaldo_MouseMove);
            // 
            // rbtnQuantidade
            // 
            this.rbtnQuantidade.AutoSize = true;
            this.rbtnQuantidade.Location = new System.Drawing.Point(358, 20);
            this.rbtnQuantidade.Name = "rbtnQuantidade";
            this.rbtnQuantidade.Size = new System.Drawing.Size(80, 17);
            this.rbtnQuantidade.TabIndex = 6;
            this.rbtnQuantidade.TabStop = true;
            this.rbtnQuantidade.Text = "Quantidade";
            this.rbtnQuantidade.UseVisualStyleBackColor = true;
            this.rbtnQuantidade.MouseLeave += new System.EventHandler(this.rbtnQuantidade_MouseLeave);
            this.rbtnQuantidade.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnQuantidade_MouseMove);
            // 
            // txtMultiplicador
            // 
            this.txtMultiplicador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtMultiplicador.Location = new System.Drawing.Point(477, 41);
            this.txtMultiplicador.MaxLength = 15;
            this.txtMultiplicador.Name = "txtMultiplicador";
            this.txtMultiplicador.Size = new System.Drawing.Size(69, 20);
            this.txtMultiplicador.TabIndex = 8;
            this.txtMultiplicador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMultiplicador.Enter += new System.EventHandler(this.txtPorcentagem_Enter);
            this.txtMultiplicador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentagem_KeyPress);
            this.txtMultiplicador.Leave += new System.EventHandler(this.txtPorcentagem_Leave);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(533, 99);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 10;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAjustar.SetToolTip(this.btnSair, "Sair de Ajustar Inventário.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalvar.Location = new System.Drawing.Point(457, 99);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAjustar.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // ttpAjustar
            // 
            this.ttpAjustar.AutoPopDelay = 5000;
            this.ttpAjustar.InitialDelay = 1000;
            this.ttpAjustar.IsBalloon = true;
            this.ttpAjustar.ReshowDelay = 100;
            this.ttpAjustar.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpAjustar.ToolTipTitle = "Dica:";
            // 
            // FrmInvAjustarInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(605, 137);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInvAjustarInventario";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajustar Inventário";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAjustarInventario_FormClosing);
            this.Load += new System.EventHandler(this.FrmAjustarInventario_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmAjustarInventario_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnSaldo;
        private System.Windows.Forms.RadioButton rbtnQuantidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ToolTip ttpAjustar;
        private System.Windows.Forms.TextBox txtMultiplicador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSubGrupo1;
        private System.Windows.Forms.ComboBox cbbpSubGrupo;
        private System.Windows.Forms.ComboBox cbbpGrupo;
        private System.Windows.Forms.Button btnpProcurar;
        private System.Windows.Forms.Button btnpProcurarSub1;
        private System.Windows.Forms.Label lblAsterisco2;
    }
}