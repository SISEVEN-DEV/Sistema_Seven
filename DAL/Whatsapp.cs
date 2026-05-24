using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Whatsapp
    {
        private short _Codigo;
        private string _Celular;
        private string _Fato_Gerador;
        private int _Cod_Fato_Gerador;
        private string _Cod_Usuario;
        private string _Nome_Usuario;
        private short _Cod_PDV_Computador;

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Celular
        {
            get { return _Celular; }
            set { _Celular = value; }
        }

        public string Fato_Gerador
        {
            get { return _Fato_Gerador; }
            set { _Fato_Gerador = value; }
        }

        public int Cod_Fato_Gerador
        {
            get { return _Cod_Fato_Gerador; }
            set { _Cod_Fato_Gerador = value; }
        }

        public string Cod_Usuario
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
        public void Dispose()
        {
            _Codigo = 0;
            _Celular = null;
            _Fato_Gerador = null;
            _Cod_Fato_Gerador = 0;
            _Cod_Usuario = null;
            _Nome_Usuario = null;
            _Cod_PDV_Computador = 0;
        }
    }
}
