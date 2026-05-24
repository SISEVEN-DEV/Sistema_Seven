using System;

namespace DAL
{
    public class Orcamento : IDisposable
    {
        private int _Codigo;
        private int _Cod_Consumidor;
        private string _Nome_Consumidor;
        private short _Cod_Usuario;
        private string _Nome_Usuario;
        private string _Data;
        private string _Data_Validade;
        private string _Hora_Validade;
        private string _Observacao;
        private decimal _Valor_Total;
        private string _Hora;
        private string _Situacao;
        private string _Pesquisar;
        private short _Cod_PDV_Computador;
        private decimal _Valor_Total_Real;
        private decimal _Valor_Desconto_Item;
        private decimal _Valor_Acrescimo_Item;
        private string _CPF_CNPJ_Consumidor;
        private decimal _Valor_Desconto;
        private decimal _Valor_Acrescimo;
        private decimal _Desconto_Porc;
        private decimal _Acrescimo_Porc;

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

        public decimal Desconto_Porc
        {
            get { return _Desconto_Porc; }
            set { _Desconto_Porc = value; }
        }

        public decimal Acrescimo_Porc
        {
            get { return _Acrescimo_Porc; }
            set { _Acrescimo_Porc = value; }
        }

        public string CPF_CNPJ_Consumidor
        {
            get { return _CPF_CNPJ_Consumidor; }
            set { _CPF_CNPJ_Consumidor = value; }
        }

        public string Hora_Validade
        {
            get { return _Hora_Validade; }
            set { _Hora_Validade = value; }
        }


        public short Cod_Usuario
        {
            get { return _Cod_Usuario; }
            set { _Cod_Usuario = value; }
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

        public decimal Valor_Total_Real
        {
            get { return _Valor_Total_Real; }
            set { _Valor_Total_Real = value; }
        }

        public string Nome_Usuario
        {
            get { return _Nome_Usuario; }
            set { _Nome_Usuario = value; }
        }

        public string Situacao
        {
            get { return _Situacao; }
            set { _Situacao = value; }
        }

        public short Cod_PDV_Computador
        {
            get { return _Cod_PDV_Computador; }
            set { _Cod_PDV_Computador = value; }
        }

        public string Hora
        {
            get { return _Hora; }
            set { _Hora = value; }
        }

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

        public int Cod_Consumidor
        {
            get { return _Cod_Consumidor; }
            set { _Cod_Consumidor = value; }
        }

        public decimal Valor_Total
        {
            get { return _Valor_Total; }
            set { _Valor_Total = value; }
        }

        public string Nome_Consumidor
        {
            get { return _Nome_Consumidor; }
            set { _Nome_Consumidor = value; }
        }

        public string Data
        {
            get { return _Data; }
            set { _Data = value; }
        }

        public string Data_Validade
        {
            get { return _Data_Validade; }
            set { _Data_Validade = value; }
        }

        public string Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Consumidor = 0;
            _Nome_Consumidor = null;
            _Data = null;
            _Cod_Usuario = 0;
            _Nome_Usuario = null;
            _Data_Validade = null;
            _Observacao = null;
            _Hora = null;
            _Situacao = null;
            _Pesquisar = null;
            _Cod_PDV_Computador = 0;
            _Valor_Total_Real = 0;
            _Valor_Desconto_Item = 0;
            _Valor_Acrescimo_Item = 0;
            _Hora_Validade = null;
            _CPF_CNPJ_Consumidor = null;
            _Valor_Desconto = 0;
            _Valor_Acrescimo = 0;
            _Desconto_Porc = 0;
            _Acrescimo_Porc = 0;
        }
    }
}