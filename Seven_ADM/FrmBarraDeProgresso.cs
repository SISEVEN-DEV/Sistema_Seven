using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace Seven_Sistema
{
    public partial class FrmBarraDeProgresso : Form
    {
        public FrmBarraDeProgresso(string nome_arquivo)
        {
            InitializeComponent();
            _Nome_Arquivo = nome_arquivo;            
        }

        int _Contador;
        string _Nome_Arquivo;
        
        private void FrmBarraDeProgresso_Load(object sender, EventArgs e)
        {
            timer1.Start();
            pgbProgresso.Value = 20;            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _Contador++;           
            try
            {
                if (bllContasPagar.VerificarArquivoCriado(_Nome_Arquivo))
                {
                    pgbProgresso.Value = 80;
                    timer1.Stop();
                    this.DialogResult = DialogResult.OK;
                }
                else if(_Contador == 10)
                {
                    timer1.Stop();
                    MessageBox.Show("Não foi possível criar o arquivo requisitado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Abort;
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer1.Stop();
                this.DialogResult = DialogResult.Abort;
            }            
        }    
    }
}
