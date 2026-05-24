using System;

namespace DAL
{
    public class Usuario : IDisposable
    {
        private short _Codigo;
        private string _Nome_Usuario;
        private string _Senha;
        private short _Cod_Funcionario;
        private string _Nome_Funcionario;
        private string _Pesquisar;
        private byte _Realizar_Orcamento;
        private byte _Realizar_Devolucao;
        private byte _Permitir_Canc_Exc_Item_Venda;
        private byte _Capturar_Orcamento;
        private byte _Capturar_Devolucao;
        private byte _Permissao_Usuarios;
        private byte _Permitir_Desc_Pag;
        private byte _Permitir_Acresc_Pag;
        private byte _Permitir_Fin_PDV;
        private byte _Permitir_Alt_Prod_Item;
        private byte _Mostrar_Dados_Prod_Item;
        private decimal _Desconto_Porc_Max_Venda;
        private decimal _Acrescimo_Porc_Max_Venda;
        private byte _Permitir_Abrir_Caixa;
        private byte _Permitir_Fechar_Caixa;
        private byte _Permitir_Real_SangSup;
        private byte _Permitir_Real_Conta_Receber;
        private byte _Permitir_Real_Conta_Pagar;
        private byte _Cadastrar_Cliente_Consumidor;
        private byte _Cadastrar_Conta_Pagar;
        private byte _Cadastrar_Conta_Receber;
        private byte _Cadastrar_Entidade_Bancaria;
        private byte _Cadastrar_Forma_Pagamento;
        private byte _Cadastrar_Fornecedor;
        private byte _Cadastrar_Funcionario;
        private byte _Cadastrar_Grupo;
        private byte _Cadastrar_Localizacao;
        private byte _Cadastrar_Marca;
        private byte _Cadastrar_Produto;
        private byte _Cadastrar_Subgrupo;
        private byte _Cadastrar_Usuario;
        private byte _Cadastrar_CFOP_NatOp;
        private byte _Permitir_Pausar_Caixa;
        private byte _Permitir_Vis_Hist_Caixa;
        private byte _Permitir_Cad_No_Pdv;
        private byte _Permitir_Venda_N_Promissoria_S_Credito;
        private byte _Rel_Abert_Fech_Caixa;
        private byte _Rel_Cliente_Consumidor;
        private byte _Rel_Conta_Pagar;
        private byte _Rel_Conta_Receber;
        private byte _Rel_Produtos_Servico;
        private byte _Rel_Orcamento;
        private byte _Rel_Venda;
        private byte _Rel_Aniversariante;
        private byte _Rel_Grupo;
        private byte _Rel_Funcionario;
        private byte _Rel_Formas_Pagamento;
        private byte _Rel_Fornecedor;
        private byte _Rel_Subgrupo;
        private byte _Rel_Historico_Caixa;
        private byte _Rel_Fluxo_Caixa;
        private byte _Rel_DFe;
        private byte _Rel_Saida_Produto;
        private byte _Rel_Entrada_Produto;
        private byte _Rel_Sangria_Suprimento;
        private byte _Rel_Devolucao_Servico;
        private byte _Permitir_Vis_Senha_Usuario;
        private byte _Permitir_Ignorar_Multa_Juros_Receber;
        private byte _Permitir_Exc_Sang_Sup;
        private byte _Rel_Usuario;
        private string _Data_Cadastro;
        private byte _Rel_Marca;
        private byte _Rel_Localizacao;
        private byte _Permitir_Venda_S_Credito_Loja;
        private byte _Permitir_Alt_Dados_Emp;
        private byte _Permitir_Alt_Dados_Config;
        private byte _Criar_Lembrete_Conta_Pagar;
        private byte _Criar_Lembrete_Conta_Receber;
        private byte _Criar_Conta_a_Pagar_DFe;
        private byte _Criar_Lembrete_Validade;
        private byte _Cadastrar_DFe;
        private byte _Rel_Reg_Atividade;
        private byte _Rel_Reg_Validade_Prod_Serv;
        private byte _Permitir_Atualizar_Zerar_Estoque;
        private byte _Rel_Estoque;
        private byte _Permitir_Excluir_Inventario;
        private byte _Capturar_Venda;
        private byte _Cadastrar_Servico;
        private byte _Permitir_Excluir_OS;
        private byte _Cadastrar_OS;
        private byte _Cadastrar_PSPPIX;
        private byte _Acessar_Menu_NFe_NFCe;
        private byte _Acessar_Menu_NFSe;
        private byte _Cadastrar_NFe;
        private byte _Rel_Comissao;
        private byte _Rel_OS;
        private byte _Rel_Controle_Cheque;
        private byte _Cadastrar_Documentos;
        private byte _Permitir_Desfazer_Baixa;

