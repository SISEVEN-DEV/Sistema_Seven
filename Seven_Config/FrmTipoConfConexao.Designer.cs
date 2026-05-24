namespace _7_Sistema_Config
{
    partial class FrmTipoConfConexao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTipoConfConexao));
            this.btnConfigLocal = new System.Windows.Forms.Button();
            this.btnConfigRede = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.ttpConexao = new System.Windows.Forms.ToolTip(this.components);
            this.grbBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfigLocal
            // 
            this.btnConfigLocal.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigLocal.Image")));
            this.btnConfigLocal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigLocal.Location = new System.Drawing.Point(6, 19);
            this.btnConfigLocal.Name = "btnConfigLocal";
            this.btnConfigLocal.Size = new System.Drawing.Size(181, 25);
            this.btnConfigLocal.TabIndex = 2;
            this.btnConfigLocal.Text = "Configurar um &Banco de Dados";
            this.btnConfigLocal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpConexao.SetToolTip(this.btnConfigLocal, "Clique para configurar um Banco de Dados");
            this.btnConfigLocal.UseVisualStyleBackColor = true;
            this.btnConfigLocal.Click += new System.EventHandler(this.btnConfigLocal_Click);
            this.btnConfigLocal.MouseLeave += new System.EventHandler(this.btnConfigLocal_MouseLeave);
            this.btnConfigLocal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnConfigLocal_MouseMove);
            // 
            // btnConfigRede
            // 
            this.btnConfigRede.Image = ((System.Drawing.Image)(resources.GetObject("btnConfigRede.Image")));
            this.btnConfigRede.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfigRede.Location = new System.Drawing.Point(193, 19);
            this.btnConfigRede.Name = "btnConfigRede";
            this.btnConfigRede.Size = new System.Drawing.Size(326, 25);
            this.btnConfigRede.TabIndex = 3;
            this.btnConfigRede.Text = "Configurar este &Computador para acessar um Banco de Dados";
            this.btnConfigRede.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpConexao.SetToolTip(this.btnConfigRede, "Clique para configurar este computador para acessar um banco de dados local ou na" +
        " rede.");
            this.btnConfigRede.UseVisualStyleBackColor = true;
            this.btnConfigRede.Click += new System.EventHandler(this.button1_Click);
            this.btnConfigRede.MouseLeave += new System.EventHandler(this.btnConfigRede_MouseLeave);
            this.btnConfigRede.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnConfigRede_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnConfigLocal);
            this.grbBox1.Controls.Add(this.btnConfigRede);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(530, 53);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Tipos de Configuração:";
            // 
            // btnSair
            // 
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(487, 71);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // ttpConexao
            // 
            this.ttpConexao.AutoPopDelay = 5000;
            this.ttpConexao.InitialDelay = 1000;
            this.ttpConexao.IsBalloon = true;
            this.ttpConexao.ReshowDelay = 100;
            this.ttpConexao.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpConexao.ToolTipTitle = "Dica:";
            // 
            // FrmTipoConfConexao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(556, 107);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTipoConfConexao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conexões";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTipoConfConexao_FormClosing);
            this.Load += new System.EventHandler(this.FrmTipoConfConexao_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmTipoConfConexao_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfigLocal;
        private System.Windows.Forms.Button btnConfigRede;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ToolTip ttpConexao;
    }
}