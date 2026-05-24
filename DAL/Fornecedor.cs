using System;

namespace DAL
{
    public class Fornecedor : IDisposable
    {
        private int _Codigo;
        private string _Nome;
        private string _CPF_CNPJ;
        private string _IE_RG;
        private string _Telefone;
        private string _CEP;
        private string _Endereco;
        private string _Cidade;
        private string _Complemento;
        private string _UF;
        private string _Bairro;
        private string _Email;
        private string _Celular;
        private int _Numero;
        private string _FAX;
        private string _Fantasia;
        private string _Data_Nascimento;
        private byte _Pessoa;
        private string _Observacao;
        private string _Pesquisar;
        private string _Genero;
        private string _Palavra_Chave;
        private byte [] _Imagem_Forn;
        private string _Data_Cadastro;
        private string _Codigo_Municipio;

        public string Codigo_Municipio
        {
            get { return _Codigo_Municipio; }
            set { _Codigo_Municipio = value; }
        }

        public string Data_Cadastro
        {
            get { return _Data_Cadastro; }
            set { _Data_Cadastro = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        public string CPF_CNPJ
        {
            get { return _CPF_CNPJ; }
            set { _CPF_CNPJ = value; }
        }

        public string IE_RG
        {
            get { return _IE_RG; }
            set { _IE_RG = value; }
        }

        public string Telefone
        {
            get { return _Telefone; }
            set { _Telefone = value; }
        }

        public string CEP
        {
            get { return _CEP; }
            set { _CEP = value; }
        }

        public string Complemento
        {
            get { return _Complemento; }
            set { _Complemento = value; }
        }

        public string Endereco
        {
            get { return _Endereco; }
            set { _Endereco = value; }
        }

        public string Cidade
        {
            get { return _Cidade; }
            set { _Cidade = value; }
        }

        public string UF
        {
            get { return _UF; }
            set { _UF = value; }
        }

        public string Bairro
        {
            get { return _Bairro; }
            set { _Bairro = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Celular
        {
            get { return _Celular; }
            set { _Celular = value; }
        }

        public int Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        public string FAX
        {
            get { return _FAX; }
            set { _FAX = value; }
        }

        public string Fantasia
        {
            get { return _Fantasia; }
            set { _Fantasia = value; }
        }

        public string Data_Nascimento
        {
            get { return _Data_Nascimento; }
            set { _Data_Nascimento = value; }
        }

        public byte Pessoa
        {
            get { return _Pessoa; }
            set { _Pessoa = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public string Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        public string Genero
        {
            get { return _Genero; }
            set { _Genero = value; }
        }

        public string Palavra_Chave
        {
            get { return _Palavra_Chave; }
            set { _Palavra_Chave = value; }
        }

        public byte[] Imagem_Forn
        {
            get { return _Imagem_Forn; }
            set { _Imagem_Forn = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Nome = null;
            _CPF_CNPJ = null;
            _IE_RG = null;
            _Telefone = null;
            _CEP = null;
            _Endereco = null;
            _Cidade = null;
            _Complemento = null;
            _UF = null;
            _Bairro = null;
            _Email = null;
            _Celular = null;
            _Numero = 0;
            _FAX = null;
            _Fantasia = null;
            _Data_Nascimento = null;
            _Pessoa = 0;
            _Pesquisar = null;
            _Genero = null;
            _Palavra_Chave = null;
            _Imagem_Forn = null;
            _Data_Cadastro = null;
            _Codigo_Municipio = null;
        }
    }
}