        public byte Permitir_Desfazer_Baixa
        {
            get { return _Permitir_Desfazer_Baixa; }
            set { _Permitir_Desfazer_Baixa = value; }
        }

        public byte Cadastrar_Documentos
        {
            get { return _Cadastrar_Documentos; }
            set { _Cadastrar_Documentos = value; }
        }

        public byte Rel_Controle_Cheque
        {
            get { return _Rel_Controle_Cheque; }
            set { _Rel_Controle_Cheque = value; }
        }

        public byte Rel_OS
        {
            get { return _Rel_OS; }
            set { _Rel_OS = value; }
        }

        public byte Rel_Comissao
        {
            get { return _Rel_Comissao; }
            set { _Rel_Comissao = value; }
        }

        public byte Cadastrar_NFe
        {
            get { return _Cadastrar_NFe; }
            set { _Cadastrar_NFe = value; }
        }

        public byte Acessar_Menu_NFe_NFCe
        {
            get { return _Acessar_Menu_NFe_NFCe; }
            set { _Acessar_Menu_NFe_NFCe = value; }
        }

        public byte Acessar_Menu_NFSe
        {
            get { return _Acessar_Menu_NFSe; }
            set { _Acessar_Menu_NFSe = value; }
        }

        public byte Cadastrar_PSPPIX
        {
            get { return _Cadastrar_PSPPIX; }
            set { _Cadastrar_PSPPIX = value; }
        }

        public byte Cadastrar_OS
        {
            get { return _Cadastrar_OS; }
            set { _Cadastrar_OS = value; }
        }

        public byte Permitir_Excluir_OS
        {
            get { return _Permitir_Excluir_OS; }
            set { _Permitir_Excluir_OS = value; }
        }

        public byte Cadastrar_Servico
        {
            get { return _Cadastrar_Servico; }
            set { _Cadastrar_Servico = value; }
        }

        public byte Capturar_Venda
        {
            get { return _Capturar_Venda; }
            set { _Capturar_Venda = value; }
        }

        public byte Permitir_Excluir_Inventario
        {
            get { return _Permitir_Excluir_Inventario; }
            set { _Permitir_Excluir_Inventario = value; }
        }

        public byte Rel_Estoque
        {
            get { return _Rel_Estoque; }
            set { _Rel_Estoque = value; }
        }

        public byte Permitir_Atualizar_Zerar_Estoque
        {
            get { return _Permitir_Atualizar_Zerar_Estoque; }
            set { _Permitir_Atualizar_Zerar_Estoque = value; }
        }

        public byte Rel_Reg_Validade_Prod_Serv
        {
            get { return _Rel_Reg_Validade_Prod_Serv; }
            set { _Rel_Reg_Validade_Prod_Serv = value; }
        }

        public byte Rel_Reg_Atividade
        {
            get { return _Rel_Reg_Atividade; }
            set { _Rel_Reg_Atividade = value; }
        }

        public byte Cadastrar_DFe
        {
            get { return _Cadastrar_DFe; }
            set { _Cadastrar_DFe = value; }
        }

        public byte Rel_Aniversariante
        {
            get { return _Rel_Aniversariante; }
            set { _Rel_Aniversariante = value; }
        }

        public byte Rel_DFe
        {
            get { return _Rel_DFe; }
            set { _Rel_DFe = value; }
        }

        public byte Cadastrar_CFOP_NatOp
        {
            get { return _Cadastrar_CFOP_NatOp; }
            set { _Cadastrar_CFOP_NatOp = value; }
        }

