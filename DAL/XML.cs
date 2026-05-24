using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DAL
{
    public class XML : IDisposable
    {
        private int _Codigo;
        private int _Cod_DFe;
        private string _Texto_XML;
        private byte _Saida;

        public int Codigo 
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public int Cod_DFe
        {
            get { return _Cod_DFe; }
            set { _Cod_DFe = value; }
        }

        public string Texto_XML
        {
            get { return _Texto_XML; }
            set { _Texto_XML = value; }
        }

        public byte Saida
        {
            get { return _Saida; }
            set { _Saida = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_DFe = 0;
            _Texto_XML = null;
            _Saida = 0;
        }
    }
}
