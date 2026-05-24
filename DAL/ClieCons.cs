using System;

namespace DAL
{
    public class ClieCons : IDisposable
    {
        private int _Codigo;
        private string _Nome;
        private string _Data_Nascimento;
        private string _CPF_CNPJ;
        private string _IE_RG;
        private string _Genero;
        private string _Telefone;
        private string _Celular;
        private string _Email;
        private string _Endereco;
        private int _Numero;
        private string _Complemento;
        private string _Bairro;
        private string _Uf;
        private string _Cidade;
        private string _Cep;
        private string _Nome_Pai;
        private string _Cpf_Pai;
        private string _Celular_Pai;
        private string _Email_Pai;
        private string _Nome_Mae;
        private string _Cpf_Mae;
        private string _Celular_Mae;
        private string _Email_Mae;
        private string _Observacao;
        private string _Pesquisar;
        private byte [] _Imagem_Cliente;
        private string _Palavra_Chave;
        private string _Data_Cadastro;
        private byte _Pessoa;
        private string _Fantasia;
        private string _FAX;
        private decimal _Saldo_Credito_Loja;
        private string _Situacao;
        private decimal _Credito;
        private decimal _Saldo;
        private string _Avalista;
        private string _CPF_Avalista;
        private string _RG_Avalista;
        private string _Email_Avalista;
        private string _Endereco_Avalista;
        private string _Bairro_Avalista;
        private string _UF_Avalista;
        private string _Cidade_Avalista;
        private int _Numero_Avalista;
        private string _Complemento_Avalista;
        private string _CEP_Avalista;
        private string _Telefone_Avalista;
        private string _Celular_Avalista;
        private short _Cod_Grupo;
        private short _Cod_SubGrupo;
        private string _Desc_Grupo;
        private string _Desc_SubGrupo;
        private string _Codigo_Municipio;
        private string _Data_Ult_Alteracao;

        public string Codigo_Municipio
        {
            get { return _Codigo_Municipio; }
            set { _Codigo_Municipio = value; }
        }


        public short Cod_Grupo
        {
            get { return _Cod_Grupo; }
            set { _Cod_Grupo = value; }
        }

        public short Cod_SubGrupo
        {
            get { return _Cod_SubGrupo; }
            set { _Cod_SubGrupo = value; }
        }

        public string Desc_Grupo
        {
            get { return _Desc_Grupo; }
            set { _Desc_Grupo = value; }
        }

        public string Desc_SubGrupo
        {
            get { return _Desc_SubGrupo; }
            set { _Desc_SubGrupo = value; }
        }

        public string Situacao
        {
            get { return _Situacao; }
            set { _Situacao = value; }
        }

        public decimal Credito
        {
            get { return _Credito; }
            set { _Credito = value; }
        }

        public decimal Saldo
        {
            get { return _Saldo; }
            set { _Saldo = value; }
        }

        public string Avalista
        {
            get { return _Avalista; }
            set { _Avalista = value; }
        }

        public string CPF_Avalista
        {
            get { return _CPF_Avalista; }
            set { _CPF_Avalista = value; }
        }

        public string RG_Avalista
        {
            get { return _RG_Avalista; }
            set { _RG_Avalista = value; }
        }

        public string Email_Avalista
        {
            get { return _Email_Avalista; }
            set { _Email_Avalista = value; }
        }

        public string Endereco_Avalista
        {
            get { return _Endereco_Avalista; }
            set { _Endereco_Avalista = value; }
        }

        public string Bairro_Avalista
        {
            get { return _Bairro_Avalista; }
            set { _Bairro_Avalista = value; }
        }

        public string UF_Avalista
        {
            get { return _UF_Avalista; }
            set { _UF_Avalista = value; }
        }

        public string Cidade_Avalista
        {
            get { return _Cidade_Avalista; }
            set { _Cidade_Avalista = value; }
        }

        public int Numero_Avalista
        {
            get { return _Numero_Avalista; }
            set { _Numero_Avalista = value; }
        }

        public string Complemento_Avalista
        {
            get { return _Complemento_Avalista; }
            set { _Complemento_Avalista = value; }
        }

        public string CEP_Avalista
        {
            get { return _CEP_Avalista; }
            set { _CEP_Avalista = value; }
        }

