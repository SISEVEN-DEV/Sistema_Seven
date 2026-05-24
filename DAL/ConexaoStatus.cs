using System;

namespace DAL
{
    public class ConexaoStatus : IDisposable
    {
        private short _Codigo;
        private string _Nome_Computador;
        private string _IP_Computador;
        private byte _Servidor;

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Nome_Computador
        {
            get { return _Nome_Computador; }
            set { _Nome_Computador = value; }
        }

        public string IP_Computador
        {
            get { return _IP_Computador; }
            set { _IP_Computador = value; }
        }

        public byte Servidor
        {
            get { return _Servidor; }
            set { _Servidor = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Nome_Computador = null;
            _IP_Computador = null;
            _Servidor = 0;
        }
    }
}
