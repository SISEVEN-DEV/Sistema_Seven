using DAL;
using System;
using System.Data;
using System.Globalization;
using System.Threading;

namespace BLL
{
    public class bllUsuario
    {
        public static bool _FrmCadUsuario_Ativo;
        public static bool _FrmRelUsuario_Ativo;
        public static string Nome_Usuario_Logado;
        public static string _User_PesqFuncionario_Tabela;
        public static bool _Funcoes_Salvas;
        public static bool _Funcoes_Iniciais = false;
        //
        public static string _Data_DatePicker1;
        public static string _Data_DatePicker2;
        //
        public static string _Tipo_Impressao;
        public static string _Impressora;
        public static string _Numero_Copias;
        public static bool _Mostrar_Logo_Marca_Imp;
        //
        public static bool _Realizar_Orcamento;
        public static bool _Realizar_Devolucao;
        public static bool _Permitir_Canc_Exc_Item_Venda;
        public static bool _Capturar_Orcamento;
        public static bool _Capturar_Devolucao;
        public static bool _Permissao_Usuarios;
        public static bool _Permitir_Desc_Pag;
        public static bool _Permitir_Acresc_Pag;
        public static bool _Permitir_Fin_PDV;
        public static bool _Permitir_Alt_Prod_Item;
        public static bool _Mostrar_Dados_Prod_Item;
        public static string _Desconto_Porc_Max_Venda;
        public static string _Acrescimo_Porc_Max_Venda;
        public static bool _Permitir_Abrir_Caixa;
        public static bool _Permitir_Fechar_Caixa;
        public static bool _Permitir_Real_SangSup;
        public static bool _Permitir_Real_Conta_Receber;
        public static bool _Permitir_Real_Conta_Pagar;
        public static bool _Cadastrar_Cliente_Consumidor;
        public static bool _Cadastrar_Conta_Pagar;
        public static bool _Cadastrar_Conta_Receber;
        public static bool _Cadastrar_Entidade_Bancaria;
        public static bool _Cadastrar_Forma_Pagamento;
        public static bool _Cadastrar_Fornecedor;
        public static bool _Cadastrar_Funcionario;
        public static bool _Cadastrar_Grupo;
        public static bool _Cadastrar_Localizacao;
        public static bool _Cadastrar_Marca;
        public static bool _Cadastrar_DFe;
        public static bool _Cadastrar_Produto;
        public static bool _Cadastrar_Subgrupo;
        public static bool _Cadastrar_Usuario;
        public static bool _Cadastrar_Servico;
        public static bool _Cadastrar_CFOP_NatOp;
        public static bool _Permitir_Pausar_Caixa;
        public static bool _Permitir_Vis_Hist_Caixa;
        public static bool _Permitir_Cad_No_Pdv;
        public static bool _Permitir_Venda_N_Prom_S_Credito;
        public static bool _Rel_Abert_Fech_Caixa;
        public static bool _Rel_Cliente_Consumidor;
        public static bool _Rel_Conta_Pagar;
        public static bool _Rel_Conta_Receber;
        public static bool _Rel_Produtos_Servico;
        public static bool _Rel_Orcamento;
        public static bool _Rel_Venda;
        public static bool _Rel_Grupo;
        public static bool _Rel_Funcionario;
        public static bool _Rel_DFe;
        public static bool _Rel_Formas_Pagamento;
        public static bool _Rel_Aniversariante;
        public static bool _Rel_Fornecedor;
        public static bool _Rel_Subgrupo;
        public static bool _Rel_Historico_Caixa;
        public static bool _Rel_Fluxo_Caixa;
        public static bool _Rel_Saida_Produto;
        public static bool _Rel_Entrada_Produto;
        public static bool _Rel_Sangria_Suprimento;
        public static bool _Rel_Devolucao_Servico;
        public static bool _Permitir_Vis_Senha_Usuario;
        public static bool _Permitir_Ignorar_Multa_Juros_Receber;
        public static bool _Permitir_Exc_Sang_Sup;
        public static bool _Rel_Usuario;
        public static bool _Rel_Marca;
        public static bool _Rel_Localizacao;
        public static bool _Permitir_Venda_S_Credito_Loja;
        public static bool _Permitir_Alt_Dados_Emp;
        public static bool _Permitir_Alt_Dados_Config;
        public static bool _Criar_Lembrete_Conta_Pagar;
        public static bool _Criar_Lembrete_Conta_Receber;
        public static bool _Criar_Conta_a_Pagar_DFe;
        public static bool _Criar_Lembrete_Validade;
        public static bool _Rel_Reg_Atividade;
        public static bool _Rel_Reg_Validade_Prod_Serv;
        public static bool _Permitir_Atualizar_Zerar_Estoque;
        public static bool _Rel_Estoque;
        public static bool _Permitir_Excluir_Inventario;
        public static bool _Capturar_Venda;
        public static bool _Permitir_Excluir_OS;
        public static bool _Cadastrar_OS;
        public static bool _Cadastrar_PSPPIX;
        public static bool _Acessar_Menu_NFe_NFCe;
        public static bool _Acessar_Menu_NFSe;
        public static bool _Cadastrar_NFe;
        public static bool _Rel_Comissao;
        public static bool _Rel_OS;
        public static bool _Rel_Controle_Cheque;
        public static bool _Cadastrar_Documentos;
        public static bool _Permitir_Desfazer_Baixa;

