using BLL;
using Seven_Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seven_ADM
{
    public partial class FrmCadCelular : Form
    {
        public FrmCadCelular(string usuario, string cod_pdv_computador, byte formulario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = formulario;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;
        private byte _Formulario;

        private void FrmCadCelular_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadCelular iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadCelular iniciado.");
                }
                //
                mtxtCelular.Select();
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadCelular.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadCelular.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmCadCelular_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmCadCelular_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadCelular foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadCelular foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadCelular.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadCelular.");
                }
            }
        }

        private void mtxtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnIncluir.Select();
            }
        }

        private void mtxtCelular_Enter(object sender, EventArgs e)
        {
            mtxtCelular.BackColor = Color.LightBlue;
        }

        private void mtxtCelular_Leave(object sender, EventArgs e)
        {
            mtxtCelular.BackColor = Color.White;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                btnIncluir.Select();
                mtxtCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if (mtxtCelular.Text.Trim() == "")
                {
                    MessageBox.Show("Existe um campo obrigatório que precisa ser preenchido: \n[ Celular ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    mtxtCelular.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtCelular.Select();
                }
                else
                {
                    mtxtCelular.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    if (_Formulario == 0)
                    {
                        bllOS._Celular_CadCelular_Tabela = mtxtCelular.Text;
                    }
                    else if (_Formulario == 1)
                    {
                        bllOrcamento._Celular_CadCelular_Tabela = mtxtCelular.Text;
                    }
                    else if (_Formulario == 2)
                    {
                        bllVenda._Celular_CadCelular_Tabela = mtxtCelular.Text;
                    }
                    else if (_Formulario == 3)
                    {
                        bllDocumentos._Celular_CadCelular_Tabela = mtxtCelular.Text;
                    }
                    //
                    bllRegistroAtividades.Salvar("INFORMOU UM CELULAR", "CELULAR", "0", _Usuario, _Cod_PDV_Computador);
                    //
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIncluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnIncluir.");
                }
                //
                if (_Formulario == 0)
                {
                    bllOS._Celular_CadCelular_Tabela = null;
                }
                else if (_Formulario == 1)
                {
                    bllOrcamento._Celular_CadCelular_Tabela = null;
                }
                else if (_Formulario == 2)
                {
                    bllVenda._Celular_CadCelular_Tabela = null;
                }
                else if (_Formulario == 3)
                {
                    bllDocumentos._Celular_CadCelular_Tabela = null;
                }
            }
        }

        private void grbBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnProcurarCliente_Click(object sender, EventArgs e)
        {
            using (FrmPesqCliente Clie = new FrmPesqCliente(16, _Usuario, _Cod_PDV_Computador))
            {
                if (Clie.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        mtxtCelular.Text = bllDocumentos._Celular_CadCelular_Tabela + ";";
                        bllDocumentos._Celular_CadCelular_Tabela = null;
                        mtxtCelular.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCliente.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCliente.");
                        }
                        mtxtCelular.Text = null;
                        bllDocumentos._Celular_CadCelular_Tabela = null;
                    }
                }
            }
        }

        private void btnPesquisarForn_Click(object sender, EventArgs e)
        {
            using (FrmPesqFornecedor Forn = new FrmPesqFornecedor(9, _Usuario, _Cod_PDV_Computador))
            {
                if (Forn.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        mtxtCelular.Text = bllDocumentos._Celular_CadCelular_Tabela + ";";
                        bllDocumentos._Celular_CadCelular_Tabela = null;
                        mtxtCelular.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCliente.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCliente.");
                        }
                        mtxtCelular.Text = null;
                        bllDocumentos._Celular_CadCelular_Tabela = null;
                    }
                }
            }
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            using (FrmPesqFuncionario Func = new FrmPesqFuncionario(11, _Usuario, _Cod_PDV_Computador))
            {
                if (Func.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        mtxtCelular.Text = bllDocumentos._Celular_CadCelular_Tabela + ";";
                        bllDocumentos._Celular_CadCelular_Tabela = null;
                        mtxtCelular.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCliente.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarCliente.");
                        }
                        mtxtCelular.Text = null;
                        bllDocumentos._Celular_CadCelular_Tabela = null;
                    }
                }
            }
        }
    }
}
