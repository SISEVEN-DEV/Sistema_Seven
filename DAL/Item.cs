using System;

namespace DAL
{
    public class Item : IDisposable
    {
        private short _Codigo;
        private int _Cod_Produto;
        private string _Descricao;
        private decimal _Quantidade;
        private string _UM;
        private decimal _Valor_Unitario;
        private decimal _Valor_Total;
        private string _Imagem_Prod;

        public string Imagem_Prod
        {
            get { return _Imagem_Prod; }
            set { _Imagem_Prod = value; }
        }

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public int Cod_Produto
        {
            get { return _Cod_Produto; }
            set { _Cod_Produto = value; }
        }

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public decimal Quantidade
        {
            get { return _Quantidade; }
            set { _Quantidade = value; }
        }
        
        public string UM
        {
            get { return _UM; }
            set { _UM = value; }
        }

        public decimal Valor_Unitario
        {
            get { return _Valor_Unitario; }
            set { _Valor_Unitario = value; }
        }

        public decimal Valor_Total
        {
            get { return _Valor_Total; }
            set { _Valor_Total = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Produto = 0;
            _Descricao = null;
            _Quantidade = 0;
            _UM = null;
            _Valor_Unitario = 0;
            _Valor_Total = 0;
            _Imagem_Prod = null;
        }
    }
}
