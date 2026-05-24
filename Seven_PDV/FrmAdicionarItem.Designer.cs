namespace Seven_Sistema
{
    partial class FrmAdicionarItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdicionarItem));
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtValorUnitario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.picbInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.ttpAdicionar = new System.Windows.Forms.ToolTip(this.components);
            this.cbbUM = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.lblAsterisco2 = new System.Windows.Forms.Label();
            this.lblAsterisco3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalCDescAcresc = new System.Windows.Forms.Label();
            this.lblValorTotalDescAcresc = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.lblValorAcrescimo = new System.Windows.Forms.Label();
            this.txtValorAcrescimo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAcrescimoPorc = new System.Windows.Forms.Label();
            this.txtAcrescimoPorc = new System.Windows.Forms.TextBox();
            this.lblValorDesconto = new System.Windows.Forms.Label();
            this.txtValorDesconto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.txtDescontoPorc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(6, 16);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(65, 13);
            this.lblQuantidade.TabIndex = 0;
            this.lblQuantidade.Text = "Quantidade:";
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.BackColor = System.Drawing.Color.White;
            this.txtQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidade.Location = new System.Drawing.Point(6, 32);
            this.txtQuantidade.MaxLength = 18;
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(80, 20);
            this.txtQuantidade.TabIndex = 2;
            this.txtQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantidade.Enter += new System.EventHandler(this.txtQuantidade_Enter);
            this.txtQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidade_KeyPress);
            this.txtQuantidade.Leave += new System.EventHandler(this.txtQuantidade_Leave);
            // 
            // txtValorUnitario
            // 
            this.txtValorUnitario.BackColor = System.Drawing.Color.White;
            this.txtValorUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorUnitario.Location = new System.Drawing.Point(165, 32);
            this.txtValorUnitario.MaxLength = 18;
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.txtValorUnitario.Size = new System.Drawing.Size(80, 20);
            this.txtValorUnitario.TabIndex = 4;
            this.txtValorUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorUnitario.Enter += new System.EventHandler(this.txtValorUnitario_Enter);
            this.txtValorUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorUnitario_KeyPress);
            this.txtValorUnitario.Leave += new System.EventHandler(this.txtValorUnitario_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Valor Unitário (R$):";
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(665, 106);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 10;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAdicionar.SetToolTip(this.btnSair, "Clique para sair de Inclusão de Itens.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluir.Image")));
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnIncluir.Location = new System.Drawing.Point(589, 106);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(70, 32);
            this.btnIncluir.TabIndex = 9;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAdicionar.SetToolTip(this.btnIncluir, "Clique para incluir os dados.");
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            this.btnIncluir.MouseLeave += new System.EventHandler(this.btnIncluir_MouseLeave);
            this.btnIncluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnIncluir_MouseMove);
            // 
            // picbInterrogacao2
            // 
            this.picbInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao2.Image")));
            this.picbInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picbInterrogacao2.Location = new System.Drawing.Point(563, 106);
            this.picbInterrogacao2.Name = "picbInterrogacao2";
            this.picbInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao2.TabIndex = 33;
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
            // cbbUM
            // 
            this.cbbUM.BackColor = System.Drawing.Color.LightBlue;
            this.cbbUM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUM.FormattingEnabled = true;
            this.cbbUM.Items.AddRange(new object[] {
            "",
            "UN",
            "CX",
            "KG",
            "M",
            "VD",
            "FR",
            "TB",
            "AP",
            "GA",
            "SC",
            "LT",
            "AM",
            "FL",
            "RL",
            "PT"});
            this.cbbUM.Location = new System.Drawing.Point(92, 32);
            this.cbbUM.Name = "cbbUM";
            this.cbbUM.Size = new System.Drawing.Size(50, 21);
            this.cbbUM.TabIndex = 3;
            this.cbbUM.DropDown += new System.EventHandler(this.cbbUM_DropDown);
            this.cbbUM.DropDownClosed += new System.EventHandler(this.cbbUM_DropDownClosed);
            this.cbbUM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbUM_KeyPress);
            this.cbbUM.MouseLeave += new System.EventHandler(this.cbbUM_MouseLeave);
            this.cbbUM.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbUM_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "UN:";
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(66, 12);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // lblAsterisco2
            // 
            this.lblAsterisco2.AutoSize = true;
            this.lblAsterisco2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco2.Location = new System.Drawing.Point(113, 12);
            this.lblAsterisco2.Name = "lblAsterisco2";
            this.lblAsterisco2.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco2.TabIndex = 0;
            this.lblAsterisco2.Text = "*";
            // 
            // lblAsterisco3
            // 
            this.lblAsterisco3.AutoSize = true;
            this.lblAsterisco3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco3.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco3.Location = new System.Drawing.Point(240, 12);
            this.lblAsterisco3.Name = "lblAsterisco3";
            this.lblAsterisco3.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco3.TabIndex = 0;
            this.lblAsterisco3.Text = "*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAsterisco3);
            this.groupBox1.Controls.Add(this.lblAsterisco2);
            this.groupBox1.Controls.Add(this.lblAsterisco1);
            this.groupBox1.Controls.Add(this.lblTotalCDescAcresc);
            this.groupBox1.Controls.Add(this.lblValorTotalDescAcresc);
            this.groupBox1.Controls.Add(this.lblValor);
            this.groupBox1.Controls.Add(this.lblValorTotal);
            this.groupBox1.Controls.Add(this.lblValorAcrescimo);
            this.groupBox1.Controls.Add(this.txtValorAcrescimo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblAcrescimoPorc);
            this.groupBox1.Controls.Add(this.txtAcrescimoPorc);
            this.groupBox1.Controls.Add(this.lblValorDesconto);
            this.groupBox1.Controls.Add(this.txtValorDesconto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblDesconto);
            this.groupBox1.Controls.Add(this.txtDescontoPorc);
            this.groupBox1.Controls.Add(this.lblQuantidade);
            this.groupBox1.Controls.Add(this.txtQuantidade);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtValorUnitario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbbUM);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(708, 88);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ações:";
            // 
            // lblTotalCDescAcresc
            // 
            this.lblTotalCDescAcresc.AutoSize = true;
            this.lblTotalCDescAcresc.Font = new System.Drawing.Font("Calibri", 14.25F);
            this.lblTotalCDescAcresc.Location = new System.Drawing.Point(235, 56);
            this.lblTotalCDescAcresc.Name = "lblTotalCDescAcresc";
            this.lblTotalCDescAcresc.Size = new System.Drawing.Size(318, 23);
            this.lblTotalCDescAcresc.TabIndex = 49;
            this.lblTotalCDescAcresc.Text = "Total após Descontos e Acréscimos (R$):";
            // 
            // lblValorTotalDescAcresc
            // 
            this.lblValorTotalDescAcresc.BackColor = System.Drawing.Color.White;
            this.lblValorTotalDescAcresc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValorTotalDescAcresc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalDescAcresc.ForeColor = System.Drawing.Color.Blue;
            this.lblValorTotalDescAcresc.Location = new System.Drawing.Point(554, 55);
            this.lblValorTotalDescAcresc.Name = "lblValorTotalDescAcresc";
            this.lblValorTotalDescAcresc.Size = new System.Drawing.Size(150, 26);
            this.lblValorTotalDescAcresc.TabIndex = 50;
            this.lblValorTotalDescAcresc.Text = "0,00";
            this.lblValorTotalDescAcresc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotalDescAcresc.Click += new System.EventHandler(this.lblValorTotalDescAcresc_Click);
            this.lblValorTotalDescAcresc.MouseLeave += new System.EventHandler(this.lblValorTotalDescAcresc_MouseLeave);
            this.lblValorTotalDescAcresc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotalDescAcresc_MouseMove);
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblValor.Location = new System.Drawing.Point(279, 16);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(57, 13);
            this.lblValor.TabIndex = 48;
            this.lblValor.Text = "Total (R$):";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.BackColor = System.Drawing.Color.White;
            this.lblValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblValorTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblValorTotal.Location = new System.Drawing.Point(282, 31);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(80, 21);
            this.lblValorTotal.TabIndex = 46;
            this.lblValorTotal.Text = "0,00";
            this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotal.Click += new System.EventHandler(this.lblValorTotal_Click);
            this.lblValorTotal.MouseLeave += new System.EventHandler(this.lblValorTotal_MouseLeave);
            this.lblValorTotal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotal_MouseMove);
            // 
            // lblValorAcrescimo
            // 
            this.lblValorAcrescimo.AutoSize = true;
            this.lblValorAcrescimo.Location = new System.Drawing.Point(622, 16);
            this.lblValorAcrescimo.Name = "lblValorAcrescimo";
            this.lblValorAcrescimo.Size = new System.Drawing.Size(82, 13);
            this.lblValorAcrescimo.TabIndex = 0;
            this.lblValorAcrescimo.Text = "Acréscimo (R$):";
            // 
            // txtValorAcrescimo
            // 
            this.txtValorAcrescimo.BackColor = System.Drawing.Color.White;
            this.txtValorAcrescimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorAcrescimo.Location = new System.Drawing.Point(625, 32);
            this.txtValorAcrescimo.MaxLength = 18;
            this.txtValorAcrescimo.Name = "txtValorAcrescimo";
            this.txtValorAcrescimo.Size = new System.Drawing.Size(80, 20);
            this.txtValorAcrescimo.TabIndex = 8;
            this.txtValorAcrescimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorAcrescimo.Enter += new System.EventHandler(this.txtValorAcrescimo_Enter);
            this.txtValorAcrescimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorAcrescimo_KeyPress);
            this.txtValorAcrescimo.Leave += new System.EventHandler(this.txtValorAcrescimo_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(611, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "%";
            // 
            // lblAcrescimoPorc
            // 
            this.lblAcrescimoPorc.AutoSize = true;
            this.lblAcrescimoPorc.Location = new System.Drawing.Point(548, 16);
            this.lblAcrescimoPorc.Name = "lblAcrescimoPorc";
            this.lblAcrescimoPorc.Size = new System.Drawing.Size(59, 13);
            this.lblAcrescimoPorc.TabIndex = 0;
            this.lblAcrescimoPorc.Text = "Acréscimo:";
            // 
            // txtAcrescimoPorc
            // 
            this.txtAcrescimoPorc.BackColor = System.Drawing.Color.White;
            this.txtAcrescimoPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcrescimoPorc.Location = new System.Drawing.Point(551, 32);
            this.txtAcrescimoPorc.MaxLength = 18;
            this.txtAcrescimoPorc.Name = "txtAcrescimoPorc";
            this.txtAcrescimoPorc.Size = new System.Drawing.Size(60, 20);
            this.txtAcrescimoPorc.TabIndex = 7;
            this.txtAcrescimoPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAcrescimoPorc.Enter += new System.EventHandler(this.txtAcrescimoPorc_Enter);
            this.txtAcrescimoPorc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcrescimoPorc_KeyPress);
            this.txtAcrescimoPorc.Leave += new System.EventHandler(this.txtAcrescimoPorc_Leave);
            // 
            // lblValorDesconto
            // 
            this.lblValorDesconto.AutoSize = true;
            this.lblValorDesconto.Location = new System.Drawing.Point(463, 16);
            this.lblValorDesconto.Name = "lblValorDesconto";
            this.lblValorDesconto.Size = new System.Drawing.Size(79, 13);
            this.lblValorDesconto.TabIndex = 0;
            this.lblValorDesconto.Text = "Desconto (R$):";
            // 
            // txtValorDesconto
            // 
            this.txtValorDesconto.BackColor = System.Drawing.Color.White;
            this.txtValorDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorDesconto.Location = new System.Drawing.Point(465, 32);
            this.txtValorDesconto.MaxLength = 18;
            this.txtValorDesconto.Name = "txtValorDesconto";
            this.txtValorDesconto.Size = new System.Drawing.Size(80, 20);
            this.txtValorDesconto.TabIndex = 6;
            this.txtValorDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorDesconto.Enter += new System.EventHandler(this.txtValorDesconto_Enter);
            this.txtValorDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorDesconto_KeyPress);
            this.txtValorDesconto.Leave += new System.EventHandler(this.txtValorDesconto_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "%";
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Location = new System.Drawing.Point(387, 16);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(56, 13);
            this.lblDesconto.TabIndex = 0;
            this.lblDesconto.Text = "Desconto:";
            // 
            // txtDescontoPorc
            // 
            this.txtDescontoPorc.BackColor = System.Drawing.Color.White;
            this.txtDescontoPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescontoPorc.Location = new System.Drawing.Point(390, 32);
            this.txtDescontoPorc.MaxLength = 18;
            this.txtDescontoPorc.Name = "txtDescontoPorc";
            this.txtDescontoPorc.Size = new System.Drawing.Size(60, 20);
            this.txtDescontoPorc.TabIndex = 5;
            this.txtDescontoPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescontoPorc.Enter += new System.EventHandler(this.txtDescontoPorc_Enter);
            this.txtDescontoPorc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescontoPorc_KeyPress);
            this.txtDescontoPorc.Leave += new System.EventHandler(this.txtDescontoPorc_Leave);
            // 
            // FrmAdicionarItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(732, 144);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.picbInterrogacao2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdicionarItem";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inclusão de Itens";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAdicionarItemOrc_FormClosing);
            this.Load += new System.EventHandler(this.FrmAdicionarItemOrc_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmAdicionarItemOrc_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtValorUnitario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.PictureBox picbInterrogacao2;
        private System.Windows.Forms.ToolTip ttpAdicionar;
        private System.Windows.Forms.ComboBox cbbUM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.Label lblAsterisco2;
        private System.Windows.Forms.Label lblAsterisco3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblValorAcrescimo;
        private System.Windows.Forms.TextBox txtValorAcrescimo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAcrescimoPorc;
        private System.Windows.Forms.TextBox txtAcrescimoPorc;
        private System.Windows.Forms.Label lblValorDesconto;
        private System.Windows.Forms.TextBox txtValorDesconto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.TextBox txtDescontoPorc;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblTotalCDescAcresc;
        private System.Windows.Forms.Label lblValorTotalDescAcresc;
    }
}