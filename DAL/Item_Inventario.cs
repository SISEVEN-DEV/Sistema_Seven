using System;

namespace DAL
{
    public class Item_Inventario : IDisposable
    {
        private int _Codigo;
        private int _Cod_Produto;
        private string _Descricao;
        private decimal _Quantidade;
        private decimal _Custo_Medio;
        private decimal _Total_Medio;
        private int _Cod_Inventario;
        private decimal _Ult_Custo;
        private decimal _Ult_Quantidade;
        private decimal _Ult_Total;
        private string _UM;
        private string _NCM;
        private decimal _Inv_Saldo_Atual;
        private decimal _Inv_Custo_Medio_Atual;
        private decimal _Inv_Total_Atual;
        private string _Pesquisar;

        public string Pesquisar 
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public string NCM
        {
            get { return _NCM; }
            set { _NCM = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string UM
        {
            get { return _UM; }
            set { _UM = value; }
        }

        public int Cod_Inventario
        {
            get { return _Cod_Inventario; }
            set { _Cod_Inventario = value; }
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

        public decimal Ult_Quantidade
        {
            get { return _Ult_Quantidade; }
            set { _Ult_Quantidade = value; }
        }

        public decimal Custo_Medio
        {
            get { return _Custo_Medio; }
            set { _Custo_Medio = value; }
        }

        public decimal Ult_Total
        {
            get { return _Ult_Total; }
            set { _Ult_Total = value; }
        }

        public decimal Ult_Custo
        {
            get { return _Ult_Custo; }
            set { _Ult_Custo = value; }
        }

        public decimal Total_Medio
        {
            get { return _Total_Medio; }
            set { _Total_Medio = value; }
        }

        public decimal Inv_Saldo_Atual 
        {
            get { return _Inv_Saldo_Atual; }
            set { _Inv_Saldo_Atual = value; }
        }

        public decimal Inv_Custo_Medio_Atual 
        {
            get { return _Inv_Custo_Medio_Atual; }
            set { _Inv_Custo_Medio_Atual = value; }
        }

        public decimal Inv_Total_Atual 
        {
            get { return _Inv_Total_Atual; }
            set { _Inv_Total_Atual = value; }
        }

        public void Dispose()
        {
            _Cod_Inventario = 0;
            _Cod_Produto = 0;
            _Descricao = null;
            _Quantidade = 0;
            _Custo_Medio = 0;
            _Total_Medio = 0;
            _Ult_Custo = 0;
            _Ult_Quantidade = 0;
            _Ult_Total = 0;
            _UM = null;
            _Codigo = 0;
            _NCM = null;
            _Inv_Saldo_Atual = 0;
            _Inv_Custo_Medio_Atual = 0;
            _Inv_Total_Atual = 0;
            _Pesquisar = null;
        }
    }
}
