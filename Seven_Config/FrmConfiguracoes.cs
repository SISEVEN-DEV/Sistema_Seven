using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using System.IO;

namespace SIE_7_Sistema
{
    public partial class FrmConfiguracoes : Form
    {
        public FrmConfiguracoes()
        {
            InitializeComponent();
        }

        private void FrmContTipoIndicacao_Load(object sender, EventArgs e)
        {
          
        }

        public void BarExample() 
        {
                    }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Preencher caminho onde imagens temporárias do cadastro de alunos, fornecedores, produtos, professores, usuários e livros serão salvas.\nImagem Temporária - São imagens em que se é usada uma camera ligada ao computador para tirar uma foto, essas imagens precisam ser salvas em algum lugar do computador antes de salvar a mesma no diretório do sistema.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtSalvarImagem_Enter(object sender, EventArgs e)
        {
          
        }

        private void txtSalvarImagem_Leave(object sender, EventArgs e)
        {
           
        }

      

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
      
        private void btnAlterar_Click(object sender, EventArgs e)
        {
           
        }

        private void txtImagemLocal7Dir_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtImagemLocal7Dir_Leave(object sender, EventArgs e)
        {
        }

        private void txtImagemLocal7Dir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
            
            }
        }

        private void txtImagemLocal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) 
            {
                
            }
        }

        private void pcibInterrogacao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Preencher caminho onde imagens ficarão salvas, por esse caminho ficará salvo a url no banco de dados, escolher preferencialmente a pasta documentos no diretório 7 Sistema - SIE.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pcibInterrogacao2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pcibInterrogacao2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        } 

        private void pcibInterrogacao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("É o caminho onde fica um arquivo txt que contém o ultimo código de uma determinada tabela. Ele é necessário para saber o código da pasta onde serão salvas as imagens.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtVelocidadeLetreiro_Enter(object sender, EventArgs e)
        {
            txtVelocidadeLetreiro.BackColor = Color.LightBlue;
        }

        private void txtVelocidadeLetreiro_Leave(object sender, EventArgs e)
        {
            txtVelocidadeLetreiro.BackColor = Color.White;
        }

        private void txtVelocidadeLetreiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                btnIncluirMensagemSistema.Select();
            }
        }

        private void btnIncluirMensagemSistema_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnIncluirMensagemSistema_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnIncluirMensagemSistema_Click(object sender, EventArgs e)
        {
            using (FrmMensagemLetreiro Letreiro = new FrmMensagemLetreiro()) 
            {
                if (Letreiro.ShowDialog() == DialogResult.Abort) 
                {
                    btnIncluirMensagemSistema.Select();    
                }            
            }            
        }

        private void chkbTrocoCartaoContaPagar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbTrocoCartaoContaPagar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbTrocoCartaoContaReceber_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbTrocoCartaoContaReceber_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDigitalizacao7Dir_Enter(object sender, EventArgs e)
        {
    
        }

        private void txtDigitalizacao7Dir_Leave(object sender, EventArgs e)
        {
          
        }

        private void txtDigitalizacao7Dir_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void chkbContaFechadaExcluir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbContaFechadaExcluir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbContaFechadaAlterar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbContaFechadaAlterar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEnviarEmail_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnEnviarEmail_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            using (FrmConfEnviarEmailFeedback Email = new FrmConfEnviarEmailFeedback()) 
            {
                if (Email.ShowDialog() == DialogResult.Abort) 
                {
                    btnEnviarEmail.Select();
                }
            }
        }

        private void btnLembrete_Click(object sender, EventArgs e)
        {
            using (FrmConfUtilLembretes Lemb = new FrmConfUtilLembretes()) 
            {
                if (Lemb.ShowDialog() == DialogResult.Abort) 
                {
                    btnLembrete.Select();
                }
            }
        }

        private void btnLembrete_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnLembrete_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCadAluno_Click(object sender, EventArgs e)
        {
            using (FrmConfCliente Aluno = new FrmConfCliente()) 
            {
                if (Aluno.ShowDialog() == DialogResult.Abort) 
                {
                    btnCadAluno.Select();
                }
            }
        }

        private void btnCadAluno_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCadAluno_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (FrmConfCadComp Comp = new FrmConfCadComp(0)) 
            {
                if (Comp.ShowDialog() == DialogResult.Abort) 
                {
                    btnCadastroComp.Select();
                }      
            }
        }

        private void btnCadFuncao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCadFuncao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCadFornecedor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnCadFornecedor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnCadFornecedor_Click(object sender, EventArgs e)
        {
            using (FrmConfFuncionario Func = new FrmConfFuncionario())
            {
                if (Func.ShowDialog() == DialogResult.Abort)
                {
                    btnCadFuncionario.Select();
                }
            }            
        }

        private void btnArquivo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnArquivo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }      

        private void btnContasPagar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnContasPagar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnContasPagar_Click(object sender, EventArgs e)
        {
            using (FrmConfContaPagar Conta = new FrmConfContaPagar()) 
            {
                if (Conta.ShowDialog() == DialogResult.Abort) 
                {
                    btnContasPagar.Select();
                }
            }
        }

        private void btnFornecedor_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnFornecedor_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            using (FrmConfFornecedor Forn = new FrmConfFornecedor()) 
            {
                if (Forn.ShowDialog() == DialogResult.Abort) 
                {
                    btnFornecedor.Select();
                }            
            }
        }

        private void btnGrupoSubGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnGrupoSubGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnGrupoSubGrupo_Click(object sender, EventArgs e)
        {
            using (FrmConfGrupo Grupo = new FrmConfGrupo())
            {
                if (Grupo.ShowDialog() == DialogResult.Abort)
                {
                    btnGrupo.Select();
                }
            }
        }

        private void btnContaReceber_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnContaReceber_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnContaReceber_Click(object sender, EventArgs e)
        {
            using (FrmConfContaReceber Conta = new FrmConfContaReceber()) 
            {
                if (Conta.ShowDialog() == DialogResult.Abort) 
                {
                    btnContaReceber.Select();
                }            
            }
        }

        private void btnFormaPagamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnFormaPagamento_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnFormaPagamento_Click(object sender, EventArgs e)
        {
            using (FrmConfCadFormaPagamento Pag = new FrmConfCadFormaPagamento())
            {
                if (Pag.ShowDialog() == DialogResult.Abort)
                {
                    btnFormaPagamento.Select();
                }
            }
        }

        private void chkbGerarLog_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbGerarLog_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnArquivo_Click(object sender, EventArgs e)
        {
            using (FrmConfProduto Prod = new FrmConfProduto())
            {
                if (Prod.ShowDialog() == DialogResult.Abort)
                {
                    btnProduto.Select();
                }
            }
        }

        private void btnOrcamento_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnOrcamento_Click(object sender, EventArgs e)
        {
            using (FrmConfOrcamento Orc = new FrmConfOrcamento())
            {
                if (Orc.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void btnSMS_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSMS_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSMS_Click(object sender, EventArgs e)
        {
            using(FrmConfSMS SMS = new FrmConfSMS())
            {
                if (SMS.ShowDialog() == DialogResult.Abort)
                {

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FrmConfLocalArquivosSistema Arq = new FrmConfLocalArquivosSistema())
            {
                if (Arq.ShowDialog() == DialogResult.Abort)
                {

                }
            }
        }

        private void btnSubGrupo_Click(object sender, EventArgs e)
        {
            using (FrmConfSubGrupo Sub = new FrmConfSubGrupo())
            {
                if (Sub.ShowDialog() == DialogResult.Abort)
                {
                    btnSubGrupo.Select();
                }
            }
        }

        private void FrmConfiguracoes_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void FrmConfiguracoes_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSubGrupo_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSubGrupo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void chkbVerConAIni_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void chkbVerConAIni_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnUsuario_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            using (FrmConfUsuario User = new FrmConfUsuario())
            {
                if (User.ShowDialog() == DialogResult.Abort)
                {
                    btnUsuario.Select();
                }
            }
        }

        private void btnConexao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnConexao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnConexao_Click(object sender, EventArgs e)
        {
            using (FrmConfConexao Conect = new FrmConfConexao())
            {
                if (Conect.ShowDialog() == DialogResult.Abort)
                {
                    btnConexao.Select();
                }
            }
        }

        private void btnRegistroAtividades_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnRegistroAtividades_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRegistroAtividades_Click(object sender, EventArgs e)
        {
            using (FrmConfRegistroAtividades Reg = new FrmConfRegistroAtividades())
            {
                if (Reg.ShowDialog() == DialogResult.Abort)
                {
                    btnRegistroAtividades.Select();
                }
            }
        }

        private void btnMarca_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnMarca_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            using (FrmConfMarca Marca = new FrmConfMarca())
            {
                if (Marca.ShowDialog() == DialogResult.Abort)
                {
                    btnMarca.Select();
                }
            }
        }
    }
}
