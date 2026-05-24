namespace Seven_Sistema
{
    partial class FrmCadTransportadora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadTransportadora));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.label54 = new System.Windows.Forms.Label();
            this.txtValorFrete = new System.Windows.Forms.TextBox();
            this.grbBox6 = new System.Windows.Forms.GroupBox();
            this.rbtnFreteDestinatario = new System.Windows.Forms.RadioButton();
            this.rbtnFreteEmitente = new System.Windows.Forms.RadioButton();
            this.grbBox5 = new System.Windows.Forms.GroupBox();
            this.rbtnTerceiros = new System.Windows.Forms.RadioButton();
            this.rbtnSemTransporte = new System.Windows.Forms.RadioButton();
            this.rbtnProprio = new System.Windows.Forms.RadioButton();
            this.grbBox4 = new System.Windows.Forms.GroupBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPesoLiquido = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPesoBruto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEspecie = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeracao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantidadeEmbalagem = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.grbBox3 = new System.Windows.Forms.GroupBox();
            this.txtVeiculo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbUF = new System.Windows.Forms.ComboBox();
            this.lblUF = new System.Windows.Forms.Label();
            this.txtPlacaVeiculo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCFOP = new System.Windows.Forms.Label();
            this.txtCodigoANTT = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grbBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnProcurarFornecedor = new System.Windows.Forms.Button();
            this.cbbFornecedor = new System.Windows.Forms.ComboBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.ttpTransportadora = new System.Windows.Forms.ToolTip(this.components);
            this.grbBox1.SuspendLayout();
            this.grbBox6.SuspendLayout();
            this.grbBox5.SuspendLayout();
            this.grbBox4.SuspendLayout();
            this.grbBox3.SuspendLayout();
            this.grbBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.label54);
            this.grbBox1.Controls.Add(this.txtValorFrete);
            this.grbBox1.Controls.Add(this.grbBox6);
            this.grbBox1.Controls.Add(this.grbBox5);
            this.grbBox1.Controls.Add(this.grbBox4);
            this.grbBox1.Controls.Add(this.grbBox3);
            this.grbBox1.Controls.Add(this.grbBox2);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(631, 320);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Informações do Transportador:";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.ForeColor = System.Drawing.Color.Black;
            this.label54.Location = new System.Drawing.Point(541, 197);
            this.label54.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(61, 13);
            this.label54.TabIndex = 0;
            this.label54.Text = "Valor Frete:";
            // 
            // txtValorFrete
            // 
            this.txtValorFrete.BackColor = System.Drawing.Color.White;
            this.txtValorFrete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtValorFrete.Location = new System.Drawing.Point(544, 213);
            this.txtValorFrete.MaxLength = 8;
            this.txtValorFrete.Name = "txtValorFrete";
            this.txtValorFrete.ReadOnly = true;
            this.txtValorFrete.Size = new System.Drawing.Size(74, 20);
            this.txtValorFrete.TabIndex = 12;
            this.txtValorFrete.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorFrete.Enter += new System.EventHandler(this.txtValorFrete_Enter);
            this.txtValorFrete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorFrete_KeyPress);
            this.txtValorFrete.Leave += new System.EventHandler(this.txtValorFrete_Leave);
            // 
            // grbBox6
            // 
            this.grbBox6.Controls.Add(this.rbtnFreteDestinatario);
            this.grbBox6.Controls.Add(this.rbtnFreteEmitente);
            this.grbBox6.Enabled = false;
            this.grbBox6.Location = new System.Drawing.Point(11, 67);
            this.grbBox6.Margin = new System.Windows.Forms.Padding(2);
            this.grbBox6.Name = "grbBox6";
            this.grbBox6.Padding = new System.Windows.Forms.Padding(2);
            this.grbBox6.Size = new System.Drawing.Size(607, 45);
            this.grbBox6.TabIndex = 5;
            this.grbBox6.TabStop = false;
            this.grbBox6.Text = "Tipo de Frete:";
            // 
            // rbtnFreteDestinatario
            // 
            this.rbtnFreteDestinatario.AutoSize = true;
            this.rbtnFreteDestinatario.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rbtnFreteDestinatario.Location = new System.Drawing.Point(299, 18);
            this.rbtnFreteDestinatario.Name = "rbtnFreteDestinatario";
            this.rbtnFreteDestinatario.Size = new System.Drawing.Size(171, 17);
            this.rbtnFreteDestinatario.TabIndex = 7;
            this.rbtnFreteDestinatario.Text = "Frete por conta do Destinatário";
            this.rbtnFreteDestinatario.UseVisualStyleBackColor = true;
            this.rbtnFreteDestinatario.MouseLeave += new System.EventHandler(this.rbtnFreteDestinatario_MouseLeave);
            this.rbtnFreteDestinatario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnFreteDestinatario_MouseMove);
            // 
            // rbtnFreteEmitente
            // 
            this.rbtnFreteEmitente.AutoSize = true;
            this.rbtnFreteEmitente.Location = new System.Drawing.Point(137, 18);
            this.rbtnFreteEmitente.Name = "rbtnFreteEmitente";
            this.rbtnFreteEmitente.Size = new System.Drawing.Size(156, 17);
            this.rbtnFreteEmitente.TabIndex = 6;
            this.rbtnFreteEmitente.Text = "Frete por conta do Emitente";
            this.rbtnFreteEmitente.UseVisualStyleBackColor = true;
            this.rbtnFreteEmitente.MouseLeave += new System.EventHandler(this.rbtnFreteEmitente_MouseLeave);
            this.rbtnFreteEmitente.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnFreteEmitente_MouseMove);
            // 
            // grbBox5
            // 
            this.grbBox5.Controls.Add(this.rbtnTerceiros);
            this.grbBox5.Controls.Add(this.rbtnSemTransporte);
            this.grbBox5.Controls.Add(this.rbtnProprio);
            this.grbBox5.Location = new System.Drawing.Point(11, 18);
            this.grbBox5.Margin = new System.Windows.Forms.Padding(2);
            this.grbBox5.Name = "grbBox5";
            this.grbBox5.Padding = new System.Windows.Forms.Padding(2);
            this.grbBox5.Size = new System.Drawing.Size(607, 45);
            this.grbBox5.TabIndex = 1;
            this.grbBox5.TabStop = false;
            this.grbBox5.Text = "Dados do Transporte:";
            // 
            // rbtnTerceiros
            // 
            this.rbtnTerceiros.AutoSize = true;
            this.rbtnTerceiros.Location = new System.Drawing.Point(260, 18);
            this.rbtnTerceiros.Name = "rbtnTerceiros";
            this.rbtnTerceiros.Size = new System.Drawing.Size(86, 17);
            this.rbtnTerceiros.TabIndex = 3;
            this.rbtnTerceiros.Text = "De Terceiros";
            this.rbtnTerceiros.UseVisualStyleBackColor = true;
            this.rbtnTerceiros.CheckedChanged += new System.EventHandler(this.rbtnTerceiros_CheckedChanged);
            this.rbtnTerceiros.MouseLeave += new System.EventHandler(this.rbtnTerceiros_MouseLeave);
            this.rbtnTerceiros.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnTerceiros_MouseMove);
            // 
            // rbtnSemTransporte
            // 
            this.rbtnSemTransporte.AutoSize = true;
            this.rbtnSemTransporte.Location = new System.Drawing.Point(352, 18);
            this.rbtnSemTransporte.Name = "rbtnSemTransporte";
            this.rbtnSemTransporte.Size = new System.Drawing.Size(100, 17);
            this.rbtnSemTransporte.TabIndex = 4;
            this.rbtnSemTransporte.Text = "Sem Transporte";
            this.rbtnSemTransporte.UseVisualStyleBackColor = true;
            this.rbtnSemTransporte.CheckedChanged += new System.EventHandler(this.rbtnSemTransporte_CheckedChanged);
            this.rbtnSemTransporte.MouseLeave += new System.EventHandler(this.rbtnSemTransporte_MouseLeave);
            this.rbtnSemTransporte.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnSemTransporte_MouseMove);
            // 
            // rbtnProprio
            // 
            this.rbtnProprio.AutoSize = true;
            this.rbtnProprio.Location = new System.Drawing.Point(156, 18);
            this.rbtnProprio.Name = "rbtnProprio";
            this.rbtnProprio.Size = new System.Drawing.Size(98, 17);
            this.rbtnProprio.TabIndex = 2;
            this.rbtnProprio.Text = "Veículo Próprio";
            this.rbtnProprio.UseVisualStyleBackColor = true;
            this.rbtnProprio.CheckedChanged += new System.EventHandler(this.rbtnProprio_CheckedChanged);
            this.rbtnProprio.MouseLeave += new System.EventHandler(this.rbtnProprio_MouseLeave);
            this.rbtnProprio.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnProprio_MouseMove);
            // 
            // grbBox4
            // 
            this.grbBox4.Controls.Add(this.txtMarca);
            this.grbBox4.Controls.Add(this.label8);
            this.grbBox4.Controls.Add(this.txtPesoLiquido);
            this.grbBox4.Controls.Add(this.label7);
            this.grbBox4.Controls.Add(this.txtPesoBruto);
            this.grbBox4.Controls.Add(this.label5);
            this.grbBox4.Controls.Add(this.txtEspecie);
            this.grbBox4.Controls.Add(this.label4);
            this.grbBox4.Controls.Add(this.txtNumeracao);
            this.grbBox4.Controls.Add(this.label3);
            this.grbBox4.Controls.Add(this.txtQuantidadeEmbalagem);
            this.grbBox4.Controls.Add(this.label10);
            this.grbBox4.Location = new System.Drawing.Point(5, 248);
            this.grbBox4.Margin = new System.Windows.Forms.Padding(2);
            this.grbBox4.Name = "grbBox4";
            this.grbBox4.Padding = new System.Windows.Forms.Padding(2);
            this.grbBox4.Size = new System.Drawing.Size(613, 62);
            this.grbBox4.TabIndex = 13;
            this.grbBox4.TabStop = false;
            this.grbBox4.Text = "Quantidade/Peso:";
            // 
            // txtMarca
            // 
            this.txtMarca.BackColor = System.Drawing.Color.White;
            this.txtMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtMarca.Location = new System.Drawing.Point(173, 31);
            this.txtMarca.MaxLength = 60;
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(115, 20);
            this.txtMarca.TabIndex = 15;
            this.txtMarca.Enter += new System.EventHandler(this.textBox1_Enter);
            this.txtMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txtMarca.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(171, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Marca:";
            // 
            // txtPesoLiquido
            // 
            this.txtPesoLiquido.BackColor = System.Drawing.Color.White;
            this.txtPesoLiquido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPesoLiquido.Location = new System.Drawing.Point(534, 31);
            this.txtPesoLiquido.MaxLength = 15;
            this.txtPesoLiquido.Name = "txtPesoLiquido";
            this.txtPesoLiquido.Size = new System.Drawing.Size(74, 20);
            this.txtPesoLiquido.TabIndex = 19;
            this.txtPesoLiquido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPesoLiquido.Enter += new System.EventHandler(this.txtPesoLiquido_Enter);
            this.txtPesoLiquido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPesoLiquido_KeyPress);
            this.txtPesoLiquido.Leave += new System.EventHandler(this.txtPesoLiquido_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(531, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Peso Líquido:";
            // 
            // txtPesoBruto
            // 
            this.txtPesoBruto.BackColor = System.Drawing.Color.White;
            this.txtPesoBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPesoBruto.Location = new System.Drawing.Point(454, 31);
            this.txtPesoBruto.MaxLength = 15;
            this.txtPesoBruto.Name = "txtPesoBruto";
            this.txtPesoBruto.Size = new System.Drawing.Size(74, 20);
            this.txtPesoBruto.TabIndex = 18;
            this.txtPesoBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPesoBruto.Enter += new System.EventHandler(this.txtPesoBruto_Enter);
            this.txtPesoBruto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPesoBruto_KeyPress);
            this.txtPesoBruto.Leave += new System.EventHandler(this.txtPesoBruto_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(451, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Peso Bruto:";
            // 
            // txtEspecie
            // 
            this.txtEspecie.BackColor = System.Drawing.Color.White;
            this.txtEspecie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtEspecie.Location = new System.Drawing.Point(5, 31);
            this.txtEspecie.MaxLength = 60;
            this.txtEspecie.Name = "txtEspecie";
            this.txtEspecie.Size = new System.Drawing.Size(162, 20);
            this.txtEspecie.TabIndex = 14;
            this.txtEspecie.Enter += new System.EventHandler(this.txtEspecie_Enter);
            this.txtEspecie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEspecie_KeyPress);
            this.txtEspecie.Leave += new System.EventHandler(this.txtEspecie_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Espécie:";
            // 
            // txtNumeracao
            // 
            this.txtNumeracao.BackColor = System.Drawing.Color.White;
            this.txtNumeracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtNumeracao.Location = new System.Drawing.Point(374, 31);
            this.txtNumeracao.MaxLength = 9;
            this.txtNumeracao.Name = "txtNumeracao";
            this.txtNumeracao.Size = new System.Drawing.Size(74, 20);
            this.txtNumeracao.TabIndex = 17;
            this.txtNumeracao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumeracao.Enter += new System.EventHandler(this.txtNumeracao_Enter);
            this.txtNumeracao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPreco_KeyPress);
            this.txtNumeracao.Leave += new System.EventHandler(this.txtNumeracao_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Númeração:";
            // 
            // txtQuantidadeEmbalagem
            // 
            this.txtQuantidadeEmbalagem.BackColor = System.Drawing.Color.White;
            this.txtQuantidadeEmbalagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtQuantidadeEmbalagem.Location = new System.Drawing.Point(294, 31);
            this.txtQuantidadeEmbalagem.MaxLength = 10;
            this.txtQuantidadeEmbalagem.Name = "txtQuantidadeEmbalagem";
            this.txtQuantidadeEmbalagem.Size = new System.Drawing.Size(74, 20);
            this.txtQuantidadeEmbalagem.TabIndex = 16;
            this.txtQuantidadeEmbalagem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuantidadeEmbalagem.Enter += new System.EventHandler(this.txtQuantidadeEmbalagem_Enter);
            this.txtQuantidadeEmbalagem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidadeEmbalagem_KeyPress);
            this.txtQuantidadeEmbalagem.Leave += new System.EventHandler(this.txtQuantidadeEmbalagem_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(291, 15);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Quantidade:";
            // 
            // grbBox3
            // 
            this.grbBox3.Controls.Add(this.txtVeiculo);
            this.grbBox3.Controls.Add(this.label6);
            this.grbBox3.Controls.Add(this.cbbUF);
            this.grbBox3.Controls.Add(this.lblUF);
            this.grbBox3.Controls.Add(this.txtPlacaVeiculo);
            this.grbBox3.Controls.Add(this.label2);
            this.grbBox3.Controls.Add(this.lblCFOP);
            this.grbBox3.Controls.Add(this.txtCodigoANTT);
            this.grbBox3.Controls.Add(this.label9);
            this.grbBox3.Location = new System.Drawing.Point(6, 182);
            this.grbBox3.Margin = new System.Windows.Forms.Padding(2);
            this.grbBox3.Name = "grbBox3";
            this.grbBox3.Padding = new System.Windows.Forms.Padding(2);
            this.grbBox3.Size = new System.Drawing.Size(531, 62);
            this.grbBox3.TabIndex = 11;
            this.grbBox3.TabStop = false;
            this.grbBox3.Text = "Informações do Veículo:";
            // 
            // txtVeiculo
            // 
            this.txtVeiculo.BackColor = System.Drawing.Color.White;
            this.txtVeiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtVeiculo.Location = new System.Drawing.Point(5, 31);
            this.txtVeiculo.MaxLength = 30;
            this.txtVeiculo.Name = "txtVeiculo";
            this.txtVeiculo.Size = new System.Drawing.Size(293, 20);
            this.txtVeiculo.TabIndex = 12;
            this.txtVeiculo.Enter += new System.EventHandler(this.txtVeiculo_Enter);
            this.txtVeiculo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVeiculo_KeyPress);
            this.txtVeiculo.Leave += new System.EventHandler(this.txtVeiculo_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(497, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "*";
            // 
            // cbbUF
            // 
            this.cbbUF.BackColor = System.Drawing.Color.LightBlue;
            this.cbbUF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cbbUF.FormattingEnabled = true;
            this.cbbUF.Items.AddRange(new object[] {
            "",
            "AC",
            "AL",
            "AM",
            "AP",
            "BA",
            "CE",
            "DF",
            "ES",
            "GO",
            "MA",
            "MG",
            "MS",
            "MT",
            "PA",
            "PB",
            "PE",
            "PI",
            "PR",
            "RJ",
            "RN",
            "RO",
            "RR",
            "RS",
            "SC",
            "SE",
            "SP",
            "TO"});
            this.cbbUF.Location = new System.Drawing.Point(481, 31);
            this.cbbUF.Name = "cbbUF";
            this.cbbUF.Size = new System.Drawing.Size(45, 21);
            this.cbbUF.TabIndex = 15;
            this.cbbUF.DropDown += new System.EventHandler(this.cbbUF_DropDown);
            this.cbbUF.DropDownClosed += new System.EventHandler(this.cbbUF_DropDownClosed);
            this.cbbUF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbUF_KeyPress);
            this.cbbUF.MouseLeave += new System.EventHandler(this.cbbUF_MouseLeave);
            this.cbbUF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbUF_MouseMove);
            // 
            // lblUF
            // 
            this.lblUF.AutoSize = true;
            this.lblUF.Location = new System.Drawing.Point(478, 15);
            this.lblUF.Name = "lblUF";
            this.lblUF.Size = new System.Drawing.Size(24, 13);
            this.lblUF.TabIndex = 0;
            this.lblUF.Text = "UF:";
            // 
            // txtPlacaVeiculo
            // 
            this.txtPlacaVeiculo.BackColor = System.Drawing.Color.White;
            this.txtPlacaVeiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPlacaVeiculo.Location = new System.Drawing.Point(384, 31);
            this.txtPlacaVeiculo.MaxLength = 7;
            this.txtPlacaVeiculo.Name = "txtPlacaVeiculo";
            this.txtPlacaVeiculo.Size = new System.Drawing.Size(91, 20);
            this.txtPlacaVeiculo.TabIndex = 14;
            this.txtPlacaVeiculo.Enter += new System.EventHandler(this.txtPlacaVeiculo_Enter);
            this.txtPlacaVeiculo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlacaVeiculo_KeyPress);
            this.txtPlacaVeiculo.Leave += new System.EventHandler(this.txtPlacaVeiculo_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Placa do Veículo:";
            // 
            // lblCFOP
            // 
            this.lblCFOP.AutoSize = true;
            this.lblCFOP.Location = new System.Drawing.Point(4, 15);
            this.lblCFOP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCFOP.Name = "lblCFOP";
            this.lblCFOP.Size = new System.Drawing.Size(47, 13);
            this.lblCFOP.TabIndex = 0;
            this.lblCFOP.Text = "Veículo:";
            // 
            // txtCodigoANTT
            // 
            this.txtCodigoANTT.BackColor = System.Drawing.Color.White;
            this.txtCodigoANTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCodigoANTT.Location = new System.Drawing.Point(304, 31);
            this.txtCodigoANTT.MaxLength = 20;
            this.txtCodigoANTT.Name = "txtCodigoANTT";
            this.txtCodigoANTT.Size = new System.Drawing.Size(74, 20);
            this.txtCodigoANTT.TabIndex = 13;
            this.txtCodigoANTT.Enter += new System.EventHandler(this.txtCodigoANTT_Enter);
            this.txtCodigoANTT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoANTT_KeyPress);
            this.txtCodigoANTT.Leave += new System.EventHandler(this.txtCodigoANTT_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(303, 15);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Código ANTT:";
            // 
            // grbBox2
            // 
            this.grbBox2.Controls.Add(this.label1);
            this.grbBox2.Controls.Add(this.btnProcurarFornecedor);
            this.grbBox2.Controls.Add(this.cbbFornecedor);
            this.grbBox2.Enabled = false;
            this.grbBox2.Location = new System.Drawing.Point(6, 117);
            this.grbBox2.Name = "grbBox2";
            this.grbBox2.Size = new System.Drawing.Size(612, 60);
            this.grbBox2.TabIndex = 8;
            this.grbBox2.TabStop = false;
            this.grbBox2.Text = "Fornecedor/Transportador:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(2, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código, Descrição e CPF/CNPJ do(a) Transportador(ra):";
            // 
            // btnProcurarFornecedor
            // 
            this.btnProcurarFornecedor.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarFornecedor.Image")));
            this.btnProcurarFornecedor.Location = new System.Drawing.Point(574, 30);
            this.btnProcurarFornecedor.Name = "btnProcurarFornecedor";
            this.btnProcurarFornecedor.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarFornecedor.TabIndex = 10;
            this.btnProcurarFornecedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpTransportadora.SetToolTip(this.btnProcurarFornecedor, "Clique para pesquisar um Transportador.");
            this.btnProcurarFornecedor.UseVisualStyleBackColor = true;
            this.btnProcurarFornecedor.Click += new System.EventHandler(this.btnProcurarProduto_Click);
            this.btnProcurarFornecedor.MouseLeave += new System.EventHandler(this.btnProcurarProduto_MouseLeave);
            this.btnProcurarFornecedor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnProcurarProduto_MouseMove);
            // 
            // cbbFornecedor
            // 
            this.cbbFornecedor.BackColor = System.Drawing.Color.LightBlue;
            this.cbbFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFornecedor.DropDownWidth = 550;
            this.cbbFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbFornecedor.FormattingEnabled = true;
            this.cbbFornecedor.Location = new System.Drawing.Point(5, 33);
            this.cbbFornecedor.Name = "cbbFornecedor";
            this.cbbFornecedor.Size = new System.Drawing.Size(563, 21);
            this.cbbFornecedor.TabIndex = 9;
            this.cbbFornecedor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbbFornecedor_DrawItem);
            this.cbbFornecedor.DropDown += new System.EventHandler(this.cbbFornecedor_DropDown);
            this.cbbFornecedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbFornecedor_KeyPress);
            this.cbbFornecedor.MouseLeave += new System.EventHandler(this.cbbFornecedor_MouseLeave);
            this.cbbFornecedor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbFornecedor_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSalvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalvar.Location = new System.Drawing.Point(283, 338);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(72, 32);
            this.btnSalvar.TabIndex = 20;
            this.btnSalvar.Text = "  &Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpTransportadora.SetToolTip(this.btnSalvar, "Salvar dados informados.");
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
            this.btnSair.Location = new System.Drawing.Point(588, 338);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 21;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpTransportadora.SetToolTip(this.btnSair, "Sair do Cadastro de Transportador.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(12, 338);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 79;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // ttpTransportadora
            // 
            this.ttpTransportadora.AutoPopDelay = 5000;
            this.ttpTransportadora.InitialDelay = 1000;
            this.ttpTransportadora.IsBalloon = true;
            this.ttpTransportadora.ReshowDelay = 100;
            this.ttpTransportadora.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpTransportadora.ToolTipTitle = "Dica:";
            // 
            // FrmCadTransportadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(654, 375);
            this.ControlBox = false;
            this.Controls.Add(this.picbInterrogacao1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadTransportadora";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Transportador";
            this.Load += new System.EventHandler(this.FrmCadTransportadora_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadTransportadora_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.grbBox6.ResumeLayout(false);
            this.grbBox6.PerformLayout();
            this.grbBox5.ResumeLayout(false);
            this.grbBox5.PerformLayout();
            this.grbBox4.ResumeLayout(false);
            this.grbBox4.PerformLayout();
            this.grbBox3.ResumeLayout(false);
            this.grbBox3.PerformLayout();
            this.grbBox2.ResumeLayout(false);
            this.grbBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbFornecedor;
        private System.Windows.Forms.GroupBox grbBox4;
        private System.Windows.Forms.TextBox txtNumeracao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigoANTT;
        private System.Windows.Forms.TextBox txtQuantidadeEmbalagem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grbBox3;
        private System.Windows.Forms.GroupBox grbBox2;
        private System.Windows.Forms.Button btnProcurarFornecedor;
        private System.Windows.Forms.Label lblCFOP;
        private System.Windows.Forms.RadioButton rbtnFreteEmitente;
        private System.Windows.Forms.RadioButton rbtnFreteDestinatario;
        private System.Windows.Forms.TextBox txtPlacaVeiculo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbUF;
        private System.Windows.Forms.Label lblUF;
        private System.Windows.Forms.TextBox txtPesoLiquido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPesoBruto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEspecie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.TextBox txtVeiculo;
        private System.Windows.Forms.RadioButton rbtnTerceiros;
        private System.Windows.Forms.RadioButton rbtnProprio;
        private System.Windows.Forms.RadioButton rbtnSemTransporte;
        private System.Windows.Forms.GroupBox grbBox6;
        private System.Windows.Forms.GroupBox grbBox5;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolTip ttpTransportadora;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox txtValorFrete;
    }
}