        public byte Criar_Lembrete_Validade
        {
            get { return _Criar_Lembrete_Validade; }
            set { _Criar_Lembrete_Validade = value; }
        }

        public byte Criar_Lembrete_Conta_Pagar
        {
            get { return _Criar_Lembrete_Conta_Pagar; }
            set { _Criar_Lembrete_Conta_Pagar = value; }
        }

        public byte Criar_Lembrete_Conta_Receber
        {
            get { return _Criar_Lembrete_Conta_Receber; }
            set { _Criar_Lembrete_Conta_Receber = value; }
        }

        public byte Criar_Conta_a_Pagar_DFe
        {
            get { return _Criar_Conta_a_Pagar_DFe; }
            set { _Criar_Conta_a_Pagar_DFe = value; }
        }

        public byte Permitir_Venda_S_Credito_Loja
        {
            get { return _Permitir_Venda_S_Credito_Loja; }
            set { _Permitir_Venda_S_Credito_Loja = value; }
        }

        public byte Permitir_Alt_Dados_Config
        {
            get { return _Permitir_Alt_Dados_Config; }
            set { _Permitir_Alt_Dados_Config = value; }
        }

        public byte Permitir_Alt_Dados_Emp
        {
            get { return _Permitir_Alt_Dados_Emp; }
            set { _Permitir_Alt_Dados_Emp = value; }
        }

        public byte Rel_Marca
        {
            get { return _Rel_Marca; }
            set { _Rel_Marca = value; }
        }

        public byte Rel_Localizacao
        {
            get { return _Rel_Localizacao; }
            set { _Rel_Localizacao = value; }
        }

        public string Data_Cadastro
        {
            get { return _Data_Cadastro; }
            set { _Data_Cadastro = value; }
        }

        public byte Rel_Usuario
        {
            get { return _Rel_Usuario; }
            set { _Rel_Usuario = value; }
        }

        public byte Permitir_Exc_Sang_Sup
        {
            get { return _Permitir_Exc_Sang_Sup; }
            set { _Permitir_Exc_Sang_Sup = value; }
        }

        public byte Permitir_Ignorar_Multa_Juros_Receber
        {
            get { return _Permitir_Ignorar_Multa_Juros_Receber; }
            set { _Permitir_Ignorar_Multa_Juros_Receber = value; }
        }

        public byte Permitir_Vis_Senha_Usuario
        {
            get { return _Permitir_Vis_Senha_Usuario; }
            set { _Permitir_Vis_Senha_Usuario = value; }
        }

        public byte Permitir_Real_SangSup
        {
            get { return _Permitir_Real_SangSup; }
            set { _Permitir_Real_SangSup = value; }
        }

        public byte Permitir_Real_Conta_Receber
        {
            get { return _Permitir_Real_Conta_Receber; }
            set { _Permitir_Real_Conta_Receber = value; }
        }

        public byte Permitir_Real_Conta_Pagar
        {
            get { return _Permitir_Real_Conta_Pagar; }
            set { _Permitir_Real_Conta_Pagar = value; }
        }

        public byte Permitir_Abrir_Caixa
        {
            get { return _Permitir_Abrir_Caixa; }
            set { _Permitir_Abrir_Caixa = value; }
        }

        public byte Rel_Abert_Fech_Caixa
        {
            get { return _Rel_Abert_Fech_Caixa; }
            set { _Rel_Abert_Fech_Caixa = value; }
        }

        public byte Rel_Cliente_Consumidor
        {
            get { return _Rel_Cliente_Consumidor; }
            set { _Rel_Cliente_Consumidor = value; }
        }

        public byte Rel_Conta_Pagar
        {
            get { return _Rel_Conta_Pagar; }
            set { _Rel_Conta_Pagar = value; }
        }

        public byte Rel_Conta_Receber
        {
            get { return _Rel_Conta_Receber; }
            set { _Rel_Conta_Receber = value; }
        }

        public byte Rel_Produtos_Servico
        {
            get { return _Rel_Produtos_Servico; }
            set { _Rel_Produtos_Servico = value; }
        }

        public byte Rel_Orcamento
        {
            get { return _Rel_Orcamento; }
            set { _Rel_Orcamento = value; }
        }

