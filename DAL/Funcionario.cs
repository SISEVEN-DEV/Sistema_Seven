using System;

namespace DAL
{
    public class Funcionario : IDisposable
    {
        private short _Codigo;
        private string _Palavra_Chave;
        private string _Nome;
        private string _Data_Nascimento;
        private string _CPF;
        private string _RG;
        private string _Sexo;
        private string _Endereco;
        private int _Numero;
        private string _Complemento;
        private string _Bairro;
        private string _UF;
        private string _Cidade;
        private string _CEP;
        private string _Telefone;
        private string _FAX;
        private string _Celular;
        private string _Email;
        private string _Observacao;
        private byte [] _Imagem_Func;
        private string _Pesquisar;
        private string _Data_Cadastro;

        public string Data_Cadastro
        {
            get { return _Data_Cadastro; }
            set { _Data_Cadastro = value; }
        }

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Palavra_Chave
        {
            get { return _Palavra_Chave; }
            set { _Palavra_Chave = value; }
        }

        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        public string Data_Nascimento
        {
            get { return _Data_Nascimento; }
            set { _Data_Nascimento = value; }
        }

        public string CPF
        {
            get { return _CPF; }
            set { _CPF = value; }
        }

        public string RG
        {
            get { return _RG; }
            set { _RG = value; }
        }

        public string Sexo
        {
            get { return _Sexo; }
            set { _Sexo = value; }
        }

        public string Endereco
        {
            get { return _Endereco; }
            set { _Endereco = value; }
        }

        public int Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        public string Complemento
        {
            get { return _Complemento; }
            set { _Complemento = value; }
        }

        public string Bairro
        {
            get { return _Bairro; }
            set { _Bairro = value; }
        }

        public string UF
        {
            get { return _UF; }
            set { _UF = value; }
        }

        public string Cidade
        {
            get { return _Cidade; }
            set { _Cidade = value; }
        }

        public string CEP
        {
            get { return _CEP; }
            set { _CEP = value; }
        }

        public string Telefone
        {
            get { return _Telefone; }
            set { _Telefone = value; }
        }

        public string FAX
        {
            get { return _FAX; }
            set { _FAX = value; }
        }

        public string Celular
        {
            get { return _Celular; }
            set { _Celular = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        public byte [] Imagem_Func
        {
            get { return _Imagem_Func; }
            set { _Imagem_Func = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Palavra_Chave = null;
            _Nome = null;
            _Data_Nascimento = null;
            _CPF = null;
            _RG = null;
            _Sexo = null;
            _Endereco = null;
            _Numero = 0;
            _Complemento = null;
            _Bairro = null;
            _UF = null;
            _Cidade = null;
            _CEP = null;
            _Telefone = null;
            _FAX = null;
            _Celular = null;
            _Email = null;
            _Observacao = null;
            _Data_Cadastro = null;
        }
    }
}
