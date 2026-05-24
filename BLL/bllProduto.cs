using DAL;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Threading;

namespace BLL
{
    public class bllProduto
    {
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static string _Url_Imagem;
        public static string _Nome_Arquivo;
        public static bool _Mostrar_Imagem;
        public static bool _Excluir_Imagem;

        public static bool _FrmCadProduto_Ativo;
        public static bool _FrmRelProduto_Ativo;
        public static bool _FrmRelSaldoAtualEstoque_Ativo;      
        public static bool _FrmRelContagemInv_Ativo;
        public static string _Grupo_PesqGrupo_Tabela;
        public static string _Localizacao_PesqLocalizacao_Tabela;
        public static string _SubGrupo_PesqSubGrupo_Tabela;
        public static string _Marca_PesqMarca_Tabela;
        public static string _Preco_Venda;
        public static string _Fornecedor_PesqFornecedor_Tabela;
        public static string _NCM_PesqNCM_Tabela;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Cod_Produto_Cadastro;

        public static void Salvar(string palavra_chave, string descricao, string um, string marca, string grupo, string subgrupo, string cod_barra, string preco, string referencia, string localizacao, string observacao, string imagem_prod, string estoque_min, string estoque_max, string saldo_adicionado, string acrescimo_porc, string desconto_porc, bool alertar_estoque, bool destacar_est_vaixo, string ncm, string cest, string cst, string aliquota, string csosn, bool importado_dfe, string excecao_ncm, string cst_ibs_cbs, string cclass_trib, string aliq_ibs_mun, string aliq_ibs_est, string aliq_cbs, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Data_Cadastro = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + "'";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Prod.Palavra_Chave = "null";
                    }
                    else
                    {
                        Prod.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    Prod.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (um == "UNID" || um == "UND")
                    {
                        Prod.UM = "'UN'";
                    }
                    else if (um == "PCT")
                    {
                        Prod.UM = "'PC'";
                    }
                    else
                    {
                        Prod.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    }
                    //
                    string[] items;
                    //
                    if (marca == "" || marca == null)
                    {
                        Prod.Cod_Marca = 0;
                        Prod.Desc_Marca = "null";
                    }
                    else
                    {
                        items = marca.Split('—');
                        Prod.Cod_Marca = Convert.ToInt16(items[0]);
                        Prod.Desc_Marca = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    items = grupo.Split('—');
                    //
                    Prod.Cod_Grupo = Convert.ToInt16(items[0]);
                    Prod.Desc_Grupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = subgrupo.Split('—');
                    //
                    Prod.Cod_SubGrupo = Convert.ToInt16(items[0]);
                    Prod.Desc_SubGrupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    if (cod_barra == "" || cod_barra == null)
                    {
                        Prod.Cod_Barra = "null";
                    }
                    else
                    {
                        Prod.Cod_Barra = cod_barra.Insert(cod_barra.Length, "'").Insert(0, "'");
                    }
                    //
                    if (preco.Contains("."))
                    {
                        Prod.Preco = Convert.ToDecimal(preco.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prod.Preco = Convert.ToDecimal(preco.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (estoque_min == "" || estoque_min == null)
                    {
                        Prod.Estoque_Min = 0;
                    }
                    else
                    {
                        if (estoque_min.Contains("."))
                        {
                            Prod.Estoque_Min = Convert.ToDecimal(estoque_min.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prod.Estoque_Min = Convert.ToDecimal(estoque_min.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    if (saldo_adicionado == "" || saldo_adicionado == null)
                    {
                        Prod.Saldo_Atual = 0;
                    }
                    else
                    {
                        if (saldo_adicionado.Contains("."))
                        {
                            Prod.Saldo_Atual = Convert.ToDecimal(saldo_adicionado.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prod.Saldo_Atual = Convert.ToDecimal(saldo_adicionado.Replace(",", "."));
                        }
                    }
                    //
                    if (estoque_max == "" || estoque_max == null)
                    {
                        Prod.Estoque_Max = 0;
                    }
                    else
                    {
                        if (estoque_max.Contains("."))
                        {
                            Prod.Estoque_Max = Convert.ToDecimal(estoque_max.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prod.Estoque_Max = Convert.ToDecimal(estoque_max.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    if (observacao == "" || observacao == null)
                    {
                        Prod.Observacao = "null";
                    }
                    else
                    {
                        Prod.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (referencia == "" || referencia == null)
                    {
                        Prod.Referencia = "null";
                    }
                    else
                    {
                        Prod.Referencia = referencia.Insert(referencia.Length, "'").Insert(0, "'");
                    }
                    //
                    if (localizacao == "" || localizacao == null)
                    {
                        Prod.Cod_Localizacao = 0;
                        Prod.Desc_Localizacao = "null";
                    }
                    else
                    {
                        items = localizacao.Split('—');
                        Prod.Cod_Localizacao = Convert.ToInt16(items[0]);
                        Prod.Desc_Localizacao = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    if (acrescimo_porc == "" || desconto_porc == null)
                    {
                        Prod.Acrescimo_Porc = 0;
                    }
                    else
                    {
                        if (acrescimo_porc.Contains("."))
                        {
                            Prod.Acrescimo_Porc = Convert.ToDecimal(acrescimo_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prod.Acrescimo_Porc = Convert.ToDecimal(acrescimo_porc.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }
                    //
                    if (desconto_porc == "" || desconto_porc == null)
                    {
                        Prod.Desconto_Porc = 0;
                    }
                    else
                    {
                        if (desconto_porc.Contains("."))
                        {
                            Prod.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prod.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                        }
                    }                    
                    //
                    if (alertar_estoque == true)
                    {
                        Prod.Alertar_Estoque = 1;
                    }
                    else
                    {
                        Prod.Alertar_Estoque = 0;
                    }
                    //
                    if (destacar_est_vaixo == true)
                    {
                        Prod.Dest_Est_Baixo = 1;
                    }
                    else
                    {
                        Prod.Dest_Est_Baixo = 0;
                    }
                    //
                    if (ncm == "" || ncm == null)
                    {
                        Prod.NCM = "null";
                    }
                    else
                    {
                        Prod.NCM = ncm.Insert(ncm.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cst == "" || cst == null)
                    {
                        Prod.CST = "null";
                    }
                    else
                    {
                        Prod.CST = cst.Insert(cst.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cest == "" || cest == null)
                    {
                        Prod.CEST = "null";
                    }
                    else
                    {
                        Prod.CEST = cest.Insert(cest.Length, "'").Insert(0, "'");
                    }
                    //
                    if (aliquota == "" || aliquota == null)
                    {
                        Prod.Aliquota = 0;
                    }
                    else
                    {
                        if (aliquota.Contains("."))
                        {
                            Prod.Aliquota = Convert.ToDecimal(aliquota.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prod.Aliquota = Convert.ToDecimal(aliquota.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    if (csosn == "" || csosn == null)
                    {
                        Prod.CSOSN = "null";
                    }
                    else
                    {
                        Prod.CSOSN = csosn.Insert(csosn.Length, "'").Insert(0, "'");
                    }
                    //
                    if (importado_dfe == true)
                    {
                        Prod.Importado_DFe = 1;
                    }
                    else
                    {
                        Prod.Importado_DFe = 0;
                    }
                    //
                    if (excecao_ncm == "" || excecao_ncm == null)
                    {
                        Prod.Excecao_NCM = "null";
                    }
                    else
                    {
                        Prod.Excecao_NCM = excecao_ncm.Insert(excecao_ncm.Length, "'").Insert(0, "'");
                    }
                    //
                    if (imagem_prod != null)
                    {
                        Image original = Image.FromFile(imagem_prod);
                        //
                        Image redimensionada = RedimensionarImagem.Redimensionar(original, 225, 225);
                        //
                        byte[] imagemBytes;
                        //
                        using (MemoryStream ms = new MemoryStream())
                        {
                            redimensionada.Save(ms, ImageFormat.Jpeg); // ou PNG, se preferir
                            imagemBytes = ms.ToArray();
                        }
                        //
                        Prod.Imagem_Prod = imagemBytes;
                    }
                    //
                    Prod.CST_IBS_CBS = cst_ibs_cbs.Insert(cst_ibs_cbs.Length, "'").Insert(0, "'");
                    //
                    Prod.CClass_Trib = cclass_trib.Insert(cclass_trib.Length, "'").Insert(0, "'");
                    //
                    if (aliq_ibs_mun.Contains("."))
                    {
                        Prod.Aliq_IBS_Mun = Convert.ToDecimal(aliq_ibs_mun.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prod.Aliq_IBS_Mun = Convert.ToDecimal(aliq_ibs_mun.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (aliq_ibs_est.Contains("."))
                    {
                        Prod.Aliq_IBS_Est = Convert.ToDecimal(aliq_ibs_est.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prod.Aliq_IBS_Est = Convert.ToDecimal(aliq_ibs_est.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (aliq_cbs.Contains("."))
                    {
                        Prod.Aliq_CBS = Convert.ToDecimal(aliq_cbs.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prod.Aliq_CBS = Convert.ToDecimal(aliq_cbs.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    Prod.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    //
                    con.Salvar_Produto(Prod);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar_Imagem_Produto(string codigo, string imagem_prod)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    //
                    bool nulo;
                    if (imagem_prod != null)
                    {
                        Image original = Image.FromFile(imagem_prod);
                        //
                        Image redimensionada = RedimensionarImagem.Redimensionar(original, 225, 225);
                        //
                        byte[] imagemBytes;
                        //
                        using (MemoryStream ms = new MemoryStream())
                        {
                            redimensionada.Save(ms, ImageFormat.Jpeg); // ou PNG, se preferir
                            imagemBytes = ms.ToArray();
                        }
                        //
                        Prod.Imagem_Prod = imagemBytes;
                        //
                        nulo = false;
                    }
                    else
                    {
                        nulo = true;
                    }
                    //
                    con.Alterar_Imagem_Produto(Prod, nulo);
                }
            }
        }


        public static int Sel_Prod_Ultimo_Cod_Adicionado()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Prod_Ultimo_Cod_Adicionado();
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Produto(Prod);
                }
            }
        }

        public static void Alterar(string codigo, string palavra_chave, string descricao, string um, string marca, string grupo, string subgrupo, string cod_barra, string preco, string referencia, string localizacao, string observacao, string estoque_min, string estoque_max, string saldo_adicionado, string acrescimo_porc, string desconto_porc, bool alertar_estoque, bool destacar_est_vazio, string cod_pdv_computador, string ncm, string cest, string cst, string aliquota, string csosn, string excecao_ncm, string cst_ibs_cbs, string cclass_trib, string aliq_ibs_mun, string aliq_ibs_est, string aliq_cbs, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Prod.Codigo = Convert.ToInt32(codigo);
                    //
                    if (palavra_chave == "" || palavra_chave == null)
                    {
                        Prod.Palavra_Chave = "null";
                    }
                    else
                    {
                        Prod.Palavra_Chave = palavra_chave.Insert(palavra_chave.Length, "'").Insert(0, "'");
                    }
                    //
                    Prod.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    Prod.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    string[] items;
                    if (marca == "")
                    {
                        Prod.Cod_Marca = 0;
                        Prod.Desc_Marca = "null";
                    }
                    else
                    {
                        items = marca.Split('—');
                        Prod.Cod_Marca = Convert.ToInt16(items[0]);
                        Prod.Desc_Marca = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    items = grupo.Split('—');
                    //
                    Prod.Cod_Grupo = Convert.ToInt16(items[0]);
                    Prod.Desc_Grupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = subgrupo.Split('—');
                    Prod.Cod_SubGrupo = Convert.ToInt16(items[0]);
                    Prod.Desc_SubGrupo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    if (cod_barra == "" || cod_barra == null)
                    {
                        Prod.Cod_Barra = "null";
                    }
                    else
                    {
                        Prod.Cod_Barra = cod_barra.Insert(cod_barra.Length, "'").Insert(0, "'");
                    }
                    //
                    if (preco.Contains("."))
                    {
                        Prod.Preco = Convert.ToDecimal(preco.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prod.Preco = Convert.ToDecimal(preco.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (localizacao == "" || localizacao == null)
                    {
                        Prod.Cod_Localizacao = 0;
                        Prod.Desc_Localizacao = "null";
                    }
                    else
                    {
                        items = localizacao.Split('—');
                        Prod.Cod_Localizacao = Convert.ToInt16(items[0]);
                        Prod.Desc_Localizacao = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    if (estoque_min == "" || estoque_min == null)
                    {
                        Prod.Estoque_Min = 0;
                    }
                    else
                    {
                        if (estoque_min.Contains("."))
                        {
                            Prod.Estoque_Min = Convert.ToDecimal(estoque_min.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prod.Estoque_Min = Convert.ToDecimal(estoque_min.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    if (saldo_adicionado == "" || saldo_adicionado == null)
                    {
                        Prod.Saldo_Atual = con.Sel_Saldo_Atual_Produto(Prod);
                    }
                    else
                    {
                        //                        
                        if (saldo_adicionado.Contains("."))
                        {
                            Prod.Saldo_Atual = Convert.ToDecimal(con.Sel_Saldo_Atual_Produto(Prod) + Convert.ToDecimal(saldo_adicionado.Replace(".", "").Replace(",", ".")));
                        }
                        else
                        {
                            Prod.Saldo_Atual = Convert.ToDecimal(con.Sel_Saldo_Atual_Produto(Prod) + Convert.ToDecimal(saldo_adicionado.Replace(",", ".").Replace(";", "")));
                        }
                    }
                    //
                    if (estoque_max == "" || estoque_max == null)
                    {
                        Prod.Estoque_Max = 0;
                    }
                    else
                    {
                        if (estoque_max.Contains("."))
                        {
                            Prod.Estoque_Max = Convert.ToDecimal(estoque_max.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prod.Estoque_Max = Convert.ToDecimal(estoque_max.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    if (observacao == "" || observacao == null)
                    {
                        Prod.Observacao = "null";
                    }
                    else
                    {
                        Prod.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (referencia == "" || referencia == null)
                    {
                        Prod.Referencia = "null";
                    }
                    else
                    {
                        Prod.Referencia = referencia.Insert(referencia.Length, "'").Insert(0, "'");
                    }
                    //  
                    if (acrescimo_porc.Contains("."))
                    {
                        Prod.Acrescimo_Porc = Convert.ToDecimal(acrescimo_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prod.Acrescimo_Porc = Convert.ToDecimal(acrescimo_porc.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (desconto_porc.Contains("."))
                    {
                        Prod.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prod.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (alertar_estoque == true)
                    {
                        Prod.Alertar_Estoque = 1;
                    }
                    else
                    {
                        Prod.Alertar_Estoque = 0;
                    }
                    //
                    if (destacar_est_vazio == true)
                    {
                        Prod.Dest_Est_Baixo = 1;
                    }
                    else
                    {
                        Prod.Dest_Est_Baixo = 0;
                    }
                    //
                    if (ncm == "" || ncm == null)
                    {
                        Prod.NCM = "null";
                    }
                    else
                    {
                        Prod.NCM = ncm.Insert(ncm.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cst == "" || cst == null)
                    {
                        Prod.CST = "null";
                    }
                    else
                    {
                        Prod.CST = cst.Insert(cst.Length, "'").Insert(0, "'");
                    }
                    //
                    if (cest == "" || cest == null)
                    {
                        Prod.CEST = "null";
                    }
                    else
                    {
                        Prod.CEST = cest.Insert(cest.Length, "'").Insert(0, "'");
                    }
                    //
                    if (aliquota == "" || aliquota == null)
                    {
                        Prod.Aliquota = 0;
                    }
                    else
                    {
                        if (aliquota.Contains("."))
                        {
                            Prod.Aliquota = Convert.ToDecimal(aliquota.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prod.Aliquota = Convert.ToDecimal(aliquota.Replace(",", ".").Replace(";", ""));
                        }
                    }
                    //
                    if (csosn == "" || csosn == null)
                    {
                        Prod.CSOSN = "null";
                    }
                    else
                    {
                        Prod.CSOSN = csosn.Insert(csosn.Length, "'").Insert(0, "'");
                    }
                    //
                    if (excecao_ncm == "" || excecao_ncm == null)
                    {
                        Prod.Excecao_NCM = "null";
                    }
                    else
                    {
                        Prod.Excecao_NCM = excecao_ncm.Insert(excecao_ncm.Length, "'").Insert(0, "'");
                    }
                    //
                    Prod.CST_IBS_CBS = cst_ibs_cbs.Insert(cst_ibs_cbs.Length, "'").Insert(0, "'");
                    //
                    Prod.CClass_Trib = cclass_trib.Insert(cclass_trib.Length, "'").Insert(0, "'");
                    //
                    if (aliq_ibs_mun.Contains("."))
                    {
                        Prod.Aliq_IBS_Mun = Convert.ToDecimal(aliq_ibs_mun.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prod.Aliq_IBS_Mun = Convert.ToDecimal(aliq_ibs_mun.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (aliq_ibs_est.Contains("."))
                    {
                        Prod.Aliq_IBS_Est = Convert.ToDecimal(aliq_ibs_est.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prod.Aliq_IBS_Est = Convert.ToDecimal(aliq_ibs_est.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (aliq_cbs.Contains("."))
                    {
                        Prod.Aliq_CBS = Convert.ToDecimal(aliq_cbs.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prod.Aliq_CBS = Convert.ToDecimal(aliq_cbs.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    Prod.Data_Ult_Alteracao = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Prod.Situacao = situacao.Insert(situacao.Length, "'").Insert(0, "'");
                    //
                    con.Alterar_Produto(Prod);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Adicionar_Saldo_Produto(string codigo, string saldo_adicionado)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Prod.Codigo = Convert.ToInt32(codigo);
                    //
                    if (saldo_adicionado == "" || saldo_adicionado == null)
                    {
                        Prod.Saldo_Atual = con.Sel_Saldo_Atual_Produto(Prod);
                    }
                    else
                    {
                        if (saldo_adicionado.Contains("."))
                        {
                            Prod.Saldo_Atual = Convert.ToDecimal(con.Sel_Saldo_Atual_Produto(Prod) + Convert.ToDecimal(saldo_adicionado.Replace(".", "").Replace(",", ".")));
                        }
                        else
                        {
                            Prod.Saldo_Atual = Convert.ToDecimal(con.Sel_Saldo_Atual_Produto(Prod) + Convert.ToDecimal(saldo_adicionado.Replace(",", ".").Replace(";", "")));
                        }
                    }
                    //
                    con.Adicionar_Saldo_Produto(Prod);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Adicionar_Saldo_Preco_Produto(string codigo, string saldo_adicionado, string preco)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Prod.Codigo = Convert.ToInt32(codigo);
                    //
                    if (preco.Contains("."))
                    {
                        Prod.Preco = Convert.ToDecimal(preco.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Prod.Preco = Convert.ToDecimal(preco.Replace(",", ".").Replace(";", "").Replace("'", "").Replace("'", "").Replace("=", ""));
                    }
                    //
                    if (saldo_adicionado == "" || saldo_adicionado == null)
                    {
                        Prod.Saldo_Atual = con.Sel_Saldo_Atual_Produto(Prod);
                    }
                    else
                    {
                        if (saldo_adicionado.Contains("."))
                        {
                            Prod.Saldo_Atual = Convert.ToDecimal(con.Sel_Saldo_Atual_Produto(Prod) + Convert.ToDecimal(saldo_adicionado.Replace(".", "").Replace(",", ".")));
                        }
                        else
                        {
                            Prod.Saldo_Atual = Convert.ToDecimal(con.Sel_Saldo_Atual_Produto(Prod) + Convert.ToDecimal(saldo_adicionado.Replace(",", ".").Replace(";", "")));
                        }
                    }
                    //
                    con.Adicionar_Saldo_Preco_Produto(Prod);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Grupo_Prod()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Grupo_Prod();
            }
        }

        public static DataTable Sel_Marca_Prod()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Marca_Prod();
            }
        }

        public static DataTable Sel_Localizacao_Prod()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Localizacao_Prod();
            }
        }

        public static DataTable Sel_SubGrupo_Prod(string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    string[] items = cbbgrupo.Split('—');
                    Prod.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_SubGrupo_Prod(Prod);
                }
            }
        }

        public static void Excluir_Entrada_Produto_Prod(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Entrada_Produto_Prod(Prod);
                }
            }
        }

        public static void Excluir_Validade_Prod(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Validade_Prod(Prod);
                }
            }
        }

        public static void Excluir_Mult_Barra_Prod(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_Mult_Barra_Prod(Prod);
                }
            }
        }

        public static DataTable Sel_Prod_Descricao(string pesquisar, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    string SqlSituacao;
                    if (situacao == "" || situacao == null)
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = " AND situacao='" + situacao + "'";
                    }
                    //
                    if (pesquisar.Contains("%"))
                    {
                        Prod.Pesquisar = pesquisar;
                        return con.Sel_Prod_Descricao_Like(Prod, SqlSituacao);
                    }
                    else
                    {
                        Prod.Pesquisar = pesquisar;
                        return con.Sel_Prod_Descricao(Prod, SqlSituacao);
                    }
                }
            }
        }

        public static DataTable Sel_Prod_Referencia(string pesquisar, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    string SqlSituacao;
                    if (situacao == "" || situacao == null)
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = " AND situacao='" + situacao + "'";
                    }
                    //
                    Prod.Pesquisar = pesquisar;
                    return con.Sel_Prod_Referencia(Prod, SqlSituacao);
                }
            }
        }

        public static DataTable Sel_Prod_Codigo(string pesquisar, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    string SqlSituacao;
                    if (situacao == "" || situacao == null)
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = " AND situacao='" + situacao + "'";
                    }
                    //
                    Prod.Pesquisar = pesquisar;
                    return con.Sel_Prod_Codigo(Prod, SqlSituacao);
                }
            }
        }

        public static DataTable Sel_Prod_Barra(string pesquisar, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    string SqlSituacao;
                    if (situacao == "" || situacao == null)
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = " AND situacao='" + situacao + "'";
                    }
                    //
                    Prod.Pesquisar = pesquisar;
                    if (con.Sel_Prod_Barra(Prod, SqlSituacao) != null)
                    {
                        return con.Sel_Prod_Barra(Prod, SqlSituacao);
                    }
                    else
                    {
                        if (con.Sel_Mult_Cod_Barra_Cod_Prod(Prod) != null)
                        {
                            DataRow dr = con.Sel_Mult_Cod_Barra_Cod_Prod(Prod).Rows[0];
                            //
                            Prod.Pesquisar = dr["id_produto"].ToString();
                            //
                            return con.Sel_Prod_Codigo(Prod, SqlSituacao);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public static DataTable Sel_Prod_Grupo(string pesquisar, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    string SqlSituacao;
                    if (situacao == "" || situacao == null)
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = " AND situacao='" + situacao + "'";
                    }
                    //
                    string[] items = pesquisar.Split('—');
                    Prod.Pesquisar = items[0];
                    return con.Sel_Prod_Grupo(Prod, SqlSituacao);
                }
            }
        }

        public static DataTable Sel_Prod_Grupo_SubGrupo(string pesquisar, string subgrupo, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    string SqlSituacao;
                    if (situacao == "" || situacao == null)
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = " AND situacao='" + situacao + "'";
                    }
                    //
                    string[] items = pesquisar.Split('—');
                    Prod.Pesquisar = items[0];
                    items = subgrupo.Split('—');
                    return con.Sel_Prod_Grupo_SubGrupo(Prod, items[0], SqlSituacao);
                }
            }
        }

        public static DataTable Sel_Prod_Palavra_Chave(string pesquisar, string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    string SqlSituacao;
                    if (situacao == "" || situacao == null)
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = " AND situacao='" + situacao + "'";
                    }
                    //
                    Prod.Pesquisar = pesquisar;
                    return con.Sel_Prod_Palavra_Chave(Prod, SqlSituacao);
                }
            }
        }

        public static DataTable Sel_Prod_Todos(string situacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    string SqlSituacao;
                    if (situacao == "" || situacao == null)
                    {
                        SqlSituacao = "";
                    }
                    else
                    {
                        SqlSituacao = " AND situacao='" + situacao + "'";
                    }
                    //
                    return con.Sel_Prod_Todos(Prod, SqlSituacao);
                }
            }
        }

        public static bool Val_Prod_NCM(string ncm)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.NCM = ncm;
                    return con.Val_Prod_NCM(Prod);
                }
            }
        }

        public static bool Val_Prod_Barra(string barra)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Cod_Barra = barra;
                    return con.Val_Prod_Barra(Prod);
                }
            }
        }

        public static bool Val_Prod_Palavra_Chave(string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Palavra_Chave = palavra_chave;
                    return con.Val_Prod_Palavra_Chave(Prod);
                }
            }
        }

        public static bool Val_Prod_Barra_Alt(string codigo, string barra)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    Prod.Cod_Barra = barra;
                    if (con.Val_Prod_Barra_Alt(Prod) == Convert.ToInt32(codigo))
                    {
                        return false;
                    }
                    else if (con.Val_Prod_Barra_Alt(Prod) == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public static bool Val_Prod_Palavra_Chave_Alt(string codigo, string palavra_chave)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    Prod.Palavra_Chave = palavra_chave;
                    if (con.Val_Prod_Palavra_Chave_Alt(Prod) == Convert.ToInt32(codigo))
                    {
                        return false;
                    }
                    else if (con.Val_Prod_Palavra_Chave_Alt(Prod) == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }

        public static DataTable Sel_Prod_A_Alt(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Prod_A_Alt(Prod);
                }
            }
        }

        public static DataTable Sel_Prod_A_Salvar()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Prod_A_Salvar();
            }
        }

        public static DataTable Sel_ComboboxGrupo_Valor_A_Alterar(string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    string[] items = cbbgrupo.Split('—');
                    Prod.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxGrupo_Valor_A_Alterar(Prod);
                }
            }
        }

        public static bool Sel_Produto_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Produto_Ainda_Existe(Prod);
                }
            }
        }

        public static DataTable Sel_ComboboxLocalizacao_Valor_A_Alterar(string cbblocalizacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    string[] items = cbblocalizacao.Split('—');
                    Prod.Cod_Localizacao = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxLocalizacao_Valor_A_Alterar(Prod);
                }
            }
        }



        public static DataTable Sel_ComboboxMarca_Valor_A_Alterar(string cbbmarca)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    string[] items = cbbmarca.Split('—');
                    Prod.Cod_Marca = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxMarca_Valor_A_Alterar(Prod);
                }
            }
        }

        public static DataTable Sel_ComboboxSubGrupo_Valor_A_Alterar_Produto(string cbbsubgrupo, string cbbgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    string[] items = cbbsubgrupo.Split('—');
                    Prod.Cod_SubGrupo = Convert.ToInt16(items[0]);
                    items = cbbgrupo.Split('—');
                    Prod.Cod_Grupo = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxSubGrupo_Valor_A_Alterar_Produto(Prod);
                }
            }
        }

        public static DataTable Sel_Fornecedor_Prod()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Fornecedor_Prod();
            }
        }

        public static DataTable Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Todos(string data, string data1, string preco, string preco1, string localizacao, string um, string saldo_atual, string saldo_atual1, string marca, string fornecedor)
        {
            using (Con7BD con = new Con7BD())
            {

                string SqlData;
                string SqlPreco;
                string SqlLocalizar;
                string SqlUM;
                string SqlSaldoAtual;
                string SqlMarca;
                string SqlFornecedor;
                string[] items;
                //
                if (data.Contains("_") || data1.Contains("_"))
                {
                    SqlData = "WHERE data_cadastro BETWEEN '21.07.1994 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
                }
                else
                {
                    SqlData = "WHERE data_cadastro BETWEEN '" + data.Replace('/', '.') + " 00:00:00" + "' AND '" + data1.Replace('/', '.') + " 23:59:59" + "'";
                }
                //
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                //

                if (preco == "" & preco1 == "")
                {
                    SqlPreco = "";
                }
                else
                {
                    decimal dpreco;
                    decimal dpreco1;
                    //
                    if (preco == "")
                    {
                        preco = "0";
                    }
                    //
                    if (preco.Contains("."))
                    {
                        dpreco = Convert.ToDecimal(preco.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        dpreco = Convert.ToDecimal(preco.Replace(",", ".").Replace(";", ""));
                    }
                    //
                    if (preco1 != "")
                    {
                        //
                        if (preco1.Contains("."))
                        {
                            dpreco1 = Convert.ToDecimal(preco1.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            dpreco1 = Convert.ToDecimal(preco1.Replace(",", ".").Replace(";", ""));
                        }
                        //
                        SqlPreco = " AND produto.preco BETWEEN '" + dpreco + "' AND '" + dpreco1 + "'";
                    }
                    else
                    {
                        dpreco1 = 0;

                        SqlPreco = " AND produto.preco=" + dpreco;
                    }
                }
                //
                if (localizacao == "")
                {
                    SqlLocalizar = "";
                }
                else
                {
                    items = localizacao.Split('—');
                    SqlLocalizar = " AND produto.id_localizacao='" + items[0] + "'";
                }
                //
                if (um == "")
                {
                    SqlUM = "";
                }
                else
                {
                    SqlUM = " AND produto.um='" + um + "'";
                }
                //
                if (saldo_atual == "" & saldo_atual1 == "")
                {
                    SqlSaldoAtual = "";
                }
                else
                {
                    decimal dsaldo_atual;
                    decimal dsaldo_atual1;
                    //
                    if (saldo_atual == "")
                    {
                        saldo_atual = "0";
                    }
                    //
                    if (saldo_atual.Contains("."))
                    {
                        dsaldo_atual = Convert.ToDecimal(saldo_atual.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        dsaldo_atual = Convert.ToDecimal(saldo_atual.Replace(",", ".").Replace(";", ""));
                    }
                    //
                    if (saldo_atual1 != "")
                    {
                        if (saldo_atual1.Contains("."))
                        {
                            dsaldo_atual1 = Convert.ToDecimal(saldo_atual1.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            dsaldo_atual1 = Convert.ToDecimal(saldo_atual1.Replace(",", ".").Replace(";", ""));
                        }
                        //
                        SqlSaldoAtual = " AND produto.est_saldo_atual BETWEEN '" + dsaldo_atual + "' AND '" + dsaldo_atual1 + "'";
                    }
                    else
                    {
                        dsaldo_atual1 = 0;
                        //
                        SqlSaldoAtual = " AND produto.est_saldo_atual=" + dsaldo_atual;
                    }
                }
                //
                if (marca == "")
                {
                    SqlMarca = "";
                }
                else
                {
                    items = marca.Split('—');

                    SqlMarca = " AND produto.id_marca='" + items[0] + "'";
                }
                //
                if (fornecedor == "")
                {
                    SqlFornecedor = " entrada_produto.id_produto=produto.id_produto ";

                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");

                    return con.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Todos(SqlData, SqlPreco, SqlLocalizar, SqlUM, SqlSaldoAtual, SqlMarca, SqlFornecedor);
                }
                else
                {
                    items = fornecedor.Split('—');
                    SqlFornecedor = " entrada_produto.id_fornecedor=" + items[0] + " AND entrada_produto.id_produto=produto.id_produto ";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                    //
                    if (con.Sel_Fornecedor_Entrada_Produto_Exist_Saida(items[0]) == null)
                    {
                        return null;
                    }
                    else
                    {
                        return con.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Todos(SqlData, SqlPreco, SqlLocalizar, SqlUM, SqlSaldoAtual, SqlMarca, SqlFornecedor);
                    }
                }
            }
        }

        public static DataTable Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Descricao(string data, string data1, string preco, string preco1, string localizacao, string um, string saldo_atual, string saldo_atual1, string marca, string fornecedor, string descricao)
        {
            using (Con7BD con = new Con7BD())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                string SqlDescricao;
                string SqlData;
                string SqlPreco;
                string SqlLocalizar;
                string SqlUM;
                string SqlSaldoAtual;
                string SqlMarca;
                string SqlFornecedor;
                string[] items;
                //
                if (descricao.Contains("%"))
                {
                    SqlDescricao = "WHERE produto.descricao LIKE '" + descricao + "'";
                }
                else
                {
                    SqlDescricao = "WHERE produto.descricao STARTING WITH '" + descricao + "'";
                }
                //
                if (data.Contains("_") || data1.Contains("_"))
                {
                    SqlData = "";
                }
                else
                {
                    SqlData = " AND produto.data_cadastro BETWEEN '" + data.Replace("/", ".") + "' AND '" + data1.Replace("/", ".") + "'";
                }
                //
                if (preco == "" & preco1 == "")
                {
                    SqlPreco = "";
                }
                else
                {
                    decimal dpreco;
                    decimal dpreco1;
                    //
                    if (preco == "")
                    {
                        preco = "0";
                    }
                    //
                    if (preco.Contains("."))
                    {
                        dpreco = Convert.ToDecimal(preco.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        dpreco = Convert.ToDecimal(preco.Replace(",", ".").Replace(";", ""));
                    }
                    //
                    if (preco1 != "")
                    {
                        //
                        if (preco1.Contains("."))
                        {
                            dpreco1 = Convert.ToDecimal(preco1.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            dpreco1 = Convert.ToDecimal(preco1.Replace(",", ".").Replace(";", ""));
                        }
                        //
                        SqlPreco = " AND produto.preco BETWEEN '" + dpreco + "' AND '" + dpreco1 + "'";
                    }
                    else
                    {
                        dpreco1 = 0;

                        SqlPreco = " AND produto.preco=" + dpreco;
                    }
                }
                //
                if (localizacao == "")
                {
                    SqlLocalizar = "";
                }
                else
                {
                    items = localizacao.Split('—');
                    SqlLocalizar = " AND produto.id_localizacao='" + items[0] + "'";
                }
                //
                if (um == "")
                {
                    SqlUM = "";
                }
                else
                {
                    SqlUM = " AND produto.um='" + um + "'";
                }
                //
                if (saldo_atual == "" & saldo_atual1 == "")
                {
                    SqlSaldoAtual = "";
                }
                else
                {
                    decimal dsaldo_atual;
                    decimal dsaldo_atual1;
                    //
                    if (saldo_atual == "")
                    {
                        saldo_atual = "0";
                    }
                    //
                    if (saldo_atual.Contains("."))
                    {
                        dsaldo_atual = Convert.ToDecimal(saldo_atual.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        dsaldo_atual = Convert.ToDecimal(saldo_atual.Replace(",", ".").Replace(";", ""));
                    }
                    //
                    if (saldo_atual1 != "")
                    {
                        if (saldo_atual1.Contains("."))
                        {
                            dsaldo_atual1 = Convert.ToDecimal(saldo_atual1.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            dsaldo_atual1 = Convert.ToDecimal(saldo_atual1.Replace(",", ".").Replace(";", ""));
                        }
                        //
                        SqlSaldoAtual = " AND produto.est_saldo_atual BETWEEN '" + dsaldo_atual + "' AND '" + dsaldo_atual1 + "'";
                    }
                    else
                    {
                        dsaldo_atual1 = 0;
                        //
                        SqlSaldoAtual = " AND produto.est_saldo_atual=" + dsaldo_atual;
                    }
                }
                //
                if (marca == "")
                {
                    SqlMarca = "";
                }
                else
                {
                    items = marca.Split('—');

                    SqlMarca = " AND produto.id_marca='" + items[0] + "'";
                }
                //
                if (fornecedor == "")
                {
                    SqlFornecedor = " entrada_produto.id_produto=produto.id_produto ";

                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");

                    return con.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Descricao(SqlDescricao, SqlData, SqlPreco, SqlLocalizar, SqlUM, SqlSaldoAtual, SqlMarca, SqlFornecedor);
                }
                else
                {
                    items = fornecedor.Split('—');
                    SqlFornecedor = " entrada_produto.id_fornecedor=" + items[0] + " AND entrada_produto.id_produto=produto.id_produto ";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                    //
                    if (con.Sel_Fornecedor_Entrada_Produto_Exist_Saida(items[0]) == null)
                    {
                        return null;
                    }
                    else
                    {
                        return con.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Descricao(SqlDescricao, SqlData, SqlPreco, SqlLocalizar, SqlUM, SqlSaldoAtual, SqlMarca, SqlFornecedor);
                    }
                }
            }
        }

        public static DataTable Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Grupo_Subgrupo(string data, string data1, string preco, string preco1, string localizacao, string um, string saldo_atual, string saldo_atual1, string marca, string fornecedor, string grupo, string subgrupo)
        {
            using (Con7BD con = new Con7BD())
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                string SqlGrupo;
                string SqlSubGrupo;
                string SqlData;
                string SqlPreco;
                string SqlLocalizar;
                string SqlUM;
                string SqlSaldoAtual;
                string SqlMarca;
                string SqlFornecedor;
                string[] items;
                //
                items = grupo.Split('—');
                SqlGrupo = "WHERE produto.id_grupo=" + items[0];
                //
                if (subgrupo == "")
                {
                    SqlSubGrupo = "";
                }
                else
                {
                    items = subgrupo.Split('—');
                    SqlSubGrupo = " AND produto.id_subgrupo='" + items[0] + "'";
                }
                //
                if (data.Contains("_") || data1.Contains("_"))
                {
                    SqlData = "";
                }
                else
                {
                    SqlData = " AND produto.data_cadastro BETWEEN '" + data.Replace("/", ".") + "' AND '" + data1.Replace("/", ".") + "'";
                }
                //
                if (preco == "" & preco1 == "")
                {
                    SqlPreco = "";
                }
                else
                {
                    decimal dpreco;
                    decimal dpreco1;
                    //
                    if (preco == "")
                    {
                        preco = "0";
                    }
                    //
                    if (preco.Contains("."))
                    {
                        dpreco = Convert.ToDecimal(preco.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        dpreco = Convert.ToDecimal(preco.Replace(",", ".").Replace(";", ""));
                    }
                    //
                    if (preco1 != "")
                    {
                        //
                        if (preco1.Contains("."))
                        {
                            dpreco1 = Convert.ToDecimal(preco1.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            dpreco1 = Convert.ToDecimal(preco1.Replace(",", ".").Replace(";", ""));
                        }
                        //
                        SqlPreco = " AND produto.preco BETWEEN '" + dpreco + "' AND '" + dpreco1 + "'";
                    }
                    else
                    {
                        dpreco1 = 0;

                        SqlPreco = " AND produto.preco=" + dpreco;
                    }
                }
                //
                if (localizacao == "")
                {
                    SqlLocalizar = "";
                }
                else
                {
                    items = localizacao.Split('—');
                    SqlLocalizar = " AND produto.id_localizacao='" + items[0] + "'";
                }
                //
                if (um == "")
                {
                    SqlUM = "";
                }
                else
                {
                    SqlUM = " AND produto.um='" + um + "'";
                }
                //
                if (saldo_atual == "" & saldo_atual1 == "")
                {
                    SqlSaldoAtual = "";
                }
                else
                {
                    decimal dsaldo_atual;
                    decimal dsaldo_atual1;
                    //
                    if (saldo_atual == "")
                    {
                        saldo_atual = "0";
                    }
                    //
                    if (saldo_atual.Contains("."))
                    {
                        dsaldo_atual = Convert.ToDecimal(saldo_atual.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        dsaldo_atual = Convert.ToDecimal(saldo_atual.Replace(",", ".").Replace(";", ""));
                    }
                    //
                    if (saldo_atual1 != "")
                    {
                        if (saldo_atual1.Contains("."))
                        {
                            dsaldo_atual1 = Convert.ToDecimal(saldo_atual1.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            dsaldo_atual1 = Convert.ToDecimal(saldo_atual1.Replace(",", ".").Replace(";", ""));
                        }
                        //
                        SqlSaldoAtual = " AND produto.est_saldo_atual BETWEEN '" + dsaldo_atual + "' AND '" + dsaldo_atual1 + "'";
                    }
                    else
                    {
                        dsaldo_atual1 = 0;
                        //
                        SqlSaldoAtual = " AND produto.est_saldo_atual=" + dsaldo_atual;
                    }
                }
                //
                if (marca == "")
                {
                    SqlMarca = "";
                }
                else
                {
                    items = marca.Split('—');

                    SqlMarca = " AND produto.id_marca='" + items[0] + "'";
                }
                //
                if (fornecedor == "")
                {
                    SqlFornecedor = " entrada_produto.id_produto=produto.id_produto ";

                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");

                    return con.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Grupo_Subgrupo(SqlGrupo, SqlSubGrupo, SqlData, SqlPreco, SqlLocalizar, SqlUM, SqlSaldoAtual, SqlMarca, SqlFornecedor);
                }
                else
                {
                    items = fornecedor.Split('—');
                    SqlFornecedor = " entrada_produto.id_fornecedor=" + items[0] + " AND entrada_produto.id_produto=produto.id_produto ";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                    //
                    if (con.Sel_Fornecedor_Entrada_Produto_Exist_Saida(items[0]) == null)
                    {
                        return null;
                    }
                    else
                    {
                        return con.Sel_Prod_Data_Preco_Localizar_Um_Forn_Estoque_Grupo_Subgrupo(SqlGrupo, SqlSubGrupo, SqlData, SqlPreco, SqlLocalizar, SqlUM, SqlSaldoAtual, SqlMarca, SqlFornecedor);
                    }
                }
            }
        }

        public static bool Sel_Dest_Est_Negativo_Prod(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    //
                    if (con.Sel_Dest_Est_Baixo_Prod(Prod) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool Sel_Alert_Est_Max_Min_Prod(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    //
                    if (con.Sel_Alert_Est_Max_Min_Prod(Prod) == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static decimal Sel_Saldo_Atual_Produto(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    //
                    return con.Sel_Saldo_Atual_Produto(Prod);
                }
            }
        }

        public static bool Ver_Estoque_Max_Prod(string codigo, string quantidade)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    //
                    DataRow dr = con.Ver_Estoque_Max_Prod(Prod).Rows[0];
                    //
                    if (Convert.ToDecimal(dr["est_saldo_atual"]) + Convert.ToDecimal(quantidade) > Convert.ToDecimal(dr["estoque_max"]) || Convert.ToDecimal(dr["estoque_max"]) == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool Ver_Estoque_Min_Prod(string codigo, string quantidade)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    //
                    DataRow dr = con.Ver_Estoque_Min_Prod(Prod).Rows[0];
                    //
                    if (Convert.ToDecimal(dr["est_saldo_atual"]) - Convert.ToDecimal(quantidade) < Convert.ToDecimal(dr["estoque_min"]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool Sel_Produto_Venda_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Produto_Venda_Ver(Prod);
                }
            }
        }

        public static bool Sel_Produto_Devolucao_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Produto_Devolucao_Ver(Prod);
                }
            }
        }

        public static bool Sel_Produto_Dfe_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Produto_Dfe_Ver(Prod);
                }
            }
        }

        public static bool Sel_Produto_OS_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Produto_OS_Ver(Prod);
                }
            }
        }

        public static bool Sel_Produto_Orcamento_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Produto_Orcamento_Ver(Prod);
                }
            }
        }

        public static string Sel_Produto_Alerta_Observacao(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Produto_Alerta_Observacao(Prod);
                }
            }
        }

