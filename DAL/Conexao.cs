using System;

namespace DAL
{
    public class Conexao : IDisposable
    {
        private short _Codigo;
        private string _Caminho_Conexao;
        private string _Entidade;
        private string _Nome_Computador;
        private string _Tipo_Conexao;
        private string _Conexao_Completa;
        private string _Senha_Autorizacao;
        private short _Ordem;
        private string _Nome_Servidor;
        private int _Porta;

        public short Ordem
        {
            get { return _Ordem; }
            set { _Ordem = value; }
        }

        public string Nome_Servidor
        {
            get { return _Nome_Servidor; }
            set { _Nome_Servidor = value; }
        }

        public int Porta
        {
            get { return _Porta; }
            set { _Porta = value; }
        }

        public string Senha_Autorizacao
        {
            get { return _Senha_Autorizacao; }
            set { _Senha_Autorizacao = value; }
        }

        public string Conexao_Completa
        {
            get { return _Conexao_Completa; }
            set { _Conexao_Completa = value; }
        }

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Entidade
        {
            get { return _Entidade; }
            set { _Entidade = value; }
        }

        public string Nome_Computador
        {
            get { return _Nome_Computador; }
            set { _Nome_Computador = value; }
        }

        public string Caminho_Conexao
        {
            get { return _Caminho_Conexao; }
            set { _Caminho_Conexao = value; }
        }

        public string Tipo_Conexao
        {
            get { return _Tipo_Conexao; }
            set { _Tipo_Conexao = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Entidade = null;
            _Caminho_Conexao = null;
            _Nome_Computador = null;
            _Conexao_Completa = null;
            _Tipo_Conexao = null;
            _Senha_Autorizacao = null;
            _Ordem = 0;
            _Nome_Servidor = null;
            _Porta = 0;
        }
    }
}
