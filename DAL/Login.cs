using System;

namespace DAL
{
    public class Login : IDisposable
    {
        private string _Nome;
        private string _Senha;

        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        public string Senha
        {
            get { return _Senha; }
            set { _Senha = value; }
        }

        public void Dispose()
        {
            Nome = null;
            Senha = null;
        }
    }
}
