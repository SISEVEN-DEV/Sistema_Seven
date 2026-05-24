namespace Seven_Sistema
{
    partial class FrmCapturarImagemWebCam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCapturarImagemWebCam));
            this.pcibImagemWebCam = new System.Windows.Forms.PictureBox();
            this.btnCapturar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.pcibImagemCapturada = new System.Windows.Forms.PictureBox();
            this.lblCamera = new System.Windows.Forms.Label();
            this.lblImagem = new System.Windows.Forms.Label();
            this.ttpCapturarImagemCamera = new System.Windows.Forms.ToolTip(this.components);
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.cbbCamera = new System.Windows.Forms.ComboBox();
            this.lblSelecionarCamera = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagemWebCam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagemCapturada)).BeginInit();
            this.SuspendLayout();
            // 
            // pcibImagemWebCam
            // 
            this.pcibImagemWebCam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibImagemWebCam.Location = new System.Drawing.Point(15, 46);
            this.pcibImagemWebCam.Name = "pcibImagemWebCam";
            this.pcibImagemWebCam.Size = new System.Drawing.Size(350, 300);
            this.pcibImagemWebCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcibImagemWebCam.TabIndex = 0;
            this.pcibImagemWebCam.TabStop = false;
            this.pcibImagemWebCam.MouseLeave += new System.EventHandler(this.pcibImagemWebCam_MouseLeave);
            this.pcibImagemWebCam.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibImagemWebCam_MouseMove);
            // 
            // btnCapturar
            // 
            this.btnCapturar.Enabled = false;
            this.btnCapturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapturar.Image = ((System.Drawing.Image)(resources.GetObject("btnCapturar.Image")));
            this.btnCapturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapturar.Location = new System.Drawing.Point(15, 352);
            this.btnCapturar.Name = "btnCapturar";
            this.btnCapturar.Size = new System.Drawing.Size(350, 25);
            this.btnCapturar.TabIndex = 6;
            this.btnCapturar.Text = "&Capturar Imagem";
            this.ttpCapturarImagemCamera.SetToolTip(this.btnCapturar, "Clique para tirar uma foto com sua câmera conectada ao seu computador.");
            this.btnCapturar.UseVisualStyleBackColor = true;
            this.btnCapturar.Click += new System.EventHandler(this.btnCapturar_Click);
            this.btnCapturar.MouseLeave += new System.EventHandler(this.btnCapturar_MouseLeave);
            this.btnCapturar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCapturar_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(371, 352);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(350, 25);
            this.btnSalvar.TabIndex = 7;
            this.btnSalvar.Text = "&Salvar Imagem";
            this.ttpCapturarImagemCamera.SetToolTip(this.btnSalvar, "Clique para salvar essa imagem.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(15, 383);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 84;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao2_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao2_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao2_MouseMove);
            // 
            // pcibImagemCapturada
            // 
            this.pcibImagemCapturada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcibImagemCapturada.InitialImage = null;
            this.pcibImagemCapturada.Location = new System.Drawing.Point(371, 46);
            this.pcibImagemCapturada.Name = "pcibImagemCapturada";
            this.pcibImagemCapturada.Size = new System.Drawing.Size(350, 300);
            this.pcibImagemCapturada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcibImagemCapturada.TabIndex = 1;
            this.pcibImagemCapturada.TabStop = false;
            this.pcibImagemCapturada.MouseLeave += new System.EventHandler(this.pcibImagemCapturada_MouseLeave);
            this.pcibImagemCapturada.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcibImagemCapturada_MouseMove);
            // 
            // lblCamera
            // 
            this.lblCamera.AutoSize = true;
            this.lblCamera.ForeColor = System.Drawing.Color.Black;
            this.lblCamera.Location = new System.Drawing.Point(12, 30);
            this.lblCamera.Name = "lblCamera";
            this.lblCamera.Size = new System.Drawing.Size(114, 13);
            this.lblCamera.TabIndex = 4;
            this.lblCamera.Text = "Dispositivo de câmera:";
            // 
            // lblImagem
            // 
            this.lblImagem.AutoSize = true;
            this.lblImagem.ForeColor = System.Drawing.Color.Black;
            this.lblImagem.Location = new System.Drawing.Point(368, 30);
            this.lblImagem.Name = "lblImagem";
            this.lblImagem.Size = new System.Drawing.Size(98, 13);
            this.lblImagem.TabIndex = 5;
            this.lblImagem.Text = "Imagem capturada:";
            // 
            // ttpCapturarImagemCamera
            // 
            this.ttpCapturarImagemCamera.AutoPopDelay = 5000;
            this.ttpCapturarImagemCamera.InitialDelay = 1000;
            this.ttpCapturarImagemCamera.IsBalloon = true;
            this.ttpCapturarImagemCamera.ReshowDelay = 100;
            this.ttpCapturarImagemCamera.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpCapturarImagemCamera.ToolTipTitle = "Dica:";
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelecionar.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionar.Image")));
            this.btnSelecionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionar.Location = new System.Drawing.Point(372, 3);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(128, 25);
            this.btnSelecionar.TabIndex = 3;
            this.btnSelecionar.Text = "&Ligar Câmera";
            this.btnSelecionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCapturarImagemCamera.SetToolTip(this.btnSelecionar, "Clique para ligar a câmera.");
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnLigarCamera_Click);
            this.btnSelecionar.MouseLeave += new System.EventHandler(this.btnSelecionar_MouseLeave);
            this.btnSelecionar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSelecionar_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSair.Location = new System.Drawing.Point(666, 383);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 35);
            this.btnSair.TabIndex = 85;
            this.btnSair.Text = "Sai&r";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpCapturarImagemCamera.SetToolTip(this.btnSair, "Sair do Dispositivo de Câmera.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseLeave += new System.EventHandler(this.btnSair_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSair_MouseMove);
            // 
            // cbbCamera
            // 
            this.cbbCamera.BackColor = System.Drawing.Color.LightBlue;
            this.cbbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCamera.FormattingEnabled = true;
            this.cbbCamera.Location = new System.Drawing.Point(116, 6);
            this.cbbCamera.Name = "cbbCamera";
            this.cbbCamera.Size = new System.Drawing.Size(250, 21);
            this.cbbCamera.TabIndex = 2;
            this.cbbCamera.DropDown += new System.EventHandler(this.cbbCamera_DropDown);
            this.cbbCamera.SelectedIndexChanged += new System.EventHandler(this.cbbCamera_SelectedIndexChanged);
            this.cbbCamera.DropDownClosed += new System.EventHandler(this.cbbCamera_DropDownClosed);
            this.cbbCamera.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbCamera_KeyPress);
            this.cbbCamera.MouseLeave += new System.EventHandler(this.cbbCamera_MouseLeave);
            this.cbbCamera.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbCamera_MouseMove);
            // 
            // lblSelecionarCamera
            // 
            this.lblSelecionarCamera.AutoSize = true;
            this.lblSelecionarCamera.ForeColor = System.Drawing.Color.Black;
            this.lblSelecionarCamera.Location = new System.Drawing.Point(12, 9);
            this.lblSelecionarCamera.Name = "lblSelecionarCamera";
            this.lblSelecionarCamera.Size = new System.Drawing.Size(99, 13);
            this.lblSelecionarCamera.TabIndex = 1;
            this.lblSelecionarCamera.Text = "Selecionar Câmera:";
            // 
            // FrmCapturarImagemWebCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(732, 430);
            this.ControlBox = false;
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnSelecionar);
            this.Controls.Add(this.lblSelecionarCamera);
            this.Controls.Add(this.cbbCamera);
            this.Controls.Add(this.lblImagem);
            this.Controls.Add(this.lblCamera);
            this.Controls.Add(this.picbInterrogacao1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCapturar);
            this.Controls.Add(this.pcibImagemCapturada);
            this.Controls.Add(this.pcibImagemWebCam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCapturarImagemWebCam";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dispositivo de Câmera";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCapturarImagemWebCam_FormClosing);
            this.Load += new System.EventHandler(this.FrmCapturarImagemWebCam_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCapturarImagemWebCam_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagemWebCam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcibImagemCapturada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcibImagemWebCam;
        private System.Windows.Forms.Button btnCapturar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.PictureBox pcibImagemCapturada;
        private System.Windows.Forms.Label lblCamera;
        private System.Windows.Forms.Label lblImagem;
        private System.Windows.Forms.ToolTip ttpCapturarImagemCamera;
        private System.Windows.Forms.ComboBox cbbCamera;
        private System.Windows.Forms.Label lblSelecionarCamera;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Button btnSair;
    }
}