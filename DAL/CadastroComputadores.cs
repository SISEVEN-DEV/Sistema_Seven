using System;


namespace DAL
{
    public class CadastroComputadores : IDisposable
    {
        private short _Codigo;
        private string _Nome_Computador;
        private string _Senha_Autorizacao;
        private short _Cod_Usuario_Adm;
        private string _Nome_Usuario_Adm;
        private short _Cod_Usuario_Pdv;
        private string _Nome_Usuario_Pdv;
        private byte _Seven_Sistema_Adm;
        private byte _Seven_Sistema_Pdv;
        private string _Tipo_Computador;
        private string _Data_Ult_Abert_Caixa;
        private string _Data_Ult_Fech_Caixa;
        private string _Pesquisa;

        public string Pesquisar
        {
            get { return _Pesquisa; }
            set { _Pesquisa = value; }
        }

        public string Data_Ult_Abert_Caixa
        {
            get { return _Data_Ult_Abert_Caixa; }
            set { _Data_Ult_Abert_Caixa = value; }
        }

        public string Data_Ult_Fech_Caixa
        {
            get { return _Data_Ult_Fech_Caixa; }
            set { _Data_Ult_Fech_Caixa = value; }
        }

        public byte Seven_Sistema_Adm
        {
            get { return _Seven_Sistema_Adm; }
            set { _Seven_Sistema_Adm = value; }
        }

        public byte Seven_Sistema_Pdv
        {
            get { return _Seven_Sistema_Pdv; }
            set { _Seven_Sistema_Pdv = value; }
        }

        public short Cod_Usuario_Adm
        {
            get { return _Cod_Usuario_Adm; }
            set { _Cod_Usuario_Adm = value; }
        }

        public string Nome_Usuario_Adm
        {
            get { return _Nome_Usuario_Adm; }
            set { _Nome_Usuario_Adm = value; }
        }

        public short Cod_Usuario_Pdv
        {
            get { return _Cod_Usuario_Pdv; }
            set { _Cod_Usuario_Pdv = value; }
        }


        public string Nome_Usuario_Pdv
        {
            get { return _Nome_Usuario_Pdv; }
            set { _Nome_Usuario_Pdv = value; }
        }

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Nome_Computador
        {
            get { return _Nome_Computador; }
            set { _Nome_Computador = value; }
        }

        public string Senha_Autorizacao
        {
            get { return _Senha_Autorizacao; }
            set { _Senha_Autorizacao = value; }
        }

        public string Tipo_Computador
        {
            get { return _Tipo_Computador; }
            set { _Tipo_Computador = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Nome_Computador = null;
            _Senha_Autorizacao = null;
            _Cod_Usuario_Adm = 0;
            _Nome_Usuario_Adm = null;
            _Cod_Usuario_Adm = 0;
            _Nome_Usuario_Adm = null;
            _Seven_Sistema_Adm = 0;
            _Seven_Sistema_Pdv = 0;
            _Tipo_Computador = null;
            _Data_Ult_Abert_Caixa = null;
            _Data_Ult_Fech_Caixa = null;
            _Pesquisa = null;
        }
    }
}