        public static void Salvar(string nome_usuario, string senha, string funcionario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    Users.Data_Cadastro = "'" + DateTime.Now.ToShortDateString().Replace('/', '.') + " 00:00:00'";
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Users.Nome_Usuario = nome_usuario.Insert(nome_usuario.Length, "'").Insert(0, "'");
                    Users.Senha = senha.Insert(senha.Length, "'").Insert(0, "'");
                    //
                    if (funcionario == "" || funcionario == null)
                    {
                        Users.Cod_Funcionario = 0;
                        Users.Nome_Funcionario = "null";
                    }
                    else
                    {
                        string[] items = funcionario.Split('—');
                        Users.Cod_Funcionario = Convert.ToInt16(items[0]);
                        Users.Nome_Funcionario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    if (_Funcoes_Iniciais == true)
                    {
                        Users.Realizar_Orcamento = 1;
                        Users.Realizar_Devolucao = 1;
                        Users.Permitir_Canc_Exc_Item_Venda = 1;
                        Users.Capturar_Orcamento = 1;
                        Users.Capturar_Devolucao = 1;
                        Users.Permissao_Usuarios = 0;
                        Users.Permitir_Desc_Pag = 1;
                        Users.Permitir_Acresc_Pag = 1;
                        Users.Permitir_Fin_PDV = 1;
                        Users.Permitir_Alt_Prod_Item = 1;
                        Users.Mostrar_Dados_Prod_Item = 0;
                        Users.Desconto_Porc_Max_Venda = 1;
                        Users.Acrescimo_Porc_Max_Venda = 1;
                        Users.Permitir_Abrir_Caixa = 1;
                        Users.Permitir_Fechar_Caixa = 1;
                        Users.Permitir_Real_SangSup = 1;
                        Users.Permitir_Real_Conta_Receber = 1;
                        Users.Permitir_Real_Conta_Pagar = 1;
                        Users.Cadastrar_Cliente_Consumidor = 1;
                        Users.Cadastrar_Conta_Pagar = 1;
                        Users.Cadastrar_Conta_Receber = 1;
                        Users.Cadastrar_Entidade_Bancaria = 1;
                        Users.Cadastrar_Forma_Pagamento = 1;
                        Users.Cadastrar_Fornecedor = 1;
                        Users.Cadastrar_Funcionario = 1;
                        Users.Cadastrar_Grupo = 1;
                        Users.Cadastrar_Localizacao = 1;
                        Users.Cadastrar_Marca = 1;
                        Users.Cadastrar_Produto = 1;
                        Users.Cadastrar_Subgrupo = 1;
                        Users.Cadastrar_Usuario = 1;
                        Users.Permitir_Pausar_Caixa = 1;
                        Users.Permitir_Vis_Hist_Caixa = 1;
                        Users.Permitir_Cad_No_Pdv = 1;
                        Users.Permitir_Venda_N_Promissoria_S_Credito = 1;
                        Users.Rel_Abert_Fech_Caixa = 1;
                        Users.Rel_Cliente_Consumidor = 1;
                        Users.Rel_Conta_Pagar = 1;
                        Users.Rel_Conta_Receber = 1;
                        Users.Rel_Produtos_Servico = 1;
                        Users.Rel_Orcamento = 1;
                        Users.Rel_Venda = 1;
                        Users.Rel_Grupo = 1;
                        Users.Rel_Funcionario = 1;
                        Users.Rel_Formas_Pagamento = 1;
                        Users.Rel_Fornecedor = 1;
                        Users.Rel_Subgrupo = 1;
                        Users.Rel_Historico_Caixa = 1;
                        Users.Rel_Fluxo_Caixa = 1;
                        Users.Rel_Saida_Produto = 1;
                        Users.Rel_Entrada_Produto = 1;
                        Users.Rel_Sangria_Suprimento = 1;
                        Users.Rel_Devolucao_Servico = 1;
                        Users.Permitir_Vis_Senha_Usuario = 1;
                        Users.Permitir_Ignorar_Multa_Juros_Receber = 0;
                        Users.Permitir_Exc_Sang_Sup = 1;
                        Users.Rel_Usuario = 1;
                        Users.Rel_Marca = 1;
                        Users.Rel_Localizacao = 1;
                        Users.Permitir_Venda_S_Credito_Loja = 1;
                        Users.Permitir_Alt_Dados_Emp = 1;
                        Users.Permitir_Alt_Dados_Config = 1;
                        Users.Criar_Lembrete_Conta_Pagar = 1;
                        Users.Criar_Lembrete_Conta_Receber = 1;
                        Users.Criar_Conta_a_Pagar_DFe = 1;
                        Users.Criar_Lembrete_Validade = 1;
                        Users.Cadastrar_CFOP_NatOp = 1;
                        Users.Rel_Aniversariante = 1;
                        Users.Rel_DFe = 1;
                        Users.Cadastrar_DFe = 1;
                        Users.Rel_Reg_Atividade = 1;
                        Users.Rel_Reg_Validade_Prod_Serv = 1;
                        Users.Permitir_Atualizar_Zerar_Estoque = 1;
                        Users.Rel_Estoque = 1;
                        Users.Permitir_Excluir_Inventario = 1;
                        Users.Capturar_Venda = 1;
                        Users.Cadastrar_Servico = 1;
                        Users.Permitir_Excluir_OS = 1;
                        Users.Cadastrar_OS = 1;
                        Users.Cadastrar_PSPPIX = 1;
                        Users.Acessar_Menu_NFe_NFCe = 1;
                        Users.Acessar_Menu_NFSe = 1;
                        Users.Cadastrar_NFe = 1;
                        Users.Rel_Comissao = 1;
                        Users.Rel_OS = 1;
                        Users.Rel_Controle_Cheque = 1;
                        Users.Cadastrar_Documentos = 1;
                        Users.Permitir_Desfazer_Baixa = 1;
                    }
                    else if (_Funcoes_Salvas == false)
                    {
                        Users.Realizar_Orcamento = 1;
                        Users.Realizar_Devolucao = 1;
                        Users.Permitir_Canc_Exc_Item_Venda = 1;
                        Users.Capturar_Orcamento = 1;
                        Users.Capturar_Devolucao = 1;
                        Users.Permissao_Usuarios = 0;
                        Users.Permitir_Desc_Pag = 0;
                        Users.Permitir_Acresc_Pag = 0;
                        Users.Permitir_Fin_PDV = 1;
                        Users.Permitir_Alt_Prod_Item = 1;
                        Users.Mostrar_Dados_Prod_Item = 0;
                        Users.Desconto_Porc_Max_Venda = 0;
                        Users.Acrescimo_Porc_Max_Venda = 0;
                        Users.Permitir_Abrir_Caixa = 1;
                        Users.Permitir_Fechar_Caixa = 1;
                        Users.Permitir_Real_SangSup = 0;
                        Users.Permitir_Real_Conta_Receber = 1;
                        Users.Permitir_Real_Conta_Pagar = 0;
                        Users.Cadastrar_Cliente_Consumidor = 1;
                        Users.Cadastrar_Conta_Pagar = 1;
                        Users.Cadastrar_Conta_Receber = 1;
                        Users.Cadastrar_Entidade_Bancaria = 1;
                        Users.Cadastrar_Forma_Pagamento = 0;
                        Users.Cadastrar_Fornecedor = 1;
                        Users.Cadastrar_Funcionario = 1;
                        Users.Cadastrar_Grupo = 1;
                        Users.Cadastrar_Localizacao = 1;
                        Users.Cadastrar_Marca = 1;
                        Users.Cadastrar_Produto = 1;
                        Users.Cadastrar_Subgrupo = 1;
                        Users.Cadastrar_Usuario = 1;
                        Users.Permitir_Pausar_Caixa = 1;
                        Users.Permitir_Vis_Hist_Caixa = 0;
                        Users.Permitir_Cad_No_Pdv = 1;
                        Users.Permitir_Venda_N_Promissoria_S_Credito = 0;
                        Users.Rel_Abert_Fech_Caixa = 0;
                        Users.Rel_Cliente_Consumidor = 1;
                        Users.Rel_Conta_Pagar = 0;
                        Users.Rel_Conta_Receber = 0;
                        Users.Rel_Produtos_Servico = 1;
                        Users.Rel_Orcamento = 1;
                        Users.Rel_Venda = 1;
                        Users.Rel_Grupo = 1;
                        Users.Rel_Funcionario = 0;
                        Users.Rel_Formas_Pagamento = 1;
                        Users.Rel_Fornecedor = 1;
                        Users.Rel_Subgrupo = 1;
                        Users.Rel_Historico_Caixa = 1;
                        Users.Rel_Fluxo_Caixa = 1;
                        Users.Rel_Saida_Produto = 1;
                        Users.Rel_Entrada_Produto = 1;
                        Users.Rel_Sangria_Suprimento = 0;
                        Users.Rel_Devolucao_Servico = 1;
                        Users.Permitir_Vis_Senha_Usuario = 0;
                        Users.Permitir_Ignorar_Multa_Juros_Receber = 0;
                        Users.Permitir_Exc_Sang_Sup = 0;
                        Users.Rel_Usuario = 0;
                        Users.Rel_Marca = 1;
                        Users.Rel_Localizacao = 1;
                        Users.Permitir_Venda_S_Credito_Loja = 0;
                        Users.Permitir_Alt_Dados_Emp = 0;
                        Users.Permitir_Alt_Dados_Config = 0;
                        Users.Criar_Lembrete_Conta_Pagar = 1;
                        Users.Criar_Lembrete_Conta_Receber = 0;
                        Users.Criar_Conta_a_Pagar_DFe = 1;
                        Users.Criar_Lembrete_Validade = 1;
                        Users.Cadastrar_CFOP_NatOp = 1;
                        Users.Rel_Aniversariante = 1;
                        Users.Rel_DFe = 1;
                        Users.Cadastrar_DFe = 1;
                        Users.Rel_Reg_Atividade = 1;
                        Users.Rel_Reg_Validade_Prod_Serv = 1;
                        Users.Permitir_Atualizar_Zerar_Estoque = 0;
                        Users.Rel_Estoque = 1;
                        Users.Permitir_Excluir_Inventario = 0;
                        Users.Capturar_Venda = 1;
                        Users.Cadastrar_Servico = 1;
                        Users.Permitir_Excluir_OS = 1;
                        Users.Cadastrar_OS = 1;
                        Users.Cadastrar_PSPPIX = 1;
                        Users.Acessar_Menu_NFe_NFCe = 1;
                        Users.Acessar_Menu_NFSe = 1;
                        Users.Cadastrar_NFe = 1;
                        Users.Rel_Comissao = 1;
                        Users.Rel_OS = 1;
                        Users.Rel_Controle_Cheque= 1;
                        Users.Cadastrar_Documentos = 1;
                        Users.Permitir_Desfazer_Baixa = 1;
                    }
                    else
                    {
                        if (_Permitir_Excluir_Inventario == true)
                        {
                            Users.Permitir_Excluir_Inventario = 1;
                        }
                        else
                        {
                            Users.Permitir_Excluir_Inventario = 0;
                        }
                        //
                        if (_Realizar_Orcamento == true)
                        {
                            Users.Realizar_Orcamento = 1;
                        }
                        else
                        {
                            Users.Realizar_Orcamento = 0;
                        }
                        //
                        if (_Realizar_Devolucao == true)
                        {
                            Users.Realizar_Devolucao = 1;
                        }
                        else
                        {
                            Users.Realizar_Devolucao = 0;
                        }
                        //
                        if (_Permitir_Canc_Exc_Item_Venda == true)
                        {
                            Users.Permitir_Canc_Exc_Item_Venda = 1;
                        }
                        else
                        {
                            Users.Permitir_Canc_Exc_Item_Venda = 0;
                        }
                        //
                        if (_Capturar_Orcamento == true)
                        {
                            Users.Capturar_Orcamento = 1;
                        }
                        else
                        {
                            Users.Capturar_Orcamento = 0;
                        }
                        //
                        if (_Capturar_Devolucao == true)
                        {
                            Users.Capturar_Devolucao = 1;
                        }
                        else
                        {
                            Users.Capturar_Devolucao = 0;
                        }
                        //
                        if (_Permissao_Usuarios == true)
                        {
                            Users.Permissao_Usuarios = 1;
                        }
                        else
                        {
                            Users.Permissao_Usuarios = 0;
                        }
                        //
                        if (_Permitir_Desc_Pag == true)
                        {
                            Users.Permitir_Desc_Pag = 1;
                        }
                        else
                        {
                            Users.Permitir_Desc_Pag = 0;
                        }
                        //
                        if (_Permitir_Acresc_Pag == true)
                        {
                            Users.Permitir_Acresc_Pag = 1;
                        }
                        else
                        {
                            Users.Permitir_Acresc_Pag = 0;
                        }
                        //
                        if (_Permitir_Fin_PDV == true)
                        {
                            Users.Permitir_Fin_PDV = 1;
                        }
                        else
                        {
                            Users.Permitir_Fin_PDV = 0;
                        }
                        //
                        if (_Permitir_Alt_Prod_Item == true)
                        {
                            Users.Permitir_Alt_Prod_Item = 1;
                        }
                        else
                        {
                            Users.Permitir_Alt_Prod_Item = 0;
                        }
                        //
                        if (_Mostrar_Dados_Prod_Item == true)
                        {
                            Users.Mostrar_Dados_Prod_Item = 1;
                        }
                        else
                        {
                            Users.Mostrar_Dados_Prod_Item = 0;
                        }
                        //
                        if (_Rel_Reg_Validade_Prod_Serv == true)
                        {
                            Users.Rel_Reg_Validade_Prod_Serv = 1;
                        }
                        else
                        {
                            Users.Rel_Reg_Validade_Prod_Serv = 0;
                        }
                        //
                        if (_Permitir_Atualizar_Zerar_Estoque == true)
                        {
                            Users.Permitir_Atualizar_Zerar_Estoque = 1;
                        }
                        else
                        {
                            Users.Permitir_Atualizar_Zerar_Estoque = 0;
                        }
                        //
                        if (_Desconto_Porc_Max_Venda.Contains("."))
                        {
                            Users.Desconto_Porc_Max_Venda = Convert.ToDecimal(_Desconto_Porc_Max_Venda.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Users.Desconto_Porc_Max_Venda = Convert.ToDecimal(_Desconto_Porc_Max_Venda.Replace(",", "."));
                        }
                        //
                        if (_Acrescimo_Porc_Max_Venda.Contains("."))
                        {
                            Users.Acrescimo_Porc_Max_Venda = Convert.ToDecimal(_Acrescimo_Porc_Max_Venda.Replace(".", "").Replace(",", "."));
                        }
                        else
                        {
                            Users.Acrescimo_Porc_Max_Venda = Convert.ToDecimal(_Acrescimo_Porc_Max_Venda.Replace(",", "."));
                        }
                        //
                        if (_Permitir_Abrir_Caixa == true)
                        {
                            Users.Permitir_Abrir_Caixa = 1;
                        }
                        else
                        {
                            Users.Permitir_Abrir_Caixa = 0;
                        }
                        //
                        if (_Permitir_Fechar_Caixa == true)
                        {
                            Users.Permitir_Fechar_Caixa = 1;
                        }
                        else
                        {
                            Users.Permitir_Fechar_Caixa = 0;
                        }
                        //
                        if (_Permitir_Real_SangSup == true)
                        {
                            Users.Permitir_Real_SangSup = 1;
                        }
                        else
                        {
                            Users.Permitir_Real_SangSup = 0;
                        }
                        //
                        if (_Permitir_Real_Conta_Receber == true)
                        {
                            Users.Permitir_Real_Conta_Receber = 1;
                        }
                        else
                        {
                            Users.Permitir_Real_Conta_Receber = 0;
                        }
                        //
                        if (_Rel_DFe == true)
                        {
                            Users.Rel_DFe = 1;
                        }
                        else
                        {
                            Users.Rel_DFe = 0;
                        }
                        //
                        if (_Permitir_Real_Conta_Pagar == true)
                        {
                            Users.Permitir_Real_Conta_Pagar = 1;
                        }
                        else
                        {
                            Users.Permitir_Real_Conta_Pagar = 0;
                        }
                        //
                        if (_Cadastrar_Cliente_Consumidor == true)
                        {
                            Users.Cadastrar_Cliente_Consumidor = 1;
                        }
                        else
                        {
                            Users.Cadastrar_Cliente_Consumidor = 0;
                        }
                        //
                        if (_Rel_Aniversariante == true)
                        {
                            Users.Rel_Aniversariante = 1;
                        }
                        else
                        {
                            Users.Rel_Aniversariante = 0;
                        }
                        //
                        if (_Cadastrar_Conta_Pagar == true)
                        {
                            Users.Cadastrar_Conta_Pagar = 1;
                        }
                        else
                        {
                            Users.Cadastrar_Conta_Pagar = 0;
                        }
                        //
                        if (_Cadastrar_Conta_Receber == true)
                        {
                            Users.Cadastrar_Conta_Receber = 1;
                        }
                        else
                        {
                            Users.Cadastrar_Conta_Receber = 0;
                        }
                        //
                        if (_Cadastrar_Entidade_Bancaria == true)
                        {
                            Users.Cadastrar_Entidade_Bancaria = 1;
                        }
                        else
                        {
                            Users.Cadastrar_Entidade_Bancaria = 0;
                        }
                        //
                        if (_Cadastrar_Forma_Pagamento == true)
                        {
                            Users.Cadastrar_Forma_Pagamento = 1;
                        }
                        else
                        {
                            Users.Cadastrar_Forma_Pagamento = 0;
                        }
                        //
                        if (_Cadastrar_Fornecedor == true)
                        {
                            Users.Cadastrar_Fornecedor = 1;
                        }
                        else
                        {
                            Users.Cadastrar_Fornecedor = 0;
                        }
                        //
                        if (_Cadastrar_Funcionario == true)
                        {
                            Users.Cadastrar_Funcionario = 1;
                        }
                        else
                        {
                            Users.Cadastrar_Funcionario = 0;
                        }
                        //
                        if (_Cadastrar_Grupo == true)
                        {
                            Users.Cadastrar_Grupo = 1;
                        }
                        else
                        {
                            Users.Cadastrar_Grupo = 0;
                        }
                        //
                        if (_Cadastrar_Localizacao == true)
                        {
                            Users.Cadastrar_Localizacao = 1;
                        }
                        else
                        {
                            Users.Cadastrar_Localizacao = 0;
                        }
                        //
                        if (_Cadastrar_Marca == true)
                        {
                            Users.Cadastrar_Marca = 1;
                        }
                        else
                        {
                            Users.Cadastrar_Marca = 0;
                        }
                        //
                        if (_Cadastrar_Produto == true)
                        {
                            Users.Cadastrar_Produto = 1;
                        }
                        else
                        {
                            Users.Cadastrar_Produto = 0;
                        }
                        //
                        if (_Cadastrar_Subgrupo == true)
                        {
                            Users.Cadastrar_Subgrupo = 1;
                        }
                        else
                        {
                            Users.Cadastrar_Subgrupo = 0;
                        }
                        //
                        if (_Cadastrar_Usuario == true)
                        {
                            Users.Cadastrar_Usuario = 1;
                        }
                        else
                        {
                            Users.Cadastrar_Usuario = 0;
                        }
                        //
                        if (_Permitir_Pausar_Caixa == true)
                        {
                            Users.Permitir_Pausar_Caixa = 1;
                        }
                        else
                        {
                            Users.Permitir_Pausar_Caixa = 0;
                        }
                        //
                        if (_Permitir_Vis_Hist_Caixa == true)
                        {
                            Users.Permitir_Vis_Hist_Caixa = 1;
                        }
                        else
                        {
                            Users.Permitir_Vis_Hist_Caixa = 0;
                        }
                        //
                        if (_Permitir_Cad_No_Pdv == true)
                        {
                            Users.Permitir_Cad_No_Pdv = 1;
                        }
                        else
                        {
                            Users.Permitir_Cad_No_Pdv = 0;
                        }
                        //
                        if (_Permitir_Venda_N_Prom_S_Credito == true)
                        {
                            Users.Permitir_Venda_N_Promissoria_S_Credito = 1;
                        }
                        else
                        {
                            Users.Permitir_Venda_N_Promissoria_S_Credito = 0;
                        }
                        //
                        if (_Rel_Abert_Fech_Caixa == true)
                        {
                            Users.Rel_Abert_Fech_Caixa = 1;
                        }
                        else
                        {
                            Users.Rel_Abert_Fech_Caixa = 0;
                        }
                        //
                        if (_Rel_Cliente_Consumidor == true)
                        {
                            Users.Rel_Cliente_Consumidor = 1;
                        }
                        else
                        {
                            Users.Rel_Cliente_Consumidor = 0;
                        }
                        //
                        if (_Rel_Conta_Pagar == true)
                        {
                            Users.Rel_Conta_Pagar = 1;
                        }
                        else
                        {
                            Users.Rel_Conta_Pagar = 0;
                        }
                        //
                        if (_Rel_Conta_Receber == true)
                        {
                            Users.Rel_Conta_Receber = 1;
                        }
                        else
                        {
                            Users.Rel_Conta_Receber = 0;
                        }
                        //
                        if (_Rel_Produtos_Servico == true)
                        {
                            Users.Rel_Produtos_Servico = 1;
                        }
                        else
                        {
                            Users.Rel_Produtos_Servico = 0;
                        }
                        //
                        if (_Rel_Orcamento == true)
                        {
                            Users.Rel_Orcamento = 1;
                        }
                        else
                        {
                            Users.Rel_Orcamento = 0;
                        }
                        //
                        if (_Rel_Venda == true)
                        {
                            Users.Rel_Venda = 1;
                        }
                        else
                        {
                            Users.Rel_Venda = 0;
                        }
                        //
                        if (_Rel_Grupo == true)
                        {
                            Users.Rel_Grupo = 1;
                        }
                        else
                        {
                            Users.Rel_Grupo = 0;
                        }
                        //
                        if (_Rel_Funcionario == true)
                        {
                            Users.Rel_Funcionario = 1;
                        }
                        else
                        {
                            Users.Rel_Funcionario = 0;
                        }
                        //
                        if (_Rel_Formas_Pagamento == true)
                        {
                            Users.Rel_Formas_Pagamento = 1;
                        }
                        else
                        {
                            Users.Rel_Formas_Pagamento = 0;
                        }
                        //
                        if (_Rel_Fornecedor == true)
                        {
                            Users.Rel_Fornecedor = 1;
                        }
                        else
                        {
                            Users.Rel_Fornecedor = 0;
                        }
                        //
                        if (_Rel_Subgrupo == true)
                        {
                            Users.Rel_Subgrupo = 1;
                        }
                        else
                        {
                            Users.Rel_Subgrupo = 0;
                        }
                        //
                        if (_Rel_Historico_Caixa == true)
                        {
                            Users.Rel_Historico_Caixa = 1;
                        }
                        else
                        {
                            Users.Rel_Historico_Caixa = 0;
                        }
                        //
                        if (_Rel_Fluxo_Caixa == true)
                        {
                            Users.Rel_Fluxo_Caixa = 1;
                        }
                        else
                        {
                            Users.Rel_Fluxo_Caixa = 0;
                        }
                        //
                        if (_Rel_Saida_Produto == true)
                        {
                            Users.Rel_Saida_Produto = 1;
                        }
                        else
                        {
                            Users.Rel_Saida_Produto = 0;
                        }
                        //
                        if (_Rel_Entrada_Produto == true)
                        {
                            Users.Rel_Entrada_Produto = 1;
                        }
                        else
                        {
                            Users.Rel_Entrada_Produto = 0;
                        }
                        //
                        if (_Rel_Sangria_Suprimento == true)
                        {
                            Users.Rel_Sangria_Suprimento = 1;
                        }
                        else
                        {
                            Users.Rel_Sangria_Suprimento = 0;
                        }
                        //
                        if (_Rel_Devolucao_Servico == true)
                        {
                            Users.Rel_Devolucao_Servico = 1;
                        }
                        else
                        {
                            Users.Rel_Devolucao_Servico = 0;
                        }
                        //
                        if (_Permitir_Vis_Senha_Usuario == true)
                        {
                            Users.Permitir_Vis_Senha_Usuario = 1;
                        }
                        else
                        {
                            Users.Permitir_Vis_Senha_Usuario = 0;
                        }
                        //
                        if (_Permitir_Ignorar_Multa_Juros_Receber == true)
                        {
                            Users.Permitir_Ignorar_Multa_Juros_Receber = 1;
                        }
                        else
                        {
                            Users.Permitir_Ignorar_Multa_Juros_Receber = 0;
                        }
                        //
                        if (_Permitir_Exc_Sang_Sup == true)
                        {
                            Users.Permitir_Exc_Sang_Sup = 1;
                        }
                        else
                        {
                            Users.Permitir_Exc_Sang_Sup = 0;
                        }
                        //
                        if (_Rel_Usuario == true)
                        {
                            Users.Rel_Usuario = 1;
                        }
                        else
                        {
                            Users.Rel_Usuario = 0;
                        }
                        //
                        if (_Rel_Marca == true)
                        {
                            Users.Rel_Marca = 1;
                        }
                        else
                        {
                            Users.Rel_Marca = 0;
                        }
                        //
                        if (_Rel_Localizacao == true)
                        {
                            Users.Rel_Localizacao = 1;
                        }
                        else
                        {
                            Users.Rel_Localizacao = 0;
                        }
                        //
                        if (_Permitir_Venda_S_Credito_Loja == true)
                        {
                            Users.Permitir_Venda_S_Credito_Loja = 1;
                        }
                        else
                        {
                            Users.Permitir_Venda_S_Credito_Loja = 0;
                        }
                        //
                        if (_Permitir_Alt_Dados_Emp == true)
                        {
                            Users.Permitir_Alt_Dados_Emp = 1;
                        }
                        else
                        {
                            Users.Permitir_Alt_Dados_Emp = 0;
                        }
                        //
                        if (_Permitir_Alt_Dados_Config == true)
                        {
                            Users.Permitir_Alt_Dados_Config = 1;
                        }
                        else
                        {
                            Users.Permitir_Alt_Dados_Config = 0;
                        }
                        //
                        if (_Criar_Lembrete_Conta_Pagar == true)
                        {
                            Users.Criar_Lembrete_Conta_Pagar = 1;
                        }
                        else
                        {
                            Users.Criar_Lembrete_Conta_Pagar = 0;
                        }
                        //
                        if (_Criar_Lembrete_Conta_Receber == true)
                        {
                            Users.Criar_Lembrete_Conta_Receber = 1;
                        }
                        else
                        {
                            Users.Criar_Lembrete_Conta_Receber = 0;
                        }
                        //
                        if (_Criar_Conta_a_Pagar_DFe == true)
                        {
                            Users.Criar_Conta_a_Pagar_DFe = 1;
                        }
                        else
                        {
                            Users.Criar_Conta_a_Pagar_DFe = 0;
                        }
                        //
                        if (_Criar_Lembrete_Validade == true)
                        {
                            Users.Criar_Lembrete_Validade = 1;
                        }
                        else
                        {
                            Users.Criar_Lembrete_Validade = 0;
                        }
                        //
                        if (_Cadastrar_CFOP_NatOp == true)
                        {
                            Users.Cadastrar_CFOP_NatOp = 1;
                        }
                        else
                        {
                            Users.Cadastrar_CFOP_NatOp = 0;
                        }
                        //
                        if (_Cadastrar_DFe == true)
                        {
                            Users.Cadastrar_DFe = 1;
                        }
                        else
                        {
                            Users.Cadastrar_DFe = 0;
                        }
                        //
                        if (_Rel_Reg_Atividade == true)
                        {
                            Users.Rel_Reg_Atividade = 1;
                        }
                        else
                        {
                            Users.Rel_Reg_Atividade = 0;
                        }
                        //
                        if (_Rel_Estoque == true)
                        {
                            Users.Rel_Estoque = 1;
                        }
                        else
                        {
                            Users.Rel_Estoque = 0;
                        }
                        //
                        if (_Capturar_Venda == true)
                        {
                            Users.Capturar_Venda = 1;
                        }
                        else
                        {
                            Users.Capturar_Venda = 0;
                        }
                        //
                        if (_Cadastrar_Servico == true)
                        {
                            Users.Cadastrar_Servico = 1;
                        }
                        else
                        {
                            Users.Cadastrar_Servico = 0;
                        }
                        //
                        if (_Permitir_Excluir_OS == true)
                        {
                            Users.Permitir_Excluir_OS = 1;
                        }
                        else
                        {
                            Users.Permitir_Excluir_OS = 0;
                        }
                        //
                        if (_Cadastrar_OS == true)
                        {
                            Users.Cadastrar_OS = 1;
                        }
                        else
                        {
                            Users.Cadastrar_OS = 0;
                        }
                        //
                        if (_Cadastrar_PSPPIX == true)
                        {
                            Users.Cadastrar_PSPPIX = 1;
                        }
                        else
                        {
                            Users.Cadastrar_PSPPIX = 0;
                        }
                        //
                        if (_Acessar_Menu_NFe_NFCe == true)
                        {
                            Users.Acessar_Menu_NFe_NFCe = 1;
                        }
                        else
                        {
                            Users.Acessar_Menu_NFe_NFCe = 0;
                        }
                        //
                        if (_Acessar_Menu_NFSe == true)
                        {
                            Users.Acessar_Menu_NFSe = 1;
                        }
                        else
                        {
                            Users.Acessar_Menu_NFSe = 0;
                        }
                        //
                        if (_Cadastrar_NFe == true)
                        {
                            Users.Cadastrar_NFe = 1;
                        }
                        else
                        {
                            Users.Cadastrar_NFe = 0;
                        }
                        //
                        if (_Rel_Comissao == true)
                        {
                            Users.Rel_Comissao = 1;
                        }
                        else
                        {
                            Users.Rel_Comissao = 0;
                        }
                        //
                        if (_Rel_OS == true)
                        {
                            Users.Rel_OS = 1;
                        }
                        else
                        {
                            Users.Rel_OS = 0;
                        }
                        //
                        if (_Rel_Controle_Cheque == true)
                        {
                            Users.Rel_Controle_Cheque = 1;
                        }
                        else
                        {
                            Users.Rel_Controle_Cheque = 0;
                        }
                        //
                        if (_Cadastrar_Documentos == true)
                        {
                            Users.Cadastrar_Documentos = 1;
                        }
                        else
                        {
                            Users.Cadastrar_Documentos = 0;
                        }
                        //
                        if (_Permitir_Desfazer_Baixa == true)
                        {
                            Users.Permitir_Desfazer_Baixa = 1;
                        }
                        else
                        {
                            Users.Permitir_Desfazer_Baixa = 0;
                        }
                    }
                    //
                    con.Salvar_Usuario(Users);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static void Alterar(string codigo, string nome_usuario, string senha, string funcionario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    //
                    Users.Codigo = Convert.ToInt16(codigo);
                    //
                    Users.Nome_Usuario = nome_usuario.Insert(nome_usuario.Length, "'").Insert(0, "'");
                    //
                    Users.Senha = senha.Insert(senha.Length, "'").Insert(0, "'");
                    //
                    if (funcionario == "" || funcionario == null)
                    {
                        Users.Cod_Funcionario = 0;
                        Users.Nome_Funcionario = "null";
                    }
                    else
                    {
                        string[] items = funcionario.Split('—');
                        Users.Cod_Funcionario = Convert.ToInt16(items[0]);
                        Users.Nome_Funcionario = items[1].Insert(items[1].Length, "'").Insert(0, "'");
                    }
                    //
                    if (_Permitir_Excluir_Inventario == true)
                    {
                        Users.Permitir_Excluir_Inventario = 1;
                    }
                    else
                    {
                        Users.Permitir_Excluir_Inventario = 0;
                    }
                    //
                    if (_Realizar_Orcamento == true)
                    {
                        Users.Realizar_Orcamento = 1;
                    }
                    else
                    {
                        Users.Realizar_Orcamento = 0;
                    }
                    //
                    if (_Realizar_Devolucao == true)
                    {
                        Users.Realizar_Devolucao = 1;
                    }
                    else
                    {
                        Users.Realizar_Devolucao = 0;
                    }
                    //
                    if (_Permitir_Canc_Exc_Item_Venda == true)
                    {
                        Users.Permitir_Canc_Exc_Item_Venda = 1;
                    }
                    else
                    {
                        Users.Permitir_Canc_Exc_Item_Venda = 0;
                    }
                    //
                    if (_Capturar_Orcamento == true)
                    {
                        Users.Capturar_Orcamento = 1;
                    }
                    else
                    {
                        Users.Capturar_Orcamento = 0;
                    }
                    //
                    if (_Rel_Aniversariante == true)
                    {
                        Users.Rel_Aniversariante = 1;
                    }
                    else
                    {
                        Users.Rel_Aniversariante = 0;
                    }
                    //
                    if (_Capturar_Devolucao == true)
                    {
                        Users.Capturar_Devolucao = 1;
                    }
                    else
                    {
                        Users.Capturar_Devolucao = 0;
                    }
                    //
                    if (_Permissao_Usuarios == true)
                    {
                        Users.Permissao_Usuarios = 1;
                    }
                    else
                    {
                        Users.Permissao_Usuarios = 0;
                    }
                    //
                    if (_Permitir_Desc_Pag == true)
                    {
                        Users.Permitir_Desc_Pag = 1;
                    }
                    else
                    {
                        Users.Permitir_Desc_Pag = 0;
                    }
                    //
                    if (_Rel_DFe == true)
                    {
                        Users.Rel_DFe = 1;
                    }
                    else
                    {
                        Users.Rel_DFe = 0;
                    }
                    //
                    if (_Permitir_Acresc_Pag == true)
                    {
                        Users.Permitir_Acresc_Pag = 1;
                    }
                    else
                    {
                        Users.Permitir_Acresc_Pag = 0;
                    }
                    //
                    if (_Permitir_Fin_PDV == true)
                    {
                        Users.Permitir_Fin_PDV = 1;
                    }
                    else
                    {
                        Users.Permitir_Fin_PDV = 0;
                    }
                    //
                    if (_Permitir_Alt_Prod_Item == true)
                    {
                        Users.Permitir_Alt_Prod_Item = 1;
                    }
                    else
                    {
                        Users.Permitir_Alt_Prod_Item = 0;
                    }
                    //
                    if (_Cadastrar_DFe == true)
                    {
                        Users.Cadastrar_DFe = 1;
                    }
                    else
                    {
                        Users.Cadastrar_DFe = 0;
                    }
                    //
                    if (_Mostrar_Dados_Prod_Item == true)
                    {
                        Users.Mostrar_Dados_Prod_Item = 1;
                    }
                    else
                    {
                        Users.Mostrar_Dados_Prod_Item = 0;
                    }
                    //
                    if (_Desconto_Porc_Max_Venda.Contains("."))
                    {
                        Users.Desconto_Porc_Max_Venda = Convert.ToDecimal(_Desconto_Porc_Max_Venda.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Users.Desconto_Porc_Max_Venda = Convert.ToDecimal(_Desconto_Porc_Max_Venda.Replace(",", "."));
                    }
                    //
                    if (_Acrescimo_Porc_Max_Venda.Contains("."))
                    {
                        Users.Acrescimo_Porc_Max_Venda = Convert.ToDecimal(_Acrescimo_Porc_Max_Venda.Replace(".", "").Replace(",", "."));
                    }
                    else
                    {
                        Users.Acrescimo_Porc_Max_Venda = Convert.ToDecimal(_Acrescimo_Porc_Max_Venda.Replace(",", "."));
                    }
                    //
                    if (_Permitir_Abrir_Caixa == true)
                    {
                        Users.Permitir_Abrir_Caixa = 1;
                    }
                    else
                    {
                        Users.Permitir_Abrir_Caixa = 0;
                    }
                    //
                    if (_Rel_Reg_Validade_Prod_Serv == true)
                    {
                        Users.Rel_Reg_Validade_Prod_Serv = 1;
                    }
                    else
                    {
                        Users.Rel_Reg_Validade_Prod_Serv = 0;
                    }
                    //
                    if (_Permitir_Fechar_Caixa == true)
                    {
                        Users.Permitir_Fechar_Caixa = 1;
                    }
                    else
                    {
                        Users.Permitir_Fechar_Caixa = 0;
                    }
                    //
                    if (_Permitir_Real_SangSup == true)
                    {
                        Users.Permitir_Real_SangSup = 1;
                    }
                    else
                    {
                        Users.Permitir_Real_SangSup = 0;
                    }
                    //
                    if (_Permitir_Real_Conta_Receber == true)
                    {
                        Users.Permitir_Real_Conta_Receber = 1;
                    }
                    else
                    {
                        Users.Permitir_Real_Conta_Receber = 0;
                    }
                    //
                    if (_Rel_Reg_Atividade == true)
                    {
                        Users.Rel_Reg_Atividade = 1;
                    }
                    else
                    {
                        Users.Rel_Reg_Atividade = 0;
                    }
                    //
                    if (_Permitir_Real_Conta_Pagar == true)
                    {
                        Users.Permitir_Real_Conta_Pagar = 1;
                    }
                    else
                    {
                        Users.Permitir_Real_Conta_Pagar = 0;
                    }
                    //
                    if (_Cadastrar_Cliente_Consumidor == true)
                    {
                        Users.Cadastrar_Cliente_Consumidor = 1;
                    }
                    else
                    {
                        Users.Cadastrar_Cliente_Consumidor = 0;
                    }
                    //
                    if (_Cadastrar_Conta_Pagar == true)
                    {
                        Users.Cadastrar_Conta_Pagar = 1;
                    }
                    else
                    {
                        Users.Cadastrar_Conta_Pagar = 0;
                    }
                    //
                    if (_Cadastrar_Conta_Receber == true)
                    {
                        Users.Cadastrar_Conta_Receber = 1;
                    }
                    else
                    {
                        Users.Cadastrar_Conta_Receber = 0;
                    }
                    //
                    if (_Cadastrar_Entidade_Bancaria == true)
                    {
                        Users.Cadastrar_Entidade_Bancaria = 1;
                    }
                    else
                    {
                        Users.Cadastrar_Entidade_Bancaria = 0;
                    }
                    //
                    if (_Cadastrar_Forma_Pagamento == true)
                    {
                        Users.Cadastrar_Forma_Pagamento = 1;
                    }
                    else
                    {
                        Users.Cadastrar_Forma_Pagamento = 0;
                    }
                    //
                    if (_Cadastrar_Fornecedor == true)
                    {
                        Users.Cadastrar_Fornecedor = 1;
                    }
                    else
                    {
                        Users.Cadastrar_Fornecedor = 0;
                    }
                    //
                    if (_Cadastrar_Funcionario == true)
                    {
                        Users.Cadastrar_Funcionario = 1;
                    }
                    else
                    {
                        Users.Cadastrar_Funcionario = 0;
                    }
                    //
                    if (_Cadastrar_Grupo == true)
                    {
                        Users.Cadastrar_Grupo = 1;
                    }
                    else
                    {
                        Users.Cadastrar_Grupo = 0;
                    }
                    //
                    if (_Cadastrar_Localizacao == true)
                    {
                        Users.Cadastrar_Localizacao = 1;
                    }
                    else
                    {
                        Users.Cadastrar_Localizacao = 0;
                    }
                    //
                    if (_Cadastrar_Marca == true)
                    {
                        Users.Cadastrar_Marca = 1;
                    }
                    else
                    {
                        Users.Cadastrar_Marca = 0;
                    }
                    //
                    if (_Cadastrar_Produto == true)
                    {
                        Users.Cadastrar_Produto = 1;
                    }
                    else
                    {
                        Users.Cadastrar_Produto = 0;
                    }
                    //
                    if (_Cadastrar_Subgrupo == true)
                    {
                        Users.Cadastrar_Subgrupo = 1;
                    }
                    else
                    {
                        Users.Cadastrar_Subgrupo = 0;
                    }
                    //
                    if (_Cadastrar_Usuario == true)
                    {
                        Users.Cadastrar_Usuario = 1;
                    }
                    else
                    {
                        Users.Cadastrar_Usuario = 0;
                    }
                    //
                    if (_Permitir_Pausar_Caixa == true)
                    {
                        Users.Permitir_Pausar_Caixa = 1;
                    }
                    else
                    {
                        Users.Permitir_Pausar_Caixa = 0;
                    }
                    //
                    if (_Permitir_Vis_Hist_Caixa == true)
                    {
                        Users.Permitir_Vis_Hist_Caixa = 1;
                    }
                    else
                    {
                        Users.Permitir_Vis_Hist_Caixa = 0;
                    }
                    //
                    if (_Permitir_Cad_No_Pdv == true)
                    {
                        Users.Permitir_Cad_No_Pdv = 1;
                    }
                    else
                    {
                        Users.Permitir_Cad_No_Pdv = 0;
                    }
                    //
                    if (_Permitir_Atualizar_Zerar_Estoque == true)
                    {
                        Users.Permitir_Atualizar_Zerar_Estoque = 1;
                    }
                    else
                    {
                        Users.Permitir_Atualizar_Zerar_Estoque = 0;
                    }
                    //
                    if (_Permitir_Venda_N_Prom_S_Credito == true)
                    {
                        Users.Permitir_Venda_N_Promissoria_S_Credito = 1;
                    }
                    else
                    {
                        Users.Permitir_Venda_N_Promissoria_S_Credito = 0;
                    }
                    //
                    if (_Rel_Abert_Fech_Caixa == true)
                    {
                        Users.Rel_Abert_Fech_Caixa = 1;
                    }
                    else
                    {
                        Users.Rel_Abert_Fech_Caixa = 0;
                    }
                    //
                    if (_Rel_Cliente_Consumidor == true)
                    {
                        Users.Rel_Cliente_Consumidor = 1;
                    }
                    else
                    {
                        Users.Rel_Cliente_Consumidor = 0;
                    }
                    //
                    if (_Rel_Conta_Pagar == true)
                    {
                        Users.Rel_Conta_Pagar = 1;
                    }
                    else
                    {
                        Users.Rel_Conta_Pagar = 0;
                    }
                    //
                    if (_Rel_Conta_Receber == true)
                    {
                        Users.Rel_Conta_Receber = 1;
                    }
                    else
                    {
                        Users.Rel_Conta_Receber = 0;
                    }
                    //
                    if (_Rel_Produtos_Servico == true)
                    {
                        Users.Rel_Produtos_Servico = 1;
                    }
                    else
                    {
                        Users.Rel_Produtos_Servico = 0;
                    }
                    //
                    if (_Rel_Orcamento == true)
                    {
                        Users.Rel_Orcamento = 1;
                    }
                    else
                    {
                        Users.Rel_Orcamento = 0;
                    }
                    //
                    if (_Rel_Venda == true)
                    {
                        Users.Rel_Venda = 1;
                    }
                    else
                    {
                        Users.Rel_Venda = 0;
                    }
                    //
                    if (_Rel_Grupo == true)
                    {
                        Users.Rel_Grupo = 1;
                    }
                    else
                    {
                        Users.Rel_Grupo = 0;
                    }
                    //
                    if (_Rel_Funcionario == true)
                    {
                        Users.Rel_Funcionario = 1;
                    }
                    else
                    {
                        Users.Rel_Funcionario = 0;
                    }
                    //
                    if (_Rel_Formas_Pagamento == true)
                    {
                        Users.Rel_Formas_Pagamento = 1;
                    }
                    else
                    {
                        Users.Rel_Formas_Pagamento = 0;
                    }
                    //
                    if (_Rel_Fornecedor == true)
                    {
                        Users.Rel_Fornecedor = 1;
                    }
                    else
                    {
                        Users.Rel_Fornecedor = 0;
                    }
                    //
                    if (_Rel_Subgrupo == true)
                    {
                        Users.Rel_Subgrupo = 1;
                    }
                    else
                    {
                        Users.Rel_Subgrupo = 0;
                    }
                    //
                    if (_Rel_Historico_Caixa == true)
                    {
                        Users.Rel_Historico_Caixa = 1;
                    }
                    else
                    {
                        Users.Rel_Historico_Caixa = 0;
                    }
                    //
                    if (_Rel_Fluxo_Caixa == true)
                    {
                        Users.Rel_Fluxo_Caixa = 1;
                    }
                    else
                    {
                        Users.Rel_Fluxo_Caixa = 0;
                    }
                    //
                    if (_Rel_Saida_Produto == true)
                    {
                        Users.Rel_Saida_Produto = 1;
                    }
                    else
                    {
                        Users.Rel_Saida_Produto = 0;
                    }
                    //
                    if (_Rel_Entrada_Produto == true)
                    {
                        Users.Rel_Entrada_Produto = 1;
                    }
                    else
                    {
                        Users.Rel_Entrada_Produto = 0;
                    }
                    //
                    if (_Rel_Sangria_Suprimento == true)
                    {
                        Users.Rel_Sangria_Suprimento = 1;
                    }
                    else
                    {
                        Users.Rel_Sangria_Suprimento = 0;
                    }
                    //
                    if (_Rel_Devolucao_Servico == true)
                    {
                        Users.Rel_Devolucao_Servico = 1;
                    }
                    else
                    {
                        Users.Rel_Devolucao_Servico = 0;
                    }
                    //
                    if (_Permitir_Vis_Senha_Usuario == true)
                    {
                        Users.Permitir_Vis_Senha_Usuario = 1;
                    }
                    else
                    {
                        Users.Permitir_Vis_Senha_Usuario = 0;
                    }
                    //
                    if (_Permitir_Ignorar_Multa_Juros_Receber == true)
                    {
                        Users.Permitir_Ignorar_Multa_Juros_Receber = 1;
                    }
                    else
                    {
                        Users.Permitir_Ignorar_Multa_Juros_Receber = 0;
                    }
                    //
                    if (_Permitir_Exc_Sang_Sup == true)
                    {
                        Users.Permitir_Exc_Sang_Sup = 1;
                    }
                    else
                    {
                        Users.Permitir_Exc_Sang_Sup = 0;
                    }
                    //
                    if (_Rel_Usuario == true)
                    {
                        Users.Rel_Usuario = 1;
                    }
                    else
                    {
                        Users.Rel_Usuario = 0;
                    }
                    //
                    if (_Rel_Localizacao == true)
                    {
                        Users.Rel_Localizacao = 1;
                    }
                    else
                    {
                        Users.Rel_Localizacao = 0;
                    }
                    //
                    if (_Rel_Marca == true)
                    {
                        Users.Rel_Marca = 1;
                    }
                    else
                    {
                        Users.Rel_Marca = 0;
                    }
                    //
                    if (_Permitir_Venda_S_Credito_Loja == true)
                    {
                        Users.Permitir_Venda_S_Credito_Loja = 1;
                    }
                    else
                    {
                        Users.Permitir_Venda_S_Credito_Loja = 0;
                    }
                    //
                    if (_Permitir_Alt_Dados_Emp == true)
                    {
                        Users.Permitir_Alt_Dados_Emp = 1;
                    }
                    else
                    {
                        Users.Permitir_Alt_Dados_Emp = 0;
                    }
                    //
                    if (_Permitir_Alt_Dados_Config == true)
                    {
                        Users.Permitir_Alt_Dados_Config = 1;
                    }
                    else
                    {
                        Users.Permitir_Alt_Dados_Config = 0;
                    }
                    //
                    if (_Criar_Lembrete_Conta_Pagar == true)
                    {
                        Users.Criar_Lembrete_Conta_Pagar = 1;
                    }
                    else
                    {
                        Users.Criar_Lembrete_Conta_Pagar = 0;
                    }
                    //
                    if (_Criar_Lembrete_Conta_Receber == true)
                    {
                        Users.Criar_Lembrete_Conta_Receber = 1;
                    }
                    else
                    {
                        Users.Criar_Lembrete_Conta_Receber = 0;
                    }
                    //
                    if (_Criar_Conta_a_Pagar_DFe == true)
                    {
                        Users.Criar_Conta_a_Pagar_DFe = 1;
                    }
                    else
                    {
                        Users.Criar_Conta_a_Pagar_DFe = 0;
                    }
                    //
                    if (_Criar_Lembrete_Validade == true)
                    {
                        Users.Criar_Lembrete_Validade = 1;
                    }
                    else
                    {
                        Users.Criar_Lembrete_Validade = 0;
                    }
                    //
                    if (_Cadastrar_CFOP_NatOp == true)
                    {
                        Users.Cadastrar_CFOP_NatOp = 1;
                    }
                    else
                    {
                        Users.Cadastrar_CFOP_NatOp = 0;
                    }
                    //
                    if (_Rel_Estoque == true)
                    {
                        Users.Rel_Estoque = 1;
                    }
                    else
                    {
                        Users.Rel_Estoque = 0;
                    }
                    //
                    if (_Capturar_Venda == true)
                    {
                        Users.Capturar_Venda = 1;
                    }
                    else
                    {
                        Users.Capturar_Venda = 0;
                    }
                    //
                    if (_Cadastrar_Servico == true)
                    {
                        Users.Cadastrar_Servico = 1;
                    }
                    else
                    {
                        Users.Cadastrar_Servico = 0;
                    }
                    //
                    if (_Permitir_Excluir_OS == true)
                    {
                        Users.Permitir_Excluir_OS = 1;
                    }
                    else
                    {
                        Users.Permitir_Excluir_OS = 0;
                    }
                    //
                    if (_Cadastrar_OS == true)
                    {
                        Users.Cadastrar_OS = 1;
                    }
                    else
                    {
                        Users.Cadastrar_OS = 0;
                    }
                    //
                    if (_Cadastrar_PSPPIX == true)
                    {
                        Users.Cadastrar_PSPPIX = 1;
                    }
                    else
                    {
                        Users.Cadastrar_PSPPIX = 0;
                    }
                    //
                    if (_Acessar_Menu_NFe_NFCe == true)
                    {
                        Users.Acessar_Menu_NFe_NFCe = 1;
                    }
                    else
                    {
                        Users.Acessar_Menu_NFe_NFCe = 0;
                    }
                    //
                    if (_Acessar_Menu_NFSe == true)
                    {
                        Users.Acessar_Menu_NFSe = 1;
                    }
                    else
                    {
                        Users.Acessar_Menu_NFSe = 0;
                    }
                    //
                    if (_Cadastrar_NFe == true)
                    {
                        Users.Cadastrar_NFe = 1;
                    }
                    else
                    {
                        Users.Cadastrar_NFe = 0;
                    }
                    //
                    if (_Rel_Comissao == true)
                    {
                        Users.Rel_Comissao = 1;
                    }
                    else
                    {
                        Users.Rel_Comissao = 0;
                    }
                    //
                    if (_Rel_OS == true)
                    {
                        Users.Rel_OS = 1;
                    }
                    else
                    {
                        Users.Rel_OS = 0;
                    }
                    //
                    if (_Rel_Controle_Cheque == true)
                    {
                        Users.Rel_Controle_Cheque = 1;
                    }
                    else
                    {
                        Users.Rel_Controle_Cheque = 0;
                    }
                    //
                    if (_Cadastrar_Documentos == true)
                    {
                        Users.Cadastrar_Documentos = 1;
                    }
                    else
                    {
                        Users.Cadastrar_Documentos = 0;
                    }
                    //
                    if (_Permitir_Desfazer_Baixa == true)
                    {
                        Users.Permitir_Desfazer_Baixa = 1;
                    }
                    else
                    {
                        Users.Permitir_Desfazer_Baixa = 0;
                    }
                    //
                    con.Alterar_Usuario(Users);
                    //
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
                }
            }
        }

        public static bool Sel_Reallizar_Orcamento_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Reallizar_Orcamento_Usuario(Users) == 1)
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

        public static bool Sel_Atualizar_Zerar_Estoque(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Atualizar_Zerar_Estoque(Users) == 1)
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

        public static bool Sel_Perm_Exc_Inv(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Perm_Exc_Inv(Users) == 1)
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

        public static bool Sel_Perm_Exc_OS(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Perm_Exc_OS(Users) == 1)
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


        public static bool Sel_Rel_Estoque(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Estoque(Users) == 1)
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

        public static bool Sel_Cadastrar_Cliente_Consumidor(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_Cliente_Consumidor(Users) == 1)
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

        public static bool Sel_Acessar_Menu_NFe_NFCe(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Acessar_Menu_NFe_NFCe(Users) == 1)
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

        public static bool Sel_Acessar_Menu_NFSe(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Acessar_Menu_NFSe(Users) == 1)
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

        public static bool Sel_Cadastrar_OS(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_OS(Users) == 1)
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

        public static bool Sel_Rel_Abert_Fech_Caixa(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Abert_Fech_Caixa(Users) == 1)
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

        public static bool Sel_Rel_Aniversariante(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Aniversariante(Users) == 1)
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

        public static bool Sel_Rel_Cliente_Consumidor(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Cliente_Consumidor(Users) == 1)
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

        public static bool Sel_Rel_Contas_Pagar(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Contas_Pagar(Users) == 1)
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

        public static bool Sel_Rel_Contas_Receber(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Contas_Receber(Users) == 1)
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

        public static bool Sel_Rel_DFe(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_DFe(Users) == 1)
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

        public static bool Sel_Rel_Validade_Prod_Serv(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Validade_Prod_Serv(Users) == 1)
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

        public static bool Sel_Rel_Produtos(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Produtos(Users) == 1)
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

        public static bool Sel_Rel_Controle_Cheque(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Controle_Cheque(Users) == 1)
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

        public static bool Sel_Rel_Orcamentos(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Orcamentos(Users) == 1)
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

        public static bool Sel_Rel_OS(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_OS(Users) == 1)
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

        public static bool Sel_Rel_Vendas(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Vendas(Users) == 1)
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

        public static bool Sel_Rel_Grupos(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Grupos(Users) == 1)
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

        public static bool Sel_Rel_Funcionarios(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Funcionarios(Users) == 1)
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

        public static bool Sel_Rel_Formas_Pagamento(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Formas_Pagamento(Users) == 1)
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

        public static bool Sel_Rel_Fornecedor(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Fornecedor(Users) == 1)
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

        public static bool Sel_Rel_Subgrupos(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Subgrupos(Users) == 1)
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

        public static bool Sel_Rel_Localizacao(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Localizacao(Users) == 1)
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

        public static bool Sel_Rel_Marca(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Marca(Users) == 1)
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

        public static bool Sel_Rel_Hist_Caixa(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Hist_Caixa(Users) == 1)
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

        public static bool Sel_Rel_Comisssao(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Comisssao(Users) == 1)
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

        public static bool Sel_Rel_Fluxo_Caixa(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Fluxo_Caixa(Users) == 1)
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

        public static bool Sel_Rel_Saidas_Produtos(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Saidas_Produtos(Users) == 1)
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

        public static bool Sel_Rel_Registro_Atividade(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Registro_Atividade(Users) == 1)
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

        public static bool Sel_Rel_Entrada_Produtos(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Entrada_Produtos(Users) == 1)
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

        public static bool Sel_Rel_Sangria_Suprimento(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Sangria_Suprimento(Users) == 1)
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

        public static bool Sel_Rel_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Usuario(Users) == 1)
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

