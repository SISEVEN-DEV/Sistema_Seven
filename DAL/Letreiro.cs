using System;

namespace DAL
{
    public class Letreiro : IDisposable
    {
        private short _Codigo;
        private string _Mensagem;
        private string _Tipo;
        private byte _Cor;
        private string _Pesquisar;

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Mensagem
        {
            get { return _Mensagem; }
            set { _Mensagem = value; }
        }

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public byte Cor
        {
            get { return _Cor; }
            set { _Cor = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Mensagem = null;
            _Tipo = null;
            _Cor = 0;
            _Pesquisar = null;
        }
    }
}
