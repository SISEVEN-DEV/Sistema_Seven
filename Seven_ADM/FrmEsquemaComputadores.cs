using BLL;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;


namespace Seven_Sistema
{
    public partial class FrmEsquemaComputadores : Form
    {
        public FrmEsquemaComputadores(string cod_pdv_computador)
        {
            InitializeComponent();
            _Cod_PDV_Computador = cod_pdv_computador;
        }

        string _Cod_PDV_Computador;

        private void FrmConexaoStatus_Load(object sender, EventArgs e)
        {
            try
            {
                bllCadastroComputadores._FrmEsquemaComputadores_Ativo = true;

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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmEsquemaComputadores iniciado.");
                }
                //
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmEsquemaComputadores iniciado.");
                }
                //            
                String strHostName = Environment.MachineName;
                //
                lblNomePc.Text = strHostName;
                //
                for (int i = 0; i < bllCadastroComputadores.Sel_Nome_Computador_Todos_Cadastro_Computadores().Rows.Count; i++)
                {
                    DataRow dr = bllCadastroComputadores.Sel_Nome_Computador_Todos_Cadastro_Computadores().Rows[i];
                    //
                    if (i == 0)
                    {
                        if (dr["tipo_computador"].ToString() != "SERVIDOR")
                        {
                            lblServidor.Enabled = false;
                            btnServidor1.Enabled = false;
                            lblNomeServidor1.Enabled = false;
                            lblNomeServidor1.Text = null;
                        }
                        else
                        {
                            lblServidor.Enabled = true;
                            btnServidor1.Enabled = true;
                            lblNomeServidor1.Enabled = true;
                            lblNomeServidor1.Text = dr["nome_computador"].ToString();
                            //
                            if (lblNomeServidor1.Text.ToUpper() == lblNomePc.Text.ToUpper())
                            {
                                lblTipoPC.Text = "Servidor";
                            }
                        }
                    }
                    else if (i == 1)
                    {
                        if (dr["tipo_computador"].ToString() != "TERMINAL")
                        {
                            lblTerminal1.Visible = false;
                            btnComputador1.Visible = false;
                            lblNomeComputador1.Visible = false;
                            lblNomeComputador1.Text = null;
                        }
                        else
                        {
                            lblTerminal1.Visible = true;
                            btnComputador1.Visible = true;
                            lblNomeComputador1.Visible = true;
                            lblNomeComputador1.Text = dr["nome_computador"].ToString();
                            if (lblNomeServidor1.Text.ToUpper() != lblNomePc.Text.ToUpper())
                            {
                                lblTipoPC.Text = "Terminal";
                            }
                        }
                    }
                    else if (i == 2)
                    {
                        if (dr["tipo_computador"].ToString() != "TERMINAL")
                        {
                            lblTerminal2.Visible = false;
                            btnComputador2.Visible = false;
                            lblNomeComputador2.Visible = false;
                            lblNomeComputador2.Text = null;
                        }
                        else
                        {
                            lblTerminal2.Visible = true;
                            btnComputador2.Visible = true;
                            lblNomeComputador2.Visible = true;
                            lblNomeComputador2.Text = dr["nome_computador"].ToString();
                            if (lblNomeServidor1.Text.ToUpper() != lblNomePc.Text.ToUpper())
                            {
                                lblTipoPC.Text = "Terminal";
                            }
                        }
                    }
                    else if (i == 3)
                    {
                        if (dr["tipo_computador"].ToString() != "TERMINAL")
                        {
                            lblTerminal3.Visible = false;
                            btnComputador3.Visible = false;
                            lblNomeComputador3.Visible = false;
                            lblNomeComputador3.Text = null;
                        }
                        else
                        {
                            lblTerminal3.Visible = true;
                            btnComputador3.Visible = true;
                            lblNomeComputador3.Visible = true;
                            lblNomeComputador3.Text = dr["nome_computador"].ToString();
                            if (lblNomeServidor1.Text.ToUpper() != lblNomePc.Text.ToUpper())
                            {
                                lblTipoPC.Text = "Terminal";
                            }
                        }
                    }
                    else if (i == 4)
                    {
                        if (dr["tipo_computador"].ToString() != "TERMINAL")
                        {
                            lblTerminal4.Visible = false;
                            btnComputador4.Visible = false;
                            lblNomeComputador4.Visible = false;
                            lblNomeComputador4.Text = null;
                        }
                        else
                        {
                            lblTerminal4.Visible = true;
                            btnComputador4.Visible = true;
                            lblNomeComputador4.Visible = true;
                            lblNomeComputador4.Text = dr["nome_computador"].ToString();
                            if (lblNomeServidor1.Text.ToUpper() != lblNomePc.Text.ToUpper())
                            {
                                lblTipoPC.Text = "Terminal";
                            }
                        }
                    }
                    else if (i == 5)
                    {
                        if (dr["tipo_computador"].ToString() != "TERMINAL")
                        {
                            lblTerminal5.Visible = false;
                            btnComputador5.Visible = false;
                            lblNomeComputador5.Visible = false;
                            lblNomeComputador5.Text = null;
                        }
                        else
                        {
                            lblTerminal5.Visible = true;
                            btnComputador5.Visible = true;
                            lblNomeComputador5.Visible = true;
                            lblNomeComputador5.Text = dr["nome_computador"].ToString();
                            if (lblNomeServidor1.Text.ToUpper() != lblNomePc.Text.ToUpper())
                            {
                                lblTipoPC.Text = "Terminal";
                            }
                        }
                    }
                    else if (i == 6)
                    {
                        if (dr["tipo_computador"].ToString() != "TERMINAL")
                        {
                            lblTerminal6.Visible = true;
                            btnComputador6.Visible = true;
                            lblNomeComputador6.Visible = true;
                            lblNomeComputador6.Text = null;
                        }
                        else
                        {
                            lblTerminal6.Visible = true;
                            btnComputador6.Visible = true;
                            lblNomeComputador6.Visible = true;
                            lblNomeComputador6.Text = dr["nome_computador"].ToString();
                            if (lblNomeServidor1.Text.ToUpper() != lblNomePc.Text.ToUpper())
                            {
                                lblTipoPC.Text = "Terminal";
                            }
                        }
                    }
                    else if (i == 7)
                    {
                        if (dr["tipo_computador"].ToString() != "TERMINAL")
                        {
                            lblTerminal7.Visible = true;
                            btnComputador7.Visible = true;
                            lblNomeComputador7.Visible = true;
                            lblNomeComputador7.Text = null;
                        }
                        else
                        {
                            lblTerminal7.Visible = true;
                            btnComputador7.Visible = true;
                            lblNomeComputador7.Visible = true;
                            lblNomeComputador7.Text = dr["nome_computador"].ToString();
                            if (lblNomeServidor1.Text.ToUpper() != lblNomePc.Text.ToUpper())
                            {
                                lblTipoPC.Text = "Terminal";
                            }
                        }
                    }
                    else if (i == 8)
                    {
                        if (dr["tipo_computador"].ToString() != "TERMINAL")
                        {
                            lblTerminal8.Visible = true;
                            btnComputador8.Visible = true;
                            lblNomeComputador8.Visible = true;
                            lblNomeComputador8.Text = null;
                        }
                        else
                        {
                            lblTerminal8.Visible = true;
                            btnComputador8.Visible = true;
                            lblNomeComputador8.Visible = true;
                            lblNomeComputador8.Text = dr["nome_computador"].ToString();
                            if (lblNomeServidor1.Text.ToUpper() != lblNomePc.Text.ToUpper())
                            {
                                lblTipoPC.Text = "Terminal";
                            }
                        }
                    }
                    else if (i == 9)
                    {
                        if (dr["tipo_computador"].ToString() != "TERMINAL")
                        {
                            lblTerminal9.Visible = true;
                            btnComputador9.Visible = true;
                            lblNomeComputador9.Visible = true;
                            lblNomeComputador9.Text = null;
                        }
                        else
                        {
                            lblTerminal9.Visible = true;
                            btnComputador9.Visible = true;
                            lblNomeComputador9.Visible = true;
                            lblNomeComputador9.Text = dr["nome_computador"].ToString();
                            if (lblNomeServidor1.Text.ToUpper() != lblNomePc.Text.ToUpper())
                            {
                                lblTipoPC.Text = "Terminal";
                            }
                        }
                    }
                    else if (i == 10)
                    {
                        if (dr["tipo_computador"].ToString() != "TERMINAL")
                        {
                            lblTerminal10.Visible = true;
                            btnComputador10.Visible = true;
                            lblNomeComputador10.Visible = true;
                            lblNomeComputador10.Text = null;
                        }
                        else
                        {
                            lblTerminal10.Visible = true;
                            btnComputador10.Visible = true;
                            lblNomeComputador10.Visible = true;
                            lblNomeComputador10.Text = dr["nome_computador"].ToString();
                            if (lblNomeServidor1.Text.ToUpper() != lblNomePc.Text.ToUpper())
                            {
                                lblTipoPC.Text = "Terminal";
                            }
                        }
                    }
                    else if (i == 11)
                    {
                        if (dr["tipo_computador"].ToString() != "TERMINAL")
                        {
                            lblTerminal11.Visible = true;
                            btnComputador11.Visible = true;
                            lblNomeComputador11.Visible = true;
                            lblNomeComputador11.Text = null;
                        }
                        else
                        {
                            lblTerminal11.Visible = true;
                            btnComputador11.Visible = true;
                            lblNomeComputador11.Visible = true;
                            lblNomeComputador11.Text = dr["nome_computador"].ToString();
                            if (lblNomeServidor1.Text.ToUpper() != lblNomePc.Text.ToUpper())
                            {
                                lblTipoPC.Text = "Terminal";
                            }
                        }
                    }
                    else if (i == 12)
                    {
                        if (dr["tipo_computador"].ToString() != "TERMINAL")
                        {
                            lblTerminal12.Visible = true;
                            btnComputador12.Visible = true;
                            lblNomeComputador12.Visible = true;
                            lblNomeComputador12.Text = null;
                        }
                        else
                        {
                            lblTerminal12.Visible = true;
                            btnComputador12.Visible = true;
                            lblNomeComputador12.Visible = true;
                            lblNomeComputador12.Text = dr["nome_computador"].ToString();
                            if (lblNomeServidor1.Text.ToUpper() != lblNomePc.Text.ToUpper())
                            {
                                lblTipoPC.Text = "Terminal";
                            }
                        }
                    }
                    else if (i == 13)
                    {
                        if (dr["tipo_computador"].ToString() != "TERMINAL")
                        {
                            lblTerminal13.Visible = true;
                            btnComputador13.Visible = true;
                            lblNomeComputador13.Visible = true;
                            lblNomeComputador13.Text = null;
                        }
                        else
                        {
                            lblTerminal13.Visible = true;
                            btnComputador13.Visible = true;
                            lblNomeComputador13.Visible = true;
                            lblNomeComputador13.Text = dr["nome_computador"].ToString();
                            if (lblNomeServidor1.Text.ToUpper() != lblNomePc.Text.ToUpper())
                            {
                                lblTipoPC.Text = "Terminal";
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
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmEsquemaComputadores.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento load do formulário FrmEsquemaComputadores.");
                }
                this.Close();
            }
        }

        private void FrmConexaoStatus_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FrmConexaoStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmEsquemaComputadores foi finalizado.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Formulário FrmEsquemaComputadores foi finalizado.");
                }
                bllCadastroComputadores._FrmEsquemaComputadores_Ativo = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmEsquemaComputadores.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento formclosing do formulário FrmEsquemaComputadores.");
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComputador1_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeServidor1.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void btnComputador1_MouseLeave(object sender, EventArgs e)
        {
            lblNomeServidor1.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void btnComputador1_Click(object sender, EventArgs e)
        {
            
        }

        private void lblNomeComputador1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSair_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void lblNomeServidor1_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeServidor1.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void lblNomeServidor1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblNomeServidor1.BorderStyle = BorderStyle.None;
        }

