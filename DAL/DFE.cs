using System;

namespace DAL
{
    public class DFE : IDisposable
    {
        private int _Codigo;
        private string _Chave_DFe;
        private string _Modelo;
        private string _Observacao;
        private int _Numero_NF;
        private string _Data_Emissao;
        private string _Data_Saida;
        private string _Hora_Saida;
        private string _Hora_Emissao;
        private int _Cod_Emitente_Destinatario;
        private string _Nome_Emitente_Destinatario;
        private decimal _Total_Produtos;
        private decimal _Descontos;
        private decimal _Frete;
        private decimal _Despesas;
        private decimal _Valor_Total_NF;
        private string _Emissao;
        private int _Serie;
        private string _Data_Cadastro;
        private string _Pesquisar;
        private int _Cod_CFOP;
        private string _Descricao_CFOP;
        private byte _Importado;
        private string _Caminho_Dfe;
        private string _Tipo_Emitente_Destinatario;
        private string _Finalidade;
        private decimal _Seguro;
        private decimal _IPI;
        private decimal _ICMS;
        private decimal _ICMS_ST;
        private string _Status;
        private string _Situacao;
        private string _Codigo_Aleatorio;
        private byte _Consumidor_Final;
        private string _Tipo_Operacao;
        private short _N_Seq_CCe;
        private string _N_Protocolo;
        private string _CPF_CNPJ_Emitente_Destinatario;
        private int _Cod_Venda;
        private int _Cod_Devolucao;
        private byte _Origem_Venda;
        private decimal _Base_Calculo_ICMS;
        private decimal _Base_Calculo_ICMS_ST;
        private decimal _Total_Aprox_Trib;
        private decimal _Base_Calculo_IBS_CBS;
        private decimal _IBS_Mun;
        private decimal _IBS_Est;
        private decimal _CBS;

        public decimal Base_Calculo_IBS_CBS 
        {
            get { return _Base_Calculo_IBS_CBS; }
            set { _Base_Calculo_IBS_CBS = value; }
        }

        public decimal IBS_Mun 
        {
            get { return _IBS_Mun; }
            set { _IBS_Mun = value; }
        }

        public decimal IBS_Est 
        {
            get { return _IBS_Est; }
            set {  _IBS_Est = value; }
        }

        public decimal CBS 
        {
            get { return _CBS; }
            set { _CBS = value; }
        }

        public decimal Total_Aprox_Trib
        {
            get { return _Total_Aprox_Trib; }
            set { _Total_Aprox_Trib = value; }
        }

        public decimal Base_Calculo_ICMS
        {
            get { return _Base_Calculo_ICMS; }
            set { _Base_Calculo_ICMS = value; }
        }

        public decimal Base_Calculo_ICMS_ST
        {
            get { return _Base_Calculo_ICMS_ST; }
            set { _Base_Calculo_ICMS_ST = value; }
        }

        public byte Origem_Venda
        {
            get { return _Origem_Venda; }
            set { _Origem_Venda = value; }
        }

        public int Cod_Venda
        {
            get { return _Cod_Venda; }
            set { _Cod_Venda = value; }
        }

        public int Cod_Devolucao
        {
            get { return _Cod_Devolucao; }
            set { _Cod_Devolucao = value; }
        }

        public string CPF_CNPJ_Emitente_Destinatario
        {
            get { return _CPF_CNPJ_Emitente_Destinatario; }
            set { _CPF_CNPJ_Emitente_Destinatario = value; }
        }

        public string N_Protocolo
        {
            get { return _N_Protocolo; }
            set { _N_Protocolo = value; }
        }

        public short N_Seq_CCe
        {
            get { return _N_Seq_CCe; }
            set { _N_Seq_CCe = value; }
        }

        public byte Consumidor_Final
        {
            get { return _Consumidor_Final; }
            set { _Consumidor_Final = value; }
        }

        public string Tipo_Operacao
        {
            get { return _Tipo_Operacao; }
            set { _Tipo_Operacao = value; }
        }

        public string Codigo_Aleatorio
        {
            get { return _Codigo_Aleatorio; }
            set { _Codigo_Aleatorio = value; }
        }

