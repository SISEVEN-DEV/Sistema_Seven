using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Item_Ped_Anota_Ai : IDisposable
    {
        private int _Codigo;
        private short _Cod_Item;
        private int _Cod_Produto;
        private string _Descricao;
        private decimal _Valor_Unitario;
        private decimal _Quantidade;
        private int _Cod_Ped_Anota_Ai;

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

        public decimal Valor_Unitario
        {
            get { return _Valor_Unitario; }
            set { _Valor_Unitario = value; }
        }

        public decimal Quantidade
        {
            get { return _Quantidade; }
            set { _Quantidade = value; }
        }

        public int Cod_Ped_Anota_Ai
        {
            get { return _Cod_Ped_Anota_Ai; }
            set { _Cod_Ped_Anota_Ai = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Item = 0;
            _Cod_Produto = 0;
            _Descricao = null;
            _Valor_Unitario = 0;
            _Quantidade = 0;
            _Cod_Ped_Anota_Ai = 0;
        }
    }
}
