namespace Seven_Sistema
{
    partial class FrmRelBaixarCheque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelBaixarCheque));
            this.ttpBaixa = new System.Windows.Forms.ToolTip(this.components);
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.lblNCheque = new System.Windows.Forms.Label();
            this.lbldocumento = new System.Windows.Forms.Label();
            this.mtxtDataCompensacao = new System.Windows.Forms.MaskedTextBox();
            this.lblValorCodigo = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblDataPagamento = new System.Windows.Forms.Label();
            this.lblValorDataEmissao = new System.Windows.Forms.Label();
            this.lblValorDataVencimento = new System.Windows.Forms.Label();
            this.lblDataVencimento = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblDataEmissao = new System.Windows.Forms.Label();
            this.lblValorDocumento = new System.Windows.Forms.Label();
            this.pcibInterrogacao = new System.Windows.Forms.PictureBox();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).BeginInit();
            this.SuspendLayout();
            // 
            // ttpBaixa
            // 
            this.ttpBaixa.AutoPopDelay = 5000;
            this.ttpBaixa.InitialDelay = 1000;
            this.ttpBaixa.IsBalloon = true;
            this.ttpBaixa.ReshowDelay = 100;
            this.ttpBaixa.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpBaixa.ToolTipTitle = "Dica:";
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(659, 43);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 3;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixa.SetToolTip(this.btnSelecionarData, "Clique para selecionar uma data.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(648, 92);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 117;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixa.SetToolTip(this.btnSair, "Sair de Baixa do Registro.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(572, 92);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 116;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixa.SetToolTip(this.btnSalvar, "Salvar os dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblAsterisco1);
            this.grbBox1.Controls.Add(this.lblNCheque);
            this.grbBox1.Controls.Add(this.lbldocumento);
            this.grbBox1.Controls.Add(this.mtxtDataCompensacao);
            this.grbBox1.Controls.Add(this.lblValorCodigo);
            this.grbBox1.Controls.Add(this.lblCodigo);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.lblDataPagamento);
            this.grbBox1.Controls.Add(this.lblValorDataEmissao);
            this.grbBox1.Controls.Add(this.lblValorDataVencimento);
            this.grbBox1.Controls.Add(this.lblDataVencimento);
            this.grbBox1.Controls.Add(this.lblValor);
            this.grbBox1.Controls.Add(this.lblDataEmissao);
            this.grbBox1.Controls.Add(this.lblValorDocumento);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(691, 74);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Informações do Cheque:";
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(560, 47);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(11, 13);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // lblNCheque
            // 
            this.lblNCheque.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNCheque.BackColor = System.Drawing.Color.White;
            this.lblNCheque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNCheque.Location = new System.Drawing.Point(338, 16);
            this.lblNCheque.Name = "lblNCheque";
            this.lblNCheque.Size = new System.Drawing.Size(101, 22);
            this.lblNCheque.TabIndex = 0;
            this.lblNCheque.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNCheque.Click += new System.EventHandler(this.lblNCheque_Click);
            this.lblNCheque.MouseLeave += new System.EventHandler(this.lblNCheque_MouseLeave);
            this.lblNCheque.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblNCheque_MouseMove);
            // 
            // lbldocumento
            // 
            this.lbldocumento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbldocumento.AutoSize = true;
            this.lbldocumento.BackColor = System.Drawing.Color.Transparent;
            this.lbldocumento.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldocumento.ForeColor = System.Drawing.Color.Black;
            this.lbldocumento.Location = new System.Drawing.Point(248, 20);
            this.lbldocumento.Name = "lbldocumento";
            this.lbldocumento.Size = new System.Drawing.Size(88, 15);
            this.lbldocumento.TabIndex = 0;
            this.lbldocumento.Text = "Nº do Cheque:";
            this.lbldocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mtxtDataCompensacao
            // 
            this.mtxtDataCompensacao.BackColor = System.Drawing.Color.White;
            this.mtxtDataCompensacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtDataCompensacao.Location = new System.Drawing.Point(575, 45);
            this.mtxtDataCompensacao.Mask = "00/00/0000";
            this.mtxtDataCompensacao.Name = "mtxtDataCompensacao";
            this.mtxtDataCompensacao.Size = new System.Drawing.Size(78, 20);
            this.mtxtDataCompensacao.TabIndex = 2;
            this.mtxtDataCompensacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtDataCompensacao.ValidatingType = typeof(System.DateTime);
            this.mtxtDataCompensacao.DoubleClick += new System.EventHandler(this.mtxtDataCompensacao_DoubleClick);
            this.mtxtDataCompensacao.Enter += new System.EventHandler(this.mtxtDataCompensacao_Enter);
            this.mtxtDataCompensacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtDataCompensacao_KeyPress);
            this.mtxtDataCompensacao.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtDataCompensacao_KeyUp);
            this.mtxtDataCompensacao.Leave += new System.EventHandler(this.mtxtDataCompensacao_Leave);
            // 
            // lblValorCodigo
            // 
            this.lblValorCodigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorCodigo.BackColor = System.Drawing.Color.White;
            this.lblValorCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorCodigo.Location = new System.Drawing.Point(134, 16);
            this.lblValorCodigo.Name = "lblValorCodigo";
            this.lblValorCodigo.Size = new System.Drawing.Size(108, 22);
            this.lblValorCodigo.TabIndex = 0;
            this.lblValorCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorCodigo.Click += new System.EventHandler(this.lblValorCodigo_Click);
            this.lblValorCodigo.MouseLeave += new System.EventHandler(this.lblValorCodigo_MouseLeave);
            this.lblValorCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorCodigo_MouseMove);
            // 
            // lblCodigo
            // 
            this.lblCodigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.Black;
            this.lblCodigo.Location = new System.Drawing.Point(82, 20);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(48, 15);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDataPagamento
            // 
            this.lblDataPagamento.AutoSize = true;
            this.lblDataPagamento.Location = new System.Drawing.Point(446, 47);
            this.lblDataPagamento.Name = "lblDataPagamento";
            this.lblDataPagamento.Size = new System.Drawing.Size(119, 13);
            this.lblDataPagamento.TabIndex = 0;
            this.lblDataPagamento.Text = "Data de Compensação:";
            // 
            // lblValorDataEmissao
            // 
            this.lblValorDataEmissao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDataEmissao.BackColor = System.Drawing.Color.White;
            this.lblValorDataEmissao.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDataEmissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDataEmissao.Location = new System.Drawing.Point(566, 15);
            this.lblValorDataEmissao.Name = "lblValorDataEmissao";
            this.lblValorDataEmissao.Size = new System.Drawing.Size(119, 22);
            this.lblValorDataEmissao.TabIndex = 0;
            this.lblValorDataEmissao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblValorDataEmissao.Click += new System.EventHandler(this.lblValorDataEmissao_Click);
            this.lblValorDataEmissao.MouseLeave += new System.EventHandler(this.lblValorDataEmissao_MouseLeave);
            this.lblValorDataEmissao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorDataEmissao_MouseMove);
            // 
            // lblValorDataVencimento
            // 
            this.lblValorDataVencimento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDataVencimento.BackColor = System.Drawing.Color.White;
            this.lblValorDataVencimento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDataVencimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDataVencimento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblValorDataVencimento.Location = new System.Drawing.Point(134, 44);
            this.lblValorDataVencimento.Name = "lblValorDataVencimento";
            this.lblValorDataVencimento.Size = new System.Drawing.Size(108, 22);
            this.lblValorDataVencimento.TabIndex = 0;
            this.lblValorDataVencimento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblValorDataVencimento.Click += new System.EventHandler(this.lblValorDataVencimento_Click);
            this.lblValorDataVencimento.MouseLeave += new System.EventHandler(this.lblValorDataVencimento_MouseLeave);
            this.lblValorDataVencimento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorDataVencimento_MouseMove);
            // 
            // lblDataVencimento
            // 
            this.lblDataVencimento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDataVencimento.AutoSize = true;
            this.lblDataVencimento.BackColor = System.Drawing.Color.Transparent;
            this.lblDataVencimento.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataVencimento.ForeColor = System.Drawing.Color.Black;
            this.lblDataVencimento.Location = new System.Drawing.Point(6, 47);
            this.lblDataVencimento.Name = "lblDataVencimento";
            this.lblDataVencimento.Size = new System.Drawing.Size(122, 15);
            this.lblDataVencimento.TabIndex = 0;
            this.lblDataVencimento.Text = "Data de Vencimento:";
            this.lblDataVencimento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.Color.Black;
            this.lblValor.Location = new System.Drawing.Point(268, 47);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(64, 15);
            this.lblValor.TabIndex = 0;
            this.lblValor.Text = "Valor (R$):";
            // 
            // lblDataEmissao
            // 
            this.lblDataEmissao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDataEmissao.AutoSize = true;
            this.lblDataEmissao.BackColor = System.Drawing.Color.Transparent;
            this.lblDataEmissao.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataEmissao.ForeColor = System.Drawing.Color.Black;
            this.lblDataEmissao.Location = new System.Drawing.Point(465, 20);
            this.lblDataEmissao.Name = "lblDataEmissao";
            this.lblDataEmissao.Size = new System.Drawing.Size(99, 15);
            this.lblDataEmissao.TabIndex = 0;
            this.lblDataEmissao.Text = "Data de Emissão:";
            this.lblDataEmissao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorDocumento
            // 
            this.lblValorDocumento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDocumento.BackColor = System.Drawing.Color.White;
            this.lblValorDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDocumento.Location = new System.Drawing.Point(338, 42);
            this.lblValorDocumento.Name = "lblValorDocumento";
            this.lblValorDocumento.Size = new System.Drawing.Size(101, 22);
            this.lblValorDocumento.TabIndex = 0;
            this.lblValorDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorDocumento.Click += new System.EventHandler(this.lblValorDocumento_Click);
            this.lblValorDocumento.MouseLeave += new System.EventHandler(this.lblValorDocumento_MouseLeave);
            this.lblValorDocumento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorDocumento_MouseMove);
            // 
            // pcibInterrogacao
            // 
            this.pcibInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao.Image")));
            this.pcibInterrogacao.Location = new System.Drawing.Point(546, 92);
            this.pcibInterrogacao.Name = "pcibInterrogacao";
            this.pcibInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao.TabIndex = 118;
            this.pcibInterrogacao.TabStop = false;
            this.pcibInterrogacao.MouseLeave += new System.EventHandler(this.pcibInterrogacao_MouseLeave);
            this.pcibInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao_MouseMove);
            // 
            // FrmRelBaixarCheque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(716, 128);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.pcibInterrogacao);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelBaixarCheque";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baixar Registro";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRelBaixarCheque_FormClosing);
            this.Load += new System.EventHandler(this.FrmRelBaixarCheque_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRelBaixarCheque_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ttpBaixa;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblNCheque;
        private System.Windows.Forms.Label lbldocumento;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblValorCodigo;
        private System.Windows.Forms.MaskedTextBox mtxtDataCompensacao;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.Label lblDataPagamento;
        private System.Windows.Forms.Label lblValorDocumento;
        private System.Windows.Forms.Label lblDataEmissao;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblDataVencimento;
        private System.Windows.Forms.Label lblValorDataEmissao;
        private System.Windows.Forms.Label lblValorDataVencimento;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox pcibInterrogacao;
        private System.Windows.Forms.Button btnSalvar;
    }
}