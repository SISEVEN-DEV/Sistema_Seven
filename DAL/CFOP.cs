using System;

namespace DAL
{
    public class CFOP : IDisposable
    {
        private short _Cod_CFOP;
        private string _Descricao;
        private string _Pesquisar;
        private string _Finalidade;

        public short Cod_CFOP
        {
            get { return _Cod_CFOP; }
            set { _Cod_CFOP = value; }
        }

        public string Finalidade
        {
            get { return _Finalidade; }
            set { _Finalidade = value; }
        }

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public void Dispose()
        {
            _Cod_CFOP = 0;
            _Descricao = null;
            _Pesquisar = null;
            _Finalidade = null;
        }
    }
}
