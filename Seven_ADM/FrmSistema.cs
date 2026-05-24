using ACBrLib.NFe;
using BLL;
using Seven_ADM;
using System;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmSistema : Form
    {
        public FrmSistema()
        {
            InitializeComponent();
        }

        private int _TamanhoMensagem;
        private int _TamanhoMensagemDecre;
        private string _Tipo_Mensagem;
        private int _Incremento = 0;
        private bool _ContEspaco = true;
        private string _Mensagem;
        private int _QuantLetreiro = 0;
        private byte _Cor;
        private bool _AtivarDesativarLet;
        private bool _Atualizacao_Disponivel = false;
        private bool _Sleep = true;
        private int _Tempo_Mostrar_Atualizacao = 0;
        private int _Tempo_Mostrar_Logado = 86400;
        private int _ContMostrar_Logado = 0;
        private bool _Mostrar_Mensagem = false;
        private bool _Reiniciar = false;
        private string _Versao = "1.0.22";
        private bool _Acesso_Negado = false;

        private void FrmSistema_Load(object sender, EventArgs e)
        {
            try
            {
                tslblUsuario.Text = "Usuário(a): " + bllConexao._Usuario;
                //
                if (bllCadastroComputadores.Sel_Computadores_Ver_Codigo(Environment.MachineName) == null)
                {
                    MessageBox.Show("Este computador não se encontra na lista de dispositivos cadastrados neste banco de dados, contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _Acesso_Negado = true;
                    Application.Exit();
                }
                else if (bllConexao.Sel_Computadores_Op_Ver_Codigo(bllConexao._Descricao_Entidade) != Environment.MachineName)
                {
                    MessageBox.Show("Este computador não se encontra na lista de dispositivos cadastrados, contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    _Acesso_Negado = true;
                    Application.Exit();
                }
                else
                {
                    //notifyIcon.BalloonTipText = "Olá também estarei por aqui para informar notificações e ajudar. Quando precisar é só clicar no meu ícone.";
                    //notifyIcon.ShowBalloonTip(1000);
                    //
                    TemporizadorAlarme.Start();
                    //
                    DataRow dr = bllCadastroComputadores.Sel_Computadores_Ver_Codigo(Environment.MachineName).Rows[0];
                    //
                    tslblVersao.Text = "Versão: " + _Versao + "/Nº Comp.: " + dr["id_cadastro_computadores"].ToString();
                    //
                    tsslblConexao.Text = "Servidor: " + bllConexao._Descricao_Conexao_Atual;
                    TemporizadorBancoDados.Start();
                    //
                    string[] items = tslblUsuario.Text.Remove(0, 12).Split('—');
                    //
                    bllRegistroAtividades.Salvar("O USUARIO " + tslblUsuario.Text.Remove(0, 12) + " LOGOU NO SISTEMA SEVEN ADM.", "USUARIO", "0", tslblUsuario.Text, tslblVersao.Text);
                    //
                    if (bllConfiguracaoSistema.Sel_Ativar_Letreiro(bllConexao._Codigo_Conexao) == true)
                    {
                        if (bllLetreiro.Sel_Mensagem_Letreiro() != null)
                        {
                            _AtivarDesativarLet = true;
                            dr = bllLetreiro.Sel_Mensagem_Letreiro().Rows[0];

                            _Mensagem = dr["mensagem"].ToString();
                            _TamanhoMensagem = dr["mensagem"].ToString().Length;
                            _TamanhoMensagemDecre = dr["mensagem"].ToString().Length;
                            _Tipo_Mensagem = dr["tipo"].ToString();
                            if (Convert.ToByte(dr["cor"]) == 0)
                            {
                                _Cor = 0;
                            }
                            else if (Convert.ToByte(dr["cor"]) == 1)
                            {
                                _Cor = 1;
                            }
                            TemporizadorLetreiro.Start();
                        }
                    }
                    //
                    if (bllMinhaEmpresa.Sel_Nome_Empresa() == null)
                    {
                        tslblEmpresa.Text = "Clique para inserir informações da Empresa.";
                    }
                    else
                    {
                        tslblEmpresa.Text = @bllMinhaEmpresa.Sel_Nome_Empresa().Replace("&", "&&");
                    }
                    //
                    if (Screen.PrimaryScreen.Bounds.Width == 1280 & Screen.PrimaryScreen.Bounds.Height == 720)
                    {
                        tstbBarraDaEsquerda.Size = new Size(200, 20);
                    }
                    else if (Screen.PrimaryScreen.Bounds.Width == 1366 & Screen.PrimaryScreen.Bounds.Height == 768)
                    {
                        tstbBarraDaEsquerda.Size = new Size(300, 20);
                    }
                    else if (Screen.PrimaryScreen.Bounds.Width == 1360 & Screen.PrimaryScreen.Bounds.Height == 768)
                    {
                        tstbBarraDaEsquerda.Size = new Size(300, 20);
                    }
                    else if (Screen.PrimaryScreen.Bounds.Width == 1440 & Screen.PrimaryScreen.Bounds.Height == 900)
                    {
                        tstbBarraDaEsquerda.Size = new Size(350, 20);
                    }
                    else if (Screen.PrimaryScreen.Bounds.Width == 1600 & Screen.PrimaryScreen.Bounds.Height == 900)
                    {
                        tstbBarraDaEsquerda.Size = new Size(450, 20);
                    }
                    else if (Screen.PrimaryScreen.Bounds.Width == 1920 & Screen.PrimaryScreen.Bounds.Height == 1080)
                    {
                        tstbBarraDaEsquerda.Size = new Size(550, 20);
                    }
                    //
                    if (bllLetreiro.Sel_Tipo_Letreiro_Existe("DFE") == true)
                    {
                        if (bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "") != null)
                        {
                            bllLetreiro.Alterar_Letreiro("Existe(m) " + bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "").Rows.Count + " DFe (NFe/NFCe) com status [ PENDENTE ] que ainda não foi(ram) verifcado(os).", "DFE");
                        }
                        else
                        {
                            bllLetreiro.Excluir_Letreiro("DFE");
                        }
                    }
                    else
                    {
                        if (bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "") != null)
                        {
                            bllLetreiro.Salvar_Letreiro("Existe(m) " + bllDFe.Sel_Dfe_Menu_NFe_NFCe("_", "_", "_", "_", "", "PENDENTE", "", "").Rows.Count + " DFe (NFe/NFCe) com status [ PENDENTE ] que ainda não foi(ram) verifcado(os).", "1", "DFE");
                        }
                        else
                        {
                            bllLetreiro.Excluir_Letreiro("DFE");
                        }
                    }
                    //
                    if (bllLetreiro.Sel_Tipo_Letreiro_Existe("LEMBRETE") == true)
                    {
                        if (bllLembrete.Sel_Lembrete_Todos("PENDENTE") != null)
                        {
                            bllLetreiro.Alterar_Letreiro("Existe(m) " + bllLetreiro.Sel_Quantidade_Lembrete() + " lembrete(es) pendente(s) que ainda não foi(ram) finalizado(os).", "LEMBRETE");
                        }
                        else
                        {
                            bllLetreiro.Excluir_Letreiro("LEMBRETE");
                        }
                    }
                    else
                    {
                        if (bllLembrete.Sel_Lembrete_Todos("PENDENTE") != null)
                        {
                            bllLetreiro.Salvar_Letreiro("Existe(m) " + bllLetreiro.Sel_Quantidade_Lembrete() + " lembrete(es) pendente(s) que ainda não foi(ram) finalizado(os).", "1", "LEMBRETE");
                        }
                        else
                        {
                            bllLetreiro.Excluir_Letreiro("LEMBRETE");
                        }
                    }
                    //
                    if (Convert.ToInt32(bllLetreiro.Sel_Quantidade_Lembrete()) >= 1 & bllLetreiro.Sel_Tipo_Letreiro_Existe("LEMBRETE") == false)
                    {
                        bllLetreiro.Salvar_Letreiro("Existe(m) " + bllLetreiro.Sel_Quantidade_Lembrete() + " lembrete(es) pendente(s) que ainda não foi(ram) finalizado(os).", "1", "LEMBRETE");
                    }
                    //
                    if (bllConfiguracaoSistema.Sel_Imagem_Fundo_7_Adm(bllConexao._Codigo_Conexao) != null)
                    {
                        BackgroundImage = Image.FromFile(bllConfiguracaoSistema.Sel_Imagem_Fundo_7_Adm(bllConexao._Codigo_Conexao));
                        //
                        if (bllConfiguracaoSistema.Sel_Ajuste_Imagem_7_Adm(bllConexao._Codigo_Conexao) == "NORMAL")
                        {
                            this.BackgroundImageLayout = ImageLayout.None;
                        }
                        else if (bllConfiguracaoSistema.Sel_Ajuste_Imagem_7_Adm(bllConexao._Codigo_Conexao) == "ESTICADA")
                        {
                            this.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else if (bllConfiguracaoSistema.Sel_Ajuste_Imagem_7_Adm(bllConexao._Codigo_Conexao) == "AUTOMATICA")
                        {
                            this.BackgroundImageLayout = ImageLayout.Tile;
                        }
                        else if (bllConfiguracaoSistema.Sel_Ajuste_Imagem_7_Adm(bllConexao._Codigo_Conexao) == "CENTRALIZADA")
                        {
                            this.BackgroundImageLayout = ImageLayout.Center;
                        }
                        else if (bllConfiguracaoSistema.Sel_Ajuste_Imagem_7_Adm(bllConexao._Codigo_Conexao) == "AMPLIADA")
                        {
                            this.BackgroundImageLayout = ImageLayout.Zoom;
                        }
                    }
                    //
                    if (bllConfiguracaoSistema.Sel_Ver_Data_Hora_Internet(bllConexao._Codigo_Conexao) == true)
                    {
                        DateTime DataInternet = GetNetworkTime();
                        //
                        if (DataInternet.Day != DateTime.Now.Day)
                        {
                            MessageBox.Show("Atenção! Verifique se a data e a hora do seu computador estão corretas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else if (DataInternet.Month != DateTime.Now.Month)
                        {
                            MessageBox.Show("Atenção! Verifique se a data e a hora do seu computador estão corretas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Close();
                        }
                        else if (DataInternet.Year != DateTime.Now.Year)
                        {
                            this.Close();
                            MessageBox.Show("Atenção! Verifique se a data e a hora do seu computador estão corretas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    //
                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                    {
                        DialogResult = MessageBox.Show("Não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            using (FrmMinhaEmpresa Empresa = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Empresa.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString();
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tudo bem isso pode ser feito em um outro momento, porém algumas funções só estarão disponíveis após o cadastro das informações da empresa.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    //
                    if (bllLicenca.Verificar_Data_Licenca() != null)
                    {
                        DataRow drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                        //
                        if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 0)
                        {
                            using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("hoje em", drLic["data_expiracao"].ToString().Remove(10)))
                            {
                                if (LicEx.ShowDialog() == DialogResult.Yes)
                                {
                                    using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                    {
                                        if (Lic.ShowDialog() == DialogResult.OK)
                                        {
                                            drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                            //
                                            MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                        else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 1)
                        {
                            using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 1 dia.", drLic["data_expiracao"].ToString().Remove(10)))
                            {
                                if (LicEx.ShowDialog() == DialogResult.Yes)
                                {
                                    using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                    {
                                        if (Lic.ShowDialog() == DialogResult.OK)
                                        {
                                            drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                            //
                                            MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                        else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 2)
                        {
                            using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 2 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                            {
                                if (LicEx.ShowDialog() == DialogResult.Yes)
                                {
                                    using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                    {
                                        if (Lic.ShowDialog() == DialogResult.OK)
                                        {
                                            drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                            //
                                            MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                        else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 3)
                        {
                            using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 3 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                            {
                                if (LicEx.ShowDialog() == DialogResult.Yes)
                                {
                                    using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                    {
                                        if (Lic.ShowDialog() == DialogResult.OK)
                                        {
                                            drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                            //
                                            MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                        else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 4)
                        {
                            using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 4 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                            {
                                if (LicEx.ShowDialog() == DialogResult.Yes)
                                {
                                    using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                    {
                                        if (Lic.ShowDialog() == DialogResult.OK)
                                        {
                                            drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                            //
                                            MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                        else if ((Convert.ToDateTime(drLic["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 5)
                        {
                            using (FrmLicencaExpirar LicEx = new FrmLicencaExpirar("em 5 dias.", drLic["data_expiracao"].ToString().Remove(10)))
                            {
                                if (LicEx.ShowDialog() == DialogResult.Yes)
                                {
                                    using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                    {
                                        if (Lic.ShowDialog() == DialogResult.OK)
                                        {
                                            drLic = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                            //
                                            MessageBox.Show("Duração da licença: Até " + drLic["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //
                    if (bllConfiguracaoSistema.Sel_Buscar_Atualizacoes(bllConexao._Codigo_Conexao) == true) 
                    {
                        bckwInicio.RunWorkerAsync();
                        bckwIndeterminado.RunWorkerAsync();
                    }
                    //
                    TemporizadorLogin.Start();
                    //
                    ACBrNFe ACBrNFe;
                    if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini"))
                    {
                        ACBrNFe = new ACBrNFe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini");
                    }
                    else
                    {
                        ACBrNFe = new ACBrNFe();
                    }
                    //
                    if (ACBrNFe.Config.DFe.ArquivoPFX != "")
                    {
                        var ret = ACBrNFe.ObterCertificados();
                        //
                        string datavalidade = string.Join(Environment.NewLine, ret.Select(x => x.Vencimento.ToString()).ToArray());
                        //
                        if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays < 0)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual está expirado desde " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual está expirado desde " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //6
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual está expirado desde " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 0)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar hoje " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar hoje " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar hoje " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 1)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar amanhã " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar amanhã " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar amanhã " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 2)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 1 dia " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 1 dia " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 1 dia " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 3)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 2 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 2 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 2 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 4)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 3 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 3 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 3 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 5)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 4 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 4 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 4 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 6)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 5 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 5 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 5 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 7)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 6 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 6 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 6 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 8)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 7 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 7 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 7 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 9)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 8 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 8 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 8 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 10)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 9 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 9 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 9 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo um novoovar para continuar a emissão de NFe/NFCe/NFSe.\n\nContate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 11)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 10 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 10 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 10 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 12)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 11 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 11 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 11 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 13)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 12 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 12 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 12 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 14)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 13 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 13 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 13 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else if ((Convert.ToDateTime(datavalidade.Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays == 15)
                        {
                            if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CERTIFICADO") == true)
                            {
                                bllLetreiro.Alterar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 14 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "CERTIFICADO");
                            }
                            else
                            {
                                bllLetreiro.Salvar_Letreiro("ATENÇÃO! O seu Certificado Digital atual vai expirar em 14 dias " + datavalidade.Remove(10) + ". É necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe. Dúvidas contate o suporte.", "1", "CERTIFICADO");
                            }
                            //
                            MessageBox.Show("ATENÇÃO!\nO seu Certificado Digital atual vai expirar em 14 dias " + datavalidade.Remove(10) + ".\n\nÉ necessário adquirir um novo para continuar a emissão de NFe/NFCe/NFSe.\n\nDúvidas contate o suporte.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            bllLetreiro.Excluir_Letreiro("CERTIFICADO");
                        }
                    }
                    //

                    /*
                   var httpClient = new HttpClient();
                   //
                   var response = await httpClient.GetAsync("http://versao.siseven.com.br/");
                   //
                   var retorno = await response.Content.ReadAsStringAsync();
                   //
                   string[] versoes = retorno.Split(',');
                   //
                   if (versoes[0].Remove(0, 15).Replace("\"", "") != bllConfiguracaoSistema.Sel_Versao())
                   {
                       DialogResult = MessageBox.Show("Existe uma atualização disponível para o seu Software.\n\nDeseja atualizar agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                       if (DialogResult == DialogResult.Yes)
                       {
                           if (this.MdiChildren.Length > 0)
                           {
                               MessageBox.Show("Por favor, finalize os formulários abertos antes de executar a atualização.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                           }
                           else
                           {
                               using (FrmAtualizacao Atu = new FrmAtualizacao())
                               {
                                   if (Atu.ShowDialog() == DialogResult.OK)
                                   {

                                   }
                               }
                           }
                       }
                       else
                       {
                           TemporizadorVersao.Start();
                           _Atualizacao_Disponivel = true;
                       }
                   }
                   //
                   MessageBox.Show(versoes[0].Remove(0, 15).Replace("\"", ""));
                   */
                    /*
                    if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CONTA A RECEBER PENDENTE") == false & bllLetreiro.Sel_Quantidade_Conta_Receber() != null & bllLetreiro.Sel_Quantidade_Conta_Receber() != "0")
                    {
                        bllLetreiro.Salvar_Letreiro("Existe(m) " + bllLetreiro.Sel_Quantidade_Conta_Receber() + " Conta(s) a Receber vencida(s) pendente(s) que ainda não foi(ram) baixada(as).", "1", "CONTA A RECEBER PENDENTE");
                    }
                    //
                    if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CONTA A PAGAR PENDENTE") == false & bllLetreiro.Sel_Quantidade_Conta_Pagar() != null & bllLetreiro.Sel_Quantidade_Conta_Pagar() != "0")
                    {
                        bllLetreiro.Salvar_Letreiro("Existe(m) " + bllLetreiro.Sel_Quantidade_Conta_Pagar() + " Conta(s) a Pagar vencida(s) pendente(s) que ainda não foi(ram) baixada(as).", "1", "CONTA A PAGAR PENDENTE");
                    }
                    //
                    if (bllLetreiro.Sel_Tipo_Letreiro_Existe("CHEQUE PENDENTE") == false & bllLetreiro.Sel_Quantidade_Cheque() != null & bllLetreiro.Sel_Quantidade_Cheque() != "0")
                    {
                        bllLetreiro.Salvar_Letreiro("Existe(m) " + bllLetreiro.Sel_Quantidade_Cheque() + " Cheque(s) vencido(s) pendente(s) que ainda não foi(ram) baixado(os).", "1", "CHEQUE PENDENTE");
                    }
                    //
                    if (bllLetreiro.Sel_Tipo_Letreiro_Existe("ORCAMENTO PENDENTE") == false & bllLetreiro.Sel_Quantidade_Orcamento() != null & bllLetreiro.Sel_Quantidade_Orcamento() != "0")
                    {
                        bllLetreiro.Salvar_Letreiro("Existe(m) " + bllLetreiro.Sel_Quantidade_Orcamento() + " Orçamento(s) pendente(s) que ainda não foi(ram) realizado(os).", "1", "ORCAMENTO PENDENTE");
                    }
                    //
                    if (bllLetreiro.Sel_Tipo_Letreiro_Existe("DEVOLUCAO PENDENTE") == false & bllLetreiro.Sel_Quantidade_Devolucao() != null & bllLetreiro.Sel_Quantidade_Devolucao() != "0")
                    {
                        bllLetreiro.Salvar_Letreiro("Existe(m) " + bllLetreiro.Sel_Quantidade_Devolucao() + " Devolução(ões) pendente(s) que ainda não foi(ram) realizado(os).", "1", "ORCAMENTO PENDENTE");
                    }
                    */

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do FrmSistema.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do FrmSistema.");
                }
            }
        }

        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }

        public static DateTime GetNetworkTime()
        {
            //Servidor nacional para melhor latência
            const string ntpServer = "a.ntp.br";

            // Tamanho da mensagem NTP - 16 bytes (RFC 2030)
            var ntpData = new byte[48];

            //Indicador de Leap (ver RFC), Versão e Modo
            ntpData[0] = 0x1B; //LI = 0 (sem warnings), VN = 3 (IPv4 apenas), Mode = 3 (modo cliente)

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;

            //123 é a porta padrão do NTP
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            //NTP usa UDP
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socket.Connect(ipEndPoint);

            //Caso NTP esteja bloqueado, ao menos nao trava o app
            socket.ReceiveTimeout = 3000;

            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();

            //Offset para chegar no campo "Transmit Timestamp" (que é
            //o do momento da saída do servidor, em formato 64-bit timestamp
            const byte serverReplyTime = 40;

            //Pegando os segundos
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            //e a fração de segundos
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            //Passando de big-endian pra little-endian
            intPart = SwapEndianness(intPart);
            fractPart = SwapEndianness(fractPart);

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            //Tempo em **UTC**
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

            return networkDateTime.ToLocalTime();
        }

        void sClickFunc(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadFuncionario")
                {
                    f.Activate();
                }
            }
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (bllFuncionario._FrmCadFuncionario_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_Funcionarios(tslblUsuario.Text) == true)
                    {
                        FrmCadFuncionario Func = new FrmCadFuncionario(tslblUsuario.Text, tslblVersao.Text, 0);
                        Func.MdiParent = this;
                        Func.Show();
                        Func.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\user-worker.png");
                        tsb.Tag = "Funcionarios";
                        tsb.Text = "Cadastro de Funcionários";
                        tsb.ToolTipText = "Cadastro de Funcionários";
                        tsb.Name = "_FrmCadFuncionario_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickFunc;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Funcionários.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O fomulário Cadastro de Funcionários já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadFuncionario")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadFuncionario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadFuncionario.");
                }
            }
        }



        void sMouseMove(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        void sMouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickClie(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadClieCons")
                {
                    f.Activate();
                    //f.Enabled = true;
                }
                //
                //MessageBox.Show("A");
            }
        }

        private void alunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllClieCons._FrmCadClieCons_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_Cliente_Consumidor(tslblUsuario.Text) == true)
                    {
                        FrmCadClieCons Aluno = new FrmCadClieCons(tslblUsuario.Text, tslblVersao.Text, 0);
                        Aluno.MdiParent = this;
                        Aluno.Show();
                        Aluno.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\user-white.png");
                        tsb.Tag = "Cliente";
                        tsb.Text = "Cadastro de Clientes/Consumidores";
                        tsb.ToolTipText = "Cadastro de Clientes/Consumidores";
                        tsb.Name = "FrmCadClieCons";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickClie;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Clientes/Consumidores.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O fomulário Cadastro de Clientes já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadClieCons")
                        {
                            f.Activate();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadClieCons.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadClieCons.");
                }
            }
        }

        void sClickForn(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadFornecedor")
                {
                    f.Activate();
                }
            }
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (bllFornecedor._FrmCadFornecedor_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_Forncedores(tslblUsuario.Text) == true)
                    {
                        FrmCadFornecedor Forn = new FrmCadFornecedor(tslblUsuario.Text, tslblVersao.Text, 0);
                        Forn.MdiParent = this;
                        Forn.Show();
                        Forn.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\user-business-gray.png");
                        tsb.Tag = "Fornecedor";
                        tsb.Text = "Cadastro de Fornecedores";
                        tsb.ToolTipText = "Cadastro de Fornecedores";
                        tsb.Name = "_FrmCadFornecedor_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickForn;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Fornecedores.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O fomulário Cadastro de Fornecedores já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadFornecedor")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadFornecedor.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadFornecedor.");
                }
            }
        }

        void sClickContPag(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadContasPagar")
                {
                    f.Activate();
                }
            }
        }

        private void contasAPagarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllContasPagar._FrmCadContasPagar_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_Conta_Pagar(tslblUsuario.Text) == true)
                    {
                        FrmCadContasPagar Contas = new FrmCadContasPagar(0, tslblUsuario.Text, tslblVersao.Text, null);
                        Contas.MdiParent = this;
                        Contas.Show();
                        Contas.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\clipboard--plus.png");
                        tsb.Tag = "ContasAPagar";
                        tsb.Text = "Cadastro de Contas a Pagar";
                        tsb.ToolTipText = "Cadastro de Contas a Pagar";
                        tsb.Name = "_FrmCadContasPagar_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickContPag;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Contas a Pagar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O formulário Cadastro de Contas a Pagar já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadContasPagar")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadContasPagar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadContasPagar.");
                }
            }
        }

        void sClickContRec(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadContasReceber")
                {
                    f.Activate();
                }
            }
        }

        private void contasAReceberToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllContasReceber._FrmCadContaReceber_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_Conta_Receber(tslblUsuario.Text) == true)
                    {
                        FrmCadContasReceber Contas = new FrmCadContasReceber(tslblUsuario.Text, tslblVersao.Text);
                        Contas.MdiParent = this;
                        Contas.Show();
                        Contas.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\document--arrow.png");
                        tsb.Tag = "ContasAReceber";
                        tsb.Text = "Cadastro de Contas a Receber";
                        tsb.ToolTipText = "Cadastro de Contas a Receber";
                        tsb.Name = "_FrmCadContaReceber_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickContRec;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Contas a Receber.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O formulário Cadastro de Contas a Receber já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadContasReceber")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadContasReceber.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadContasReceber.");
                }
            }
        }

        void sClickRelContRec(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelContaReceber")
                {
                    f.Activate();
                }
            }
        }

        private void contasAReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllContasReceber._FrmRelContaReceber_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Contas_Receber(tslblUsuario.Text) == true)
                        {
                            FrmRelContaReceber Contas = new FrmRelContaReceber(tslblUsuario.Text, tslblVersao.Text);
                            Contas.MdiParent = this;
                            Contas.Show();
                            Contas.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\document--arrow.png");
                            tsb.Tag = "RelContasAReceber";
                            tsb.Text = "Relatório de Contas a Receber";
                            tsb.ToolTipText = "Relatório de Contas a Receber";
                            tsb.Name = "_FrmRelContaReceber_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelContRec;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Contas a Receber.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O formulário Relatório de Contas a Receber já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelContaReceber")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do contasAReceberToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do contasAReceberToolStripMenuItem.");
                }
            }
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void tslblUsuario_MouseMove(object sender, MouseEventArgs e)
        {
            tslblUsuario.ForeColor = Color.Red;
            this.Cursor = Cursors.Hand;
        }

        private void tslblUsuario_MouseLeave(object sender, EventArgs e)
        {
            tslblUsuario.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void tslblEmpresa_MouseMove(object sender, MouseEventArgs e)
        {
            tslblEmpresa.ForeColor = Color.Red;
            this.Cursor = Cursors.Hand;
        }

        private void tslblEmpresa_MouseLeave(object sender, EventArgs e)
        {
            tslblEmpresa.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        private void tslblVersao_MouseMove(object sender, MouseEventArgs e)
        {
            tslblVersao.ForeColor = Color.Red;
            this.Cursor = Cursors.Hand;
        }

        private void tslblVersao_MouseLeave(object sender, EventArgs e)
        {
            tslblVersao.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        //Letreiro
        private void TemporizadorLetreiro_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_TamanhoMensagemDecre != 0 & _ContEspaco == true)
                {
                    if (_Cor == 0)
                    {
                        tsslblMensagem.ForeColor = Color.Green;
                    }
                    else if (_Cor == 1)
                    {
                        tsslblMensagem.ForeColor = Color.Red;
                    }
                    tsslblMensagem.Text = tsslblMensagem.Text.Insert(_Incremento, _Mensagem.Substring(_Incremento, 1));
                    _Incremento = _Incremento + 1;
                    _TamanhoMensagemDecre = _TamanhoMensagemDecre - 1;
                }
                else
                {
                    if (tsslblMensagem.Text.Length == 500)
                    {
                        if (_TamanhoMensagem != _TamanhoMensagemDecre)
                        {
                            _ContEspaco = false;
                            tsslblMensagem.Text = "";
                            //
                            if (_QuantLetreiro < bllLetreiro.Sel_Mensagem_Letreiro().Rows.Count - 1)
                            {
                                _QuantLetreiro = _QuantLetreiro + 1;
                                _Incremento = 0;
                                _ContEspaco = true;
                                DataRow dr = bllLetreiro.Sel_Mensagem_Letreiro().Rows[_QuantLetreiro];
                                _Mensagem = dr["mensagem"].ToString();
                                _TamanhoMensagem = dr["mensagem"].ToString().Length;
                                _TamanhoMensagemDecre = dr["mensagem"].ToString().Length;
                                _Tipo_Mensagem = dr["tipo"].ToString();
                                if (Convert.ToByte(dr["cor"]) == 0)
                                {
                                    _Cor = 0;
                                }
                                else if (Convert.ToByte(dr["cor"]) == 1)
                                {
                                    _Cor = 1;
                                }
                            }
                            else
                            {
                                _QuantLetreiro = 0;
                                _Incremento = 0;
                                _ContEspaco = true;
                                DataRow dr = bllLetreiro.Sel_Mensagem_Letreiro().Rows[0];
                                _Mensagem = dr["mensagem"].ToString();
                                _TamanhoMensagem = dr["mensagem"].ToString().Length;
                                _TamanhoMensagemDecre = dr["mensagem"].ToString().Length;
                                if (Convert.ToByte(dr["cor"]) == 0)
                                {
                                    _Cor = 0;
                                }
                                else if (Convert.ToByte(dr["cor"]) == 1)
                                {
                                    _Cor = 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (_ContEspaco == true)
                        {
                            tsslblMensagem.Text = tsslblMensagem.Text + " ";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TemporizadorLetreiro.Stop();
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento tick do TemporizadorLetreiro.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento tick do TemporizadorLetreiro.");
                }
            }
        }

        public static bool Ativar_Mensagem_Notify_Alarme;

        private void tslblEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                {
                    foreach (DataRow dr in bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows)
                    {
                        MessageBox.Show("Nome/Razão Social: " + dr["nome"].ToString() + "\nCPF/CNPJ: " + dr["cpf_cnpj"].ToString() + "\nInscrição Estadual/RG: " + dr["ie_rg"].ToString() + "\nNome Fantasia: " + dr["fantasia"].ToString() + "\nEndereço/Logradouro: " + dr["endereco"].ToString() + "\nNumero: " + dr["numero"].ToString() + "\nBairro/Distrito: " + dr["bairro"].ToString() + "\nComplemento: " + dr["complemento"].ToString() + "\nReferência: " + dr["referencia"].ToString() + "\nUF: " + dr["UF"].ToString() + "\nCidade: " + dr["cidade"].ToString() + "\nLocalização: " + dr["localizacao"].ToString() + "\nCEP: " + dr["cep"].ToString() + "\nTelefone: " + dr["telefone"].ToString() + "\nCelular: " + dr["celular"].ToString() + "\nEmail: " + dr["email"].ToString(), "Informações da Empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão tslblEmpresa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão tslblEmpresa.");
                }
            }
        }

        private void cadastrarToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cadastrarToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tslblUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show(tslblUsuario.Text.Replace('—', '-'), "Informações do Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tslblVersao_Click(object sender, EventArgs e)
        {
            if (_Atualizacao_Disponivel == false)
            {
                using (FrmVersao Ver = new FrmVersao(_Versao))
                {
                    if (Ver.ShowDialog() == DialogResult.Abort)
                    {

                    }
                }
            }
            else
            {
                if (_Atualizacao_Disponivel == true)
                {
                    if (bckwIndeterminado.IsBusy == true)
                    {
                        MessageBox.Show("Sua solicitação está sendo processada. Por favor, aguarde um momento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        _Mostrar_Mensagem = true;
                        //
                        bckwIndeterminado.RunWorkerAsync();
                    }
                }
            }
        }

        private void programaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void programaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelContPag(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelContaPagar")
                {
                    f.Activate();
                }
            }
        }

        private void contasAPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllContasPagar._FrmRelContaPagar_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Contas_Pagar(tslblUsuario.Text) == true)
                        {
                            FrmRelContaPagar Conta = new FrmRelContaPagar(tslblUsuario.Text, tslblVersao.Text);
                            Conta.MdiParent = this;
                            Conta.Show();
                            Conta.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\clipboard--plus.png");
                            tsb.Tag = "RelContasAPagar";
                            tsb.Text = "Relatório de Contas a Pagar";
                            tsb.ToolTipText = "Relatório de Contas a Pagar";
                            tsb.Name = "_FrmRelContaPagar_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelContPag;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Contas a Pagar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Contas a Pagar já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelContaPagar")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do contasAPagarToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do contasAPagarToolStripMenuItem.");
                }
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Deseja finalizar o aplicativo Sistema SEVEN - ADM?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void movimentaçãoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void movimentaçãoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmSistema_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = MessageBox.Show("Deseja finalizar o aplicativo Sistema SEVEN - ADM?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else if (e.KeyCode == Keys.F1)
            {
                cadastrarToolStripMenuItem.ShowDropDown();
            }
            else if (e.KeyCode == Keys.F2)
            {
                movimentaçãoToolStripMenuItem.ShowDropDown();
            }
            else if (e.KeyCode == Keys.F3)
            {
                menuNFeNFCeToolStripMenuItem.ShowDropDown();
            }
            else if (e.KeyCode == Keys.F4)
            {
                ordemDeServiçoToolStripMenuItem1_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                utilitáriosToolStripMenuItem.ShowDropDown();
            }
            else if (e.KeyCode == Keys.F6)
            {
                suporteTécnicoToolStripMenuItem_Click(sender, e);
            }
        }

        private void cadastrarToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cadastrarToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void alunosToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void alunosToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void contasAPagarToolStripMenuItem1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void contasAPagarToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void contasAReceberToolStripMenuItem1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void contasAReceberToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cursoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cursoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void fornecedorToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void fornecedorToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void localToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void localToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void professorInstrutorToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void professorInstrutorToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void tipoDeIndicaçãoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void tipoDeIndicaçãoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void turmaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void turmaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void usuáriosToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void usuáriosToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void livroMóduloToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void livroMóduloToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void AppToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void AppToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void ajudaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void ajudaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void backupToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void backupToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void configuraçõesÁreaRestritaDestinadaAoSuporteToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void configuraçõesÁreaRestritaDestinadaAoSuporteToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void escolherImagemDoSistemaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void escolherImagemDoSistemaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void configuraçõesToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void configuraçõesToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void sobreToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void sobreToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void sairToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void sairToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void disciplinaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void disciplinaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelAniversariante(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelAniversario")
                {
                    f.Activate();
                }
            }
        }

        private void aniversáriantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllAniversariante._FrmRelAniversario_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Aniversariante(tslblUsuario.Text) == true)
                        {
                            FrmRelAniversario Aniv = new FrmRelAniversario(tslblVersao.Text, tslblUsuario.Text);
                            Aniv.MdiParent = this;
                            Aniv.Show();
                            Aniv.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\cake.png");
                            tsb.Tag = "RelAbertFech";
                            tsb.Text = "Relatório de Aniversariantes";
                            tsb.ToolTipText = "Relatório de Aniversariantes";
                            tsb.Name = "_FrmRelAniversario_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelAniversariante;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Aniversariantes.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Aniversariantes já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelAniversario")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do aniversáriantesToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do aniversáriantesToolStripMenuItem.");
                }
            }
        }

        void sClickProd(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadProduto")
                {
                    f.Activate();
                }
            }
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllProduto._FrmCadProduto_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_Produtos(tslblUsuario.Text) == true)
                    {
                        FrmCadProduto Prod = new FrmCadProduto(tslblUsuario.Text, tslblVersao.Text, 0);
                        Prod.MdiParent = this;
                        Prod.Show();
                        Prod.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\box.png");
                        tsb.Tag = "Produtos";
                        tsb.Text = "Cadastro de Produtos";
                        tsb.ToolTipText = "Cadastro de Produtos";
                        tsb.Name = "_FrmCadProduto_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickProd;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Produtos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O formulário Cadastro de Produtos já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadProduto")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadProduto.");
                }
            }
        }

        private void grupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bllGrupo._FrmCadGrupo_Ativo == false)
            {
                FrmCadGrupo Grupo = new FrmCadGrupo(tslblUsuario.Text, tslblVersao.Text);
                Grupo.MdiParent = this;
                Grupo.Show();
            }
            else
            {
                MessageBox.Show("O formulário Cadastro de Grupo já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void grupoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void grupoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void produtoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void produtoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void configuraçõesÁreaRestritaDestinadaAoSuporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string strHostName = Dns.GetHostName();

                Form[] mdichild = this.MdiChildren;

                if (this.MdiChildren.Length > 0)
                {
                    MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //if (bllUsuario.Sel_Permitir_Configurar(tslblUsuario.Text) == true)
                    //{
                    using (FrmLoginSuporte Login = new FrmLoginSuporte())
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            using (FrmConfiguracoes Config = new FrmConfiguracoes())
                            {
                                if (Config.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllConfiguracaoSistema.Sel_Imagem_Fundo_7_Adm(bllConexao._Codigo_Conexao) != "")
                                    {
                                        BackgroundImage =
                                        System.Drawing.Image.FromFile(bllConfiguracaoSistema.Sel_Imagem_Fundo_7_Adm(bllConexao._Codigo_Conexao));
                                        //
                                        if (bllConfiguracaoSistema.Sel_Ajuste_Imagem_7_Adm(bllConexao._Codigo_Conexao) == "NORMAL")
                                        {
                                            this.BackgroundImageLayout = ImageLayout.None;
                                        }
                                        else if (bllConfiguracaoSistema.Sel_Ajuste_Imagem_7_Adm(bllConexao._Codigo_Conexao) == "ESTICADA")
                                        {
                                            this.BackgroundImageLayout = ImageLayout.Stretch;
                                        }
                                        else if (bllConfiguracaoSistema.Sel_Ajuste_Imagem_7_Adm(bllConexao._Codigo_Conexao) == "AUTOMATICA")
                                        {
                                            this.BackgroundImageLayout = ImageLayout.Tile;
                                        }
                                        else if (bllConfiguracaoSistema.Sel_Ajuste_Imagem_7_Adm(bllConexao._Codigo_Conexao) == "CENTRALIZADA")
                                        {
                                            this.BackgroundImageLayout = ImageLayout.Center;
                                        }
                                        else if (bllConfiguracaoSistema.Sel_Ajuste_Imagem_7_Adm(bllConexao._Codigo_Conexao) == "AMPLIADA")
                                        {
                                            this.BackgroundImageLayout = ImageLayout.Zoom;
                                        }
                                    }
                                    else
                                    {
                                        this.BackgroundImage = null;
                                    }
                                    //
                                    if (bllConfiguracaoSistema.Sel_Ativar_Letreiro(bllConexao._Codigo_Conexao) == true & _AtivarDesativarLet == false)
                                    {
                                        _AtivarDesativarLet = true;
                                        DataRow dr = bllLetreiro.Sel_Mensagem_Letreiro().Rows[0];

                                        _Mensagem = dr["mensagem"].ToString();
                                        _TamanhoMensagem = dr["mensagem"].ToString().Length;
                                        _TamanhoMensagemDecre = dr["mensagem"].ToString().Length;
                                        if (Convert.ToByte(dr["cor"]) == 0)
                                        {
                                            _Cor = 0;
                                        }
                                        else if (Convert.ToByte(dr["cor"]) == 1)
                                        {
                                            _Cor = 1;
                                        }
                                        TemporizadorLetreiro.Start();
                                    }
                                    else if (bllConfiguracaoSistema.Sel_Ativar_Letreiro(bllConexao._Codigo_Conexao) == false)
                                    {
                                        _AtivarDesativarLet = false;
                                        TemporizadorLetreiro.Stop();
                                        tsslblMensagem.Text = "";
                                        _QuantLetreiro = 0;
                                        _Incremento = 0;
                                        _ContEspaco = true;
                                        _Mensagem = "";
                                        _TamanhoMensagem = 0;
                                        _TamanhoMensagemDecre = 0;
                                        _Cor = 0;
                                    }
                                    //
                                    if (bllConfiguracaoSistema.Sel_Resolucao_Pdv(bllConexao._Codigo_Conexao) == "1280 x 720")
                                    {
                                        tstbBarraDaEsquerda.Size = new Size(350, 20);
                                    }
                                    else if (bllConfiguracaoSistema.Sel_Resolucao_Pdv(bllConexao._Codigo_Conexao) == "1366 x 768")
                                    {
                                        tstbBarraDaEsquerda.Size = new Size(450, 20);
                                    }
                                    //
                                    if (bllConfiguracaoSistema.Sel_Ver_Data_Hora_Internet(bllConexao._Codigo_Conexao) == true)
                                    {
                                        DateTime DataInternet = GetNetworkTime();
                                        //
                                        if (DataInternet.Day != DateTime.Now.Day)
                                        {
                                            MessageBox.Show("Atenção! Verifique se a data e a hora do seu computador estão corretas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.Close();
                                        }
                                        else if (DataInternet.Month != DateTime.Now.Month)
                                        {
                                            MessageBox.Show("Atenção! Verifique se a data e a hora do seu computador estão corretas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            this.Close();
                                        }
                                        else if (DataInternet.Year != DateTime.Now.Year)
                                        {
                                            this.Close();
                                            MessageBox.Show("Atenção! Verifique se a data e a hora do seu computador estão corretas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    /*
                }
                else
                {
                    MessageBox.Show("O Usuário atual não possui permissão para acessar Configurações.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                    */
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do FrmSistema.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do FrmSistema.");
                }
            }
        }


        private void contasAPagarToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void contasAPagarToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmSistema_MdiChildActivate(object sender, EventArgs e)
        {
            if (bllClieCons._FrmCadClieCons_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["FrmCadClieCons"]);
            }
            //
            if (bllContasPagar._FrmCadContasPagar_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadContasPagar_Ativo"]);
            }
            //
            if (bllContasReceber._FrmCadContaReceber_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadContaReceber_Ativo"]);
            }
            //
            if (bllFornecedor._FrmCadFornecedor_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadFornecedor_Ativo"]);
            }
            //
            if (bllFuncionario._FrmCadFuncionario_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadFuncionario_Ativo"]);
            }
            //
            if (bllFormaPagamento._FrmCadFormaPagamento_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadFormaPagamento_Ativo"]);
            }
            //
            if (bllGrupo._FrmCadGrupo_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadGrupo_Ativo"]);
            }
            //
            if (bllProduto._FrmCadProduto_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadProduto_Ativo"]);
            }
            //
            if (bllSubGrupo._FrmCadSubgrupo_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadSubgrupo_Ativo"]);
            }
            //
            if (bllUsuario._FrmCadUsuario_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadUsuario_Ativo"]);
            }
            //
            if (bllMarca._FrmCadMarca_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadMarca_Ativo"]);
            }
            //
            if (bllAbert_Fech_Caixa._FrmRelCaixas_Aberto == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelCaixas_Aberto"]);
            }
            //
            if (bllClieCons._FrmRelCliente_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelCliente_Ativo"]);
            }
            //
            if (bllContasPagar._FrmRelContaPagar_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelContaPagar_Ativo"]);
            }
            //
            if (bllContasReceber._FrmRelContaReceber_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelContaReceber_Ativo"]);
            }
            //
            if (bllProduto._FrmRelProduto_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelProduto_Ativo"]);
            }
            //
            if (bllOrcamento._FrmRelOrcamento_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelOrcamento_Ativo"]);
            }
            //
            if (bllVenda._FrmRelVenda_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelVenda_Ativo"]);
            }
            //
            if (bllGrupo._FrmRelGrupo_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelGrupo_Ativo"]);
            }
            //
            if (bllFormaPagamento._FrmRelFormaPagamento_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelFormaPagamento_Ativo"]);
            }
            //
            if (bllFornecedor._FrmRelFornecedor_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelFornecedor_Ativo"]);
            }
            //
            if (bllSubGrupo._FrmRelSubgrupo_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelSubgrupo_Ativo"]);
            }
            //
            if (bllMarca._FrmRelMarca_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelMarca_Ativo"]);
            }
            //
            if (bllLocalizacao._FrmCadLocalizacaoProd_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadLocalizacaoProd_Ativo"]);
            }
            //
            if (bllLocalizacao._FrmRelLocalizacaoProd_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelLocalizacaoProd_Ativo"]);
            }
            //
            if (bllFluxoCaixa._FrmRelFluxoCaixa_Aberto == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelFluxoCaixa_Aberto"]);
            }
            //
            if (bllSaidasProdutos._FrmRelSaidasProdutos_Aberto == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelSaidasProdutos_Aberto"]);
            }
            //
            if (bllHistCaixa._FrmRelHistCaixa_Aberto == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelHistCaixa_Aberto"]);
            }
            //
            if (bllEntradasProdutos._FrmRelEntradasProdutos_Aberto == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelEntradasProdutos_Aberto"]);
            }
            //
            if (bllSangriaSuprimento._FrmRelSangriaSuprimento_Aberto == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelSangriaSuprimento_Aberto"]);
            }
            //
            if (bllDevolucao._FrmRelDevolucao_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelDevolucao_Ativo"]);
            }
            //
            if (bllFuncionario._FrmRelFuncionario_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelFuncionario_Ativo"]);
            }
            //
            if (bllEntidadeBancaria._FrmCadEntidadeBancaria_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadEntidadeBancaria_Ativo"]);
            }
            //
            if (bllCadastroComputadores._FrmEsquemaComputadores_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmEsquemaComputadores_Ativo"]);
            }
            //
            if (bllProduto._FrmRelSaldoAtualEstoque_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelSaldoAtualEstoque_Ativo"]);
            }
            //
            if (bllProduto._FrmRelContagemInv_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelContagemInv_Ativo"]);
            }
            //
            if (bllRegistroAtividades._FrmRelRegistroAtividades_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelRegistroAtividades_Ativo"]);
            }
            //
            if (bllUsuario._FrmRelUsuario_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelUsuario_Ativo"]);
            }
            //
            if (bllControleCheque._FrmRelControleCheque_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelControleCheque_Ativo"]);
            }
            //
            if (bllEnviarEmail.FrmUtilEnviarEmail_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmUtilEnviarEmail"]);
            }
            //
            if (bllDFe._FrmCadDocFiscais_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadDocFiscais"]);
            }
            //
            if (bllCFOP._FrmCadCFOP_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadCFOP"]);
            }
            //
            if (bllDFe._FrmCadDocFiscais_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadDocFiscais"]);
            }
            //
            if (bllDFe._FrmRelDocFiscais_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelDFe"]);
            }
            //
            if (bllValidade._FrmRelValidade_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelValidade"]);
            }
            //
            if (bllDFe._FrmCadNFeNFCe_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadNFeNFCe_Ativo"]);
            }
            //
            if (bllAniversariante._FrmRelAniversario_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelAniversario_Ativo"]);
            }
            //
            if (bllEnviarSMS._FrmUtilEnviarSMS_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmUtilEnviarSMS_Ativo"]);
            }
            //
            if (bllLembrete._FrmUtiLembrete_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmUtilLembrete" + _Instancia_Alarme]);
                _Instancia_Alarme = _Instancia_Alarme - 1;
                //
                foreach (Form mdiChild in this.MdiChildren)
                {
                    if (mdiChild.Name == "FrmUtilLembrete")
                    {
                        bllLembrete._FrmUtiLembrete_Ativo = true;
                    }
                }
            }
            //
            if (bllLembrete._FrmUtiAgenda_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmUtilAgenda"]);
            }
            //
            if (bllInventario._FrmInventario_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelInventario"]);
            }
            //
            if (bllDFe._FrmMenuNFeNFCe_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["FrmMenuNFeNFCe"]);
            }
            //
            if (bllFormaPagamento._FrmSimuFormaPagamento_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmSimularFormaPagamento"]);
            }
            //
            if (bllServico._FrmCadServico_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadServico_Ativo"]);
            }
            //
            if (bllOS._FrmOS_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["FrmOS"]);
            }
            //
            if (bllPSP._FrmCadPSPPIX_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["FrmCadPSPPIX"]);
            }
            //
            if (bllNFSe._FrmMenuNFSe_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["FrmMenuNFSe"]);
            }
            //
            if (bllSangriaSuprimento._FrmCadSangriaSuprimento_Aberto == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["FrmCadSangriaSuprimento"]);
            }
            //
            if (bllOrcamento._FrmOrcamento_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["FrmCadOrcamento_Ativo"]);
            }
            //
            if (bllComissao._FrmRelComissao_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["FrmRelComissao"]);
            }
            //
            if (bllOS._FrmRelOS_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmRelOS_Ativo"]);
            }
            //
            if (bllDocumentos._FrmCadDocumentos_Ativo == false)
            {
                sttBarraSup.Items.Remove(sttBarraSup.Items["_FrmCadDocumentos_Ativo"]);
            }



            /*
            if (ActiveMdiChild == null)
            {
                if (bllEscolherImagemSistema.Sel_Imagem_Form() != "")
                {
                    Image image;
                    using (Stream stream = File.OpenRead(bllEscolherImagemSistema.Sel_Imagem_Form()))
                    {
                        image = System.Drawing.Image.FromStream(stream);
                    }

                    if (bllEscolherImagemSistema.Sel_Alinhamento_Form() == "AUTOMATICO")
                    {
                        this.BackgroundImageLayout = ImageLayout.None;
                    }
                    else if (bllEscolherImagemSistema.Sel_Alinhamento_Form() == "CENTRALIZADO")
                    {
                        this.BackgroundImageLayout = ImageLayout.Center;
                    }
                    else if (bllEscolherImagemSistema.Sel_Alinhamento_Form() == "ESTICADO")
                    {
                        this.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        this.BackgroundImageLayout = ImageLayout.Zoom;
                    }

                    this.BackgroundImage = image;

                    foreach (Control control in this.Controls)
                    {
                        if (control is MdiClient)
                        {
                            control.BackColor = Color.FromName("Control");
                            break;
                        }
                    }
                }
                else
                {
                    this.BackgroundImage = null;

                    foreach (Control control in this.Controls)
                    {
                        if (control is MdiClient)
                        {
                            control.BackColor = Color.FromName("Control");
                            break;
                        }
                    }
                }

                bllMinhaEmpresa._Exec_Mud_Minha_Empresa = false;                
            }
             */
        }

        private int ContarMDIChildPorNome(string nomeMDIChild)
        {
            int contador = 0;

            foreach (Form mdiChild in this.MdiChildren)
            {
                if (mdiChild.Name == nomeMDIChild)
                {
                    contador++;
                }
            }

            return contador;
        }

        private void enviarEmailToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void enviarEmailToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickEnviarEmail(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmUtilEnviarEmail")
                {
                    f.Activate();
                }
            }
        }

        private void enviarEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllEnviarEmail.FrmUtilEnviarEmail_Ativo == false)
                {
                    FrmUtilEnviarEmail Email = new FrmUtilEnviarEmail(0, tslblVersao.Text, tslblUsuario.Text, null, null, null, null);
                    Email.MdiParent = this;
                    Email.Show();
                    Email.WindowState = FormWindowState.Normal;
                    //
                    ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                    tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\mail--pencil.png");
                    tsb.Tag = "RelEnviarEmail";
                    tsb.Text = "Enviar E-mail";
                    tsb.ToolTipText = "Enviar E-mail";
                    tsb.Name = "_FrmUtilEnviarEmail";
                    tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                    tsb.BackColor = Color.LightGray;
                    tsb.MouseMove += sMouseMove;
                    tsb.MouseLeave += sMouseLeave;
                    tsb.Click += sClickEnviarEmail;
                    sttBarraSup.Items.Add(tsb);
                }
                else
                {
                    MessageBox.Show("O fomulário Enviar E-mail já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmUtilEnviarEmail")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do enviarEmailToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do enviarEmailToolStripMenuItem.");
                }
            }
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\Windows\System32\Calc.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calculadoraToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void calculadoraToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void tecladoVirtualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\Windows\system32\osk.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lupaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\Windows\System32\Magnify.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tecladoVirtualToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void tecladoVirtualToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lupaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lupaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void scannerToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void scannerToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void câmeraToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void câmeraToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lembretesToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lembretesToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void controlarToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void controlarToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void controlarToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void controlarToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void utilitáriosToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void utilitáriosToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void tsslblMensagem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void tsslblMensagem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        public static bool FormIsOpen(FormCollection application, Type formType)
        {
            return Application.OpenForms.Cast<Form>().Any(openForm => openForm.GetType() == formType);
        }

        //ALARME
        void sClickAlarmLembrete(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmUtilLembrete")
                {
                    f.Activate();
                }
            }
        }
        private int _Instancia_Alarme = 0;

        int _Valor = 0;
        private void TemporizadorAlarme_Tick(object sender, EventArgs e)
        {
            try
            {
                string data = DateTime.Now.ToShortDateString();
                string hora = DateTime.Now.ToLongTimeString();
                //
                if (bllLembrete.Sel_Alarme_Dia_Hora(data, hora, tslblUsuario.Text.Replace("Usuário(a): ", "")) != null)
                {
                    for (int i = 0; i < bllLembrete.Sel_Alarme_Dia_Hora(data, hora, tslblUsuario.Text.Replace("Usuário(a): ", "")).Rows.Count; i++)
                    {
                        _Instancia_Alarme = _Instancia_Alarme + 1;
                        //
                        if (FormIsOpen(Application.OpenForms, typeof(FrmUtilLembrete)) == true)
                        {
                            DataRow dr = bllLembrete.Sel_Alarme_Dia_Hora(data, hora, tslblUsuario.Text.Replace("Usuário(a): ", "")).Rows[i];
                            FrmUtilLembrete Alarme = new FrmUtilLembrete(dr["id_lembrete"].ToString(), null, null, null, 1, tslblUsuario.Text, tslblVersao.Text);
                            Alarme.Location = new Point(0 * _Valor, 0 * _Valor);
                            Alarme.Size = new Size(381, 271);
                            Alarme.MdiParent = this;
                            Alarme.Show();
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\bell.png");
                            tsb.Tag = "Lembrete" + _Instancia_Alarme;
                            tsb.Text = "Lembrete";
                            tsb.ToolTipText = "Lembrete" + _Instancia_Alarme;
                            tsb.Name = "_FrmUtilLembrete" + _Instancia_Alarme;
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickAlarmLembrete;
                            sttBarraSup.Items.Add(tsb);
                            //
                            notifyIcon.BalloonTipText = "Você possui um(ou mais) LEMBRETE(s) em aberto..";
                            notifyIcon.ShowBalloonTip(20000);
                            notifyIcon.BalloonTipClicked += NotifyIcon_BallonTipClicked;
                        }
                        else
                        {
                            DataRow dr = bllLembrete.Sel_Alarme_Dia_Hora(data, hora, tslblUsuario.Text.Replace("Usuário(a): ", "")).Rows[i];
                            FrmUtilLembrete Alarme = new FrmUtilLembrete(dr["id_lembrete"].ToString(), null, null, null, 1, tslblUsuario.Text, tslblVersao.Text);
                            Alarme.Location = new Point(0 * _Valor, 0 * _Valor);
                            Alarme.Size = new Size(381, 271);
                            Alarme.MdiParent = this;
                            Alarme.Show();
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\bell.png");
                            tsb.Tag = "Lembrete" + _Instancia_Alarme;
                            tsb.Text = "Lembrete";
                            tsb.ToolTipText = "Lembrete" + _Instancia_Alarme;
                            tsb.Name = "_FrmUtilLembrete" + _Instancia_Alarme;
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickAlarmLembrete;
                            sttBarraSup.Items.Add(tsb);
                            //
                            notifyIcon.BalloonTipText = "Você possui um(ou mais) LEMBRETE(s) em aberto..";
                            notifyIcon.ShowBalloonTip(20000);
                            notifyIcon.BalloonTipClicked += NotifyIcon_BallonTipClicked;
                            //
                        }
                        _Valor = _Valor + 75;
                    }
                    _Valor = 0;
                }
            }
            catch (Exception ex)
            {
                TemporizadorAlarme.Stop();
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão TemporizadorAlarme.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão TemporizadorAlarme.");
                }
            }
        }

        private void tsslblConexao_MouseMove(object sender, MouseEventArgs e)
        {
            tsslblConexao.ForeColor = Color.Red;
            this.Cursor = Cursors.Hand;
        }

        private void tsslblConexao_MouseLeave(object sender, EventArgs e)
        {
            tsslblConexao.ForeColor = Color.Black;
            this.Cursor = Cursors.Default;
        }

        void sClickEsq(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmEsquemaComputadores")
                {
                    f.Activate();
                }
            }
        }

        private void tsslblConexao_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Deseja visualizar os computadores que acessam o Aplicativo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    if (bllCadastroComputadores._FrmEsquemaComputadores_Ativo == false)
                    {
                        FrmEsquemaComputadores Con = new FrmEsquemaComputadores(tslblVersao.Text);
                        Con.MdiParent = this;
                        Con.Show();
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\computer.png");
                        tsb.Tag = "Esquema";
                        tsb.Text = "Esquema de Computadores";
                        tsb.ToolTipText = "Esquema de Computadores";
                        tsb.Name = "_FrmEsquemaComputadores_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickEsq;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Esquema de Computadores já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmEsquemaComputadores")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do tsslblConexao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do tsslblConexao.");
                }
            }
        }

        void sClickAgenda(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmUtilAgenda")
                {
                    f.Activate();
                }
            }
        }

        private void lembretesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllLembrete._FrmUtiAgenda_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_Cliente_Consumidor(tslblUsuario.Text) == true)
                    {
                        FrmUtilAgenda Lembretes = new FrmUtilAgenda(tslblUsuario.Text, tslblVersao.Text, 0, null);
                        Lembretes.MdiParent = this;
                        Lembretes.Show();
                        Lembretes.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\alarm-clock-blue.png");
                        tsb.Tag = "Agenda";
                        tsb.Text = "Agenda";
                        tsb.ToolTipText = "Agenda";
                        tsb.Name = "_FrmUtilAgenda";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickAgenda;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para usar a Agenda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O fomulário Agenda já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmUtilAgenda")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do lembretesToolStripMenuItem1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do lembretesToolStripMenuItem1.");
                }
            }


        }

        private void lembretesToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lembretesToolStripMenuItem1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void blocoDeNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\Windows\System32\Notepad.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void blocoDeNotasToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void blocoDeNotasToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void scannerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void matriculaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void matriculaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void enviarSMSToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void enviarSMSToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickSMS(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmUtilEnviarSMS")
                {
                    f.Activate();
                }
            }
        }


        private void enviarSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.OK)
                                {
                                    tslblEmpresa.Text = bllMinhaEmpresa.Sel_Nome_Empresa();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder cadastrar Clientes/Consumidores é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllEnviarSMS._FrmUtilEnviarSMS_Ativo == false)
                    {
                        if (bllUsuario.Sel_Cadastrar_Cliente_Consumidor(tslblUsuario.Text) == true)
                        {
                            FrmUtilEnviarSMS SMS = new FrmUtilEnviarSMS(0, tslblVersao.Text, tslblUsuario.Text, null, null);
                            SMS.MdiParent = this;
                            SMS.Show();
                            SMS.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\mobile-phone--pencil.png");
                            tsb.Tag = "SMS";
                            tsb.Text = "Enviar SMS";
                            tsb.ToolTipText = "Enviar SMS";
                            tsb.Name = "_FrmUtilEnviarSMS_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickSMS;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para Enviar SMS.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Enviar SMS já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmUtilEnviarSMS")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadClieCons.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadClieCons.");
                }
            }
        }

        private void funçõesDeFuncionárioToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void funçõesDeFuncionárioToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickSub(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadSubGrupo")
                {
                    f.Activate();
                }
            }
        }

        private void funçõesDeFuncionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (bllSubGrupo._FrmCadSubgrupo_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_Subgrupos(tslblUsuario.Text) == true)
                    {
                        FrmCadSubGrupo Sub = new FrmCadSubGrupo(tslblUsuario.Text, tslblVersao.Text);
                        Sub.MdiParent = this;
                        Sub.Show();
                        Sub.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\group_add.png");
                        tsb.Tag = "SubGrupo";
                        tsb.Text = "Cadastro de Subgrupos";
                        tsb.ToolTipText = "Cadastro de Subgrupos";
                        tsb.Name = "_FrmCadSubgrupo_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickSub;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Subgrupos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O fomulário Cadastro de Subgrupos já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadSubGrupo")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadSubGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadSubGrupo.");
                }
            }
        }

        private void cadastroDeArquivosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cadastroDeArquivosToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cadastroDeArquivosToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void grupoESubgrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bllGrupo._FrmCadGrupo_Ativo == false)
            {
                FrmCadGrupo Grupo = new FrmCadGrupo(tslblUsuario.Text, tslblVersao.Text);
                Grupo.MdiParent = this;
                Grupo.Show();
            }
            else
            {
                MessageBox.Show("O fomulário Cadastro de Grupo e Sub-grupo está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void grupoESubgrupoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void grupoESubgrupoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickForma(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadFormaPagamento")
                {
                    f.Activate();
                }
            }
        }

        private void formaDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {

                if (bllFormaPagamento._FrmCadFormaPagamento_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_Forma_Pagamento(tslblUsuario.Text) == true)
                    {
                        FrmCadFormaPagamento Pag = new FrmCadFormaPagamento(tslblUsuario.Text, tslblVersao.Text, 0);
                        Pag.MdiParent = this;
                        Pag.Show();
                        Pag.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\money_dollar.png");
                        tsb.Tag = "FormaPagamento";
                        tsb.Text = "Cadastro de Formas de Pagamento";
                        tsb.ToolTipText = "Cadastro de Formas de Pagamento";
                        tsb.Name = "_FrmCadFormaPagamento_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickForma;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Formas de Pagamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O fomulário Cadastro de Formas de Pagamento já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadFormaPagamento")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadFormaPagamento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadFormaPagamento.");
                }
            }
        }

        private void formaDePagamentoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void formaDePagamentoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void deClientesToolStripMenuItem1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deClientesToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelClie(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelClieCons")
                {
                    f.Activate();
                }
            }
        }

        private void deClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void grupoESubToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void grupoESubToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickGrupo(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadGrupo")
                {
                    f.Activate();
                }
            }
        }

        private void grupoESubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (bllGrupo._FrmCadGrupo_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_Grupos(tslblUsuario.Text) == true)
                    {
                        FrmCadGrupo Grup = new FrmCadGrupo(tslblUsuario.Text, tslblVersao.Text);
                        Grup.MdiParent = this;
                        Grup.Show();
                        Grup.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\group.png");
                        tsb.Tag = "Grupo";
                        tsb.Text = "Cadastro de Grupos";
                        tsb.ToolTipText = "Cadastro de Grupos";
                        tsb.Name = "_FrmCadGrupo_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickGrupo;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Grupos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O fomulário Cadastro de Grupos já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadGrupo")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadGrupo.");
                }
            }
        }

        void sClickSimuPag(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmSimularFormaPagamento")
                {
                    f.Activate();
                }
            }
        }

        private void simuladorDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bllFormaPagamento._FrmSimuFormaPagamento_Ativo == false)
            {
                FrmSimularFormaPagamento Simul = new FrmSimularFormaPagamento(null, null, null, null, null, null, null, null, null, 0);
                Simul.MdiParent = this;
                Simul.Show();
                Simul.WindowState = FormWindowState.Normal;
                //
                ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\money_add.png");
                tsb.Tag = "SimuPag";
                tsb.Text = "Simulador de Forma de Pagamento";
                tsb.ToolTipText = "Simulador de Forma de Pagamento";
                tsb.Name = "_FrmSimularFormaPagamento";
                tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                tsb.BackColor = Color.LightGray;
                tsb.MouseMove += sMouseMove;
                tsb.MouseLeave += sMouseLeave;
                tsb.Click += sClickSimuPag;
                sttBarraSup.Items.Add(tsb);
            }
            else
            {
                MessageBox.Show("O fomulário Simulador de Forma de Pagamento já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void simuladorDePagamentoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void simuladorDePagamentoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void deFornecedorToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deFornecedorToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelForn(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelFornecedor")
                {
                    f.Activate();
                }
            }
        }

        private void deFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllFornecedor._FrmRelFornecedor_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Fornecedor(tslblUsuario.Text) == true)
                        {
                            FrmRelFornecedor Forn = new FrmRelFornecedor();
                            Forn.MdiParent = this;
                            Forn.Show();
                            Forn.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\user-business-gray.png");
                            tsb.Tag = "RelFornecedor";
                            tsb.Text = "Relatório de Fornecedores";
                            tsb.ToolTipText = "Relatório de Fornecedores";
                            tsb.Name = "_FrmRelFornecedor_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelForn;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Fornecedores.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Fornecedores já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelFornecedor")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deFornecedorToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deFornecedorToolStripMenuItem.");
                }
            }

        }

        void sClickRelFunc(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelFuncionario")
                {
                    f.Activate();
                }
            }
        }

        private void deFuncionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllFuncionario._FrmRelFuncionario_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Funcionarios(tslblUsuario.Text) == true)
                        {
                            FrmRelFuncionario Func = new FrmRelFuncionario();
                            Func.MdiParent = this;
                            Func.Show();
                            Func.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\user-worker.png");
                            tsb.Tag = "RelFuncionarios";
                            tsb.Text = "Relatório de Funcionários";
                            tsb.ToolTipText = "Relatório de Funcionários";
                            tsb.Name = "_FrmRelFuncionario_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelFunc;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Funcionários.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Funcionários já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelFuncionario")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deFuncionárioToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deFuncionárioToolStripMenuItem.");
                }
            }
        }

        void sClickUser(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadUsuario")
                {
                    f.Activate();
                }
            }
        }

        private void deUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario._FrmCadUsuario_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_Usuario(tslblUsuario.Text) == true)
                    {
                        FrmCadUsuario User = new FrmCadUsuario(tslblUsuario.Text, tslblVersao.Text);
                        User.MdiParent = this;
                        User.Show();
                        User.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\user-black.png");
                        tsb.Tag = "Usuarios";
                        tsb.Text = "Cadastro de Usuários";
                        tsb.ToolTipText = "Cadastro de Usuários";
                        tsb.Name = "_FrmCadUsuario_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickUser;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Usuários.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O fomulário Cadastro de Usuário já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadUsuario")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadUsuario.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadUsuario.");
                }
            }
        }

        void sClickLocal(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadLocalizacao")
                {
                    f.Activate();
                }
            }
        }

        private void rotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (bllLocalizacao._FrmCadLocalizacaoProd_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_Localizacao(tslblUsuario.Text) == true)
                    {
                        FrmCadLocalizacao Loc = new FrmCadLocalizacao(tslblUsuario.Text, tslblVersao.Text);
                        Loc.MdiParent = this;
                        Loc.Show();
                        Loc.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\magnifier--plus.png");
                        tsb.Tag = "Localizacao";
                        tsb.Text = "Cadastro de Localização";
                        tsb.ToolTipText = "Cadastro de Localização";
                        tsb.Name = "_FrmCadLocalizacaoProd_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickLocal;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Localização de Produtos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O fomulário Cadastro de Localização de Produtos já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadLocalizacao")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadLocalizacao.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadLocalizacao.");
                }
            }
        }

        private void mudarUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void conexõesToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void conexõesToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mudarUsuárioToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void mudarUsuárioToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void atualizaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bckwIndeterminado.IsBusy == true)
                {
                    MessageBox.Show("Sua solicitação está sendo processada. Por favor, aguarde um momento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    _Mostrar_Mensagem = true;
                    //
                    bckwIndeterminado.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do atualizaçõesToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do atualizaçõesToolStripMenuItem.");
                }
            }
        }

        void sClickRelGrupo(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelGrupo")
                {
                    f.Activate();
                }
            }
        }

        private void deGrupoESubgrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllGrupo._FrmRelGrupo_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Grupos(tslblUsuario.Text) == true)
                        {
                            FrmRelGrupo Grupo = new FrmRelGrupo();
                            Grupo.MdiParent = this;
                            Grupo.Show();
                            Grupo.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\group.png");
                            tsb.Tag = "RelGrupo";
                            tsb.Text = "Relatório de Grupos";
                            tsb.ToolTipText = "Relatório de Grupos";
                            tsb.Name = "_FrmRelGrupo_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelGrupo;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Grupos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Grupos já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelGrupo")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deGrupoESubgrupoToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deGrupoESubgrupoToolStripMenuItem.");
                }
            }
        }

        private void deGrupoESubgrupoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deGrupoESubgrupoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void deFuncionárioToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deFuncionárioToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void deSubgruposToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deSubgruposToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelSub(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelSubGrupo")
                {
                    f.Activate();
                }
            }
        }

        private void deSubgruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllSubGrupo._FrmRelSubgrupo_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Subgrupos(tslblUsuario.Text) == true)
                        {
                            FrmRelSubGrupo Sub = new FrmRelSubGrupo();
                            Sub.MdiParent = this;
                            Sub.Show();
                            Sub.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\group_add.png");
                            tsb.Tag = "RelSubGrupo";
                            tsb.Text = "Relatório de Subgrupos";
                            tsb.ToolTipText = "Relatório de Subgrupos";
                            tsb.Name = "_FrmRelSubgrupo_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelSub;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Subgrupos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Subgrupos já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelSubGrupo")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deSubgruposToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deSubgruposToolStripMenuItem.");
                }
            }
        }

        private void deUsuáriosToolStripMenuItem1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deUsuáriosToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void FrmSistema_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_Acesso_Negado != true)
                {
                    if (bllMinhaEmpresa.Sel_Empresa_Backup_Automatico() == true & _Reiniciar == false)
                    {
                        if (bllBackup.Sel_Data_Ult_Backup() == null || bllBackup.Sel_Data_Ult_Backup() == "")
                        {
                            if (bckwIndeterminado.IsBusy != true)
                            {
                                if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() != null)
                                {
                                    using (FrmProgresso Prog = new FrmProgresso(1))
                                    {
                                        if (Prog.ShowDialog() == DialogResult.OK)
                                        {

                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToDateTime(bllBackup.Sel_Data_Ult_Backup()).Day != DateTime.Now.Day)
                            {
                                if (bckwIndeterminado.IsBusy != true)
                                {
                                    if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() != null)
                                    {
                                        using (FrmProgresso Prog = new FrmProgresso(1))
                                        {
                                            if (Prog.ShowDialog() == DialogResult.OK)
                                            {

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //
                    string[] items = tslblUsuario.Text.Remove(0, 12).Split('—');
                    //
                    bllRegistroAtividades.Salvar("O USUARIO " + tslblUsuario.Text.Remove(0, 12) + " DESLOGOU DO SISTEMA SEVEN ADM.", "USUARIO", items[0], tslblUsuario.Text, tslblVersao.Text);
                    //
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Sistema SEVEN - Admnistração foi finalizado.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Sistema SEVEN - Admnistração foi finalizado.");
                    }
                    //
                    //notifyIcon.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmSistema ADM.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmSistema ADM.");
                }
            }
        }

        void sClickRelProd(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelProduto")
                {
                    f.Activate();
                }
            }
        }

        private void deProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        void sClickMarca(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadMarca")
                {
                    f.Activate();
                }
            }
        }

        private void deMarcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMarca._FrmCadMarca_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_Marcas(tslblUsuario.Text) == true)
                    {
                        FrmCadMarca Marca = new FrmCadMarca(tslblUsuario.Text, tslblVersao.Text, 0);
                        Marca.MdiParent = this;
                        Marca.Show();
                        Marca.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\star.png");
                        tsb.Tag = "Marcas";
                        tsb.Text = "Cadastro de Marcas";
                        tsb.ToolTipText = "Cadastro de Marcas";
                        tsb.Name = "_FrmCadMarca_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickMarca;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Marcas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O fomulário Cadastro de Marcas já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadMarca")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadMarca.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadMarca.");
                }
            }
        }

        private void deMarcasToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deMarcasToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void deProdutosToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deProdutosToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelMarca(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelMarca")
                {
                    f.Activate();
                }
            }
        }

        private void deMarcasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void deMarcasToolStripMenuItem1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deMarcasToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelForma(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelFormaPagamento")
                {
                    f.Activate();
                }
            }
        }

        private void deFormasDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllFormaPagamento._FrmRelFormaPagamento_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Formas_Pagamento(tslblUsuario.Text) == true)
                        {
                            FrmRelFormaPagamento Pag = new FrmRelFormaPagamento();
                            Pag.MdiParent = this;
                            Pag.Show();
                            Pag.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\money_dollar.png");
                            tsb.Tag = "RelFormaPagamento";
                            tsb.Text = "Relatório de Formas de Pagamento";
                            tsb.ToolTipText = "Relatório de Formas de Pagamento";
                            tsb.Name = "_FrmRelFormaPagamento_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelForma;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Formas de Pagamento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Formas de Pagamento já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelFormaPagamento")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deFormasDePagamentoToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deFormasDePagamentoToolStripMenuItem.");
                }
            }
        }

        private void deFormasDePagamentoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deFormasDePagamentoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void operaçõesToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void operaçõesToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void baixaDeContasAPagarToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void baixaDeContasAPagarToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void baixaDeContasAReceberToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void baixaDeContasAReceberToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void baixaDeContasAPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bllContasPagar._FrmOpeBaixaContaPagar_Ativo == false)
            {
                FrmRelContaPagar Contas = new FrmRelContaPagar(tslblUsuario.Text, tslblVersao.Text);
                Contas.MdiParent = this;
                Contas.Show();
            }
            else
            {
                MessageBox.Show("O formulário Baixa de Contas a Pagar já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "FrmOpeBaixaContaPagar")
                    {
                        f.Activate();
                    }
                }
            }
        }

        private void rotaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void rotaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelLocal(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelLocalizacao")
                {
                    f.Activate();
                }
            }
        }

        private void deLocalizaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void deLocalizaçãoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deLocalizaçãoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void digitalizarDocumentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void deVendaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deVendaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelVenda(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelVenda")
                {
                    f.Activate();
                }
            }
        }

        private void deVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllVenda._FrmRelVenda_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Vendas(tslblUsuario.Text) == true)
                        {
                            FrmRelVenda Aluno = new FrmRelVenda(tslblUsuario.Text, tslblVersao.Text);
                            Aluno.MdiParent = this;
                            Aluno.Show();
                            Aluno.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\store.png");
                            tsb.Tag = "RelVendas";
                            tsb.Text = "Relatório de Vendas";
                            tsb.ToolTipText = "Relatório de Vendas";
                            tsb.Name = "_FrmRelVenda_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelVenda;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Vendas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Vendas já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelVenda")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deVendaToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deVendaToolStripMenuItem.");
                }
            }
        }

        private void históricoDoCaixaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void históricoDoCaixaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelHistCx(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelHistCaixa")
                {
                    f.Activate();
                }
            }
        }

        private void históricoDoCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllHistCaixa._FrmRelHistCaixa_Aberto == false)
                    {
                        if (bllUsuario.Sel_Rel_Hist_Caixa(tslblUsuario.Text) == true)
                        {
                            FrmRelHistCaixa Hist = new FrmRelHistCaixa(tslblUsuario.Text, tslblVersao.Text);
                            Hist.MdiParent = this;
                            Hist.Show();
                            Hist.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\book-open-text.png");
                            tsb.Tag = "RelHistCaixa";
                            tsb.Text = "Relatório de Histórico do Caixa";
                            tsb.ToolTipText = "Relatório de Histórico do Caixa";
                            tsb.Name = "_FrmRelHistCaixa_Aberto";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelHistCx;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Histórico do Caixa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Histórico do Caixa já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelHistCaixa")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do históricoDoCaixaToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do históricoDoCaixaToolStripMenuItem.");
                }
            }
        }

        void sClickRelSaidaProd(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelSaidasProdutos")
                {
                    f.Activate();
                }
            }
        }

        private void saídasDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllSaidasProdutos._FrmRelSaidasProdutos_Aberto == false)
                    {
                        if (bllUsuario.Sel_Rel_Saidas_Produtos(tslblUsuario.Text) == true)
                        {
                            FrmRelSaidasProdutos Sai = new FrmRelSaidasProdutos(tslblUsuario.Text, tslblVersao.Text);
                            Sai.MdiParent = this;
                            Sai.Show();
                            Sai.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\box--arrow.png");
                            tsb.Tag = "RelSaidaProd";
                            tsb.Text = "Relatório de Saídas de Produtos";
                            tsb.ToolTipText = "Relatório de Saídas de Produtos";
                            tsb.Name = "_FrmRelSaidasProdutos_Aberto";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelSaidaProd;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Saída de Produtos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Saída de Produtos já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelSaidasProdutos")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do saídasDeProdutosToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do saídasDeProdutosToolStripMenuItem.");
                }
            }

        }

        private void saídasDeProdutosToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void saídasDeProdutosToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelEntProd(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelEntradasProdutos")
                {
                    f.Activate();
                }
            }
        }


        private void deFornecedoresDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void deFornecedoresDeProdutosToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deFornecedoresDeProdutosToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void deAberturaEFechamentoDeCaixasToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deAberturaEFechamentoDeCaixasToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickAbertFechCx(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelAbertFechCaixa")
                {
                    f.Activate();
                }
            }
        }

        void sClickRelAbertFechCx(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelAbertFechCaixa")
                {
                    f.Activate();
                }
            }
        }

        private void deAberturaEFechamentoDeCaixasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllAbert_Fech_Caixa._FrmRelCaixas_Aberto == false)
                    {
                        if (bllUsuario.Sel_Rel_Abert_Fech_Caixa(tslblUsuario.Text) == true)
                        {
                            FrmRelAbertFechCaixa Abert = new FrmRelAbertFechCaixa(tslblUsuario.Text, tslblVersao.Text);
                            Abert.MdiParent = this;
                            Abert.Show();
                            Abert.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\monitor-window-3d.png");
                            tsb.Tag = "RelAbertFech";
                            tsb.Text = "Relatório de Abertura e Fechamento de Caixa";
                            tsb.ToolTipText = "Relatório de Abertura e Fechamento de Caixa";
                            tsb.Name = "_FrmRelCaixas_Aberto";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelAbertFechCx;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Abertura e Fechamento de Caixa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Abertura e Fechamento de Caixa já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelAbertFechCaixa")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deAberturaEFechamentoDeCaixasToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deAberturaEFechamentoDeCaixasToolStripMenuItem.");
                }
            }
        }

        private void deFluxoDeCaixaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deFluxoDeCaixaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelFluxo(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelFluxoCaixa")
                {
                    f.Activate();
                }
            }
        }

        private void deFluxoDeCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllFluxoCaixa._FrmRelFluxoCaixa_Aberto == false)
                    {
                        if (bllUsuario.Sel_Rel_Fluxo_Caixa(tslblUsuario.Text) == true)
                        {
                            FrmRelFluxoCaixa Fluxo = new FrmRelFluxoCaixa(tslblVersao.Text, tslblUsuario.Text);
                            Fluxo.MdiParent = this;
                            Fluxo.Show();
                            Fluxo.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\arrow-circle-double-135.png");
                            tsb.Tag = "RelFluxCx";
                            tsb.Text = "Relatório de Fluxo de Caixa";
                            tsb.ToolTipText = "Relatório de Fluxo de Caixa";
                            tsb.Name = "_FrmRelFluxoCaixa_Aberto";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelFluxo;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Fluxo do Caixa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Fluxo de Caixa já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelFluxoCaixa")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deFluxoDeCaixaToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deFluxoDeCaixaToolStripMenuItem.");
                }
            }
        }

        private void deSangriaSuprimentoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deSangriaSuprimentoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelSangSup(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelSangriaSuprimento")
                {
                    f.Activate();
                }
            }
        }

        private void deSangriaSuprimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllSangriaSuprimento._FrmRelSangriaSuprimento_Aberto == false)
                    {
                        if (bllUsuario.Sel_Rel_Sangria_Suprimento(tslblUsuario.Text) == true)
                        {
                            FrmRelSangriaSuprimento SangSup = new FrmRelSangriaSuprimento(tslblUsuario.Text, tslblVersao.Text);
                            SangSup.MdiParent = this;
                            SangSup.Show();
                            SangSup.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\money-coin.png");
                            tsb.Tag = "RelSangSup";
                            tsb.Text = "Relatório de Sangria e Suprimento";
                            tsb.ToolTipText = "Relatório de Sangria e Suprimento";
                            tsb.Name = "_FrmRelSangriaSuprimento_Aberto";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelSangSup;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Sangria e Suprimentos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Sangria e Suprimento já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelSangriaSuprimento")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deSangriaSuprimentoToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deSangriaSuprimentoToolStripMenuItem.");
                }
            }
        }

        private void sToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void sToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelDevProd(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelDevolucao")
                {
                    f.Activate();
                }
            }
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        void sClickRegAtiv(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelRegistroAtividade")
                {
                    f.Activate();
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.OK)
                                {
                                    tslblEmpresa.Text = bllMinhaEmpresa.Sel_Nome_Empresa();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllRegistroAtividades._FrmRelRegistroAtividades_Ativo == false)
                    {
                        FrmRelRegistroAtividade Reg = new FrmRelRegistroAtividade(tslblUsuario.Text, tslblVersao.Text);
                        Reg.MdiParent = this;
                        Reg.Show();
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\calendar-day.png");
                        tsb.Tag = "RegAtiv";
                        tsb.Text = "Registro de Atividades";
                        tsb.ToolTipText = "Registro de Atividades";
                        tsb.Name = "_FrmRelRegistroAtividades_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickRegAtiv;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Registro de Atividades já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelRegistroAtividade")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do toolStripMenuItem2.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do toolStripMenuItem2.");
                }
            }
        }

        private void toolStripMenuItem2_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelOrc(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelOrcamento")
                {
                    f.Activate();
                }
            }
        }

        private void deOrçamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllOrcamento._FrmRelOrcamento_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Orcamentos(tslblUsuario.Text) == true)
                        {
                            FrmRelOrcamento Orc = new FrmRelOrcamento(tslblUsuario.Text, tslblVersao.Text);
                            Orc.MdiParent = this;
                            Orc.Show();
                            Orc.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\report--arrow.png");
                            tsb.Tag = "RelOrcamento";
                            tsb.Text = "Relatório de Orçamentos";
                            tsb.ToolTipText = "Relatório de Orçamentos";
                            tsb.Name = "_FrmRelOrcamento_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelOrc;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Orçamentos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Orçamentos já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelOrcamento")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deOrçamentoToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deOrçamentoToolStripMenuItem.");
                }
            }
        }

        private void deOrçamentoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void deOrçamentoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void abrirAPPIBExpertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\Program Files (x86)\HK-Software\IBExpert\ibexpert.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do abrirAPPIBExpert.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do abrirAPPIBExpert.");
                }
            }
        }

        private void contasAReceberToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void contasAReceberToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelUsuario(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelUsuario")
                {
                    f.Activate();
                }
            }
        }

        private void usuáriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllUsuario._FrmRelUsuario_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Usuario(tslblUsuario.Text) == true)
                        {
                            FrmRelUsuario Users = new FrmRelUsuario(tslblUsuario.Text, tslblVersao.Text);
                            Users.MdiParent = this;
                            Users.Show();
                            Users.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\user-black.png");
                            tsb.Tag = "RelUsuario";
                            tsb.Text = "Relatório de Usuários";
                            tsb.ToolTipText = "Relatório de Usuários";
                            tsb.Name = "_FrmRelUsuario_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelUsuario;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Usuários.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Usuários já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelUsuario")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do usuáriosToolStripMenuItem1_Click.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do usuáriosToolStripMenuItem1_Click.");
                }
            }
        }

        private void usuáriosToolStripMenuItem1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void usuáriosToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void entidadeBancáriaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void entidadeBancáriaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickBanco(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadEntidadeBancaria")
                {
                    f.Activate();
                }
            }
        }

        private void entidadeBancáriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllEntidadeBancaria._FrmCadEntidadeBancaria_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_Entidade_Bancaria(tslblUsuario.Text) == true)
                    {
                        FrmCadEntidadeBancaria Ent = new FrmCadEntidadeBancaria(tslblUsuario.Text, tslblVersao.Text);
                        Ent.MdiParent = this;
                        Ent.Show();
                        Ent.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\bank.png");
                        tsb.Tag = "Banco";
                        tsb.Text = "Cadastro de Entidade Bancária";
                        tsb.ToolTipText = "Cadastro de Entidade Bancária";
                        tsb.Name = "_FrmCadEntidadeBancaria_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickBanco;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Entidade Bancária.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O fomulário Cadastro de Entidade Bancária já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadEntidadeBancaria")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadEntidadeBancaria.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadEntidadeBancaria.");
                }
            }
        }

        private void estoqueToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void estoqueToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        void sClickSaldo(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelSaldoAtual")
                {
                    f.Activate();
                }
            }
        }

        private void saldoAtualToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void saldoAtualToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void saldoAtualToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        void sClickContagem(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelContagemInv")
                {
                    f.Activate();
                }
            }
        }

        private void contagemDeEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void contagemDeEstoqueToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void contagemDeEstoqueToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pararIniciarLetreiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_AtivarDesativarLet == false)
            {
                if (bllLetreiro.Sel_Mensagem_Letreiro() != null)
                {
                    _AtivarDesativarLet = true;

                    DataRow dr = bllLetreiro.Sel_Mensagem_Letreiro().Rows[0];
                    //
                    _Mensagem = dr["mensagem"].ToString();
                    _TamanhoMensagem = dr["mensagem"].ToString().Length;
                    _TamanhoMensagemDecre = dr["mensagem"].ToString().Length;
                    _Tipo_Mensagem = dr["tipo"].ToString();
                    if (Convert.ToByte(dr["cor"]) == 0)
                    {
                        _Cor = 0;
                    }
                    else if (Convert.ToByte(dr["cor"]) == 1)
                    {
                        _Cor = 1;
                    }
                    TemporizadorLetreiro.Start();
                }
            }
            else
            {
                _AtivarDesativarLet = false;
                TemporizadorLetreiro.Stop();
                tsslblMensagem.Text = "";
                _QuantLetreiro = 0;
                _Incremento = 0;
                _ContEspaco = true;
                _Mensagem = "";
                _TamanhoMensagem = 0;
                _TamanhoMensagemDecre = 0;
                _Cor = 0;
            }
        }

        private void pararIniciarLetreiroToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pararIniciarLetreiroToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void tsslblMensagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Tipo_Mensagem == "DFE")
                {
                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                    {
                        DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (DialogResult == DialogResult.Yes)
                        {
                            Form[] mdichild = this.MdiChildren;

                            if (this.MdiChildren.Length > 0)
                            {
                                MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                                {
                                    if (Emp.ShowDialog() == DialogResult.Abort)
                                    {
                                        if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                        {
                                            DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                            //
                                            tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Para poder visualizar Menu NFe/NFCe é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        if (bllDFe._FrmMenuNFeNFCe_Ativo == false)
                        {
                            if (bllUsuario.Sel_Acessar_Menu_NFe_NFCe(tslblUsuario.Text) == true)
                            {
                                FrmMenuNFeNFCe Menu = new FrmMenuNFeNFCe(tslblUsuario.Text, tslblVersao.Text, 0, null);
                                Menu.MdiParent = this;
                                Menu.Show();
                                //
                                ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                                tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\barra-de-menu.png");
                                tsb.Tag = "Menu";
                                tsb.Text = "Menu NFe/NFCe";
                                tsb.ToolTipText = "Menu NFe/NFCe";
                                tsb.Name = "FrmMenuNFeNFCe";
                                tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                                tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                                tsb.BackColor = Color.LightGray;
                                tsb.MouseMove += sMouseMove;
                                tsb.MouseLeave += sMouseLeave;
                                tsb.Click += sClickMenu;
                                sttBarraSup.Items.Add(tsb);
                            }
                            else
                            {
                                MessageBox.Show("O Usuário atual não possui permissão para visualizar Menu NFe/NFCe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("O fomulário Menu NFe/NFCe já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            foreach (Form f in this.MdiChildren)
                            {
                                if (f.Name == "FrmMenuNFeNFCe")
                                {
                                    f.Activate();
                                }
                            }
                        }
                    }
                }
                else if (_Tipo_Mensagem == "LEMBRETE")
                {
                    if (bllLembrete._FrmUtiAgenda_Ativo == false)
                    {
                        if (bllUsuario.Sel_Cadastrar_Cliente_Consumidor(tslblUsuario.Text) == true)
                        {
                            FrmUtilAgenda Lembretes = new FrmUtilAgenda(tslblUsuario.Text, tslblVersao.Text, 0, null);
                            Lembretes.MdiParent = this;
                            Lembretes.Show();
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\alarm-clock-blue.png");
                            tsb.Tag = "Agenda";
                            tsb.Text = "Agenda";
                            tsb.ToolTipText = "Agenda";
                            tsb.Name = "_FrmUtilAgenda";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickAgenda;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para usar a Agenda.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Agenda já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmUtilAgenda")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
                else if (_Tipo_Mensagem == "CERTIFICADO") 
                {
                    MessageBox.Show(_Mensagem, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    using (FrmVersao Ver = new FrmVersao(_Versao))
                    {
                        if (Ver.ShowDialog() == DialogResult.Abort)
                        {

                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do tsslblMensagem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do tsslblMensagem.");
                }
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length < 1)
            {
                MessageBox.Show("Ainda não existem janelas abertas para fechar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                foreach (Form childForm in this.MdiChildren)
                {
                    childForm.Close();
                }
            }
        }

        private void tsslblFechar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void tsslblFechar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mstrMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsslblConexao_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void AppToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void appPDVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\Sistema SEVEN\Sistema SEVEN PDV.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do appPDVToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do appPDVToolStripMenuItem.");
                }
            }
        }

        private void appPDVToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void appPDVToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void abrirAPPIBExpertToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void abrirAPPIBExpertToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void atualizaçõesToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void atualizaçõesToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void acessoRemotoSuporteToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void acessoRemotoSuporteToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void movimentaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rotasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        

        private void toolStripMenuItem3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void TemporizadorBancoDados_Tick(object sender, EventArgs e)
        {
            try
            {
                if (tsslblConexao.Text == "Servidor: " + bllConexao._Descricao_Conexao_Atual)
                {
                    tsslblConexao.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\store-open.png");
                    tsslblConexao.Text = " Empresa/Entidade: " + bllConexao._Descricao_Entidade;
                }
                else
                {
                    tsslblConexao.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\database-medium.png");
                    tsslblConexao.Text = "Servidor: " + bllConexao._Descricao_Conexao_Atual;
                }
            }
            catch (Exception ex)
            {
                TemporizadorBancoDados.Stop();
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento tick do botão TemporizadorBancoDados.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento tick do botão TemporizadorBancoDados.");
                }
            }
        }

        private void enviarUmFeedBackToolStripMenuItem_MouseMove_1(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void enviarUmFeedBackToolStripMenuItem_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void desenvolvedorToolStripMenuItem_MouseMove_1(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void desenvolvedorToolStripMenuItem_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void sttBarraInf_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Form[] mdichild = this.MdiChildren;
                //
                if (this.MdiChildren.Length > 0)
                {
                    MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    using (FrmBackup Back = new FrmBackup())
                    {
                        if (Back.ShowDialog() == DialogResult.Abort)
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do toolStripMenuItem1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do toolStripMenuItem1.");
                }
            }
        }

        private void toolStripMenuItem1_MouseMove_1(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem1_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void desenvolvedorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Versão: " + _Versao + "\nSistema SEVEN - SISEVEN (C)", "Informações do Aplicativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aplicarLicençaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.OK)
                                {
                                    tslblEmpresa.Text = bllMinhaEmpresa.Sel_Nome_Empresa();
                                    //
                                    using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                                    {
                                        if (Lic.ShowDialog() == DialogResult.OK)
                                        {
                                            DataRow dr = bllLicenca.Verificar_Data_Licenca().Rows[0];
                                            //
                                            MessageBox.Show("Duração da licença: Até " + dr["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder Aplicar a Licença é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    using (FrmLicencaSoftware Lic = new FrmLicencaSoftware(1))
                    {
                        if (Lic.ShowDialog() == DialogResult.OK)
                        {
                            DataRow dr = bllLicenca.Verificar_Data_Licenca().Rows[0];
                            //
                            MessageBox.Show("Duração da licença: Até " + dr["data_expiracao"].ToString().Remove(10) + " (30 dias).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do aplicarLicençaToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do aplicarLicençaToolStripMenuItem.");
                }
            }
        }

        private void consultarLicençaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void consultarLicençaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void aplicarLicençaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void aplicarLicençaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void licençaDoAplicativoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void licençaDoAplicativoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void consultarLicençaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = bllLicenca.Verificar_Data_Licenca().Rows[0];
                //
                if (Convert.ToDateTime(dr["data_expiracao"].ToString().Remove(10)) == Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                {
                    MessageBox.Show("Duração da licença: Até " + dr["data_expiracao"].ToString().Remove(10) + " \n\nHOJE É O ÚLTIMO DIA ANTES DA LICENÇA EXPIRAR.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Duração da licença: Até " + dr["data_expiracao"].ToString().Remove(10) + " (" + (Convert.ToDateTime(dr["data_expiracao"].ToString().Remove(10)) - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays + " dia(s)).", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do consultarLicençaToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do consultarLicençaToolStripMenuItem.");
                }
            }
        }

        private void TemporizadorVersao_Tick(object sender, EventArgs e)
        {
            if (bllConfiguracaoSistema.Sel_Buscar_Atualizacoes(bllConexao._Codigo_Conexao) == true)
            {
                if (_Atualizacao_Disponivel == true)
                {
                    if (tslblVersao.ForeColor == Color.Black)
                    {
                        tslblVersao.ForeColor = Color.Blue;
                    }
                    else
                    {
                        tslblVersao.ForeColor = Color.Black;
                    }
                    //
                    if (_Tempo_Mostrar_Atualizacao == 900)
                    {
                        bckwIndeterminado.RunWorkerAsync();
                    }
                }
                else
                {
                    if (_Tempo_Mostrar_Atualizacao == 1000)
                    {
                        bckwIndeterminado.RunWorkerAsync();
                    }
                }
                //

                _Tempo_Mostrar_Atualizacao = _Tempo_Mostrar_Atualizacao + 1;
            }
        }

        private void licençaDoAplicativoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void controleDeChequeToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void controleDeChequeToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelContCheque(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelControleCheque")
                {
                    f.Activate();
                }
            }
        }

        private void controleDeChequeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllControleCheque._FrmRelControleCheque_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Controle_Cheque(tslblUsuario.Text) == true)
                        {
                            FrmRelControleCheque Cheque = new FrmRelControleCheque(tslblUsuario.Text, tslblVersao.Text);
                            Cheque.MdiParent = this;
                            Cheque.Show();
                            Cheque.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\zone-money.png");
                            tsb.Tag = "RelControleCheque";
                            tsb.Text = "Relatório de Controle de Cheque";
                            tsb.ToolTipText = "Relatório de Controle de Cheque";
                            tsb.Name = "_FrmRelControleCheque_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelContCheque;
                            sttBarraSup.Items.Add(tsb);

                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Controle de Cheque.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Controle de Cheque já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelProduto")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deProdutosToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deProdutosToolStripMenuItem.");
                }
            }
        }

        void sClickDFe(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadDocFiscais")
                {
                    f.Activate();
                }
            }
        }

        private void lançamentoDeNotaFiscalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllDFe._FrmCadDocFiscais_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_DFe(tslblUsuario.Text) == true)
                    {
                        FrmCadDocFiscais Fiscal = new FrmCadDocFiscais(tslblUsuario.Text, tslblVersao.Text, 0);
                        Fiscal.MdiParent = this;
                        Fiscal.Show();
                        Fiscal.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\brasil.png");
                        tsb.Tag = "CadDocFiscais";
                        tsb.Text = "Cadastro de DFe [ Entradas/Compras ]";
                        tsb.ToolTipText = "Cadastro de DFe [ Entradas/Compras ]";
                        tsb.Name = "_FrmCadDocFiscais";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickDFe;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar DFe [ Entradas/Compras ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O formulário Cadastro de DFe\n[ Entradas/Compras ] já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadDocFiscais")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadDocFiscais.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadDocFiscais.");
                }
            }
        }

        private void lançamentoDeNotaFiscalToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lançamentoDeNotaFiscalToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cFOPToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cFOPToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickCFOP(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadCFOP")
                {
                    f.Activate();
                }
            }
        }

        private void cFOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (bllCFOP._FrmCadCFOP_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_CFOP_NatOp(tslblUsuario.Text) == true)
                    {
                        FrmCadCFOP Cfop = new FrmCadCFOP(tslblUsuario.Text, tslblVersao.Text, 0);
                        Cfop.MdiParent = this;
                        Cfop.Show();
                        Cfop.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\book--arrow.png");
                        tsb.Tag = "CadCFOP";
                        tsb.Text = "Cadastro de CFOP/Natureza da Operação";
                        tsb.ToolTipText = "Cadastro de CFOP";
                        tsb.Name = "_FrmCadCFOP";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickCFOP;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar CFOP/Natureza da Operação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O formulário Cadastro de CFOP/Natureza da Operação já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadCFOP")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do CFOPToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do CFOPToolStripMenuItem.");
                }
            }
        }

        void sClickRelDFe(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelDFe")
                {
                    f.Activate();
                }
            }
        }

        private void dFeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void dFeToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void dFeToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void validadeDeProdutoServiçoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void validadeDeProdutoServiçoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelVal(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelValidade")
                {
                    f.Activate();
                }
            }
        }

        private void validadeDeProdutoServiçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        void sClickCriarNFeNFCe(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadNFeNFCe")
                {
                    f.Activate();
                }
            }
        }

        private void criarDFeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.OK)
                                {
                                    tslblEmpresa.Text = bllMinhaEmpresa.Sel_Nome_Empresa();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder cadastrar Documentos Fiscais é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllDFe._FrmCadNFeNFCe_Ativo == false)
                    {
                        if (bllUsuario.Sel_Cadastrar_Produtos(tslblUsuario.Text) == true)
                        {
                            FrmCadNFeNFCe Fiscal = new FrmCadNFeNFCe(tslblUsuario.Text, tslblVersao.Text, 1, null, null, null, 0, false);
                            Fiscal.MdiParent = this;
                            Fiscal.Show();
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\brasil.png");
                            tsb.Tag = "CadNFeNFCe";
                            tsb.Text = "Criar DFe";
                            tsb.ToolTipText = "Criar DFe";
                            tsb.Name = "_FrmCadNFeNFCe_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickCriarNFeNFCe;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para Criar NFe/NFCe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O formulário Criar DFe já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmCadNFeNFCe")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadDocFiscais.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadDocFiscais.");
                }
            }
        }

        private void criarDFeToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void criarDFeToolStripMenuItem_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void criarDFeToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void aniversáriantesToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void aniversáriantesToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }


        void sClickInv(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelInventario")
                {
                    f.Activate();
                }
            }
        }

        private void inventárioDeEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void inventárioDeEstoqueToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void inventárioDeEstoqueToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickMenu(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmMenuNFeNFCe")
                {
                    f.Activate();
                }
            }
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void menuToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void criarDFe_Click(object sender, EventArgs e)
        {

        }

        private void criarDFeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void cadastrarDFeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void criarDFeToolStripMenuItem_MouseMove_1(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void criarDFeToolStripMenuItem_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cadastrarDFeToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cadastrarDFeToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void criarDFeToolStripMenuItem1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void criarDFeToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void criarNFeNotaFiscalEletrônicaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void criarNFeNotaFiscalEletrônicaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }


        private void suporteTécnicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Nosso número de suporte é: (75) 98271-6595\n\nNosso e-mail é: 7sistema.suporte@gmail.com\n\n\n\nDeseja entrar em contato pelo whatsapp?", "Suporte Técnico", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (DialogResult == DialogResult.Yes)
                {
                    Process.Start("https://wa.me/5575982716595?text=Ol%C3%A1");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão toolStripMenuItem1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão toolStripMenuItem1.");
                }
            }
        }

        private void suporteTécnicoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void suporteTécnicoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mudarDeUsuárioToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void mudarDeUsuárioToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mudarDeUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form[] mdichild = this.MdiChildren;
                //
                if (this.MdiChildren.Length > 0)
                {
                    MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    using (FrmLoginUsuarioADM Login = new FrmLoginUsuarioADM(tslblUsuario.Text, tslblVersao.Text))
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            this.DialogResult = DialogResult.Abort;
                            tslblUsuario.Text = "Usuário(a): " + bllConexao._Usuario;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do mudarUsuárioToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do mudarUsuárioToolStripMenuItem.");
                }
            }
        }



        private void menuNFeNFCeToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void menuNFeNFCeToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void ordemDeServiçoToolStripMenuItem1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;

        }

        private void ordemDeServiçoToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickOS(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmOS")
                {
                    f.Activate();
                }
            }
        }

        private void ordemDeServiçoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder visualizar Ordem de Serviço é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(tslblVersao.Text) != 0 & bllConfiguracaoSistema.Sel_Abert_Fech_Caixa_Config() == true)
                    {
                        MessageBox.Show("Não é possível iniciar [ Ordem de Serviço ] porque o caixa está fechado.\n\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (bllOS._FrmOS_Ativo == false)
                        {
                            if (bllUsuario.Sel_Cadastrar_OS(tslblUsuario.Text) == true)
                            {
                                FrmOS Menu = new FrmOS(tslblVersao.Text, tslblUsuario.Text);
                                Menu.MdiParent = this;
                                Menu.Show();
                                Menu.WindowState = FormWindowState.Normal;
                                //
                                ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                                tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\document-share.png");
                                tsb.Tag = "OS";
                                tsb.Text = "Ordem de Serviço";
                                tsb.ToolTipText = "Ordem de Serviço";
                                tsb.Name = "FrmOS";
                                tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                                tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                                tsb.BackColor = Color.LightGray;
                                tsb.MouseMove += sMouseMove;
                                tsb.MouseLeave += sMouseLeave;
                                tsb.Click += sClickOS;
                                sttBarraSup.Items.Add(tsb);
                            }
                            else
                            {
                                MessageBox.Show("O Usuário atual não possui permissão para visualizar Ordem de Serviço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("O fomulário Ordem de Serviço já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            foreach (Form f in this.MdiChildren)
                            {
                                if (f.Name == "FrmOS")
                                {
                                    f.Activate();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do ordemDeServiçoToolStripMenu.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do ordemDeServiçoToolStripMenu.");
                }
            }
        }

        private void serviçosToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void serviçosToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickServico(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadServico")
                {
                    f.Activate();
                }
            }
        }

        private void serviçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllServico._FrmCadServico_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_Servico(tslblUsuario.Text) == true)
                    {
                        FrmCadServico Serv = new FrmCadServico(tslblUsuario.Text, tslblVersao.Text, 0);
                        Serv.MdiParent = this;
                        Serv.Show();
                        Serv.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\document-share.png");
                        tsb.Tag = "Serviço";
                        tsb.Text = "Cadastro de Serviços";
                        tsb.ToolTipText = "Cadastro de Serviços";
                        tsb.Name = "_FrmCadServico_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickServico;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Serviços.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O fomulário Cadastro de Serviços já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadServico")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadGrupo.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadGrupo.");
                }
            }
        }

        private void pSPPIXToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pSPPIXToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickPSP(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadPSPPIX")
                {
                    f.Activate();
                }
            }
        }

        private void pSPPIXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllPSP._FrmCadPSPPIX_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_PSP_PIX(tslblUsuario.Text) == true)
                    {
                        FrmCadPSPPIX Pix = new FrmCadPSPPIX(tslblUsuario.Text, tslblVersao.Text);
                        Pix.MdiParent = this;
                        Pix.Show();
                        Pix.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\pix.png");
                        tsb.Tag = "PSP";
                        tsb.Text = "Cadastro de PSP/PIX";
                        tsb.ToolTipText = "Cadastro de PSP/PIX";
                        tsb.Name = "FrmCadPSPPIX";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickPSP;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar PSP/PIX.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O fomulário Cadastro de PSP/PIX já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadPSPPIX")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadEntidadeBancaria.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadEntidadeBancaria.");
                }
            }
        }

        private void bckwIndeterminado_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        { 
            if (_Sleep == true)
            {
                Thread.Sleep(5000);
            }
            //
            if (bllVersao.VerificarAtualizacoesSQLOperation() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesSQLSeven() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
            {
                if (bllVersao.VerificarAtualizacoesSQL_CPF_CNPJ() == true)
                {
                    bllVersao.BaixarAtualizacoesSQL_CPF_CNPJ();
                }
            }
            //
            if (bllVersao.VerificarAtualizacoesIBPT() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesSeven_Adm() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesSeven_Pdv() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesBLL() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesDAL() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesSeven_Config() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesACBR_Lib() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesConfig() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (bllVersao.VerificarAtualizacoesSistemaSeven() == true)
            {
                _Atualizacao_Disponivel = true;
            }
            //
            if (_Atualizacao_Disponivel == true)
            {
                bllVersao.BaixarDetalheAtualizacao();
            }
            //
            _Sleep = false;          
        }

        private void bckwIndeterminado_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                _Atualizacao_Disponivel = false;
                TemporizadorVersao.Stop();
                //informa ao usuario do acontecimento de algum erro.
                MessageBox.Show(this, e.Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                }
                _Mostrar_Mensagem = false;
                _Tempo_Mostrar_Atualizacao = 0;
                TemporizadorVersao.Start();
            }
            else
            {
                try
                {
                    TemporizadorVersao.Stop();
                    //
                    if (_Atualizacao_Disponivel == true)
                    {
                        using (FrmAtualizacaoDisponivel Disp = new FrmAtualizacaoDisponivel())
                        {
                            if (Disp.ShowDialog() == DialogResult.Yes)
                            {
                                using (FrmAtualizacao Atu = new FrmAtualizacao())
                                {
                                    if (Atu.ShowDialog() == DialogResult.OK)
                                    {
                                        foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                                        {
                                            if (form != Application.OpenForms[0])
                                            {
                                                form.Close();
                                            }
                                        }
                                        //
                                        using (FrmProgresso Prog = new FrmProgresso(0))
                                        {
                                            if (Prog.ShowDialog() == DialogResult.OK)
                                            {
                                                MessageBox.Show(this, "O Seu sistema SEVEN foi atualizado com sucesso.\n\nO Aplicativo precisará reiniciar todos os módulos para aplicar as alterações.\n\nCertifique-se de salvar seus trabalhos pendentes no aplicativo PDV, caso ele esteja aberto.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                //
                                                _Reiniciar = true;
                                                //
                                                Process[] processos = Process.GetProcessesByName("Seven_PDV");
                                                //
                                                foreach (Process processo in processos)
                                                {
                                                    processo.Kill();
                                                }
                                                //
                                                Process.Start(@"C:\Sistema SEVEN\Seven_Adm.exe");
                                                //
                                                this.Close();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (_Mostrar_Mensagem == true)
                        {
                            _Mostrar_Mensagem = false;
                            MessageBox.Show("O Sistema SEVEN já possui todas as atualizações mais recentes.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    //
                    _Tempo_Mostrar_Atualizacao = 0;
                    TemporizadorVersao.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwIndeterminado.");
                    }
                }
            }
        }

        private void criarNFeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.OK)
                                {
                                    tslblEmpresa.Text = bllMinhaEmpresa.Sel_Nome_Empresa();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder cadastrar Documentos Fiscais é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(tslblVersao.Text) != 0 & bllConfiguracaoSistema.Sel_Abert_Fech_Caixa_Config() == true)
                    {
                        MessageBox.Show("Não é possível iniciar [ Criar DFe ] porque o caixa está fechado.\n\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (bllDFe._FrmCadNFeNFCe_Ativo == false)
                        {
                            if (bllUsuario.Sel_Cadastrar_NFe(tslblUsuario.Text) == true)
                            {
                                FrmCadNFeNFCe Fiscal = new FrmCadNFeNFCe(tslblUsuario.Text, tslblVersao.Text, 1, null, null, null, 0, false);
                                Fiscal.MdiParent = this;
                                Fiscal.Show();
                                Fiscal.WindowState = FormWindowState.Normal;
                                //
                                ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                                tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\brasil.png");
                                tsb.Tag = "CadNFeNFCe";
                                tsb.Text = "Criar DFe [ Modelo 55 ]";
                                tsb.ToolTipText = "Criar NFe [ Modelo 55 ]";
                                tsb.Name = "_FrmCadNFeNFCe_Ativo";
                                tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                                tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                                tsb.BackColor = Color.LightGray;
                                tsb.MouseMove += sMouseMove;
                                tsb.MouseLeave += sMouseLeave;
                                tsb.Click += sClickCriarNFeNFCe;
                                sttBarraSup.Items.Add(tsb);
                            }
                            else
                            {
                                MessageBox.Show("O Usuário atual não possui permissão para Criar NFe\n[ Modelo 55 ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("O formulário Criar DFe [ Modelo 55 ] já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            foreach (Form f in this.MdiChildren)
                            {
                                if (f.Name == "FrmCadNFeNFCe")
                                {
                                    f.Activate();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadDocFiscais.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadDocFiscais.");
                }
            }
        }

        private void dFeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder visualizar Menu NFe/NFCe é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(tslblVersao.Text) != 0)
                    {
                        MessageBox.Show("Não é possível iniciar [ Menu NFe/NFCe ] porque o caixa está fechado.\n\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (bllDFe._FrmMenuNFeNFCe_Ativo == false)
                        {
                            if (bllUsuario.Sel_Acessar_Menu_NFe_NFCe(tslblUsuario.Text) == true)
                            {
                                FrmMenuNFeNFCe Menu = new FrmMenuNFeNFCe(tslblUsuario.Text, tslblVersao.Text, 0, null);
                                Menu.MdiParent = this;
                                Menu.Show();
                                Menu.WindowState = FormWindowState.Normal;
                                //
                                ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                                tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\barra-de-menu.png");
                                tsb.Tag = "Menu";
                                tsb.Text = "Menu NFe/NFCe";
                                tsb.ToolTipText = "Menu NFe/NFCe";
                                tsb.Name = "FrmMenuNFeNFCe";
                                tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                                tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                                tsb.BackColor = Color.LightGray;
                                tsb.MouseMove += sMouseMove;
                                tsb.MouseLeave += sMouseLeave;
                                tsb.Click += sClickMenu;
                                sttBarraSup.Items.Add(tsb);
                            }
                            else
                            {
                                MessageBox.Show("O Usuário atual não possui permissão para visualizar Menu NFe/NFCe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("O fomulário Menu NFe/NFCe já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            foreach (Form f in this.MdiChildren)
                            {
                                if (f.Name == "FrmMenuNFeNFCe")
                                {
                                    f.Activate();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do menuToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do menuToolStripMenuItem.");
                }
            }
        }

        private void criarNFeToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void criarNFeToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void dFeToolStripMenuItem1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void dFeToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void menuNFSeToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void menuNFSeToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickNFSe(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmMenuNFSe")
                {
                    f.Activate();
                }
            }
        }

        private void menuNFSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder visualizar Menu NFSe é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(tslblVersao.Text) != 0)
                    {
                        MessageBox.Show("Não é possível iniciar [ Menu NFSe ] porque o caixa está fechado.\n\nAbra o caixa e tente novamente.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (bllNFSe._FrmMenuNFSe_Ativo == false)
                        {
                            if (bllUsuario.Sel_Acessar_Menu_NFSe(tslblUsuario.Text) == true)
                            {
                                FrmMenuNFSe Menu = new FrmMenuNFSe(tslblUsuario.Text, tslblVersao.Text, 0, null);
                                Menu.MdiParent = this;
                                Menu.Show();
                                Menu.WindowState = FormWindowState.Normal;
                                //
                                ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                                tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\abrir-menu.png");
                                tsb.Tag = "Menu1";
                                tsb.Text = "Menu NFSe";
                                tsb.ToolTipText = "Menu NFSe";
                                tsb.Name = "FrmMenuNFSe";
                                tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                                tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                                tsb.BackColor = Color.LightGray;
                                tsb.MouseMove += sMouseMove;
                                tsb.MouseLeave += sMouseLeave;
                                tsb.Click += sClickNFSe;
                                sttBarraSup.Items.Add(tsb);
                            }
                            else
                            {
                                MessageBox.Show("O Usuário atual não possui permissão para visualizar Menu NFSe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("O fomulário Menu NFSe já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            foreach (Form f in this.MdiChildren)
                            {
                                if (f.Name == "FrmMenuNFSe")
                                {
                                    f.Activate();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do menuToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do menuToolStripMenuItem.");
                }
            }
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            bllBackup.RealizarBackupFbkRede(this);
        }

        private void nFeNFCeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllDFe._FrmRelDocFiscais_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_DFe(tslblUsuario.Text) == true)
                        {
                            FrmRelDFe NFe = new FrmRelDFe(tslblVersao.Text, tslblUsuario.Text);
                            NFe.MdiParent = this;
                            NFe.Show();
                            NFe.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\brasil.png");
                            tsb.Tag = "RelDFe";
                            tsb.Text = "Relatório de DFe - Documentos Fiscais Eletrônicos";
                            tsb.ToolTipText = "Relatório de DFe - Documentos Fiscais Eletrônicos";
                            tsb.Name = "_FrmRelDFe";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelDFe;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de DFe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de DFe já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelDFe")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do dFeToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do dFeToolStripMenuItem.");
                }
            }
        }

        private void nFeNFCeToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void nFeNFCeToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void nFSeToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void nFSeToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void sangriaSuprimentoToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void sangriaSuprimentoToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickSangria(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadSangriaSuprimento")
                {
                    f.Activate();
                }
            }
        }

        private void sangriaSuprimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllSangriaSuprimento._FrmCadSangriaSuprimento_Aberto == false)
                {
                    if (bllUsuario.Sel_Reallizar_SangSup_Usuario(tslblUsuario.Text) == true)
                    {
                        FrmCadSangriaSuprimento Serv = new FrmCadSangriaSuprimento(tslblUsuario.Text, tslblVersao.Text, 0, null);
                        Serv.MdiParent = this;
                        Serv.Show();
                        Serv.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\money-coin.png");
                        tsb.Tag = "SangSup";
                        tsb.Text = "Cadastro de Sangria e Suprimento";
                        tsb.ToolTipText = "Cadastro de Sangria e Suprimento";
                        tsb.Name = "FrmCadSangriaSuprimento";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickSangria;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Sangria e Suprimento.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O fomulário Cadastro de Sangria e Suprimento já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadSangriaSuprimento")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadSangriaSuprimento.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadSangriaSuprimento.");
                }
            }
        }

        private void orçamentosToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void orçamentosToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickOrc(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadOrcamento")
                {
                    f.Activate();
                }
            }
        }

        private void orçamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllOrcamento._FrmOrcamento_Ativo == false)
                {
                    if (bllUsuario.Sel_Reallizar_Orcamento_Usuario(tslblUsuario.Text) == true)
                    {
                        FrmCadOrcamento Orc = new FrmCadOrcamento(tslblUsuario.Text, tslblVersao.Text);
                        Orc.MdiParent = this;
                        Orc.Show();
                        Orc.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\report--arrow.png");
                        tsb.Tag = "FrmCadOrcamento";
                        tsb.Text = "Cadastro de Orçamentos";
                        tsb.ToolTipText = "Cadastro de Orçamentos";
                        tsb.Name = "FrmCadOrcamento_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickOrc;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Orçamentos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O formulário Cadastro de Orçamentos já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadOrcamento")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadProduto.");
                }
            }
        }

        private void integraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIntegracoes Prod = new FrmIntegracoes(tslblUsuario.Text, tslblVersao.Text);
            Prod.MdiParent = this;
            Prod.Show();
        }
      
        private void bckwInicio_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(this, e.Error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwInicio.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + e.Error + " | Evento runworkercompleted do bckwInicio.");
                }
            }
        }

        private void bckwInicio_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            bllVersao.CriarArquivoLogLoginServ("seven_adm", _Versao, null);
            //
            DataTable Lembrete = bllLembrete.Sel_Lembrete_Data("01/01/2025", DateTime.Now.ToShortDateString(), "ABERTO");
            //
            if (Lembrete != null)
            {
                for (int i = 0; i < Lembrete.Rows.Count; i++)
                {
                    DataRow dr = Lembrete.Rows[i];
                    //
                    bllLembrete.Pendente_Lembrete(dr["id_lembrete"].ToString());
                    //
                    
                }
                //
                if (Convert.ToInt32(bllLetreiro.Sel_Quantidade_Lembrete()) >= 1 & bllLetreiro.Sel_Tipo_Letreiro_Existe("LEMBRETE") == false)
                {
                    bllLetreiro.Salvar_Letreiro("Existe(m) " + bllLetreiro.Sel_Quantidade_Lembrete() + " lembrete(es) pendente(s) que ainda não foi(ram) finalizado(os).", "1", "LEMBRETE");
                }
                else if (Convert.ToInt32(bllLetreiro.Sel_Quantidade_Lembrete()) >= 1)
                {
                    bllLetreiro.Alterar_Letreiro("Existe(m) " + bllLetreiro.Sel_Quantidade_Lembrete() + " lembrete(es) pendente(s) que ainda não foi(ram) finalizado(os).", "LEMBRETE");
                }
            }
            //
            bool alarmar = false;
            if (bllLembrete.Sel_Lembrete_Usuario(tslblUsuario.Text, "PENDENTE") != null)
            {
                alarmar = true;
            }
            //
            if (alarmar == true)
            {
                notifyIcon.BalloonTipText = "Você possui um(ou mais) LEMBRETE(s) em aberto..";
                notifyIcon.ShowBalloonTip(20000);
                notifyIcon.BalloonTipClicked += NotifyIcon_BallonTipClicked;
            }
        }

        private void NotifyIcon_BallonTipClicked(Object sender, EventArgs e)
        {
            lembretesToolStripMenuItem1_Click(sender, e);
        }



        private void comissõesToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void comissõesToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickRelCom(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelComissao")
                {
                    f.Activate();
                }
            }
        }

        private void comissõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllComissao._FrmRelComissao_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Comisssao(tslblUsuario.Text) == true)
                        {
                            FrmRelComissao Com = new FrmRelComissao(tslblUsuario.Text, tslblVersao.Text);
                            Com.MdiParent = this;
                            Com.Show();
                            Com.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\book-open-text.png");
                            tsb.Tag = "RelComiss";
                            tsb.Text = "Relatório de Comissões";
                            tsb.ToolTipText = "Relatório de Comissões";
                            tsb.Name = "FrmRelComissao";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelCom;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Comissões.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Histórico do Caixa já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelComissao")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do comissõesToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do comissõesToolStripMenuItem.");
                }
            }
        }

        private void button1_Click_6(object sender, EventArgs e)
        {
            /*
            bllVersao.LimparArquivosRecebidos();
            //
            if (bllVersao.VerificarAtualizacoesSeven_Adm() == true)
            {
                bllVersao.BaixarAtualizacoesSeven_Adm();
            }
            //
            if (bllVersao.VerificarAtualizacoesSeven_Pdv() == true)
            {
                bllVersao.BaixarAtualizacoesSeven_Pdv();
            }
            //
            if (bllVersao.VerificarAtualizacoesBLL() == true)
            {
                bllVersao.BaixarAtualizacoesBLL();
            }
            //
            if (bllVersao.VerificarAtualizacoesDAL() == true)
            {
                bllVersao.BaixarAtualizacoesDAL();
            }
            //
            if (bllVersao.VerificarAtualizacoesSeven_Config() == true)
            {
                bllVersao.BaixarAtualizacoesSeven_Config();
            }
            //
            if (bllVersao.VerificarAtualizacoesACBR_Lib() == true)
            {
                bllVersao.BaixarAtualizacoes_ACBR_Lib();
            }
            //
            if (bllVersao.VerificarAtualizacoesConfig() == true)
            {
                bllVersao.BaixarAtualizacoes_Config();
            }
            //
            if (bllVersao.VerificarAtualizacoesSistemaSeven() == true)
            {
                bllVersao.BaixarAtualizacoes_Sistema_Seven();
            }
            */
        }

        private void sttBancoLet_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void abrirCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.Sel_Reallizar_Abert_Caixa_Usuario(tslblUsuario.Text) == true)
                {
                    this.Enabled = false;
                    using (FrmAbrirCaixa Abrir = new FrmAbrirCaixa(tslblUsuario.Text, tslblVersao.Text))
                    {
                        if (Abrir.ShowDialog() == DialogResult.OK)
                        {
                            
                        }
                    }
                    this.Enabled = true;
                }
                else
                {
                    this.Enabled = false;
                    using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(tslblUsuario.Text, tslblVersao.Text, "Permitir_Abrir_Caixa"))
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda._Permitir_Abrir_Caixa == 1)
                            {
                                using (FrmAbrirCaixa Abrir = new FrmAbrirCaixa(tslblUsuario.Text, tslblVersao.Text))
                                {
                                    if (Abrir.ShowDialog() == DialogResult.OK)
                                    {

                                    }
                                }
                            }
                            else if (bllVenda._Permitir_Abrir_Caixa == 0)
                            {
                                MessageBox.Show("O Usuário informado não possui permissão para realizar Abertura de Caixa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    this.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do abrirCaixaToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento Click do abrirCaixaToolStripMenuItem.");
                }
            }
        }

        private void utilitáriosToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                if (bllConfiguracaoSistema.Sel_Abert_Fech_Caixa_Config() == false)
                {
                    if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(tslblVersao.Text) == 0)
                    {
                        abrirCaixaToolStripMenuItem.Enabled = false;
                        fecharCaixaToolStripMenuItem.Enabled = false;
                    }
                    else if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(tslblVersao.Text) == 1)
                    {
                        abrirCaixaToolStripMenuItem.Enabled = false;
                        fecharCaixaToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        abrirCaixaToolStripMenuItem.Enabled = true;
                        fecharCaixaToolStripMenuItem.Enabled = false;
                    }
                }
                else
                {
                    if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(tslblVersao.Text) == 0)
                    {
                        abrirCaixaToolStripMenuItem.Enabled = false;
                        fecharCaixaToolStripMenuItem.Enabled = true;
                    }
                    else if (bllAbert_Fech_Caixa.Sel_Aberto_Fechado_Caixa(tslblVersao.Text) == 1)
                    {
                        abrirCaixaToolStripMenuItem.Enabled = false;
                        fecharCaixaToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        abrirCaixaToolStripMenuItem.Enabled = true;
                        fecharCaixaToolStripMenuItem.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento DropDownOpened do utilitáriosToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento DropDownOpened do utilitáriosToolStripMenuItem.");
                }
            }
        }

        private void abrirCaixaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void abrirCaixaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void fecharCaixaToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void fecharCaixaToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void fecharCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                if (bllUsuario.Sel_Reallizar_Fechamento_Caixa_Usuario(tslblUsuario.Text) == true)
                {
                    Form[] mdichild = this.MdiChildren;

                    if (this.MdiChildren.Length > 0)
                    {
                        MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        using (FrmFecharCaixa Fechar = new FrmFecharCaixa(tslblUsuario.Text, tslblVersao.Text))
                        {
                            if (Fechar.ShowDialog() == DialogResult.OK)
                            {
                                
                            }
                        }
                    }
                }
                else
                {
                    using (FrmLoginUsuarioPerm Login = new FrmLoginUsuarioPerm(tslblUsuario.Text, tslblVersao.Text, "Permitir_Fechar_Caixa"))
                    {
                        if (Login.ShowDialog() == DialogResult.OK)
                        {
                            if (bllVenda._Permitir_Fechar_Caixa == 1)
                            {
                                using (FrmFecharCaixa Fechar = new FrmFecharCaixa(tslblUsuario.Text, tslblVersao.Text))
                                {
                                    if (Fechar.ShowDialog() == DialogResult.OK)
                                    {
                                      
                                    }
                                }
                            }
                            else if (bllVenda._Permitir_Fechar_Caixa == 0)
                            {
                                MessageBox.Show("O Usuário informado não possui permissão para realizar Fechamento do Caixa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                }
                this.Enabled = true;
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do fecharCaixaToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do fecharCaixaToolStripMenuItem.");
                }
            }
        }

        void sClickRelOS(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmRelOS")
                {
                    f.Activate();
                }
            }
        }

        private void ordemDeServiçosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllOS._FrmRelOS_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_OS(tslblUsuario.Text) == true)
                        {
                            FrmRelOS Os = new FrmRelOS(tslblUsuario.Text, tslblVersao.Text);
                            Os.MdiParent = this;
                            Os.Show();
                            Os.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\document-share.png");
                            tsb.Tag = "RelOS";
                            tsb.Text = "Relatório de Ordem de Serviço";
                            tsb.ToolTipText = "Relatório de Ordem de Serviço";
                            tsb.Name = "_FrmRelOS_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelOS;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Ordem de Serviço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Ordem de Serviço já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelOS")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do ordemDeServiçosToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do ordemDeServiçosToolStripMenuItem.");
                }
            }
        }

        private void ordemDeServiçosToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void ordemDeServiçosToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void menuNFeNFCeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void meuCertificadoDigitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ACBrNFe ACBrNFe;
                if (File.Exists(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini"))
                {
                    ACBrNFe = new ACBrNFe(@"C:\Sistema SEVEN\Config\" + bllConexao._Codigo_Conexao + "nfenfce.ini");
                }
                else
                {
                    ACBrNFe = new ACBrNFe();
                }
                //
                var ret = ACBrNFe.ObterCertificados();
                //
                var array = ret.Select(x => x.ToString()).ToArray();
                //
                MessageBox.Show(string.Join(Environment.NewLine, array), "Informações do Certificado Digital", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do meuCertificadoDigitalToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do meuCertificadoDigitalToolStripMenuItem.");
                }
            }
        }

        private void meuCertificadoDigitalToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void meuCertificadoDigitalToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllRegistroAtividades._FrmRelRegistroAtividades_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Registro_Atividade(tslblUsuario.Text) == true)
                        {
                            FrmRelRegistroAtividade Reg = new FrmRelRegistroAtividade(tslblUsuario.Text, tslblVersao.Text);
                            Reg.MdiParent = this;
                            Reg.Show();
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\calendar-day.png");
                            tsb.Tag = "RegAtiv";
                            tsb.Text = "Registro de Atividades";
                            tsb.ToolTipText = "Registro de Atividades";
                            tsb.Name = "_FrmRelRegistroAtividades_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRegAtiv;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Registro de Atividades.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Registro de Atividades já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelRegistroAtividade")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do toolStripMenuItem2.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do toolStripMenuItem2.");
                }
            }
        }

        private void registroAtividadeToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void registroAtividadeToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem2_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (bllPSP._FrmCadPSPPIX_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_PSP_PIX(tslblUsuario.Text) == true)
                    {
                        FrmCadPSPPIX Pix = new FrmCadPSPPIX(tslblUsuario.Text, tslblVersao.Text);
                        Pix.MdiParent = this;
                        Pix.Show();
                        Pix.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\pix.png");
                        tsb.Tag = "PSP";
                        tsb.Text = "Cadastro de PSP/PIX";
                        tsb.ToolTipText = "Cadastro de PSP/PIX";
                        tsb.Name = "FrmCadPSPPIX";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickPSP;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar PSP/PIX.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O fomulário Cadastro de PSP/PIX já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadPSPPIX")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadEntidadeBancaria.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadEntidadeBancaria.");
                }
            }
        }

        private void toolStripMenuItem2_MouseMove_1(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem2_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_ContMostrar_Logado.ToString());
        }

        private void TemporizadorLogin_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_Tempo_Mostrar_Logado == _ContMostrar_Logado)
                {
                    DateTime TempoLogado = new DateTime();
                    //
                    TempoLogado = TempoLogado.AddSeconds(_ContMostrar_Logado);
                    //
                    _Tempo_Mostrar_Logado = _Tempo_Mostrar_Logado + 86400;
                    //
                    bllVersao.CriarArquivoLogLoginServ("seven_adm", _Versao, TempoLogado.Hour.ToString() + "h " + TempoLogado.Minute.ToString() + "min");
                    //
                    if (bllMinhaEmpresa.Sel_Empresa_Backup_Automatico() == true)
                    {
                        if (bllMinhaEmpresa.Sel_Empresa_CPFCNPJ() != null)
                        {
                            DialogResult = MessageBox.Show("O Backup do Sistema não é realizado há mais de 24 horas. Deseja executá-lo agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (DialogResult == DialogResult.Yes)
                            {
                                using (FrmProgresso Prog = new FrmProgresso(2))
                                {
                                    if (Prog.ShowDialog() == DialogResult.OK)
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
                //
                _ContMostrar_Logado++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento tick do botão TemporizadorLogin.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento tick do botão TemporizadorLogin.");
                }
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllDevolucao._FrmRelDevolucao_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Devolucao(tslblUsuario.Text) == true)
                        {
                            FrmRelDevolucao Dev = new FrmRelDevolucao(tslblUsuario.Text, tslblVersao.Text);
                            Dev.MdiParent = this;
                            Dev.Show();
                            Dev.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\arrow-circle-double.png");
                            tsb.Tag = "RelDevProd";
                            tsb.Text = "Relatório de Devolução de Produtos/Serviços";
                            tsb.ToolTipText = "Relatório de Devolução de Produtos/Serviços";
                            tsb.Name = "_FrmRelDevolucao_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelDevProd;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Devolução de Produtos/Serviços.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Devolução de Produtos/Serviços já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelDevolucao")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do sToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do sToolStripMenuItem.");
                }
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllProduto._FrmRelSaldoAtualEstoque_Ativo == false)
                    {
                        FrmRelSaldoAtual Sal = new FrmRelSaldoAtual(tslblUsuario.Text, tslblVersao.Text);
                        Sal.MdiParent = this;
                        Sal.Show();
                        Sal.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\package.png");
                        tsb.Tag = "Saldo";
                        tsb.Text = "Relatório de Saldo Atual de Estoque";
                        tsb.ToolTipText = "Relatório de Saldo Atual de Estoque";
                        tsb.Name = "_FrmRelSaldoAtualEstoque_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickSaldo;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Saldo Atual de Estoque já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelSaldoAtual")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do saldoAtualToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do saldoAtualToolStripMenuItem.");
                }
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllInventario._FrmInventario_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Estoque(tslblUsuario.Text) == true)
                        {
                            FrmRelInventario Inv = new FrmRelInventario(tslblUsuario.Text, tslblVersao.Text);
                            Inv.MdiParent = this;
                            Inv.Show();
                            Inv.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\clipboard-task.png");
                            tsb.Tag = "Inventario";
                            tsb.Text = "Inventário de Produtos/Serviços";
                            tsb.ToolTipText = "Inventário de Produtos/Serviços";
                            tsb.Name = "_FrmRelInventario";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickInv;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Inventário de Produtos/Serviços.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Inventário de Produtos/Serviços já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelInventario")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do inventárioDeEstoqueToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do inventárioDeEstoqueToolStripMenuItem.");
                }
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllProduto._FrmRelContagemInv_Ativo == false)
                    {
                        FrmRelContagemInv Sal = new FrmRelContagemInv(tslblUsuario.Text, tslblVersao.Text);
                        Sal.MdiParent = this;
                        Sal.Show();
                        Sal.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\clipboard--pencil.png");
                        tsb.Tag = "Contagem";
                        tsb.Text = "Relatório de Contagem de Inventário";
                        tsb.ToolTipText = "Relatório de Contagem de Inventário";
                        tsb.Name = "_FrmRelContagemInv_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickContagem;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Saldo Atual de Estoque já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelSaldoAtual")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do contagemDeEstoqueToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do contagemDeEstoqueToolStripMenuItem.");
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllLocalizacao._FrmRelLocalizacaoProd_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Localizacao(tslblUsuario.Text) == true)
                        {
                            FrmRelLocalizacao Loc = new FrmRelLocalizacao();
                            Loc.MdiParent = this;
                            Loc.Show();
                            Loc.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\magnifier--plus.png");
                            tsb.Tag = "RelLocalizacao";
                            tsb.Text = "Relatório de Localização";
                            tsb.ToolTipText = "Relatório de Localização";
                            tsb.Name = "_FrmRelLocalizacaoProd_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelLocal;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Localização de Produtos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Localização de Produtos já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelLocalizacao")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deLocalizaçãoToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deLocalizaçãoToolStripMenuItem.");
                }
            }
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllMarca._FrmRelMarca_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Marca(tslblUsuario.Text) == true)
                        {
                            FrmRelMarca Marca = new FrmRelMarca();
                            Marca.MdiParent = this;
                            Marca.Show();
                            Marca.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\star.png");
                            tsb.Tag = "RelMarcas";
                            tsb.Text = "Relatório de Marcas";
                            tsb.ToolTipText = "Relatório de Marcas";
                            tsb.Name = "_FrmRelMarca_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelMarca;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Marcas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Marcas já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelMarca")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deMarcasToolStripMenuItem1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deMarcasToolStripMenuItem1.");
                }
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllProduto._FrmRelProduto_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Produtos(tslblUsuario.Text) == true)
                        {
                            FrmRelProduto Prod = new FrmRelProduto(tslblUsuario.Text, tslblVersao.Text);
                            Prod.MdiParent = this;
                            Prod.Show();
                            Prod.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\box.png");
                            tsb.Tag = "RelProdutos";
                            tsb.Text = "Relatório de Produtos";
                            tsb.ToolTipText = "Relatório de Produtos";
                            tsb.Name = "_FrmRelProduto_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelProd;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Produtos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Produtos já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelProduto")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deProdutosToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deProdutosToolStripMenuItem.");
                }
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.OK)
                                {
                                    tslblEmpresa.Text = bllMinhaEmpresa.Sel_Nome_Empresa();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllValidade._FrmRelValidade_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Validade_Prod_Serv(tslblUsuario.Text) == true)
                        {
                            FrmRelValidade Val = new FrmRelValidade(tslblUsuario.Text, tslblVersao.Text);
                            Val.MdiParent = this;
                            Val.Show();
                            Val.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\date_error.png");
                            tsb.Tag = "RelValidade";
                            tsb.Text = "Relatório de Validade de Produto/Serviços";
                            tsb.ToolTipText = "Relatório de Validade de Produto/Serviços";
                            tsb.Name = "_FrmRelValidade";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelVal;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Validade de Produto/Serviços.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Validade de Produto/Serviço já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelValidade")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do validadeDeProdutoServiçoToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do validadeDeProdutoServiçoToolStripMenuItem.");
                }
            }
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllEntradasProdutos._FrmRelEntradasProdutos_Aberto == false)
                    {
                        if (bllUsuario.Sel_Rel_Entrada_Produtos(tslblUsuario.Text) == true)
                        {
                            FrmRelEntradasProdutos Ent = new FrmRelEntradasProdutos(tslblUsuario.Text, tslblVersao.Text);
                            Ent.MdiParent = this;
                            Ent.Show();
                            Ent.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\box-share.png");
                            tsb.Tag = "RelEntProd";
                            tsb.Text = "Relatório de Entradas de Produtos";
                            tsb.ToolTipText = "Relatório de Entradas de Produtos";
                            tsb.Name = "_FrmRelEntradasProdutos_Aberto";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelEntProd;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Entrada de Produtos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Entrada de Produtos já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelEntradasProdutos")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deFornecedoresDeProdutosToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deFornecedoresDeProdutosToolStripMenuItem.");
                }
            }
        }

        private void toolStripMenuItem10_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem10_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem9_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem9_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem16_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem16_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem3_MouseMove_1(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem3_MouseLeave_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem11_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem11_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem4_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem8_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem8_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem5_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem5_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem6_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem6_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem7_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem7_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            try
            {
                string strHostName = Dns.GetHostName();

                Form[] mdichild = this.MdiChildren;

                if (this.MdiChildren.Length > 0)
                {
                    MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (bllUsuario.Sel_Cadastrar_Empresa(tslblUsuario.Text) == true)
                    {
                        using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                        {
                            if (Emp.ShowDialog() == DialogResult.Abort)
                            {
                                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                {
                                    DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                    //
                                    tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                }
                            }
                        }
                    }
                    else if (bllUsuario.Sel_Cadastrar_Empresa(tslblUsuario.Text) == false & bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                    {
                        using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                        {
                            if (Emp.ShowDialog() == DialogResult.Abort)
                            {
                                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                {
                                    DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                    //
                                    tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para acessar dados da Empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do configuraçõesToolStripMenuItem.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do configuraçõesToolStripMenuItem.");
                }
            }
        }

        private void documentosToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void documentosToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem12_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem12_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() == null)
                {
                    DialogResult = MessageBox.Show("Ainda não foram inseridas as informações da empresa, deseja fazer isso agora?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult == DialogResult.Yes)
                    {
                        Form[] mdichild = this.MdiChildren;

                        if (this.MdiChildren.Length > 0)
                        {
                            MessageBox.Show("Por favor, finalize os formulários abertos antes de executar esta ação.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            using (FrmMinhaEmpresa Emp = new FrmMinhaEmpresa(tslblUsuario.Text, tslblVersao.Text))
                            {
                                if (Emp.ShowDialog() == DialogResult.Abort)
                                {
                                    if (bllMinhaEmpresa.Sel_Dados_Minha_Empresa() != null)
                                    {
                                        DataRow dr = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                                        //
                                        tslblEmpresa.Text = dr["nome"].ToString().Replace("&", "&&");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Para poder gerar relatórios é necessário inserir os dados da empresa.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    if (bllClieCons._FrmRelCliente_Ativo == false)
                    {
                        if (bllUsuario.Sel_Rel_Cliente_Consumidor(tslblUsuario.Text) == true)
                        {
                            Seven_Sistema.FrmRelClieCons Clie = new Seven_Sistema.FrmRelClieCons(tslblVersao.Text, tslblUsuario.Text);
                            Clie.MdiParent = this;
                            Clie.Show();
                            Clie.WindowState = FormWindowState.Normal;
                            //
                            ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                            tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\user-white.png");
                            tsb.Tag = "RelCliente";
                            tsb.Text = "Relatório de Clientes/Consumidores";
                            tsb.ToolTipText = "Relatório de Clientes/Consumidores";
                            tsb.Name = "_FrmRelCliente_Ativo";
                            tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                            tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                            tsb.BackColor = Color.LightGray;
                            tsb.MouseMove += sMouseMove;
                            tsb.MouseLeave += sMouseLeave;
                            tsb.Click += sClickRelClie;
                            sttBarraSup.Items.Add(tsb);
                        }
                        else
                        {
                            MessageBox.Show("O Usuário atual não possui permissão para visualizar Relatório de Clientes/Consumidores.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O fomulário Relatório de Clientes já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        foreach (Form f in this.MdiChildren)
                        {
                            if (f.Name == "FrmRelClieCons")
                            {
                                f.Activate();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deClientesToolStripMenuItem1.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do deClientesToolStripMenuItem1.");
                }
            }
        }

        private void documentosToolStripMenuItem1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void documentosToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void sClickDoc(Object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "FrmCadDocumentos")
                {
                    f.Activate();
                }
            }
        }


        private void documentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllDocumentos._FrmCadDocumentos_Ativo == false)
                {
                    if (bllUsuario.Sel_Cadastrar_Documentos(tslblUsuario.Text) == true)
                    {
                        FrmCadDocumentos Doc = new FrmCadDocumentos(tslblUsuario.Text, tslblVersao.Text, 0);
                        Doc.MdiParent = this;
                        Doc.Show();
                        Doc.WindowState = FormWindowState.Normal;
                        //
                        ToolStripStatusLabel tsb = new ToolStripStatusLabel();
                        tsb.Image = Image.FromFile(@"C:\Sistema SEVEN\Config\ToolStrip\folder-open-document.png");
                        tsb.Tag = "Documentos";
                        tsb.Text = "Cadastro de Documentos";
                        tsb.ToolTipText = "Cadastro de Documentos";
                        tsb.Name = "_FrmCadDocumentos_Ativo";
                        tsb.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                        tsb.BorderSides = ToolStripStatusLabelBorderSides.All;
                        tsb.BackColor = Color.LightGray;
                        tsb.MouseMove += sMouseMove;
                        tsb.MouseLeave += sMouseLeave;
                        tsb.Click += sClickDoc;
                        sttBarraSup.Items.Add(tsb);
                    }
                    else
                    {
                        MessageBox.Show("O Usuário atual não possui permissão para Cadastrar Documentos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("O formulário Cadastro de Documentos já está aberto.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.Name == "FrmCadDocumentos")
                        {
                            f.Activate();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadDocumentos.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do FrmCadDocumentos.");
                }
            }
        }

        private void toolStripMenuItem13_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void toolStripMenuItem13_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}
