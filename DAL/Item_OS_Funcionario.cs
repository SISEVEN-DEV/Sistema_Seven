using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Item_OS_Funcionario : IDisposable
    {
        private int _Codigo;
        private short _Cod_Item;
        private int _Cod_Funcionario;
        private string _Nome_Funcionario;
        private int _Cod_OS;

        public short Cod_Item
        {
            get { return _Cod_Item; }
            set { _Cod_Item = value; }
        }

        public int Cod_OS
        {
            get { return _Cod_OS; }
            set { _Cod_OS = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public int Cod_Funcionario
        {
            get { return _Cod_Funcionario; }
            set { _Cod_Funcionario = value; }
        }

        public string Nome_Funcionario
        {
            get { return _Nome_Funcionario; }
            set { _Nome_Funcionario = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Funcionario = 0;
            _Nome_Funcionario = null;
            _Cod_OS = 0;
            _Cod_Item = 0;
        }
    }
}
