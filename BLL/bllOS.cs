using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL
{
    public class bllOS
    {
        public static bool _FrmOS_Ativo;
        public static bool _FrmRelOS_Ativo;
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;

        public static string _Usuario_PesqUsuario_Tabela;
        public static string _Cliente_PesqCliente_Tabela;
        public static string _Func_PesqFuncionario_Tabela;
        public static string _Marca_PesqMarca_Tabela;
        public static string _Servico_PesqServico_Tabela;
        public static string _Produto_PesqProduto_Tabela;
        public static string _Forma_Pagamento_PesqFormaPagamento_Tabela;
        public static string _Celular_CadCelular_Tabela;

        public static string _Nome_Arquivo;
        public static string _Url_Imagem;
        public static bool _Excluir_Imagem;
        public static bool _Mostrar_Imagem;


        public static string _Quantidade;
        public static string _Codigo;

        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;

        public static string _Cod_Servico_Cadastro;
        public static string _Cod_Produto_Cadastro;
        public static string _Cod_Funcionario_Cadastro;
        public static string _Cod_Cliente_Cadastro;
        public static string _Cod_Marca_Cadastro;
        public static string _Cod_Orcamento_Cadastro;

        public static string _Tipo_Venda;


        public static DataTable Sel_Cliente_OS()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Cliente_OS();
            }
        }

        public static DataTable Sel_Servico_OS()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Servico_OS();
            }
        }

        public static DataTable Sel_Produto_OS()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Produto_OS();
            }
        }

        public static bool Sel_Venda_OS_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Os.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Venda_OS_Ver(Os);
                }
            }
        }

        public static DataTable Sel_Funcionario_OS()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Funcionario_OS();
            }
        }

        public static bool Sel_OS_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Os.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_OS_Ainda_Existe(Os);
                }
            }
        }

        public static bool Sel_Baixa_OS_Aconteceu(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Os.Codigo = Convert.ToInt32(codigo);
                    return con.Sel_Baixa_OS_Aconteceu(Os);
                }
            }
        }

        public static void Alterar_Estoque_Produto_OS(string codigo, string quantidade, bool adicionar)
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
                    if (adicionar == false)
                    {
                        if (quantidade.Contains("."))
                        {
                            Prod.Saldo_Atual = con.Sel_Estoque_Atual_Produto_PDV(Prod) - Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prod.Saldo_Atual = con.Sel_Estoque_Atual_Produto_PDV(Prod) - Convert.ToDecimal(quantidade.Replace(",", "."));
                        }
                    }
                    else
                    {
                        if (quantidade.Contains("."))
                        {
                            Prod.Saldo_Atual = con.Sel_Estoque_Atual_Produto_PDV(Prod) + Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Prod.Saldo_Atual = con.Sel_Estoque_Atual_Produto_PDV(Prod) + Convert.ToDecimal(quantidade.Replace(",", "."));
                        }
                    }
                    //
                    con.Alterar_Estoque_Produto_OS(Prod);
                }
                //
                Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            }
        }

        public static void Salvar(string consumidor, string data, string horario, string data_conc_prev, string horario_conc_prev, string descricao, string desc_item, string marca, string modelo, string n_serie, string observacao, string imagem_os, string cod_pdv_computador, string valor_real, string valor_servicos, string valor_produtos, string valor_total, string usuario, string valor_desconto_item, string valor_acrescimo_item)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    string[] items;
                    if (consumidor == null || consumidor == "")
                    {
                        Os.Cod_Consumidor = 0;
                        Os.Nome_Consumidor = "null";
                        Os.CPF_CNPJ_Consumidor = "null";
                    }
                    else
                    {
                        items = consumidor.Split('—');
                        //
                        Os.Cod_Consumidor = Convert.ToInt32(items[0]);
                        Os.Nome_Consumidor = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                        //
                        if (items.Length > 2)
                        {
                            Os.CPF_CNPJ_Consumidor = items[2].Insert(items[2].Length, "'").Insert(0, "'");
                        }
                        else
                        {
                            Os.CPF_CNPJ_Consumidor = "null";
                        }
                    }
                    //
                    Os.Data = "'" + data.Replace('/', '.') + " " + horario.Remove(5) + "'";
                    //
                    Os.Horario = horario.Insert(horario.Length, "'").Insert(0, "'");
                    //
                    if (data_conc_prev == "" || data_conc_prev == "  /  /" || data_conc_prev == "__/__/____" || data_conc_prev == null)
                    {
                        Os.Data_Conc_Prev = "null";
                    }
                    else
                    {
                        if (horario_conc_prev == "" || horario_conc_prev == "  :  :" || horario_conc_prev == "__:__:__" || horario_conc_prev == null)
                        {
                            Os.Data_Conc_Prev = data_conc_prev.Insert(data_conc_prev.Length, "'").Insert(0, "'").Replace('/', '.');
                        }
                        else
                        {
                            Os.Data_Conc_Prev = "'" + data_conc_prev.Replace('/', '.') + " " + horario_conc_prev.Remove(5) + "'";
                        }
                    }
                    //
                    if (horario_conc_prev == "" || horario_conc_prev == "  :  :" || horario_conc_prev == "__:__:__" || horario_conc_prev == null)
                    {
                        Os.Horario_Conc_Prev = "null";
                    }
                    else
                    {
                        Os.Horario_Conc_Prev = horario_conc_prev.Insert(horario_conc_prev.Length, "'").Insert(0, "'");
                    }
                    //
                    Os.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    Os.Descricao_Item = desc_item.Insert(desc_item.Length, "'").Insert(0, "'");
                    //
                    if (marca == null || marca == "")
                    {
                        Os.Marca = "null";
                    }
                    else
                    {
                        Os.Marca = marca.Insert(marca.Length, "'").Insert(0, "'");
                    }
                    //
                    if (modelo == null || modelo == "")
                    {
                        Os.Modelo = "null";
                    }
                    else
                    {
                        Os.Modelo = modelo.Insert(modelo.Length, "'").Insert(0, "'");
                    }
                    //
                    if (n_serie == null || n_serie == "")
                    {
                        Os.N_Serie = "null";
                    }
                    else
                    {
                        Os.N_Serie = n_serie.Insert(n_serie.Length, "'").Insert(0, "'");
                    }
                    //
                    if (observacao == null || observacao == "")
                    {
                        Os.Observacao = "null";
                    }
                    else
                    {
                        Os.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    Os.Situacao = "'PENDENTE'";
                    //
                    if (imagem_os != null)
                    {
                        Image original = Image.FromFile(imagem_os);
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
                        Os.Imagem_OS = imagemBytes;
                    }
                    //
                    if (valor_real.Contains("."))
                    {
                        Os.Valor_Real = Convert.ToDecimal(valor_real.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Real = Convert.ToDecimal(valor_real.Replace(",", "."));
                    }
                    //
                    if (valor_servicos.Contains("."))
                    {
                        Os.Valor_Servicos = Convert.ToDecimal(valor_servicos.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Servicos = Convert.ToDecimal(valor_servicos.Replace(",", "."));
                    }
                    //
                    if (valor_produtos.Contains("."))
                    {
                        Os.Valor_Produtos = Convert.ToDecimal(valor_produtos.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Produtos = Convert.ToDecimal(valor_produtos.Replace(",", "."));
                    }
                    //
                    if (valor_total.Contains("."))
                    {
                        Os.Valor_Total = Convert.ToDecimal(valor_total.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Total = Convert.ToDecimal(valor_total.Replace(",", "."));
                    }
                    //
                    Os.Pagamento_Parcial = 0;
                    //
                    items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Os.Cod_Usuario= Convert.ToInt16(items[0]);
                    //
                    Os.Nome_Usuario= items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    if (valor_desconto_item.Contains("."))
                    {
                        Os.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(",", "."));
                    }
                    //
                    if (valor_acrescimo_item.Contains("."))
                    {
                        Os.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(",", "."));
                    }
                    //
                    con.Salvar_OS(Os);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar_Imagem_Os(string codigo, string imagem_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Os.Codigo = Convert.ToInt32(codigo);
                    //
                    bool nulo;
                    if (imagem_os != null)
                    {
                        Image original = Image.FromFile(imagem_os);
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
                        Os.Imagem_OS = imagemBytes;
                        //
                        nulo = false;
                    }
                    else
                    {
                        nulo = true;
                    }
                    //
                    con.Alterar_Imagem_Os(Os, nulo);
                }
            }
        }

        public static DataTable Sel_Formas_Pagamento_OS(string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Pagamento_OS Pgto = new Pagamento_OS())
                {
                    Pgto.Cod_OS = Convert.ToInt32(cod_os);
                    return con.Sel_Formas_Pagamento_OS(Pgto);
                }
            }
        }

        public static void Salvar_Forma_Pagamento_OS_Temp(string item, string forma_pagamento, string valor_pagamento, string cod_conexao_configuracoes, string cod_tabela, byte pagamento_parcial)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_OS_Pgto_Temp Pgto = new Item_OS_Pgto_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Pgto.Codigo = Convert.ToInt16(item);
                    //
                    string[] items = forma_pagamento.Split('—');
                    //
                    Pgto.Cod_Pagamento = Convert.ToInt16(items[0]);
                    //
                    Pgto.Tipo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    if (valor_pagamento.Contains("."))
                    {
                        Pgto.Valor_Pago = Convert.ToDecimal(valor_pagamento.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Pgto.Valor_Pago = Convert.ToDecimal(valor_pagamento.Replace(",", "."));
                    }
                    //
                    Pgto.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    Pgto.Cod_Tabela = Convert.ToByte(cod_tabela);
                    //
                    Pgto.Pagamento_Parcial = pagamento_parcial;
                    //
                    con.Salvar_Forma_Pagamento_OS_Temp(Pgto);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Item_OS_Pgto_Todas(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_OS_Pgto_Temp Items = new Item_OS_Pgto_Temp())
                {
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    return con.Sel_Item_OS_Pgto_Todas(Items);
                }
            }
        }

        public static void Salvar_Baixa_Pagamento_OS(string codigo, string valor_real, string data_conclusao, string horario_conclusao, string troco, string usuario, string cod_pdv_computador, string valor_desconto, string desconto_porc, string valor_acrescimo, string acrescimo_porc)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Os.Data_Baixa = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm") + "'";
                    //
                    Os.Horario_Baixa = "'" + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Os.Codigo = Convert.ToInt32(codigo);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    if (valor_real.Contains("."))
                    {
                        Os.Valor_Real = Convert.ToDecimal(valor_real.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Real = Convert.ToDecimal(valor_real.Replace(",", "."));
                    }
                    //
                    if (horario_conclusao == "" || horario_conclusao == "  :  :" || horario_conclusao == "__:__:__" || horario_conclusao == null)
                    {
                        Os.Data_Conclusao = "'" + data_conclusao.Replace('/', '.') + "'";
                    }
                    else
                    {
                        Os.Data_Conclusao = "'" + data_conclusao.Replace('/', '.') + " " + horario_conclusao.Remove(5) + "'";
                    }
                    //
                    if (horario_conclusao == "" || horario_conclusao == "  :  :" || horario_conclusao == "__:__:__" || horario_conclusao == null)
                    {
                        Os.Horario_Conclusao = "null";
                    }
                    else
                    {
                        Os.Horario_Conclusao = horario_conclusao.Insert(horario_conclusao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (troco.Contains("."))
                    {
                        Os.Troco = Convert.ToDecimal(troco.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Troco = Convert.ToDecimal(troco.Replace(",", "."));
                    }
                    //
                    if (valor_desconto.Contains("."))
                    {
                        Os.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                    }
                    //
                    if (desconto_porc.Contains("."))
                    {
                        Os.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Desconto_Porc = Convert.ToDecimal(desconto_porc.Replace(",", "."));
                    }
                    //
                    if (valor_acrescimo.Contains("."))
                    {
                        Os.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(",", "."));
                    }
                    //
                    if (acrescimo_porc.Contains("."))
                    {
                        Os.Acrescimo_Porc = Convert.ToDecimal(acrescimo_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Acrescimo_Porc = Convert.ToDecimal(acrescimo_porc.Replace(",", "."));
                    }
                    //
                    usuario = usuario.Remove(0, 12);
                    string[] items = usuario.Split('—');
                    //
                    Os.Cod_Usuario_Baixa = Convert.ToInt16(items[0]);
                    //
                    Os.Nome_Usuario_Baixa = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = cod_pdv_computador.Split('/');
                    Os.Cod_PDV_Computador_Baixa = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    //
                    con.Salvar_Baixa_Pagamento_OS(Os);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar_Forma_Pagamento_Parcial(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Os.Codigo = Convert.ToInt32(codigo);
                    //
                    con.Alterar_Forma_Pagamento_Parcial(Os);
                }
            }
        }

        public static void Alterar_Pagamento_Parcial_OS(string codigo, bool pagamento_parcial)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Os.Codigo = Convert.ToInt32(codigo);
                    //
                    if (pagamento_parcial == true)
                    {
                        Os.Pagamento_Parcial = 1;
                    }
                    else
                    {
                        Os.Pagamento_Parcial = 0;
                    }
                    //
                    con.Alterar_Pagamento_Parcial_OS(Os);
                }
            }
        }

        public static bool Sel_Pagamento_Parcial_OS(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Os.Codigo = Convert.ToInt32(codigo);
                    //
                    return con.Sel_Pagamento_Parcial_OS(Os);
                }
            }
        }

        public static string Calculo_Acrescimo(string valor_documento, string acrescimo_porc)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal percentual = Convert.ToDecimal(acrescimo_porc) / 100;
            decimal retorno = (percentual * valor);
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_ValorAcrescimo(string valor_documento, string valor_acrescimo)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal desconto = Convert.ToDecimal(valor_acrescimo);
            decimal retorno = (desconto) / valor * 100;
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_Desconto(string valor_documento, string desconto_porc)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal percentual = Convert.ToDecimal(desconto_porc) / 100;
            decimal retorno = (percentual * valor);
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_ValorDesconto(string valor_documento, string valor_desconto)
        {
            decimal valor = Convert.ToDecimal(valor_documento);
            decimal desconto = Convert.ToDecimal(valor_desconto);
            decimal retorno = (desconto) / valor * 100;
            return Math.Round(retorno, 2).ToString();
        }

        public static string Calculo_Valor_Item(string preco, string quantidade)
        {
            decimal valor = Convert.ToDecimal(preco);
            decimal qtde = Convert.ToDecimal(quantidade);
            valor = valor * qtde;
            return Math.Round(valor, 2).ToString();
        }

        public static string Calculo_Valor_Real_Desc_Acresc(string valor_total, string valor_desconto, string valor_acrescimo)
        {
            if (valor_desconto == "")
            {
                valor_desconto = "0,00";
            }
            //
            if (valor_acrescimo == "")
            {
                valor_acrescimo = "0,00";
            }
            //
            decimal valor = Convert.ToDecimal(valor_total);
            decimal desconto = Convert.ToDecimal(valor_desconto);
            decimal acrescimo = Convert.ToDecimal(valor_acrescimo);
            valor = ((valor + acrescimo) - desconto);
            return Math.Round(valor, 2).ToString();
        }

        public static string Calculo_Valor_Item_Desc_Acresc(string preco, string valor_desconto, string valor_acrescimo)
        {
            if (valor_desconto == "")
            {
                valor_desconto = "0,00";
            }
            //
            if (valor_acrescimo == "")
            {
                valor_acrescimo = "0,00";
            }
            //
            decimal valor = Convert.ToDecimal(preco);
            decimal desconto = Convert.ToDecimal(valor_desconto);
            decimal acrescimo = Convert.ToDecimal(valor_acrescimo);
            valor = valor + acrescimo - desconto;
            return valor.ToString();
        }

        public static void Salvar_Pagamento_OS(string cod_item_pagamento, string forma_pagamento, string valor_pagamento, string cod_os, string usuario, string cod_pdv_computador, string cod_tabela, byte pagamento_parcial)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Pagamento_OS Os = new Pagamento_OS())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    string[] items = forma_pagamento.Split('—');
                    //
                    Os.Data_Pagamento = "'" + DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '.') + " " + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Os.Hora_Pagamento = "'" + DateTime.Now.ToString("HH:mm:ss") + "'";
                    //
                    Os.Cod_Item_Pagamento = Convert.ToInt16(cod_item_pagamento);
                    //
                    Os.Cod_Pagamento = Convert.ToInt16(items[0]);
                    //
                    Os.Tipo = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    if (valor_pagamento.Contains("."))
                    {
                        Os.Valor_Pago = Convert.ToDecimal(valor_pagamento.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Pago = Convert.ToDecimal(valor_pagamento.Replace(",", "."));
                    }
                    //
                    Os.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    usuario = usuario.Remove(0, 12);
                    //
                    items = usuario.Split('—');
                    //
                    Os.Cod_Usuario = Convert.ToInt16(items[0]);
                    Os.Nome_Usuario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    //
                    items = cod_pdv_computador.Split('/');
                    Os.Cod_PDV_Computador = Convert.ToInt16(items[1].Replace("Nº PDV: ", "").Replace("Nº Comp.: ", ""));
                    //
                    Os.Cod_Tabela = Convert.ToByte(cod_tabela);
                    //
                    Os.Pagamento_Parcial = pagamento_parcial;
                    //
                    con.Salvar_Pagamento_OS(Os);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Excluir_Item_OS_Pgto_Atual(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_OS_Pgto_Temp Pgto = new Item_OS_Pgto_Temp())
                {
                    Pgto.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Item_OS_Pgto_Atual(Pgto);
                }
            }
        }

        public static void Atualizar_Item_Dt_Pgto_OS(int item_atual, int total_item, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_OS_Pgto_Temp Pgto = new Item_OS_Pgto_Temp())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Pgto.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        Pgto.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                        //
                        con.Atualizar_Item_Dt_Pgto_OS(Pgto, item.ToString());
                    }
                }
            }
        }

        public static void Excluir_Item(string cod_item, string cod_conexao_configuracoes, string cod_tabela)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_OS_Pgto_Temp Pgto = new Item_OS_Pgto_Temp())
                {
                    Pgto.Codigo = Convert.ToInt16(cod_item);
                    Pgto.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    Pgto.Cod_Tabela = Convert.ToByte(cod_tabela);
                    //
                    con.Excluir_Item_Pgto_OS_Temp(Pgto);
                }
            }
        }

        public static void Alterar(string codigo, string consumidor, string data, string horario, string data_conc_prev, string horario_conc_prev, string descricao, string desc_item, string marca, string modelo, string n_serie, string observacao, string cod_pdv_computador, string valor_real, string valor_servicos, string valor_produtos, string valor_total, string valor_desconto_item, string valor_acrescimo_item)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Os.Codigo = Convert.ToInt32(codigo);
                    //
                    string[] items;
                    if (consumidor == null || consumidor == "")
                    {
                        Os.Cod_Consumidor = 0;
                        Os.Nome_Consumidor = "null";
                        Os.CPF_CNPJ_Consumidor = "null";
                    }
                    else
                    {
                        items = consumidor.Split('—');
                        //
                        Os.Cod_Consumidor = Convert.ToInt32(items[0]);
                        Os.Nome_Consumidor = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                        //
                        if (items.Length > 2)
                        {
                            Os.CPF_CNPJ_Consumidor = items[2].Insert(items[2].Length, "'").Insert(0, "'");
                        }
                        else
                        {
                            Os.CPF_CNPJ_Consumidor = "null";
                        }
                    }
                    //
                    Os.Data = "'" + data.Replace('/', '.') + " " + horario.Remove(5) + "'";
                    //
                    Os.Horario = horario.Insert(horario.Length, "'").Insert(0, "'");
                    //
                    if (data_conc_prev == "" || data_conc_prev == "  /  /" || data_conc_prev == "__/__/____" || data_conc_prev == null)
                    {
                        Os.Data_Conc_Prev = "null";
                    }
                    else
                    {
                        if (horario_conc_prev == "" || horario_conc_prev == "  :  :" || horario_conc_prev == "__:__:__" || horario_conc_prev == null)
                        {
                            Os.Data_Conc_Prev = data_conc_prev.Insert(data_conc_prev.Length, "'").Insert(0, "'").Replace('/', '.');
                        }
                        else
                        {
                            Os.Data_Conc_Prev = "'" + data_conc_prev.Replace('/', '.') + " " + horario_conc_prev.Remove(5) + "'";
                        }
                    }
                    //
                    if (horario_conc_prev == "" || horario_conc_prev == "  :  :" || horario_conc_prev == "__:__:__" || horario_conc_prev == null)
                    {
                        Os.Horario_Conc_Prev = "null";
                    }
                    else
                    {
                        Os.Horario_Conc_Prev = horario_conc_prev.Insert(horario_conc_prev.Length, "'").Insert(0, "'");
                    }
                    //
                    Os.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    Os.Descricao_Item = desc_item.Insert(desc_item.Length, "'").Insert(0, "'");
                    //
                    if (marca == null || marca == "")
                    {
                        Os.Marca = "null";
                    }
                    else
                    {
                        Os.Marca = marca.Insert(marca.Length, "'").Insert(0, "'");
                    }
                    //
                    if (modelo == null || modelo == "")
                    {
                        Os.Modelo = "null";
                    }
                    else
                    {
                        Os.Modelo = modelo.Insert(modelo.Length, "'").Insert(0, "'");
                    }
                    //
                    if (n_serie == null || n_serie == "")
                    {
                        Os.N_Serie = "null";
                    }
                    else
                    {
                        Os.N_Serie = n_serie.Insert(n_serie.Length, "'").Insert(0, "'");
                    }
                    //
                    if (observacao == null || observacao == "")
                    {
                        Os.Observacao = "null";
                    }
                    else
                    {
                        Os.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //
                    if (valor_real.Contains("."))
                    {
                        Os.Valor_Real = Convert.ToDecimal(valor_real.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Real = Convert.ToDecimal(valor_real.Replace(",", "."));
                    }
                    //
                    if (valor_servicos.Contains("."))
                    {
                        Os.Valor_Servicos = Convert.ToDecimal(valor_servicos.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Servicos = Convert.ToDecimal(valor_servicos.Replace(",", "."));
                    }
                    //
                    if (valor_produtos.Contains("."))
                    {
                        Os.Valor_Produtos = Convert.ToDecimal(valor_produtos.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Produtos = Convert.ToDecimal(valor_produtos.Replace(",", "."));
                    }
                    //
                    if (valor_total.Contains("."))
                    {
                        Os.Valor_Total = Convert.ToDecimal(valor_total.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Total = Convert.ToDecimal(valor_total.Replace(",", "."));
                    }
                    //
                    if (valor_desconto_item.Contains("."))
                    {
                        Os.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Desconto_Item = Convert.ToDecimal(valor_desconto_item.Replace(",", "."));
                    }
                    //
                    if (valor_acrescimo_item.Contains("."))
                    {
                        Os.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Acrescimo_Item = Convert.ToDecimal(valor_acrescimo_item.Replace(",", "."));
                    }
                    con.Alterar_OS(Os);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Usuario_OS()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Usuario_OS();
            }
        }

        public static void Alterar_OS_Observacao(string codigo, string observacao)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Os.Codigo = Convert.ToInt32(codigo);
                    //
                    if (observacao == "" || observacao == null)
                    {
                        Os.Observacao = "null";
                    }
                    else
                    {
                        Os.Observacao = observacao.Insert(observacao.Length, "'").Insert(0, "'");
                    }
                    //    
                    con.Alterar_OS_Observacao(Os);
                }
            }
        }

        public static void Alterar_OS_Valores(string codigo, string valor_real, string valor_servicos, string valor_produtos, string valor_total)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Os.Codigo = Convert.ToInt32(codigo);
                    //
                    if (valor_real.Contains("."))
                    {
                        Os.Valor_Real = Convert.ToDecimal(valor_real.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Real = Convert.ToDecimal(valor_real.Replace(",", "."));
                    }
                    //
                    if (valor_servicos.Contains("."))
                    {
                        Os.Valor_Servicos = Convert.ToDecimal(valor_servicos.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Servicos = Convert.ToDecimal(valor_servicos.Replace(",", "."));
                    }
                    //
                    if (valor_produtos.Contains("."))
                    {
                        Os.Valor_Produtos = Convert.ToDecimal(valor_produtos.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Produtos = Convert.ToDecimal(valor_produtos.Replace(",", "."));
                    }
                    //
                    if (valor_total.Contains("."))
                    {
                        Os.Valor_Total = Convert.ToDecimal(valor_total.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Os.Valor_Total = Convert.ToDecimal(valor_total.Replace(",", "."));
                    }
                    //
                    con.Alterar_OS_Valores(Os);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static string Sel_Ultimo_Cod_OS_Adicionado()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Ultimo_Cod_OS_Adicionado();
            }
        }

        public static void Salvar_Items_Servico_Valor_Desc_Acresc_Temp(string item, string cod_servico, string desc_servico, string valor_unitario, string cod_conexao_configuracoes, string quantidade, string comissao_porc, string valor_desconto, string valor_acrescimo, string valor_total_a_desc_acresc, string cod_orcamento)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Servico_Temp Items = new Item_Servico_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Codigo = Convert.ToInt16(item);
                    //
                    Items.Cod_Servico = Convert.ToInt32(cod_servico);
                    //
                    Items.Desc_Servico = desc_servico.Insert(desc_servico.Length, "'").Insert(0, "'");
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));
                    }
                    //
                    if (quantidade.Contains("."))
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    if (comissao_porc.Contains("."))
                    {
                        Items.Comissao_Porc = Convert.ToDecimal(comissao_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Comissao_Porc = Convert.ToDecimal(comissao_porc.Replace(",", "."));
                    }
                    //
                    if (valor_acrescimo.Contains("."))
                    {
                        Items.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(",", "."));
                    }
                    //
                    if (valor_desconto.Contains("."))
                    {
                        Items.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                    }
                    //
                    if (valor_total_a_desc_acresc.Contains("."))
                    {
                        Items.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(valor_total_a_desc_acresc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(valor_total_a_desc_acresc.Replace(",", "."));
                    }
                    //
                    Items.Cod_Orcamento = Convert.ToInt32(cod_orcamento);
                    //
                    con.Salvar_Items_Servico_Temp(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Items_Servico_Temp(string item, string cod_servico, string desc_servico, string valor_unitario, string cod_conexao_configuracoes, string quantidade, string comissao_porc, string desconto_porc, string acrescimo_porc, string cod_orcamento)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Servico_Temp Items = new Item_Servico_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Codigo = Convert.ToInt16(item);
                    //
                    Items.Cod_Servico = Convert.ToInt32(cod_servico);
                    //
                    Items.Desc_Servico = desc_servico.Insert(desc_servico.Length, "'").Insert(0, "'");
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));
                    }
                    //
                    if (quantidade.Contains("."))
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    if (comissao_porc.Contains("."))
                    {
                        Items.Comissao_Porc = Convert.ToDecimal(comissao_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Comissao_Porc = Convert.ToDecimal(comissao_porc.Replace(",", "."));
                    }
                    //
                    if (acrescimo_porc.Contains("."))
                    {
                        decimal perc_acresc = Convert.ToDecimal(acrescimo_porc.Replace(".", "").Replace(",", ".")) / 100;
                        Items.Valor_Acrescimo = (perc_acresc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    else
                    {
                        decimal perc_acresc = Convert.ToDecimal(acrescimo_porc.Replace(",", ".")) / 100;
                        Items.Valor_Acrescimo = (perc_acresc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    //
                    if (desconto_porc.Contains("."))
                    {
                        decimal perc_desc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", ".")) / 100;
                        Items.Valor_Desconto = (perc_desc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    else
                    {
                        decimal perc_desc = Convert.ToDecimal(desconto_porc.Replace(",", ".")) / 100;
                        Items.Valor_Desconto = (perc_desc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    //
                    Items.Valor_Total_A_Desc_Acresc = (Items.Valor_Unitario * Items.Quantidade) + Items.Valor_Acrescimo - Items.Valor_Desconto;
                    //
                    Items.Cod_Orcamento = Convert.ToInt32(cod_orcamento);
                    //
                    con.Salvar_Items_Servico_Temp(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Items_Servico_Con(string item, string cod_servico, string desc_servico, string valor_unitario, string cod_os, string quantidade, string comissao_porc, string valor_desconto, string valor_acrescimo, string valor_total_a_desc_acresc, string cod_orcamento)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Servico Items = new Item_Servico())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Cod_Item = Convert.ToInt16(item);
                    //
                    Items.Cod_Servico = Convert.ToInt32(cod_servico);
                    //
                    Items.Desc_Servico = desc_servico.Insert(desc_servico.Length, "'").Insert(0, "'");
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));
                    }
                    //
                    Items.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    if (quantidade.Contains("."))
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    if (comissao_porc.Contains("."))
                    {
                        Items.Comissao_Porc = Convert.ToDecimal(comissao_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Comissao_Porc = Convert.ToDecimal(comissao_porc.Replace(",", "."));
                    }
                    //
                    if (valor_acrescimo.Contains("."))
                    {
                        Items.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(",", "."));
                    }
                    //
                    if (valor_desconto.Contains("."))
                    {
                        Items.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                    }
                    //
                    if (valor_total_a_desc_acresc.Contains("."))
                    {
                        Items.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(valor_total_a_desc_acresc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(valor_total_a_desc_acresc.Replace(",", "."));
                    }
                    //
                    Items.Cod_Orcamento = Convert.ToInt32(cod_orcamento);
                    //
                    con.Salvar_Items_Servico_Con(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Items_Servico_Valor_Desc_Acresc(string item, string cod_servico, string desc_servico, string valor_unitario, string cod_os, string quantidade, string comissao_porc, string valor_desconto, string valor_acrescimo, string cod_orcamento, string valor_total_a_desc_acresc)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Servico Items = new Item_Servico())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Cod_Item = Convert.ToInt16(item);
                    //
                    Items.Cod_Servico = Convert.ToInt32(cod_servico);
                    //
                    Items.Desc_Servico = desc_servico.Insert(desc_servico.Length, "'").Insert(0, "'");
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));
                    }
                    //
                    Items.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    if (quantidade.Contains("."))
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    if (comissao_porc.Contains("."))
                    {
                        Items.Comissao_Porc = Convert.ToDecimal(comissao_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Comissao_Porc = Convert.ToDecimal(comissao_porc.Replace(",", "."));
                    }
                    //
                    if (valor_acrescimo.Contains("."))
                    {
                        Items.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(",", "."));
                    }
                    //
                    if (valor_desconto.Contains("."))
                    {
                        Items.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                    }
                    //
                    if (valor_total_a_desc_acresc.Contains("."))
                    {
                        Items.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(valor_total_a_desc_acresc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(valor_total_a_desc_acresc.Replace(",", "."));
                    }  
                    //
                    Items.Cod_Orcamento = Convert.ToInt32(cod_orcamento);
                    //
                    con.Salvar_Items_Servico(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Items_Servico(string item, string cod_servico, string desc_servico, string valor_unitario, string cod_os, string quantidade, string comissao_porc, string desconto_porc, string acrescimo_porc, string cod_orcamento)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Servico Items = new Item_Servico())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Cod_Item = Convert.ToInt16(item);
                    //
                    Items.Cod_Servico = Convert.ToInt32(cod_servico);
                    //
                    Items.Desc_Servico = desc_servico.Insert(desc_servico.Length, "'").Insert(0, "'");
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));
                    }
                    //
                    Items.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    if (quantidade.Contains("."))
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    if (comissao_porc.Contains("."))
                    {
                        Items.Comissao_Porc = Convert.ToDecimal(comissao_porc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Comissao_Porc = Convert.ToDecimal(comissao_porc.Replace(",", "."));
                    }
                    //
                    if (acrescimo_porc.Contains("."))
                    {
                        decimal perc_acresc = Convert.ToDecimal(acrescimo_porc.Replace(".", "").Replace(",", ".")) / 100;
                        Items.Valor_Acrescimo = (perc_acresc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    else
                    {
                        decimal perc_acresc = Convert.ToDecimal(acrescimo_porc.Replace(",", ".")) / 100;
                        Items.Valor_Acrescimo = (perc_acresc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    //
                    if (desconto_porc.Contains("."))
                    {
                        decimal perc_desc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", ".")) / 100;
                        Items.Valor_Desconto = (perc_desc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    else
                    {
                        decimal perc_desc = Convert.ToDecimal(desconto_porc.Replace(",", ".")) / 100;
                        Items.Valor_Desconto = (perc_desc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    //
                    Items.Valor_Total_A_Desc_Acresc = (Items.Valor_Unitario * Items.Quantidade) + Items.Valor_Acrescimo - Items.Valor_Desconto;
                    //
                    Items.Cod_Orcamento = Convert.ToInt32(cod_orcamento);
                    //
                    con.Salvar_Items_Servico(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Items_OS_Funcionario_Temp(string item, string cod_funcionario, string nome_funcionario, string cod_conexao_configuracoes, string imagem_func)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_OS_Funcionario_Temp Items = new Item_OS_Funcionario_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Codigo = Convert.ToInt16(item);
                    //
                    Items.Cod_Funcionario = Convert.ToInt32(cod_funcionario);
                    //
                    Items.Nome_Funcionario = nome_funcionario.Insert(nome_funcionario.Length, "'").Insert(0, "'");
                    //
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    if (imagem_func == "")
                    {
                        Items.Imagem_Func = "null";
                    }
                    else
                    {
                        Items.Imagem_Func = imagem_func.Insert(imagem_func.Length, "'").Insert(0, "'");
                    }
                    //
                    con.Salvar_Item_OS_Funcionario_Temp(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Items_OS_Funcionario(string item, string cod_funcionario, string nome_funcionario, string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_OS_Funcionario Items = new Item_OS_Funcionario())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Cod_Item = Convert.ToInt16(item);
                    //
                    Items.Cod_Funcionario = Convert.ToInt32(cod_funcionario);
                    //
                    Items.Nome_Funcionario = nome_funcionario.Insert(nome_funcionario.Length, "'").Insert(0, "'");
                    //
                    Items.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    con.Salvar_Item_OS_Funcionario(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Items_OS_Produto_Valor_Desc_Acresc_Temp(string item, string cod_produto, string descricao, string valor_unitario, string um, string quantidade, string valor_acrescimo, string valor_desconto, string valor_total_a_desc_acresc, string cod_conexao_configuracoes, string cod_orcamento)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_OS_Produto_Temp Items = new Item_OS_Produto_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Codigo = Convert.ToInt16(item);
                    //
                    Items.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    Items.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));
                    }
                    //
                    if (quantidade.Contains("."))
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    Items.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (valor_acrescimo.Contains("."))
                    {
                        Items.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(",", "."));
                    }
                    //
                    if (valor_desconto.Contains("."))
                    {
                        Items.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                    }
                    //
                    if (valor_total_a_desc_acresc.Contains("."))
                    {
                        Items.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(valor_total_a_desc_acresc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(valor_total_a_desc_acresc.Replace(",", "."));
                    }
                    //
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    Items.Cod_Orcamento = Convert.ToInt32(cod_orcamento);
                    //
                    con.Salvar_Item_OS_Produto_Temp(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Items_OS_Produto_Temp(string item, string cod_produto, string descricao, string valor_unitario, string um, string quantidade, string acrescimo_porc, string desconto_porc, string cod_conexao_configuracoes, string cod_orcamento)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_OS_Produto_Temp Items = new Item_OS_Produto_Temp())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Codigo = Convert.ToInt16(item);
                    //
                    Items.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    Items.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));
                    }
                    //
                    if (quantidade.Contains("."))
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    Items.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (acrescimo_porc.Contains("."))
                    {
                        decimal perc_acresc = Convert.ToDecimal(acrescimo_porc.Replace(".", "").Replace(",", ".")) / 100;
                        Items.Valor_Acrescimo = (perc_acresc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    else
                    {
                        decimal perc_acresc = Convert.ToDecimal(acrescimo_porc.Replace(",", ".")) / 100;
                        Items.Valor_Acrescimo = (perc_acresc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    //
                    if (desconto_porc.Contains("."))
                    {
                        decimal perc_desc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", ".")) / 100;
                        Items.Valor_Desconto = (perc_desc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    else
                    {
                        decimal perc_desc = Convert.ToDecimal(desconto_porc.Replace(",", ".")) / 100;
                        Items.Valor_Desconto = (perc_desc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    //
                    Items.Valor_Total_A_Desc_Acresc = (Items.Valor_Unitario * Items.Quantidade) + Items.Valor_Acrescimo - Items.Valor_Desconto;
                    //
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    Items.Cod_Orcamento = Convert.ToInt32(cod_orcamento);
                    //
                    con.Salvar_Item_OS_Produto_Temp(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Items_OS_Produto_Con(string item, string cod_produto, string descricao, string valor_unitario, string um, string quantidade, string valor_acrescimo, string valor_desconto, string cod_os, string valor_total_a_desc_acresc, string cod_orcamento)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_OS_Produto Items = new Item_OS_Produto())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Cod_Item = Convert.ToInt16(item);
                    //
                    Items.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    Items.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));
                    }
                    //
                    if (quantidade.Contains("."))
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    Items.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (valor_acrescimo.Contains("."))
                    {
                        Items.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(",", "."));
                    }
                    //
                    if (valor_desconto.Contains("."))
                    {
                        Items.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                    }
                    //
                    if (valor_total_a_desc_acresc.Contains("."))
                    {
                        Items.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(valor_total_a_desc_acresc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(valor_total_a_desc_acresc.Replace(",", "."));
                    }
                    //
                    Items.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    Items.Cod_Orcamento = Convert.ToInt32(cod_orcamento);
                    //
                    con.Salvar_Item_OS_Produto(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Items_OS_Produto_Valor_Desc_Acresc(string item, string cod_produto, string descricao, string valor_unitario, string um, string quantidade, string valor_acrescimo, string valor_desconto, string cod_os, string cod_orcamento, string valor_total_a_desc_acresc)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_OS_Produto Items = new Item_OS_Produto())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Cod_Item = Convert.ToInt16(item);
                    //
                    Items.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    Items.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));
                    }
                    //
                    if (quantidade.Contains("."))
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    Items.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (valor_acrescimo.Contains("."))
                    {
                        Items.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Acrescimo = Convert.ToDecimal(valor_acrescimo.Replace(",", "."));
                    }
                    //
                    if (valor_desconto.Contains("."))
                    {
                        Items.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Desconto = Convert.ToDecimal(valor_desconto.Replace(",", "."));
                    }
                    //
                    if (valor_total_a_desc_acresc.Contains("."))
                    {
                        Items.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(valor_total_a_desc_acresc.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Total_A_Desc_Acresc = Convert.ToDecimal(valor_total_a_desc_acresc.Replace(",", "."));
                    }
                    //
                    Items.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    Items.Cod_Orcamento = Convert.ToInt32(cod_orcamento);
                    //
                    con.Salvar_Item_OS_Produto(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Salvar_Items_OS_Produto(string item, string cod_produto, string descricao, string valor_unitario, string um, string quantidade, string acrescimo_porc, string desconto_porc, string cod_os, string cod_orcamento)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_OS_Produto Items = new Item_OS_Produto())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Items.Cod_Item = Convert.ToInt16(item);
                    //
                    Items.Cod_Produto = Convert.ToInt32(cod_produto);
                    //
                    Items.Descricao = descricao.Insert(descricao.Length, "'").Insert(0, "'");
                    //
                    if (valor_unitario.Contains("."))
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Valor_Unitario = Convert.ToDecimal(valor_unitario.Replace(",", "."));
                    }
                    //
                    if (quantidade.Contains("."))
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Items.Quantidade = Convert.ToDecimal(quantidade.Replace(",", "."));
                    }
                    //
                    Items.Valor_Total = Items.Valor_Unitario * Items.Quantidade;
                    //
                    Items.UM = um.Insert(um.Length, "'").Insert(0, "'");
                    //
                    if (acrescimo_porc.Contains("."))
                    {
                        decimal perc_acresc = Convert.ToDecimal(acrescimo_porc.Replace(".", "").Replace(",", ".")) / 100;
                        Items.Valor_Acrescimo = (perc_acresc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    else
                    {
                        decimal perc_acresc = Convert.ToDecimal(acrescimo_porc.Replace(",", ".")) / 100;
                        Items.Valor_Acrescimo = (perc_acresc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    //
                    if (desconto_porc.Contains("."))
                    {
                        decimal perc_desc = Convert.ToDecimal(desconto_porc.Replace(".", "").Replace(",", ".")) / 100;
                        Items.Valor_Desconto = (perc_desc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    else
                    {
                        decimal perc_desc = Convert.ToDecimal(desconto_porc.Replace(",", ".")) / 100;
                        Items.Valor_Desconto = (perc_desc * Items.Valor_Unitario) * Items.Quantidade;
                    }
                    //
                    Items.Valor_Total_A_Desc_Acresc = (Items.Valor_Unitario * Items.Quantidade) + Items.Valor_Acrescimo - Items.Valor_Desconto;
                    //
                    Items.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    Items.Cod_Orcamento = Convert.ToInt32(cod_orcamento);
                    //
                    con.Salvar_Item_OS_Produto(Items);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static DataTable Sel_Item_Servico_Temp_Todos(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Servico_Temp Items = new Item_Servico_Temp())
                {
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    return con.Sel_Item_Servico_Temp_Todos(Items);
                }
            }
        }

        public static DataTable Sel_Item_Servico_Todos(string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Servico Items = new Item_Servico())
                {
                    Items.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    return con.Sel_Item_Servico_Todos(Items);
                }
            }
        }

        public static DataTable Sel_Item_OS_Funcionario_Temp_Todos(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_OS_Funcionario_Temp Items = new Item_OS_Funcionario_Temp())
                {
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    return con.Sel_Item_OS_Funcionario_Temp_Todos(Items);
                }
            }
        }

        public static DataTable Sel_Item_OS_Funcionario_Todos(string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_OS_Funcionario Items = new Item_OS_Funcionario())
                {
                    Items.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    return con.Sel_Item_OS_Funcionario_Todos(Items);
                }
            }
        }

        public static DataTable Sel_Item_OS_Produto_Temp_Todos(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Servico_Temp Items = new Item_Servico_Temp())
                {
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    return con.Sel_Item_OS_Produto_Temp_Todos(Items);
                }
            }
        }

        public static DataTable Sel_Item_OS_Produto_Todos(string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Servico Items = new Item_Servico())
                {
                    Items.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    return con.Sel_Item_OS_Produto_Todos(Items);
                }
            }
        }

        public static void Excluir_Items_OS_Produto(string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Os.Codigo = Convert.ToInt32(cod_os);
                    //
                    con.Excluir_Items_OS_Produto(Os);
                }
            }
        }

        public static void Excluir_Items_OS_Servico(string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Os.Codigo = Convert.ToInt32(cod_os);
                    //
                    con.Excluir_Items_OS_Servico(Os);
                }
            }
        }

        public static void Excluir(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Os.Codigo = Convert.ToInt32(codigo);
                    con.Excluir_OS(Os);
                }
            }
        }

        public static void Excluir_Items_OS_Funcionario(string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Os.Codigo = Convert.ToInt32(cod_os);
                    //
                    con.Excluir_Items_OS_Funcionario(Os);
                }
            }
        }

        public static void Excluir_Item_NFSe_OS(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (NFSE Nfse = new NFSE())
                {
                    Nfse.Codigo = Convert.ToInt32(codigo);
                    //
                    con.Excluir_Item_NFSe_OS(Nfse);
                }
            }
        }

        public static void Excluir_NFSe_OS(string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Os.Codigo = Convert.ToInt32(cod_os);
                    //
                    con.Excluir_NFSe_OS(Os);
                }
            }
        }

        public static void Excluir_Pagamento_OS(string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    Os.Codigo = Convert.ToInt32(cod_os);
                    //
                    con.Excluir_Pagamento_OS(Os);
                }
            }
        }

        public static void Excluir_Pagamento_OS_Item(string cod_os, string cod_item_pagamento)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Pagamento_OS Os = new Pagamento_OS())
                {
                    Os.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    Os.Codigo = Convert.ToInt16(cod_item_pagamento);
                    //
                    con.Excluir_Pagamento_OS_Item(Os);
                }
            }
        }

        public static void Excluir_Item_Servico_Todos_Temp(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Servico_Temp Items = new Item_Servico_Temp())
                {
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Item_Servico_Todos_Temp(Items);
                }
            }
        }

        public static void Excluir_Item_OS_Produto_Todos_Temp(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Servico_Temp Items = new Item_Servico_Temp())
                {
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Item_OS_Produto_Todos_Temp(Items);
                }
            }
        }

        public static void Excluir_Item_OS_Funcionario_Todos_Temp(string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_OS_Funcionario_Temp Items = new Item_OS_Funcionario_Temp())
                {
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Item_OS_Funcionario_Todos_Temp(Items);
                }
            }
        }

        public static void Excluir_Item_Servico_Temp(string codigo, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Servico_Temp Items = new Item_Servico_Temp())
                {
                    Items.Codigo = Convert.ToInt16(codigo);
                    //
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Item_Servico_Temp(Items);
                }
            }
        }

        public static void Excluir_Item_Servico(string cod_item, string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Servico Items = new Item_Servico())
                {
                    Items.Cod_Item = Convert.ToInt16(cod_item);
                    //
                    Items.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    con.Excluir_Item_Servico(Items);
                }
            }
        }

        public static void Excluir_Item_OS_Produto(string cod_item, string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_OS_Produto Items = new Item_OS_Produto())
                {
                    Items.Cod_Item = Convert.ToInt16(cod_item);
                    //
                    Items.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    con.Excluir_Item_OS_Produto(Items);
                }
            }
        }

        public static void Excluir_Item_OS_Produto_Temp(string codigo, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_OS_Produto_Temp Items = new Item_OS_Produto_Temp())
                {
                    Items.Codigo = Convert.ToInt16(codigo);
                    //
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Item_OS_Produto_Temp(Items);
                }
            }
        }

        public static void Excluir_Item_OS_Funcionario_Temp(string codigo, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_OS_Funcionario_Temp Items = new Item_OS_Funcionario_Temp())
                {
                    Items.Codigo = Convert.ToInt16(codigo);
                    //
                    Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                    //
                    con.Excluir_Item_OS_Funcionario_Temp(Items);
                }
            }
        }

        public static void Excluir_Item_OS_Funcionario(string codigo, string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_OS_Funcionario Items = new Item_OS_Funcionario())
                {
                    Items.Cod_Item = Convert.ToInt16(codigo);
                    //
                    Items.Cod_OS = Convert.ToInt32(cod_os);
                    //
                    con.Excluir_Item_OS_Funcionario(Items);
                }
            }
        }

        public static void Atualizar_Item_Dt_Item_Servico_Temp(int item_atual, int total_item, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_Servico_Temp Items = new Item_Servico_Temp())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Items.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                        con.Atualizar_Item_Dt_Item_Servico_Temp(Items, item.ToString());
                    }
                }
            }
        }

        public static void Atualizar_Item_Dt_Item_Servico(int item_atual, int total_item, string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_Servico Items = new Item_Servico())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Items.Cod_Item = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        Items.Cod_OS = Convert.ToInt32(cod_os);
                        con.Atualizar_Item_Dt_Item_Servico(Items, item.ToString());
                    }
                }
            }
        }

        public static void Atualizar_Item_Dt_Item_OS_Produto(int item_atual, int total_item, string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_OS_Produto Items = new Item_OS_Produto())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Items.Cod_Item = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        Items.Cod_OS = Convert.ToInt32(cod_os);
                        con.Atualizar_Item_Dt_Item_OS_Produto(Items, item.ToString());
                    }
                }
            }
        }

        public static void Atualizar_Item_Dt_Item_OS_Produto_Temp(int item_atual, int total_item, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_OS_Produto_Temp Items = new Item_OS_Produto_Temp())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Items.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                        con.Atualizar_Item_Dt_Item_OS_Produto_Temp(Items, item.ToString());
                    }
                }
            }
        }

        public static void Atualizar_Item_Dt_Item_OS_Funcionario_Temp(int item_atual, int total_item, string cod_conexao_configuracoes)
        {
            using (ConOperationBD con = new ConOperationBD())
            {
                using (Item_OS_Funcionario_Temp Items = new Item_OS_Funcionario_Temp())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Items.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        Items.Cod_Conexao_Configuracoes = Convert.ToInt16(cod_conexao_configuracoes);
                        con.Atualizar_Item_Dt_Item_OS_Funcionario_Temp(Items, item.ToString());
                    }
                }
            }
        }

        public static void Atualizar_Item_Dt_Item_OS_Funcionario(int item_atual, int total_item, string cod_os)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Item_OS_Funcionario Items = new Item_OS_Funcionario())
                {
                    for (int i = item_atual; i < total_item; i++)
                    {
                        short item;
                        Items.Codigo = Convert.ToInt16(i);
                        item = Convert.ToInt16(i + 1);
                        Items.Cod_OS = Convert.ToInt32(cod_os);
                        con.Atualizar_Item_Dt_Item_OS_Funcionario(Items, item.ToString());
                    }
                }
            }
        }

        public static string Sel_OS_Data_Codigo_Clie_Func_Usuario_Situacao_Data_Baixa_Soma(string situacao, string usuario, string codigo, string data, string data1, string horario, string horario1, string cliente, string funcionario, string databaixa, string databaixa1, string horariobaixa, string horariobaixa1, string forma_pagamento, string cod_orcamento, string servico, string produto)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    string SqlCodigo;
                    string SqlData;
                    string SqlCliente;
                    string SqlFuncionario;
                    string SqlSituacao;
                    string SqlUsuario;
                    string SqlDataBaixa;
                    string SqlFormaPagamento;
                    string SqlOrcamento;
                    string SqlServico;
                    string SqlProduto;
                    //
                    string[] items;
                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "WHERE os.data BETWEEN '21.07.2024 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
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
                        SqlData = "WHERE os.data BETWEEN '" + data.Replace("/", ".") + horario + "' AND '" + data1.Replace("/", ".") + horario1 + "'";
                    }
                    //
                    if (databaixa.Contains("_") || databaixa1.Contains("_"))
                    {
                        SqlDataBaixa = "";
                    }
                    else
                    {
                        if (horariobaixa.Contains("_"))
                        {
                            horariobaixa = "";
                        }
                        else
                        {
                            horariobaixa = " " + horariobaixa;
                        }
                        //
                        if (horariobaixa1.Contains("_"))
                        {
                            horariobaixa1 = " 23:59:59";
                        }
                        else
                        {
                            horariobaixa1 = " " + horariobaixa1;
                        }
                        //
                        SqlDataBaixa = " AND pagamento_os.data_pagamento BETWEEN '" + databaixa.Replace("/", ".") + horariobaixa + "' AND '" + databaixa1.Replace("/", ".") + horariobaixa1 + "'";
                    }
                    //
                    if (codigo == null || codigo == "")
                    {
                        SqlCodigo = "";
                    }
                    else
                    {
                        SqlCodigo = " AND os.id_os='" + codigo + "'";
                    }
                    //
                    if (situacao == null || situacao == "")
                    {
                        SqlSituacao = "";

                    }
                    else
                    {
                        SqlSituacao = " AND os.situacao='" + situacao + "'";
                    }
                    //
                    if (cliente == null || cliente == "")
                    {
                        SqlCliente = "";
                    }
                    else
                    {
                        items = cliente.Split('—');
                        //
                        SqlCliente = " AND os.id_consumidor='" + items[0] + "'";
                    }
                    //
                    if (usuario == null || usuario == "")
                    {
                        SqlUsuario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        //
                        SqlUsuario = " AND os.id_usuario='" + items[0] + "'";
                    }
                    //
                    if (funcionario == null || funcionario == "")
                    {
                        SqlFuncionario = "";
                    }
                    else
                    {
                        items = funcionario.Split('—');
                        //
                        SqlFuncionario = " AND item_os_funcionario.id_funcionario='" + items[0] + "'";
                    }
                    //
                    if (forma_pagamento == null || forma_pagamento == "")
                    {
                        SqlFormaPagamento = "";
                    }
                    else
                    {
                        items = forma_pagamento.Split('—');
                        //
                        SqlFormaPagamento = " AND pagamento_os.id_pagamento='" + items[0] + "'";
                    }
                    //
                    if (cod_orcamento == null || cod_orcamento == "")
                    {
                        SqlOrcamento = "";
                    }
                    else
                    {
                        SqlOrcamento = " AND item_servico.id_orcamento='" + cod_orcamento + "'";
                    }
                    //
                    if (servico == null || servico == "")
                    {
                        SqlServico = "";
                    }
                    else
                    {
                        items = servico.Split('—');
                        //
                        SqlServico = " AND item_servico.id_servico='" + items[0] + "'";
                    }
                    //
                    if (produto == null || produto == "")
                    {
                        SqlProduto = "";
                    }
                    else
                    {
                        items = produto.Split('—');
                        //
                        SqlProduto = " AND item_os_produto.id_produto='" + items[0] + "'";
                    }
                    //
                    if (con.Sel_OS_Data_Codigo_Clie_Func_Usuario_Situacao_Data_Baixa_Soma(SqlSituacao, SqlUsuario, SqlCodigo, SqlData, SqlCliente, SqlFuncionario, SqlDataBaixa, SqlFormaPagamento, SqlOrcamento, SqlServico, SqlProduto) == null)
                    {
                        return null;
                    }
                    else
                    {
                        decimal soma = 0;
                        //
                        for (int i = 0; i < con.Sel_OS_Data_Codigo_Clie_Func_Usuario_Situacao_Data_Baixa_Soma(SqlSituacao, SqlUsuario, SqlCodigo, SqlData, SqlCliente, SqlFuncionario, SqlDataBaixa, SqlFormaPagamento, SqlOrcamento, SqlServico, SqlProduto).Rows.Count; i++)
                        {
                            DataRow dr = con.Sel_OS_Data_Codigo_Clie_Func_Usuario_Situacao_Data_Baixa_Soma(SqlSituacao, SqlUsuario, SqlCodigo, SqlData, SqlCliente, SqlFuncionario, SqlDataBaixa, SqlFormaPagamento, SqlOrcamento, SqlServico, SqlProduto).Rows[i];
                            //
                            soma = soma + Convert.ToDecimal(dr["soma"]); 
                        }
                        //
                        return soma.ToString();
                    }
                }
            }
        }

        public static DataTable Sel_OS_Data_Codigo_Clie_Func_Usuario_Situacao_Data_Baixa(string situacao, string usuario, string codigo, string data, string data1, string horario, string horario1, string cliente, string funcionario, string databaixa, string databaixa1, string horariobaixa, string horariobaixa1, string forma_pagamento, string cod_orcamento, string servico, string produto)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS())
                {
                    string SqlCodigo;
                    string SqlData;
                    string SqlCliente;
                    string SqlFuncionario;
                    string SqlSituacao;
                    string SqlUsuario;
                    string SqlDataBaixa;
                    string SqlFormaPagamento;
                    string SqlOrcamento;
                    string SqlProduto;
                    string SqlServico;
                    //
                    string[] items;
                    if (data.Contains("_") || data1.Contains("_"))
                    {
                        SqlData = "WHERE os.data BETWEEN '21.07.2024 00:00:00' AND '" + DateTime.Now.ToString().Replace('/', '.') + "'";
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
                        SqlData = "WHERE os.data BETWEEN '" + data.Replace("/", ".") + horario + "' AND '" + data1.Replace("/", ".") + horario1 + "'";
                    }
                    //
                    if (databaixa.Contains("_") || databaixa1.Contains("_"))
                    {
                        SqlDataBaixa = "";
                    }
                    else
                    {
                        if (horariobaixa.Contains("_"))
                        {
                            horariobaixa = "";
                        }
                        else
                        {
                            horariobaixa = " " + horariobaixa;
                        }
                        //
                        if (horariobaixa1.Contains("_"))
                        {
                            horariobaixa1 = " 23:59:59";
                        }
                        else
                        {
                            horariobaixa1 = " " + horariobaixa1;
                        }
                        //
                        SqlDataBaixa = " AND pagamento_os.data_pagamento BETWEEN '" + databaixa.Replace("/", ".") + horariobaixa + "' AND '" + databaixa1.Replace("/", ".") + horariobaixa1 + "'";
                    }
                    //
                    if (codigo == null || codigo == "")
                    {
                        SqlCodigo = "";

                    }
                    else
                    {
                        SqlCodigo = " AND os.id_os='" + codigo + "'";
                    }
                    //
                    if (situacao == null || situacao == "")
                    {
                        SqlSituacao = "";

                    }
                    else
                    {
                        SqlSituacao = " AND os.situacao='" + situacao + "'";
                    }
                    //
                    if (cliente == null || cliente == "")
                    {
                        SqlCliente = "";
                    }
                    else
                    {
                        items = cliente.Split('—');
                        //
                        SqlCliente = " AND os.id_consumidor='" + items[0] + "'";
                    }
                    //
                    if (usuario == null || usuario == "")
                    {
                        SqlUsuario = "";
                    }
                    else
                    {
                        items = usuario.Split('—');
                        //
                        SqlUsuario = " AND os.id_usuario='" + items[0] + "'";
                    }
                    //
                    if (funcionario == null || funcionario == "")
                    {
                        SqlFuncionario = "";
                    }
                    else
                    {
                        items = funcionario.Split('—');
                        //
                        SqlFuncionario = " AND item_os_funcionario.id_funcionario='" + items[0] + "'";
                    }
                    //
                    if (forma_pagamento == null || forma_pagamento == "")
                    {
                        SqlFormaPagamento = "";
                    }
                    else
                    {
                        items = forma_pagamento.Split('—');
                        //
                        SqlFormaPagamento = " AND pagamento_os.id_pagamento='" + items[0] + "'";
                    }
                    //
                    if (cod_orcamento == null || cod_orcamento == "")
                    {
                        SqlOrcamento = "";
                    }
                    else
                    {
                        SqlOrcamento = " AND item_servico.id_orcamento='" + cod_orcamento + "'";
                    }
                    //
                    if (servico == null || servico == "")
                    {
                        SqlServico = "";
                    }
                    else
                    {
                        items = servico.Split('—');
                        //
                        SqlServico = " AND item_servico.id_servico='" + items[0] + "'";
                    }
                    //
                    if (produto == null || produto == "")
                    {
                        SqlProduto = "";
                    }
                    else
                    {
                        items = produto.Split('—');
                        //
                        SqlProduto = " AND item_os_produto.id_produto='" + items[0] + "'";
                    }
                    //
                    return con.Sel_OS_Data_Codigo_Clie_Func_Usuario_Situacao_Data_Baixa(SqlSituacao, SqlUsuario, SqlCodigo, SqlData, SqlCliente, SqlFuncionario, SqlDataBaixa, SqlFormaPagamento, SqlOrcamento, SqlServico, SqlProduto);
                }
            }
        }

        public static DataTable Sel_OS_Codigo(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (OS Os = new OS()) 
                {
                    Os.Pesquisar = pesquisar;
                    return con.Sel_OS_Codigo(Os);
                }
            }
        }

        public static DataTable Sel_Forma_Pagamento_OS()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Forma_Pagamento_OS();
            }
        }
        

    }
}
