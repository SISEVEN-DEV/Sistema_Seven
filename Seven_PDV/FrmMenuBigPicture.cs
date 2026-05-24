using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Seven_Sistema
{
    public partial class FrmMenuBigPicture : Form
    {
        public FrmMenuBigPicture(string cod_pdv_computador)
        {
            InitializeComponent();
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Cod_PDV_Computador;

        private void FrmPDFVisualizador_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Config\Log\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Config\Log\Log de Acoes");
                }
                if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMenuBigPicture iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMenuBigPicture iniciado.");
                }
                //
                if (bllConfiguracaoSistema.Sel_Abert_Fech_Caixa_Config() == false)
                {
                    if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) == 0)
                    {
                        lblAbrirCaixa.Enabled = false;
                        lblFecharCaixa.Enabled = false;
                        lblPausarCaixa.Enabled = false;
                    }
                    else if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) == 1)
                    {
                        lblAbrirCaixa.Enabled = false;
                        lblFecharCaixa.Enabled = false;
                        lblPausarCaixa.Enabled = true;
                    }
                    else
                    {
                        lblAbrirCaixa.Enabled = true;
                        lblFecharCaixa.Enabled = false;
                        lblPausarCaixa.Enabled = false;
                    }
                }
                else
                {
                    if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) == 0)
                    {
                        lblAbrirCaixa.Enabled = false;
                        lblFecharCaixa.Enabled = true;
                        lblPausarCaixa.Enabled = true;
                    }
                    else if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(_Cod_PDV_Computador) == 1)
                    {
                        lblAbrirCaixa.Enabled = false;
                        lblFecharCaixa.Enabled = false;
                        lblPausarCaixa.Enabled = true;
                    }
                    else
                    {
                        lblAbrirCaixa.Enabled = true;
                        lblFecharCaixa.Enabled = false;
                        lblPausarCaixa.Enabled = false;
                    }
                }
                //
                btnSair.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmMenuBigPicture.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmMenuBigPicture.");
                }
            }
        }

        private void FrmPDFVisualizador_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
            else if (e.KeyCode == Keys.F1)
            {
                lblAbrirCaixa.BackColor = Color.LightGray;
                lblAbrirCaixa1.BackColor = Color.LightGray;
                if (lblAbrirCaixa.Enabled == true)
                {
                    bllVenda._Opcao_Menu_BigPicture = 1;
                    DialogResult = DialogResult.OK;
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                lblPausarCaixa.BackColor = Color.LightGray;
                lblPausarCaixa1.BackColor = Color.LightGray;
                if (lblPausarCaixa.Enabled == true)
                {
                    bllVenda._Opcao_Menu_BigPicture = 2;
                    DialogResult = DialogResult.OK;
                }
            }
            else if (e.KeyCode == Keys.F3)
            {
                lblFecharCaixa.BackColor = Color.LightGray;
                lblFecharCaixa1.BackColor = Color.LightGray;
                if (lblFecharCaixa.Enabled == true)
                {
                    bllVenda._Opcao_Menu_BigPicture = 3;
                    DialogResult = DialogResult.OK;
                }
            }
            else if (e.KeyCode == Keys.F4)
            {
                lblContasReceber.BackColor = Color.LightGray;
                lblContasReceber1.BackColor = Color.LightGray;
                if (lblContasReceber.Enabled == true)
                {
                    bllVenda._Opcao_Menu_BigPicture = 4;
                    DialogResult = DialogResult.OK;
                }
            }
            else if (e.KeyCode == Keys.F5)
            {
                lblContasPagar.BackColor = Color.LightGray;
                lblContasPagar1.BackColor = Color.LightGray;
                if (lblContasPagar.Enabled == true)
                {
                    bllVenda._Opcao_Menu_BigPicture = 5;
                    DialogResult = DialogResult.OK;
                }
            }
            else if (e.KeyCode == Keys.F6)
            {
                lblVendas.BackColor = Color.LightGray;
                lblVendas1.BackColor = Color.LightGray;
                if (lblVendas.Enabled == true)
                {
                    bllVenda._Opcao_Menu_BigPicture = 6;
                    DialogResult = DialogResult.OK;
                }
            }
            else if (e.KeyCode == Keys.F7)
            {
                lblOrcamentos.BackColor = Color.LightGray;
                lblOrcamentos1.BackColor = Color.LightGray;
                if (lblOrcamentos.Enabled == true)
                {
                    bllVenda._Opcao_Menu_BigPicture = 7;
                    DialogResult = DialogResult.OK;
                }
            }
            else if (e.KeyCode == Keys.F8)
            {
                lblDevolucoes.BackColor = Color.LightGray;
                lblDevolucoes1.BackColor = Color.LightGray;
                if (lblDevolucoes.Enabled == true)
                {
                    bllVenda._Opcao_Menu_BigPicture = 8;
                    DialogResult = DialogResult.OK;
                }
            }
            else if (e.KeyCode == Keys.F9)
            {
                lblSangriaSuprimento.BackColor = Color.LightGray;
                lblSangriaSuprimento1.BackColor = Color.LightGray;
                if (lblSangriaSuprimento.Enabled == true)
                {
                    bllVenda._Opcao_Menu_BigPicture = 9;
                    DialogResult = DialogResult.OK;
                }
            }
            else if (e.KeyCode == Keys.F10)
            {
                lblHistoricoCaixa.BackColor = Color.LightGray;
                lblHistoricoCaixa1.BackColor = Color.LightGray;
                if (lblHistoricoCaixa.Enabled == true)
                {
                    bllVenda._Opcao_Menu_BigPicture = 10;
                    DialogResult = DialogResult.OK;
                }
            }
            else if (e.KeyCode == Keys.F11)
            {
                lblAdicionarObs.BackColor = Color.LightGray;
                lblAdicionarObs1.BackColor = Color.LightGray;
                if (lblAdicionarObs.Enabled == true)
                {
                    bllVenda._Opcao_Menu_BigPicture = 11;
                    DialogResult = DialogResult.OK;
                }
            }
            else if (e.KeyCode == Keys.F12)
            {
                lblMenuNFeNFCe.BackColor = Color.LightGray;
                lblMenuNFeNFCe1.BackColor = Color.LightGray;
                if (lblMenuNFeNFCe.Enabled == true)
                {
                    bllVenda._Opcao_Menu_BigPicture = 12;
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblAbrirCaixa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblAbrirCaixa.BackColor = Color.WhiteSmoke;
            lblAbrirCaixa1.BackColor = Color.WhiteSmoke;
        }

        private void lblAbrirCaixa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblAbrirCaixa.BackColor = Color.LightGray;
            lblAbrirCaixa1.BackColor = Color.LightGray;
        }

        private void lblPausarCaixa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblPausarCaixa.BackColor = Color.WhiteSmoke;
            lblPausarCaixa1.BackColor = Color.WhiteSmoke;
        }

        private void lblPausarCaixa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblPausarCaixa.BackColor = Color.LightGray;
            lblPausarCaixa1.BackColor = Color.LightGray;
        }

        private void lblFecharCaixa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblFecharCaixa.BackColor = Color.WhiteSmoke;
            lblFecharCaixa1.BackColor = Color.WhiteSmoke;
        }

        private void lblFecharCaixa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblFecharCaixa.BackColor = Color.LightGray;
            lblFecharCaixa1.BackColor = Color.LightGray;
        }

        private void lblContasReceber_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblContasReceber.BackColor = Color.WhiteSmoke;
            lblContasReceber1.BackColor = Color.WhiteSmoke;
        }

        private void lblContasReceber_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblContasReceber.BackColor = Color.LightGray;
            lblContasReceber1.BackColor = Color.LightGray;
        }

        private void lblContasPagar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblContasPagar.BackColor = Color.WhiteSmoke;
            lblContasPagar1.BackColor = Color.WhiteSmoke;
        }

        private void lblContasPagar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblContasPagar.BackColor = Color.LightGray;
            lblContasPagar1.BackColor = Color.LightGray;
        }

        private void lblVendas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblVendas.BackColor = Color.WhiteSmoke;
            lblVendas1.BackColor = Color.WhiteSmoke;
        }

        private void lblVendas_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblVendas.BackColor = Color.LightGray;
            lblVendas1.BackColor = Color.LightGray;
        }

        private void lblOrcamentos_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblOrcamentos.BackColor = Color.WhiteSmoke;
            lblOrcamentos1.BackColor = Color.WhiteSmoke;
        }

        private void lblOrcamentos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblOrcamentos.BackColor = Color.LightGray;
            lblOrcamentos1.BackColor = Color.LightGray;
        }

        private void lblDevolucoes_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblDevolucoes.BackColor = Color.WhiteSmoke;
            lblDevolucoes1.BackColor = Color.WhiteSmoke;
        }

        private void lblDevolucoes_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblDevolucoes.BackColor = Color.LightGray;
            lblDevolucoes1.BackColor = Color.LightGray;
        }

        private void lblSangriaSuprimento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblSangriaSuprimento.BackColor = Color.WhiteSmoke;
            lblSangriaSuprimento1.BackColor = Color.WhiteSmoke;
        }

        private void lblSangriaSuprimento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblSangriaSuprimento.BackColor = Color.LightGray;
            lblSangriaSuprimento1.BackColor = Color.LightGray;
        }

        private void lblHistoricoCaixa_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblHistoricoCaixa.BackColor = Color.WhiteSmoke;
            lblHistoricoCaixa1.BackColor = Color.WhiteSmoke;
        }

        private void lblHistoricoCaixa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblHistoricoCaixa.BackColor = Color.LightGray;
            lblHistoricoCaixa1.BackColor = Color.LightGray;
        }

        private void lblAdicionarObs_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblAdicionarObs.BackColor = Color.WhiteSmoke;
            lblAdicionarObs1.BackColor = Color.WhiteSmoke;
        }

        private void lblAdicionarObs_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblAdicionarObs.BackColor = Color.LightGray;
            lblAdicionarObs1.BackColor = Color.LightGray;
        }

        private void lblMenuNFeNFCe_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblMenuNFeNFCe.BackColor = Color.WhiteSmoke;
            lblMenuNFeNFCe1.BackColor = Color.WhiteSmoke;
        }

        private void lblMenuNFeNFCe_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblMenuNFeNFCe.BackColor = Color.LightGray;
            lblMenuNFeNFCe1.BackColor = Color.LightGray;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void FrmMenuBigPicture_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                lblAbrirCaixa.BackColor = Color.WhiteSmoke;
                lblAbrirCaixa1.BackColor = Color.WhiteSmoke;
            }
            else if (e.KeyCode == Keys.F2)
            {
                lblPausarCaixa.BackColor = Color.WhiteSmoke;
                lblPausarCaixa1.BackColor = Color.WhiteSmoke;
            }
            else if (e.KeyCode == Keys.F3)
            {
                lblFecharCaixa.BackColor = Color.WhiteSmoke;
                lblFecharCaixa1.BackColor = Color.WhiteSmoke;
            }
            else if (e.KeyCode == Keys.F4)
            {
                lblContasReceber.BackColor = Color.WhiteSmoke;
                lblContasReceber1.BackColor = Color.WhiteSmoke;
            }
            else if (e.KeyCode == Keys.F5)
            {
                lblContasPagar.BackColor = Color.WhiteSmoke;
                lblContasPagar1.BackColor = Color.WhiteSmoke;
            }
            else if (e.KeyCode == Keys.F6)
            {
                lblVendas.BackColor = Color.WhiteSmoke;
                lblVendas1.BackColor = Color.WhiteSmoke;
            }
            else if (e.KeyCode == Keys.F7)
            {
                lblOrcamentos.BackColor = Color.WhiteSmoke;
                lblOrcamentos1.BackColor = Color.WhiteSmoke;
            }
            else if (e.KeyCode == Keys.F8)
            {
                lblDevolucoes.BackColor = Color.WhiteSmoke;
                lblDevolucoes1.BackColor = Color.WhiteSmoke;
            }
            else if (e.KeyCode == Keys.F9)
            {
                lblSangriaSuprimento.BackColor = Color.WhiteSmoke;
                lblSangriaSuprimento1.BackColor = Color.WhiteSmoke;
            }
            else if (e.KeyCode == Keys.F10)
            {
                lblHistoricoCaixa.BackColor = Color.WhiteSmoke;
                lblHistoricoCaixa1.BackColor = Color.WhiteSmoke;
            }
            else if (e.KeyCode == Keys.F11)
            {
                lblAdicionarObs.BackColor = Color.WhiteSmoke;
                lblAdicionarObs1.BackColor = Color.WhiteSmoke;
            }
            else if (e.KeyCode == Keys.F12)
            {
                lblMenuNFeNFCe.BackColor = Color.WhiteSmoke;
                lblMenuNFeNFCe1.BackColor = Color.WhiteSmoke;
            }
        }

        private void lblMenuNFeNFCe_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 12;
            DialogResult = DialogResult.OK;
        }

        private void lblAbrirCaixa_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 1;
            DialogResult = DialogResult.OK;
        }

        private void lblPausarCaixa_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 2;
            DialogResult = DialogResult.OK;
        }

        private void lblFecharCaixa_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 3;
            DialogResult = DialogResult.OK;
        }

        private void lblContasPagar_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 5;
            DialogResult = DialogResult.OK;
        }

        private void lblVendas_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 6;
            DialogResult = DialogResult.OK;
        }

        private void lblOrcamentos_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 7;
            DialogResult = DialogResult.OK;
        }

        private void lblDevolucoes_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 8;
            DialogResult = DialogResult.OK;
        }

        private void lblSangriaSuprimento_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 9;
            DialogResult = DialogResult.OK;
        }

        private void lblHistoricoCaixa_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 10;
            DialogResult = DialogResult.OK;
        }

        private void lblAdicionarObs_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 11;
            DialogResult = DialogResult.OK;
        }

        private void lblContasReceber_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 4;
            DialogResult = DialogResult.OK;
        }

        private void FrmMenuBigPicture_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMenuBigPicture foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmMenuBigPicture foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmMenuBigPicture.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmMenuBigPicture.");
                }
            }
        }

        private void lblBackup_MouseMove(object sender, MouseEventArgs e)
        {
            lblBackup.BackColor = Color.WhiteSmoke;
            lblBackup1.BackColor = Color.WhiteSmoke;
        }

        private void lblBackup_MouseLeave(object sender, EventArgs e)
        {
            lblBackup.BackColor = Color.LightGray;
            lblBackup1.BackColor = Color.LightGray;
        }

        private void lblAtualizacoes_MouseMove(object sender, MouseEventArgs e)
        {
            lblAtualizacoes.BackColor = Color.WhiteSmoke;
            lblAtualizacoes1.BackColor = Color.WhiteSmoke;
        }

        private void lblAtualizacoes_MouseLeave(object sender, EventArgs e)
        {
            lblAtualizacoes.BackColor = Color.LightGray;
            lblAtualizacoes1.BackColor = Color.LightGray;
        }

        private void lblLicenca_MouseMove(object sender, MouseEventArgs e)
        {
            lblLicenca.BackColor = Color.WhiteSmoke;
            lblLicenca1.BackColor = Color.WhiteSmoke;
        }

        private void lblLicenca_MouseLeave(object sender, EventArgs e)
        {
            lblLicenca.BackColor = Color.LightGray;
            lblLicenca1.BackColor = Color.LightGray;
        }

        private void lblLayout_MouseMove(object sender, MouseEventArgs e)
        {
            lblLayout.BackColor = Color.WhiteSmoke;
            lblLayout1.BackColor = Color.WhiteSmoke;
        }

        private void lblLayout_MouseLeave(object sender, EventArgs e)
        {
            lblLayout.BackColor = Color.LightGray;
            lblLayout1.BackColor = Color.LightGray;
        }

        private void lblUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            lblUsuario.BackColor = Color.WhiteSmoke;
            lblUsuario1.BackColor = Color.WhiteSmoke;
        }

        private void lblUsuario_MouseLeave(object sender, EventArgs e)
        {
            lblUsuario.BackColor = Color.LightGray;
            lblUsuario1.BackColor = Color.LightGray;
        }

        private void lblSobre_MouseMove(object sender, MouseEventArgs e)
        {
            lblSobre.BackColor = Color.WhiteSmoke;
            lblSobre1.BackColor = Color.WhiteSmoke;
        }

        private void lblSobre_MouseLeave(object sender, EventArgs e)
        {
            lblSobre.BackColor = Color.LightGray;
            lblSobre1.BackColor = Color.LightGray;
        }

        private void lblSair_MouseMove(object sender, MouseEventArgs e)
        {
            lblSair.BackColor = Color.WhiteSmoke;
            lblSair1.BackColor = Color.WhiteSmoke;
        }

        private void lblSair_MouseLeave(object sender, EventArgs e)
        {
            lblSair.BackColor = Color.LightGray;
            lblSair1.BackColor = Color.LightGray;
        }

        private void lblAtualizacoes_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 13;
            DialogResult = DialogResult.OK;
        }

        private void lblBackup_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 14;
            DialogResult = DialogResult.OK;
        }

        private void lblLicenca_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 15;
            DialogResult = DialogResult.OK;
        }

        private void lblLayout_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 16;
            DialogResult = DialogResult.OK;
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 17;
            DialogResult = DialogResult.OK;
        }

        private void lblSobre_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 18;
            DialogResult = DialogResult.OK;
        }

        private void lblSair_Click(object sender, EventArgs e)
        {
            bllVenda._Opcao_Menu_BigPicture = 19;
            DialogResult = DialogResult.OK;
        }
    }
}
