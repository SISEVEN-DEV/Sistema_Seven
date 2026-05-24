using System;

namespace DAL
{
    public class Pagamento : IDisposable
    {
        private int _Codigo;
        private short _Cod_Forma_Pagamento;
        private string _Descricao_Forma_Pagamento;
        private string _Tipo_Forma_Pagamento;
        private decimal _Valor_Pago;
        byte _Cod_Ordem;
        private int _Cod_Orcamento;

        public byte Cod_Ordem
        {
            get { return _Cod_Ordem; }
            set { _Cod_Ordem = value; }
        }

        public string Tipo_Forma_Pagamento
        {
            get { return _Tipo_Forma_Pagamento; }
            set { _Tipo_Forma_Pagamento = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public short Cod_Forma_Pagamento
        {
            get { return _Cod_Forma_Pagamento; }
            set { _Cod_Forma_Pagamento = value; }
        }

        public string Descricao_Forma_Pagamento
        {
            get { return _Descricao_Forma_Pagamento; }
            set { _Descricao_Forma_Pagamento = value; }
        }

        public decimal Valor_Pago
        {
            get { return _Valor_Pago; }
            set { _Valor_Pago = value; }
        }

        public int Cod_Orcamento
        {
            get { return _Cod_Orcamento; }
            set { _Cod_Orcamento = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Forma_Pagamento = 0;
            _Descricao_Forma_Pagamento = null;
            _Valor_Pago = 0;
            _Cod_Orcamento = 0;
            _Tipo_Forma_Pagamento = null;
            _Cod_Ordem = 0;
        }
    }
}