        private void lblNomeComputador1_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador1.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void lblNomeComputador1_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador1.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void lblNomeComputador2_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador2.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void lblNomeComputador2_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador2.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void lblNomeComputador3_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador3.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void lblNomeComputador3_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador3.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void lblNomeComputador4_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador4.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void lblNomeComputador4_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador4.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void lblNomeComputador5_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador5.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void lblNomeComputador5_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador5.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void lblNomeComputador6_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador6.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void lblNomeComputador6_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador6.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void lblNomeComputador7_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador7.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void lblNomeComputador7_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador7.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void lblNomeComputador8_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador8.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void lblNomeComputador8_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador8.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void lblNomeComputador9_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador9.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void lblNomeComputador9_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador9.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void lblNomeComputador10_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador10.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void lblNomeComputador10_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador10.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void lblNomeComputador11_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador11.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void lblNomeComputador11_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador11.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void lblNomeComputador12_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador12.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void lblNomeComputador12_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador12.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void lblNomeComputador13_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador13.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void lblNomeComputador13_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador13.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void btnComputador1_MouseMove_1(object sender, MouseEventArgs e)
        {
            lblNomeComputador1.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void btnComputador1_MouseLeave_1(object sender, EventArgs e)
        {
            lblNomeComputador1.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void btnComputador2_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador2.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void btnComputador2_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador2.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void btnComputador3_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador3.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void btnComputador3_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador3.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void btnComputador4_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador4.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void btnComputador4_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador4.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void btnComputador5_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador5.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void btnComputador5_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador5.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void btnComputador6_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador6.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void btnComputador6_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador6.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void btnComputador7_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador7.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void btnComputador7_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador7.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void btnComputador8_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador8.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void btnComputador8_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador8.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void btnComputador9_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador9.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void btnComputador9_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador9.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void btnComputador10_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador10.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void btnComputador10_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador10.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void btnComputador11_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador11.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void btnComputador11_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador11.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void btnComputador12_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador12.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void btnComputador12_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador12.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void btnComputador13_MouseMove(object sender, MouseEventArgs e)
        {
            lblNomeComputador13.BorderStyle = BorderStyle.FixedSingle;
            this.Cursor = Cursors.Hand;
        }

        private void btnComputador13_MouseLeave(object sender, EventArgs e)
        {
            lblNomeComputador13.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Default;
        }

        private void btnComputador1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void lblNomeComputador1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btnComputador2_Click(object sender, EventArgs e)
        {
           
        }

        private void btnComputador3_Click(object sender, EventArgs e)
        {
           
        }

        private void lblNomeComputador3_Click(object sender, EventArgs e)
        {
          
        }

        private void btnComputador4_Click(object sender, EventArgs e)
        {
         
        }

        private void lblNomeComputador4_Click(object sender, EventArgs e)
        {
        
        }

        private void btnComputador5_Click(object sender, EventArgs e)
        {
            
        }

        private void lblNomeComputador5_Click(object sender, EventArgs e)
        {
           
        }

        private void btnComputador6_Click(object sender, EventArgs e)
        {
           
        }

        private void lblNomeComputador6_Click(object sender, EventArgs e)
        {
            
        }

        private void btnComputador7_Click(object sender, EventArgs e)
        {
        
        }

        private void lblNomeComputador7_Click(object sender, EventArgs e)
        {
       
        }

        private void btnComputador8_Click(object sender, EventArgs e)
        {
           
        }

        private void lblNomeComputador8_Click(object sender, EventArgs e)
        {
            
        }

        private void btnComputador9_Click(object sender, EventArgs e)
        {
            
        }

        private void lblNomeComputador9_Click(object sender, EventArgs e)
        {
           
        }

        private void btnComputador10_Click(object sender, EventArgs e)
        {
          
        }

        private void lblNomeComputador10_Click(object sender, EventArgs e)
        {
           
        }

        private void btnComputador11_Click(object sender, EventArgs e)
        {
          
        }

        private void lblNomeComputador11_Click(object sender, EventArgs e)
        {
           
        }

        private void btnComputador12_Click(object sender, EventArgs e)
        {
           
        }

        private void lblNomeComputador12_Click(object sender, EventArgs e)
        {
           
        }

        private void btnComputador13_Click(object sender, EventArgs e)
        {
           
        }

        private void lblNomeComputador13_Click(object sender, EventArgs e)
        {
        
        }

        private void lblNomeComputador2_Click(object sender, EventArgs e)
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

        private void picbInterrogacao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1 - Informações: Mostra dados do computador atual.\n\n2 - Todos os Computadores: Mostra todos os computadores que possuem registro no aplicativo, são computadores que tem permissão para acessar o aplicativo.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
