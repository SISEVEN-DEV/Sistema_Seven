namespace Seven_Sistema
{
    partial class FrmPesqDevolucao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesqDevolucao));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnCodVenda = new System.Windows.Forms.RadioButton();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cbbTipoDevolucao = new System.Windows.Forms.ComboBox();
            this.btnProcurarConsumidor = new System.Windows.Forms.Button();
            this.lblConsumidor = new System.Windows.Forms.Label();
            this.cbbConsumidor = new System.Windows.Forms.ComboBox();
            this.lblDatas = new System.Windows.Forms.Label();
            this.rbtnTodos = new System.Windows.Forms.RadioButton();
            this.rbtnCodigo = new System.Windows.Forms.RadioButton();
            this.btnProcurar1 = new System.Windows.Forms.Button();
            this.btnProcurarUsuario = new System.Windows.Forms.Button();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.lblCodPDV = new System.Windows.Forms.Label();
            this.cbbCodPDV = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.mtxtHorario1 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtHorario = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.lblAte = new System.Windows.Forms.Label();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.cbbUsuario = new System.Windows.Forms.ComboBox();
            this.txtpCodigo = new System.Windows.Forms.TextBox();
            this.lblPesquisar = new System.Windows.Forms.Label();
            this.grbBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.rbtnCodVenda);
            this.grbBox1.Controls.Add(this.lblTipo);
            this.grbBox1.Controls.Add(this.cbbTipoDevolucao);
            this.grbBox1.Controls.Add(this.btnProcurarConsumidor);
            this.grbBox1.Controls.Add(this.lblConsumidor);
            this.grbBox1.Controls.Add(this.cbbConsumidor);
            this.grbBox1.Controls.Add(this.lblDatas);
            this.grbBox1.Controls.Add(this.rbtnTodos);
            this.grbBox1.Controls.Add(this.rbtnCodigo);
            this.grbBox1.Controls.Add(this.btnProcurar1);
            this.grbBox1.Controls.Add(this.btnProcurarUsuario);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.lblCodPDV);
            this.grbBox1.Controls.Add(this.cbbCodPDV);
            this.grbBox1.Controls.Add(this.lblUsuario);
            this.grbBox1.Controls.Add(this.mtxtHorario1);
            this.grbBox1.Controls.Add(this.mtxtHorario);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.cbbUsuario);
            this.grbBox1.Controls.Add(this.txtpCodigo);
            this.grbBox1.Controls.Add(this.lblPesquisar);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(821, 123);
            this.grbBox1.TabIndex = 2;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Pesquisar por:";
            // 
            // rbtnCodVenda
            // 
            this.rbtnCodVenda.AutoSize = true;
            this.rbtnCodVenda.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodVenda.Location = new System.Drawing.Point(70, 19);
            this.rbtnCodVenda.Name = "rbtnCodVenda";
            this.rbtnCodVenda.Size = new System.Drawing.Size(107, 17);
            this.rbtnCodVenda.TabIndex = 3;
            this.rbtnCodVenda.TabStop = true;
            this.rbtnCodVenda.Text = "Código da Venda";
            this.rbtnCodVenda.UseVisualStyleBackColor = true;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Enabled = false;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(464, 79);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(119, 13);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo de Devolução:";
            // 
            // cbbTipoDevolucao
            // 
            this.cbbTipoDevolucao.BackColor = System.Drawing.Color.LightBlue;
            this.cbbTipoDevolucao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoDevolucao.DropDownWidth = 470;
            this.cbbTipoDevolucao.Enabled = false;
            this.cbbTipoDevolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTipoDevolucao.FormattingEnabled = true;
            this.cbbTipoDevolucao.Items.AddRange(new object[] {
            "",
            "DEVOLUCAO EM CREDITO LOJA",
            "DEVOLUCAO EM DINHEIRO",
            "DEVOLUCAO EM PRODUTOS",
            "DEVOLUCAO PARCIAL DE PRODUTOS COM DEVOLUCAO EM DINHEIRO",
            "DEVOLUCAO PARCIAL DE PRODUTOS COM DEVOLUCAO EM CREDITO LOJA"});
            this.cbbTipoDevolucao.Location = new System.Drawing.Point(467, 94);
            this.cbbTipoDevolucao.Name = "cbbTipoDevolucao";
            this.cbbTipoDevolucao.Size = new System.Drawing.Size(348, 21);
            this.cbbTipoDevolucao.TabIndex = 17;
            // 
            // btnProcurarConsumidor
            // 
            this.btnProcurarConsumidor.Enabled = false;
            this.btnProcurarConsumidor.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarConsumidor.Image")));
            this.btnProcurarConsumidor.Location = new System.Drawing.Point(332, 91);
            this.btnProcurarConsumidor.Name = "btnProcurarConsumidor";
            this.btnProcurarConsumidor.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarConsumidor.TabIndex = 16;
            this.btnProcurarConsumidor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcurarConsumidor.UseVisualStyleBackColor = true;
            // 
            // lblConsumidor
            // 
            this.lblConsumidor.AutoSize = true;
            this.lblConsumidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsumidor.Location = new System.Drawing.Point(3, 78);
            this.lblConsumidor.Name = "lblConsumidor";
            this.lblConsumidor.Size = new System.Drawing.Size(76, 13);
            this.lblConsumidor.TabIndex = 0;
            this.lblConsumidor.Text = "Consumidor:";
            // 
            // cbbConsumidor
            // 
            this.cbbConsumidor.BackColor = System.Drawing.Color.LightBlue;
            this.cbbConsumidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbConsumidor.DropDownWidth = 550;
            this.cbbConsumidor.Enabled = false;
            this.cbbConsumidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbConsumidor.FormattingEnabled = true;
            this.cbbConsumidor.Location = new System.Drawing.Point(6, 94);
            this.cbbConsumidor.Name = "cbbConsumidor";
            this.cbbConsumidor.Size = new System.Drawing.Size(320, 21);
            this.cbbConsumidor.TabIndex = 15;
            // 
            // lblDatas
            // 
            this.lblDatas.AutoSize = true;
            this.lblDatas.Enabled = false;
            this.lblDatas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatas.Location = new System.Drawing.Point(3, 39);
            this.lblDatas.Name = "lblDatas";
            this.lblDatas.Size = new System.Drawing.Size(177, 13);
            this.lblDatas.TabIndex = 0;
            this.lblDatas.Text = "Data e Horário da Devolução:";
            // 
            // rbtnTodos
            // 
            this.rbtnTodos.AutoSize = true;
            this.rbtnTodos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnTodos.Location = new System.Drawing.Point(183, 19);
            this.rbtnTodos.Name = "rbtnTodos";
            this.rbtnTodos.Size = new System.Drawing.Size(55, 17);
            this.rbtnTodos.TabIndex = 4;
            this.rbtnTodos.TabStop = true;
            this.rbtnTodos.Text = "Todos";
            this.rbtnTodos.UseVisualStyleBackColor = true;
            // 
            // rbtnCodigo
            // 
            this.rbtnCodigo.AutoSize = true;
            this.rbtnCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rbtnCodigo.Location = new System.Drawing.Point(6, 19);
            this.rbtnCodigo.Name = "rbtnCodigo";
            this.rbtnCodigo.Size = new System.Drawing.Size(58, 17);
            this.rbtnCodigo.TabIndex = 2;
            this.rbtnCodigo.TabStop = true;
            this.rbtnCodigo.Text = "Código";
            this.rbtnCodigo.UseVisualStyleBackColor = true;
            // 
            // btnProcurar1
            // 
            this.btnProcurar1.Enabled = false;
            this.btnProcurar1.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurar1.Image")));
            this.btnProcurar1.Location = new System.Drawing.Point(789, 52);
            this.btnProcurar1.Name = "btnProcurar1";
            this.btnProcurar1.Size = new System.Drawing.Size(26, 25);
            this.btnProcurar1.TabIndex = 14;
            this.btnProcurar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcurar1.UseVisualStyleBackColor = true;
            // 
            // btnProcurarUsuario
            // 
            this.btnProcurarUsuario.Enabled = false;
            this.btnProcurarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnProcurarUsuario.Image")));
            this.btnProcurarUsuario.Location = new System.Drawing.Point(586, 52);
            this.btnProcurarUsuario.Name = "btnProcurarUsuario";
            this.btnProcurarUsuario.Size = new System.Drawing.Size(26, 25);
            this.btnProcurarUsuario.TabIndex = 11;
            this.btnProcurarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcurarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Enabled = false;
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(332, 52);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 9;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            // 
            // lblCodPDV
            // 
            this.lblCodPDV.AutoSize = true;
            this.lblCodPDV.Enabled = false;
            this.lblCodPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodPDV.Location = new System.Drawing.Point(722, 38);
            this.lblCodPDV.Name = "lblCodPDV";
            this.lblCodPDV.Size = new System.Drawing.Size(84, 13);
            this.lblCodPDV.TabIndex = 0;
            this.lblCodPDV.Text = "Cód. do PDV:";
            // 
            // cbbCodPDV
            // 
            this.cbbCodPDV.BackColor = System.Drawing.Color.LightBlue;
            this.cbbCodPDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCodPDV.DropDownWidth = 80;
            this.cbbCodPDV.Enabled = false;
            this.cbbCodPDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCodPDV.FormattingEnabled = true;
            this.cbbCodPDV.Location = new System.Drawing.Point(725, 54);
            this.cbbCodPDV.Name = "cbbCodPDV";
            this.cbbCodPDV.Size = new System.Drawing.Size(58, 21);
            this.cbbCodPDV.TabIndex = 13;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Enabled = false;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(464, 39);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(54, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuário:";
            // 
            // mtxtHorario1
            // 
            this.mtxtHorario1.BackColor = System.Drawing.Color.White;
            this.mtxtHorario1.Enabled = false;
            this.mtxtHorario1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorario1.Location = new System.Drawing.Point(269, 55);
            this.mtxtHorario1.Mask = "00:00:00";
            this.mtxtHorario1.Name = "mtxtHorario1";
            this.mtxtHorario1.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario1.TabIndex = 8;
            this.mtxtHorario1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mtxtHorario
            // 
            this.mtxtHorario.BackColor = System.Drawing.Color.White;
            this.mtxtHorario.Enabled = false;
            this.mtxtHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtHorario.Location = new System.Drawing.Point(90, 55);
            this.mtxtHorario.Mask = "00:00:00";
            this.mtxtHorario.Name = "mtxtHorario";
            this.mtxtHorario.Size = new System.Drawing.Size(57, 20);
            this.mtxtHorario.TabIndex = 6;
            this.mtxtHorario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mtxtpData1
            // 
            this.mtxtpData1.BackColor = System.Drawing.Color.White;
            this.mtxtpData1.Enabled = false;
            this.mtxtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData1.Location = new System.Drawing.Point(185, 55);
            this.mtxtpData1.Mask = "00/00/0000";
            this.mtxtpData1.Name = "mtxtpData1";
            this.mtxtpData1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData1.TabIndex = 7;
            this.mtxtpData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Enabled = false;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(153, 58);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // mtxtpData
            // 
            this.mtxtpData.BackColor = System.Drawing.Color.White;
            this.mtxtpData.Enabled = false;
            this.mtxtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData.Location = new System.Drawing.Point(6, 55);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 5;
            this.mtxtpData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbbUsuario
            // 
            this.cbbUsuario.BackColor = System.Drawing.Color.LightBlue;
            this.cbbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUsuario.DropDownWidth = 180;
            this.cbbUsuario.Enabled = false;
            this.cbbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUsuario.FormattingEnabled = true;
            this.cbbUsuario.Location = new System.Drawing.Point(467, 54);
            this.cbbUsuario.Name = "cbbUsuario";
            this.cbbUsuario.Size = new System.Drawing.Size(113, 21);
            this.cbbUsuario.TabIndex = 10;
            // 
            // txtpCodigo
            // 
            this.txtpCodigo.BackColor = System.Drawing.Color.White;
            this.txtpCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpCodigo.Location = new System.Drawing.Point(735, 18);
            this.txtpCodigo.MaxLength = 9;
            this.txtpCodigo.Name = "txtpCodigo";
            this.txtpCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtpCodigo.TabIndex = 4;
            this.txtpCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPesquisar
            // 
            this.lblPesquisar.AutoSize = true;
            this.lblPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPesquisar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPesquisar.Location = new System.Drawing.Point(632, 21);
            this.lblPesquisar.Name = "lblPesquisar";
            this.lblPesquisar.Size = new System.Drawing.Size(97, 13);
            this.lblPesquisar.TabIndex = 0;
            this.lblPesquisar.Text = "Digite o código:";
            // 
            // FrmPesqDevolucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(972, 450);
            this.ControlBox = false;
            this.Controls.Add(this.grbBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPesqDevolucao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPesqDevolucao";
              this.TopMost = false;
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.RadioButton rbtnCodVenda;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cbbTipoDevolucao;
        private System.Windows.Forms.Button btnProcurarConsumidor;
        private System.Windows.Forms.Label lblConsumidor;
        private System.Windows.Forms.ComboBox cbbConsumidor;
        private System.Windows.Forms.Label lblDatas;
        private System.Windows.Forms.RadioButton rbtnTodos;
        private System.Windows.Forms.RadioButton rbtnCodigo;
        private System.Windows.Forms.Button btnProcurar1;
        private System.Windows.Forms.Button btnProcurarUsuario;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.Label lblCodPDV;
        private System.Windows.Forms.ComboBox cbbCodPDV;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.MaskedTextBox mtxtHorario1;
        private System.Windows.Forms.MaskedTextBox mtxtHorario;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.ComboBox cbbUsuario;
        private System.Windows.Forms.TextBox txtpCodigo;
        private System.Windows.Forms.Label lblPesquisar;
    }
}