        public string Situacao
        {
            get { return _Situacao; }
            set { _Situacao = value; }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public decimal ICMS
        {
            get { return _ICMS; }
            set { _ICMS = value; }
        }

        public decimal ICMS_ST
        {
            get { return _ICMS_ST; }
            set { _ICMS_ST = value; }
        }

        public decimal Seguro
        {
            get { return _Seguro; }
            set { _Seguro = value; }
        }

        public decimal IPI
        {
            get { return _IPI; }
            set { _IPI = value; }
        }

        public string Finalidade
        {
            get { return _Finalidade; }
            set { _Finalidade = value; }
        }

        public string Tipo_Emitente_Destinatario
        {
            get { return _Tipo_Emitente_Destinatario; }
            set { _Tipo_Emitente_Destinatario = value; }
        }

        public string Caminho_Dfe
        {
            get { return _Caminho_Dfe; }
            set { _Caminho_Dfe = value; }
        }

        public byte Importado
        {
            get { return _Importado; }
            set { _Importado = value; }
        }

        public int Cod_CFOP
        {
            get { return _Cod_CFOP; }
            set { _Cod_CFOP = value; }
        }

        public string Descricao_CFOP
        {
            get { return _Descricao_CFOP; }
            set { _Descricao_CFOP = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Data_Cadastro
        {
            get { return _Data_Cadastro; }
            set { _Data_Cadastro = value; }
        }

        public string Chave_DFe
        {
            get { return _Chave_DFe; }
            set { _Chave_DFe = value; }
        }

        public string Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        public string Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        public int Numero_NF
        {
            get { return _Numero_NF; }
            set { _Numero_NF = value; }
        }

        public string Data_Emissao
        {
            get { return _Data_Emissao; }
            set { _Data_Emissao = value; }
        }

        public string Data_Saida
        {
            get { return _Data_Saida; }
            set { _Data_Saida = value; }
        }

        public string Hora_Saida
        {
            get { return _Hora_Saida; }
            set { _Hora_Saida = value; }
        }

        public string Hora_Emissao
        {
            get { return _Hora_Emissao; }
            set { _Hora_Emissao = value; }
        }

        public int Cod_Emitente_Destinatario
        {
            get { return _Cod_Emitente_Destinatario; }
            set { _Cod_Emitente_Destinatario = value; }
        }

        public string Nome_Emitente_Destinatario
        {
            get { return _Nome_Emitente_Destinatario; }
            set { _Nome_Emitente_Destinatario = value; }
        }

        public decimal Total_Produtos
        {
            get { return _Total_Produtos; }
            set { _Total_Produtos = value; }
        }

        public decimal Descontos
        {
            get { return _Descontos; }
            set { _Descontos = value; }
        }

        public decimal Frete
        {
            get { return _Frete; }
            set { _Frete = value; }
        }

        public decimal Despesas
        {
            get { return _Despesas; }
            set { _Despesas = value; }
        }

        public decimal Valor_Total_NF
        {
            get { return _Valor_Total_NF; }
            set { _Valor_Total_NF = value; }
        }

        public string Emissao
        {
            get { return _Emissao; }
            set { _Emissao = value; }
        }

        public int Serie
        {
            get { return _Serie; }
            set { _Serie = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public void Dispose()
        {
            _Importado = 0;
            _Descricao_CFOP = null;
            _Cod_CFOP = 0;
            _Chave_DFe = null;
            _Modelo = null;
            _Observacao = null;
            _Numero_NF = 0;
            _Data_Emissao = null;
            _Data_Saida = null;
            _Hora_Saida = null;
            _Hora_Emissao = null;
            _Cod_Emitente_Destinatario = 0;
            _Nome_Emitente_Destinatario = null;
            _Total_Produtos = 0;
            _Descontos = 0;
            _Frete = 0;
            _Despesas = 0;
            _Valor_Total_NF = 0;
            _Emissao = null;
            _Serie = 0;
            _Data_Cadastro = null;
            _Pesquisar = null;
            _Codigo = 0;
            _Caminho_Dfe = null;
            _Tipo_Emitente_Destinatario = null;
            _Finalidade = null;
            _IPI = 0;
            _Seguro = 0;
            _ICMS = 0;
            _ICMS_ST = 0;
            _Status = null;
            _Situacao = null;
            _Codigo_Aleatorio = null;
            _Consumidor_Final = 0;
            _Tipo_Operacao = null;
            _N_Seq_CCe = 0;
            _N_Protocolo = null;
            _CPF_CNPJ_Emitente_Destinatario = null;
            _Cod_Venda = 0;
            _Cod_Devolucao = 0;
            _Origem_Venda = 0;
            _Base_Calculo_ICMS = 0;
            _Base_Calculo_ICMS_ST = 0;
            _Total_Aprox_Trib = 0;
            _Base_Calculo_IBS_CBS = 0;
            _IBS_Mun = 0;
            _IBS_Est = 0; 
            _CBS = 0; 
        }
    }
}
