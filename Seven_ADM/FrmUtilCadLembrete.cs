using BLL;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace Seven_Sistema
{
    public partial class FrmUtilCadLembrete : Form
    {
        public FrmUtilCadLembrete(string codigo, string data, string hora, string descricao, string observacao, string som_alerta, bool comando_atualizar, string usuario, string cod_pdv_computador, byte formulario, string tabela_geradora, string cod_fato_gerador)
        {
            InitializeComponent();
            _Comando_Atualizar = comando_atualizar;
            txtCodigo.Text = codigo;
            mtxtDataVencimento.Text = data;
            txtDescricao.Text = descricao;
            rtxtObservacoes.Text = observacao;
            cbbSomAlarme.Text = som_alerta;
            mtxtHora.Text = hora;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Formulario = formulario;
            _Data = data;
            _Tabela_Geradora = tabela_geradora;
            _Cod_Fato_Gerador = cod_fato_gerador;
        }

        private byte _Formulario;
        private bool _Comando_Atualizar;
        private string _Usuario;
        private string _Cod_PDV_Computador;
        private string _Data;
        private string _Tabela_Geradora;
        private string _Cod_Fato_Gerador;

        private void FrmContCadLembrete_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void FrmContCadLembrete_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário utilitário lembrete iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário utilitário lembrete iniciado.");
                }
                //
                if (_Comando_Atualizar == false)
                {
                    if (_Formulario == 1)
                    {
                        _Data = _Data.Remove(6) + DateTime.Now.Year;
                        //
                        DateTime d = Convert.ToDateTime(_Data);
                        //
                        if (d < DateTime.Now)
                        {
                            d = d.AddYears(1);
                            //
                            mtxtDataVencimento.Text = d.ToString();
                        }
                        else
                        {
                            mtxtDataVencimento.Text = _Data;
                        }
                    }
                    //
                    mtxtDataVencimento.Select();
                    cbbSomAlarme.Text = "ALERTA 2";

                    if (bllLembrete.Sel_Lembrete_Usuarios() == null)
                    {
                        lviewUsuarios.Enabled = false;
                    }
                    else
                    {
                        lviewUsuarios.Enabled = true;

                        foreach (DataRow dr in bllLembrete.Sel_Lembrete_Usuarios().Rows)
                        {
                            lviewUsuarios.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                        }
                    }

                    for (int i = 0; i < lviewUsuarios.Items.Count; i++)
                    {
                        string[] items = lviewUsuarios.Items[i].Text.Split('—');

                        string[] items1 = _Usuario.Replace("Usuário(a): ", "").Split('—');

                        if (items1[0] == items[0])
                        {
                            lviewUsuarios.Items[i].Checked = true;
                        }
                    }
                }
                else
                {
                    if (bllLembrete.Sel_Lembrete_Usuarios() == null)
                    {
                        lviewUsuarios.Enabled = false;
                    }
                    else
                    {
                        lviewUsuarios.Enabled = true;

                        foreach (DataRow dr in bllLembrete.Sel_Lembrete_Usuarios().Rows)
                        {
                            lviewUsuarios.Items.Add((dr["id_usuario"].ToString()) + "—" + (dr["nome_usuario"].ToString()));
                        }
                    }
                    //
                    for (int i = 0; i < lviewUsuarios.Items.Count; i++)
                    {
                        for (int a = 0; a < bllLembrete.Sel_Ver_Usuario_Lembrete(txtCodigo.Text).Rows.Count; a++)
                        {
                            DataRow dr = bllLembrete.Sel_Ver_Usuario_Lembrete(txtCodigo.Text).Rows[a];

                            string[] items = lviewUsuarios.Items[i].Text.Split('—');

                            if (dr["id_usuario"].ToString() == items[0])
                            {
                                lviewUsuarios.Items[i].Checked = true;
                            }
                        }
                    }
                    //
                    txtCodigo.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do form.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do form.");
                }
            }
        }

        private void lblOuvir_Click(object sender, EventArgs e)
        {
            if (cbbSomAlarme.Text == "")
            {
                MessageBox.Show("Por favor, selecione um alarme para escutar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
                cbbSomAlarme.Select();
            }
            else
            {
                try
                {
                    SoundPlayer Player = new SoundPlayer();

                    if (cbbSomAlarme.SelectedIndex == 0)
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-01.wav";
                        Player.Play();
                    }
                    else if (cbbSomAlarme.SelectedIndex == 1)
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-02.wav";
                        Player.Play();
                    }
                    else if (cbbSomAlarme.SelectedIndex == 2)
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-03.wav";
                        Player.Play();
                    }
                    else if (cbbSomAlarme.SelectedIndex == 3)
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-04.wav";
                        Player.Play();
                    }
                    else if (cbbSomAlarme.SelectedIndex == 4)
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-05.wav";
                        Player.Play();
                    }
                    else if (cbbSomAlarme.SelectedIndex == 5)
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-06.wav";
                        Player.Play();
                    }
                    else if (cbbSomAlarme.SelectedIndex == 6)
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-07.wav";
                        Player.Play();
                    }
                    else if (cbbSomAlarme.SelectedIndex == 7)
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-08.wav";
                        Player.Play();
                    }
                    else if (cbbSomAlarme.SelectedIndex == 8)
                    {
                        Player.SoundLocation = @"C:\Sistema SEVEN\Config\Sons Alarme\Alert-09.wav";
                        Player.Play();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnOuvir.");
                    }

                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnOuvir.");
                    }
                    cbbSomAlarme.Select();
                }
            }
        }

        private void lblOuvir_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lblOuvir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbSomAlarme_DropDown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSomAlarme_DropDownClosed(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void cbbSomAlarme_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescricao.Select();
            }
        }

        private void mtxtHora_Enter(object sender, EventArgs e)
        {
            mtxtHora.BackColor = Color.LightBlue;
        }

        private void mtxtHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbSomAlarme.Select();
            }
        }

        private void mtxtHora_Leave(object sender, EventArgs e)
        {
            mtxtHora.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHora.Text != "")
            {
                try
                {
                    mtxtHora.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    ValidarData.Ver_Hora(mtxtHora.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHora.");
                    }

                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHora.");
                    }
                    mtxtHora.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHora.Text = null;
                }
            }
            mtxtHora.BackColor = Color.White;
        }

        private void txtDescricao_Enter(object sender, EventArgs e)
        {
            txtDescricao.BackColor = Color.LightBlue;
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                rtxtObservacoes.Select();
            }
        }

        private void txtDescricao_Leave(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Contains("'") || txtDescricao.Text.Contains(";") || txtDescricao.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtDescricao.Text = null;
            }
            txtDescricao.BackColor = Color.White;
        }

        private void rtxtObservacoes_Enter(object sender, EventArgs e)
        {
            rtxtObservacoes.BackColor = Color.LightBlue;
        }

        private void rtxtObservacoes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                lviewUsuarios.Select();
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

        private void rtxtObservacoes_Leave(object sender, EventArgs e)
        {
            rtxtObservacoes.BackColor = Color.White;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = MessageBox.Show("Deseja salvar os dados informados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    mtxtHora.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataVencimento.Text == "" || cbbSomAlarme.Text == "" || mtxtHora.Text == "" || txtDescricao.Text == "" || lviewUsuarios.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Existem campos obrigatórios que precisam ser preenchidos: [ Data ], [ Hora ], [ Descrição ], [ Usuários ] e [ Som do Alarme ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtHora.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtDataVencimento.Select();
                    }
                    else
                    {
                        mtxtHora.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (_Comando_Atualizar == true)
                        {
                            for (int a = 0; a < lviewUsuarios.CheckedItems.Count; a++)
                            {
                                ListViewItem i = lviewUsuarios.CheckedItems[a];
                                if (bllLembrete.Ver_Usuario_Horario_Data_Alt(txtCodigo.Text, i.Text, mtxtDataVencimento.Text, mtxtHora.Text))
                                {
                                    DialogResult = MessageBox.Show("Conflito!\nO usuário " + i.Text.Replace('—', '-') + " já possui um lembrete na data " + mtxtDataVencimento.Text + " no horário " + mtxtHora.Text + ".\n\nDeseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        this.DialogResult = DialogResult.None;
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.None;
                                        return;
                                    }
                                }
                            }

                            string primeiroitem = null;
                            foreach (ListViewItem i in lviewUsuarios.CheckedItems)
                            {
                                primeiroitem = i.Text;
                                break;
                            }

                            bllLembrete.Alterar(txtCodigo.Text, mtxtDataVencimento.Text, mtxtHora.Text, txtDescricao.Text.Trim(), rtxtObservacoes.Text.Trim(), cbbSomAlarme.Text, primeiroitem, lviewUsuarios.CheckedItems.Count);

                            bllRegistroAtividades.Salvar("ALTEROU DADOS DE UM LEMBRETE", "LEMBRETE", txtCodigo.Text, _Usuario, _Cod_PDV_Computador);
                            //
                            bllLembrete.Excluir_Usuario_Lembrete(txtCodigo.Text);

                            foreach (ListViewItem i in lviewUsuarios.CheckedItems)
                            {
                                string[] items = i.Text.Split('—');
                                bllLembrete.Salvar_Usuario_Lembrete(txtCodigo.Text, items[0], items[1], mtxtDataVencimento.Text, mtxtHora.Text);
                            }
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
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Lembrete alterado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text.Trim());
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Lembrete alterado. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text.Trim());
                            }
                            //
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            for (int a = 0; a < lviewUsuarios.CheckedItems.Count; a++)
                            {
                                ListViewItem i = lviewUsuarios.CheckedItems[a];
                                if (bllLembrete.Ver_Usuario_Horario_Data(i.Text, mtxtDataVencimento.Text, mtxtHora.Text))
                                {
                                    DialogResult = MessageBox.Show("Conflito!\nO usuário " + i.Text.Replace('—', '-') + " já possui um lembrete na data " + mtxtDataVencimento.Text + " no horário " + mtxtHora.Text + ".\n\nDeseja continuar?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (DialogResult == DialogResult.Yes)
                                    {
                                        this.DialogResult = DialogResult.None;
                                    }
                                    else
                                    {
                                        this.DialogResult = DialogResult.None;
                                        return;
                                    }
                                }
                            }
                            //
                            string primeiroitem = null;
                            foreach (ListViewItem i in lviewUsuarios.CheckedItems)
                            {
                                primeiroitem = i.Text;
                                break;
                            }
                            //
                            bllLembrete.Salvar(mtxtDataVencimento.Text, mtxtHora.Text, txtDescricao.Text.Trim(), rtxtObservacoes.Text.Trim(), cbbSomAlarme.Text, primeiroitem, lviewUsuarios.CheckedItems.Count, _Tabela_Geradora, _Cod_Fato_Gerador);
                            //
                            string codigo = bllLembrete.Sel_Lembrete_Ultimo_Cod_Adicionado();
                            //
                            bllRegistroAtividades.Salvar("SALVOU UM LEMBRETE", "LEMBRETE", codigo, _Usuario, _Cod_PDV_Computador);
                            //
                            foreach (ListViewItem i in lviewUsuarios.CheckedItems)
                            {
                                string[] items = i.Text.Split('—');
                                bllLembrete.Salvar_Usuario_Lembrete(codigo, items[0], items[1], mtxtDataVencimento.Text, mtxtHora.Text);
                            }
                            //
                            if (_Formulario == 1)
                            {
                                DialogResult = MessageBox.Show("Deseja que o lembrete criado para esse aniversáriante seja mantido todo ano?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (DialogResult == DialogResult.Yes)
                                {
                                    this.DialogResult = DialogResult.None;
                                    int seq = 1;
                                    string _Data_Multiplicada;
                                    //
                                    for (int a = 0; a < 30; a++)
                                    {
                                        DateTime d = Convert.ToDateTime(mtxtDataVencimento.Text);
                                        _Data_Multiplicada = d.AddYears(seq).ToString("dd/MM/yyyy");
                                        //
                                        bllLembrete.Salvar(_Data_Multiplicada, mtxtHora.Text, txtDescricao.Text.Trim(), rtxtObservacoes.Text.Trim(), cbbSomAlarme.Text, primeiroitem, lviewUsuarios.CheckedItems.Count, null, null);
                                        //
                                        codigo = bllLembrete.Sel_Lembrete_Ultimo_Cod_Adicionado();
                                        //
                                        foreach (ListViewItem i in lviewUsuarios.CheckedItems)
                                        {
                                            string[] items = i.Text.Split('—');
                                            bllLembrete.Salvar_Usuario_Lembrete(codigo, items[0], items[1], mtxtDataVencimento.Text, mtxtHora.Text);
                                        }
                                        //
                                        seq++;
                                    }
                                }
                                else
                                {
                                    DialogResult = DialogResult.None;
                                }
                            }
                            //
                            MessageBox.Show("Os dados foram salvos com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //
                            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Lembrete salvo. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text.Trim());
                            }
                            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                            {
                                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Lembrete salvo. Cod: " + txtCodigo.Text + " | Descrição: " + txtDescricao.Text.Trim());
                            }
                            //
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnSalvar.");
                }
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

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Hora: O campo hora é preenchido no formato HH:mm (Hora : Minuto).\n2 - Alarmar os seguintes usuários do sistema: Selecione os usuários que serão alertados pelo alarme.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void cbbSomAlarme_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void cbbSomAlarme_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lviewUsuarios_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void lviewUsuarios_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void mtxtDataVencimento_Enter(object sender, EventArgs e)
        {
            mtxtDataVencimento.BackColor = Color.LightBlue;
        }

        private void mtxtDataVencimento_Leave(object sender, EventArgs e)
        {
            mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataVencimento.Text != "")
            {
                try
                {
                    mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataVencimento.Text);
                    //
                    if (Convert.ToDateTime(mtxtDataVencimento.Text) < DateTime.Now.Date)
                    {
                        MessageBox.Show("Não é possível criar lembretes pra datas menores que " + DateTime.Now.ToShortDateString() + ".", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                        mtxtDataVencimento.Text = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataVencimento.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataVencimento.");
                    }
                    mtxtDataVencimento.Text = null;
                }
            }
            mtxtDataVencimento.BackColor = Color.White;
        }

        private void btnSelecionarData3_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSelecionarData3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSelecionarData3_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmDatePicker Data = new FrmDatePicker(0))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataVencimento.Text = bllContasPagar._Data_DatePicker1;
                    bllContasPagar._Data_DatePicker1 = null;
                    mtxtDataVencimento.Select();
                }
            }
            this.Enabled = true;
        }

        private void mtxtDataVencimento_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataVencimento.Text == "")
            {
                mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataVencimento.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void mtxtDataVencimento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHora.Select();
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

        private void mtxtHora_DoubleClick(object sender, EventArgs e)
        {
            mtxtHora.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHora.Text == "")
            {
                mtxtHora.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHora.Text = DateTime.Now.ToString("HH:mm");
            }
            else
            {
                mtxtHora.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHora_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHora.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHora.Text == "")
                {
                    mtxtHora.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHora.Text = DateTime.Now.ToString("HH:mm");
                }
                else
                {
                    mtxtHora.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void btnMarcarDesmarcar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lviewUsuarios.Items.Count > 0)
                {
                    foreach (ListViewItem item in lviewUsuarios.Items)
                    {
                        item.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnMarcarDesmarcar.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnMarcarDesmarcar.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (lviewUsuarios.Items.Count > 0)
                {
                    foreach (ListViewItem item in lviewUsuarios.Items)
                    {
                        item.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnMarcarDesmarcar.");
                }

                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnMarcarDesmarcar.");
                }
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnMarcar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnMarcar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnDesmarcar_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnDesmarcar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataVencimento.Select();
            }
        }

        private void mtxtDataVencimento_KeyUp(object sender, KeyEventArgs e)
        {
            if (mtxtDataVencimento.ReadOnly == false)
            {
                if (e.KeyCode == Keys.Insert)
                {
                    mtxtDataVencimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataVencimento.Text == "")
                    {
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        mtxtDataVencimento.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        mtxtDataVencimento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    }
                }
            }
        }
    }
}
