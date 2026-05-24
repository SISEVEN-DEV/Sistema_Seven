using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Item_NFSe : IDisposable
    {
        private int _Codigo;
        private int _Cod_Item;
        private int _Cod_Servico;
        private string _Descricao;
        private decimal _Preco;
        private int _Cod_Item_Servico;
        private decimal _Aliquota;
        private int _Cod_NFSe;

        public int Cod_NFSe
        {
            get { return _Cod_NFSe; }
            set { _Cod_NFSe = value; }
        }

        public decimal Aliquota
        {
            get { return _Aliquota; }
            set { _Aliquota = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public int Cod_Item
        {
            get { return _Cod_Item; }
            set { _Cod_Item = value; }
        }

        public int Cod_Servico
        {
            get { return _Cod_Servico; }
            set { _Cod_Servico = value; }
        }

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public decimal Preco
        {
            get { return _Preco; }
            set { _Preco = value; }
        }

        public int Cod_Item_Servico
        {
            get { return _Cod_Item_Servico; }
            set { _Cod_Item_Servico = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Descricao = null;
            _Preco = 0;
            _Cod_Item_Servico = 0;
            _Aliquota = 0;
            _Cod_Item = 0;
            _Cod_Servico = 0;
            _Cod_NFSe = 0;
        }
    }
}
