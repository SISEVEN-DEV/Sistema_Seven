using System;

namespace DAL
{
    public class Inventario : IDisposable
    {
        private int _Codigo;
        private string _Data_Inicial;
        private string _Data_Final;
        private string _Descricao;
        private string _Data_Cadastro;
        private short _Cod_Localizacao;
        private string _Desc_Localizacao;
        private byte _Inv_Contabil;

        public byte Inv_Contabil
        {
            get { return _Inv_Contabil; }
            set { _Inv_Contabil = value; }
        }

        public short Cod_Localizacao
        {
            get { return _Cod_Localizacao; }
            set { _Cod_Localizacao = value; }
        }

        public string Desc_Localizacao
        {
            get { return _Desc_Localizacao; }
            set { _Desc_Localizacao = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Data_Cadastro
        {
            get { return _Data_Cadastro; }
            set { _Data_Cadastro = value; }
        }

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public string Data_Inicial
        {
            get { return _Data_Inicial; }
            set { _Data_Inicial = value; }
        }

        public string Data_Final
        {
            get { return _Data_Final; }
            set { _Data_Final = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Data_Inicial = null;
            _Data_Final = null;
            _Descricao = null;
            _Data_Cadastro = null;
            _Cod_Localizacao = 0;
            _Desc_Localizacao = null;
            _Inv_Contabil = 0;
        }
    }
}
