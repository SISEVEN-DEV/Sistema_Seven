namespace Seven_Sistema
{
    partial class FrmUtilCadLembrete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUtilCadLembrete));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnDesmarcar = new System.Windows.Forms.Button();
            this.btnSelecionarData3 = new System.Windows.Forms.Button();
            this.btnMarcar = new System.Windows.Forms.Button();
            this.mtxtDataVencimento = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lviewUsuarios = new System.Windows.Forms.ListView();
            this.lblAsterisco4 = new System.Windows.Forms.Label();
            this.lblAsterisco5 = new System.Windows.Forms.Label();
            this.lblAsterisco3 = new System.Windows.Forms.Label();
            this.lblAsterisco2 = new System.Windows.Forms.Label();
            this.lblAlarmeUsuario = new System.Windows.Forms.Label();
            this.btnOuvir = new System.Windows.Forms.Button();
            this.lblAsterisco1 = new System.Windows.Forms.Label();
            this.lblSomAlarme = new System.Windows.Forms.Label();
            this.mtxtHora = new System.Windows.Forms.MaskedTextBox();
            this.cbbSomAlarme = new System.Windows.Forms.ComboBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblObservacoes = new System.Windows.Forms.Label();
            this.rtxtObservacoes = new System.Windows.Forms.RichTextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.ttpLembrete = new System.Windows.Forms.ToolTip(this.components);
            this.btnSair = new System.Windows.Forms.Button();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.txtCodigo);
            this.grbBox1.Controls.Add(this.btnDesmarcar);
            this.grbBox1.Controls.Add(this.btnSelecionarData3);
            this.grbBox1.Controls.Add(this.btnMarcar);
            this.grbBox1.Controls.Add(this.mtxtDataVencimento);
            this.grbBox1.Controls.Add(this.label1);
            this.grbBox1.Controls.Add(this.lviewUsuarios);
            this.grbBox1.Controls.Add(this.lblAsterisco4);
            this.grbBox1.Controls.Add(this.lblAsterisco5);
            this.grbBox1.Controls.Add(this.lblAsterisco3);
            this.grbBox1.Controls.Add(this.lblAsterisco2);
            this.grbBox1.Controls.Add(this.lblAlarmeUsuario);
            this.grbBox1.Controls.Add(this.btnOuvir);
            this.grbBox1.Controls.Add(this.lblAsterisco1);
            this.grbBox1.Controls.Add(this.lblSomAlarme);
            this.grbBox1.Controls.Add(this.mtxtHora);
            this.grbBox1.Controls.Add(this.cbbSomAlarme);
            this.grbBox1.Controls.Add(this.lblHora);
            this.grbBox1.Controls.Add(this.lblObservacoes);
            this.grbBox1.Controls.Add(this.rtxtObservacoes);
            this.grbBox1.Controls.Add(this.txtDescricao);
            this.grbBox1.Controls.Add(this.lblDescricao);
            this.grbBox1.Controls.Add(this.lblData);
            this.grbBox1.Controls.Add(this.lblCodigo);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(525, 332);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Lembrete:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(6, 32);
            this.txtCodigo.MaxLength = 10;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCodigo.Size = new System.Drawing.Size(78, 20);
            this.txtCodigo.TabIndex = 2;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // btnDesmarcar
            // 
            this.btnDesmarcar.Image = ((System.Drawing.Image)(resources.GetObject("btnDesmarcar.Image")));
            this.btnDesmarcar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDesmarcar.Location = new System.Drawing.Point(393, 302);
            this.btnDesmarcar.Name = "btnDesmarcar";
            this.btnDesmarcar.Size = new System.Drawing.Size(118, 25);
            this.btnDesmarcar.TabIndex = 12;
            this.btnDesmarcar.Text = "&Desmarcar Todos";
            this.btnDesmarcar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnDesmarcar, "Clique para desmarcar todos os itens.");
            this.btnDesmarcar.UseVisualStyleBackColor = true;
            this.btnDesmarcar.Click += new System.EventHandler(this.button1_Click);
            this.btnDesmarcar.MouseLeave += new System.EventHandler(this.btnDesmarcar_MouseLeave);
            this.btnDesmarcar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDesmarcar_MouseMove);
            // 
            // btnSelecionarData3
            // 
            this.btnSelecionarData3.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData3.Image")));
            this.btnSelecionarData3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData3.Location = new System.Drawing.Point(174, 29);
            this.btnSelecionarData3.Name = "btnSelecionarData3";
            this.btnSelecionarData3.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData3.TabIndex = 4;
            this.btnSelecionarData3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnSelecionarData3, "Clique para selecionar uma data.");
            this.btnSelecionarData3.UseVisualStyleBackColor = true;
            this.btnSelecionarData3.Click += new System.EventHandler(this.btnSelecionarData3_Click);
            this.btnSelecionarData3.MouseLeave += new System.EventHandler(this.btnSelecionarData3_MouseLeave);
            this.btnSelecionarData3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData3_MouseMove);
            // 
            // btnMarcar
            // 
            this.btnMarcar.Image = ((System.Drawing.Image)(resources.GetObject("btnMarcar.Image")));
            this.btnMarcar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcar.Location = new System.Drawing.Point(6, 302);
            this.btnMarcar.Name = "btnMarcar";
            this.btnMarcar.Size = new System.Drawing.Size(100, 25);
            this.btnMarcar.TabIndex = 11;
            this.btnMarcar.Text = "&Marcar Todos";
            this.btnMarcar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnMarcar, "Clique para marcar todos os itens.");
            this.btnMarcar.UseVisualStyleBackColor = true;
            this.btnMarcar.Click += new System.EventHandler(this.btnMarcarDesmarcar_Click);
            this.btnMarcar.MouseLeave += new System.EventHandler(this.btnMarcar_MouseLeave);
            this.btnMarcar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMarcar_MouseMove);
            // 
            // mtxtDataVencimento
            // 
            this.mtxtDataVencimento.BackColor = System.Drawing.Color.White;
            this.mtxtDataVencimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtDataVencimento.Location = new System.Drawing.Point(90, 32);
            this.mtxtDataVencimento.Mask = "00/00/0000";
            this.mtxtDataVencimento.Name = "mtxtDataVencimento";
            this.mtxtDataVencimento.Size = new System.Drawing.Size(78, 20);
            this.mtxtDataVencimento.TabIndex = 3;
            this.mtxtDataVencimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtxtDataVencimento.DoubleClick += new System.EventHandler(this.mtxtDataVencimento_DoubleClick);
            this.mtxtDataVencimento.Enter += new System.EventHandler(this.mtxtDataVencimento_Enter);
            this.mtxtDataVencimento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtDataVencimento_KeyPress);
            this.mtxtDataVencimento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtDataVencimento_KeyUp);
            this.mtxtDataVencimento.Leave += new System.EventHandler(this.mtxtDataVencimento_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "HH:mm";
            // 
            // lviewUsuarios
            // 
            this.lviewUsuarios.BackColor = System.Drawing.Color.GhostWhite;
            this.lviewUsuarios.CheckBoxes = true;
            this.lviewUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lviewUsuarios.FullRowSelect = true;
            this.lviewUsuarios.HideSelection = false;
            this.lviewUsuarios.Location = new System.Drawing.Point(6, 189);
            this.lviewUsuarios.Name = "lviewUsuarios";
            this.lviewUsuarios.Size = new System.Drawing.Size(505, 107);
            this.lviewUsuarios.TabIndex = 10;
            this.lviewUsuarios.UseCompatibleStateImageBehavior = false;
            this.lviewUsuarios.View = System.Windows.Forms.View.List;
            this.lviewUsuarios.MouseLeave += new System.EventHandler(this.lviewUsuarios_MouseLeave);
            this.lviewUsuarios.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lviewUsuarios_MouseMove);
            // 
            // lblAsterisco4
            // 
            this.lblAsterisco4.AutoSize = true;
            this.lblAsterisco4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco4.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco4.Location = new System.Drawing.Point(372, 13);
            this.lblAsterisco4.Name = "lblAsterisco4";
            this.lblAsterisco4.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco4.TabIndex = 0;
            this.lblAsterisco4.Text = "*";
            // 
            // lblAsterisco5
            // 
            this.lblAsterisco5.AutoSize = true;
            this.lblAsterisco5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco5.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco5.Location = new System.Drawing.Point(153, 169);
            this.lblAsterisco5.Name = "lblAsterisco5";
            this.lblAsterisco5.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco5.TabIndex = 0;
            this.lblAsterisco5.Text = "*";
            // 
            // lblAsterisco3
            // 
            this.lblAsterisco3.AutoSize = true;
            this.lblAsterisco3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco3.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco3.Location = new System.Drawing.Point(59, 51);
            this.lblAsterisco3.Name = "lblAsterisco3";
            this.lblAsterisco3.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco3.TabIndex = 0;
            this.lblAsterisco3.Text = "*";
            // 
            // lblAsterisco2
            // 
            this.lblAsterisco2.AutoSize = true;
            this.lblAsterisco2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco2.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco2.Location = new System.Drawing.Point(242, 13);
            this.lblAsterisco2.Name = "lblAsterisco2";
            this.lblAsterisco2.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco2.TabIndex = 0;
            this.lblAsterisco2.Text = "*";
            // 
            // lblAlarmeUsuario
            // 
            this.lblAlarmeUsuario.AutoSize = true;
            this.lblAlarmeUsuario.Location = new System.Drawing.Point(6, 173);
            this.lblAlarmeUsuario.Name = "lblAlarmeUsuario";
            this.lblAlarmeUsuario.Size = new System.Drawing.Size(152, 13);
            this.lblAlarmeUsuario.TabIndex = 0;
            this.lblAlarmeUsuario.Text = "Lembrar os seguintes usuários:";
            // 
            // btnOuvir
            // 
            this.btnOuvir.Image = ((System.Drawing.Image)(resources.GetObject("btnOuvir.Image")));
            this.btnOuvir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOuvir.Location = new System.Drawing.Point(456, 29);
            this.btnOuvir.Name = "btnOuvir";
            this.btnOuvir.Size = new System.Drawing.Size(55, 25);
            this.btnOuvir.TabIndex = 7;
            this.btnOuvir.Text = "&Ouvir";
            this.btnOuvir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnOuvir, "Clique para ouvir o som do alarme.");
            this.btnOuvir.UseVisualStyleBackColor = true;
            this.btnOuvir.Click += new System.EventHandler(this.lblOuvir_Click);
            this.btnOuvir.MouseLeave += new System.EventHandler(this.lblOuvir_MouseLeave);
            this.btnOuvir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblOuvir_MouseMove);
            // 
            // lblAsterisco1
            // 
            this.lblAsterisco1.AutoSize = true;
            this.lblAsterisco1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAsterisco1.ForeColor = System.Drawing.Color.Red;
            this.lblAsterisco1.Location = new System.Drawing.Point(115, 13);
            this.lblAsterisco1.Name = "lblAsterisco1";
            this.lblAsterisco1.Size = new System.Drawing.Size(13, 15);
            this.lblAsterisco1.TabIndex = 0;
            this.lblAsterisco1.Text = "*";
            // 
            // lblSomAlarme
            // 
            this.lblSomAlarme.AutoSize = true;
            this.lblSomAlarme.Location = new System.Drawing.Point(297, 16);
            this.lblSomAlarme.Name = "lblSomAlarme";
            this.lblSomAlarme.Size = new System.Drawing.Size(80, 13);
            this.lblSomAlarme.TabIndex = 0;
            this.lblSomAlarme.Text = "Som do alarme:";
            // 
            // mtxtHora
            // 
            this.mtxtHora.BackColor = System.Drawing.Color.White;
            this.mtxtHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHora.Location = new System.Drawing.Point(206, 32);
            this.mtxtHora.Mask = "00:00";
            this.mtxtHora.Name = "mtxtHora";
            this.mtxtHora.Size = new System.Drawing.Size(40, 20);
            this.mtxtHora.TabIndex = 5;
            this.mtxtHora.ValidatingType = typeof(System.DateTime);
            this.mtxtHora.DoubleClick += new System.EventHandler(this.mtxtHora_DoubleClick);
            this.mtxtHora.Enter += new System.EventHandler(this.mtxtHora_Enter);
            this.mtxtHora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtHora_KeyPress);
            this.mtxtHora.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mtxtHora_KeyUp);
            this.mtxtHora.Leave += new System.EventHandler(this.mtxtHora_Leave);
            // 
            // cbbSomAlarme
            // 
            this.cbbSomAlarme.BackColor = System.Drawing.Color.LightBlue;
            this.cbbSomAlarme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSomAlarme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSomAlarme.FormattingEnabled = true;
            this.cbbSomAlarme.Items.AddRange(new object[] {
            "ALERTA 1",
            "ALERTA 2",
            "ALERTA 3",
            "ALERTA 4",
            "ALERTA 5",
            "ALERTA 6",
            "ALERTA 7",
            "ALERTA 8",
            "ALERTA 9"});
            this.cbbSomAlarme.Location = new System.Drawing.Point(300, 32);
            this.cbbSomAlarme.Name = "cbbSomAlarme";
            this.cbbSomAlarme.Size = new System.Drawing.Size(150, 21);
            this.cbbSomAlarme.TabIndex = 6;
            this.cbbSomAlarme.DropDown += new System.EventHandler(this.cbbSomAlarme_DropDown);
            this.cbbSomAlarme.DropDownClosed += new System.EventHandler(this.cbbSomAlarme_DropDownClosed);
            this.cbbSomAlarme.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbSomAlarme_KeyPress);
            this.cbbSomAlarme.MouseLeave += new System.EventHandler(this.cbbSomAlarme_MouseLeave);
            this.cbbSomAlarme.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbSomAlarme_MouseMove);
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(202, 16);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(44, 13);
            this.lblHora.TabIndex = 0;
            this.lblHora.Text = "Horário:";
            // 
            // lblObservacoes
            // 
            this.lblObservacoes.AutoSize = true;
            this.lblObservacoes.Location = new System.Drawing.Point(6, 94);
            this.lblObservacoes.Name = "lblObservacoes";
            this.lblObservacoes.Size = new System.Drawing.Size(73, 13);
            this.lblObservacoes.TabIndex = 0;
            this.lblObservacoes.Text = "Observações:";
            // 
            // rtxtObservacoes
            // 
            this.rtxtObservacoes.BackColor = System.Drawing.Color.White;
            this.rtxtObservacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtObservacoes.Location = new System.Drawing.Point(6, 110);
            this.rtxtObservacoes.MaxLength = 200;
            this.rtxtObservacoes.Name = "rtxtObservacoes";
            this.rtxtObservacoes.Size = new System.Drawing.Size(505, 60);
            this.rtxtObservacoes.TabIndex = 9;
            this.rtxtObservacoes.Text = "";
            this.rtxtObservacoes.Enter += new System.EventHandler(this.rtxtObservacoes_Enter);
            this.rtxtObservacoes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtObservacoes_KeyPress);
            this.rtxtObservacoes.Leave += new System.EventHandler(this.rtxtObservacoes_Leave);
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(6, 71);
            this.txtDescricao.MaxLength = 60;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDescricao.Size = new System.Drawing.Size(505, 20);
            this.txtDescricao.TabIndex = 8;
            this.txtDescricao.Enter += new System.EventHandler(this.txtDescricao_Enter);
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            this.txtDescricao.Leave += new System.EventHandler(this.txtDescricao_Leave);
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(6, 55);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 0;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(87, 16);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(33, 13);
            this.lblData.TabIndex = 0;
            this.lblData.Text = "Data:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.Location = new System.Drawing.Point(236, 350);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 32);
            this.btnSalvar.TabIndex = 13;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnSalvar, "Salvar dados e prosseguir.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(12, 350);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 56;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // ttpLembrete
            // 
            this.ttpLembrete.AutoPopDelay = 5000;
            this.ttpLembrete.InitialDelay = 1000;
            this.ttpLembrete.IsBalloon = true;
            this.ttpLembrete.ReshowDelay = 100;
            this.ttpLembrete.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpLembrete.ToolTipTitle = "Dica:";
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(482, 350);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 14;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpLembrete.SetToolTip(this.btnSair, "Sair de Cadastro de Lembrete");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // FrmUtilCadLembrete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(550, 386);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.picbInterrogacao1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUtilCadLembrete";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Lembrete";
              this.TopMost = false;
            this.Load += new System.EventHandler(this.FrmContCadLembrete_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmContCadLembrete_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblObservacoes;
        private System.Windows.Forms.RichTextBox rtxtObservacoes;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnOuvir;
        private System.Windows.Forms.Label lblSomAlarme;
        private System.Windows.Forms.ComboBox cbbSomAlarme;
        private System.Windows.Forms.MaskedTextBox mtxtHora;
        private System.Windows.Forms.Label lblAlarmeUsuario;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblAsterisco3;
        private System.Windows.Forms.Label lblAsterisco2;
        private System.Windows.Forms.Label lblAsterisco1;
        private System.Windows.Forms.Label lblAsterisco5;
        private System.Windows.Forms.Label lblAsterisco4;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.ToolTip ttpLembrete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lviewUsuarios;
        private System.Windows.Forms.MaskedTextBox mtxtDataVencimento;
        private System.Windows.Forms.Button btnSelecionarData3;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnMarcar;
        private System.Windows.Forms.Button btnDesmarcar;
    }
}