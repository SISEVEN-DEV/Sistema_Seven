using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Precificacao : IDisposable
    {
        private int _Cod_Item;
        private int _Cod_Produto;
        private decimal _Margem;
        private decimal _Novo_Preco;
        private int _Cod_DFe;

        public int Cod_Item
        {
            get { return _Cod_Item; }
            set { _Cod_Item = value; }
        }

        public int Cod_Produto 
        {
            get { return _Cod_Produto; }
            set { _Cod_Produto = value; }
        }

        public decimal Margem
        {
            get { return _Margem; }
            set { _Margem = value; }
        }

        public decimal Novo_Preco
        {
            get { return _Novo_Preco; }
            set { _Novo_Preco = value; }
        }

        public int Cod_DFe
        {
            get { return _Cod_DFe; }
            set { _Cod_DFe = value; }
        }

        public void Dispose()
        {
            _Cod_Item = 0;
            _Cod_Produto = 0;
            _Margem = 0;
            _Novo_Preco = 0;
            _Cod_DFe = 0;
        }
    }
}
