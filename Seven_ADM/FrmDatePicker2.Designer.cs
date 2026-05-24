namespace Seven_Sistema
{
    partial class FrmDatePicker2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDatePicker2));
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.lblData = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.dtpData1 = new System.Windows.Forms.DateTimePicker();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.ttpData = new System.Windows.Forms.ToolTip(this.components);
            this.btnSair = new System.Windows.Forms.Button();
            this.picbInterrogacao1 = new System.Windows.Forms.PictureBox();
            this.grbBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpData
            // 
            this.dtpData.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(6, 32);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(106, 20);
            this.dtpData.TabIndex = 2;
            this.dtpData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpData_KeyPress);
            this.dtpData.MouseLeave += new System.EventHandler(this.dtpData_MouseLeave);
            this.dtpData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtpData_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblData);
            this.grbBox1.Controls.Add(this.lblAte);
            this.grbBox1.Controls.Add(this.dtpData1);
            this.grbBox1.Controls.Add(this.btnSalvar);
            this.grbBox1.Controls.Add(this.dtpData);
            this.grbBox1.Location = new System.Drawing.Point(12, 12);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(398, 240);
            this.grbBox1.TabIndex = 1;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Ações:";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(3, 16);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(100, 13);
            this.lblData.TabIndex = 7;
            this.lblData.Text = "Selecione as datas:";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAte.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAte.Location = new System.Drawing.Point(118, 36);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(30, 13);
            this.lblAte.TabIndex = 0;
            this.lblAte.Text = "Até:";
            // 
            // dtpData1
            // 
            this.dtpData1.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtpData1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpData1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData1.Location = new System.Drawing.Point(154, 32);
            this.dtpData1.Name = "dtpData1";
            this.dtpData1.Size = new System.Drawing.Size(106, 20);
            this.dtpData1.TabIndex = 3;
            this.dtpData1.DropDown += new System.EventHandler(this.dtpData1_DropDown);
            this.dtpData1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpData1_KeyPress);
            this.dtpData1.MouseLeave += new System.EventHandler(this.dtpData1_MouseLeave);
            this.dtpData1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtpData1_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(322, 209);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 25);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpData.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // ttpData
            // 
            this.ttpData.AutoPopDelay = 5000;
            this.ttpData.InitialDelay = 1000;
            this.ttpData.IsBalloon = true;
            this.ttpData.ReshowDelay = 100;
            this.ttpData.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpData.ToolTipTitle = "Dica:";
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSair.Location = new System.Drawing.Point(355, 258);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(55, 32);
            this.btnSair.TabIndex = 5;
            this.btnSair.Text = "&Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpData.SetToolTip(this.btnSair, "Sair de Escolha as Datas.");
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnSair.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // picbInterrogacao1
            // 
            this.picbInterrogacao1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picbInterrogacao1.Image = ((System.Drawing.Image)(resources.GetObject("picbInterrogacao1.Image")));
            this.picbInterrogacao1.Location = new System.Drawing.Point(12, 258);
            this.picbInterrogacao1.Name = "picbInterrogacao1";
            this.picbInterrogacao1.Size = new System.Drawing.Size(20, 20);
            this.picbInterrogacao1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picbInterrogacao1.TabIndex = 76;
            this.picbInterrogacao1.TabStop = false;
            this.picbInterrogacao1.Click += new System.EventHandler(this.picbInterrogacao1_Click);
            this.picbInterrogacao1.MouseLeave += new System.EventHandler(this.picbInterrogacao1_MouseLeave);
            this.picbInterrogacao1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picbInterrogacao1_MouseMove);
            // 
            // FrmDatePicker2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(422, 296);
            this.ControlBox = false;
            this.Controls.Add(this.picbInterrogacao1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.grbBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDatePicker2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Escolha as datas";
            this.Load += new System.EventHandler(this.FrmContLembreteDatePicker_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmContLembreteDatePicker_KeyUp);
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbInterrogacao1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ToolTip ttpData;
        private System.Windows.Forms.DateTimePicker dtpData1;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.PictureBox picbInterrogacao1;
        private System.Windows.Forms.Label lblData;
    }
}