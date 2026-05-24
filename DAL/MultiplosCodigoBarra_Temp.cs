using System;

namespace DAL
{
    public class MultiplosCodigoBarra_Temp : IDisposable
    {
        private int _Codigo;
        private string _Cod_Barra;
        private string _Pesquisar;

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Cod_Barra
        {
            get { return _Cod_Barra; }
            set { _Cod_Barra = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Barra = null;
            _Pesquisar = null;
        }
    }
}
