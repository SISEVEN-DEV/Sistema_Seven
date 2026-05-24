using System;

namespace DAL
{
    public class Lembrete : IDisposable
    {
        private int _Codigo;
        private string _Data;
        private string _Horario;
        private string _Descricao;
        private string _Observacao;
        private string _Som_Alarme;
        private string _Pesquisar;
        private string _Detalhe_Usuario;
        private short _Codigo_Usuario;
        private string _Nome_Usuario;
        private string _Situacao;
        private byte _Exc_Lemb_Fechado;
        private string _Tabela_Geradora;
        private int _Cod_Fato_Gerador;

        public string Situacao
        {
            get { return _Situacao; }
            set { _Situacao = value; }
        }


        public byte Exc_Lemb_Fechado
        {
            get { return _Exc_Lemb_Fechado; }
            set { _Exc_Lemb_Fechado = value; }
        }

        public string Detalhe_Usuario
        {
            get { return _Detalhe_Usuario; }
            set { _Detalhe_Usuario = value; }
        }

        public short Codigo_Usuario
        {
            get { return _Codigo_Usuario; }
            set { _Codigo_Usuario = value; }
        }

        public string Nome_Usuario
        {
            get { return _Nome_Usuario; }
            set { _Nome_Usuario = value; }
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

        public string Horario
        {
            get { return _Horario; }
            set { _Horario = value; }
        }

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public string Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        public string Som_Alarme
        {
            get { return _Som_Alarme; }
            set { _Som_Alarme = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public string Tabela_Geradora
        {
            get { return _Tabela_Geradora; }
            set { _Tabela_Geradora = value; }
        }

        public int Cod_Fato_Gerador
        {
            get { return _Cod_Fato_Gerador; }
            set { _Cod_Fato_Gerador = value; }
        }

        public void Dispose()
        {
            _Tabela_Geradora = null;
            _Cod_Fato_Gerador = 0;
            _Situacao = null;
            _Exc_Lemb_Fechado = 0;
            _Pesquisar = null;
            _Codigo = 0;
            _Data = null;
            _Horario = null;
            _Descricao = null;
            _Observacao = null;
            _Som_Alarme = null;
            _Codigo_Usuario = 0;
            _Nome_Usuario = null;
            _Detalhe_Usuario = null;
        }
    }
}
