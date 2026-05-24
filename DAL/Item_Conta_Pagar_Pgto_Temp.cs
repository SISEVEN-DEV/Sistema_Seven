using System;

namespace DAL
{
    public class Item_Conta_Pagar_Pgto_Temp : IDisposable
    {
        private short _Codigo;
        private short _Cod_Pagamento;
        private string _Tipo;
        private decimal _Valor_Pago;
        private byte _Pagamento_Parcial;
        private short _Cod_Conexao_Configuracoes;

        public short Cod_Conexao_Configuracoes
        {
            get { return _Cod_Conexao_Configuracoes; }
            set { _Cod_Conexao_Configuracoes = value; }
        }

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public short Cod_Pagamento
        {
            get { return _Cod_Pagamento; }
            set { _Cod_Pagamento = value; }
        }

        public byte Pagamento_Parcial
        {
            get { return _Pagamento_Parcial; }
            set { _Pagamento_Parcial = value; }
        }

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public decimal Valor_Pago
        {
            get { return _Valor_Pago; }
            set { _Valor_Pago = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Pagamento = 0;
            _Tipo = null;
            _Valor_Pago = 0;
            _Pagamento_Parcial = 0;
            _Cod_Conexao_Configuracoes = 0;
        }
    }
}
