using BLL;
using System;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmDatePicker2 : Form
    {
        public FrmDatePicker2(byte _formulario)
        {
            InitializeComponent();
            _Formulario = _formulario;
        }

        public byte _Formulario;

        private void FrmContLembreteDatePicker_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSalvar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVoltar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_Formulario == 0)
            {
                bllLembrete._Data_DatePicker1 = dtpData.Text;
                bllLembrete._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 1)
            {
                bllContasPagar._Data_DatePicker1 = dtpData.Text;
                bllContasPagar._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 2)
            {
                bllContasReceber._Data_DatePicker1 = dtpData.Text;
                bllContasReceber._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 3)
            {
                bllVenda._Data_DatePicker1 = dtpData.Text;
                bllVenda._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 4)
            {
                bllProduto._Data_DatePicker1 = dtpData.Text;
                bllProduto._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 5)
            {
                bllHistCaixa._Data_DatePicker1 = dtpData.Text;
                bllHistCaixa._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 6)
            {
                bllSaidasProdutos._Data_DatePicker1 = dtpData.Text;
                bllSaidasProdutos._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 7)
            {
                bllEntradasProdutos._Data_DatePicker1 = dtpData.Text;
                bllEntradasProdutos._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 8)
            {
                bllAbert_Fech_Caixa._Data_DatePicker1 = dtpData.Text;
                bllAbert_Fech_Caixa._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 9)
            {
                bllFluxoCaixa._Data_DatePicker1 = dtpData.Text;
                bllFluxoCaixa._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 10)
            {
                bllSangriaSuprimento._Data_DatePicker1 = dtpData.Text;
                bllSangriaSuprimento._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 11)
            {
                bllDevolucao._Data_DatePicker1 = dtpData.Text;
                bllDevolucao._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 12)
            {
                bllOrcamento._Data_DatePicker1 = dtpData.Text;
                bllOrcamento._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 13)
            {
                bllRegistroAtividades._Data_DatePicker1 = dtpData.Text;
                bllRegistroAtividades._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 14)
            {
                bllSubGrupo._Data_DatePicker1 = dtpData.Text;
                bllSubGrupo._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 15)
            {
                bllGrupo._Data_DatePicker1 = dtpData.Text;
                bllGrupo._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 16)
            {
                bllFuncionario._Data_DatePicker1 = dtpData.Text;
                bllFuncionario._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 17)
            {
                bllClieCons._Data_DatePicker1 = dtpData.Text;
                bllClieCons._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 18)
            {
                bllUsuario._Data_DatePicker1 = dtpData.Text;
                bllUsuario._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 19)
            {
                bllLocalizacao._Data_DatePicker1 = dtpData.Text;
                bllLocalizacao._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 20)
            {
                bllGrupo._Data_DatePicker1 = dtpData.Text;
                bllGrupo._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 21)
            {
                bllControleCheque._Data_DatePicker1 = dtpData.Text;
                bllControleCheque._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 22)
            {
                bllDFe._Data_DatePicker1 = dtpData.Text;
                bllDFe._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 23)
            {
                bllValidade._Data_DatePicker1 = dtpData.Text;
                bllValidade._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 24)
            {
                bllAniversariante._Data_DatePicker1 = dtpData.Text;
                bllAniversariante._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 25)
            {
                bllInventario._Data_DatePicker1 = dtpData.Text;
                bllInventario._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 26)
            {
                bllOS._Data_DatePicker1 = dtpData.Text;
                bllOS._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 27)
            {
                bllNFSe._Data_DatePicker1 = dtpData.Text;
                bllNFSe._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 28)
            {
                bllComissao._Data_DatePicker1 = dtpData.Text;
                bllComissao._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else if (_Formulario == 29)
            {
                bllDocumentos._Data_DatePicker1 = dtpData.Text;
                bllDocumentos._Data_DatePicker2 = dtpData1.Text;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dtpData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dtpData1.Select();
            }
        }

        private void dtpData_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.IBeam;
        }

        private void dtpData_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmContLembreteDatePicker_Load(object sender, EventArgs e)
        {
            dtpData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dtpData1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dtpData.Select();
        }

        private void dtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSalvar.Select();
            }
        }

        private void dtpData1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.IBeam;
        }

        private void dtpData1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecione as datas nos campos acima.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtpData1_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
    }
}
