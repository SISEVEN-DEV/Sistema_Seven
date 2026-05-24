namespace Seven_Sistema
{
    partial class FrmDataAtualizarEst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataAtualizarEst));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDataVenda = new System.Windows.Forms.Label();
            this.btnSelecionarData = new System.Windows.Forms.Button();
            this.mtxtpData = new System.Windows.Forms.MaskedTextBox();
            this.mtxtpData1 = new System.Windows.Forms.MaskedTextBox();
            this.lblAte = new System.Windows.Forms.Label();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.ttpAtu = new System.Windows.Forms.ToolTip(this.components);
            this.grbBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.label9);
            this.grbBox1.Controls.Add(this.lblDataVenda);
            this.grbBox1.Controls.Add(this.btnSelecionarData);
            this.grbBox1.Controls.Add(this.mtxtpData);
            this.grbBox1.Controls.Add(this.mtxtpData1);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(250, 60);
            this.grbBox1.TabIndex = 2;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Informações da recontagem/atualização:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(105, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 15);
            this.label9.TabIndex = 51;
            this.label9.Text = "*";
            // 
            // lblDataVenda
            // 
            this.lblDataVenda.AutoSize = true;
            this.lblDataVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataVenda.Location = new System.Drawing.Point(6, 16);
            this.lblDataVenda.Name = "lblDataVenda";
            this.lblDataVenda.Size = new System.Drawing.Size(104, 13);
            this.lblDataVenda.TabIndex = 10;
            this.lblDataVenda.Text = "Data de Inicio e Fim:";
            // 
            // btnSelecionarData
            // 
            this.btnSelecionarData.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarData.Image")));
            this.btnSelecionarData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarData.Location = new System.Drawing.Point(216, 29);
            this.btnSelecionarData.Name = "btnSelecionarData";
            this.btnSelecionarData.Size = new System.Drawing.Size(26, 25);
            this.btnSelecionarData.TabIndex = 4;
            this.btnSelecionarData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAtu.SetToolTip(this.btnSelecionarData, "Clique para selecionar as datas.");
            this.btnSelecionarData.UseVisualStyleBackColor = true;
            this.btnSelecionarData.Click += new System.EventHandler(this.btnSelecionarData_Click);
            this.btnSelecionarData.MouseLeave += new System.EventHandler(this.btnSelecionarData_MouseLeave);
            this.btnSelecionarData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionarData_MouseMove);
            // 
            // mtxtpData
            // 
            this.mtxtpData.BackColor = System.Drawing.Color.White;
            this.mtxtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtpData.Location = new System.Drawing.Point(6, 32);
            this.mtxtpData.Mask = "00/00/0000";
            this.mtxtpData.Name = "mtxtpData";
            this.mtxtpData.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData.TabIndex = 2;
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
            this.mtxtpData1.Location = new System.Drawing.Point(132, 32);
            this.mtxtpData1.Mask = "00/00/0000";
            this.mtxtpData1.Name = "mtxtpData1";
            this.mtxtpData1.Size = new System.Drawing.Size(78, 20);
            this.mtxtpData1.TabIndex = 3;
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
            this.lblAte.Location = new System.Drawing.Point(97, 35);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(26, 13);
            this.lblAte.TabIndex = 11;
            this.lblAte.Text = "Até:";
            // 
            // btnContinuar
            // 
            this.btnContinuar.Image = ((System.Drawing.Image)(resources.GetObject("btnContinuar.Image")));
            this.btnContinuar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnContinuar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnContinuar.Location = new System.Drawing.Point(115, 78);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(86, 32);
            this.btnContinuar.TabIndex = 5;
            this.btnContinuar.Text = "&Continuar";
            this.btnContinuar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAtu.SetToolTip(this.btnContinuar, "Clique para continuar a Atualização do Estoque.");
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            this.btnContinuar.MouseLeave += new System.EventHandler(this.btnContinuar_MouseLeave);
            this.btnContinuar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnContinuar_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(207, 78);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpAtu.SetToolTip(this.btnSair, "Sair de Atualizar Estoque.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // ttpAtu
            // 
            this.ttpAtu.AutoPopDelay = 5000;
            this.ttpAtu.InitialDelay = 1000;
            this.ttpAtu.IsBalloon = true;
            this.ttpAtu.ReshowDelay = 100;
            this.ttpAtu.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpAtu.ToolTipTitle = "Dica:";
            // 
            // FrmDataAtualizarEst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(283, 119);
            this.ControlBox = false;
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDataAtualizarEst";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualizar Estoque";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDataAtualizarEst_FormClosing);
            this.Load += new System.EventHandler(this.FrmDataAtualizarEst_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmDataAtualizarEst_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDataVenda;
        private System.Windows.Forms.Button btnSelecionarData;
        private System.Windows.Forms.MaskedTextBox mtxtpData;
        private System.Windows.Forms.MaskedTextBox mtxtpData1;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ToolTip ttpAtu;
    }
}