        public string Telefone_Avalista
        {
            get { return _Telefone_Avalista; }
            set { _Telefone_Avalista = value; }
        }

        public string Celular_Avalista
        {
            get { return _Celular_Avalista; }
            set { _Celular_Avalista = value; }
        }

        public decimal Saldo_Credito_Loja
        {
            get { return _Saldo_Credito_Loja; }
            set { _Saldo_Credito_Loja = value; }
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

        public byte Pessoa
        {
            get { return _Pessoa; }
            set { _Pessoa = value; }
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

        public string Data_Nascimento
        {
            get { return _Data_Nascimento; }
            set { _Data_Nascimento = value; }
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

        public string Genero
        {
            get { return _Genero; }
            set { _Genero = value; }
        }

        public string Telefone
        {
            get { return _Telefone; }
            set { _Telefone = value; }
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

        public string Uf
        {
            get { return _Uf; }
            set { _Uf = value; }
        }

        public string Cidade
        {
            get { return _Cidade; }
            set { _Cidade = value; }
        }

        public string Cep
        {
            get { return _Cep; }
            set { _Cep = value; }
        }

        public string Nome_Pai
        {
            get { return _Nome_Pai; }
            set { _Nome_Pai = value; }
        }

        public string CPF_Pai
        {
            get { return _Cpf_Pai; }
            set { _Cpf_Pai = value; }
        }

        public string Celular_Pai
        {
            get { return _Celular_Pai; }
            set { _Celular_Pai = value; }
        }

        public string Email_Pai
        {
            get { return _Email_Pai; }
            set { _Email_Pai = value; }
        }

        public string Nome_Mae
        {
            get { return _Nome_Mae; }
            set { _Nome_Mae = value; }
        }

        public string CPF_Mae
        {
            get { return _Cpf_Mae; }
            set { _Cpf_Mae = value; }
        }

        public string Celular_Mae
        {
            get { return _Celular_Mae; }
            set { _Celular_Mae = value; }
        }

        public string Email_Mae
        {
            get { return _Email_Mae; }
            set { _Email_Mae = value; }
        }

        public string Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public byte [] Imagem_Cliente
        {
            get { return _Imagem_Cliente; }
            set { _Imagem_Cliente = value; }
        }

        public string Palavra_Chave
        {
            get { return _Palavra_Chave; }
            set { _Palavra_Chave = value; }
        }

        public string Data_Ult_Alteracao
        { 
            get { return _Data_Ult_Alteracao; }
            set { _Data_Ult_Alteracao = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Nome = null;
            _Data_Nascimento = null;
            _CPF_CNPJ = null;
            _IE_RG = null;
            _Genero = null;
            _Telefone = null;
            _Celular = null;
            _Email = null;
            _Endereco = null;
            _Numero = 0;
            _Complemento = null;
            _Bairro = null;
            _Uf = null;
            _Cidade = null;
            _Cep = null;
            _Nome_Pai = null;
            _Cpf_Pai = null;
            _Celular_Pai = null;
            _Email_Pai = null;
            _Nome_Mae = null;
            _Cpf_Mae = null;
            _Celular_Mae = null;
            _Email_Mae = null;
            _Observacao = null;
            _Pesquisar = null;
            _Imagem_Cliente = null;
            _Palavra_Chave = null;
            _Data_Cadastro = null;
            _Pessoa = 0;
            _Fantasia = null;
            _FAX = null;
            _Situacao = null;
            _Credito = 0;
            _Saldo = 0;
            _Avalista = null;
            _CPF_Avalista = null;
            _RG_Avalista = null;
            _Email_Avalista = null;
            _Endereco_Avalista = null;
            _Bairro_Avalista = null;
            _UF_Avalista = null;
            _Cidade_Avalista = null;
            _Numero_Avalista = 0;
            _Complemento_Avalista = null;
            _CEP_Avalista = null;
            _Telefone_Avalista = null;
            _Celular_Avalista = null;
            _Cod_Grupo = 0;
            _Cod_SubGrupo = 0;
            _Desc_Grupo = null;
            _Desc_SubGrupo = null;
            _Codigo_Municipio = null;
            _Data_Ult_Alteracao = null;
        }
    }
}