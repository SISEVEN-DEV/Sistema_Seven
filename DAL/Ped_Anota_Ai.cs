using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Ped_Anota_Ai : IDisposable
    {
        private int _Codigo;
        private string _Data;
        private string _Hora;
        private decimal _Desconto;
        private decimal _Acrescimo;
        private decimal _Valor_Total;
        //private decimal _Valor_Real;
        private string _Situacao;

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

        public string Hora
        {
            get { return _Hora; }
            set { _Hora = value; }
        }

        public decimal Desconto
        {
            get { return _Desconto; }
            set { _Desconto = value; }
        }

        public decimal Acrescimo
        {
            get { return _Acrescimo; }
            set { _Acrescimo = value; }
        }

        public decimal Valor_Total
        {
            get { return _Valor_Total; }
            set { _Valor_Total = value; }
        }

        public string Situacao
        {
            get { return _Situacao; }
            set { _Situacao = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Data = null;
            _Hora = null;
            _Desconto = 0;
            _Acrescimo = 0;
            _Valor_Total = 0;
            _Situacao = null;
        }
    }
}
