using BLL;
using Seven_Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seven_ADM
{
    public partial class FrmPesqOS : Form
    {
        public FrmPesqOS(byte formulario, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Formulario = formulario;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private byte _Formulario;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmPesqOS_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(@"C:\Sistema SEVEN\Config\Log\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Sistema SEVEN\Config\Log\Log de Acoes");
                }
                //
                if (!Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes"))
                {
                    Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqOS iniciado.");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqOS iniciado.");
                }
                //
                cbbpUsuario.Items.Clear();
                if (bllOS.Sel_Usuario_OS() == null)
                {
                    cbbpUsuario.Text = null;
                    cbbpUsuario.Enabled = false;
                    lblUsuario.Enabled = false;
                }
                else
                {
                    cbbpUsuario.Enabled = true;
                    lblUsuario.Enabled = true;
                    cbbpUsuario.Items.Add("");
                    foreach (DataRow dr in bllOS.Sel_Usuario_OS().Rows)
                    {
                        cbbpUsuario.Items.Add(dr["id_usuario"].ToString() + "—" + dr["nome_usuario"].ToString());
                    }
                }
                //
                cbbFuncionario.Items.Clear();
                if (bllOS.Sel_Funcionario_OS() == null)
                {
                    cbbFuncionario.Enabled = false;
                    cbbFuncionario.Text = null;
                }
                else
                {
                    cbbFuncionario.Enabled = true;
                    cbbFuncionario.Items.Add("");
                    foreach (DataRow dr in bllOS.Sel_Funcionario_OS().Rows)
                    {
                        cbbFuncionario.Items.Add(dr["id_funcionario"].ToString() + "—" + dr["nome"].ToString());
                    }
                }
                //
                cbbClieConsFunc.Items.Clear();
                if (bllOS.Sel_Cliente_OS() == null)
                {
                    cbbClieConsFunc.Enabled = false;
                    cbbClieConsFunc.Text = null;
                }
                else
                {
                    cbbClieConsFunc.Enabled = true;
                    cbbClieConsFunc.Items.Add("");
                    foreach (DataRow dr in bllOS.Sel_Cliente_OS().Rows)
                    {
                        string cpfcnpj;
                        if (dr["cpf_cnpj"].ToString() == "")
                        {
                            cpfcnpj = "";
                        }
                        else
                        {
                            cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                        }
                        cbbClieConsFunc.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                    }
                }
                //
                cbbFormaPagamento.Items.Clear();
                if (bllOS.Sel_Forma_Pagamento_OS() == null)
                {
                    cbbFormaPagamento.Text = null;
                    cbbFormaPagamento.Enabled = false;
                    lblFormaPagamento.Enabled = false;
                }
                else
                {
                    cbbFormaPagamento.Enabled = true;
                    lblFormaPagamento.Enabled = true;
                    cbbFormaPagamento.Items.Add("");
                    foreach (DataRow dr in bllOS.Sel_Forma_Pagamento_OS().Rows)
                    {
                        cbbFormaPagamento.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                    }
                }
                //
                mtxtpData.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqOS.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmPesqOS.");
                }
                this.DialogResult = DialogResult.None;
            }
        }

        private void mtxtpData_DoubleClick(object sender, EventArgs e)
        {
            mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData.Text == "")
            {
                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario.Select();
            }
        }

        private void btnSelecionarData_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(26))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtDataBaixa.Text = bllOS._Data_DatePicker1;
                    mtxtDataBaixa1.Text = bllOS._Data_DatePicker2;
                }
            }
            this.Enabled = true;
        }


        private void mtxtpData_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpData.Text == "")
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpData_Enter(object sender, EventArgs e)
        {
            mtxtpData.BackColor = Color.LightBlue;
        }

        private void mtxtpData_Leave(object sender, EventArgs e)
        {
            mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData.Text != "")
            {
                try
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpData.Text);

                    mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpData1.Text != "")
                    {
                        mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpData.Text) > Convert.ToDateTime(mtxtpData1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpData.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData.");
                    }
                    mtxtpData.Text = null;
                }
            }
            mtxtpData.BackColor = Color.White;
        }

        private void mtxtHorario_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario.Text == "")
            {
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorario.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpData1.Select();
            }
        }

        private void mtxtHorario_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorario.Text == "")
                {
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorario.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorario_Enter(object sender, EventArgs e)
        {
            mtxtHorario.BackColor = Color.LightBlue;
        }

        private void mtxtHorario_Leave(object sender, EventArgs e)
        {
            mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario.Text != "")
            {
                if (mtxtHorario.Text.Length == 4)
                {
                    mtxtHorario.Text = mtxtHorario.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorario.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario.");
                    }
                    mtxtHorario.Text = null;
                }
            }
            mtxtHorario.BackColor = Color.White;
        }

        private void mtxtpData1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData1.Text == "")
            {
                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpData1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpData1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorario1.Select();
            }
        }

        private void mtxtpData1_Enter(object sender, EventArgs e)
        {
            mtxtpData1.BackColor = Color.LightBlue;
        }

        private void mtxtpData1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpData1.Text == "")
                {
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpData1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }



        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                mtxtHorario.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                mtxtDataBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtDataBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                mtxtHorarioBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if ((mtxtpData.Text == "" & mtxtpData1.Text != "") || (mtxtpData.Text != "" & mtxtpData1.Text == ""))
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    mtxtpData.Select();
                }
                else if ((mtxtDataBaixa.Text == "" & mtxtDataBaixa1.Text != "") || (mtxtDataBaixa.Text != "" & mtxtDataBaixa1.Text == ""))
                {
                    mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    mtxtHorarioBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    MessageBox.Show("É necessário preencher ambos os campos de [ Data Baixa ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    mtxtDataBaixa.Select();
                }
                else
                {
                    mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    mtxtHorario.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    mtxtHorarioBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    //
                    if (bllOS.Sel_OS_Data_Codigo_Clie_Func_Usuario_Situacao_Data_Baixa(cbbpSituacao.Text, cbbpUsuario.Text, txtpCodigo.Text.Trim(), mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbClieConsFunc.Text, cbbFuncionario.Text, mtxtDataBaixa.Text, mtxtDataBaixa1.Text, mtxtHorarioBaixa.Text, mtxtHorarioBaixa1.Text, cbbFormaPagamento.Text, "", "", "") == null)
                    {
                        dtPesquisa.DataSource = null;
                        MessageBox.Show("Nenhum registro encontrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.None;
                    }
                    else
                    {
                        dtPesquisa.DataSource = bllOS.Sel_OS_Data_Codigo_Clie_Func_Usuario_Situacao_Data_Baixa(cbbpSituacao.Text, cbbpUsuario.Text, txtpCodigo.Text.Trim(), mtxtpData.Text, mtxtpData1.Text, mtxtHorario.Text, mtxtHorario1.Text, cbbClieConsFunc.Text, cbbFuncionario.Text, mtxtDataBaixa.Text, mtxtDataBaixa1.Text, mtxtHorarioBaixa.Text, mtxtHorarioBaixa1.Text, cbbFormaPagamento.Text, "", "", "");
                        dtPesquisa.Select();
                    }
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou ordem de serviço.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Pesquisou ordem de serviço.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisar.");
                }
                dtPesquisa.DataSource = null;
            }
        }

        private void FrmPesqOS_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void FrmPesqOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqOS foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmPesqOS foi finalizado.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPesqOS.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmPesqOS.");
                }
            }
        }


        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nesta seção você pesquisará os dados por data, descrição, código, cliente/consumidor, funcionário e todos os dados cadastrados e/ou situação.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void chkbDestOsPend_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbDestOsPend.Checked == true)
            {
                if (dtPesquisa.DataSource != null)
                {
                    for (int i = 0; i < dtPesquisa.Rows.Count; i++)
                    {
                        if (dtPesquisa.Rows[i].Cells[19].Value.ToString() == "PENDENTE")
                        {
                            dtPesquisa.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                }
            }
            else
            {
                if (dtPesquisa.DataSource != null)
                {
                    for (int i = 0; i < dtPesquisa.Rows.Count; i++)
                    {
                        dtPesquisa.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void dtPesquisa_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtPesquisa.Columns[0].HeaderText = "Código";
            dtPesquisa.Columns[1].HeaderText = "Cód. do Consumidor";
            dtPesquisa.Columns[2].HeaderText = "Nome do Consumidor";
            dtPesquisa.Columns[3].HeaderText = "CPF/CNPJ do Consumidor";
            dtPesquisa.Columns[4].HeaderText = "Data";
            dtPesquisa.Columns[5].HeaderText = "Horário";
            dtPesquisa.Columns[6].Visible = false;
            dtPesquisa.Columns[7].Visible = false;
            dtPesquisa.Columns[8].Visible = false;
            dtPesquisa.Columns[9].HeaderText = "Descrição do Item";
            dtPesquisa.Columns[10].Visible = false;
            dtPesquisa.Columns[11].Visible = false;
            dtPesquisa.Columns[12].Visible = false;
            dtPesquisa.Columns[13].Visible = false;
            dtPesquisa.Columns[14].Visible = false;
            dtPesquisa.Columns[15].HeaderText = "Valor Total (R$)";
            dtPesquisa.Columns[16].Visible = false;
            dtPesquisa.Columns[17].HeaderText = "Data de Conclusão";
            dtPesquisa.Columns[18].HeaderText = "Horário de Conclusão";
            dtPesquisa.Columns[19].HeaderText = "Situação";
            dtPesquisa.Columns[20].Visible = false;
            dtPesquisa.Columns[21].Visible = false;
            dtPesquisa.Columns[22].Visible = false;
            dtPesquisa.Columns[23].Visible = false;
            dtPesquisa.Columns[24].Visible = false;
            dtPesquisa.Columns[25].Visible = false;
            dtPesquisa.Columns[26].Visible = false;
            dtPesquisa.Columns[27].Visible = false;
            dtPesquisa.Columns[28].Visible = false;
            dtPesquisa.Columns[29].HeaderText = "A Pagar (R$)";
            dtPesquisa.Columns[30].HeaderText = "Valor Pago (R$)";
            dtPesquisa.Columns[31].HeaderText = "Troco (R$)";
            dtPesquisa.Columns[32].Visible = false;
            dtPesquisa.Columns[33].Visible = false;
            dtPesquisa.Columns[34].Visible = false;
            dtPesquisa.Columns[35].HeaderText = "Cód. do Usuário";
            dtPesquisa.Columns[36].HeaderText = "Nome do Usuário";
            dtPesquisa.Columns[37].Visible = false;
            dtPesquisa.Columns[38].Visible = false;
            //
            dtPesquisa.Columns[15].DisplayIndex = 20;
            dtPesquisa.Columns[19].DisplayIndex = 32;
            dtPesquisa.Columns[17].DisplayIndex = 33;
            dtPesquisa.Columns[18].DisplayIndex = 34;

            /*
             dtOs.Columns[0].HeaderText = "Código";
            dtOs.Columns[1].HeaderText = "Cód. do Consumidor";
            dtOs.Columns[2].HeaderText = "Nome do Consumidor";
            dtOs.Columns[3].HeaderText = "CPF/CNPJ do Consumidor";
            dtOs.Columns[4].HeaderText = "Data";
            dtOs.Columns[5].HeaderText = "Horário";
            dtOs.Columns[6].Visible = "Data de Conclusão Prevista";
            dtOs.Columns[7].HeaderText = "Horário de Conclusão Prevista";
            dtOs.Columns[8].HeaderText = "Descrição";
            dtOs.Columns[9].HeaderText = "Descrição do Item/Equipamento";
            dtOs.Columns[10].HeaderText = "Marca";
            dtOs.Columns[11].HeaderText = "Modelo";
            dtOs.Columns[12].HeaderText = "Nº de Série";
            dtOs.Columns[13].HeaderText = "Total dos Serviços (R$)";
            dtOs.Columns[14].HeaderText = "Total dos Produtos (R$)";
            dtOs.Columns[15].HeaderText = "Valor Total (R$)";
            dtOs.Columns[16].HeaderText = "Observação.";
            dtOs.Columns[17].HeaderText = "Data de Conclusão";
            dtOs.Columns[18].HeaderText = "Horário de Conclusão";
            dtOs.Columns[19].HeaderText = "Situação";
            dtOs.Columns[20].Visible = false;
            dtOs.Columns[21].HeaderText = "Valor do Desconto (R$)";
            dtOs.Columns[22].HeaderText = "Desconto (%)";
            dtOs.Columns[23].HeaderText = "Valor do Acréscimo (R$)";
            dtOs.Columns[24].HeaderText = "Acréscimo (%)";
            dtOs.Columns[25].HeaderText = "Valor do Desconto Prod. (R$)";
            dtOs.Columns[26].HeaderText = "Desconto Prod. (%)";
            dtOs.Columns[27].HeaderText = "Valor do Acréscimo Prod. (R$)";
            dtOs.Columns[28].HeaderText = "Acréscimo Prod. (%)";
            dtOs.Columns[29].HeaderText = "Valor Real (R$)";
            dtOs.Columns[30].HeaderText = "Valor Pago (R$)";
            dtOs.Columns[31].HeaderText = "Troco (R$)";
            dtOs.Columns[32].HeaderText = "Cód. do Usuário Baixa";
            dtOs.Columns[33].HeaderText = "Nome do Usuário Baixa";
            dtOs.Columns[34].HeaderText = "Cód. do PDV/Computador Baixa";
            dtOs.Columns[35].HeaderText = "Cód. do Usuário";
            dtOs.Columns[36].HeaderText = "Nome do Usuário";
            dtOs.Columns[37].HeaderText = "Valor do Acéscimo do Item (R$)";
            dtOs.Columns[38].HeaderText = "Valor do Desconto do Item (R$)";
             */
            //
            dtPesquisa.DefaultCellStyle.Font = new System.Drawing.Font(dtPesquisa.Font, FontStyle.Bold);
            //
            dtPesquisa.Columns[0].Width = 85;
            dtPesquisa.Columns[1].Width = 130;
            dtPesquisa.Columns[2].Width = 250;
            dtPesquisa.Columns[3].Width = 185;
            dtPesquisa.Columns[4].Width = 125;
            dtPesquisa.Columns[5].Width = 85;
            dtPesquisa.Columns[6].Width = 175;
            dtPesquisa.Columns[7].Width = 175;
            dtPesquisa.Columns[8].Width = 500;
            dtPesquisa.Columns[9].Width = 320;
            dtPesquisa.Columns[10].Width = 320;
            dtPesquisa.Columns[11].Width = 320;
            dtPesquisa.Columns[12].Width = 320;
            dtPesquisa.Columns[13].Width = 150;
            dtPesquisa.Columns[14].Width = 150;
            dtPesquisa.Columns[15].Width = 150;
            dtPesquisa.Columns[16].Width = 500;
            dtPesquisa.Columns[17].Width = 150;
            dtPesquisa.Columns[18].Width = 150;
            dtPesquisa.Columns[19].Width = 175;
            dtPesquisa.Columns[21].Width = 150;
            dtPesquisa.Columns[22].Width = 150;
            dtPesquisa.Columns[23].Width = 150;
            dtPesquisa.Columns[24].Width = 175;
            dtPesquisa.Columns[25].Width = 175;
            dtPesquisa.Columns[26].Width = 175;
            dtPesquisa.Columns[27].Width = 175;
            dtPesquisa.Columns[28].Width = 175;
            dtPesquisa.Columns[29].Width = 150;
            dtPesquisa.Columns[30].Width = 150;
            dtPesquisa.Columns[31].Width = 150;
            dtPesquisa.Columns[32].Width = 150;
            dtPesquisa.Columns[33].Width = 150;
            dtPesquisa.Columns[34].Width = 200;
            dtPesquisa.Columns[35].Width = 150;
            dtPesquisa.Columns[36].Width = 150;
            dtPesquisa.Columns[37].Width = 195;
            dtPesquisa.Columns[38].Width = 195;
            //
            dtPesquisa.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[26].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[27].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[31].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[31].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[32].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[32].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[33].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[33].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[34].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[35].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[36].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[36].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[37].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[37].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[38].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtPesquisa.Columns[38].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            //
            lblRegistros.Text = "Registros: " + dtPesquisa.Rows.Count;
        }

        private void dtPesquisa_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegistros.Text = "Registros: 0";
        }

        private void dtPesquisa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 4 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 6 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 17 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
            //
            if (e.ColumnIndex == 13 && e.Value.ToString() == "")
            {
                e.Value = 0;
            }
            //
            if (e.ColumnIndex == 14 && e.Value.ToString() == "")
            {
                e.Value = 0;
            }
            //
            if (e.ColumnIndex == 15 && e.Value.ToString() == "")
            {
                e.Value = 0;
            }
            //
            if (e.ColumnIndex == 32 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 34 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
            //
            if (e.ColumnIndex == 30 && e.Value.ToString() == "")
            {
                e.Value = 0;
            }
        }

        private void dtPesquisa_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtPesquisa.Columns[13].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[13].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[14].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[14].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[15].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[15].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[21].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[21].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[22].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[22].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[23].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[23].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[24].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[24].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[25].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[25].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[26].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[26].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[27].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[27].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[28].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[28].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[29].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[29].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[30].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[30].DefaultCellStyle.Format = "n2";
            dtPesquisa.Columns[31].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPesquisa.Columns[31].DefaultCellStyle.Format = "n2";

            dtPesquisa.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtPesquisa.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dtPesquisa_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtPesquisa.DataSource == null)
            {
                btnIncluir.Enabled = false;
                dtPesquisa.Enabled = false;
            }
            else
            {
                btnIncluir.Enabled = true;
                dtPesquisa.Enabled = true;
            }
        }

     
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                //
                if (_Formulario == 0)
                {
                    btnIncluir.Select();
                    bllComissao._Cod_OS = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    btnIncluir.Select();
                    bllVenda._Cod_OS = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do click btnIncluir.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do click btnIncluir.");
                }
            }
        }

        private void dtPesquisa_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                //
                if (_Formulario == 0)
                {
                    btnIncluir.Select();
                    bllComissao._Cod_OS = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
                else if (_Formulario == 1)
                {
                    btnIncluir.Select();
                    bllVenda._Cod_OS = SelectedRow.Cells[0].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do doubleclick dtPesquisa.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do doubleclick dtPesquisa.");
                }
            }
        }

        private void dtPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    DataGridViewRow SelectedRow = dtPesquisa.Rows[dtPesquisa.CurrentRow.Index];
                    //
                    if (_Formulario == 0)
                    {
                        btnIncluir.Select();
                        bllComissao._Cod_OS = SelectedRow.Cells[0].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                    else if (_Formulario == 1)
                    {
                        btnIncluir.Select();
                        bllVenda._Cod_OS = SelectedRow.Cells[0].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do KeyDown dtPesquisa.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento do KeyDown dtPesquisa.");
                    }
                }
            }
        }

        private void dtPesquisa_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtPesquisa.DataSource == null)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void dtPesquisa_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnProcurarUsuario_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqUsuario User = new FrmPesqUsuario(11, _Usuario, _Cod_PDV_Computador))
            {
                if (User.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbpUsuario.Items.Clear();
                        if (bllOS.Sel_Usuario_OS() == null)
                        {
                            cbbpUsuario.Text = null;
                            cbbpUsuario.Enabled = false;
                            lblUsuario.Enabled = false;
                        }
                        else
                        {
                            cbbpUsuario.Enabled = true;
                            lblUsuario.Enabled = true;
                            cbbpUsuario.Items.Add("");
                            foreach (DataRow dr in bllOS.Sel_Usuario_OS().Rows)
                            {
                                cbbpUsuario.Items.Add(dr["id_usuario"].ToString() + "—" + dr["nome_usuario"].ToString());
                            }
                        }
                        cbbpUsuario.Text = bllOS._Usuario_PesqUsuario_Tabela;
                        bllOS._Usuario_PesqUsuario_Tabela = null;
                        cbbpUsuario.Select();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarUsuario.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarUsuario.");
                        }
                        cbbpUsuario.Text = null;
                        bllOS._Usuario_PesqUsuario_Tabela = null;
                    }
                }
            }
            this.Enabled = true;
        }

        private void btnSelecionarData1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmDatePicker2 Data = new FrmDatePicker2(26))
            {
                if (Data.ShowDialog() == DialogResult.OK)
                {
                    mtxtpData.Text = bllOS._Data_DatePicker1;
                    mtxtpData1.Text = bllOS._Data_DatePicker2;
                }
            }
            this.Enabled = true;
        }

        
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                using (FrmPesqCliente Clie = new FrmPesqCliente(13, _Usuario, _Cod_PDV_Computador))
                {
                    if (Clie.ShowDialog() == DialogResult.OK)
                    {
                        cbbClieConsFunc.Items.Clear();
                        if (bllOS.Sel_Cliente_OS() == null)
                        {
                            cbbClieConsFunc.Text = null;
                            cbbClieConsFunc.Enabled = false;
                        }
                        else
                        {
                            cbbClieConsFunc.Enabled = true;
                            cbbClieConsFunc.Items.Add("");
                            foreach (DataRow dr in bllOS.Sel_Cliente_OS().Rows)
                            {
                                string cpfcnpj;
                                if (dr["cpf_cnpj"].ToString() == "")
                                {
                                    cpfcnpj = "";
                                }
                                else
                                {
                                    cpfcnpj = "—" + dr["cpf_cnpj"].ToString();
                                }
                                cbbClieConsFunc.Items.Add(dr["id_cliente"].ToString() + "—" + dr["nome"].ToString() + cpfcnpj);
                            }
                        }
                        cbbClieConsFunc.Text = bllOS._Cliente_PesqCliente_Tabela;
                        bllOS._Cliente_PesqCliente_Tabela = null;
                        cbbClieConsFunc.Select();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                cbbClieConsFunc.Text = null;
                bllOS._Cliente_PesqCliente_Tabela = null;
            }
            this.Enabled = true;
        }

        private void btnProcurarFuncionario_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                using (FrmPesqFuncionario Func = new FrmPesqFuncionario(8, _Usuario, _Cod_PDV_Computador))
                {
                    if (Func.ShowDialog() == DialogResult.OK)
                    {
                        cbbFuncionario.Items.Clear();
                        if (bllOS.Sel_Funcionario_OS() == null)
                        {
                            cbbFuncionario.Text = null;
                            cbbFuncionario.Enabled = false;
                        }
                        else
                        {
                            cbbFuncionario.Enabled = true;
                            cbbFuncionario.Items.Add("");
                            foreach (DataRow dr in bllOS.Sel_Funcionario_OS().Rows)
                            {
                                cbbFuncionario.Items.Add(dr["id_funcionario"].ToString() + "—" + dr["nome"].ToString());
                            }
                        }
                        cbbFuncionario.Text = bllOS._Func_PesqFuncionario_Tabela;
                        bllOS._Func_PesqFuncionario_Tabela = null;
                        cbbFuncionario.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurar.");
                }
                cbbFuncionario.Text = null;
                bllOS._Func_PesqFuncionario_Tabela = null;
            }
            this.Enabled = true;
        }

        private void mtxtpData1_Leave(object sender, EventArgs e)
        {
            mtxtpData1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpData1.Text != "")
            {
                try
                {
                    mtxtpData1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpData1.Text);

                    mtxtpData.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpData.Text != "")
                    {
                        mtxtpData.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpData1.Text) < Convert.ToDateTime(mtxtpData.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpData1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpData1.");
                    }
                    mtxtpData1.Text = null;
                }
            }
            mtxtpData1.BackColor = Color.White;
        }

        private void mtxtHorario1_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario1.Text == "")
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorario1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorario1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbClieConsFunc.Select();
            }
        }

        private void mtxtHorario1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorario1.Text == "")
                {
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorario1.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorario1_Enter(object sender, EventArgs e)
        {
            mtxtHorario1.BackColor = Color.LightBlue;
        }

        private void mtxtHorario1_Leave(object sender, EventArgs e)
        {
            mtxtHorario1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorario1.Text != "")
            {
                if (mtxtHorario1.Text.Length == 4)
                {
                    mtxtHorario1.Text = mtxtHorario1.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorario1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorario1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorario1.");
                    }
                    mtxtHorario1.Text = null;
                }
            }
            mtxtHorario1.BackColor = Color.White;
        }

        private void mtxtDataBaixa_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataBaixa.Text == "")
            {
                mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataBaixa.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtDataBaixa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioBaixa.Select();
            }
        }

        private void mtxtDataBaixa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataBaixa.Text == "")
                {
                    mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataBaixa.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtDataBaixa_Enter(object sender, EventArgs e)
        {
            mtxtDataBaixa.BackColor = Color.LightBlue;
        }

        private void mtxtDataBaixa_Leave(object sender, EventArgs e)
        {
            mtxtDataBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataBaixa.Text != "")
            {
                try
                {
                    mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataBaixa.Text);

                    mtxtDataBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataBaixa1.Text != "")
                    {
                        mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtDataBaixa.Text) > Convert.ToDateTime(mtxtDataBaixa1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtDataBaixa.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataBaixa.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataBaixa.");
                    }
                    mtxtDataBaixa.Text = null;
                }
            }
            mtxtDataBaixa.BackColor = Color.White;
        }

        private void mtxtHorarioBaixa_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioBaixa.Text == "")
            {
                mtxtHorarioBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioBaixa.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioBaixa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtDataBaixa1.Select();
            }
        }

        private void mtxtHorarioBaixa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioBaixa.Text == "")
                {
                    mtxtHorarioBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioBaixa.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioBaixa_Leave(object sender, EventArgs e)
        {
            mtxtHorarioBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioBaixa.Text != "")
            {
                if (mtxtHorarioBaixa.Text.Length == 4)
                {
                    mtxtHorarioBaixa.Text = mtxtHorarioBaixa.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioBaixa.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioBaixa.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioBaixa.");
                    }
                    mtxtHorarioBaixa.Text = null;
                }
            }
            mtxtHorarioBaixa.BackColor = Color.White;
        }

        private void mtxtHorarioBaixa_Enter(object sender, EventArgs e)
        {
            mtxtHorarioBaixa.BackColor = Color.LightBlue;
        }

        private void mtxtDataBaixa1_DoubleClick(object sender, EventArgs e)
        {
            mtxtDataBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataBaixa1.Text == "")
            {
                mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtDataBaixa1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtDataBaixa1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioBaixa1.Select();
            }
        }

        private void mtxtDataBaixa1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtDataBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtDataBaixa1.Text == "")
                {
                    mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtDataBaixa1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtDataBaixa1_Enter(object sender, EventArgs e)
        {
            mtxtDataBaixa1.BackColor = Color.LightBlue;
        }

        private void mtxtDataBaixa1_Leave(object sender, EventArgs e)
        {
            mtxtDataBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtDataBaixa1.Text != "")
            {
                try
                {
                    mtxtDataBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtDataBaixa1.Text);

                    mtxtDataBaixa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtDataBaixa.Text != "")
                    {
                        mtxtDataBaixa.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtDataBaixa1.Text) < Convert.ToDateTime(mtxtDataBaixa.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtDataBaixa1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataBaixa1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtDataBaixa1.");
                    }
                    mtxtDataBaixa1.Text = null;
                }
            }
            mtxtDataBaixa1.BackColor = Color.White;
        }

        private void cbbFuncionario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbpSituacao.Select();
            }
        }

        private void cbbpSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbFormaPagamento.Select();
            }
        }

        private void cbbpUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtpCodigo.Select();
            }
        }

        private void txtpCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                mtxtDataBaixa.Select();
            }
        }

        private void txtpCodigo_Leave(object sender, EventArgs e)
        {
            if (txtpCodigo.Text.Contains("'") || txtpCodigo.Text.Contains(";") || txtpCodigo.Text.Contains("="))
            {
                MessageBox.Show("Caracteres inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                txtpCodigo.Text = null;
                txtpCodigo.Select();
            }
            txtpCodigo.BackColor = Color.White;
        }

        private void txtpCodigo_Enter(object sender, EventArgs e)
        {
            txtpCodigo.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioBaixa1_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioBaixa1.Text == "")
            {
                mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioBaixa1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioBaixa1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbFuncionario.Select();
            }
        }

        private void mtxtHorarioBaixa1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioBaixa1.Text == "")
                {
                    mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioBaixa1.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioBaixa1_Enter(object sender, EventArgs e)
        {
            mtxtHorarioBaixa1.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioBaixa1_Leave(object sender, EventArgs e)
        {
            mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioBaixa1.Text != "")
            {
                if (mtxtHorarioBaixa1.Text.Length == 4)
                {
                    mtxtHorarioBaixa1.Text = mtxtHorarioBaixa1.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioBaixa1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioBaixa1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioBaixa1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioBaixa1.");
                    }
                    mtxtHorarioBaixa1.Text = null;
                }
            }
            mtxtHorarioBaixa1.BackColor = Color.White;
        }

        private void cbbClieConsFunc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbpUsuario.Select();
            }
        }

        private void cbbFormaPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnProcurarForma_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqFormaPagamento Pag = new FrmPesqFormaPagamento(3, _Usuario, _Cod_PDV_Computador))
            {
                if (Pag.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbFormaPagamento.Items.Clear();
                        if (bllOS.Sel_Forma_Pagamento_OS() == null)
                        {
                            cbbFormaPagamento.Text = null;
                            cbbFormaPagamento.Enabled = false;
                            lblFormaPagamento.Enabled = false;
                        }
                        else
                        {
                            cbbFormaPagamento.Enabled = true;
                            lblFormaPagamento.Enabled = true;
                            cbbFormaPagamento.Items.Add("");
                            foreach (DataRow dr in bllOS.Sel_Forma_Pagamento_OS().Rows)
                            {
                                cbbFormaPagamento.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                            }
                        }
                        cbbFormaPagamento.Text = bllOS._Forma_Pagamento_PesqFormaPagamento_Tabela;
                        bllOS._Forma_Pagamento_PesqFormaPagamento_Tabela = null;
                        cbbFormaPagamento.Select();
                    }
                    catch (Exception ex)
                    {
                        this.Enabled = false;
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.None;
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarPagamento.");
                        }
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnProcurarPagamento.");
                        }
                        cbbFormaPagamento.Text = null;
                        bllOS._Forma_Pagamento_PesqFormaPagamento_Tabela = null;
                    }
                }
            }
            this.Enabled = true;
        }
    }

        
}
