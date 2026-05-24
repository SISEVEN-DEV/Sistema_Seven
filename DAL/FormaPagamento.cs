using System;

namespace DAL
{
    public class FormaPagamento : IDisposable
    {
        private short _Codigo;
        private string _Descricao;
        private decimal _Entrada_Porc;
        private short _Parcela;
        private short _Dia_Primeiro_Pagamento;
        private string _Tipo;
        private decimal _Desconto_Fixo_Porc;
        private decimal _Acrescimo_Fixo_Porc;
        private string _Pesquisar;
        private decimal _Multa_Porc;
        private decimal _Juros_Mora_Porc;
        private string _Data_Cadastro;
        private short _Cod_Entidade_Bancaria;
        private string _Desc_Entidade_Bancaria;
        private string _Tipo_Operacao;
        private decimal _Desconto_Porc;
        private short _Dia_Duracao_Desconto;

        public decimal Desconto_Porc
        {
            get { return _Desconto_Porc; }
            set { _Desconto_Porc = value; }
        }

        public short Dia_Duracao_Desconto
        {
            get { return _Dia_Duracao_Desconto; }
            set { _Dia_Duracao_Desconto = value; }
        }

        public short Cod_Entidade_Bancaria
        {
            get { return _Cod_Entidade_Bancaria; }
            set { _Cod_Entidade_Bancaria = value; }
        }

        public string Desc_Entidade_Bancaria
        {
            get { return _Desc_Entidade_Bancaria; }
            set { _Desc_Entidade_Bancaria = value; }
        }

        public string Tipo_Operacao
        {
            get { return _Tipo_Operacao; }
            set { _Tipo_Operacao = value; }
        }

        public decimal Juros_Mora_Porc
        {
            get { return _Juros_Mora_Porc; }
            set { _Juros_Mora_Porc = value; }
        }

        public decimal Desconto_Fixo_Porc
        {
            get { return _Desconto_Fixo_Porc; }
            set { _Desconto_Fixo_Porc = value; }
        }

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public short Dia_Primeiro_Pagamento
        {
            get { return _Dia_Primeiro_Pagamento; }
            set { _Dia_Primeiro_Pagamento = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public string Data_Cadastro
        {
            get { return _Data_Cadastro; }
            set { _Data_Cadastro = value; }
        }

        public decimal Acrescimo_Fixo_Porc
        {
            get { return _Acrescimo_Fixo_Porc; }
            set { _Acrescimo_Fixo_Porc = value; }
        }

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public decimal Multa_Porc
        {
            get { return _Multa_Porc; }
            set { _Multa_Porc = value; }
        }

        public decimal Entrada_Porc
        {
            get { return _Entrada_Porc; }
            set { _Entrada_Porc = value; }
        }

        public short Parcela
        {
            get { return _Parcela; }
            set { _Parcela = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Descricao = null;
            _Multa_Porc = 0;
            _Entrada_Porc = 0;
            _Parcela = 0;
            _Dia_Primeiro_Pagamento = 0;
            _Acrescimo_Fixo_Porc = 0;
            _Tipo = null;
            _Desconto_Fixo_Porc = 0;
            _Pesquisar = null;
            _Juros_Mora_Porc = 0;
            _Data_Cadastro = null;
            _Cod_Entidade_Bancaria = 0;
            _Desc_Entidade_Bancaria = null;
            _Tipo_Operacao = null;
            _Desconto_Porc = 0;
            _Dia_Duracao_Desconto = 0;
        }
    }
}
