using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Pagamento_Ped_Anota_Ai : IDisposable
    {
        private int _Codigo;
        private short _Cod_Pagamento;
        private short _Cod_Item_Pagamento;
        private string _Tipo;
        private decimal _Valor_Pago;
        private int _Cod_Ped_Anota_Ai;

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

        public int Cod_Ped_Anota_Ai
        {
            get { return _Cod_Ped_Anota_Ai; }
            set { _Cod_Ped_Anota_Ai = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Pagamento = 0;
            _Cod_Item_Pagamento = 0;
            _Tipo = null;
            _Valor_Pago = 0;
            _Cod_Ped_Anota_Ai = 0;
        }
    }
}
