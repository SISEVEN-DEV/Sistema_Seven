using System;

namespace DAL
{
    public class Item_Dev_Prod : IDisposable
    {
        private short _Codigo;
        private short _Cod_Item;
        private int _Cod_Produto;
        private string _Descricao;
        private string _UM;
        private decimal _Valor_Unitario;
        private decimal _Valor_Total;
        private decimal _Quantidade;
        private int _Cod_Devolucao;
        private decimal _Valor_Desconto_Item;
        private decimal _Valor_Acrescimo_Item;
        private decimal _Valor_Total_A_Desc_Acresc;

        public decimal Valor_Desconto_Item
        {
            get { return _Valor_Desconto_Item; }
            set { _Valor_Desconto_Item = value; }
        }

        public decimal Valor_Acrescimo_Item
        {
            get { return _Valor_Acrescimo_Item; }
            set { _Valor_Acrescimo_Item = value; }
        }

        public decimal Valor_Total_A_Desc_Acresc
        {
            get { return _Valor_Total_A_Desc_Acresc; }
            set { _Valor_Total_A_Desc_Acresc = value; }
        }


        public short Cod_Item
        {
            get { return _Cod_Item; }
            set { _Cod_Item = value; }
        }

        public int Cod_Devolucao
        {
            get { return _Cod_Devolucao; }
            set { _Cod_Devolucao = value; }
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
            _Cod_Devolucao = 0;
            _Cod_Item = 0;
            _Valor_Desconto_Item = 0;
            _Valor_Acrescimo_Item = 0;
            _Valor_Total_A_Desc_Acresc = 0;
        }
    }
}
