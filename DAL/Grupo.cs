using System;

namespace DAL
{
    public class Grupo : IDisposable
    {
        private short _Codigo;
        private string _Descricao;
        private string _Palavra_Chave;
        private string _Tabela_Destino;
        private string _Pesquisar;
        private string _Data_Cadastro;
        private string _Cor_Destaque;

        public string Cor_Destaque
        {
            get { return _Cor_Destaque; }
            set { _Cor_Destaque = value; }
        }

        public string Tabela_Destino
        {
            get { return _Tabela_Destino; }
            set { _Tabela_Destino = value; }
        }

        public string Data_Cadastro
        {
            get { return _Data_Cadastro; }
            set { _Data_Cadastro = value; }
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

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Descricao = null;
            _Palavra_Chave = null;
            _Pesquisar = null;
            _Tabela_Destino = null;
            _Data_Cadastro = null;
            _Cor_Destaque = null;
        }
    }
}
