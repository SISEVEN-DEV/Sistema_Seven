using BLL;
using Seven_ADM;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACBrLib.NFe;

namespace Seven_Sistema
{
    public partial class FrmTroco : Form
    {
        public FrmTroco(string valor_troco, string cod_venda, string usuario, string cod_pdv_computador)
        {
            InitializeComponent();
            lblValorTroco.Text = valor_troco;
            _Usuario = usuario;
            _Cod_PDV_Computador = cod_pdv_computador;
            _Cod_Venda = cod_venda;
        }

        private string _Cod_Venda;
        private string _Usuario;
        private string _Cod_PDV_Computador;

        private void FrmTroco_Load(object sender, EventArgs e)
        {
            btnOK.Select();
        }

        private void FrmTroco_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void FrmTroco_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private async void btnEnviarWhatsapp_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                this.TopMost = false;
                DataRow drVenda = bllVenda.Sel_Venda_Codigo(_Cod_Venda).Rows[0];
                //
                string celular;
                //
                DataRow dr;
                if (drVenda["id_consumidor"].ToString() != "0")
                {
                    dr = bllClieCons.Sel_Cliente_Codigo(drVenda["id_consumidor"].ToString()).Rows[0];
                    //
                    if (dr["celular"].ToString() == "" || dr["celular"].ToString() == null)
                    {
                        using (FrmCadCelular Cel = new FrmCadCelular(_Usuario, _Cod_PDV_Computador, 2))
                        {
                            if (Cel.ShowDialog() == DialogResult.OK)
                            {
                                celular = bllVenda._Celular_CadCelular_Tabela;
                            }
                            else
                            {
                                celular = null;
                                return;
                            }
                        }
                    }
                    else
                    {
                        celular = dr["celular"].ToString();
                    }
                }
                else
                {
                    using (FrmCadCelular Cel = new FrmCadCelular(_Usuario, _Cod_PDV_Computador, 2))
                    {
                        if (Cel.ShowDialog() == DialogResult.OK)
                        {
                            celular = bllVenda._Celular_CadCelular_Tabela;
                        }
                        else
                        {
                            celular = null;
                            return;
                        }
                    }
                }
                //
                celular = celular.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
                //
                if (drVenda["tipo"].ToString() == "NFCe" || drVenda["tipo"].ToString() == "NFe")
                {
                    if (bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "_", "_", "_", "_", "_", "_", "", "", "", "", "", "", "", "", drVenda["id_venda"].ToString()) == null)
                    {
                        MessageBox.Show("Não foi possível localizar o DFe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        dr = bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "_", "_", "_", "_", "_", "_", "", "", "", "", "", "", "", "", drVenda["id_venda"].ToString()).Rows[0];
                    }
                    //
                    if (!File.Exists(dr["caminho_dfe"].ToString()))
                    {
                        MessageBox.Show("Não foi possível localizar o arquivo do dfe [ " + dr["id_dfe"].ToString() + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
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
                        string modelo = null;
                        if (dr["modelo"].ToString() == "55")
                        {
                            modelo = "NFe";
                        }
                        else if (dr["modelo"].ToString() == "65")
                        {
                            modelo = "NFCe";
                        }
                        //
                        string destino_pdf = @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("-", "").Replace("/", "") + @"\" + modelo + "_" + dr["numero_nf"].ToString() + ".pdf";
                        ACBrNFe.LimparLista();
                        ACBrNFe.CarregarXML(dr["caminho_dfe"].ToString());
                        var nomeArquivo = destino_pdf;
                        //
                        for (int i = 0; i < 2; i++)
                        {
                            using (FileStream aStream = File.Create(nomeArquivo))
                            {
                                ACBrNFe.ImprimirPDF(aStream);
                                byte[] buffer = new Byte[aStream.Length];
                                await aStream.ReadAsync(buffer, 0, buffer.Length);
                                await aStream.FlushAsync();
                                aStream.Seek(0, SeekOrigin.End);
                                await aStream.WriteAsync(buffer, 0, buffer.Length);
                            }
                        }
                        //
                        await bllVenda.UploadPdfAsync(destino_pdf, celular);
                        //
                        bllRegistroAtividades.Salvar("ENVIO DE VENDA POR WHATSAPP", "VENDA", drVenda["id_venda"].ToString(), _Usuario, _Cod_PDV_Computador);
                    }
                }
                else if (drVenda["tipo"].ToString() == "DAV")
                {
                    string mes;
                    if (Convert.ToDateTime(drVenda["data"]).Month < 10)
                    {
                        mes = "0" + Convert.ToDateTime(drVenda["data"]).Month;
                    }
                    else
                    {
                        mes = Convert.ToDateTime(drVenda["data"]).Month.ToString();
                    }

                    if (!File.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes + @"\" + drVenda["id_venda"].ToString() + ".pdf"))
                    {
                        MessageBox.Show("Não foi possível localizar o arquivo do DAV [ " + drVenda["id_venda"].ToString() + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        string destino_pdf = @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes + @"\" + drVenda["id_venda"].ToString() + ".pdf";
                        //
                        await bllVenda.UploadPdfAsync(destino_pdf, celular);
                        //
                        bllRegistroAtividades.Salvar("ENVIO DE VENDA POR WHATSAPP", "VENDA", drVenda["id_venda"].ToString(), _Usuario, _Cod_PDV_Computador);
                    }
                }
                //
                btnOK.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarWhatsapp.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarWhatsapp.");
                }
            }
        }

