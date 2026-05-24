using System;

namespace DAL
{
    public class Contato : IDisposable
    {
        private short _Codigo;
        private string _Telefone;
        private string _Celular;
        private string _FAX;
        private string _Site;
        private string _Email;
        private string _Senha;
        private string _Pesquisar;

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

        public string Telefone
        {
            get { return _Telefone; }
            set { _Telefone = value; }
        }

        public string FAX
        {
            get { return _FAX; }
            set { _FAX = value; }
        }

        public string Site
        {
            get { return _Site; }
            set { _Site = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Senha
        {
            get { return _Senha; }
            set { _Senha = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Telefone = null;
            _Celular = null;
            _FAX = null;
            _Site = null;
            _Email = null;
            _Senha = null;
            _Pesquisar = null;
        }
    }
}
