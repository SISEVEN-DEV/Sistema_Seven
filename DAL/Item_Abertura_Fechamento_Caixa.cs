using System;

namespace DAL
{
    public class Item_Abertura_Fechamento_Caixa : IDisposable
    {
        private int _Codigo;
        private short _Cod_Forma_Pagamento;
        private string _Tipo;
        private decimal _Total;
        private decimal _Valor_Informado;
        private decimal _Quebra_Caixa;
        private int _Cod_Abertura_Fechamento_Caixa;

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

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        public decimal Valor_Informado
        {
            get { return _Valor_Informado; }
            set { _Valor_Informado = value; }
        }

        public decimal Quebra_Caixa
        {
            get { return _Quebra_Caixa; }
            set { _Quebra_Caixa = value; }
        }

        public int Cod_Abertura_Fechamento_Caixa
        {
            get { return _Cod_Abertura_Fechamento_Caixa; }
            set { _Cod_Abertura_Fechamento_Caixa = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Forma_Pagamento = 0;
            _Tipo = null;
            _Total = 0;
            _Valor_Informado = 0;
            _Quebra_Caixa = 0;
            _Cod_Abertura_Fechamento_Caixa = 0;
        }
    }
}
