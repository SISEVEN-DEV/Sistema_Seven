namespace Seven_Sistema
{
    partial class FrmUtilEnviarSMS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUtilEnviarSMS));
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.lblQtdeCar = new System.Windows.Forms.Label();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.pcibInterrogacao = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ttpSMS = new System.Windows.Forms.ToolTip(this.components);
            this.btnAdicionarManual = new System.Windows.Forms.Button();
            this.btnFuncionario = new System.Windows.Forms.Button();
            this.btnPesquisarForn = new System.Windows.Forms.Button();
            this.btnProcurarCliente = new System.Windows.Forms.Button();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.pgbProgresso = new System.Windows.Forms.ProgressBar();
            this.bckwIndeterminado = new System.ComponentModel.BackgroundWorker();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mtxtCelular = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPara = new System.Windows.Forms.TextBox();
            this.lblAsterisco7 = new System.Windows.Forms.Label();
            this.cbbPorta = new System.Windows.Forms.ComboBox();
            this.lblPorta = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).BeginInit();
            this.grbBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(237, 135);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // lblQtdeCar
            // 
            this.lblQtdeCar.Location = new System.Drawing.Point(236, 280);
            this.lblQtdeCar.Name = "lblQtdeCar";
            this.lblQtdeCar.Size = new System.Drawing.Size(183, 13);
            this.lblQtdeCar.TabIndex = 0;
            this.lblQtdeCar.Text = "Max. de Caracteres: 0/160";
            this.lblQtdeCar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.Location = new System.Drawing.Point(180, 138);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(62, 13);
            this.lblMensagem.TabIndex = 0;
            this.lblMensagem.Text = "Mensagem:";
            // 
            // pcibInterrogacao
            // 
            this.pcibInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao.Image")));
            this.pcibInterrogacao.Location = new System.Drawing.Point(9, 283);
            this.pcibInterrogacao.Name = "pcibInterrogacao";
            this.pcibInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao.TabIndex = 53;
            this.pcibInterrogacao.TabStop = false;
            this.pcibInterrogacao.Click += new System.EventHandler(this.pcibInterrogacao_Click);
            this.pcibInterrogacao.MouseLeave += new System.EventHandler(this.pcibAnexo_MouseLeave);
            this.pcibInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibAnexo_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(383, 354);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 35);
            this.btnSair.TabIndex = 11;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpSMS.SetToolTip(this.btnSair, "Sair do envio de SMS.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.Image")));
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnEnviar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEnviar.Location = new System.Drawing.Point(349, 296);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(70, 35);
            this.btnEnviar.TabIndex = 10;
            this.btnEnviar.Text = "&Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpSMS.SetToolTip(this.btnEnviar, "Clique para enviar um SMS.");
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            this.btnEnviar.MouseLeave += new System.EventHandler(this.btnEnviar_MouseLeave);
            this.btnEnviar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEnviar_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Para:";
            // 
            // ttpSMS
            // 
            this.ttpSMS.AutoPopDelay = 5000;
            this.ttpSMS.InitialDelay = 1000;
            this.ttpSMS.IsBalloon = true;
            this.ttpSMS.ReshowDelay = 100;
            this.ttpSMS.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpSMS.ToolTipTitle = "Dica:";
            // 
            // btnAdicionarManual
            // 
            this.btnAdicionarManual.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarManual.Image")));
            this.btnAdicionarManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdicionarManual.Location = new System.Drawing.Point(161, 42);
            this.btnAdicionarManual.Name = "btnAdicionarManual";
            this.btnAdicionarManual.Size = new System.Drawing.Size(185, 25);
            this.btnAdicionarManual.TabIndex = 4;
            this.btnAdicionarManual.Text = "&Adicionar Número Manualmente";
            this.btnAdicionarManual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpSMS.SetToolTip(this.btnAdicionarManual, "Clique para adicionar um número de celular.");
            this.btnAdicionarManual.UseVisualStyleBackColor = true;
            this.btnAdicionarManual.Click += new System.EventHandler(this.btnAdicionarManual_Click);
            this.btnAdicionarManual.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.btnAdicionarManual.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // btnFuncionario
            // 
            this.btnFuncionario.Image = ((System.Drawing.Image)(resources.GetObject("btnFuncionario.Image")));
            this.btnFuncionario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFuncionario.Location = new System.Drawing.Point(274, 110);
            this.btnFuncionario.Name = "btnFuncionario";
            this.btnFuncionario.Size = new System.Drawing.Size(85, 25);
            this.btnFuncionario.TabIndex = 8;
            this.btnFuncionario.Text = "&Funcionário";
            this.btnFuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpSMS.SetToolTip(this.btnFuncionario, "Clique para pesquisar um Funcionário.");
            this.btnFuncionario.UseVisualStyleBackColor = true;
            this.btnFuncionario.Click += new System.EventHandler(this.btnFuncionario_Click);
            this.btnFuncionario.MouseLeave += new System.EventHandler(this.btnFuncionario_MouseLeave);
            this.btnFuncionario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnFuncionario_MouseMove);
            // 
            // btnPesquisarForn
            // 
            this.btnPesquisarForn.Image = ((System.Drawing.Image)(resources.GetObject("btnPesquisarForn.Image")));
            this.btnPesquisarForn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisarForn.Location = new System.Drawing.Point(183, 110);
            this.btnPesquisarForn.Name = "btnPesquisarForn";
            this.btnPesquisarForn.Size = new System.Drawing.Size(85, 25);
            this.btnPesquisarForn.TabIndex = 7;
            this.btnPesquisarForn.Text = "For&necedor";
            this.btnPesquisarForn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpSMS.SetToolTip(this.btnPesquisarForn, "Clique para pesquisar um Fornecedor.");
            this.btnPesquisarForn.UseVisualStyleBackColor = true;
            this.btnPesquisarForn.Click += new System.EventHandler(this.btnPesquisarForn_Click);
            this.btnPesquisarForn.MouseLeave += new System.EventHandler(this.btnPesquisarForn_MouseLeave);
            this.btnPesquisarForn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPesquisarForn_MouseMove);
            // 
            // btnProcurarCliente
            // 
            this.btnProcurarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarCliente.Image")));
            this.btnProcurarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcurarCliente.Location = new System.Drawing.Point(53, 110);
            this.btnProcurarCliente.Name = "btnProcurarCliente";
            this.btnProcurarCliente.Size = new System.Drawing.Size(124, 25);
            this.btnProcurarCliente.TabIndex = 6;
            this.btnProcurarCliente.Text = "&Cliente/Consumidor";
            this.btnProcurarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpSMS.SetToolTip(this.btnProcurarCliente, "Clique para pesquisar um Cliente/Consumidor.");
            this.btnProcurarCliente.UseVisualStyleBackColor = true;
            this.btnProcurarCliente.Click += new System.EventHandler(this.btnProcurarCliente_Click);
            this.btnProcurarCliente.MouseLeave += new System.EventHandler(this.btnProcurarCliente_MouseLeave);
            this.btnProcurarCliente.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarCliente_MouseMove);
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.BackColor = System.Drawing.Color.White;
            this.lblProgresso.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold);
            this.lblProgresso.ForeColor = System.Drawing.Color.Red;
            this.lblProgresso.Location = new System.Drawing.Point(70, 176);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(300, 33);
            this.lblProgresso.TabIndex = 0;
            this.lblProgresso.Text = "Por favor, aguarde...";
            this.lblProgresso.Visible = false;
            // 
            // pgbProgresso
            // 
            this.pgbProgresso.BackColor = System.Drawing.SystemColors.Control;
            this.pgbProgresso.Location = new System.Drawing.Point(60, 210);
            this.pgbProgresso.Name = "pgbProgresso";
            this.pgbProgresso.Size = new System.Drawing.Size(320, 23);
            this.pgbProgresso.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbProgresso.TabIndex = 0;
            this.pgbProgresso.Visible = false;
            // 
            // bckwIndeterminado
            // 
            this.bckwIndeterminado.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bckwIndeterminado_DoWork);
            this.bckwIndeterminado.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bckwIndeterminado_RunWorkerCompleted);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.label3);
            this.grbBox1.Controls.Add(this.btnAdicionarManual);
            this.grbBox1.Controls.Add(this.mtxtCelular);
            this.grbBox1.Controls.Add(this.btnFuncionario);
            this.grbBox1.Controls.Add(this.btnPesquisarForn);
            this.grbBox1.Controls.Add(this.btnProcurarCliente);
            this.grbBox1.Controls.Add(this.label2);
            this.grbBox1.Controls.Add(this.txtPara);
            this.grbBox1.Controls.Add(this.lblProgresso);
            this.grbBox1.Controls.Add(this.lblAsterisco7);
            this.grbBox1.Controls.Add(this.label1);
            this.grbBox1.Controls.Add(this.pgbProgresso);
            this.grbBox1.Controls.Add(this.cbbPorta);
            this.grbBox1.Controls.Add(this.lblPorta);
            this.grbBox1.Controls.Add(this.lblAsterisco1);
            this.grbBox1.Controls.Add(this.lblMensagem);
            this.grbBox1.Controls.Add(this.btnEnviar);
            this.grbBox1.Controls.Add(this.pcibInterrogacao);
            this.grbBox1.Controls.Add(this.lblQtdeCar);
            this.grbBox1.Controls.Add(this.txtMsg);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(426, 336);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Novo SMS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Celular:";
            // 
            // mtxtCelular
            // 
            this.mtxtCelular.BackColor = System.Drawing.Color.White;
            this.mtxtCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.mtxtCelular.Location = new System.Drawing.Point(53, 45);
            this.mtxtCelular.Mask = "(00) 00000-0000";
            this.mtxtCelular.Name = "mtxtCelular";
            this.mtxtCelular.Size = new System.Drawing.Size(102, 20);
            this.mtxtCelular.TabIndex = 3;
            this.mtxtCelular.Enter += new System.EventHandler(this.mtxtCelular_Enter);
            this.mtxtCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtCelular_KeyPress);
            this.mtxtCelular.Leave += new System.EventHandler(this.mtxtCelular_Leave);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(33, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 10);
            this.label2.TabIndex = 0;
            this.label2.Text = "*";
            // 
            // txtPara
            // 
            this.txtPara.BackColor = System.Drawing.Color.White;
            this.txtPara.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPara.Location = new System.Drawing.Point(53, 71);
            this.txtPara.MaxLength = 2000;
            this.txtPara.Multiline = true;
            this.txtPara.Name = "txtPara";
            this.txtPara.Size = new System.Drawing.Size(306, 33);
            this.txtPara.TabIndex = 5;
            this.txtPara.Enter += new System.EventHandler(this.txtPara_Enter);
            this.txtPara.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPara_KeyPress);
            this.txtPara.Leave += new System.EventHandler(this.txtPara_Leave);
            // 
            // lblAsterisco7
            // 
            this.lblAsterisco7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsterisco7.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco7.Location = new System.Drawing.Point(37, 19);
            this.lblAsterisco7.Name = "lblAsterisco7";
            this.lblAsterisco7.Size = new System.Drawing.Size(10, 10);
            this.lblAsterisco7.TabIndex = 0;
            this.lblAsterisco7.Text = "*";
            // 
            // cbbPorta
            // 
            this.cbbPorta.BackColor = System.Drawing.Color.LightBlue;
            this.cbbPorta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPorta.DropDownWidth = 65;
            this.cbbPorta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbbPorta.FormattingEnabled = true;
            this.cbbPorta.Items.AddRange(new object[] {
            "",
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.cbbPorta.Location = new System.Drawing.Point(53, 18);
            this.cbbPorta.Name = "cbbPorta";
            this.cbbPorta.Size = new System.Drawing.Size(65, 21);
            this.cbbPorta.TabIndex = 2;
            this.cbbPorta.DropDown += new System.EventHandler(this.cbbPorta_DropDown);
            this.cbbPorta.DropDownClosed += new System.EventHandler(this.cbbPorta_DropDownClosed);
            this.cbbPorta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbPorta_KeyPress);
            this.cbbPorta.MouseLeave += new System.EventHandler(this.cbbPorta_MouseLeave);
            this.cbbPorta.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbPorta_MouseMove);
            // 
            // lblPorta
            // 
            this.lblPorta.AutoSize = true;
            this.lblPorta.Location = new System.Drawing.Point(6, 22);
            this.lblPorta.Name = "lblPorta";
            this.lblPorta.Size = new System.Drawing.Size(35, 13);
            this.lblPorta.TabIndex = 0;
            this.lblPorta.Text = "Porta:";
            // 
            // txtMsg
            // 
            this.txtMsg.BackColor = System.Drawing.Color.White;
            this.txtMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsg.Location = new System.Drawing.Point(9, 154);
            this.txtMsg.MaxLength = 500;
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(410, 123);
            this.txtMsg.TabIndex = 9;
            this.txtMsg.TextChanged += new System.EventHandler(this.txtMsg_TextChanged);
            this.txtMsg.Enter += new System.EventHandler(this.txtMsg_Enter);
            this.txtMsg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMsg_KeyPress);
            this.txtMsg.Leave += new System.EventHandler(this.txtMsg_Leave);
            // 
            // FrmUtilEnviarSMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(442, 386);
            this.ControlBox = false;
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.btnSair);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUtilEnviarSMS";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar SMS";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUtilEnviarSMS_FormClosing);
            this.Load += new System.EventHandler(this.FrmUtilEnviarSMS_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmUtilEnviarSMS_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.Label lblQtdeCar;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox pcibInterrogacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip ttpSMS;
        private System.Windows.Forms.Label lblProgresso;
        private System.Windows.Forms.ProgressBar pgbProgresso;
        private System.ComponentModel.BackgroundWorker bckwIndeterminado;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAsterisco7;
        private System.Windows.Forms.ComboBox cbbPorta;
        private System.Windows.Forms.Label lblPorta;
        private System.Windows.Forms.TextBox txtPara;
        private System.Windows.Forms.Button btnFuncionario;
        private System.Windows.Forms.Button btnPesquisarForn;
        private System.Windows.Forms.Button btnProcurarCliente;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdicionarManual;
        private System.Windows.Forms.MaskedTextBox mtxtCelular;
    }
}