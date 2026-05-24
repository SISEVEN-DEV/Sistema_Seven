namespace SIE_7_Sistema
{
    partial class FrmCadCursoProfessor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadCursoProfessor));
            this.ttpProf = new System.Windows.Forms.ToolTip(this.components);
            this.dtProfessor = new System.Windows.Forms.DataGridView();
            this.grbBox1 = new System.Windows.Forms.GroupBox();
            this.cbbProfessor = new System.Windows.Forms.ComboBox();
            this.lblProfessor = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtProfessor)).BeginInit();
            this.grbBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttpProf
            // 
            this.ttpProf.AutoPopDelay = 5000;
            this.ttpProf.InitialDelay = 1000;
            this.ttpProf.IsBalloon = true;
            this.ttpProf.ReshowDelay = 100;
            this.ttpProf.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpProf.ToolTipTitle = "Dica:";
            // 
            // dtProfessor
            // 
            this.dtProfessor.AllowUserToAddRows = false;
            this.dtProfessor.AllowUserToDeleteRows = false;
            this.dtProfessor.AllowUserToOrderColumns = true;
            this.dtProfessor.AllowUserToResizeRows = false;
            this.dtProfessor.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtProfessor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtProfessor.Location = new System.Drawing.Point(12, 12);
            this.dtProfessor.MultiSelect = false;
            this.dtProfessor.Name = "dtProfessor";
            this.dtProfessor.ReadOnly = true;
            this.dtProfessor.RowHeadersVisible = false;
            this.dtProfessor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtProfessor.ShowCellErrors = false;
            this.dtProfessor.ShowCellToolTips = false;
            this.dtProfessor.ShowEditingIcon = false;
            this.dtProfessor.ShowRowErrors = false;
            this.dtProfessor.Size = new System.Drawing.Size(375, 128);
            this.dtProfessor.TabIndex = 138;
            this.dtProfessor.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtProfessor_CellEnter);
            this.dtProfessor.MouseLeave += new System.EventHandler(this.dtProfessor_MouseLeave);
            this.dtProfessor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dtProfessor_MouseMove);
            // 
            // grbBox1
            // 
            this.grbBox1.Controls.Add(this.lblProfessor);
            this.grbBox1.Controls.Add(this.cbbProfessor);
            this.grbBox1.Location = new System.Drawing.Point(12, 146);
            this.grbBox1.Name = "grbBox1";
            this.grbBox1.Size = new System.Drawing.Size(375, 63);
            this.grbBox1.TabIndex = 139;
            this.grbBox1.TabStop = false;
            this.grbBox1.Text = "Cadastrar, alterar e excluir:";
            // 
            // cbbProfessor
            // 
            this.cbbProfessor.BackColor = System.Drawing.Color.LightBlue;
            this.cbbProfessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProfessor.FormattingEnabled = true;
            this.cbbProfessor.Location = new System.Drawing.Point(6, 32);
            this.cbbProfessor.Name = "cbbProfessor";
            this.cbbProfessor.Size = new System.Drawing.Size(360, 21);
            this.cbbProfessor.TabIndex = 0;
            this.cbbProfessor.DropDown += new System.EventHandler(this.cbbProfessor_DropDown);
            this.cbbProfessor.DropDownClosed += new System.EventHandler(this.cbbProfessor_DropDownClosed);
            this.cbbProfessor.MouseLeave += new System.EventHandler(this.cbbProfessor_MouseLeave);
            this.cbbProfessor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cbbProfessor_MouseMove);
            // 
            // lblProfessor
            // 
            this.lblProfessor.AutoSize = true;
            this.lblProfessor.Location = new System.Drawing.Point(6, 16);
            this.lblProfessor.Name = "lblProfessor";
            this.lblProfessor.Size = new System.Drawing.Size(54, 13);
            this.lblProfessor.TabIndex = 1;
            this.lblProfessor.Text = "Professor:";
            // 
            // btnNovo
            // 
            this.btnNovo.Image = ((System.Drawing.Image)(resources.GetObject("btnNovo.Image")));
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.Location = new System.Drawing.Point(12, 215);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(66, 25);
            this.btnNovo.TabIndex = 143;
            this.btnNovo.Text = "&Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProf.SetToolTip(this.btnNovo, "Cadastrar um novo professor ao curso.");
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            this.btnNovo.MouseLeave += new System.EventHandler(this.btnNovo_MouseLeave);
            this.btnNovo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNovo_MouseMove);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterar.Image")));
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterar.Location = new System.Drawing.Point(84, 215);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(66, 25);
            this.btnAlterar.TabIndex = 140;
            this.btnAlterar.Text = "&Alterar";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProf.SetToolTip(this.btnAlterar, "Alterar um curso cadastrado a um curso.");
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.MouseLeave += new System.EventHandler(this.btnAlterar_MouseLeave);
            this.btnAlterar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAlterar_MouseMove);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(325, 215);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(62, 25);
            this.btnSalvar.TabIndex = 141;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProf.SetToolTip(this.btnSalvar, "Salvar dados informados.");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.MouseLeave += new System.EventHandler(this.btnSalvar_MouseLeave);
            this.btnSalvar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSalvar_MouseMove);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Enabled = false;
            this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(156, 215);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(64, 25);
            this.btnExcluir.TabIndex = 142;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProf.SetToolTip(this.btnExcluir, "Excluir um curso cadastrado a um curso.");
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.MouseLeave += new System.EventHandler(this.btnExcluir_MouseLeave);
            this.btnExcluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcluir_MouseMove);
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoltar.Location = new System.Drawing.Point(312, 246);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 25);
            this.btnVoltar.TabIndex = 145;
            this.btnVoltar.Text = "     &Voltar";
            this.ttpProf.SetToolTip(this.btnVoltar, "Sair do cadastro de professores a um curso.");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.MouseLeave += new System.EventHandler(this.btnVoltar_MouseLeave);
            this.btnVoltar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnVoltar_MouseMove);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(251, 215);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(73, 25);
            this.btnCancelar.TabIndex = 146;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ttpProf.SetToolTip(this.btnCancelar, "Cancelar a opção atual.");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.MouseLeave += new System.EventHandler(this.btnCancelar_MouseLeave);
            this.btnCancelar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelar_MouseMove);
            // 
            // FrmCadCursoProfessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(400, 283);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.grbBox1);
            this.Controls.Add(this.dtProfessor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadCursoProfessor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informações do Professor";
            this.Load += new System.EventHandler(this.FrmCadProfInfo_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmCadCursoProfessor_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtProfessor)).EndInit();
            this.grbBox1.ResumeLayout(false);
            this.grbBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip ttpProf;
        private System.Windows.Forms.DataGridView dtProfessor;
        private System.Windows.Forms.GroupBox grbBox1;
        private System.Windows.Forms.Label lblProfessor;
        private System.Windows.Forms.ComboBox cbbProfessor;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnCancelar;
    }
}