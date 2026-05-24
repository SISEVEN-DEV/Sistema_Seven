using BLL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmLoginUsuarioPerm : Form
    {
        public FrmLoginUsuarioPerm(string usuario, string cod_pdv_computador, string funcao)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Funcao = funcao;
        }

        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Funcao;

        private void FrmLoginUsuarioPerm_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLoginUsuarioPerm iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLoginUsuarioPerm iniciado.");
                }
                //
                txtUsuario.Select();
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmLoginUsuarioPerm.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmLoginUsuarioPerm.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            txtUsuario.BackColor = Color.LightBlue;
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.LightBlue;
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSenha.Select();
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Contains("'") || txtUsuario.Text.Contains(";") || txtUsuario.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtUsuario.Text = null;
            }
            txtUsuario.BackColor = Color.White;
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogar.Select();
            }
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            if (txtSenha.Text.Contains("'") || txtSenha.Text.Contains(";") || txtSenha.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtSenha.Text = null;
            }
            txtSenha.BackColor = Color.White;
        }

        private void FrmLoginUsuarioPerm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmLoginUsuarioPerm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLoginUsuarioPerm foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmLoginUsuarioPerm foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmLoginUsuarioPerm.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmLoginUsuarioPerm.");
                }
            }
        }

        private void btnVer_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnVer_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnLogar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnLogar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void picbInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (txtSenha.PasswordChar == '●')
            {
                txtSenha.PasswordChar = '\0';
            }
            else
            {
                txtSenha.PasswordChar = '●';
            }
            txtSenha.Select();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Campos [ Usuário ] e [ Senha ] são obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                try
                {
                    if (bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text) == null)
                    {
                        MessageBox.Show("O nome de Usuário e/ou Senha estão incorretos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        if (bllLogin.LoginSelectFuncao(txtUsuario.Text, txtSenha.Text, _Funcao) == true)
                        {
                            if (_Funcao == "Excluir_Item")
                            {
                                bllVenda._Excluir_Item = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " EXCLUIR ITEM/CANCELAR CUPOM.", "USUARIO", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            else if (_Funcao == "Realizar_Orcamento")
                            {
                                bllVenda._Realizar_Orcamento = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " REALIZAR ORCAMENTO.", "USUARIO", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            else if (_Funcao == "Realizar_Devolucao")
                            {
                                bllVenda._Realizar_Devolucao = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " REALIZAR DEVOLUCAO.", "USUARIO", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            else if (_Funcao == "Capturar_Orcamento")
                            {
                                bllVenda._Capturar_Orcamento = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " CAPTURAR ORCAMENTO.", "USUARIO", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            else if (_Funcao == "Capturar_Devolucao")
                            {
                                bllVenda._Capturar_Devolucao = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " CAPTURAR DEVOLUCAO.", "USUARIO", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            else if (_Funcao == "Permitir_Desc_Pag")
                            {
                                bllVenda._Permitir_Desc_Pag = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " APLICAR DESCONTO NO PAGAMENTO.", "USUARIO", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            else if (_Funcao == "Permitir_Acresc_Pag")
                            {
                                bllVenda._Permitir_Acresc_Pag = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " APLICAR ACRÉSCIMO NO PAGAMENTO.", "USUARIO", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            else if (_Funcao == "Permitir_Fin_PDV")
                            {
                                bllVenda._Permitir_Fin_PDV = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " FINALIZAR SISTEMA SEVEN - PDV.", "USUARIO", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            else if (_Funcao == "Permitir_Alt_Prod_Item")
                            {
                                bllVenda._Permitir_Alt_Prod_Item = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " ALTERAR PRODUTO/ITEM.", "USUARIO", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            else if (_Funcao == "Permitir_Real_Conta_Receber")
                            {
                                bllVenda._Permitir_Real_Conta_Receber = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " REALIZAR RECEBIMENTOS.", "USUARIO", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            else if (_Funcao == "Permitir_Real_Conta_Pagar")
                            {
                                bllVenda._Permitir_Real_Conta_Pagar = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " REALIZAR PAGAMENTOS.", "USUARIO", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            else if (_Funcao == "Permitir_Real_SangSup")
                            {
                                bllVenda._Permitir_Real_SangSup = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " REALIZAR SANGRIA/SUPRIMENTO.", "USUARIO", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            else if (_Funcao == "Permitir_Abrir_Caixa")
                            {
                                bllVenda._Permitir_Abrir_Caixa = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " REALIZAR ABERTURA DE CAIXA.", "USUARIO", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            else if (_Funcao == "Permitir_Fechar_Caixa")
                            {
                                bllVenda._Permitir_Fechar_Caixa = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " REALIZAR FECHAMENTO DE CAIXA.", "USUARIO", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            else if (_Funcao == "Permitir_Pausar_Caixa")
                            {
                                bllVenda._Permitir_Pausar_Caixa = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " REALIZAR PAUSA DE CAIXA.", "USUARIO", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            else if (_Funcao == "Permitir_Vis_Hist_Caixa")
                            {
                                bllVenda._Permitir_Vis_Hist_Caixa = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " VISUALIZAR HISTÓRICO DO CAIXA.", "USUARIO", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            else if (_Funcao == "Permitir_Venda_N_Prom_S_Credito")
                            {
                                bllVenda._Permitir_Venda_N_Prom_S_Credito = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " REALIZAR VENDA PARA CLIENTE SEM CREDITO.", "VENDAS", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            //
                            else if (_Funcao == "Permitir_Venda_S_Credito_Loja")
                            {
                                bllVenda._Permitir_Venda_S_Credito_Loja = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " REALIZAR VENDA PARA CLIENTE SEM CREDITO.", "VENDAS", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            //
                            else if (_Funcao == "Capturar_Venda")
                            {
                                bllVenda._Capturar_Venda = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " CAPTURAR VENDA.", "VENDAS", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            //
                            else if (_Funcao == "Desfazer_Baixa")
                            {
                                bllContasReceber._Desfazer_Baixa = 1;
                                //
                                string[] items = bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text).Split('—');
                                //
                                bllRegistroAtividades.Salvar("PERMITIU O USUARIO " + _Usuario.Replace("Usuário(a): ", "") + " DESFAZER BAIXA.", "CONTAS A RECEBER", "0", bllLogin.LoginSelect(txtUsuario.Text, txtSenha.Text), _Cod_PDV_Computador);
                            }
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            if (_Funcao == "Excluir_Item")
                            {
                                bllVenda._Excluir_Item = 0;
                            }
                            else if (_Funcao == "Realizar_Orcamento")
                            {
                                bllVenda._Realizar_Orcamento = 0;
                            }
                            else if (_Funcao == "Realizar_Devolucao")
                            {
                                bllVenda._Realizar_Devolucao = 0;
                            }
                            else if (_Funcao == "Capturar_Orcamento")
                            {
                                bllVenda._Capturar_Orcamento = 0;
                            }
                            else if (_Funcao == "Capturar_Devolucao")
                            {
                                bllVenda._Capturar_Devolucao = 0;
                            }
                            else if (_Funcao == "Permitir_Desc_Pag")
                            {
                                bllVenda._Permitir_Desc_Pag = 0;
                            }
                            else if (_Funcao == "Permitir_Acresc_Pag")
                            {
                                bllVenda._Permitir_Acresc_Pag = 0;
                            }
                            else if (_Funcao == "Permitir_Fin_PDV")
                            {
                                bllVenda._Permitir_Fin_PDV = 0;
                            }
                            else if (_Funcao == "Permitir_Alt_Prod_Item")
                            {
                                bllVenda._Permitir_Alt_Prod_Item = 0;
                            }
                            else if (_Funcao == "Permitir_Real_Conta_Receber")
                            {
                                bllVenda._Permitir_Real_Conta_Receber = 0;
                            }
                            else if (_Funcao == "Permitir_Real_Conta_Pagar")
                            {
                                bllVenda._Permitir_Real_Conta_Pagar = 0;
                            }
                            else if (_Funcao == "Permitir_Real_SangSup")
                            {
                                bllVenda._Permitir_Real_SangSup = 0;
                            }
                            else if (_Funcao == "Permitir_Abrir_Caixa")
                            {
                                bllVenda._Permitir_Abrir_Caixa = 0;
                            }
                            else if (_Funcao == "Permitir_Fechar_Caixa")
                            {
                                bllVenda._Permitir_Fechar_Caixa = 0;
                            }
                            else if (_Funcao == "Permitir_Pausar_Caixa")
                            {
                                bllVenda._Permitir_Pausar_Caixa = 0;
                            }
                            else if (_Funcao == "Permitir_Vis_Hist_Caixa")
                            {
                                bllVenda._Permitir_Vis_Hist_Caixa = 0;
                            }
                            else if (_Funcao == "_Permitir_Venda_N_Prom_S_Credito")
                            {
                                bllVenda._Permitir_Venda_N_Prom_S_Credito = 0;
                            }
                            else if (_Funcao == "Permitir_Venda_S_Credito_Loja")
                            {
                                bllVenda._Permitir_Venda_S_Credito_Loja = 0;
                            }
                            else if (_Funcao == "Capturar_Venda")
                            {
                                bllVenda._Capturar_Venda = 0;
                            }
                            else if (_Funcao == "Desfazer_Baixa")
                            {
                                bllContasReceber._Desfazer_Baixa = 0;
                            }
                            //
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
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnLogar.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnLogar.");
                    }
                    txtUsuario.Select();
                }
            }
        }

        private void picbInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Informe o usuário e a senha de um usuário já cadastrado no sistema, que possua permissão para executar a ação requisitada anteriormente.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }
    }
}