        public static bool Sel_Rel_Devolucao(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Rel_Devolucao(Users) == 1)
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



        public static bool Sel_Cadastrar_Conta_Pagar(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_Conta_Pagar(Users) == 1)
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

        public static bool Sel_Cadastrar_Conta_Receber(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_Conta_Receber(Users) == 1)
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

        public static void Alterar_User_Cadastro_Computadores_Adm(string codigo, string nome)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Codigo = Convert.ToInt16(codigo);
                    User.Nome_Usuario = nome.Insert(nome.Length, "'").Insert(0, "'");
                    con.Alterar_User_Cadastro_Computadores_Adm(User);
                }
            }
        }

        public static void Alterar_User_Cadastro_Computadores_Pdv(string codigo, string nome)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Codigo = Convert.ToInt16(codigo);
                    User.Nome_Usuario = nome.Insert(nome.Length, "'").Insert(0, "'");
                    con.Alterar_User_Cadastro_Computadores_Pdv(User);
                }
            }
        }


        public static bool Sel_Cadastrar_Localizacao(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_Localizacao(Users) == 1)
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

        public static bool Sel_Cadastrar_Marcas(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_Marcas(Users) == 1)
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

        public static bool Sel_Permitir_Configurar(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Permitir_Configurar(Users) == 1)
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



        public static bool Sel_Cadastrar_Empresa(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_Empresa(Users) == 1)
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

        public static bool Sel_Cadastrar_CFOP_NatOp(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_CFOP_NatOp(Users) == 1)
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

        public static bool Sel_Cadastrar_Produtos(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_Produtos(Users) == 1)
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

        public static bool Sel_Cadastrar_Documentos(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_Documentos(Users) == 1)
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

        public static bool Sel_Cadastrar_DFe(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_DFe(Users) == 1)
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

        public static bool Sel_Cadastrar_NFe(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_NFe(Users) == 1)
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



        public static bool Sel_Cadastrar_Subgrupos(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_Subgrupos(Users) == 1)
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

        public static bool Sel_Cadastrar_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_Usuario(Users) == 1)
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

        public static bool Sel_Cadastrar_PSP_PIX(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_PSP_PIX(Users) == 1)
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

        public static bool Sel_Cadastrar_Entidade_Bancaria(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_Entidade_Bancaria(Users) == 1)
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

        public static bool Sel_Cadastrar_Forma_Pagamento(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_Forma_Pagamento(Users) == 1)
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

        public static bool Sel_Cadastrar_Forncedores(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_Fornecedores(Users) == 1)
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

        public static bool Sel_Cadastrar_Funcionarios(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_Funcionarios(Users) == 1)
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

        public static bool Sel_Cadastrar_Grupos(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_Grupos(Users) == 1)
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

        public static bool Sel_Cadastrar_Servico(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Cadastrar_Servico(Users) == 1)
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


        public static bool Sel_Reallizar_Fechamento_Caixa_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Reallizar_Fechamento_Caixa_Usuario(Users) == 1)
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

        public static bool Sel_Reallizar_Pausa_Caixa_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Reallizar_Pausa_Caixa_Usuario(Users) == 1)
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

        public static bool Sel_Visualizar_Hist_Caixa_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Visualizar_Hist_Caixa_Usuario(Users) == 1)
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

        public static bool Sel_Reallizar_Abert_Caixa_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Reallizar_Abert_Caixa_Usuario(Users) == 1)
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

        public static bool Sel_Reallizar_SangSup_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Reallizar_SangSup_Usuario(Users) == 1)
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

        public static bool Sel_Reallizar_Pagamento_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Reallizar_Pagamento_Usuario(Users) == 1)
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

        public static bool Sel_Usuario_Ainda_Existe(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    Users.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Usuario_Ainda_Existe(Users);
                }
            }
        }

        public static bool Sel_Reallizar_Recebimento_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Reallizar_Recebimento_Usuario(Users) == 1)
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

        public static bool Sel_Permitir_Alt_Prod_Item_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Permitir_Alt_Prod_Item_Usuario(Users) == 1)
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

        public static bool Sel_Capturar_Devolucao_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Capturar_Devolucao_Usuario(Users) == 1)
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

        public static bool Sel_Capturar_Venda_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Capturar_Venda_Usuario(Users) == 1)
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

        public static bool Sel_Permitir_Desc_Pag_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Permitir_Desc_Pag_Usuario(Users) == 1)
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

        public static bool Sel_Desconto_Porc_Max_Venda_Usuario(string usuario, string desconto_porc)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    Users.Desconto_Porc_Max_Venda = Convert.ToDecimal(desconto_porc);
                    //
                    if (Users.Desconto_Porc_Max_Venda <= con.Sel_Desconto_Porc_Max_Venda_Usuario(Users))
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

        public static bool Sel_Acrescimo_Porc_Max_Venda_Usuario(string usuario, string acrescimo_porc)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    Users.Acrescimo_Porc_Max_Venda = Convert.ToDecimal(acrescimo_porc);
                    //
                    if (Users.Acrescimo_Porc_Max_Venda <= con.Sel_Acrescimo_Porc_Max_Venda_Usuario(Users))
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

        public static bool Sel_Permitir_Acresc_Pag_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Permitir_Acresc_Pag_Usuario(Users) == 1)
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


        public static bool Sel_Reallizar_Devolucao_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Reallizar_Devolucao_Usuario(Users) == 1)
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

        public static bool Sel_Permitir_Finalizar_PDV_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Permitir_Finalizar_PDV_Usuario(Users) == 1)
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

        public static bool Sel_Capturar_Orcamento_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Capturar_Orcamento_Usuario(Users) == 1)
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

        public static bool Sel_Excluir_Sang_Sup_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Excluir_Sang_Sup_Usuario(Users) == 1)
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

        public static bool Sel_Criar_Lemb_Conta_Receber_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Criar_Lemb_Conta_Receber_Usuario(Users) == 1)
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

        public static bool Sel_Criar_Conta_Pagar_DFe_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Criar_Conta_Pagar_DFe_Usuario(Users) == 1)
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

        public static bool Sel_Criar_Lemb_Conta_Pagar_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Criar_Lemb_Conta_Pagar_Usuario(Users) == 1)
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

        public static bool Sel_Criar_Lemb_Validade_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Criar_Lemb_Validade_Usuario(Users) == 1)
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

        public static bool Sel_Permitir_Canc_Exc_Item_Venda_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Permitir_Canc_Exc_Item_Venda_Usuario(Users) == 1)
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

        public static bool Sel_Permitir_Desfazer_Baixa_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Permitir_Desfazer_Baixa_Usuario(Users) == 1)
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

        public static bool Sel_Mostrar_Dados_Prod_Item_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Mostrar_Dados_Prod_Item_Usuario(Users) == 1)
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

        public static DataTable Sel_Funcoes_Usuario(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Funcoes_Usuario(User);
                }
            }
        }

        public static void Excluir(string codigo)//Salvando dados no banco
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    Users.Codigo = Convert.ToInt16(codigo);
                    con.Excluir_Usuario(Users);
                }
            }
        }

        public static DataTable Sel_Usuario_Nome_Usuario(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    if (pesquisar.Contains("%"))
                    {
                        User.Pesquisar = pesquisar;
                        return con.Sel_Usuario_Nome_Usuario_Like(User);
                    }
                    else
                    {
                        User.Pesquisar = pesquisar;
                        return con.Sel_Usuario_Nome_Usuario(User);
                    }
                }
            }
        }

        public static DataTable Sel_ComboboxFunc_Valor_A_Alterar(string cbbfuncionario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    string[] items = cbbfuncionario.Split('—');
                    User.Cod_Funcionario = Convert.ToInt16(items[0]);
                    return con.Sel_ComboboxFunc_Valor_A_Alterar(User);
                }
            }
        }


        public static DataTable Sel_Codigo_User(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Pesquisar = pesquisar;
                    return con.Sel_Usuario_Cod(User);
                }
            }
        }

        public static DataTable Sel_Usuario_A_Salvar()
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    return con.Sel_Usuario_A_Salvar();
                }
            }
        }

        public static DataTable Sel_Usuario_A_Alterar(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_Usuario_A_Alterar(User);
                }
            }
        }

        public static DataTable Sel_Funcionario_User(string pesquisar)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    string[] items = pesquisar.Split('—');
                    User.Pesquisar = items[0];
                    return con.Sel_Funcionario_User(User);
                }
            }
        }

        public static DataTable Sel_Funcionario_Usuario()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Funcionario_Usuario();
            }
        }

        public static DataTable Sel_Usuario_Todos()
        {
            using (Con7BD con = new Con7BD())
            {
                return con.Sel_Usuario_Todos();
            }
        }

        public static bool Sel_Usuario_Ver_Nome(string nome_usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    Users.Nome_Usuario = nome_usuario;
                    return con.Sel_Usuario_Ver_Nome(Users);
                }
            }
        }

        public static bool Sel_Permitir_Cadastrar_PDV_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Permitir_Cadastrar_PDV_Usuario(Users) == 1)
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

        public static bool Sel_Permitir_Venda_N_Promissoria_S_Credito_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Permitir_Venda_N_Promissoria_S_Credito_Usuario(Users) == 1)
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

        public static bool Sel_Permitir_Venda_S_Credito_Loja_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Permitir_Venda_S_Credito_Loja_Usuario(Users) == 1)
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

        public static bool Sel_Usuario_Ver_Nome_Alt(string codigo, string nome_usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    Users.Nome_Usuario = nome_usuario;
                    if (con.Sel_Usuario_Ver_Nome_Alt(Users) == Convert.ToInt16(codigo))
                    {
                        return false;
                    }
                    else if (con.Sel_Usuario_Ver_Nome_Alt(Users) == 0)
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

        public static bool Sel_Permitir_Vis_Senha_Usuario(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Permitir_Vis_Senha_Usuario(Users) == 1)
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

        public static bool Sel_User_Abert_Fech_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_User_Abert_Fech_Ver(User);
                }
            }
        }

        public static bool Sel_User_Cadastro_Computadores_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_User_Cadastro_Computadores_Ver(User);
                }
            }
        }

        public static bool Sel_User_Conta_Pagar_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_User_Conta_Pagar_Ver(User);
                }
            }
        }

        public static bool Sel_User_Conta_Receber_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_User_Conta_Receber_Ver(User);
                }
            }
        }

        public static bool Sel_User_Devolucao_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_User_Devolucao_Ver(User);
                }
            }
        }

        public static bool Sel_User_Fluxo_Caixa_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_User_Fluxo_Caixa(User);
                }
            }
        }

        public static bool Sel_User_Orcamento_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_User_Orcamento_Ver(User);
                }
            }
        }

        public static bool Sel_User_Pagamento_Conta_Pagar_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_User_Pagamento_Conta_Pagar_Ver(User);
                }
            }
        }

        public static bool Sel_User_Pagamento_Conta_Receber_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_User_Pagamento_Conta_Receber_Ver(User);
                }
            }
        }

        public static bool Sel_User_Registro_Atividade_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_User_Registro_Atividade_Ver(User);
                }
            }
        }

        public static bool Sel_User_Sangria_Suprimento_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_User_Sangria_Suprimento_Ver(User);
                }
            }
        }

        public static bool Sel_User_Venda_Ver(string codigo)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario User = new Usuario())
                {
                    User.Codigo = Convert.ToInt16(codigo);
                    return con.Sel_User_Venda_Ver(User);
                }
            }
        }


        public static bool Sel_Permitir_Ignorar_Multa_Juros_Receber(string usuario)
        {
            using (Con7BD con = new Con7BD())
            {
                using (Usuario Users = new Usuario())
                {
                    string[] items = usuario.Replace("Usuário(a): ", "").Split('—');
                    //
                    Users.Codigo = Convert.ToInt16(items[0]);
                    //
                    if (con.Sel_Permitir_Ignorar_Multa_Juros_Receber(Users) == 1)
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
    }
}
