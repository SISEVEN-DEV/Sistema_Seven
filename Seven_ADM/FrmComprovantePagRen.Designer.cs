namespace SIE_7_Sistema
{
    partial class FrmComprovantePagRen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComprovantePagRen));
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnDigitalizar = new System.Windows.Forms.Button();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.btnTirarFoto = new System.Windows.Forms.Button();
            this.btnEscolherArquivo = new System.Windows.Forms.Button();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.ttpComprovante = new System.Windows.Forms.ToolTip(this.components);
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualizar.Image")));
            this.btnVisualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisualizar.Location = new System.Drawing.Point(470, 19);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(149, 25);
            this.btnVisualizar.TabIndex = 5;
            this.btnVisualizar.Text = "&Visualizar comprovantes";
            this.btnVisualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComprovante.SetToolTip(this.btnVisualizar, "Abrir local de arquivo.");
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            this.btnVisualizar.MouseLeave += new System.EventHandler(this.btnVisualizar_MouseLeave);
            this.btnVisualizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVisualizar_MouseMove);
            // 
            // btnDigitalizar
            // 
            this.btnDigitalizar.Image = ((System.Drawing.Image)(resources.GetObject("btnDigitalizar.Image")));
            this.btnDigitalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDigitalizar.Location = new System.Drawing.Point(217, 19);
            this.btnDigitalizar.Name = "btnDigitalizar";
            this.btnDigitalizar.Size = new System.Drawing.Size(141, 25);
            this.btnDigitalizar.TabIndex = 3;
            this.btnDigitalizar.Text = "&Digitalizar documentos";
            this.btnDigitalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComprovante.SetToolTip(this.btnDigitalizar, "Clique para scanear com um dispositivo de scanner conectado a este computador.\r\n");
            this.btnDigitalizar.UseVisualStyleBackColor = true;
            this.btnDigitalizar.Click += new System.EventHandler(this.btnDigitalizar_Click);
            this.btnDigitalizar.MouseLeave += new System.EventHandler(this.btnDigitalizar_MouseLeave);
            this.btnDigitalizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDigitalizar_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnTirarFoto);
            this.grbBox1.Controls.Add(this.btnEscolherArquivo);
            this.grbBox1.Controls.Add(this.btnDigitalizar);
            this.grbBox1.Controls.Add(this.btnVisualizar);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(626, 50);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Ações:";
            // 
            // btnTirarFoto
            // 
            this.btnTirarFoto.Image = ((System.Drawing.Image)(resources.GetObject("btnTirarFoto.Image")));
            this.btnTirarFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTirarFoto.Location = new System.Drawing.Point(364, 19);
            this.btnTirarFoto.Name = "btnTirarFoto";
            this.btnTirarFoto.Size = new System.Drawing.Size(100, 25);
            this.btnTirarFoto.TabIndex = 4;
            this.btnTirarFoto.Text = "&Tirar uma foto";
            this.btnTirarFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComprovante.SetToolTip(this.btnTirarFoto, "Clique para tirar uma foto com um dispositivo de câmera conectado a este computad" +
        "or.");
            this.btnTirarFoto.UseVisualStyleBackColor = true;
            this.btnTirarFoto.Click += new System.EventHandler(this.btnTirarFoto_Click);
            this.btnTirarFoto.MouseLeave += new System.EventHandler(this.btnTirarFoto_MouseLeave);
            this.btnTirarFoto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnTirarFoto_MouseMove);
            // 
            // btnEscolherArquivo
            // 
            this.btnEscolherArquivo.Image = ((System.Drawing.Image)(resources.GetObject("btnEscolherArquivo.Image")));
            this.btnEscolherArquivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEscolherArquivo.Location = new System.Drawing.Point(6, 19);
            this.btnEscolherArquivo.Name = "btnEscolherArquivo";
            this.btnEscolherArquivo.Size = new System.Drawing.Size(205, 25);
            this.btnEscolherArquivo.TabIndex = 2;
            this.btnEscolherArquivo.Text = "&Escolher um arquivo do computador";
            this.btnEscolherArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComprovante.SetToolTip(this.btnEscolherArquivo, "Escolher um arquivo do computador.");
            this.btnEscolherArquivo.UseVisualStyleBackColor = true;
            this.btnEscolherArquivo.Click += new System.EventHandler(this.btnEscolherImagem_Click);
            this.btnEscolherArquivo.MouseLeave += new System.EventHandler(this.btnEscolherImagem_MouseLeave);
            this.btnEscolherArquivo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEscolherImagem_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(12, 68);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 79;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(568, 68);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(70, 32);
            this.btnVoltar.TabIndex = 6;
            this.btnVoltar.Text = "V&oltar";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpComprovante.SetToolTip(this.btnVoltar, "Voltar ao menu anterior.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // ttpComprovante
            // 
            this.ttpComprovante.AutoPopDelay = 5000;
            this.ttpComprovante.InitialDelay = 1000;
            this.ttpComprovante.IsBalloon = true;
            this.ttpComprovante.ReshowDelay = 100;
            this.ttpComprovante.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpComprovante.ToolTipTitle = "Dica:";
            // 
            // FrmComprovantePagRen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(649, 107);
            this.ControlBox = false;
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.picbInterrogacao1);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmComprovantePagRen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comprovante de Pagamento \\ Renegociação";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmComprovantePagamento_FormClosing);
            this.Load += new System.EventHandler(this.FrmComprovantePagamento_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmComprovantePagamento_KeyUp);
            this.grbBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Button btnDigitalizar;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnEscolherArquivo;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.ToolTip ttpComprovante;
        private System.Windows.Forms.Button btnTirarFoto;
    }
}