using BLL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmUtilLembrete : Form
    {
        public FrmUtilLembrete(string codigo, string descricao, string horario, string data, byte formulario, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Codigo = codigo;
            lblValorDescricao.Text = descricao;
            if (horario != null)
            {
                lblValorHorario.Text = horario.Remove(5);
            }
            if (data != null)
            {
                lblValorDataVencimento.Text = "Data: " + data.Remove(10);
            }
            TempoLabel.Start();
            _Formulario = formulario;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Codigo;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private byte _Formulario;
        private string _Observacao;
        private string _Som_Alarme;

        private void FrmAlarme_Load(object sender, EventArgs e)
        {
            try
            {
                bllLembrete._FrmUtiLembrete_Ativo = true;
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmUtilAlarme iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmUtilAlarme iniciado.");
                }
                //
                if (bllLembrete.Sel_Alarme_Dia_Hora_Dados(_Codigo) != null)
                {
                    DataRow dr = bllLembrete.Sel_Alarme_Dia_Hora_Dados(_Codigo).Rows[0];
                    //
                    lblValorDescricao.Text = dr["descricao"].ToString();
                    lblValorHorario.Text = dr["horario"].ToString().Remove(5);
                    lblValorDataVencimento.Text = "Data: " + dr["data"].ToString().Remove(10);
                    _Som_Alarme = dr["som_alarme"].ToString();
                    //
                    TempoLabel.Start();
                    TempoSom.Start();
                    //
                    dr = bllLembrete.Sel_Lembrete_Codigo(_Codigo).Rows[0];
                    //
                    SoundPlayer Player = new SoundPlayer();
                    //
                    if (_Som_Alarme == "ALERTA 1")
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-01.wav";
                        Player.Play();
                    }
                    else if (_Som_Alarme == "ALERTA 2")
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-02.wav";
                        Player.Play();
                    }
                    else if (_Som_Alarme == "ALERTA 3")
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-03.wav";
                        Player.Play();
                    }
                    else if (_Som_Alarme == "ALERTA 4")
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-04.wav";
                        Player.Play();
                    }
                    else if (_Som_Alarme == "ALERTA 5")
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-05.wav";
                        Player.Play();
                    }
                    else if (_Som_Alarme == "ALERTA 6")
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-06.wav";
                        Player.Play();
                    }
                    else if (_Som_Alarme == "ALERTA 7")
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-07.wav";
                        Player.Play();
                    }
                    else if (_Som_Alarme == "ALERTA 8")
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-08.wav";
                        Player.Play();
                    }
                    else if (_Som_Alarme == "ALERTA 9")
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-09.wav";
                        Player.Play();
                    }
                    _Observacao = dr["observacao"].ToString();
                    //
                    btnAdiar.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmUtilAlarme.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmUtilAlarme.");
                }
            }
        }

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Finalizar: Clique neste botão para finalizar o lembrete.\n2 - Adiar: Clique para sair do lembrete sem finalizar, o mesmo permanecerá em aberto.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmPesquisarTipoIndicacao_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    if (_Formulario == 0)
                    {
                        this.DialogResult = DialogResult.Abort;
                    }
                    else
                    {
                        if (bllLembrete.Sel_Lembrete_Ainda_Existe(_Codigo) != false)
                        {
                            bllLembrete.Pendente_Lembrete(_Codigo);
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
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento KeyUp.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento KeyUp.");
                }
            }
        }

        private void btnAdiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Formulario == 0)
                {
                    this.DialogResult = DialogResult.Abort;
                }
                else
                {
                    if (bllLembrete.Sel_Lembrete_Ainda_Existe(_Codigo) != false)
                    {
                        bllLembrete.Pendente_Lembrete(_Codigo);
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
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAdiar.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnAdiar.");
                }
            }
        }

        private void btnAdiar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnAdiar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnFinalizar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnFinalizar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Deseja finalizar o lembrete?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.Yes)
            {
                try
                {
                    if (bllLembrete.Sel_Lembrete_Ainda_Existe(_Codigo) == false)
                    {
                        MessageBox.Show("Não é possível finalizar este registro pois o mesmo já foi excluído.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        if (_Formulario == 1)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.DialogResult = DialogResult.Abort;
                        }
                    }
                    else
                    {
                        bllLembrete.Baixa_Lembrete(_Codigo);
                        //
                        MessageBox.Show("Lembrete finalizado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //
                        if (bllLetreiro.Sel_Quantidade_Lembrete() == null)
                        {
                            bllLetreiro.Excluir_Letreiro("LEMBRETE");
                        }
                        else if (Convert.ToInt32(bllLetreiro.Sel_Quantidade_Lembrete()) == 0)
                        {
                            bllLetreiro.Excluir_Letreiro("LEMBRETE");
                        }
                        else if (Convert.ToInt32(bllLetreiro.Sel_Quantidade_Lembrete()) >= 1)
                        {
                            bllLetreiro.Alterar_Letreiro("Existe(m) " + bllLetreiro.Sel_Quantidade_Lembrete() + " lembrete(es) em aberto que ainda não foi(ram) finalizado(os).", "LEMBRETE");
                        }
                        //
                        if (_Formulario == 0)
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnFinalizar.");
                    }

                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnFinalizar.");
                    }
                }
            }
        }

        private void TemporalizadorLabel_Tick(object sender, EventArgs e)
        {
            if (lblValorHorario.ForeColor == Color.Black)
            {
                lblValorHorario.ForeColor = Color.Red;
            }
            else
            {
                lblValorHorario.ForeColor = Color.Black;
            }
        }

        private void picbInterrogacao1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void picbInterrogacao1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblValorDescricao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.IBeam;
        }

        private void lblValorDescricao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnOBservacao_Click(object sender, EventArgs e)
        {
            if (_Observacao == null || _Observacao == "")
            {
                MessageBox.Show("Não foi informada uma observação para este lembrete.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                MessageBox.Show("Observação:\n\n" + _Observacao, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
            }
        }

        private void btnOBservacao_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnOBservacao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void TempoSom_Tick(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer Player = new SoundPlayer();

                if (_Som_Alarme == "ALERTA 1")
                {
                    Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-01.wav";
                    Player.Play();
                }
                else if (_Som_Alarme == "ALERTA 2")
                {
                    Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-02.wav";
                    Player.Play();
                }
                else if (_Som_Alarme == "ALERTA 3")
                {
                    Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-03.wav";
                    Player.Play();
                }
                else if (_Som_Alarme == "ALERTA 4")
                {
                    Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-04.wav";
                    Player.Play();
                }
                else if (_Som_Alarme == "ALERTA 5")
                {
                    Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-05.wav";
                    Player.Play();
                }
                else if (_Som_Alarme == "ALERTA 6")
                {
                    Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-06.wav";
                    Player.Play();
                }
                else if (_Som_Alarme == "ALERTA 7")
                {
                    Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-07.wav";
                    Player.Play();
                }
                else if (_Som_Alarme == "ALERTA 8")
                {
                    Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-08.wav";
                    Player.Play();
                }
                else if (_Som_Alarme == "ALERTA 9")
                {
                    Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-09.wav";
                    Player.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnFinalizar.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnFinalizar.");
                }
            }
        }

        private void FrmUtilLembrete_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmUtilLembrete foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmUtilLembrete foi finalizado.");
                }
                bllLembrete._FrmUtiLembrete_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmUtilLembrete.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmUtilLembrete.");
                }
            }
        }
    }
}
