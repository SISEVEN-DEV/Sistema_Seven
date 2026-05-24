using System;

namespace DAL
{
    public class FluxoCaixa : IDisposable
    {
        private int _Codigo;
        private string _Data;
        private string _Hora;
        private string _Tipo;
        private string _Descricao;
        private decimal _Valor;
        private decimal _Saldo;
        private int _Cod_Fato_Gerador;
        private string _Pesquisar;
        private short _Cod_Usuario;
        private string _Nome_Usuario;
        private short _Cod_PDV_Computador;

        public short Cod_PDV_Computador
        {
            get { return _Cod_PDV_Computador; }
            set { _Cod_PDV_Computador = value; }
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

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public decimal Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        public decimal Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        public int Cod_Fato_Gerador
        {
            get { return _Cod_Fato_Gerador; }
            set { _Cod_Fato_Gerador = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Data = null;
            _Hora = null;
            _Tipo = null;
            _Descricao = null;
            _Valor = 0;
            _Saldo = 0;
            _Cod_Fato_Gerador = 0;
            _Pesquisar = null;
            _Cod_Usuario = 0;
            _Nome_Usuario = null;
            _Cod_PDV_Computador = 0;
        }
    }
}
