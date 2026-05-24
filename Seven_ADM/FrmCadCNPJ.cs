using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Seven_ADM
{
    public partial class FrmCadCNPJ : Form
    {
        public FrmCadCNPJ(string usuario, string cod_pdv_computador, byte formulario)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = formulario;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;
        private byte _Formulario;

        private void FrmCadCNPJ_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadCNPJ iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadCNPJ iniciado.");
                }
                //
                mtxtCNPJ.Select();
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadCNPJ.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmCadCNPJ.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmCadCNPJ_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmCadCNPJ_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadCNPJ foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmCadCNPJ foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadCNPJ.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmCadCNPJ.");
                }
            }
        }

        private void mtxtCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnIncluir.Select();
            }
        }

        private void mtxtCNPJ_Leave(object sender, EventArgs e)
        {
            try
            {
                mtxtCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtCNPJ.Text != "")
                {
                    if (ValidarCNPJECPF.ValidaCNPJ(mtxtCNPJ.Text))
                    {
                        mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                    else
                    {
                        MessageBox.Show("CNPJ inválido.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.DialogResult = DialogResult.None;
                        mtxtCNPJ.Text = null;
                        mtxtCNPJ.Select();
                    }
                }
                else
                {
                    mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtCNPJ.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtCNPJ.");
                }
                mtxtCNPJ.Text = null;
            }
            mtxtCNPJ.BackColor = Color.White;
        }

        private void mtxtCNPJ_Enter(object sender, EventArgs e)
        {
            mtxtCNPJ.BackColor = Color.LightBlue;
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
                mtxtCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                if (mtxtCNPJ.Text.Trim() == "")
                {
                    MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: \n[ CNPJ ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtCNPJ.Select();
                }
                else
                {
                    mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    if (_Formulario == 0)
                    {
                        if (bllClieCons.Sel_Clie_CPFCNPJ(mtxtCNPJ.Text) != null)
                        {
                            MessageBox.Show("O CNPJ informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //
                            bllClieCons._CNPJ_PesqCNPJ_Tabela = mtxtCNPJ.Text;
                            //
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            mtxtCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            //
                            string cnpj = mtxtCNPJ.Text;
                            //
                            mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            //
                            ValidarCNPJECPF.BuscarCNPJ(mtxtCNPJ.Text, cnpj, _Cod_PDV_Computador, _Formulario, _Usuario);
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 1)
                    {
                        if (bllFornecedor.Sel_F_Cnpj(mtxtCNPJ.Text) != null)
                        {
                            MessageBox.Show("O CNPJ informado já está cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            //
                            bllFornecedor._CNPJ_PesqCNPJ_Tabela = mtxtCNPJ.Text;
                            //
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            mtxtCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            //
                            string cnpj = mtxtCNPJ.Text;
                            //
                            mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                            //
                            ValidarCNPJECPF.BuscarCNPJ(mtxtCNPJ.Text, cnpj, _Cod_PDV_Computador, _Formulario, _Usuario);
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    else if (_Formulario == 2)
                    {
                        mtxtCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        //
                        string cnpj = mtxtCNPJ.Text;
                        //
                        mtxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        //
                        ValidarCNPJECPF.BuscarCNPJ(mtxtCNPJ.Text, cnpj, _Cod_PDV_Computador, _Formulario, _Usuario);
                        //
                        MessageBox.Show("Os dados foram salvos com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
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
                bllFornecedor._CNPJ_PesqCNPJ_Tabela = null;
                bllClieCons._CNPJ_PesqCNPJ_Tabela = null;
            }
        }
    }
}
