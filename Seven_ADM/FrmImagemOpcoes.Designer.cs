namespace Seven_Sistema
{
    partial class FrmImagemOpcoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImagemOpcoes));
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.btnExcluirImg = new System.Windows.Forms.Button();
            this.btnTirarFoto = new System.Windows.Forms.Button();
            this.btnEscolherImagem = new System.Windows.Forms.Button();
            this.btnVisualizar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.ttpInserirImagem = new System.Windows.Forms.ToolTip(this.components);
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.btnExcluirImg);
            this.grbBox1.Controls.Add(this.btnTirarFoto);
            this.grbBox1.Controls.Add(this.btnEscolherImagem);
            this.grbBox1.Controls.Add(this.btnVisualizar);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(493, 50);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Ações:";
            // 
            // btnExcluirImg
            // 
            this.btnExcluirImg.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirImg.Image")));
            this.btnExcluirImg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluirImg.Location = new System.Drawing.Point(377, 19);
            this.btnExcluirImg.Name = "btnExcluirImg";
            this.btnExcluirImg.Size = new System.Drawing.Size(110, 25);
            this.btnExcluirImg.TabIndex = 6;
            this.btnExcluirImg.Text = "&Excluir imagem";
            this.btnExcluirImg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInserirImagem.SetToolTip(this.btnExcluirImg, "Excluir imagem atual.");
            this.btnExcluirImg.UseVisualStyleBackColor = true;
            this.btnExcluirImg.Click += new System.EventHandler(this.btnExcluirImg_Click);
            this.btnExcluirImg.MouseLeave += new System.EventHandler(this.btnExcluirImg_MouseLeave);
            this.btnExcluirImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluirImg_MouseMove);
            // 
            // btnTirarFoto
            // 
            this.btnTirarFoto.Image = ((System.Drawing.Image)(resources.GetObject("btnTirarFoto.Image")));
            this.btnTirarFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTirarFoto.Location = new System.Drawing.Point(150, 19);
            this.btnTirarFoto.Name = "btnTirarFoto";
            this.btnTirarFoto.Size = new System.Drawing.Size(100, 25);
            this.btnTirarFoto.TabIndex = 4;
            this.btnTirarFoto.Text = "&Tirar uma foto";
            this.btnTirarFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInserirImagem.SetToolTip(this.btnTirarFoto, "Clique para tirar uma foto com um dispositivo de câmera conectado a este computad" +
        "or.");
            this.btnTirarFoto.UseVisualStyleBackColor = true;
            this.btnTirarFoto.Click += new System.EventHandler(this.btnTirarFoto_Click);
            this.btnTirarFoto.MouseLeave += new System.EventHandler(this.btnTirarFoto_MouseLeave);
            this.btnTirarFoto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnTirarFoto_MouseMove);
            // 
            // btnEscolherImagem
            // 
            this.btnEscolherImagem.Image = ((System.Drawing.Image)(resources.GetObject("btnEscolherImagem.Image")));
            this.btnEscolherImagem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEscolherImagem.Location = new System.Drawing.Point(6, 19);
            this.btnEscolherImagem.Name = "btnEscolherImagem";
            this.btnEscolherImagem.Size = new System.Drawing.Size(138, 25);
            this.btnEscolherImagem.TabIndex = 2;
            this.btnEscolherImagem.Text = "Es&colher uma imagem";
            this.btnEscolherImagem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInserirImagem.SetToolTip(this.btnEscolherImagem, "Ao clicar nesse botão você vai navegar pelo windows até encontrar o arquivo desej" +
        "ado.");
            this.btnEscolherImagem.UseVisualStyleBackColor = true;
            this.btnEscolherImagem.Click += new System.EventHandler(this.btnEscolherImagem_Click);
            this.btnEscolherImagem.MouseLeave += new System.EventHandler(this.btnEscolherImagem_MouseLeave);
            this.btnEscolherImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEscolherImagem_MouseMove);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnVisualizar.Image")));
            this.btnVisualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisualizar.Location = new System.Drawing.Point(256, 19);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(115, 25);
            this.btnVisualizar.TabIndex = 5;
            this.btnVisualizar.Text = "&Visualizar imagem";
            this.btnVisualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInserirImagem.SetToolTip(this.btnVisualizar, "Visualizar imagem pelo o windows.");
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            this.btnVisualizar.MouseLeave += new System.EventHandler(this.btnVisualizar_MouseLeave);
            this.btnVisualizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVisualizar_MouseMove);
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoltar.Location = new System.Drawing.Point(450, 68);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(55, 32);
            this.btnVoltar.TabIndex = 8;
            this.btnVoltar.Text = "&Sair";
            this.btnVoltar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpInserirImagem.SetToolTip(this.btnVoltar, "Sair de Inserir Imagem.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(12, 68);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 78;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // ttpInserirImagem
            // 
            this.ttpInserirImagem.AutoPopDelay = 5000;
            this.ttpInserirImagem.InitialDelay = 1000;
            this.ttpInserirImagem.IsBalloon = true;
            this.ttpInserirImagem.ReshowDelay = 100;
            this.ttpInserirImagem.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpInserirImagem.ToolTipTitle = "Dica:";
            // 
            // FrmImagemOpcoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(516, 105);
            this.ControlBox = false;
            this.Controls.Add(this.picbInterrogacao1);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.btnVoltar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImagemOpcoes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inserir imagem";
              this.TopMost = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmImagemOpcoes_FormClosing);
            this.Load += new System.EventHandler(this.FrmImagemOpcoes_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmImagemOpcoes_KeyUp);
            this.grbBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnEscolherImagem;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Button btnTirarFoto;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Button btnExcluirImg;
        private System.Windows.Forms.ToolTip ttpInserirImagem;
    }
}