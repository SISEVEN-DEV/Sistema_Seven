using System;

namespace DAL
{
    public class MultiplosCodigoBarra : IDisposable
    {
        private int _Codigo;
        private short _Cod_Item;
        private string _Cod_Barra;
        private int _Cod_Produto;
        private string _Pesquisar;

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public short Cod_Item
        {
            get { return _Cod_Item; }
            set { _Cod_Item = value; }
        }

        public string Cod_Barra
        {
            get { return _Cod_Barra; }
            set { _Cod_Barra = value; }
        }

        public int Cod_Produto
        {
            get { return _Cod_Produto; }
            set { _Cod_Produto = value; }
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
            _Cod_Produto = 0;
            _Pesquisar = null;
            _Cod_Item = 0;
        }
    }
}
