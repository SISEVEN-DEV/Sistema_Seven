using System;

namespace DAL
{
    public class Abertura_Fechamento_Caixa : IDisposable
    {
        private int _Codigo;
        private string _Data_Abertura;
        private string _Hora_Abertura;
        private decimal _Saldo_Inicial;
        private string _Data_Fechamento;
        private string _Hora_Fechamento;
        private decimal _Saldo_Final;
        private decimal _Total_Quebra_Caixa;
        private short _Cod_PDV_Computador;
        private string _Observacoes;
        private short _Cod_Usuario_Abertura;
        private string _Nome_Usuario_Abertura;
        private short _Cod_Usuario_Fechamento;
        private string _Nome_Usuario_Fechamento;
        private string _Situacao;
        private string _Nome_Computador;
        private string _Pesquisar;


        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public string Nome_Computador
        {
            get { return _Nome_Computador; }
            set { _Nome_Computador = value; }
        }

        public short Cod_Usuario_Abertura
        {
            get { return _Cod_Usuario_Abertura; }
            set { _Cod_Usuario_Abertura = value; }
        }

        public string Nome_Usuario_Abertura
        {
            get { return _Nome_Usuario_Abertura; }
            set { _Nome_Usuario_Abertura = value; }
        }

        public short Cod_Usuario_Fechamento
        {
            get { return _Cod_Usuario_Fechamento; }
            set { _Cod_Usuario_Fechamento = value; }
        }

        public string Nome_Usuario_Fechamento
        {
            get { return _Nome_Usuario_Fechamento; }
            set { _Nome_Usuario_Fechamento = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Observacoes
        {
            get { return _Observacoes; }
            set { _Observacoes = value; }
        }

        public string Data_Abertura
        {
            get { return _Data_Abertura; }
            set { _Data_Abertura = value; }
        }

        public string Hora_Abertura
        {
            get { return _Hora_Abertura; }
            set { _Hora_Abertura = value; }
        }

        public decimal Saldo_Inicial
        {
            get { return _Saldo_Inicial; }
            set { _Saldo_Inicial = value; }
        }

        public string Data_Fechamento
        {
            get { return _Data_Fechamento; }
            set { _Data_Fechamento = value; }
        }
        public string Hora_Fechamento
        {
            get { return _Hora_Fechamento; }
            set { _Hora_Fechamento = value; }
        }

        public decimal Saldo_Final
        {
            get { return _Saldo_Final; }
            set { _Saldo_Final = value; }
        }

        public decimal Total_Quebra_Caixa
        {
            get { return _Total_Quebra_Caixa; }
            set { _Total_Quebra_Caixa = value; }
        }

        public short Cod_PDV_Computador
        {
            get { return _Cod_PDV_Computador; }
            set { _Cod_PDV_Computador = value; }
        }

        public string Situacao
        {
            get { return _Situacao; }
            set { _Situacao = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Pesquisar = null;
            _Data_Abertura = null;
            _Hora_Abertura = null;
            _Saldo_Inicial = 0;
            _Data_Fechamento = null;
            _Hora_Fechamento = null;
            _Saldo_Final = 0;
            _Total_Quebra_Caixa = 0;
            _Cod_PDV_Computador = 0;
            _Observacoes = null;
            _Cod_Usuario_Abertura = 0;
            _Nome_Usuario_Abertura = null;
            _Cod_Usuario_Fechamento = 0;
            _Nome_Usuario_Fechamento = null;
            _Situacao = null;
            _Nome_Computador = null;
        }
    }
}