        public async Task EnviarMensagem(string numero, string mensagem) 
        {
            /*
            var token = "EAASEhb1Dxb4BPEe3kdJANJXNKFoucsS6FxjWxu324RDOtmAy8USVzK1FOsQ7R3ozLOMnHu95BVzlM7IvRXhKWss7dIgyg65pZAZAiStdaASkl76fd4gmNCPcXxm4vPHmgnez3EnMwDzZBkgaR7ANee2t1VPUTksuWPi3v9A3yy5w4ddE8C3kIZBoZCsBvjYIv6acaIew5YZBdoKbQcv4tKwZCIZAurWOZCqO3ZBqneuGEwsrqZB2AZDZD";

            var numeroDoTelefone = "780239865162570";

            var url = $"https://graph.facebook.com/v19.0/{numeroDoTelefone}/messages";

            var cliente = new HttpClient();

            cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var payload = new
            {
                messaging_product = "whatsapp",
                to = numero,
                type = "text",
                text = new { body = mensagem }
            };

            var json = System.Text.Json.JsonSerializer.Serialize(payload);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync(url, content);

            string resultado = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode) 
            {
                throw new Exception($"Erro: { response.StatusCode} - { resultado } ");
            }

            MessageBox.Show("Mensagem enviada", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
        }

        private void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            try
            {
                TopMost = false;
                DataRow drVenda = bllVenda.Sel_Venda_Codigo(_Cod_Venda).Rows[0];
                //
                string email = "";
                //
                if (drVenda["id_consumidor"].ToString() != "0")
                {
                    if (bllClieCons.Sel_Cliente_Codigo(drVenda["id_consumidor"].ToString()) == null)
                    {
                        MessageBox.Show("O Cliente/Consumidor não foi encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.None;
                        email = null;
                    }
                    else
                    {
                        DataRow dr = bllClieCons.Sel_Cliente_Codigo(drVenda["id_consumidor"].ToString()).Rows[0];
                        //
                        if (dr["email"].ToString() == null || dr["email"].ToString() == "")
                        {
                            MessageBox.Show("Este cliente não possui e-mail cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.DialogResult = DialogResult.None;
                            email = null;
                        }
                        else
                        {
                            email = dr["email"].ToString();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("A Venda selecionada não possui nenhum Cliente/Consumidor informado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    email = null;
                }
                //
                string arquivo = null;
                //
                if (drVenda["tipo"].ToString() == "NFCe" || drVenda["tipo"].ToString() == "NFe")
                {
                    DataRow dr;
                    if (bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "_", "_", "_", "_", "_", "_", "", "", "", "", "", "", "", "", drVenda["id_venda"].ToString()) == null)
                    {
                        MessageBox.Show("Não foi possível localizar o DFe.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        dr = bllDFe.Sel_Dfe_DataEmiss_HoraEmiss_Tipo_Cod_Venda("_", "_", "_", "_", "_", "_", "_", "_", "", "", "", "", "", "", "", "", drVenda["id_venda"].ToString()).Rows[0];
                    }
                    //
                    if (!File.Exists(dr["caminho_dfe"].ToString()))
                    {
                        MessageBox.Show("Não foi possível localizar o arquivo do dfe [ " + dr["id_dfe"].ToString() + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        arquivo = dr["caminho_dfe"].ToString();
                    }
                }
                else if (drVenda["tipo"].ToString() == "DAV")
                {
                    string mes;
                    if (Convert.ToDateTime(drVenda["data"]).Month < 10)
                    {
                        mes = "0" + Convert.ToDateTime(drVenda["data"]).Month;
                    }
                    else
                    {
                        mes = Convert.ToDateTime(drVenda["data"]).Month.ToString();
                    }

                    if (!File.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes + @"\" + drVenda["id_venda"].ToString() + ".pdf"))
                    {
                        MessageBox.Show("Não foi possível localizar o arquivo do DAV [ " + drVenda["id_venda"].ToString() + " ].", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        arquivo = @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\PDV\Pedido\" + Convert.ToDateTime(drVenda["data"]).Year + mes + @"\" + drVenda["id_venda"].ToString() + ".pdf";
                    }
                }
                //
                this.Enabled = false;
                using (FrmUtilEnviarEmail Mail = new FrmUtilEnviarEmail(4, _Cod_PDV_Computador, _Usuario, arquivo, "Segue em anexo a Venda", "Venda", email))
                {
                    if (Mail.ShowDialog() == DialogResult.OK)
                    {
                        btnOK.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                this.Enabled = true;
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (StreamWriter writer = new StreamWriter(@"C:\Sistema SEVEN\Config\Log\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarEmail.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Windows\Temp\Sistema SEVEN\Log de Acoes\" + DateTime.Now.ToShortDateString().Replace('/', '_') + ".txt", true))
                {
                    writer.WriteLine(DateTime.Now.ToShortTimeString() + " - Erro: " + ex.Message + " | Evento click do botão btnEnviarEmail.");
                }
            }
            this.Enabled = true;
        }
    }
}