        public byte Rel_Venda
        {
            get { return _Rel_Venda; }
            set { _Rel_Venda = value; }
        }

        public byte Rel_Grupo
        {
            get { return _Rel_Grupo; }
            set { _Rel_Grupo = value; }
        }

        public byte Rel_Funcionario
        {
            get { return _Rel_Funcionario; }
            set { _Rel_Funcionario = value; }
        }

        public byte Rel_Formas_Pagamento
        {
            get { return _Rel_Formas_Pagamento; }
            set { _Rel_Formas_Pagamento = value; }
        }

        public byte Rel_Fornecedor
        {
            get { return _Rel_Fornecedor; }
            set { _Rel_Fornecedor = value; }
        }

        public byte Rel_Subgrupo
        {
            get { return _Rel_Subgrupo; }
            set { _Rel_Subgrupo = value; }
        }

        public byte Rel_Historico_Caixa
        {
            get { return _Rel_Historico_Caixa; }
            set { _Rel_Historico_Caixa = value; }
        }

        public byte Rel_Fluxo_Caixa
        {
            get { return _Rel_Fluxo_Caixa; }
            set { _Rel_Fluxo_Caixa = value; }
        }

        public byte Rel_Saida_Produto
        {
            get { return _Rel_Saida_Produto; }
            set { _Rel_Saida_Produto = value; }
        }

        public byte Rel_Entrada_Produto
        {
            get { return _Rel_Entrada_Produto; }
            set { _Rel_Entrada_Produto = value; }
        }

        public byte Rel_Sangria_Suprimento
        {
            get { return _Rel_Sangria_Suprimento; }
            set { _Rel_Sangria_Suprimento = value; }
        }

        public byte Rel_Devolucao_Servico
        {
            get { return _Rel_Devolucao_Servico; }
            set { _Rel_Devolucao_Servico = value; }
        }

        public byte Permitir_Fechar_Caixa
        {
            get { return _Permitir_Fechar_Caixa; }
            set { _Permitir_Fechar_Caixa = value; }
        }

        public decimal Desconto_Porc_Max_Venda
        {
            get { return _Desconto_Porc_Max_Venda; }
            set { _Desconto_Porc_Max_Venda = value; }
        }

        public decimal Acrescimo_Porc_Max_Venda
        {
            get { return _Acrescimo_Porc_Max_Venda; }
            set { _Acrescimo_Porc_Max_Venda = value; }
        }

        public byte Permitir_Pausar_Caixa
        {
            get { return _Permitir_Pausar_Caixa; }
            set { _Permitir_Pausar_Caixa = value; }
        }

        public byte Mostrar_Dados_Prod_Item
        {
            get { return _Mostrar_Dados_Prod_Item; }
            set { _Mostrar_Dados_Prod_Item = value; }
        }

        public byte Permitir_Alt_Prod_Item
        {
            get { return _Permitir_Alt_Prod_Item; }
            set { _Permitir_Alt_Prod_Item = value; }
        }

        public byte Permitir_Fin_PDV
        {
            get { return _Permitir_Fin_PDV; }
            set { _Permitir_Fin_PDV = value; }
        }

        public byte Permitir_Acresc_Pag
        {
            get { return _Permitir_Acresc_Pag; }
            set { _Permitir_Acresc_Pag = value; }
        }

        public byte Permitir_Desc_Pag
        {
            get { return _Permitir_Desc_Pag; }
            set { _Permitir_Desc_Pag = value; }
        }

        public byte Permissao_Usuarios
        {
            get { return _Permissao_Usuarios; }
            set { _Permissao_Usuarios = value; }
        }

        public byte Permitir_Vis_Hist_Caixa
        {
            get { return _Permitir_Vis_Hist_Caixa; }
            set { _Permitir_Vis_Hist_Caixa = value; }
        }

        public byte Permitir_Cad_No_Pdv
        {
            get { return _Permitir_Cad_No_Pdv; }
            set { _Permitir_Cad_No_Pdv = value; }
        }

        public byte Permitir_Venda_N_Promissoria_S_Credito
        {
            get { return _Permitir_Venda_N_Promissoria_S_Credito; }
            set { _Permitir_Venda_N_Promissoria_S_Credito = value; }
        }

