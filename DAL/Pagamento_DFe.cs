using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Pagamento_DFe : IDisposable
    {
        private int _Codigo;
        private short _Cod_Pagamento;
        private short _Cod_Item_Pagamento;
        private string _Tipo;
        private decimal _Valor_Pago;
        private int _Cod_Dfe;

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

        public int Cod_Dfe
        {
            get { return _Cod_Dfe; }
            set { _Cod_Dfe = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Pagamento = 0;
            _Cod_Item_Pagamento = 0;
            _Tipo = null;
            _Valor_Pago = 0;
            _Cod_Dfe = 0;
        }
    }
}
