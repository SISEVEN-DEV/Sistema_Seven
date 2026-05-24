using System;

namespace DAL
{
    public class EntidadeBancaria : IDisposable
    {
        private short _Codigo;
        private string _Descricao;
        private string _Palavra_Chave;
        private string _Pesquisar;
        private string _Data_Cadastro;
        private int _Codigo_Compe;

        public int Codigo_Compe
        {
            get { return _Codigo_Compe; }
            set { _Codigo_Compe = value; }
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
            _Data_Cadastro = null;
            _Codigo_Compe = 0;
        }
    }
}
