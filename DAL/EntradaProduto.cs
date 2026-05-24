using System;

namespace DAL
{
    public class EntradaProduto : IDisposable
    {
        private int _Codigo;
        private string _Data_Compra;
        private decimal _Quantidade;
        private int _Cod_Fornecedor;
        private string _Nome_Fornecedor;
        private int _Cod_Produto;
        private string _Desc_Produto;
        private string _Data_Cadastro;

        public int Cod_Produto
        {
            get { return _Cod_Produto; }
            set { _Cod_Produto = value; }
        }

        public string Desc_Produto
        {
            get { return _Desc_Produto; }
            set { _Desc_Produto = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Data_Compra
        {
            get { return _Data_Compra; }
            set { _Data_Compra = value; }
        }

        public decimal Quantidade
        {
            get { return _Quantidade; }
            set { _Quantidade = value; }
        }


        public int Cod_Fornecedor
        {
            get { return _Cod_Fornecedor; }
            set { _Cod_Fornecedor = value; }
        }

        public string Nome_Fornecedor
        {
            get { return _Nome_Fornecedor; }
            set { _Nome_Fornecedor = value; }
        }

        public string Data_Cadastro
        {
            get { return _Data_Cadastro; }
            set { _Data_Cadastro = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Data_Compra = null;
            _Quantidade = 0;
            _Cod_Fornecedor = 0;
            _Nome_Fornecedor = null;
            _Cod_Produto = 0;
            _Desc_Produto = null;
            _Data_Cadastro = null;
        }
    }
}
