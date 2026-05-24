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
    public partial class FrmIntegracoes : Form
    {
        public FrmIntegracoes(string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        private string _Usuario;
        //private byte _Trabalho;
        private string _Cod_PDV_Computador;

        private void FrmIntegracoes_Load(object sender, EventArgs e)
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmIntegracoes iniciado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmIntegracoes iniciado.");
                }
                //
                cbbFormaPagamento.Items.Clear();
                if (bllPedAnotaAI.Sel_Forma_Pagamento_Ped_Anota_AI() == null)
                {
                    cbbFormaPagamento.Enabled = false;
                    cbbFormaPagamento.Text = null;
                }
                else
                {
                    cbbFormaPagamento.Enabled = true;
                    cbbFormaPagamento.Items.Add("");
                    foreach (DataRow dr in bllPedAnotaAI.Sel_Forma_Pagamento_Ped_Anota_AI().Rows)
                    {
                        cbbFormaPagamento.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                    }
                }
                //
                mtxtpDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
                mtxtpDataEmissao1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                //
                btnPesquisar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmIntegracoes.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmIntegracoes.");
                }
            }
        }

        private void FrmIntegracoes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void mtxtpDataEmissao_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmissao.Text == "")
            {
                mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataEmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioEmissao.Select();
            }
        }

        private void mtxtpDataEmissao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataEmissao.Text == "")
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataEmissao.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataEmissao_Leave(object sender, EventArgs e)
        {
            mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmissao.Text != "")
            {
                try
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataEmissao.Text);

                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataEmissao1.Text != "")
                    {
                        mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataEmissao.Text) > Convert.ToDateTime(mtxtpDataEmissao1.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser maiores do que o segundo campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmissao.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmissao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmissao.");
                    }
                    mtxtpDataEmissao.Text = null;
                }
            }
            mtxtpDataEmissao.BackColor = Color.White;
        }

        private void mtxtpDataEmissao_Enter(object sender, EventArgs e)
        {
            mtxtpDataEmissao.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioEmissao_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioEmissao.Text == "")
            {
                mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioEmissao.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioEmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtpDataEmissao1.Select();
            }
        }

        private void mtxtHorarioEmissao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioEmissao.Text == "")
                {
                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioEmissao.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioEmissao_Leave(object sender, EventArgs e)
        {
            mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioEmissao.Text != "")
            {
                if (mtxtHorarioEmissao.Text.Length == 4)
                {
                    mtxtHorarioEmissao.Text = mtxtHorarioEmissao.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioEmissao.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioEmissao.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioEmissao.");
                    }
                    mtxtHorarioEmissao.Text = null;
                }
            }
            mtxtHorarioEmissao.BackColor = Color.White;
        }

        private void mtxtHorarioEmissao_Enter(object sender, EventArgs e)
        {
            mtxtHorarioEmissao.BackColor = Color.LightBlue;
        }

        private void mtxtpDataEmissao1_DoubleClick(object sender, EventArgs e)
        {
            mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmissao1.Text == "")
            {
                mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtpDataEmissao1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtpDataEmissao1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                mtxtHorarioEmissao1.Select();
            }
        }

        private void mtxtpDataEmissao1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtpDataEmissao1.Text == "")
                {
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtpDataEmissao1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtpDataEmissao1_Leave(object sender, EventArgs e)
        {
            mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtpDataEmissao1.Text != "")
            {
                try
                {
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Data(mtxtpDataEmissao1.Text);

                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                    if (mtxtpDataEmissao.Text != "")
                    {
                        mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                        if (Convert.ToDateTime(mtxtpDataEmissao1.Text) < Convert.ToDateTime(mtxtpDataEmissao.Text))
                        {
                            MessageBox.Show("Os dados preenchidos neste campo não podem ser menores que o primeiro campo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            mtxtpDataEmissao1.Text = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmissao1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtpDataEmissao1.");
                    }
                    mtxtpDataEmissao1.Text = null;
                }
            }
            mtxtpDataEmissao1.BackColor = Color.White;
        }

        private void mtxtpDataEmissao1_Enter(object sender, EventArgs e)
        {
            mtxtpDataEmissao1.BackColor = Color.LightBlue;
        }

        private void mtxtHorarioEmissao1_DoubleClick(object sender, EventArgs e)
        {
            mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioEmissao1.Text == "")
            {
                mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                mtxtHorarioEmissao1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
        }

        private void mtxtHorarioEmissao1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbFormaPagamento.Select();
            }
        }

        private void mtxtHorarioEmissao1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if (mtxtHorarioEmissao1.Text == "")
                {
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioEmissao1.Text = DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                }
            }
        }

        private void mtxtHorarioEmissao1_Leave(object sender, EventArgs e)
        {
            mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            if (mtxtHorarioEmissao1.Text != "")
            {
                if (mtxtHorarioEmissao1.Text.Length == 4)
                {
                    mtxtHorarioEmissao1.Text = mtxtHorarioEmissao1.Text.Insert(4, "00");
                }
                //
                try
                {
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    ValidarData.Ver_Hora(mtxtHorarioEmissao1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioEmissao1.");
                    }
                    using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                    {
                        writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento leave da caixa de texto mtxtHorarioEmissao1.");
                    }
                    mtxtHorarioEmissao1.Text = null;
                }
            }
            mtxtHorarioEmissao1.BackColor = Color.White;
        }

        private void mtxtHorarioEmissao1_Enter(object sender, EventArgs e)
        {
            mtxtHorarioEmissao1.BackColor = Color.LightBlue;
        }

        private void dtPedido_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                dtPedido.Columns[0].HeaderText = "Código";
                dtPedido.Columns[1].HeaderText = "Data";
                dtPedido.Columns[2].HeaderText = "Horário";
                dtPedido.Columns[3].HeaderText = "Valor (R$)";
                dtPedido.Columns[4].HeaderText = "Desconto";
                dtPedido.Columns[5].HeaderText = "Acréscimo";
                dtPedido.Columns[6].HeaderText = "Valor Total (R$)";
                dtPedido.Columns[7].HeaderText = "Situação";
                //
                dtPedido.Columns[0].Width = 75;
                dtPedido.Columns[1].Width = 90;
                dtPedido.Columns[2].Width = 75;
                dtPedido.Columns[3].Width = 80;
                dtPedido.Columns[4].Width = 80;
                dtPedido.Columns[5].Width = 85;
                dtPedido.Columns[6].Width = 110;
                //
                dtPedido.DefaultCellStyle.Font = new Font(dtPedido.Font, FontStyle.Bold);

                dtPedido.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPedido.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPedido.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPedido.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPedido.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPedido.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPedido.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPedido.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPedido.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPedido.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPedido.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPedido.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPedido.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPedido.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPedido.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtPedido.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                lblRegPedido.Text = "Registros: " + dtPedido.Rows.Count;

                for (int i = 0; i < dtPedido.Rows.Count; i++)
                {
                    if (dtPedido.Rows[i].Cells[7].Value.ToString() == "PENDENTE")
                    {
                        dtPedido.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    else
                    {
                        dtPedido.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
                //
                decimal valortotal = 0;
                for (int i = 0; i < dtPedido.Rows.Count; i++)
                {
                    valortotal += Convert.ToDecimal(dtPedido.Rows[i].Cells[3].Value);
                }
                lblValorTotal.Text = Convert.ToDecimal(valortotal).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valortotalreal = 0;
                for (int i = 0; i < dtPedido.Rows.Count; i++)
                {
                    valortotalreal += Convert.ToDecimal(dtPedido.Rows[i].Cells[6].Value);
                }
                lblValorTotalReal.Text = Convert.ToDecimal(valortotalreal).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valordesconto = 0;
                for (int i = 0; i < dtPedido.Rows.Count; i++)
                {
                    valordesconto += Convert.ToDecimal(dtPedido.Rows[i].Cells[4].Value);
                }
                lblValorDesconto.Text = Convert.ToDecimal(valordesconto).ToString("n2", new CultureInfo("pt-BR"));
                //
                decimal valoracrescimo = 0;
                for (int i = 0; i < dtPedido.Rows.Count; i++)
                {
                    valoracrescimo += Convert.ToDecimal(dtPedido.Rows[i].Cells[5].Value);
                }
                lblValorAcrescimo.Text = Convert.ToDecimal(valoracrescimo).ToString("n2", new CultureInfo("pt-BR"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtPedido.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento rowsadded do dtPedido.");
                }
                dtPedido.DataSource = null;
            }
        }

        private void dtPedido_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegPedido.Text = "Registros: 0";
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                mtxtpDataEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtpDataEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                mtxtHorarioEmissao.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                if ((mtxtpDataEmissao.Text == "" & mtxtpDataEmissao1.Text != "") || (mtxtpDataEmissao.Text != "" & mtxtpDataEmissao1.Text == ""))
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    MessageBox.Show("É necessário preencher ambos os campos de [ Data ] para pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    mtxtpDataEmissao.Select();
                    return;
                }
                else
                {
                    mtxtpDataEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtpDataEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

                    mtxtHorarioEmissao.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    mtxtHorarioEmissao1.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;


                    if (bllPedAnotaAI.Sel_Ped_Anota_Ai_Data_Cad_Situacao(mtxtpDataEmissao.Text, mtxtpDataEmissao1.Text, mtxtHorarioEmissao.Text, mtxtHorarioEmissao1.Text, cbbSituacao.Text, txtpCodigo.Text, cbbFormaPagamento.Text) == null)
                    {
                        dtPedido.DataSource = null;
                    }
                    else
                    {
                        dtPedido.DataSource = bllPedAnotaAI.Sel_Ped_Anota_Ai_Data_Cad_Situacao(mtxtpDataEmissao.Text, mtxtpDataEmissao1.Text, mtxtHorarioEmissao.Text, mtxtHorarioEmissao1.Text, cbbSituacao.Text, txtpCodigo.Text, cbbFormaPagamento.Text);
                        dtPedido.Select();
                    }
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
                dtPedido.DataSource = null;
                mtxtpDataEmissao.Select();
            }
        }

        private void dtPedido_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtPedido.DataSource == null)
            {
                dtPedido.Enabled = false;
                dtFormaPagamento.DataSource = null;
                dtItemPedido.DataSource = null;
                lblValorTotal.Enabled = false;
                lblValorTotalReal.Enabled = false;
                lblTotal.Enabled = false;
                lblTotalReal.Enabled = false;
                lblCancelada.Enabled = false;
                lblValorDesconto.Enabled = false;
                lblValorAcrescimo.Enabled = false;
                lblAcrescimo.Enabled = false;
            }
            else
            {
                dtPedido.Enabled = true;
                //
                DataGridViewRow SelectedRow = dtPedido.Rows[dtPedido.CurrentRow.Index];
                dtItemPedido.DataSource = bllPedAnotaAI.Sel_Ped_Anota_Ai_Items(SelectedRow.Cells[0].Value.ToString());
                //
                dtFormaPagamento.DataSource = bllPedAnotaAI.Sel_Ped_Anota_Ai_Items_Pagamento(SelectedRow.Cells[0].Value.ToString());
                //
                lblValorTotal.Enabled = true;
                lblValorTotalReal.Enabled = true;
                lblTotal.Enabled = true;
                lblTotalReal.Enabled = true;
                lblCancelada.Enabled = true;
                lblValorDesconto.Enabled = true;
                lblValorAcrescimo.Enabled = true;
                lblAcrescimo.Enabled = true;
            }
        }

        private void dtPedido_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            dtPedido.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtPedido.DefaultCellStyle.SelectionForeColor = Color.Black;

            dtPedido.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPedido.Columns[3].DefaultCellStyle.Format = "n2";
            dtPedido.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPedido.Columns[4].DefaultCellStyle.Format = "n2";
            dtPedido.Columns[5].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPedido.Columns[5].DefaultCellStyle.Format = "n2";
            dtPedido.Columns[6].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtPedido.Columns[6].DefaultCellStyle.Format = "n2";
            //
            //


            /*
            //
            mtxtChave.Text = SelectedRow.Cells[15].Value.ToString();
            //
            if (SelectedRow.Cells[18].Value.ToString() == "CANCELADA")
            {
                lblValorSituacao.Visible = true;
                lblCxSituacao.Visible = true;
                lblValorSituacao.Text = "CANCELADA";
                lblValorSituacao.ForeColor = Color.Red;
                lblCxSituacao.BackColor = Color.Red;
                btnConsultarDFe.Enabled = true;
                btnTransmitir.Enabled = false;
                btnCancelar.Enabled = false;
                btnInutilizar.Enabled = false;
                btnCartaCorrecao.Enabled = false;
                lblChave.Enabled = true;
                mtxtChave.Enabled = true;
                btnCopiarChave.Enabled = true;
            }
            else if (SelectedRow.Cells[18].Value.ToString() == "DENEGADA")
            {
                lblValorSituacao.Visible = true;
                lblCxSituacao.Visible = true;
                lblValorSituacao.Text = "CANCELADA";
                lblValorSituacao.ForeColor = Color.Red;
                lblCxSituacao.BackColor = Color.Red;
                btnConsultarDFe.Enabled = true;
                btnTransmitir.Enabled = false;
                btnCancelar.Enabled = false;
                btnInutilizar.Enabled = false;
                btnCartaCorrecao.Enabled = false;
                lblChave.Enabled = true;
                mtxtChave.Enabled = true;
                btnCopiarChave.Enabled = true;
            }
            else if (SelectedRow.Cells[18].Value.ToString() == "INUTILIZADA")
            {
                lblValorSituacao.Visible = true;
                lblCxSituacao.Visible = true;
                lblValorSituacao.Text = "INUTILIZADA";
                lblValorSituacao.ForeColor = Color.Red;
                lblCxSituacao.BackColor = Color.Red;
                btnConsultarDFe.Enabled = false;
                btnTransmitir.Enabled = false;
                btnCancelar.Enabled = false;
                btnInutilizar.Enabled = false;
                btnCartaCorrecao.Enabled = false;
                lblChave.Enabled = true;
                mtxtChave.Enabled = true;
                btnCopiarChave.Enabled = true;
            }
            else if (SelectedRow.Cells[18].Value.ToString() == "TRANSMITIDA")
            {
                lblValorSituacao.Visible = true;
                lblCxSituacao.Visible = true;
                lblValorSituacao.Text = "TRANSMITIDA";
                lblValorSituacao.ForeColor = Color.Green;
                lblCxSituacao.BackColor = Color.Green;
                btnConsultarDFe.Enabled = true;
                btnTransmitir.Enabled = false;
                btnCancelar.Enabled = false;
                btnInutilizar.Enabled = false;
                if (SelectedRow.Cells[11].Value.ToString() == "55")
                {
                    btnCartaCorrecao.Enabled = true;
                }
                else
                {
                    btnCartaCorrecao.Enabled = false;
                }
                lblChave.Enabled = true;
                mtxtChave.Enabled = true;
                btnCopiarChave.Enabled = true;
            }
            else if (SelectedRow.Cells[18].Value.ToString() == "PENDENTE")
            {
                lblValorSituacao.Visible = true;
                lblCxSituacao.Visible = true;
                lblValorSituacao.Text = "PENDENTE";
                lblValorSituacao.ForeColor = Color.Red;
                lblCxSituacao.BackColor = Color.Red;
                if (SelectedRow.Cells[15].Value.ToString() == "")
                {
                    btnConsultarDFe.Enabled = false;
                    btnTransmitir.Enabled = true;
                    lblChave.Enabled = false;
                    mtxtChave.Enabled = false;
                    btnCopiarChave.Enabled = false;
                }
                else
                {
                    btnConsultarDFe.Enabled = true;
                    btnTransmitir.Enabled = false;
                    lblChave.Enabled = true;
                    mtxtChave.Enabled = true;
                    btnCopiarChave.Enabled = true;
                }
                btnCancelar.Enabled = false;
                btnInutilizar.Enabled = false;
                btnCartaCorrecao.Enabled = false;
            }
            else
            {
                lblValorSituacao.Visible = true;
                lblCxSituacao.Visible = true;
                lblValorSituacao.Text = "PENDENTE";
                lblValorSituacao.ForeColor = Color.Red;
                lblCxSituacao.BackColor = Color.Red;
                if (SelectedRow.Cells[15].Value.ToString() == "")
                {
                    btnConsultarDFe.Enabled = false;
                    btnTransmitir.Enabled = true;
                    lblChave.Enabled = false;
                    mtxtChave.Enabled = false;
                    btnCopiarChave.Enabled = false;
                }
                else
                {
                    btnConsultarDFe.Enabled = true;
                    btnTransmitir.Enabled = false;
                    lblChave.Enabled = true;
                    mtxtChave.Enabled = true;
                    btnAbrirArquivo.Enabled = true;
                    btnCopiarChave.Enabled = true;
                }
                btnCancelar.Enabled = false;
                btnInutilizar.Enabled = false;
                btnCartaCorrecao.Enabled = false;
            }
            //
           */
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.DialogResult = DialogResult.None;
            using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtPedido.");
            }
            using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
            {
                writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento cellenter do datagridview dtPedido.");
            }
            dtPedido.DataSource = null;
        }
        }

        private void dtPedido_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value.ToString() != "")
            {
                e.Value = e.Value.ToString().Remove(10);
            }
        }

        private void dtItemPedido_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtItemPedido.Columns[0].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtItemPedido.Columns[0].DefaultCellStyle.Format = "D3";
            dtItemPedido.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtItemPedido.Columns[3].DefaultCellStyle.Format = "n2";
            dtItemPedido.Columns[4].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtItemPedido.Columns[4].DefaultCellStyle.Format = "n2";

            dtItemPedido.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtItemPedido.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dtItemPedido_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtItemPedido.DataSource == null)
            {
                dtItemPedido.Enabled = false;
            }
            else
            {
                dtItemPedido.Enabled = true;
            }
        }

        private void dtItemPedido_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtItemPedido.Columns[0].HeaderText = "Item";
            dtItemPedido.Columns[1].HeaderText = "Código";
            dtItemPedido.Columns[2].HeaderText = "Descrição";
            dtItemPedido.Columns[3].HeaderText = "Quantidade";
            dtItemPedido.Columns[4].HeaderText = "Valor (R$)";
            dtItemPedido.Columns[5].Visible = false;

            dtItemPedido.Columns[0].Width = 56;
            dtItemPedido.Columns[1].Width = 75;
            dtItemPedido.Columns[2].Width = 175;
            dtItemPedido.Columns[3].Width = 85;
            dtItemPedido.Columns[4].Width = 85;

            dtItemPedido.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemPedido.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemPedido.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemPedido.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemPedido.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemPedido.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemPedido.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemPedido.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemPedido.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtItemPedido.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtItemPedido.DefaultCellStyle.Font = new Font(dtItemPedido.Font, FontStyle.Bold);

            for (int i = 0; i < dtItemPedido.Rows.Count; i++)
            {
                if (dtItemPedido.Rows[i].Cells[1].Value.ToString() == "0")
                {
                    dtItemPedido.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dtItemPedido.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
            //
            lblRegItem.Text = "Registros: " + dtItemPedido.Rows.Count;
        }

        private void dtFormaPagamento_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dtFormaPagamento.Columns[0].HeaderText = "Item";
            dtFormaPagamento.Columns[1].HeaderText = "Código";
            dtFormaPagamento.Columns[2].HeaderText = "Tipo";
            dtFormaPagamento.Columns[3].HeaderText = "Valor Pago (R$)";
            dtFormaPagamento.Columns[4].Visible = false;

            dtFormaPagamento.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtFormaPagamento.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtFormaPagamento.Columns[0].Width = 55;
            dtFormaPagamento.Columns[1].Width = 60;
            dtFormaPagamento.Columns[2].Width = 147;
            dtFormaPagamento.Columns[3].Width = 105;

            dtFormaPagamento.DefaultCellStyle.Font = new Font(dtFormaPagamento.Font, FontStyle.Bold);

            lblRegFormaPagamento.Text = "Registros: " + dtFormaPagamento.Rows.Count;

            for (int i = 0; i < dtFormaPagamento.Rows.Count; i++)
            {
                if (dtFormaPagamento.Rows[i].Cells[1].Value.ToString() == "0")
                {
                    dtFormaPagamento.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dtFormaPagamento.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void dtFormaPagamento_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtFormaPagamento.Columns[3].DefaultCellStyle.FormatProvider = new CultureInfo("pt-BR");
            dtFormaPagamento.Columns[3].DefaultCellStyle.Format = "n2";

            dtFormaPagamento.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dtFormaPagamento.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dtFormaPagamento_DataSourceChanged(object sender, EventArgs e)
        {
            if (dtFormaPagamento.DataSource == null)
            {
                dtFormaPagamento.Enabled = false;
            }
            else
            {
                dtFormaPagamento.Enabled = true;
            }
        }

        private void dtItemPedido_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegItem.Text = "Registros: 0";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtpCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == 13)
            {
                mtxtpDataEmissao.Select();
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

        private void lblValorTotal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total (R$): " + lblValorTotal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorDesconto_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Descontos (R$): " + lblValorDesconto.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorAcrescimo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Acréscimos (R$): " + lblValorAcrescimo.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void lblValorTotalReal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Valor Total (R$): " + lblValorTotalReal.Text, "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.None;
        }

        private void dtItemPedido_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value.ToString() == "0")
            {
                e.Value = "";
            }
        }

        private void dtFormaPagamento_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblRegFormaPagamento.Text = "Registros: 0";
        }

        private void cbbFormaPagamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cbbSituacao.Select();
            }
        }

        private void cbbSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPesquisar.Select();
            }
        }

        private void btnProcurarPagamento_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            using (FrmPesqFormaPagamento Pag = new FrmPesqFormaPagamento(5, _Usuario, _Cod_PDV_Computador))
            {
                if (Pag.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        cbbFormaPagamento.Items.Clear();
                        if (bllPedAnotaAI.Sel_Forma_Pagamento_Ped_Anota_AI() == null)
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
                            foreach (DataRow dr in bllPedAnotaAI.Sel_Forma_Pagamento_Ped_Anota_AI().Rows)
                            {
                                cbbFormaPagamento.Items.Add(dr["id_pagamento"].ToString() + "—" + dr["tipo"].ToString());
                            }
                        }
                        cbbFormaPagamento.Text = bllPedAnotaAI._Pagamento_PesqPagamento_Tabela;
                        bllPedAnotaAI._Pagamento_PesqPagamento_Tabela = null;
                        cbbFormaPagamento.Select();
                    }
                    catch (Exception ex)
                    {
                        this.Enabled = true;
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
                        bllVenda._Pagamento_PesqPagamento_Tabela = null;
                    }
                }
            }
            this.Enabled = true;
        }

        private void btnGerarCupom_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                using (FrmPesqProduto Prod = new FrmPesqProduto(10, null, _Usuario, _Cod_PDV_Computador, 0, null))
                {
                    if (Prod.ShowDialog() == DialogResult.OK)
                    {
                        DataGridViewRow SelectedRow = dtItemPedido.Rows[dtItemPedido.CurrentRow.Index];
                        //
                        int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);
                        //
                        bllPedAnotaAI.Alterar_Item_Ped_Anota_Ai(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[5].Value.ToString(), bllPedAnotaAI._PedAnotaAi_PesqProduto_Tabela);
                        //
                        bllRegistroAtividades.Salvar("ALTEROU DADOS DE UM ITEM", "INTEGRACAO ANOTA AI", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Item alterado. Cod: " + SelectedRow.Cells[0].Value.ToString());
                        }
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Item alterado. Cod: " + SelectedRow.Cells[0].Value.ToString());
                        }
                        //
                        SelectedRow = dtPedido.Rows[dtPedido.CurrentRow.Index];
                        //
                        dtItemPedido.DataSource = bllPedAnotaAI.Sel_Ped_Anota_Ai_Items(SelectedRow.Cells[0].Value.ToString());
                        //
                        foreach (DataGridViewRow row in dtItemPedido.Rows)
                        {
                            if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                            {
                                row.Selected = true;
                                dtItemPedido.CurrentCell = row.Cells[0];
                                break;
                            }
                        }
                        //
                        MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                        //
                        dtItemPedido.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                this.Enabled = false;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisarProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisarProduto.");
                }
            }
            this.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            //try
            //{
                using (FrmPesqFormaPagamento Prod = new FrmPesqFormaPagamento(5, _Usuario, _Cod_PDV_Computador))
                {
                    if (Prod.ShowDialog() == DialogResult.OK)
                    {
                        DataGridViewRow SelectedRow = dtFormaPagamento.Rows[dtFormaPagamento.CurrentRow.Index];
                        //
                        int item_selecionado = Convert.ToInt32(SelectedRow.Cells[0].Value);
                        //
                        bllPedAnotaAI.Alterar_Pagamento_Ped_Anota_Ai(SelectedRow.Cells[0].Value.ToString(), SelectedRow.Cells[4].Value.ToString(), bllPedAnotaAI._Pagamento_PesqPagamento_Tabela);
                        //
                        bllRegistroAtividades.Salvar("ALTEROU DADOS DE UM PAGAMENTO", "INTEGRACAO ANOTA AI", SelectedRow.Cells[0].Value.ToString(), _Usuario, _Cod_PDV_Computador);
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Item alterado. Cod: " + SelectedRow.Cells[0].Value.ToString());
                        }
                        //
                        using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                        {
                            writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Item alterado. Cod: " + SelectedRow.Cells[0].Value.ToString());
                        }
                        //
                        SelectedRow = dtPedido.Rows[dtPedido.CurrentRow.Index];
                        //
                        dtFormaPagamento.DataSource = bllPedAnotaAI.Sel_Ped_Anota_Ai_Items_Pagamento(SelectedRow.Cells[0].Value.ToString());
                        //
                        foreach (DataGridViewRow row in dtItemPedido.Rows)
                        {
                            if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == item_selecionado)
                            {
                                row.Selected = true;
                                dtItemPedido.CurrentCell = row.Cells[0];
                                break;
                            }
                        }
                        //
                        MessageBox.Show("Os dados foram alterados com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                        //
                        dtItemPedido.Select();
                    }
                }
                /*
            }
            catch (Exception ex)
            {
                this.Enabled = false;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisarProduto.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnPesquisarProduto.");
                }
            }
                */
            this.Enabled = true;
        }
    }
}
