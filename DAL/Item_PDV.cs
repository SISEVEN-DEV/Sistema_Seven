using System;

namespace DAL
{
    public class Item_PDV : IDisposable
    {
        private int _Codigo;
        private short _Cod_Item;
        private int _Cod_Produto;
        private string _Descricao;
        private string _UM;
        private decimal _Valor_Unitario;
        private decimal _Valor_Total;
        private decimal _Quantidade;
        private int _Cod_Venda;
        private decimal _Valor_Desconto;
        private decimal _Valor_Acrescimo;
        private decimal _Valor_Desconto_Item;
        private decimal _Valor_Acrescimo_Item;
        private decimal _Valor_Total_A_Desc_Acresc;
        private string _Tipo;

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

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

        public decimal Valor_Desconto
        {
            get { return _Valor_Desconto; }
            set { _Valor_Desconto = value; }
        }

        public decimal Valor_Acrescimo
        {
            get { return _Valor_Acrescimo; }
            set { _Valor_Acrescimo = value; }
        }

        public decimal Valor_Total_A_Desc_Acresc
        {
            get { return _Valor_Total_A_Desc_Acresc; }
            set { _Valor_Total_A_Desc_Acresc = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public short Cod_Item
        {
            get { return _Cod_Item; }
            set { _Cod_Item = value; }
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

        public decimal Quantidade
        {
            get { return _Quantidade; }
            set { _Quantidade = value; }
        }

        public int Cod_Venda
        {
            get { return _Cod_Venda; }
            set { _Cod_Venda = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Item = 0;
            _Cod_Produto = 0;
            _Descricao = null;
            _UM = null;
            _Valor_Unitario = 0;
            _Valor_Total = 0;
            _Quantidade = 0;
            _Cod_Venda = 0;
            _Valor_Desconto = 0;
            _Valor_Acrescimo = 0;
            _Valor_Total_A_Desc_Acresc = 0;
            _Valor_Desconto_Item = 0;
            _Valor_Acrescimo_Item = 0;
            _Tipo = null;
        }
    }
}
