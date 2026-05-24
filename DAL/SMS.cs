using System;

namespace DAL
{
    public class SMS : IDisposable
    {
        private int _Codigo;
        private string _Porta;
        private short _Cod_Conexao_Configuracoes;

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public short Cod_Conexao_Configuracoes
        {
            get { return _Cod_Conexao_Configuracoes; }
            set { _Cod_Conexao_Configuracoes = value; }
        }

        public string Porta
        {
            get { return _Porta; }
            set { _Porta = value; }
        }

        public void Dispose()
        {
            _Porta = null;
            _Codigo = 0;
            _Cod_Conexao_Configuracoes = 0;
        }
    }
}
