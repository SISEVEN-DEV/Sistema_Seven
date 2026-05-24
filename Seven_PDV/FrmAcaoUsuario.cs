using BLL;
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

namespace Seven_Sistema
{
    public partial class FrmAcaoUsuario : Form
    {
        public FrmAcaoUsuario(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Usuario;
        private string  _Cod_PDV_Computador;

        private void FrmTipoHistCaixa_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"C:\7 Sistema\Config\Log\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\7 Sistema\Config\Log\Log de Acoes");
                }
                if (!Directory.Exists(@"C:\Windows\Temp\7 Sistema\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Windows\Temp\7 Sistema\Log de Acoes");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAcaoUsuario iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAcaoUsuario iniciado.");
                }
                btnUsuario.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmAcaoUsuario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmAcaoUsuario.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnTodasContas_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnTodasContas_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnImprimir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnImprimir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnImprimirMatricial_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnImprimirMatricial_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmTipoHistCaixa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            using (FrmRelHistCaixa Caix = new FrmRelHistCaixa(_Usuario, _Cod_PDV_Computador))
            {
                if (Caix.ShowDialog() == DialogResult.Abort)
                {
                    this.DialogResult = DialogResult.Abort;
                }
            }
        }

        private void btnImprimirMatricial_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllVenda.Sel_Dados_Usuario_PDV(_Usuario) == null)
                {
                    MessageBox.Show("Não existem informações de funcionário cadastradas para este usuário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.Abort;
                }
                else
                {
                    DataRow dr = bllVenda.Sel_Dados_Usuario_PDV(_Usuario).Rows[0];
                    MessageBox.Show("Informações do Usuário:\n\nCódigo: " + dr["id_funcionario"].ToString() + "\nNome: " + dr["nome"].ToString() + "\nCPF: " + dr["cpf"].ToString() + "\nRG: " + dr["rg"].ToString() + "\nData de Nascimento: " + dr["data_nascimento"].ToString() + "\nEndereço: " + dr["endereco"].ToString() + "\nNúmero: " + dr["numero"].ToString() + "\nComplemento: " + dr["complemento"].ToString() + "\nBairro: " + dr["bairro"].ToString() + "\nUF: " + dr["uf"].ToString() + "\nCidade: " + dr["cidade"].ToString() + "\nCEP: " + dr["cep"].ToString() + "\nCelular: " + dr["celular"].ToString() + "\nTelefone: " + dr["telefone"].ToString() + "\nE-mail: " + dr["email"].ToString() + "\nSexo: " + dr["sexo"].ToString(), "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Abort;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnInformacao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnInformacao.");
                }
            }
        }

        private void btnTodasContas_Click(object sender, EventArgs e)
        {
            /*
            using (FrmLogin Login = new FrmLogin(1))
            {
                if (Login.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.Abort;
                }
            }
            */
        }

        private void picbInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Mudar de Usuário: Clique para alterar o usuário do sistema.\n\n2 - Histórico do Caixa: Clique para visualizar o histórico do caixa do usuário atual.\n\n3 - Informação: Clique para visualizar as informações do usuário atual.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void picbInterrogacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmTipoHistCaixa_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAcaoUsuario foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmAcaoUsuario foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\7 Sistema\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmAcaoUsuario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\7 Sistema\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do FrmAcaoUsuario.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}