        public byte Capturar_Devolucao
        {
            get { return _Capturar_Devolucao; }
            set { _Capturar_Devolucao = value; }
        }

        public byte Capturar_Orcamento
        {
            get { return _Capturar_Orcamento; }
            set { _Capturar_Orcamento = value; }
        }

        public byte Realizar_Orcamento
        {
            get { return _Realizar_Orcamento; }
            set { _Realizar_Orcamento = value; }
        }

        public byte Realizar_Devolucao
        {
            get { return _Realizar_Devolucao; }
            set { _Realizar_Devolucao = value; }
        }

        public byte Permitir_Canc_Exc_Item_Venda
        {
            get { return _Permitir_Canc_Exc_Item_Venda; }
            set { _Permitir_Canc_Exc_Item_Venda = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public short Cod_Funcionario
        {
            get { return _Cod_Funcionario; }
            set { _Cod_Funcionario = value; }
        }

        public string Nome_Funcionario
        {
            get { return _Nome_Funcionario; }
            set { _Nome_Funcionario = value; }
        }

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Nome_Usuario
        {
            get { return _Nome_Usuario; }
            set { _Nome_Usuario = value; }
        }

        public string Senha
        {
            get { return _Senha; }
            set { _Senha = value; }
        }

        public byte Cadastrar_Cliente_Consumidor
        {
            get { return _Cadastrar_Cliente_Consumidor; }
            set { _Cadastrar_Cliente_Consumidor = value; }
        }

        public byte Cadastrar_Conta_Pagar
        {
            get { return _Cadastrar_Conta_Pagar; }
            set { _Cadastrar_Conta_Pagar = value; }
        }

        public byte Cadastrar_Conta_Receber
        {
            get { return _Cadastrar_Conta_Receber; }
            set { _Cadastrar_Conta_Receber = value; }
        }

        public byte Cadastrar_Entidade_Bancaria
        {
            get { return _Cadastrar_Entidade_Bancaria; }
            set { _Cadastrar_Entidade_Bancaria = value; }
        }

        public byte Cadastrar_Forma_Pagamento
        {
            get { return _Cadastrar_Forma_Pagamento; }
            set { _Cadastrar_Forma_Pagamento = value; }
        }

        public byte Cadastrar_Fornecedor
        {
            get { return _Cadastrar_Fornecedor; }
            set { _Cadastrar_Fornecedor = value; }
        }

        public byte Cadastrar_Funcionario
        {
            get { return _Cadastrar_Funcionario; }
            set { _Cadastrar_Funcionario = value; }
        }

        public byte Cadastrar_Grupo
        {
            get { return _Cadastrar_Grupo; }
            set { _Cadastrar_Grupo = value; }
        }

        public byte Cadastrar_Localizacao
        {
            get { return _Cadastrar_Localizacao; }
            set { _Cadastrar_Localizacao = value; }
        }

        public byte Cadastrar_Marca
        {
            get { return _Cadastrar_Marca; }
            set { _Cadastrar_Marca = value; }
        }

        public byte Cadastrar_Produto
        {
            get { return _Cadastrar_Produto; }
            set { _Cadastrar_Produto = value; }
        }

        public byte Cadastrar_Subgrupo
        {
            get { return _Cadastrar_Subgrupo; }
            set { _Cadastrar_Subgrupo = value; }
        }

        public byte Cadastrar_Usuario
        {
            get { return _Cadastrar_Usuario; }
            set { _Cadastrar_Usuario = value; }
        }

        public void Dispose()
        {
            _Rel_OS = 0;
            _Permitir_Excluir_Inventario = 0;
            _Rel_Estoque = 0;
            _Codigo = 0;
            _Nome_Usuario = null;
            _Senha = null;
            _Cod_Funcionario = 0;
            _Nome_Funcionario = null;
            _Pesquisar = null;
            _Realizar_Orcamento = 0;
            _Realizar_Devolucao = 0;
            _Permitir_Canc_Exc_Item_Venda = 0;
            _Capturar_Orcamento = 0;
            _Capturar_Devolucao = 0;
            _Permissao_Usuarios = 0;
            _Permitir_Desc_Pag = 0;
            _Permitir_Acresc_Pag = 0;
            _Permitir_Fin_PDV = 0;
            _Permitir_Alt_Prod_Item = 0;
            _Mostrar_Dados_Prod_Item = 0;
            _Acrescimo_Porc_Max_Venda = 0;
            _Desconto_Porc_Max_Venda = 0;
            _Permitir_Abrir_Caixa = 0;
            _Permitir_Fechar_Caixa = 0;
            _Permitir_Real_SangSup = 0;
            _Permitir_Real_Conta_Receber = 0;
            _Permitir_Real_Conta_Pagar = 0;
            _Cadastrar_Cliente_Consumidor = 0;
            _Cadastrar_Conta_Pagar = 0;
            _Cadastrar_Conta_Receber = 0;
            _Cadastrar_Entidade_Bancaria = 0;
            _Cadastrar_Forma_Pagamento = 0;
            _Cadastrar_Fornecedor = 0;
            _Cadastrar_Funcionario = 0;
            _Cadastrar_Grupo = 0;
            _Cadastrar_Localizacao = 0;
            _Cadastrar_Marca = 0;
            _Cadastrar_Produto = 0;
            _Cadastrar_Subgrupo = 0;
            _Cadastrar_Usuario = 0;
            _Permitir_Pausar_Caixa = 0;
            _Permitir_Vis_Hist_Caixa = 0;
            _Permitir_Cad_No_Pdv = 0;
            _Permitir_Venda_N_Promissoria_S_Credito = 0;
            _Rel_Abert_Fech_Caixa = 0;
            _Rel_Cliente_Consumidor = 0;
            _Rel_Conta_Pagar = 0;
            _Rel_Conta_Receber = 0;
            _Rel_Produtos_Servico = 0;
            _Rel_Orcamento = 0;
            _Rel_Venda = 0;
            _Rel_Grupo = 0;
            _Rel_Funcionario = 0;
            _Rel_Formas_Pagamento = 0;
            _Rel_Fornecedor = 0;
            _Rel_Subgrupo = 0;
            _Rel_Historico_Caixa = 0;
            _Rel_Fluxo_Caixa = 0;
            _Rel_Saida_Produto = 0;
            _Rel_Entrada_Produto = 0;
            _Rel_Sangria_Suprimento = 0;
            _Rel_Devolucao_Servico = 0;
            _Permitir_Vis_Senha_Usuario = 0;
            _Permitir_Ignorar_Multa_Juros_Receber = 0;
            _Permitir_Exc_Sang_Sup = 0;
            _Rel_Usuario = 0;
            _Data_Cadastro = null;
            _Rel_Marca = 0;
            _Rel_Localizacao = 0;
            _Permitir_Venda_S_Credito_Loja = 0;
            _Permitir_Alt_Dados_Emp = 0;
            _Permitir_Alt_Dados_Config = 0;
            _Criar_Lembrete_Conta_Pagar = 0;
            _Criar_Lembrete_Conta_Receber = 0;
            _Criar_Conta_a_Pagar_DFe = 0;
            _Criar_Lembrete_Validade = 0;
            _Cadastrar_CFOP_NatOp = 0;
            _Rel_Aniversariante = 0;
            _Rel_DFe = 0;
            _Cadastrar_DFe = 0;
            _Rel_Reg_Atividade = 0;
            _Rel_Reg_Validade_Prod_Serv = 0;
            _Permitir_Atualizar_Zerar_Estoque = 0;
            _Capturar_Venda = 0;
            _Cadastrar_Servico = 0;
            _Permitir_Excluir_OS = 0;
            _Cadastrar_OS = 0;
            _Cadastrar_PSPPIX = 0;
            _Acessar_Menu_NFe_NFCe = 0;
            _Acessar_Menu_NFSe = 0;
            _Cadastrar_NFe = 0;
            _Rel_Comissao = 0;
            _Rel_Controle_Cheque = 0;
            _Cadastrar_Documentos = 0;
            _Permitir_Desfazer_Baixa = 0;
        }
    }
}
