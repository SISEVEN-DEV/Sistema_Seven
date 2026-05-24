using System;

namespace DAL
{
    public class Pagamento_Venda : IDisposable
    {
        private int _Codigo;
        private short _Cod_Pagamento;
        private short _Cod_Item_Pagamento;
        private string _Tipo;
        private decimal _Valor_Pago;
        private string _Data_Pagamento;
        private string _Hora_Pagamento;
        private int _Cod_Venda;
        private short _Cod_Usuario;
        private string _Nome_Usuario;
        private short _Cod_PDV_Computador;

        public short Cod_Usuario
        {
            get { return _Cod_Usuario; }
            set { _Cod_Usuario = value; }
        }

        public string Nome_Usuario
        {
            get { return _Nome_Usuario; }
            set { _Nome_Usuario = value; }
        }

        public short Cod_PDV_Computador
        {
            get { return _Cod_PDV_Computador; }
            set { _Cod_PDV_Computador = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public short Cod_Item_Pagamento
        {
            get { return _Cod_Item_Pagamento; }
            set { _Cod_Item_Pagamento = value; }
        }

        public short Cod_Pagamento
        {
            get { return _Cod_Pagamento; }
            set { _Cod_Pagamento = value; }
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

        public string Data_Pagamento
        {
            get { return _Data_Pagamento; }
            set { _Data_Pagamento = value; }
        }

        public string Hora_Pagamento
        {
            get { return _Hora_Pagamento; }
            set { _Hora_Pagamento = value; }
        }

        public int Cod_Venda
        {
            get { return _Cod_Venda; }
            set { _Cod_Venda = value; }
        }



        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Pagamento = 0;
            _Cod_Item_Pagamento = 0;
            _Tipo = null;
            _Valor_Pago = 0;
            _Data_Pagamento = null;
            _Hora_Pagamento = null;
            _Cod_Venda = 0;
            _Cod_Usuario = 0;
            _Nome_Usuario = null;
            _Cod_PDV_Computador = 0;
        }
    }
}
