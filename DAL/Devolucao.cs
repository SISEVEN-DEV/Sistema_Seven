using System;

namespace DAL
{
    public class Devolucao : IDisposable
    {
        private int _Codigo;
        private int _Cod_Consumidor;
        private string _Nome_Consumidor;
        private string _CPF_CNPJ_Consumidor;
        private string _Data;
        private string _Hora;
        private decimal _Valor;
        private short _Cod_Usuario;
        private string _Nome_Usuario;
        private short _Cod_PDV_Computador;
        private string _Pesquisar;
        private int _Cod_Venda;
        private string _Tipo;
        private decimal _Valor_Novos_Itens;
        private decimal _Valor_Devolvido;

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public int Cod_Venda
        {
            get { return _Cod_Venda; }
            set { _Cod_Venda = value; }
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

        public string Nome_Consumidor
        {
            get { return _Nome_Consumidor; }
            set { _Nome_Consumidor = value; }
        }

        public string CPF_CNPJ_Consumidor
        {
            get { return _CPF_CNPJ_Consumidor; }
            set { _CPF_CNPJ_Consumidor = value; }
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

        public decimal Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        public decimal Valor_Novos_Itens
        {
            get { return _Valor_Novos_Itens; }
            set { _Valor_Novos_Itens = value; }
        }

        public decimal Valor_Devolvido
        {
            get { return _Valor_Devolvido; }
            set { _Valor_Devolvido = value; }
        }

        public short Cod_Usuario
        {
            get { return _Cod_Usuario; }
            set { _Cod_Usuario = value; }
        }

        public string Nome_Usuario
        {
            get { return _Nome_Usuario; }
            set { _Nome_Usuario = value; }
        }

        public short Cod_PDV_Computador
        {
            get { return _Cod_PDV_Computador; }
            set { _Cod_PDV_Computador = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Consumidor = 0;
            _Nome_Consumidor = null;
            _CPF_CNPJ_Consumidor = null;
            _Data = null;
            _Hora = null;
            _Valor = 0;
            _Cod_Usuario = 0;
            _Nome_Usuario = null;
            _Cod_PDV_Computador = 0;
            _Pesquisar = null;
            _Cod_Venda = 0;
            _Tipo = null;
            _Valor_Devolvido = 0;
            _Valor_Novos_Itens = 0;
        }
    }
}
