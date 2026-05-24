using DAL;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Security;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;

namespace BLL
{
    public class bllSangriaSuprimento
    {
        public static bool _FrmRelSangriaSuprimento_Aberto;
        public static bool _FrmCadSangriaSuprimento_Aberto;
        //
        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;
        //
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;
        //
        public static string _SangriaSuprimento_PesqUsuarioTabela;
        public static string _SangriaSuprimento_PesqCompPDV_Tabela;

        public static void Salvar(string descricao, string valor, string usuario, string tipo, string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Sangria_Suprimento Sang = new Sangria_Suprimento())
                {
                    if (descricao == "")
                    {
                        Sang.Descricao = "null";
                    }
                    else
                    {
                        Sang.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    }
                    //
                    Sang.Data = "'" + DateTime.Now.ToShortDateString().Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Sang.Hora = "'" + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Sang.Tipo = tipo.Insert(tipo.Length, "'").Insert(0, "'");
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    if (valor.Contains("."))
                    {
                        Sang.Valor = Convert.ToDecimal(valor.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Sang.Valor = Convert.ToDecimal(valor.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    usuario = usuario.Remove(0, 12);
                    string[] items = usuario.Split('—');
                    Sang.Cod_Usuario = Convert.ToInt16(items[0]);
                    Sang.Nome_Usuario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = cod_pdv_computador.Split('/');
                    Sang.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    //
                    con.Salvar_Sangria_Suprimento(Sang);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Sangria_Suprimento Sang = new Sangria_Suprimento())
                {
                    Sang.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Sangria_Suprimento(Sang);
                }
            }
        }

        public static DataTable Sel_Sangria_Suprimento_Data_PDV(string data, string hora)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Sangria_Suprimento Sang = new Sangria_Suprimento())
                {
                    Sang.Data = data.Replace('/', '.');
                    Sang.Hora = hora;
                    return con.Sel_Sangria_Suprimento_Data_PDV(Sang);
                }
            }
        }

        public static DataTable Sel_Ultima_Sangria_Suprimento()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Ultima_Sangria_Suprimento();
            }
        }

        public static bool Sel_SangSup_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Sangria_Suprimento Sang = new Sangria_Suprimento())
                {
                    Sang.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_SangSup_Ainda_Existe(Sang);
                }
            }
        }

        public static string Sel_Abert_Caixa_Dados_Sang_Qtdeg(string data, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Sangria_Suprimento Sang = new Sangria_Suprimento())
                {
                    Sang.Data = data.Replace('/', '.');
                    //
                    Sang.Cod_PDV_Computador = Convert.ToInt16(cod_pdv_computador);
                    //
                    string[] items = usuario.Split('-');
                    Sang.Cod_Usuario = Convert.ToInt16(items[0]);

                    if (con.Sel_Abert_Caixa_Dados_Sang(Sang) != null)
                    {
                        return con.Sel_Abert_Caixa_Dados_Sang(Sang).Rows.Count.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
            }
        }

        public static string Sel_Abert_Caixa_Dados_Sup_Qtdeg(string data, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Sangria_Suprimento Sang = new Sangria_Suprimento())
                {
                    Sang.Data = data.Replace('/', '.');
                    //
                    Sang.Cod_PDV_Computador = Convert.ToInt16(cod_pdv_computador);
                    //
                    string[] items = usuario.Split('-');
                    Sang.Cod_Usuario = Convert.ToInt16(items[0]);

                    if (con.Sel_Abert_Caixa_Dados_Sup(Sang) != null)
                    {
                        return con.Sel_Abert_Caixa_Dados_Sup(Sang).Rows.Count.ToString();
                    }
                    else
                    {
                        return "0";
                    }
                }
            }
        }

        public static string Sel_Abert_Caixa_Dados_Sang(string data, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Sangria_Suprimento Sang = new Sangria_Suprimento())
                {
                    Sang.Data = data.Replace('/', '.');
                    //
                    Sang.Cod_PDV_Computador = Convert.ToInt16(cod_pdv_computador);
                    //
                    string[] items = usuario.Split('-');
                    Sang.Cod_Usuario = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Abert_Caixa_Dados_Sang(Sang) != null)
                    {
                        decimal valor = 0;
                        //
                        for (int i = 0; i < con.Sel_Abert_Caixa_Dados_Sang(Sang).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_Abert_Caixa_Dados_Sang(Sang).Rows[i];

                            valor += Convert.ToDecimal(dr[0]);
                        }
                        //
                        return valor.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public static string Sel_Abert_Caixa_Dados_Sup(string data, string cod_pdv_computador, string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Sangria_Suprimento Sang = new Sangria_Suprimento())
                {
                    Sang.Data = data.Replace('/', '.');
                    //
                    Sang.Cod_PDV_Computador = Convert.ToInt16(cod_pdv_computador);
                    //
                    string[] items = usuario.Split('-');
                    Sang.Cod_Usuario = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Abert_Caixa_Dados_Sup(Sang) != null)
                    {
                        decimal valor = 0;
                        //
                        for (int i = 0; i < con.Sel_Abert_Caixa_Dados_Sup(Sang).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_Abert_Caixa_Dados_Sup(Sang).Rows[i];

                            valor += Convert.ToDecimal(dr[0]);
                        }
                        //
                        return valor.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public static DataTable Sel_Usuario_Sangria_Suprimento()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Usuario_Fluxo_Caixa();
            }
        }

        public static DataTable Sel_Cod_PDV_Sangria_Suprimento()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cod_PDV_Sangria_Suprimento();
            }
        }

        public static DataTable Sel_Codigo_Sang_Sup(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Sangria_Suprimento SangSup = new Sangria_Suprimento())
                {
                    SangSup.Pesquisar = pesquisar;
                    return con.Sel_Codigo_Sang_Sup(SangSup);
                }
            }
        }

        public static DataTable Sel_Data_Sang_Sup(string data_inicio, string data_fim, string hora_inicio, string hora_fim, string usuario, string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                string[] items;
                //
                string SqlData;
                string SqlUsuario;
                string SqlCodPdvComputador;
                //
                if (data_inicio.Contains("_") || data_fim.Contains("_"))
                {
                    SqlData = "WHERE data BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = "";
                    }
                    else
                    {
                        hora_inicio = " " + hora_inicio;
                    }
                    //
                    if (hora_fim.Contains("_"))
                    {
                        hora_fim = " 23:59:59";
                    }
                    else
                    {
                        hora_fim = " " + hora_fim;
                    }
                    //
                    SqlData = "WHERE data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                }
                //
                if (usuario == "")
                {
                    SqlUsuario = "";
                }
                else
                {
                    items = usuario.Split('—');
                    SqlUsuario = " AND id_usuario=" + items[0];
                }
                //
                if (cod_pdv_computador == "")
                {
                    SqlCodPdvComputador = "";
                }
                else
                {
                    SqlCodPdvComputador = " AND id_pdv_computador=" + cod_pdv_computador;
                }
                //
                return con.Sel_Data_Sang_Sup(SqlData, SqlUsuario, SqlCodPdvComputador);
            }
        }

        public static bool Sel_SangriaSuprimento_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Sangria_Suprimento SangSup = new Sangria_Suprimento())
                {
                    SangSup.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_SangriaSuprimento_Ainda_Existe(SangSup);
                }
            }
        }

        public static DataTable Sel_Descricao_Sang_Sup(string descricao, string data_inicio, string data_fim, string hora_inicio, string hora_fim, string usuario, string cod_pdv_computador)
        {
            using (Con7BD con = new Con7BD())
            {
                string[] items;
                //
                string SqlDescricao;
                string SqlData;
                string SqlUsuario;
                string SqlCodPdvComputador;
                //
                if (descricao.Contains("%"))
                {
                    SqlDescricao = "WHERE descricao LIKE '" + descricao + "'";
                }
                else
                {
                    SqlDescricao = "WHERE descricao STARTING WITH '" + descricao + "'";
                }
                //
                if (data_inicio.Contains("_") || data_fim.Contains("_"))
                {
                    SqlData = "";
                }
                else
                {
                    if (hora_inicio.Contains("_"))
                    {
                        hora_inicio = "";
                    }
                    else
                    {
                        hora_inicio = " " + hora_inicio;
                    }
                    //
                    if (hora_fim.Contains("_"))
                    {
                        hora_fim = " 23:59:59";
                    }
                    else
                    {
                        hora_fim = " " + hora_fim;
                    }
                    //
                    SqlData = " AND data BETWEEN '" + data_inicio.Replace("/", ".") + hora_inicio + "' AND '" + data_fim.Replace("/", ".") + hora_fim + "'";
                }
                //
                if (usuario == "")
                {
                    SqlUsuario = "";
                }
                else
                {
                    items = usuario.Split('—');
                    SqlUsuario = " AND id_usuario=" + items[0];
                }
                //
                if (cod_pdv_computador == "")
                {
                    SqlCodPdvComputador = "";
                }
                else
                {
                    SqlCodPdvComputador = " AND id_pdv_computador=" + cod_pdv_computador;
                }
                //
                return con.Sel_Descricao_Sang_Sup(SqlDescricao, SqlData, SqlUsuario, SqlCodPdvComputador);
            }
        }

        public static string GerarCupom(byte trabalho, string codigo) 
        {
            if (trabalho == 0)
            {
                using (var doc = new PdfDocument())
                {
                    DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep;
                    byte pessoa;
                    //
                    nome = drPDF["nome"].ToString();
                    fantasia = drPDF["fantasia"].ToString();
                    cpf_cnpj = drPDF["cpf_cnpj"].ToString();
                    ie_rg = drPDF["ie_rg"].ToString();
                    endereco = drPDF["endereco"].ToString();
                    numero = drPDF["numero"].ToString();
                    bairro = drPDF["bairro"].ToString();
                    cidade = drPDF["cidade"].ToString();
                    uf = drPDF["uf"].ToString();
                    cep = drPDF["cep"].ToString();
                    pessoa = Convert.ToByte(drPDF["pessoa"]);
                    //
                    var page = doc.AddPage();
                    //
                    page.Width = 203;
                    page.Height = 842;
                    //                       
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    var textFormatter4 = new XTextFormatter(graphics);
                    //
                    var fonte1 = new XFont("Courrier Regular", 7, XFontStyle.Bold);
                    var fonte2 = new XFont("Courrier New", 7, XFontStyle.Regular);
                    var fonte3 = new XFont("Courrier New", 6, XFontStyle.Regular);
                    var fonte4 = new XFont("Courrier Regular", 5, XFontStyle.Italic);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter2.Alignment = XParagraphAlignment.Left;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    XPen pen1 = new XPen(XColors.AntiqueWhite);
                    XPen pen = new XPen(XColors.Black);
                    //
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                    //
                    StringFormat Sf1 = new StringFormat();
                    Sf1.Alignment = StringAlignment.Near;
                    //
                    StringFormat Sf2 = new StringFormat();
                    Sf2.Alignment = StringAlignment.Far;
                    //
                    int AumentoDeLinhaFixo = 0;
                    //
                    if (bllSangriaSuprimento._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 72 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                    }
                    //
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, 85 + Margem_Topo, 198, 16);
                    if (nome.Length > 30)
                    {
                        if (!nome.Substring(0, 30).Contains(" ") || (!nome.Substring(30).Contains(" ") & nome.Substring(30).Length > 15))
                        {
                            textFormatter1.DrawString(nome.Insert(30, Environment.NewLine), fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 16));
                        }
                        else
                        {
                            textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 16));
                        }
                        AumentoDeLinhaFixo = AumentoDeLinhaFixo + 8;
                    }
                    else
                    {
                        textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 198, 8));
                    }
                    //
                    if (fantasia.Length > 30)
                    {
                        if (!fantasia.Substring(0, 30).Contains(" ") || !fantasia.Substring(30).Contains(" "))
                        {
                            textFormatter1.DrawString(fantasia.Insert(30, Environment.NewLine), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 93 + Margem_Topo, 198, 16));
                        }
                        else
                        {
                            textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 93 + Margem_Topo, 198, 16));
                        }
                        AumentoDeLinhaFixo = AumentoDeLinhaFixo + 8;
                    }
                    else
                    {
                        textFormatter1.DrawString(fantasia, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 93 + Margem_Topo, 198, 8));
                    }
                    //
                    if (pessoa == 1)
                    {
                        textFormatter1.DrawString("CNPJ: " + cpf_cnpj + " IE: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 101 + Margem_Topo, 198, 8));
                    }
                    else
                    {
                        textFormatter1.DrawString("CPF: " + cpf_cnpj + " RG: " + ie_rg, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 101 + Margem_Topo, 198, 8));
                    }
                    //
                    //graphics.DrawRectangle(pen, 2 + Margem_Esq, AumentoDeLinhaFixo + 109 + Margem_Topo, 198, 40);
                    textFormatter1.DrawString(endereco + ", " + numero + ", " + bairro + ", " + cidade + ", " + uf + ", " + cep, fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 109 + Margem_Topo, 198, 40));
                    //
                    //graphics.DrawRectangle(pen, 0 + Margem_Esq, 133 + AumentoDeLinhaFixo + Margem_Topo, 198, 24);
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 144 + AumentoDeLinhaFixo + Margem_Topo, 198, 24));
                    textFormatter1.DrawString("SANGRIA/SUPRIMENTO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 150 + AumentoDeLinhaFixo + Margem_Topo, 198, 24));
                    textFormatter2.DrawString("---------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 155 + AumentoDeLinhaFixo + Margem_Topo, 198, 24));
                    //
                    DataRow dr = Sel_Codigo_Sang_Sup(codigo).Rows[0];
                    //
                    textFormatter2.DrawString("Código: " + dr["id_sang_sup"].ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 160 + Margem_Topo, 198, 7));
                    //  
                    textFormatter2.DrawString("Tipo: " + dr["tipo"].ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 168 + Margem_Topo, 198, 7));
                    //     
                    if (dr["descricao"].ToString().Length > 40)
                    {
                        textFormatter2.DrawString("Descrição: " + dr["descricao"].ToString().Insert(40, Environment.NewLine), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 176 + Margem_Topo, 198, 14));
                        AumentoDeLinhaFixo = AumentoDeLinhaFixo + 8;
                    }
                    else
                    {
                        textFormatter2.DrawString("Descrição: " + dr["descricao"].ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 176 + Margem_Topo, 198, 7));
                    }
                    //
                    textFormatter2.DrawString("Valor (R$): " + Convert.ToDecimal(dr["valor"]).ToString("n2", new CultureInfo("pt-BR")), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 184 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Data: " + dr["data"].ToString().Remove(10), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 192 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Horário: " + dr["hora"].ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 200 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Usuário(a): " + dr["id_usuario"].ToString() + "-" + dr["nome_usuario"].ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 208 + Margem_Topo, 198, 7));
                    //
                    textFormatter2.DrawString("Nº do PDV: " + dr["id_pdv_computador"].ToString(), fonte3, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 216 + Margem_Topo, 198, 7));
                    //
                    textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, AumentoDeLinhaFixo + 232 + Margem_Topo, 198, 16));
                    //
                    PdfSecuritySettings security = doc.SecuritySettings;
                    //
                    security.PermitAccessibilityExtractContent = false;
                    security.PermitAnnotations = false;
                    security.PermitAssembleDocument = false;
                    security.PermitExtractContent = false;
                    security.PermitFormsFill = true;
                    security.PermitFullQualityPrint = false;
                    security.PermitModifyDocument = false;
                    security.PermitPrint = true;
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento");
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\" + codigo + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\" + codigo + ".pdf");
                    }
                }
            }
            else if (trabalho == 1)
            {
                using (var doc = new PdfDocument())
                {
                    DataRow drPDF = bllMinhaEmpresa.Sel_Dados_Minha_Empresa().Rows[0];
                    //
                    string nome, fantasia, cpf_cnpj, ie_rg, endereco, numero, bairro, cidade, uf, cep;
                    byte pessoa;
                    //
                    nome = drPDF["nome"].ToString();
                    fantasia = drPDF["fantasia"].ToString();
                    cpf_cnpj = drPDF["cpf_cnpj"].ToString();
                    ie_rg = drPDF["ie_rg"].ToString();
                    endereco = drPDF["endereco"].ToString();
                    numero = drPDF["numero"].ToString();
                    bairro = drPDF["bairro"].ToString();
                    cidade = drPDF["cidade"].ToString();
                    uf = drPDF["uf"].ToString();
                    cep = drPDF["cep"].ToString();
                    pessoa = Convert.ToByte(drPDF["pessoa"]);
                    //
                    var page = doc.AddPage();
                    //
                    page.Width = 595;
                    page.Height = 842;
                    //
                    var graphics = XGraphics.FromPdfPage(page);
                    var textFormatter1 = new XTextFormatter(graphics);
                    var textFormatter2 = new XTextFormatter(graphics);
                    var textFormatter3 = new XTextFormatter(graphics);
                    //
                    var fonte1 = new XFont("Microsoft Sans Serif", 12, XFontStyle.Bold);
                    var fonte2 = new XFont("Microsoft Sans Serif", 12);
                    var fonte4 = new XFont("Microsoft Sans Serif", 10, XFontStyle.Italic);
                    //
                    textFormatter1.Alignment = XParagraphAlignment.Center;
                    textFormatter2.Alignment = XParagraphAlignment.Left;
                    textFormatter3.Alignment = XParagraphAlignment.Right;
                    //
                    XPen pen1 = new XPen(XColors.AntiqueWhite);
                    XPen pen = new XPen(XColors.Black);
                    //
                    int Margem_Esq = bllConfiguracaoSistema.Sel_Margem_Esq_Pdv_PDF(bllConexao._Codigo_Conexao);
                    int Margem_Topo = bllConfiguracaoSistema.Sel_Margem_Topo_Pdv_PDF(bllConexao._Codigo_Conexao);
                    //
                    StringFormat Sf1 = new StringFormat();
                    Sf1.Alignment = StringAlignment.Near;
                    //
                    StringFormat Sf2 = new StringFormat();
                    Sf2.Alignment = StringAlignment.Far;
                    //                                   
                    if (bllSangriaSuprimento._Mostrar_Logo_Marca_Imp == true & bllMinhaEmpresa.Sel_Imagem_Logo_Empresa() != "")
                    {
                        XImage imagem1 = XImage.FromFile(bllMinhaEmpresa.Sel_Imagem_Logo_Empresa());
                        graphics.DrawImage(imagem1, 280 + Margem_Esq, 1 + Margem_Topo, 58, 69);
                    }
                    else
                    {
                        Margem_Topo = Convert.ToInt16(Margem_Topo - 69);
                    }
                    //
                    textFormatter1.DrawString(nome, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 85 + Margem_Topo, 595, 13));
                    //
                    textFormatter1.DrawString(fantasia, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 98 + Margem_Topo, 595, 13));
                    //
                    if (pessoa == 1)
                    {
                        textFormatter1.DrawString("CNPJ: " + cpf_cnpj + " IE: " + ie_rg, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 111 + Margem_Topo, 595, 13));
                    }
                    else
                    {
                        textFormatter1.DrawString("CPF: " + cpf_cnpj + " RG: " + ie_rg, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 111 + Margem_Topo, 595, 13));
                    }
                    //
                    textFormatter1.DrawString(endereco + ", " + numero + Environment.NewLine + bairro + Environment.NewLine + cidade + ", " + uf + ", " + cep, fonte1, XBrushes.Black, new XRect(2 + Margem_Esq, 124 + Margem_Topo, 595, 45));
                    //
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 160 + Margem_Topo, 595, 24));
                    textFormatter1.DrawString("SANGRIA/SUPRIMENTO", fonte1, XBrushes.Black, new XRect(5 + Margem_Esq, 169 + Margem_Topo, 595, 13));
                    textFormatter2.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", fonte2, XBrushes.Black, new XRect(0 + Margem_Esq, 175 + Margem_Topo, 595, 24));
                    //
                    //
                    int Incrementar = 0;
                    DataRow dr = Sel_Codigo_Sang_Sup(codigo).Rows[0];
                    //
                    textFormatter2.DrawString("Código: " + dr["id_sang_sup"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 185 + Margem_Topo, 595, 13));
                    //
                    textFormatter2.DrawString("Tipo: " + dr["tipo"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 199 + Margem_Topo, 595, 13));
                    //  
                    textFormatter2.DrawString("Descrição: " + dr["descricao"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 213 + Margem_Topo, 595, 13));
                    //
                    textFormatter2.DrawString("Valor (R$): " + Convert.ToDecimal(dr["valor"]).ToString("n2", new CultureInfo("pt-BR")), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 227 + Margem_Topo, 595, 13)); Incrementar = Incrementar + 26;
                    //
                    textFormatter2.DrawString("Data: " + dr["data"].ToString().Remove(10), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 241 + Margem_Topo, 595, 13));
                    //
                    textFormatter2.DrawString("Horário: " + dr["hora"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 255 + Margem_Topo, 595, 13));
                    //
                    textFormatter2.DrawString("Usuário(a): " + dr["id_usuario"].ToString() + "-" + dr["nome_usuario"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 269 + Margem_Topo, 595, 13));
                    //
                    textFormatter2.DrawString("Nº do PDV: " + dr["id_pdv_computador"].ToString(), fonte2, XBrushes.Black, new XRect(2 + Margem_Esq, 283 + Margem_Topo, 595, 13));
                    //
                    textFormatter3.DrawString("Sistema SEVEN", fonte4, XBrushes.Black, new XRect(2 + Margem_Esq, Incrementar + 309 + Margem_Topo, 585, 11));
                    //
                    PdfSecuritySettings security = doc.SecuritySettings;
                    //
                    security.PermitAccessibilityExtractContent = false;
                    security.PermitAnnotations = false;
                    security.PermitAssembleDocument = false;
                    security.PermitExtractContent = false;
                    security.PermitFormsFill = true;
                    security.PermitFullQualityPrint = false;
                    security.PermitModifyDocument = false;
                    security.PermitPrint = true;
                    //
                    if (!Directory.Exists(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento"))
                    {
                        Directory.CreateDirectory(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento");
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\" + codigo + ".pdf");
                    }
                    else
                    {
                        doc.Save(@"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\" + codigo + ".pdf");
                    }                   
                }
            }
            //
            return @"C:\Sistema SEVEN\Documentos\" + bllMinhaEmpresa.Sel_Empresa_CPFCNPJ().Replace(".", "").Replace("/", "").Replace("-", "") + @"\SangriaSuprimento\" + codigo + ".pdf";
        } 
    }
}
