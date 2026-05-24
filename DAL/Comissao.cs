using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Comissao : IDisposable
    {
        private int _Codigo;
        private short _Cod_Funcionario;
        private string _Nome_Funcionario;
        private decimal _Valor;
        private decimal _Comissao_Porc;
        private int _Cod_Venda;
        private int _Cod_OS;
        private decimal _Valor_Comissao;
        private string _Data;
        private string _Horario;
        private string _Situacao;
        private string _Data_Baixa;
        private string _Horario_Baixa;

        public string Data_Baixa 
        {
            get { return _Data_Baixa; }
            set { _Data_Baixa = value; }
        }

        public string Horario_Baixa 
        {
            get { return _Horario_Baixa; }
            set { _Horario_Baixa = value; }
        }

        public string Situacao 
        {
            get { return _Situacao; }
            set { _Situacao = value; }
        }

        public string Data 
        {
            get { return _Data; }
            set { _Data = value; }
        }

        public string Horario 
        {
            get { return _Horario; }
            set { _Horario = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public short Cod_Funcionario
        {
            get { return _Cod_Funcionario; }
            set { _Cod_Funcionario = value; }
        }

        public string Nome_Funcionario
        {
            get { return _Nome_Funcionario; }
            set { _Nome_Funcionario = value; }
        }

        public decimal Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        public decimal Comissao_Porc
        {
            get { return _Comissao_Porc; }
            set { _Comissao_Porc = value; }
        }

        public int Cod_Venda
        {
            get { return _Cod_Venda; }
            set { _Cod_Venda = value; }
        }

        public int Cod_OS
        {
            get { return _Cod_OS; }
            set { _Cod_OS = value; }
        }

        public decimal Valor_Comissao 
        {
            get { return _Valor_Comissao; }
            set { _Valor_Comissao = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Funcionario = 0;
            _Nome_Funcionario = null;
            _Valor = 0;
            _Comissao_Porc = 0;
            _Cod_Venda = 0;
            _Cod_OS = 0;
            _Valor_Comissao = 0;
            _Data = null;
            _Horario = null;
            _Situacao = null;
            _Data_Baixa = null;
            _Horario_Baixa = null;
        }
    }
}
