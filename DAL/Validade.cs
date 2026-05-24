using System;

namespace DAL
{
    public class Validade : IDisposable
    {
        private int _Codigo;
        private string _N_Lote;
        private string _Data_Validade;
        private int _Cod_Produto;
        private int _Cod_Dfe;
        private string _Pesquisar;
        private string _Data_Cadastro;
        private string _Data_Fabricacao;
        private string _Horario_Fabricacao;

        public string Horario_Fabricacao
        {
            get { return _Horario_Fabricacao; }
            set { _Horario_Fabricacao = value; }
        }

        public string Data_Fabricacao
        {
            get { return _Data_Fabricacao; }
            set { _Data_Fabricacao = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string N_Lote
        {
            get { return _N_Lote; }
            set { _N_Lote = value; }
        }

        public string Data_Validade
        {
            get { return _Data_Validade; }
            set { _Data_Validade = value; }
        }

        public int Cod_Produto
        {
            get { return _Cod_Produto; }
            set { _Cod_Produto = value; }
        }

        public int Cod_Dfe
        {
            get { return _Cod_Dfe; }
            set { _Cod_Dfe = value; }
        }

        public string Data_Cadastro
        {
            get { return _Data_Cadastro; }
            set { _Data_Cadastro = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _N_Lote = null;
            _Data_Validade = null;
            _Cod_Produto = 0;
            _Cod_Dfe = 0;
            _Pesquisar = null;
            _Data_Cadastro = null;
            _Data_Fabricacao = null;
            _Horario_Fabricacao = null;
        }
    }
}
