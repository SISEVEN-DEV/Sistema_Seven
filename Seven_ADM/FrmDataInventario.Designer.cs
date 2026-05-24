namespace Seven_Sistema
{
    partial class FrmDataInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataInventario));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.chkbInvCont = new System.Windows.Forms.CheckBox();
            this.pcibInterrogacao2 = new System.Windows.Forms.PictureBox();
            this.btnProcurarLocalizacao = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.mtxtUltimoInventario = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDataVenda = new System.Windows.Forms.Label();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.lblAte = new System.Windows.Forms.Label();
            this.lblCidade = new System.Windows.Forms.Label();
            this.cbbLocalizacao = new System.Windows.Forms.ComboBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ttpInv = new System.Windows.Forms.ToolTip(this.components);
            this.btnSair = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao2)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.chkbInvCont);
            this.grbBox1.Controls.Add(this.pcibInterrogacao2);
            this.grbBox1.Controls.Add(this.btnProcurarLocalizacao);
            this.grbBox1.Controls.Add(this.label9);
            this.grbBox1.Controls.Add(this.mtxtUltimoInventario);
            this.grbBox1.Controls.Add(this.label2);
            this.grbBox1.Controls.Add(this.lblDataVenda);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.lblCidade);
            this.grbBox1.Controls.Add(this.cbbLocalizacao);
            this.grbBox1.Controls.Add(this.txtDescricao);
            this.grbBox1.Controls.Add(this.label1);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(352, 158);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Informações do Inventário:";
            // 
            // chkbInvCont
            // 
            this.chkbInvCont.AutoSize = true;
            this.chkbInvCont.Checked = true;
            this.chkbInvCont.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbInvCont.Location = new System.Drawing.Point(6, 137);
            this.chkbInvCont.Name = "chkbInvCont";
            this.chkbInvCont.Size = new System.Drawing.Size(153, 17);
            this.chkbInvCont.TabIndex = 9;
            this.chkbInvCont.Text = "Apenas Inventário Contábil";
            this.chkbInvCont.UseVisualStyleBackColor = true;
            this.chkbInvCont.MouseLeave += new System.EventHandler(this.chkbInvCont_MouseLeave);
            this.chkbInvCont.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbInvCont_MouseMove);
            // 
            // pcibInterrogacao2
            // 
            this.pcibInterrogacao2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao2.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao2.Image")));
            this.pcibInterrogacao2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pcibInterrogacao2.Location = new System.Drawing.Point(90, 32);
            this.pcibInterrogacao2.Name = "pcibInterrogacao2";
            this.pcibInterrogacao2.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao2.TabIndex = 72;
            this.pcibInterrogacao2.TabStop = false;
            this.pcibInterrogacao2.Click += new System.EventHandler(this.pcibInterrogacao2_Click);
            this.pcibInterrogacao2.MouseLeave += new System.EventHandler(this.pcibInterrogacao2_MouseLeave);
            this.pcibInterrogacao2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao2_MouseMove);
            // 
            // btnProcurarLocalizacao
            // 
            this.btnProcurarLocalizacao.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarLocalizacao.Image")));
            this.btnProcurarLocalizacao.Location = new System.Drawing.Point(313, 107);
            this.btnProcurarLocalizacao.Name = "btnProcurarLocalizacao";
            this.btnProcurarLocalizacao.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarLocalizacao.TabIndex = 8;
            this.btnProcurarLocalizacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInv.SetToolTip(this.btnProcurarLocalizacao, "Clique para pesquisar uma Localização.");
            this.btnProcurarLocalizacao.UseVisualStyleBackColor = true;
            this.btnProcurarLocalizacao.Click += new System.EventHandler(this.btnProcurarLocalizacao_Click);
            this.btnProcurarLocalizacao.MouseLeave += new System.EventHandler(this.btnProcurarLocalizacao_MouseLeave);
            this.btnProcurarLocalizacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarLocalizacao_MouseMove);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(296, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "*";
            // 
            // mtxtUltimoInventario
            // 
            this.mtxtUltimoInventario.BackColor = System.Drawing.Color.White;
            this.mtxtUltimoInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtUltimoInventario.Location = new System.Drawing.Point(6, 32);
            this.mtxtUltimoInventario.Mask = "00/00/0000";
            this.mtxtUltimoInventario.Name = "mtxtUltimoInventario";
            this.mtxtUltimoInventario.ReadOnly = true;
            this.mtxtUltimoInventario.Size = new System.Drawing.Size(78, 20);
            this.mtxtUltimoInventario.TabIndex = 2;
            this.mtxtUltimoInventario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(2, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Último Inventário:";
            // 
            // lblDataVenda
            // 
            this.lblDataVenda.AutoSize = true;
            this.lblDataVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataVenda.Location = new System.Drawing.Point(132, 16);
            this.lblDataVenda.Name = "lblDataVenda";
            this.lblDataVenda.Size = new System.Drawing.Size(169, 13);
            this.lblDataVenda.TabIndex = 0;
            this.lblDataVenda.Text = "Data de Inicio e Fim do Inventário:";
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(313, 29);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 5;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInv.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // mtxtpData
            // 
            this.mtxtpData.BackColor = System.Drawing.Color.White;
            this.mtxtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData.Location = new System.Drawing.Point(118, 32);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 3;
            this.mtxtpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData.DoubleClick += new System.EventHandler(this.mtxtpData_DoubleClick);
            this.mtxtpData.Enter += new System.EventHandler(this.mtxtpData_Enter);
            this.mtxtpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData_KeyPress);
            this.mtxtpData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData_KeyUp);
            this.mtxtpData.Leave += new System.EventHandler(this.mtxtpData_Leave);
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(229, 32);
            this.mtxtpData1.Mask = "00/00/0000";
            this.mtxtpData1.Name = "mtxtpData1";
            this.mtxtpData1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData1.TabIndex = 4;
            this.mtxtpData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtpData1.DoubleClick += new System.EventHandler(this.mtxtpData1_DoubleClick);
            this.mtxtpData1.Enter += new System.EventHandler(this.mtxtpData1_Enter);
            this.mtxtpData1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtpData1_KeyPress);
            this.mtxtpData1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtpData1_KeyUp);
            this.mtxtpData1.Leave += new System.EventHandler(this.mtxtpData1_Leave);
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(202, 35);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(6, 94);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(67, 13);
            this.lblCidade.TabIndex = 0;
            this.lblCidade.Text = "Localização:";
            // 
            // cbbLocalizacao
            // 
            this.cbbLocalizacao.BackColor = System.Drawing.Color.LightBlue;
            this.cbbLocalizacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLocalizacao.DropDownWidth = 325;
            this.cbbLocalizacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbbLocalizacao.FormattingEnabled = true;
            this.cbbLocalizacao.Location = new System.Drawing.Point(6, 110);
            this.cbbLocalizacao.Name = "cbbLocalizacao";
            this.cbbLocalizacao.Size = new System.Drawing.Size(301, 21);
            this.cbbLocalizacao.TabIndex = 7;
            this.cbbLocalizacao.DropDown += new System.EventHandler(this.cbbLocalizacao_DropDown);
            this.cbbLocalizacao.DropDownClosed += new System.EventHandler(this.cbbLocalizacao_DropDownClosed);
            this.cbbLocalizacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbLocalizacao_KeyPress);
            this.cbbLocalizacao.MouseLeave += new System.EventHandler(this.cbbLocalizacao_MouseLeave);
            this.cbbLocalizacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbLocalizacao_MouseMove);
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDescricao.Location = new System.Drawing.Point(6, 71);
            this.txtDescricao.MaxLength = 60;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(333, 20);
            this.txtDescricao.TabIndex = 6;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            this.txtDescricao.Leave += new System.EventHandler(this.txtDescricao_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrição:";
            // 
            // ttpInv
            // 
            this.ttpInv.AutoPopDelay = 5000;
            this.ttpInv.InitialDelay = 1000;
            this.ttpInv.IsBalloon = true;
            this.ttpInv.ReshowDelay = 100;
            this.ttpInv.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpInv.ToolTipTitle = "Dica:";
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(309, 176);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 11;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInv.SetToolTip(this.btnSair, "Sair do Inventário de Produtos.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Image = ((System.Drawing.Image)(resources.GetObject("btnContinuar.Image")));
            this.btnContinuar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnContinuar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnContinuar.Location = new System.Drawing.Point(217, 176);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(86, 32);
            this.btnContinuar.TabIndex = 10;
            this.btnContinuar.Text = "&Continuar";
            this.btnContinuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInv.SetToolTip(this.btnContinuar, "Clique para prosseguir para o Inventário de Produtos.");
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            this.btnContinuar.MouseLeave += new System.EventHandler(this.btnContinuar_MouseLeave);
            this.btnContinuar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnContinuar_MouseMove);
            // 
            // FrmDataInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(379, 213);
            this.ControlBox = false;
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDataInventario";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventário de Produtos";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDataInventario_FormClosing);
            this.Load += new System.EventHandler(this.FrmDataInventario_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmDataInventario_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ToolTip ttpInv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.ComboBox cbbLocalizacao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox mtxtUltimoInventario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDataVenda;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.Button btnProcurarLocalizacao;
        private System.Windows.Forms.CheckBox chkbInvCont;
        private System.Windows.Forms.PictureBox pcibInterrogacao2;
    }
}