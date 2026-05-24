using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReferenciaDFe : IDisposable
    {
        private int _Codigo;
        private short _Cod_Item_Referencia;
        private string _Chave_DFe;
        private int _Cod_DFe;

        public int Codigo 
        {
            get { return _Codigo; }
            set { _Codigo = value;  }
        }

        public short Cod_Item_Referencia 
        {
            get { return _Cod_Item_Referencia; }
            set { _Cod_Item_Referencia = value; }
        }

        public string Chave_DFe 
        {
            get { return _Chave_DFe; }
            set { _Chave_DFe = value; }
        }

        public int Cod_DFe
        {
            get { return _Cod_DFe; }
            set { _Cod_DFe = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Item_Referencia = 0;
            _Chave_DFe = null;
            _Cod_DFe = 0;
        }
    }
}
