using System;

namespace DAL
{
    public class Licenca : IDisposable
    {
        private int _Codigo;
        private string _Data_Renovacao;
        private string _Data_Expiracao;
        private string _Data_Recente;
        private string _Pesquisar;
        private string _Chave;

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Chave
        {
            get { return _Chave; }
            set { _Chave = value; }
        }

        public string Data_Renovacao
        {
            get { return _Data_Renovacao; }
            set { _Data_Renovacao = value; }
        }

        public string Data_Expiracao
        {
            get { return _Data_Expiracao; }
            set { _Data_Expiracao = value; }
        }

        public string Data_Recente
        {
            get { return _Data_Recente; }
            set { _Data_Recente = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Data_Renovacao = null;
            _Data_Expiracao = null;
            _Data_Recente = null;
            _Pesquisar = null;
            _Chave = null;
        }
    }
}
