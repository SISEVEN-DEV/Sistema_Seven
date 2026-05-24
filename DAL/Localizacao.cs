using System;

namespace DAL
{
    public class Localizacao : IDisposable
    {
        private short _Codigo;
        private string _Descricao;
        private string _Palavra_Chave;
        private string _Data_Cadastro;
        private string _Pesquisar;

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public string Palavra_Chave
        {
            get { return _Palavra_Chave; }
            set { _Palavra_Chave = value; }
        }

        public string Data_Cadastro
        {
            get { return _Data_Cadastro; }
            set { _Data_Cadastro = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Descricao = null;
            _Palavra_Chave = null;
            _Data_Cadastro = null;
            _Pesquisar = null;
        }
    }
}
