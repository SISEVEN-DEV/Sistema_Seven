using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;

namespace SIE_7_Sistema
{
    public partial class FrmRelSelecionarColunas : Form
    {
        public FrmRelSelecionarColunas(List<string> availableFields)
        {
            InitializeComponent();
            foreach (string field in availableFields)
                chklst.Items.Add(field, true);
        }

        public FrmRelSelecionarColunas()
        {
            InitializeComponent();
        }

        private void btnImprimirAPagar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnImprimirAPagar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rdoAllRows_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rdoSelectedRows_Leave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rdoAllRows_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rdoSelectedRows_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rdoSelectedRows_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void txtTitle_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.IBeam;
        }

        private void txtTitle_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chklst_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.IBeam;
        }

        private void chklst_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmRelSelecionarColunas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.DialogResult = DialogResult.Abort;
            }
        }       

        public bool PrintAllRows
        {
            get { return rdoAllRows.Checked; }
        }

        public bool FitToPageWidth
        {
            get { return chkFitToPageWidth.Checked; }
        }

        public List<string> GetSelectedColumns()
        {
            List<string> lst = new List<string>();
            foreach (object item in chklst.CheckedItems)
                lst.Add(item.ToString());
            return lst;
        }

        public string PrintTitle
        {
            get { return ""; }
        }

        bool VerificarItemChecado;

        private void FrmRelSelecionarColunas_Load(object sender, EventArgs e)
        {
            bllContasPagar._Mostrar_Logo_Empresa = true;
            bllContasPagar._Mostrar_Logo_Empresa = true;
            rbtnPadrao.Checked = true;
            chkFitToPageWidth.Checked = false;
            VerificarItemChecado = true;
            chkbLogoEmpresa.Checked = true;
            chkbLogoSistema.Checked = true;
            chkbMostrarInfEmp.Checked = true;
            chklst.Select();
        }

      
        private void btnImprimirAPagar_Click(object sender, EventArgs e)
        {
            if (chklst.CheckedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecione pelo menos uma coluna para imprimir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                chklst.Select();
            }
            else
            {
                if (chklst.CheckedItems.Count > 6 & rbtnPadrao.Checked != true)
                {
                    DialogResult = MessageBox.Show("Você selecionou mais de 6 colunas para serem mostradas no relatório, pode ser que elas não fiquem alinhadas corretamente na página.\nDeseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        if (chkbLogoEmpresa.Checked == true)
                        {
                            bllContasPagar._Mostrar_Logo_Empresa = true;
                        }
                        else
                        {
                            bllContasPagar._Mostrar_Logo_Empresa = false;
                        }
                        //
                        if (chkbMostrarInfEmp.Checked == true)
                        {
                            bllContasPagar._Mostrar_Inf_Empresa = true;
                        }
                        else
                        {
                            bllContasPagar._Mostrar_Inf_Empresa = false;
                        }
                        //
                        if (chkbLogoSistema.Checked == true)
                        {
                            bllContasPagar._Mostrar_Logo_Sistema = true;
                        }
                        else
                        {
                            bllContasPagar._Mostrar_Logo_Sistema = false;
                        }
                        //
                        bllContasPagar._ImprimirSalvar = true;
                        this.DialogResult = DialogResult.OK;

                        this.Close();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.None;
                    }
                }
                else 
                {
                    if (chkbLogoEmpresa.Checked == true)
                    {
                        bllContasPagar._Mostrar_Logo_Empresa = true;
                    }
                    else
                    {
                        bllContasPagar._Mostrar_Logo_Empresa = false;
                    }
                    //
                    if (chkbMostrarInfEmp.Checked == true)
                    {
                        bllContasPagar._Mostrar_Inf_Empresa = true;
                    }
                    else
                    {
                        bllContasPagar._Mostrar_Inf_Empresa = false;
                    }
                    //
                    if (chkbLogoSistema.Checked == true)
                    {
                        bllContasPagar._Mostrar_Logo_Sistema = true;
                    }
                    else
                    {
                        bllContasPagar._Mostrar_Logo_Sistema = false;
                    }
                    //
                    bllContasPagar._ImprimirSalvar = true;
                    this.DialogResult = DialogResult.OK;                    
                }       
            }            
        }

        private void rbtnPadrao_CheckedChanged(object sender, EventArgs e)
        {
            VerificarItemChecado = false;
            chklst.SetItemChecked(0, true);
            chklst.SetItemChecked(1, false);
            chklst.SetItemChecked(2, true);
            chklst.SetItemChecked(3, true);
            chklst.SetItemChecked(4, true);
            chklst.SetItemChecked(5, false);
            chklst.SetItemChecked(6, false);
            chklst.SetItemChecked(7, true);
            chklst.SetItemChecked(8, false);
            chklst.SetItemChecked(9, false);
            chklst.SetItemChecked(10, false);
            chklst.SetItemChecked(11, true);
            chklst.SetItemChecked(12, false);
            chklst.SetItemChecked(13, true);
            chklst.SetItemChecked(14, false);
            chklst.SetItemChecked(15, true);
            chklst.SetItemChecked(16, false);
            chklst.SetItemChecked(17, true);
            chklst.SetItemChecked(18, false);
            chklst.SetItemChecked(19, true);
            chklst.SetItemChecked(20, false);
            chklst.SetItemChecked(21, true);
            chklst.SetItemChecked(22, false);
            chklst.SetItemChecked(23, false);
            chklst.SetItemChecked(24, false);
            chklst.SetItemChecked(25, false);
            chklst.SetItemChecked(26, false);
            VerificarItemChecado = true;
        }

        private void rbtnPadrao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rbtnPadrao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rdoAllRows_CheckedChanged(object sender, EventArgs e)
        {
            VerificarItemChecado = false;
            for (int i = 0; i < chklst.Items.Count; i++)
            {
                chklst.SetItemChecked(i, true);
            }
            VerificarItemChecado = true;
        }

        private void chkbLogoSistema_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbLogoSistema_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void checkBox2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbLogoEmpresa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbMostrarInfEmp_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbMostrarInfEmp_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chklst_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (VerificarItemChecado == true) 
            {

                rbtnSelectedRows.Checked = true;
                VerificarItemChecado = false;
            }         
        }

        private void chkFitToPageWidth_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }     

        private void chkFitToPageWidth_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(chklst.CheckedItems.Count.ToString());
                                
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        
    }
}