        public static bool Sel_Produto_Devolucao_Dev_Prod_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Produto_Devolucao_Dev_Prod_Ver(Prod);
                }
            }
        }

        public static DataTable Sel_Prod_Data_Hora_Ult_Venda(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Prod_Data_Hora_Ult_Venda(Prod);
                }
            }
        }

        public static DataTable Sel_Prod_Qtde_Venda(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Prod_Qtde_Venda(Prod);
                }
            }
        }

        public static DataTable Sel_Prod_Qtde_Media_Venda(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Prod_Qtde_Media_Venda(Prod);
                }
            }
        }

        public static DataTable Sel_Prod_Total_Valor_Venda(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Prod_Total_Valor_Venda(Prod);
                }
            }
        }

        public static DataTable Sel_Prod_Frequencia_Venda(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Prod_Frequencia_Venda(Prod);
                }
            }
        }

        public static DataTable Sel_Prod_Data_Hora_Ult_Entrada(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Prod_Data_Hora_Ult_Entrada(Prod);
                }
            }
        }

        public static DataTable Sel_Prod_Qtde_Ult_Entrada(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Prod_Qtde_Ult_Entrada(Prod);
                }
            }
        }

        public static DataTable Sel_Prod_Data_Hora_Ult_Alteracao(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Prod_Data_Hora_Ult_Alteracao(Prod);
                }
            }
        }

        public static DataTable Sel_Prod_Frequencia_Entrada(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Produto Prod = new Produto())
                {
                    Prod.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Prod_Frequencia_Entrada(Prod);
                }
            }
        }


    }
}
