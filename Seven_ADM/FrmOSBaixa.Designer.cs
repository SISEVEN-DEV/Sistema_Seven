namespace Seven_Sistema
{
    partial class FrmOSBaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOSBaixa));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSair = new System.Windows.Forms.Button();
            this.pcibInterrogacao = new System.Windows.Forms.PictureBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.ttpBaixarOS = new System.Windows.Forms.ToolTip(this.components);
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.btnProcurarForma = new System.Windows.Forms.Button();
            this.btnSalvarPagamento = new System.Windows.Forms.Button();
            this.btnExcluirReg = new System.Windows.Forms.Button();
            this.lblDataConclusao = new System.Windows.Forms.Label();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.lblValorReal = new System.Windows.Forms.Label();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.grbBox3 = new System.Windows.Forms.GroupBox();
            this.lblValorDiferencaTroco = new System.Windows.Forms.Label();
            this.lblListaFormasPagamento = new System.Windows.Forms.Label();
            this.lblValorTotalPago = new System.Windows.Forms.Label();
            this.lblTotalPago = new System.Windows.Forms.Label();
            this.cbbFormaPagamento = new System.Windows.Forms.ComboBox();
            this.lblAsterisco2 = new System.Windows.Forms.Label();
            this.txtValorPagamento = new System.Windows.Forms.TextBox();
            this.dtFormaPagamento = new System.Windows.Forms.DataGridView();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.lblAsterisco3 = new System.Windows.Forms.Label();
            this.lblValorPago = new System.Windows.Forms.Label();
            this.lblDiferencaTroco = new System.Windows.Forms.Label();
            this.lblValorTotalPagar = new System.Windows.Forms.Label();
            this.mtxtDataConclusao = new System.Windows.Forms.MaskedTextBox();
            this.lblParcialPago = new System.Windows.Forms.Label();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.txtValorDesconto = new System.Windows.Forms.TextBox();
            this.lblAcrescimo = new System.Windows.Forms.Label();
            this.txtValorAcrescimo = new System.Windows.Forms.TextBox();
            this.mtxtHorarioConclusao = new System.Windows.Forms.MaskedTextBox();
            this.lblDescontoPorc = new System.Windows.Forms.Label();
            this.txtDescontoPorc = new System.Windows.Forms.TextBox();
            this.lblAcrescimoPorc = new System.Windows.Forms.Label();
            this.txtAcrescimoPorc = new System.Windows.Forms.TextBox();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblDataConclusaoPrev = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblValorDocumento = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblQtdeCarObs = new System.Windows.Forms.Label();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.lblValorAcrescimoItem = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblValorDescontoItem = new System.Windows.Forms.Label();
            this.lblValorCodigo = new System.Windows.Forms.Label();
            this.lblValorDataConclusaoPrev = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).BeginInit();
            this.grbBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFormaPagamento)).BeginInit();
            this.grbBox1.SuspendLayout();
            this.grbBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(642, 512);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 30;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixarOS.SetToolTip(this.btnSair, "Sair de Baixar Ordem de Serviço.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // pcibInterrogacao
            // 
            this.pcibInterrogacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibInterrogacao.Image = ((System.Drawing.Image)(resources.GetObject("pcibInterrogacao.Image")));
            this.pcibInterrogacao.Location = new System.Drawing.Point(530, 512);
            this.pcibInterrogacao.Name = "pcibInterrogacao";
            this.pcibInterrogacao.Size = new System.Drawing.Size(20, 20);
            this.pcibInterrogacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pcibInterrogacao.TabIndex = 118;
            this.pcibInterrogacao.TabStop = false;
            this.pcibInterrogacao.Click += new System.EventHandler(this.pcibInterrogacao_Click);
            this.pcibInterrogacao.MouseLeave += new System.EventHandler(this.pcibInterrogacao_MouseLeave);
            this.pcibInterrogacao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibInterrogacao_MouseMove);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Image = ((System.Drawing.Image)(resources.GetObject("btnFinalizar.Image")));
            this.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinalizar.Location = new System.Drawing.Point(556, 512);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(80, 32);
            this.btnFinalizar.TabIndex = 29;
            this.btnFinalizar.Text = "&Finalizar";
            this.btnFinalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixarOS.SetToolTip(this.btnFinalizar, "Clique para Finalizar a Ordem de Serviço.");
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            this.btnFinalizar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnFinalizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // ttpBaixarOS
            // 
            this.ttpBaixarOS.AutoPopDelay = 5000;
            this.ttpBaixarOS.InitialDelay = 1000;
            this.ttpBaixarOS.IsBalloon = true;
            this.ttpBaixarOS.ReshowDelay = 100;
            this.ttpBaixarOS.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpBaixarOS.ToolTipTitle = "Dica:";
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(309, 12);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 4;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixarOS.SetToolTip(this.btnSelecionarData, "Clique para selecionar uma data.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // btnProcurarForma
            // 
            this.btnProcurarForma.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarForma.Image")));
            this.btnProcurarForma.Location = new System.Drawing.Point(351, 11);
            this.btnProcurarForma.Name = "btnProcurarForma";
            this.btnProcurarForma.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarForma.TabIndex = 13;
            this.btnProcurarForma.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixarOS.SetToolTip(this.btnProcurarForma, "Clique para pesquisar uma Forma de Pagamento.");
            this.btnProcurarForma.UseVisualStyleBackColor = true;
            this.btnProcurarForma.Click += new System.EventHandler(this.btnProcurarForma_Click);
            this.btnProcurarForma.MouseLeave += new System.EventHandler(this.btnProcurarForma_MouseLeave);
            this.btnProcurarForma.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarForma_MouseMove);
            // 
            // btnSalvarPagamento
            // 
            this.btnSalvarPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarPagamento.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvarPagamento.Image")));
            this.btnSalvarPagamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvarPagamento.Location = new System.Drawing.Point(572, 10);
            this.btnSalvarPagamento.Name = "btnSalvarPagamento";
            this.btnSalvarPagamento.Size = new System.Drawing.Size(65, 25);
            this.btnSalvarPagamento.TabIndex = 15;
            this.btnSalvarPagamento.Text = "&Incluir";
            this.btnSalvarPagamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixarOS.SetToolTip(this.btnSalvarPagamento, "Incluir o dado da Forma de Pagamento informada.");
            this.btnSalvarPagamento.UseVisualStyleBackColor = true;
            this.btnSalvarPagamento.Click += new System.EventHandler(this.btnSalvarPagamento_Click);
            this.btnSalvarPagamento.MouseLeave += new System.EventHandler(this.btnSalvarPagamento_MouseLeave);
            this.btnSalvarPagamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvarPagamento_MouseMove);
            // 
            // btnExcluirReg
            // 
            this.btnExcluirReg.Enabled = false;
            this.btnExcluirReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirReg.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirReg.Image")));
            this.btnExcluirReg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluirReg.Location = new System.Drawing.Point(528, 186);
            this.btnExcluirReg.Name = "btnExcluirReg";
            this.btnExcluirReg.Size = new System.Drawing.Size(107, 25);
            this.btnExcluirReg.TabIndex = 17;
            this.btnExcluirReg.Text = "&Excluir Registro";
            this.btnExcluirReg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpBaixarOS.SetToolTip(this.btnExcluirReg, "Excluir uma Forma de Pagamento informada.");
            this.btnExcluirReg.UseVisualStyleBackColor = true;
            this.btnExcluirReg.Click += new System.EventHandler(this.btnExcluirReg_Click);
            this.btnExcluirReg.MouseLeave += new System.EventHandler(this.btnExcluirReg_MouseLeave);
            this.btnExcluirReg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluirReg_MouseMove);
            // 
            // lblDataConclusao
            // 
            this.lblDataConclusao.AutoSize = true;
            this.lblDataConclusao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataConclusao.Location = new System.Drawing.Point(6, 18);
            this.lblDataConclusao.Name = "lblDataConclusao";
            this.lblDataConclusao.Size = new System.Drawing.Size(147, 13);
            this.lblDataConclusao.TabIndex = 0;
            this.lblDataConclusao.Text = "Data e Horário de Conclusão:";
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(148, 15);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // lblValorReal
            // 
            this.lblValorReal.AutoSize = true;
            this.lblValorReal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorReal.ForeColor = System.Drawing.Color.Black;
            this.lblValorReal.Location = new System.Drawing.Point(532, 166);
            this.lblValorReal.Name = "lblValorReal";
            this.lblValorReal.Size = new System.Drawing.Size(116, 13);
            this.lblValorReal.TabIndex = 0;
            this.lblValorReal.Text = "Total a Pagar (R$):";
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesconto.ForeColor = System.Drawing.Color.Black;
            this.lblDesconto.Location = new System.Drawing.Point(177, 166);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(105, 13);
            this.lblDesconto.TabIndex = 0;
            this.lblDesconto.Text = "Desconto -  (R$):";
            // 
            // grbBox3
            // 
            this.grbBox3.Controls.Add(this.lblValorDiferencaTroco);
            this.grbBox3.Controls.Add(this.lblListaFormasPagamento);
            this.grbBox3.Controls.Add(this.lblValorTotalPago);
            this.grbBox3.Controls.Add(this.lblTotalPago);
            this.grbBox3.Controls.Add(this.cbbFormaPagamento);
            this.grbBox3.Controls.Add(this.lblAsterisco2);
            this.grbBox3.Controls.Add(this.btnExcluirReg);
            this.grbBox3.Controls.Add(this.btnSalvarPagamento);
            this.grbBox3.Controls.Add(this.txtValorPagamento);
            this.grbBox3.Controls.Add(this.dtFormaPagamento);
            this.grbBox3.Controls.Add(this.lblFormaPagamento);
            this.grbBox3.Controls.Add(this.btnProcurarForma);
            this.grbBox3.Controls.Add(this.lblAsterisco3);
            this.grbBox3.Controls.Add(this.lblValorPago);
            this.grbBox3.Controls.Add(this.lblDiferencaTroco);
            this.grbBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox3.Location = new System.Drawing.Point(6, 208);
            this.grbBox3.Name = "grbBox3";
            this.grbBox3.Size = new System.Drawing.Size(642, 215);
            this.grbBox3.TabIndex = 11;
            this.grbBox3.TabStop = false;
            this.grbBox3.Text = "Pagamento:";
            // 
            // lblValorDiferencaTroco
            // 
            this.lblValorDiferencaTroco.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDiferencaTroco.BackColor = System.Drawing.Color.White;
            this.lblValorDiferencaTroco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDiferencaTroco.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDiferencaTroco.ForeColor = System.Drawing.Color.Black;
            this.lblValorDiferencaTroco.Location = new System.Drawing.Point(368, 183);
            this.lblValorDiferencaTroco.Name = "lblValorDiferencaTroco";
            this.lblValorDiferencaTroco.Size = new System.Drawing.Size(97, 26);
            this.lblValorDiferencaTroco.TabIndex = 0;
            this.lblValorDiferencaTroco.Text = "0,00";
            this.lblValorDiferencaTroco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorDiferencaTroco.Click += new System.EventHandler(this.lblValorDiferencaTroco_Click);
            this.lblValorDiferencaTroco.MouseLeave += new System.EventHandler(this.lblValorDiferencaTroco_MouseLeave);
            this.lblValorDiferencaTroco.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorDiferencaTroco_MouseMove);
            // 
            // lblListaFormasPagamento
            // 
            this.lblListaFormasPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaFormasPagamento.Location = new System.Drawing.Point(6, 38);
            this.lblListaFormasPagamento.Name = "lblListaFormasPagamento";
            this.lblListaFormasPagamento.Size = new System.Drawing.Size(629, 13);
            this.lblListaFormasPagamento.TabIndex = 0;
            this.lblListaFormasPagamento.Text = "Pagamentos:";
            this.lblListaFormasPagamento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValorTotalPago
            // 
            this.lblValorTotalPago.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorTotalPago.BackColor = System.Drawing.Color.White;
            this.lblValorTotalPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotalPago.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotalPago.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotalPago.Location = new System.Drawing.Point(122, 183);
            this.lblValorTotalPago.Name = "lblValorTotalPago";
            this.lblValorTotalPago.Size = new System.Drawing.Size(97, 26);
            this.lblValorTotalPago.TabIndex = 0;
            this.lblValorTotalPago.Text = "0,00";
            this.lblValorTotalPago.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotalPago.Click += new System.EventHandler(this.lblValorTotalPago_Click);
            this.lblValorTotalPago.MouseLeave += new System.EventHandler(this.lblValorTotalPago_MouseLeave);
            this.lblValorTotalPago.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotalPago_MouseMove);
            // 
            // lblTotalPago
            // 
            this.lblTotalPago.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotalPago.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPago.ForeColor = System.Drawing.Color.Black;
            this.lblTotalPago.Location = new System.Drawing.Point(3, 183);
            this.lblTotalPago.Name = "lblTotalPago";
            this.lblTotalPago.Size = new System.Drawing.Size(132, 26);
            this.lblTotalPago.TabIndex = 0;
            this.lblTotalPago.Text = "Total Pago (R$):";
            this.lblTotalPago.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbbFormaPagamento
            // 
            this.cbbFormaPagamento.BackColor = System.Drawing.Color.LightBlue;
            this.cbbFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFormaPagamento.DropDownWidth = 350;
            this.cbbFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbFormaPagamento.FormattingEnabled = true;
            this.cbbFormaPagamento.Location = new System.Drawing.Point(130, 13);
            this.cbbFormaPagamento.Name = "cbbFormaPagamento";
            this.cbbFormaPagamento.Size = new System.Drawing.Size(215, 21);
            this.cbbFormaPagamento.TabIndex = 12;
            this.cbbFormaPagamento.DropDown += new System.EventHandler(this.cbbFormaPagamento_DropDown);
            this.cbbFormaPagamento.DropDownClosed += new System.EventHandler(this.cbbFormaPagamento_DropDownClosed);
            this.cbbFormaPagamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbFormaPagamento_KeyPress);
            this.cbbFormaPagamento.MouseLeave += new System.EventHandler(this.cbbFormaPagamento_MouseLeave);
            this.cbbFormaPagamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbFormaPagamento_MouseMove);
            // 
            // lblAsterisco2
            // 
            this.lblAsterisco2.AutoSize = true;
            this.lblAsterisco2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco2.Location = new System.Drawing.Point(117, 13);
            this.lblAsterisco2.Name = "lblAsterisco2";
            this.lblAsterisco2.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco2.TabIndex = 0;
            this.lblAsterisco2.Text = "*";
            // 
            // txtValorPagamento
            // 
            this.txtValorPagamento.BackColor = System.Drawing.Color.White;
            this.txtValorPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorPagamento.Location = new System.Drawing.Point(474, 13);
            this.txtValorPagamento.MaxLength = 15;
            this.txtValorPagamento.Name = "txtValorPagamento";
            this.txtValorPagamento.Size = new System.Drawing.Size(92, 20);
            this.txtValorPagamento.TabIndex = 14;
            this.txtValorPagamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorPagamento.DoubleClick += new System.EventHandler(this.txtValorPagamento_DoubleClick);
            this.txtValorPagamento.Enter += new System.EventHandler(this.txtValorPagamento_Enter);
            this.txtValorPagamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorPagamento_KeyPress);
            this.txtValorPagamento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtValorPagamento_KeyUp);
            this.txtValorPagamento.Leave += new System.EventHandler(this.txtValorPagamento_Leave);
            // 
            // dtFormaPagamento
            // 
            this.dtFormaPagamento.AllowUserToAddRows = false;
            this.dtFormaPagamento.AllowUserToDeleteRows = false;
            this.dtFormaPagamento.AllowUserToResizeRows = false;
            this.dtFormaPagamento.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtFormaPagamento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtFormaPagamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtFormaPagamento.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtFormaPagamento.Enabled = false;
            this.dtFormaPagamento.Location = new System.Drawing.Point(6, 52);
            this.dtFormaPagamento.MultiSelect = false;
            this.dtFormaPagamento.Name = "dtFormaPagamento";
            this.dtFormaPagamento.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtFormaPagamento.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtFormaPagamento.RowHeadersVisible = false;
            this.dtFormaPagamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtFormaPagamento.ShowCellErrors = false;
            this.dtFormaPagamento.ShowCellToolTips = false;
            this.dtFormaPagamento.ShowEditingIcon = false;
            this.dtFormaPagamento.ShowRowErrors = false;
            this.dtFormaPagamento.Size = new System.Drawing.Size(628, 128);
            this.dtFormaPagamento.TabIndex = 16;
            this.dtFormaPagamento.DataSourceChanged += new System.EventHandler(this.dtFormaPagamento_DataSourceChanged);
            this.dtFormaPagamento.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtFormaPagamento_CellEnter);
            this.dtFormaPagamento.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtFormaPagamento_CellFormatting);
            this.dtFormaPagamento.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dtFormaPagamento_RowsAdded);
            this.dtFormaPagamento.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dtFormaPagamento_RowsRemoved);
            this.dtFormaPagamento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtFormaPagamento_KeyUp);
            this.dtFormaPagamento.MouseLeave += new System.EventHandler(this.dtFormaPagamento_MouseLeave);
            this.dtFormaPagamento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtFormaPagamento_MouseMove);
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormaPagamento.Location = new System.Drawing.Point(11, 16);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(111, 13);
            this.lblFormaPagamento.TabIndex = 0;
            this.lblFormaPagamento.Text = "Forma de Pagamento:";
            // 
            // lblAsterisco3
            // 
            this.lblAsterisco3.AutoSize = true;
            this.lblAsterisco3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco3.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco3.Location = new System.Drawing.Point(460, 13);
            this.lblAsterisco3.Name = "lblAsterisco3";
            this.lblAsterisco3.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco3.TabIndex = 0;
            this.lblAsterisco3.Text = "*";
            // 
            // lblValorPago
            // 
            this.lblValorPago.AutoSize = true;
            this.lblValorPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorPago.Location = new System.Drawing.Point(380, 16);
            this.lblValorPago.Name = "lblValorPago";
            this.lblValorPago.Size = new System.Drawing.Size(85, 13);
            this.lblValorPago.TabIndex = 0;
            this.lblValorPago.Text = "Valor Pago (R$):";
            // 
            // lblDiferencaTroco
            // 
            this.lblDiferencaTroco.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDiferencaTroco.BackColor = System.Drawing.Color.Transparent;
            this.lblDiferencaTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiferencaTroco.ForeColor = System.Drawing.Color.Red;
            this.lblDiferencaTroco.Location = new System.Drawing.Point(245, 183);
            this.lblDiferencaTroco.Name = "lblDiferencaTroco";
            this.lblDiferencaTroco.Size = new System.Drawing.Size(129, 26);
            this.lblDiferencaTroco.TabIndex = 0;
            this.lblDiferencaTroco.Text = "Diferença (R$):";
            this.lblDiferencaTroco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValorTotalPagar
            // 
            this.lblValorTotalPagar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorTotalPagar.BackColor = System.Drawing.Color.White;
            this.lblValorTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblValorTotalPagar.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotalPagar.Location = new System.Drawing.Point(535, 180);
            this.lblValorTotalPagar.Name = "lblValorTotalPagar";
            this.lblValorTotalPagar.Size = new System.Drawing.Size(105, 26);
            this.lblValorTotalPagar.TabIndex = 0;
            this.lblValorTotalPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotalPagar.Click += new System.EventHandler(this.lblValorTotalPagar_Click);
            this.lblValorTotalPagar.MouseLeave += new System.EventHandler(this.lblValorTotalPagar_MouseLeave);
            this.lblValorTotalPagar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotalPagar_MouseMove);
            // 
            // mtxtDataConclusao
            // 
            this.mtxtDataConclusao.BackColor = System.Drawing.Color.White;
            this.mtxtDataConclusao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtDataConclusao.Location = new System.Drawing.Point(162, 15);
            this.mtxtDataConclusao.Mask = "00/00/0000";
            this.mtxtDataConclusao.Name = "mtxtDataConclusao";
            this.mtxtDataConclusao.Size = new System.Drawing.Size(78, 20);
            this.mtxtDataConclusao.TabIndex = 2;
            this.mtxtDataConclusao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtDataConclusao.ValidatingType = typeof(System.DateTime);
            this.mtxtDataConclusao.DoubleClick += new System.EventHandler(this.mtxtDataConclusao_DoubleClick);
            this.mtxtDataConclusao.Enter += new System.EventHandler(this.mtxtDataConclusao_Enter);
            this.mtxtDataConclusao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtDataConclusao_KeyPress);
            this.mtxtDataConclusao.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtDataConclusao_KeyUp);
            this.mtxtDataConclusao.Leave += new System.EventHandler(this.mtxtDataConclusao_Leave);
            // 
            // lblParcialPago
            // 
            this.lblParcialPago.AutoSize = true;
            this.lblParcialPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParcialPago.ForeColor = System.Drawing.Color.Black;
            this.lblParcialPago.Location = new System.Drawing.Point(533, 124);
            this.lblParcialPago.Name = "lblParcialPago";
            this.lblParcialPago.Size = new System.Drawing.Size(68, 13);
            this.lblParcialPago.TabIndex = 0;
            this.lblParcialPago.Text = "Total (R$):";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorTotal.BackColor = System.Drawing.Color.White;
            this.lblValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblValorTotal.ForeColor = System.Drawing.Color.Black;
            this.lblValorTotal.Location = new System.Drawing.Point(535, 137);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(105, 26);
            this.lblValorTotal.TabIndex = 0;
            this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorTotal.Click += new System.EventHandler(this.lblValorTotal_Click);
            this.lblValorTotal.MouseLeave += new System.EventHandler(this.lblValorTotal_MouseLeave);
            this.lblValorTotal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorTotal_MouseMove);
            // 
            // txtValorDesconto
            // 
            this.txtValorDesconto.BackColor = System.Drawing.Color.White;
            this.txtValorDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold);
            this.txtValorDesconto.Location = new System.Drawing.Point(180, 180);
            this.txtValorDesconto.MaxLength = 15;
            this.txtValorDesconto.Name = "txtValorDesconto";
            this.txtValorDesconto.Size = new System.Drawing.Size(105, 27);
            this.txtValorDesconto.TabIndex = 6;
            this.txtValorDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorDesconto.Enter += new System.EventHandler(this.txtValorDesconto_Enter);
            this.txtValorDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorDesconto_KeyPress);
            this.txtValorDesconto.Leave += new System.EventHandler(this.txtValorDesconto_Leave);
            // 
            // lblAcrescimo
            // 
            this.lblAcrescimo.AutoSize = true;
            this.lblAcrescimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcrescimo.ForeColor = System.Drawing.Color.Black;
            this.lblAcrescimo.Location = new System.Drawing.Point(371, 166);
            this.lblAcrescimo.Name = "lblAcrescimo";
            this.lblAcrescimo.Size = new System.Drawing.Size(108, 13);
            this.lblAcrescimo.TabIndex = 0;
            this.lblAcrescimo.Text = "Acréscimo + (R$):";
            // 
            // txtValorAcrescimo
            // 
            this.txtValorAcrescimo.BackColor = System.Drawing.Color.White;
            this.txtValorAcrescimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold);
            this.txtValorAcrescimo.Location = new System.Drawing.Point(374, 180);
            this.txtValorAcrescimo.MaxLength = 15;
            this.txtValorAcrescimo.Name = "txtValorAcrescimo";
            this.txtValorAcrescimo.Size = new System.Drawing.Size(105, 27);
            this.txtValorAcrescimo.TabIndex = 8;
            this.txtValorAcrescimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorAcrescimo.Enter += new System.EventHandler(this.txtValorAcrescimo_Enter);
            this.txtValorAcrescimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorAcrescimo_KeyPress);
            this.txtValorAcrescimo.Leave += new System.EventHandler(this.txtValorAcrescimo_Leave);
            // 
            // mtxtHorarioConclusao
            // 
            this.mtxtHorarioConclusao.BackColor = System.Drawing.Color.White;
            this.mtxtHorarioConclusao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorarioConclusao.Location = new System.Drawing.Point(246, 15);
            this.mtxtHorarioConclusao.Mask = "00:00:00";
            this.mtxtHorarioConclusao.Name = "mtxtHorarioConclusao";
            this.mtxtHorarioConclusao.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorarioConclusao.TabIndex = 3;
            this.mtxtHorarioConclusao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtHorarioConclusao.DoubleClick += new System.EventHandler(this.mtxtHorarioConclusao_DoubleClick);
            this.mtxtHorarioConclusao.Enter += new System.EventHandler(this.mtxtHorarioConclusao_Enter);
            this.mtxtHorarioConclusao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHorarioConclusao_KeyPress);
            this.mtxtHorarioConclusao.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHorarioConclusao_KeyUp);
            this.mtxtHorarioConclusao.Leave += new System.EventHandler(this.mtxtHorarioConclusao_Leave);
            // 
            // lblDescontoPorc
            // 
            this.lblDescontoPorc.AutoSize = true;
            this.lblDescontoPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescontoPorc.ForeColor = System.Drawing.Color.Black;
            this.lblDescontoPorc.Location = new System.Drawing.Point(177, 124);
            this.lblDescontoPorc.Name = "lblDescontoPorc";
            this.lblDescontoPorc.Size = new System.Drawing.Size(98, 13);
            this.lblDescontoPorc.TabIndex = 0;
            this.lblDescontoPorc.Text = "Desconto -  (%):";
            // 
            // txtDescontoPorc
            // 
            this.txtDescontoPorc.BackColor = System.Drawing.Color.White;
            this.txtDescontoPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescontoPorc.Location = new System.Drawing.Point(180, 137);
            this.txtDescontoPorc.MaxLength = 6;
            this.txtDescontoPorc.Name = "txtDescontoPorc";
            this.txtDescontoPorc.Size = new System.Drawing.Size(105, 27);
            this.txtDescontoPorc.TabIndex = 7;
            this.txtDescontoPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescontoPorc.Enter += new System.EventHandler(this.txtDescontoPorc_Enter);
            this.txtDescontoPorc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            this.txtDescontoPorc.Leave += new System.EventHandler(this.txtDescontoPorc_Leave);
            // 
            // lblAcrescimoPorc
            // 
            this.lblAcrescimoPorc.AutoSize = true;
            this.lblAcrescimoPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcrescimoPorc.ForeColor = System.Drawing.Color.Black;
            this.lblAcrescimoPorc.Location = new System.Drawing.Point(371, 124);
            this.lblAcrescimoPorc.Name = "lblAcrescimoPorc";
            this.lblAcrescimoPorc.Size = new System.Drawing.Size(101, 13);
            this.lblAcrescimoPorc.TabIndex = 0;
            this.lblAcrescimoPorc.Text = "Acréscimo + (%):";
            // 
            // txtAcrescimoPorc
            // 
            this.txtAcrescimoPorc.BackColor = System.Drawing.Color.White;
            this.txtAcrescimoPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold);
            this.txtAcrescimoPorc.Location = new System.Drawing.Point(374, 137);
            this.txtAcrescimoPorc.MaxLength = 6;
            this.txtAcrescimoPorc.Name = "txtAcrescimoPorc";
            this.txtAcrescimoPorc.Size = new System.Drawing.Size(105, 27);
            this.txtAcrescimoPorc.TabIndex = 9;
            this.txtAcrescimoPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAcrescimoPorc.Enter += new System.EventHandler(this.txtAcrescimoPorc_Enter);
            this.txtAcrescimoPorc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAcrescimoPorc_KeyPress);
            this.txtAcrescimoPorc.Leave += new System.EventHandler(this.txtAcrescimoPorc_Leave);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblDataConclusaoPrev);
            this.grbBox1.Controls.Add(this.lblValor);
            this.grbBox1.Controls.Add(this.lblValorDocumento);
            this.grbBox1.Controls.Add(this.lblCodigo);
            this.grbBox1.Controls.Add(this.grbBox2);
            this.grbBox1.Controls.Add(this.lblValorCodigo);
            this.grbBox1.Controls.Add(this.lblValorDataConclusaoPrev);
            this.grbBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(685, 494);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Informações da Ordem de Serviço:";
            // 
            // lblDataConclusaoPrev
            // 
            this.lblDataConclusaoPrev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDataConclusaoPrev.BackColor = System.Drawing.Color.Transparent;
            this.lblDataConclusaoPrev.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataConclusaoPrev.ForeColor = System.Drawing.Color.Black;
            this.lblDataConclusaoPrev.Location = new System.Drawing.Point(147, 15);
            this.lblDataConclusaoPrev.Name = "lblDataConclusaoPrev";
            this.lblDataConclusaoPrev.Size = new System.Drawing.Size(116, 26);
            this.lblDataConclusaoPrev.TabIndex = 0;
            this.lblDataConclusaoPrev.Text = "Conclusão Prevista:";
            this.lblDataConclusaoPrev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.Color.Black;
            this.lblValor.Location = new System.Drawing.Point(468, 22);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(107, 15);
            this.lblValor.TabIndex = 0;
            this.lblValor.Text = "Valor da O.S.  (R$):";
            // 
            // lblValorDocumento
            // 
            this.lblValorDocumento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDocumento.BackColor = System.Drawing.Color.White;
            this.lblValorDocumento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDocumento.ForeColor = System.Drawing.Color.Black;
            this.lblValorDocumento.Location = new System.Drawing.Point(578, 19);
            this.lblValorDocumento.Name = "lblValorDocumento";
            this.lblValorDocumento.Size = new System.Drawing.Size(101, 22);
            this.lblValorDocumento.TabIndex = 0;
            this.lblValorDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorDocumento.Click += new System.EventHandler(this.lblValorDocumento_Click);
            this.lblValorDocumento.MouseLeave += new System.EventHandler(this.lblValorDocumento_MouseLeave);
            this.lblValorDocumento.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorDocumento_MouseMove);
            // 
            // lblCodigo
            // 
            this.lblCodigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCodigo.BackColor = System.Drawing.Color.Transparent;
            this.lblCodigo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.Black;
            this.lblCodigo.Location = new System.Drawing.Point(8, 15);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(48, 26);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.label4);
            this.grbBox2.Controls.Add(this.lblQtdeCarObs);
            this.grbBox2.Controls.Add(this.lblObservacao);
            this.grbBox2.Controls.Add(this.lblValorAcrescimoItem);
            this.grbBox2.Controls.Add(this.txtObservacao);
            this.grbBox2.Controls.Add(this.mtxtHorarioConclusao);
            this.grbBox2.Controls.Add(this.label7);
            this.grbBox2.Controls.Add(this.lblValorDescontoItem);
            this.grbBox2.Controls.Add(this.mtxtDataConclusao);
            this.grbBox2.Controls.Add(this.btnSelecionarData);
            this.grbBox2.Controls.Add(this.lblDesconto);
            this.grbBox2.Controls.Add(this.lblAsterisco1);
            this.grbBox2.Controls.Add(this.lblDataConclusao);
            this.grbBox2.Controls.Add(this.txtAcrescimoPorc);
            this.grbBox2.Controls.Add(this.lblDescontoPorc);
            this.grbBox2.Controls.Add(this.lblAcrescimo);
            this.grbBox2.Controls.Add(this.lblValorTotalPagar);
            this.grbBox2.Controls.Add(this.lblValorReal);
            this.grbBox2.Controls.Add(this.lblParcialPago);
            this.grbBox2.Controls.Add(this.txtValorDesconto);
            this.grbBox2.Controls.Add(this.txtDescontoPorc);
            this.grbBox2.Controls.Add(this.lblAcrescimoPorc);
            this.grbBox2.Controls.Add(this.lblValorTotal);
            this.grbBox2.Controls.Add(this.txtValorAcrescimo);
            this.grbBox2.Controls.Add(this.grbBox3);
            this.grbBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbBox2.Location = new System.Drawing.Point(8, 54);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(662, 431);
            this.grbBox2.TabIndex = 3;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Informações de Pagamento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(3, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Acréscimo Item (R$):";
            // 
            // lblQtdeCarObs
            // 
            this.lblQtdeCarObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdeCarObs.Location = new System.Drawing.Point(456, 100);
            this.lblQtdeCarObs.Name = "lblQtdeCarObs";
            this.lblQtdeCarObs.Size = new System.Drawing.Size(183, 13);
            this.lblQtdeCarObs.TabIndex = 28;
            this.lblQtdeCarObs.Text = "Max. de Caracteres: 0/250";
            this.lblQtdeCarObs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblObservacao
            // 
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblObservacao.Location = new System.Drawing.Point(6, 36);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(128, 13);
            this.lblObservacao.TabIndex = 26;
            this.lblObservacao.Text = "Observações/Conclusão:";
            // 
            // lblValorAcrescimoItem
            // 
            this.lblValorAcrescimoItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorAcrescimoItem.BackColor = System.Drawing.Color.White;
            this.lblValorAcrescimoItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorAcrescimoItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblValorAcrescimoItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblValorAcrescimoItem.ForeColor = System.Drawing.Color.Black;
            this.lblValorAcrescimoItem.Location = new System.Drawing.Point(6, 180);
            this.lblValorAcrescimoItem.Name = "lblValorAcrescimoItem";
            this.lblValorAcrescimoItem.Size = new System.Drawing.Size(105, 26);
            this.lblValorAcrescimoItem.TabIndex = 13;
            this.lblValorAcrescimoItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorAcrescimoItem.Click += new System.EventHandler(this.lblValorAcrescimoItem_Click);
            // 
            // txtObservacao
            // 
            this.txtObservacao.BackColor = System.Drawing.Color.White;
            this.txtObservacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtObservacao.Location = new System.Drawing.Point(6, 52);
            this.txtObservacao.MaxLength = 300;
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(634, 45);
            this.txtObservacao.TabIndex = 5;
            this.txtObservacao.TextChanged += new System.EventHandler(this.txtObservacao_TextChanged);
            this.txtObservacao.Enter += new System.EventHandler(this.txtObservacao_Enter);
            this.txtObservacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObservacao_KeyPress_1);
            this.txtObservacao.Leave += new System.EventHandler(this.txtObservacao_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(3, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Desconto Item (R$):";
            // 
            // lblValorDescontoItem
            // 
            this.lblValorDescontoItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDescontoItem.BackColor = System.Drawing.Color.White;
            this.lblValorDescontoItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDescontoItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblValorDescontoItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDescontoItem.ForeColor = System.Drawing.Color.Black;
            this.lblValorDescontoItem.Location = new System.Drawing.Point(6, 137);
            this.lblValorDescontoItem.Name = "lblValorDescontoItem";
            this.lblValorDescontoItem.Size = new System.Drawing.Size(105, 26);
            this.lblValorDescontoItem.TabIndex = 15;
            this.lblValorDescontoItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorDescontoItem.Click += new System.EventHandler(this.lblValorDescontoItem_Click);
            // 
            // lblValorCodigo
            // 
            this.lblValorCodigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorCodigo.BackColor = System.Drawing.Color.White;
            this.lblValorCodigo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorCodigo.ForeColor = System.Drawing.Color.Black;
            this.lblValorCodigo.Location = new System.Drawing.Point(62, 18);
            this.lblValorCodigo.Name = "lblValorCodigo";
            this.lblValorCodigo.Size = new System.Drawing.Size(81, 22);
            this.lblValorCodigo.TabIndex = 0;
            this.lblValorCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblValorCodigo.Click += new System.EventHandler(this.lblValorCodigo_Click);
            this.lblValorCodigo.MouseLeave += new System.EventHandler(this.lblValorCodigo_MouseLeave);
            this.lblValorCodigo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorCodigo_MouseMove);
            // 
            // lblValorDataConclusaoPrev
            // 
            this.lblValorDataConclusaoPrev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblValorDataConclusaoPrev.BackColor = System.Drawing.Color.White;
            this.lblValorDataConclusaoPrev.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblValorDataConclusaoPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorDataConclusaoPrev.ForeColor = System.Drawing.Color.Black;
            this.lblValorDataConclusaoPrev.Location = new System.Drawing.Point(262, 18);
            this.lblValorDataConclusaoPrev.Name = "lblValorDataConclusaoPrev";
            this.lblValorDataConclusaoPrev.Size = new System.Drawing.Size(200, 22);
            this.lblValorDataConclusaoPrev.TabIndex = 0;
            this.lblValorDataConclusaoPrev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblValorDataConclusaoPrev.Click += new System.EventHandler(this.lblValorDataVencimento_Click);
            this.lblValorDataConclusaoPrev.MouseLeave += new System.EventHandler(this.lblValorDataVencimento_MouseLeave);
            this.lblValorDataConclusaoPrev.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblValorDataVencimento_MouseMove);
            // 
            // FrmOSBaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(710, 551);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.pcibInterrogacao);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.grbBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOSBaixa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baixar Ordem de Serviço";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOSBaixa_FormClosing);
            this.Load += new System.EventHandler(this.FrmOSBaixa_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmOSBaixa_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pcibInterrogacao)).EndInit();
            this.grbBox3.ResumeLayout(false);
            this.grbBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFormaPagamento)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox pcibInterrogacao;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.ToolTip ttpBaixarOS;
        private System.Windows.Forms.TextBox txtAcrescimoPorc;
        private System.Windows.Forms.Label lblAcrescimoPorc;
        private System.Windows.Forms.TextBox txtDescontoPorc;
        private System.Windows.Forms.Label lblDescontoPorc;
        private System.Windows.Forms.MaskedTextBox mtxtHorarioConclusao;
        private System.Windows.Forms.TextBox txtValorAcrescimo;
        private System.Windows.Forms.Label lblAcrescimo;
        private System.Windows.Forms.TextBox txtValorDesconto;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.Label lblParcialPago;
        private System.Windows.Forms.MaskedTextBox mtxtDataConclusao;
        private System.Windows.Forms.Label lblValorTotalPagar;
        private System.Windows.Forms.GroupBox grbBox3;
        private System.Windows.Forms.Label lblValorDiferencaTroco;
        private System.Windows.Forms.Label lblListaFormasPagamento;
        private System.Windows.Forms.Label lblValorTotalPago;
        private System.Windows.Forms.Label lblTotalPago;
        private System.Windows.Forms.ComboBox cbbFormaPagamento;
        private System.Windows.Forms.Label lblAsterisco2;
        private System.Windows.Forms.Button btnExcluirReg;
        private System.Windows.Forms.Button btnSalvarPagamento;
        private System.Windows.Forms.TextBox txtValorPagamento;
        private System.Windows.Forms.DataGridView dtFormaPagamento;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.Button btnProcurarForma;
        private System.Windows.Forms.Label lblDiferencaTroco;
        private System.Windows.Forms.Label lblAsterisco3;
        private System.Windows.Forms.Label lblValorPago;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.Label lblValorReal;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.Label lblDataConclusao;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblValorCodigo;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Label lblValorDocumento;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblValorDataConclusaoPrev;
        private System.Windows.Forms.Label lblDataConclusaoPrev;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label lblQtdeCarObs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblValorAcrescimoItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblValorDescontoItem;
    }
}