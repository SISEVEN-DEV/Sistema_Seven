namespace SIE_7_Sistema
{
    partial class FrmRelSelecionarColunas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelSelecionarColunas));
            this.chkFitToPageWidth = new System.Windows.Forms.CheckBox();
            this.gboxRowsToPrint = new System.Windows.Forms.GroupBox();
            this.rbtnPadrao = new System.Windows.Forms.RadioButton();
            this.rbtnSelectedRows = new System.Windows.Forms.RadioButton();
            this.rdoAllRows = new System.Windows.Forms.RadioButton();
            this.lblColumnsToPrint = new System.Windows.Forms.Label();
            this.chklst = new System.Windows.Forms.CheckedListBox();
            this.btnImprimirAPagar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkbMostrarInfEmp = new System.Windows.Forms.CheckBox();
            this.chkbLogoEmpresa = new System.Windows.Forms.CheckBox();
            this.chkbLogoSistema = new System.Windows.Forms.CheckBox();
            this.ttpOpcoesImpressao = new System.Windows.Forms.ToolTip(this.components);
            this.btnVoltar = new System.Windows.Forms.Button();
            this.gboxRowsToPrint.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkFitToPageWidth
            // 
            this.chkFitToPageWidth.AutoSize = true;
            this.chkFitToPageWidth.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFitToPageWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkFitToPageWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFitToPageWidth.Location = new System.Drawing.Point(188, 60);
            this.chkFitToPageWidth.Name = "chkFitToPageWidth";
            this.chkFitToPageWidth.Size = new System.Drawing.Size(187, 18);
            this.chkFitToPageWidth.TabIndex = 30;
            this.chkFitToPageWidth.Text = "Imprimir dados no tam. da página";
            this.chkFitToPageWidth.UseVisualStyleBackColor = true;
            this.chkFitToPageWidth.MouseLeave += new System.EventHandler(this.chkFitToPageWidth_MouseLeave);
            this.chkFitToPageWidth.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkFitToPageWidth_MouseMove);
            // 
            // gboxRowsToPrint
            // 
            this.gboxRowsToPrint.Controls.Add(this.rbtnPadrao);
            this.gboxRowsToPrint.Controls.Add(this.rbtnSelectedRows);
            this.gboxRowsToPrint.Controls.Add(this.rdoAllRows);
            this.gboxRowsToPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxRowsToPrint.Location = new System.Drawing.Point(188, 12);
            this.gboxRowsToPrint.Name = "gboxRowsToPrint";
            this.gboxRowsToPrint.Size = new System.Drawing.Size(276, 42);
            this.gboxRowsToPrint.TabIndex = 27;
            this.gboxRowsToPrint.TabStop = false;
            this.gboxRowsToPrint.Text = "Colunas para imprimir:";
            // 
            // rbtnPadrao
            // 
            this.rbtnPadrao.AutoSize = true;
            this.rbtnPadrao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPadrao.Location = new System.Drawing.Point(6, 19);
            this.rbtnPadrao.Name = "rbtnPadrao";
            this.rbtnPadrao.Size = new System.Drawing.Size(65, 17);
            this.rbtnPadrao.TabIndex = 2;
            this.rbtnPadrao.TabStop = true;
            this.rbtnPadrao.Text = "Padrão";
            this.rbtnPadrao.UseVisualStyleBackColor = true;
            this.rbtnPadrao.CheckedChanged += new System.EventHandler(this.rbtnPadrao_CheckedChanged);
            this.rbtnPadrao.MouseLeave += new System.EventHandler(this.rbtnPadrao_MouseLeave);
            this.rbtnPadrao.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rbtnPadrao_MouseMove);
            // 
            // rbtnSelectedRows
            // 
            this.rbtnSelectedRows.AutoSize = true;
            this.rbtnSelectedRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSelectedRows.Location = new System.Drawing.Point(143, 19);
            this.rbtnSelectedRows.Name = "rbtnSelectedRows";
            this.rbtnSelectedRows.Size = new System.Drawing.Size(116, 17);
            this.rbtnSelectedRows.TabIndex = 1;
            this.rbtnSelectedRows.TabStop = true;
            this.rbtnSelectedRows.Text = "Selecionada(as)";
            this.rbtnSelectedRows.UseVisualStyleBackColor = true;
            this.rbtnSelectedRows.Leave += new System.EventHandler(this.rdoSelectedRows_Leave);
            this.rbtnSelectedRows.MouseLeave += new System.EventHandler(this.rdoSelectedRows_MouseLeave);
            this.rbtnSelectedRows.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rdoSelectedRows_MouseMove);
            // 
            // rdoAllRows
            // 
            this.rdoAllRows.AutoSize = true;
            this.rdoAllRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAllRows.Location = new System.Drawing.Point(77, 19);
            this.rdoAllRows.Name = "rdoAllRows";
            this.rdoAllRows.Size = new System.Drawing.Size(60, 17);
            this.rdoAllRows.TabIndex = 0;
            this.rdoAllRows.TabStop = true;
            this.rdoAllRows.Text = "Todas";
            this.rdoAllRows.UseVisualStyleBackColor = true;
            this.rdoAllRows.CheckedChanged += new System.EventHandler(this.rdoAllRows_CheckedChanged);
            this.rdoAllRows.MouseLeave += new System.EventHandler(this.rdoAllRows_MouseLeave);
            this.rdoAllRows.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rdoAllRows_MouseMove);
            // 
            // lblColumnsToPrint
            // 
            this.lblColumnsToPrint.AutoSize = true;
            this.lblColumnsToPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnsToPrint.Location = new System.Drawing.Point(12, 9);
            this.lblColumnsToPrint.Name = "lblColumnsToPrint";
            this.lblColumnsToPrint.Size = new System.Drawing.Size(161, 13);
            this.lblColumnsToPrint.TabIndex = 26;
            this.lblColumnsToPrint.Text = "Selecionar colunas para imprimir:";
            // 
            // chklst
            // 
            this.chklst.CheckOnClick = true;
            this.chklst.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chklst.FormattingEnabled = true;
            this.chklst.HorizontalScrollbar = true;
            this.chklst.Location = new System.Drawing.Point(12, 25);
            this.chklst.Name = "chklst";
            this.chklst.Size = new System.Drawing.Size(170, 214);
            this.chklst.TabIndex = 22;
            this.chklst.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklst_ItemCheck);
            this.chklst.MouseLeave += new System.EventHandler(this.chklst_MouseLeave);
            this.chklst.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chklst_MouseMove);
            // 
            // btnImprimirAPagar
            // 
            this.btnImprimirAPagar.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimirAPagar.Image")));
            this.btnImprimirAPagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimirAPagar.Location = new System.Drawing.Point(201, 85);
            this.btnImprimirAPagar.Name = "btnImprimirAPagar";
            this.btnImprimirAPagar.Size = new System.Drawing.Size(69, 25);
            this.btnImprimirAPagar.TabIndex = 31;
            this.btnImprimirAPagar.Text = "&Imprimir";
            this.btnImprimirAPagar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpOpcoesImpressao.SetToolTip(this.btnImprimirAPagar, "Imprimir dados.");
            this.btnImprimirAPagar.UseVisualStyleBackColor = true;
            this.btnImprimirAPagar.Click += new System.EventHandler(this.btnImprimirAPagar_Click);
            this.btnImprimirAPagar.MouseLeave += new System.EventHandler(this.btnImprimirAPagar_MouseLeave);
            this.btnImprimirAPagar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnImprimirAPagar_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkbMostrarInfEmp);
            this.groupBox1.Controls.Add(this.chkbLogoEmpresa);
            this.groupBox1.Controls.Add(this.btnImprimirAPagar);
            this.groupBox1.Controls.Add(this.chkbLogoSistema);
            this.groupBox1.Location = new System.Drawing.Point(188, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 116);
            this.groupBox1.TabIndex = 191;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opções do relatório:";
            // 
            // chkbMostrarInfEmp
            // 
            this.chkbMostrarInfEmp.AutoSize = true;
            this.chkbMostrarInfEmp.Location = new System.Drawing.Point(6, 65);
            this.chkbMostrarInfEmp.Name = "chkbMostrarInfEmp";
            this.chkbMostrarInfEmp.Size = new System.Drawing.Size(181, 17);
            this.chkbMostrarInfEmp.TabIndex = 2;
            this.chkbMostrarInfEmp.Text = "Mostrar Informações da Empresa";
            this.chkbMostrarInfEmp.UseVisualStyleBackColor = true;
            this.chkbMostrarInfEmp.MouseLeave += new System.EventHandler(this.chkbMostrarInfEmp_MouseLeave);
            this.chkbMostrarInfEmp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbMostrarInfEmp_MouseMove);
            // 
            // chkbLogoEmpresa
            // 
            this.chkbLogoEmpresa.AutoSize = true;
            this.chkbLogoEmpresa.Location = new System.Drawing.Point(6, 42);
            this.chkbLogoEmpresa.Name = "chkbLogoEmpresa";
            this.chkbLogoEmpresa.Size = new System.Drawing.Size(143, 17);
            this.chkbLogoEmpresa.TabIndex = 1;
            this.chkbLogoEmpresa.Text = "Mostrar logo da Empresa";
            this.chkbLogoEmpresa.UseVisualStyleBackColor = true;
            this.chkbLogoEmpresa.MouseLeave += new System.EventHandler(this.chkbLogoEmpresa_MouseLeave);
            this.chkbLogoEmpresa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.checkBox2_MouseMove);
            // 
            // chkbLogoSistema
            // 
            this.chkbLogoSistema.AutoSize = true;
            this.chkbLogoSistema.Location = new System.Drawing.Point(6, 19);
            this.chkbLogoSistema.Name = "chkbLogoSistema";
            this.chkbLogoSistema.Size = new System.Drawing.Size(148, 17);
            this.chkbLogoSistema.TabIndex = 0;
            this.chkbLogoSistema.Text = "Mostrar logo do 7 Sistema";
            this.chkbLogoSistema.UseVisualStyleBackColor = true;
            this.chkbLogoSistema.MouseLeave += new System.EventHandler(this.chkbLogoSistema_MouseLeave);
            this.chkbLogoSistema.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkbLogoSistema_MouseMove);
            // 
            // ttpOpcoesImpressao
            // 
            this.ttpOpcoesImpressao.AutoPopDelay = 5000;
            this.ttpOpcoesImpressao.InitialDelay = 1000;
            this.ttpOpcoesImpressao.IsBalloon = true;
            this.ttpOpcoesImpressao.ReshowDelay = 100;
            this.ttpOpcoesImpressao.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpOpcoesImpressao.ToolTipTitle = "Dica:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(394, 206);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(70, 32);
            this.btnVoltar.TabIndex = 82;
            this.btnVoltar.Text = "V&oltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // FrmRelSelecionarColunas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(476, 250);
            this.ControlBox = false;
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkFitToPageWidth);
            this.Controls.Add(this.gboxRowsToPrint);
            this.Controls.Add(this.lblColumnsToPrint);
            this.Controls.Add(this.chklst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRelSelecionarColunas";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Opções de Impressão";
            this.Load += new System.EventHandler(this.FrmRelSelecionarColunas_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmRelSelecionarColunas_KeyUp);
            this.gboxRowsToPrint.ResumeLayout(false);
            this.gboxRowsToPrint.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox chkFitToPageWidth;
        internal System.Windows.Forms.GroupBox gboxRowsToPrint;
        internal System.Windows.Forms.RadioButton rbtnSelectedRows;
        internal System.Windows.Forms.RadioButton rdoAllRows;
        internal System.Windows.Forms.Label lblColumnsToPrint;
        internal System.Windows.Forms.CheckedListBox chklst;
        private System.Windows.Forms.Button btnImprimirAPagar;
        internal System.Windows.Forms.RadioButton rbtnPadrao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkbMostrarInfEmp;
        private System.Windows.Forms.CheckBox chkbLogoEmpresa;
        private System.Windows.Forms.CheckBox chkbLogoSistema;
        private System.Windows.Forms.ToolTip ttpOpcoesImpressao;
        private System.Windows.Forms.Button btnVoltar;
    }
}