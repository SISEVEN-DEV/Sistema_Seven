using System;

namespace DAL
{
    public class RegistroAtividades : IDisposable
    {
        //Tabela Cadastro de Funções
        private int _Codigo;
        private string _Descricao;
        private string _Data;
        private string _Horario;
        private string _Nome_Tabela;
        private int _Cod_Registro;
        private short _Cod_Usuario;
        private string _Nome_Usuario;
        private string _Pesquisar;
        private short _Cod_PDV_Computador;

        public short Cod_PDV_Computador
        {
            get { return _Cod_PDV_Computador; }
            set { _Cod_PDV_Computador = value; }
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

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
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

        public string Nome_Tabela
        {
            get { return _Nome_Tabela; }
            set { _Nome_Tabela = value; }
        }

        public int Cod_Registro
        {
            get { return _Cod_Registro; }
            set { _Cod_Registro = value; }
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

        public void Dispose()
        {
            _Codigo = 0;
            _Descricao = null;
            _Data = null;
            _Horario = null;
            _Nome_Tabela = null;
            _Cod_Registro = 0;
            _Cod_Usuario = 0;
            _Nome_Usuario = null;
            _Pesquisar = null;
            _Cod_PDV_Computador = 0;
        }
    }
}
