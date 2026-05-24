namespace SIE_7_Sistema
{
    partial class FrmSS
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
            this.grbBoxDataHorrario = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.mtxtHoraSai = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mtxtHoraIni = new System.Windows.Forms.MaskedTextBox();
            this.grbBoxDataHorrario.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBoxDataHorrario
            // 
            this.grbBoxDataHorrario.Controls.Add(this.comboBox1);
            this.grbBoxDataHorrario.Controls.Add(this.mtxtHoraSai);
            this.grbBoxDataHorrario.Controls.Add(this.label5);
            this.grbBoxDataHorrario.Controls.Add(this.label4);
            this.grbBoxDataHorrario.Controls.Add(this.label3);
            this.grbBoxDataHorrario.Controls.Add(this.mtxtHoraIni);
            this.grbBoxDataHorrario.Location = new System.Drawing.Point(43, 65);
            this.grbBoxDataHorrario.Name = "grbBoxDataHorrario";
            this.grbBoxDataHorrario.Size = new System.Drawing.Size(198, 133);
            this.grbBoxDataHorrario.TabIndex = 21;
            this.grbBoxDataHorrario.TabStop = false;
            this.grbBoxDataHorrario.Text = "Dias e horários:";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Coral;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 35);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(78, 21);
            this.comboBox1.TabIndex = 28;
            // 
            // mtxtHoraSai
            // 
            this.mtxtHoraSai.Enabled = false;
            this.mtxtHoraSai.Location = new System.Drawing.Point(145, 36);
            this.mtxtHoraSai.Mask = "00:00";
            this.mtxtHoraSai.Name = "mtxtHoraSai";
            this.mtxtHoraSai.Size = new System.Drawing.Size(34, 20);
            this.mtxtHoraSai.TabIndex = 37;
            this.mtxtHoraSai.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(142, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "Saída:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(87, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Início:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Dia:";
            // 
            // mtxtHoraIni
            // 
            this.mtxtHoraIni.Enabled = false;
            this.mtxtHoraIni.Location = new System.Drawing.Point(90, 35);
            this.mtxtHoraIni.Mask = "00:00";
            this.mtxtHoraIni.Name = "mtxtHoraIni";
            this.mtxtHoraIni.Size = new System.Drawing.Size(34, 20);
            this.mtxtHoraIni.TabIndex = 19;
            this.mtxtHoraIni.ValidatingType = typeof(System.DateTime);
            // 
            // FrmSS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.grbBoxDataHorrario);
            this.Name = "FrmSS";
            this.Text = "FrmSS";
            this.grbBoxDataHorrario.ResumeLayout(false);
            this.grbBoxDataHorrario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBoxDataHorrario;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MaskedTextBox mtxtHoraSai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtxtHoraIni;
    }
}