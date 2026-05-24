using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IBPT : IDisposable
    {
        private int _Codigo;
        private string _NCM;
        private string _Descricao;
        private decimal _Trib_Federal;
        private decimal _Trib_Federal_Importado;
        private decimal _Trib_Estadual;
        private decimal _Trib_Municipal;
        private string _Excecao;
        private string _Pesquisar;

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string NCM
        {
            get { return _NCM; }
            set { _NCM = value; }
        }

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public decimal Trib_Federal
        {
            get { return _Trib_Federal; }
            set { _Trib_Federal = value; }
        }

        public decimal Trib_Federal_Importado
        {
            get { return _Trib_Federal_Importado; }
            set { _Trib_Federal_Importado = value; }
        }

        public decimal Trib_Estadual
        {
            get { return _Trib_Estadual; }
            set { _Trib_Estadual = value; }
        }

        public decimal Trib_Municipal
        {
            get { return _Trib_Municipal; }
            set { _Trib_Municipal = value; }
        }

        public string Excecao
        {
            get { return _Excecao; }
            set { _Excecao = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _NCM = null;
            _Descricao = null;
            _Trib_Federal = 0;
            _Trib_Federal_Importado = 0;
            _Trib_Estadual = 0;
            _Trib_Municipal = 0;
            _Excecao = null;
            _Pesquisar = null;
        }
    }
}
