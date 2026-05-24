using DAL;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using WIA;

namespace BLL
{
    public class bllDocumentos
    {
        public static bool _FrmCadDocumentos_Ativo;
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;
        public static string _Grupo_PesqGrupo_Tabela;
        public static string _SubGrupo_PesqSubGrupo_Tabela;
        public static string _Nome_Arquivo = null;
        public static string _Celular_CadCelular_Tabela;


        private static void SetWIAProperty(IProperties properties, object propName, object propValue)
        {
            try
            {
                Property prop = properties.get_Item(ref propName);
                prop.set_Value(ref propValue);
            }
            catch { }
        }

        public static bool Escanear()
        {
            var dialog = new WIA.CommonDialog();

            ImageFile image = dialog.ShowAcquireImage(
                WiaDeviceType.ScannerDeviceType,
                WiaImageIntent.ColorIntent,
                WiaImageBias.MaximizeQuality,
                FormatID.wiaFormatJPEG,
                false, true, false
                );

            if (image != null)
            {
                byte[] bytes = (byte[])image.FileData.get_BinaryData();

                using (var ms = new MemoryStream(bytes))
                {
                    Image.FromStream(ms);

                var reduzida = RedimensionarProporcional(Image.FromStream(ms), 1280, 720);

                var encoder = ImageCodecInfo.GetImageEncoders()
                    .First(c => c.FormatID == ImageFormat.Jpeg.Guid);

                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 70L);

                    if (Directory.Exists(@"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Digitalizacao"))
                    {
                        Directory.CreateDirectory(@"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Digitalizacao");
                    }

                    string guid = Guid.NewGuid().ToString("N");

                    reduzida.Save(@"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Digitalizacao\" + guid + ".jpg", encoder, encoderParams);
                    _Nome_Arquivo = @"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\Digitalizacao\" + guid + ".jpg";
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static Bitmap RedimensionarProporcional(Image img, int maxLargura, int maxAltura) 
        {
            double ratioX = (double)maxLargura / img.Width;
            double ratioY = (double)maxAltura / img.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int novaLargura = (int)(img.Width * ratio);
            int novaAltura = (int)(img.Height * ratio);

            var novaImagem = new Bitmap(novaLargura, novaAltura);

            using (var g = Graphics.FromImage(novaImagem)) 
            {
                g.DrawImage(img, 0, 0, novaLargura, novaAltura);
            }

            return novaImagem;
        }

        public static byte[] SalvarJpegComQualidade(Image img, long qualidade = 70L) 
        {
            using (var ms = new MemoryStream())
            {
                var encoder = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);

                var encoderParams = new EncoderParameters(1);

                encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, qualidade);

                img.Save(ms, encoder, encoderParams);

                return ms.ToArray();
            }
        }

        public static bool Sel_Documento_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Documento Doc = new Documento())
                {
                    Doc.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Documento_Ainda_Existe(Doc);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Documento Doc = new Documento())
                {
                    Doc.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Documento(Doc);
                }
            }
        }


        public static DataTable Sel_Documento_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (CFOP Cfop = new CFOP())
                {
                    Cfop.Pesquisar = pesquisar;
                    return con.Sel_CFOP_Codigo_CFOP(Cfop);
                }
            }
        }

        public static DataTable Sel_Documento_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Documento Doc = new Documento())
                {
                    Doc.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Documento_A_Alt(Doc);
                }
            }
        }

        public static DataTable Sel_Documento_A_Salvar()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Documento_A_Salvar();
            }
        }

        public static DataTable Sel_ComboboxSubGrupo_Valor_A_Alterar_Documento(string cbbsubgrupo, string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Documento Doc = new Documento())
                {
                    string[] items = cbbsubgrupo.Split('—');
                    Doc.Cod_SubGrupo = Convert.ToInt16(items[0]);
                    items = cbbgrupo.Split('—');
                    Doc.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxSubGrupo_Valor_A_Alterar_Documento(Doc);
                }
            }
        }

        public static DataTable Sel_ComboboxGrupo_Valor_A_Documento(string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Documento Doc = new Documento())
                {
                    string[] items = cbbgrupo.Split('—');
                    Doc.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxGrupo_Valor_A_Documento(Doc);
                }
            }
        }


        public static DataTable Sel_Documento_Data_Codigo_Clie_Forn_Func_Usuario_Situacao_Grupo_SubGrupo(string situacao, string codigo, string data, string data1, string horario, string horario1, string destinatario, byte formulario, string grupo, string subgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    string SqlCodigo;
                    string SqlData;
                    string SqlDestinatrio;
                    string SqlSituacao;
                    string SqlGrupo;
                    string SqlSubgrupo;
                    //
                    string[] items;
                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "WHERE documento.data BETWEEN '01.01.2020 00:00:00' AND '" + DateTime.Now.ToShortDateString().Replace("/", ".") + " 23:59:59'";
                    }
                    else
                    {
                        if (horario.Contains("_"))
                        {
                            horario = "";
                        }
                        else
                        {
                            horario = " " + horario;
                        }
                        //
                        if (horario1.Contains("_"))
                        {
                            horario1 = " 23:59:59";
                        }
                        else
                        {
                            horario1 = " " + horario1;
                        }
                        //
                        SqlData = "WHERE documento.data BETWEEN '" + data.Replace("/", ".") + horario + "' AND '" + data1.Replace("/", ".") + horario1 + "'";
                    }
                    //
                    if (codigo == null || codigo == "")
                    {
                        SqlCodigo = "";
                    }
                    else
                    {
                        SqlCodigo = " AND documento.id_documento='" + codigo + "'";
                    }
                    //
                    if (situacao == null || situacao == "")
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = " AND documento.situacao='" + situacao + "'";
                    }
                    //
                    if (destinatario == null || destinatario == "")
                    {
                        SqlDestinatrio = "";
                    }
                    else
                    {
                        items = destinatario.Split('—');
                        //
                        SqlDestinatrio = " AND documento.id_consumidor='" + items[0] + "'";
                    }
                    //
                    if (grupo == null || grupo == "")
                    {
                        SqlGrupo = "";
                    }
                    else
                    {
                        items = grupo.Split('—');
                        //
                        SqlGrupo = " AND documento.id_grupo='" + items[0] + "'";
                    }
                    //
                    if (subgrupo == null || subgrupo == "")
                    {
                        SqlSubgrupo = "";
                    }
                    else
                    {
                        items = subgrupo.Split('—');
                        //
                        SqlSubgrupo = " AND documento.id_subgrupo='" + items[0] + "'";
                    }

                    return con.Sel_Documento_Data_Codigo_Clie_Forn_Func_Usuario_Situacao_Grupo_SubGrupo(SqlSituacao, SqlCodigo, SqlData, SqlGrupo, SqlSubgrupo);
                }
            }
        }

        public static void Salvar(string descricao, string data, string horario, string situacao, string grupo, string subgrupo, string observacao, string arq_documento, string usuario, string consumidor, string funcionario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Documento Doc = new Documento())
                {
                    if (descricao == "" || descricao == null)
                    {
                        Doc.Descricao = "null";
                    }
                    else
                    {
                        Doc.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (data == "" || data == "  /  /" || data == "__/__/____" || data == null)
                    {
                        Doc.Data = "null";
                    }
                    else
                    {
                        if (horario == "" || horario == "  :  :" || horario == "__:__:__" || horario == null)
                        {
                            Doc.Data = "'" + data.Replace('/', '.') + " 00:00:00'";
                        }
                        else
                        {
                            Doc.Data = "'" + data.Replace('/', '.') + " " + horario.Remove(5) + "'";
                        }
                    }
                    //
                    if (horario == "" || horario == null || horario == "  :  :" || horario == "__:__:__")
                    {
                        Doc.Horario = "null";
                    }
                    else
                    {
                        Doc.Horario = horario.Insert(horario.Length, "'").Insert(0, "'");
                    }
                    //
                    if (situacao == "" || situacao == null)
                    {
                        Doc.Situacao = "null";
                    }
                    else
                    {
                        Doc.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    }
                    //
                    string [] items = grupo.Split('—');
                    //
                    Doc.Cod_Grupo = Convert.ToInt16(items[0]);
                    Doc.Desc_Grupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = subgrupo.Split('—');
                    //
                    Doc.Cod_SubGrupo = Convert.ToInt16(items[0]);
                    Doc.Desc_SubGrupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    if (observacao == "" || observacao == null)
                    {
                        Doc.Observacao = "null";
                    }
                    else
                    {
                        Doc.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (File.Exists(arq_documento))
                    {
                        byte[] arquivoBytes = File.ReadAllBytes(arq_documento);
                        //
                        Doc.Arq_Documento = arquivoBytes;
                        //
                        items = arq_documento.Split('\\');
                        //
                        Doc.Nome_Arquivo = "'" + items[items.Length - 1] + "'";
                    }
                    else
                    {
                        throw new Exception("Arquivo não encontrado.");
                    }
                    // 
                    con.Salvar_Documento(Doc);
                }
            }
        }

        public static void Alterar(string codigo, string descricao, string data, string horario, string situacao, string grupo, string subgrupo, string observacao, string arq_documento, string usuario, string consumidor, string funcionario, string nome_arquivo, bool mudou_arquivo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Documento Doc = new Documento())
                {
                    Doc.Codigo = Convert.ToInt32(codigo);

                    if (descricao == "" || descricao == null)
                    {
                        Doc.Descricao = "null";
                    }
                    else
                    {
                        Doc.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (data == "" || data == "  /  /" || data == "__/__/____" || data == null)
                    {
                        Doc.Data = "null";
                    }
                    else
                    {
                        if (horario == "" || horario == "  :  :" || horario == "__:__:__" || horario == null)
                        {
                            Doc.Data = "'" + data.Replace('/', '.') + " 00:00:00'";
                        }
                        else
                        {
                            Doc.Data = "'" + data.Replace('/', '.') + " " + horario.Remove(5) + "'";
                        }
                    }
                    //
                    if (horario == "" || horario == "  :  :" || horario == "__:__:__" || horario == null)
                    {
                        Doc.Horario = "null";
                    }
                    else
                    {
                        Doc.Horario = horario.Insert(horario.Length, "'").Insert(0, "'");
                    }
                    //
                    if (situacao == "" || situacao == null)
                    {
                        Doc.Situacao = "null";
                    }
                    else
                    {
                        Doc.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    }
                    //
                    string [] items = grupo.Split('—');
                    //
                    Doc.Cod_Grupo = Convert.ToInt16(items[0]);
                    Doc.Desc_Grupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = subgrupo.Split('—');
                    //
                    Doc.Cod_SubGrupo = Convert.ToInt16(items[0]);
                    Doc.Desc_SubGrupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    if (observacao == "" || observacao == null)
                    {
                        Doc.Observacao = "null";
                    }
                    else
                    {
                        Doc.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (mudou_arquivo == true)
                    {
                        if (File.Exists(arq_documento))
                        {
                            byte[] arquivoBytes = File.ReadAllBytes(arq_documento);
                            //
                            items = arq_documento.Split('\\');
                            //
                            Doc.Nome_Arquivo = "'" + items[items.Length - 1] + "'";
                            //
                            Doc.Arq_Documento = arquivoBytes;
                            //
                            con.Alterar_Arq_Documento(Doc);
                        }
                        else
                        {
                            throw new Exception("Arquivo não encontrado.");
                        }
                    }
                    //
                    con.Alterar_Documento(Doc);
                }
            }
        }

        public static void Arq_Documento (string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Documento Doc = new Documento()) 
                {
                    Doc.Codigo = Convert.ToInt32(codigo);
                    //
                    if (con.Arq_Documento(Doc) != null)
                    {
                        DataRow dr = con.Arq_Documento(Doc).Rows[0];
                        //
                        byte[] arquivoBytes = (byte[])dr[0];
                        //
                        string[] items = dr[1].ToString().Split('.');
                        //
                        string guid = Guid.NewGuid().ToString("N");
                        //
                        string diretorio = @"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace("/", "").Replace(".", "").Replace("-", "") + @"\Documentos";
                        //
                        if (!Directory.Exists(diretorio))
                        {
                            Directory.CreateDirectory(diretorio);
                        }
                        //
                        string caminho = diretorio + @"\" + guid + "." + items[1];
                        //
                        File.WriteAllBytes(caminho, arquivoBytes);
                        //
                        Process.Start(new ProcessStartInfo()
                        { 
                            FileName = caminho, UseShellExecute = true
                        });
                    }
                }
            }
        }

        public static string Arq_Documento_Zap(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Documento Doc = new Documento())
                {
                    Doc.Codigo = Convert.ToInt32(codigo);
                    //
                    if (con.Arq_Documento(Doc) != null)
                    {
                        DataRow dr = con.Arq_Documento(Doc).Rows[0];
                        //
                        byte[] arquivoBytes = (byte[])dr[0];
                        //
                        string[] items = dr[1].ToString().Split('.');
                        //
                        string guid = Guid.NewGuid().ToString("N");
                        //
                        string diretorio = @"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace("/", "").Replace(".", "").Replace("-", "") + @"\Documentos";
                        //
                        if (!Directory.Exists(diretorio))
                        {
                            Directory.CreateDirectory(diretorio);
                        }
                        //
                        string caminho = diretorio + @"\" + guid + "." + items[1];
                        //
                        File.WriteAllBytes(caminho, arquivoBytes);
                        //
                        return caminho;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public static bool Exportar_Arq_Documento(string codigo, string data)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Documento Doc = new Documento())
                {
                    try
                    {
                        Doc.Codigo = Convert.ToInt32(codigo);
                        //
                        if (con.Arq_Documento(Doc) != null)
                        {
                            DataRow dr = con.Arq_Documento(Doc).Rows[0];
                            //
                            byte[] arquivoBytes = (byte[])dr[0];
                            //
                            string[] items = dr[1].ToString().Split('.');
                            //
                            string guid = Guid.NewGuid().ToString("N");
                            //
                            string diretorio = @"C:\Windows\Temp\Sistema SEVEN\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace("/", "").Replace(".", "").Replace("-", "") + @"\Documentos\Exportacao_Documento_" + data;
                            //
                            if (!Directory.Exists(diretorio))
                            {
                                Directory.CreateDirectory(diretorio);
                            }
                            //
                            string caminho = diretorio + @"\" + guid + "." + items[1];
                            //
                            File.WriteAllBytes(caminho, arquivoBytes);
                            //
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        public static async Task UploadPdfAsync(string caminho, string celular)
        {
            var url = "https://www.siseven.com.br/api/upload/upload";

            var client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(5);

            var form = new MultipartFormDataContent();

            var fs = File.OpenRead(caminho);
            var streamContent = new StreamContent(fs);

            string [] items = caminho.Split('\\');
            //
            if (items[items.Length - 1] == ".pdf")
            {
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            }
            else if (items[items.Length - 1] == ".bmp")
            {
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("image/bmp");
            }
            else if (items[items.Length - 1] == ".jpg" || items[items.Length - 1] == ".jpeg")
            {
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            }
            else if (items[items.Length - 1] == ".png")
            {
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            }
            else if (items[items.Length - 1] == ".xps")
            {
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-xpsdocument");
            }
            else if (items[items.Length - 1] == ".doc")
            {
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/msword");
            }
            else if (items[items.Length - 1] == ".xls")
            {
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            }
            else if (items[items.Length - 1] == ".txt")
            {
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            }
            else if (items[items.Length - 1] == ".xml")
            {
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
            }
            //
            form.Add(streamContent, "arquivo", Path.GetFileName(caminho));
            //
            var response = await client.PostAsync(url, form);

            var resposta = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                /*
                MessageBox.Show(
            $"Status: {(int)response.StatusCode}\n\n{resposta}",
            "Erro no Upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                */
                MessageBox.Show("Ocorreu um ou mais erros.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var resultado = JsonConvert.DeserializeObject<RespostaUploadDFe>(resposta);

            MessageBox.Show("O Upload foi realizado com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string mensagem = "Olá! O *Documento* está disponível em:\n" + resultado.url;

            Clipboard.SetText(mensagem);

            string encodedMessage = HttpUtility.UrlEncode(mensagem);

            string whatsapp = $"https://wa.me/55{celular}?text={encodedMessage}";

            Process.Start(new ProcessStartInfo
            {
                FileName = whatsapp,
                UseShellExecute = true
            });
        }


        public static DataTable Sel_Grupo_Doc()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Grupo_Doc();
            }
        }

        public static DataTable Sel_Usuario_Doc()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Usuario_Doc();
            }
        }

        public static DataTable Sel_SubGrupo_Doc(string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Documento Doc = new Documento())
                {
                    string[] items = cbbgrupo.Split('—');
                    Doc.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_SubGrupo_Doc(Doc);
                }
            }
        }











    }

}