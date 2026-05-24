using System;

namespace DAL
{
    public class Marca : IDisposable
    {
        private short _Codigo;
        private string _Descricao;
        private string _Origem;
        private string _Pais;
        private string _Palavra_Chave;
        private string _Pesquisar;
        private string _Data_Cadastro;

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

        public string Origem
        {
            get { return _Origem; }
            set { _Origem = value; }
        }

        public string Pais
        {
            get { return _Pais; }
            set { _Pais = value; }
        }

        public string Palavra_Chave
        {
            get { return _Palavra_Chave; }
            set { _Palavra_Chave = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
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
            _Origem = null;
            _Pais = null;
            _Palavra_Chave = null;
            _Pesquisar = null;
            _Data_Cadastro = null;
        }
    }
}
