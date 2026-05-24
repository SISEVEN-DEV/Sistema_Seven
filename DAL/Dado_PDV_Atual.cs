using System;

namespace DAL
{
    public class Dado_PDV_Atual : IDisposable
    {
        private int _Cod_Consumidor_Orc;
        private string _Nome_Consumidor_Orc;
        private string _Data_Validade;
        private string _Horario_Validade;
        private string _Observacao_Orc;
        private int _Cod_Consumidor_PDV;
        private string _Nome_Consumidor_PDV;
        private string _CPF_CNPJ_Consumidor_PDV;
        private int _Cod_Consumidor_PDV_2;
        private string _Nome_Consumidor_PDV_2;
        private string _CPF_CNPJ_Consumidor_PDV_2;
        private int _Cod_Devolucao;
        private int _Cod_Orcamento;
        private string _CPF_CNPJ_Consumidor_Orc;
        private decimal _Valor_Desconto_Devolucao;
        private int _Cod_Orcamento_Orc;
        private short _Cod_Conexao_Configuracoes;
        private int _Cod_Venda;

        public int Cod_Venda
        {
            get { return _Cod_Venda; }
            set { _Cod_Venda = value; }
        }

        public short Cod_Conexao_Configuracoes
        {
            get { return _Cod_Conexao_Configuracoes; }
            set { _Cod_Conexao_Configuracoes = value; }
        }

        public int Cod_Orcamento_Orc
        {
            get { return _Cod_Orcamento_Orc; }
            set { _Cod_Orcamento_Orc = value; }
        }

        public decimal Valor_Desconto_Devolucao
        {
            get { return _Valor_Desconto_Devolucao; }
            set { _Valor_Desconto_Devolucao = value; }
        }

        public string CPF_CNPJ_Consumidor_Orc
        {
            get { return _CPF_CNPJ_Consumidor_Orc; }
            set { _CPF_CNPJ_Consumidor_Orc = value; }
        }

        public int Cod_Devolucao
        {
            get { return _Cod_Devolucao; }
            set { _Cod_Devolucao = value; }
        }

        public int Cod_Orcamento
        {
            get { return _Cod_Orcamento; }
            set { _Cod_Orcamento = value; }
        }

        public int Cod_Consumidor_PDV
        {
            get { return _Cod_Consumidor_PDV; }
            set { _Cod_Consumidor_PDV = value; }
        }

        public string Nome_Consumidor_PDV
        {
            get { return _Nome_Consumidor_PDV; }
            set { _Nome_Consumidor_PDV = value; }
        }

        public string CPF_CNPJ_Consumidor_PDV
        {
            get { return _CPF_CNPJ_Consumidor_PDV; }
            set { _CPF_CNPJ_Consumidor_PDV = value; }
        }

        public int Cod_Consumidor_PDV_2
        {
            get { return _Cod_Consumidor_PDV_2; }
            set { _Cod_Consumidor_PDV_2 = value; }
        }

        public string Nome_Consumidor_PDV_2
        {
            get { return _Nome_Consumidor_PDV_2; }
            set { _Nome_Consumidor_PDV_2 = value; }
        }

        public string CPF_CNPJ_Consumidor_PDV_2
        {
            get { return _CPF_CNPJ_Consumidor_PDV_2; }
            set { _CPF_CNPJ_Consumidor_PDV_2 = value; }
        }

        public int Cod_Consumidor_Orc
        {
            get { return _Cod_Consumidor_Orc; }
            set { _Cod_Consumidor_Orc = value; }
        }

        public string Nome_Consumidor_Orc
        {
            get { return _Nome_Consumidor_Orc; }
            set { _Nome_Consumidor_Orc = value; }
        }

        public string Horario_Validade
        {
            get { return _Horario_Validade; }
            set { _Horario_Validade = value; }
        }

        public string Data_Validade
        {
            get { return _Data_Validade; }
            set { _Data_Validade = value; }
        }

        public string Observacao_Orc
        {
            get { return _Observacao_Orc; }
            set { _Observacao_Orc = value; }
        }

        public void Dispose()
        {
            _Cod_Consumidor_Orc = 0; ;
            _Nome_Consumidor_Orc = null;
            _Data_Validade = null;
            _Horario_Validade = null;
            _Observacao_Orc = null;
            _Cod_Consumidor_PDV = 0;
            _Nome_Consumidor_PDV = null;
            _CPF_CNPJ_Consumidor_PDV = null;
            _Cod_Devolucao = 0;
            _Cod_Orcamento = 0;
            _Cod_Consumidor_PDV_2 = 0;
            _Nome_Consumidor_PDV_2 = null;
            _CPF_CNPJ_Consumidor_PDV_2 = null;
            _CPF_CNPJ_Consumidor_Orc = null;
            _Valor_Desconto_Devolucao = 0;
            _Cod_Orcamento_Orc = 0;
            _Cod_Conexao_Configuracoes = 0;
            _Cod_Venda = 0;
        }
    }
}
