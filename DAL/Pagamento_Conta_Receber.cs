using System;

namespace DAL
{
    public class Pagamento_Conta_Receber : IDisposable
    {
        private int _Codigo;
        private short _Cod_Pagamento;
        private short _Cod_Item_Pagamento;
        private string _Tipo;
        private decimal _Valor_Pago;
        private string _Data_Pagamento;
        private string _Hora_Pagamento;
        private int _Cod_Conta_Receber;
        private byte _Pagamento_Parcial;
        private short _Cod_Usuario;
        private string _Nome_Usuario;
        private short _Cod_PDV_Computador;

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public byte Pagamento_Parcial
        {
            get { return _Pagamento_Parcial; }
            set { _Pagamento_Parcial = value; }
        }

        public short Cod_PDV_Computador
        {
            get { return _Cod_PDV_Computador; }
            set { _Cod_PDV_Computador = value; }
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

        public int Cod_Conta_Receber
        {
            get { return _Cod_Conta_Receber; }
            set { _Cod_Conta_Receber = value; }
        }

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

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Pagamento = 0;
            _Cod_Item_Pagamento = 0;
            _Tipo = null;
            _Hora_Pagamento = null;
            _Data_Pagamento = null;
            _Valor_Pago = 0;
            _Cod_Conta_Receber = 0;
            _Pagamento_Parcial = 0;
            _Cod_Usuario = 0;
            _Nome_Usuario = null;
            _Cod_PDV_Computador = 0;
        }
    }
}
