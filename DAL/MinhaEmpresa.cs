using System;

namespace DAL
{
    public class MinhaEmpresa : IDisposable
    {
        private byte _Codigo;
        private string _Empresa;
        private string _CPF_CNPJ;
        private string _IE_RG;
        private string _Fantasia;
        private string _Endereco;
        private int _Numero;
        private string _Complemento;
        private string _Bairro;
        private string _UF;
        private string _Cidade;
        private string _CEP;
        private string _Telefone;
        private string _Celular;
        private string _Email;
        private string _Referencia;
        private string _Localizacao;
        private byte [] _Imagem_Logo;
        private string _Genero;
        private byte _Pessoa;
        private string _Empresa_Contador;
        private string _CPF_CNPJ_Contador;
        private string _IE_RG_Contador;
        private string _Fantasia_Contador;
        private string _Endereco_Contador;
        private int _Numero_Contador;
        private string _Complemento_Contador;
        private string _Bairro_Contador;
        private string _UF_Contador;
        private string _Cidade_Contador;
        private string _CEP_Contador;
        private string _Telefone_Contador;
        private string _Celular_Contador;
        private string _Email_Contador;
        private string _Referencia_Contador;
        private string _Localizacao_Contador;
        private string _Genero_Contador;
        private byte _Pessoa_Contador;
        private string _Email_Empresa;
        private string _Senha_Email_Empresa;
        private string _CRT;
        private short _CFOP_Trib_Dentro;
        private short _CFOP_Trib_Fora;
        private short _CFOP_Subs_Dentro;
        private short _CFOP_Subs_Fora;
        private short _Serie_NFe;
        private short _Serie_NFCe;
        private string _Codigo_Municipio;
        private string _Inscricao_Municipal;
        private byte _Backup_Automatico;
        private int _Ult_Num_NFCe;
        private int _Ult_Num_NFe;
        private int _Ult_Num_NFSe;

        public int Ult_Num_NFCe
        {
            get { return _Ult_Num_NFCe; }
            set { _Ult_Num_NFCe = value; }
        }

        public int Ult_Num_NFe
        {
            get { return _Ult_Num_NFe; }
            set { _Ult_Num_NFe = value; }
        }

        public int Ult_Num_NFSe
        {
            get { return _Ult_Num_NFSe; }
            set { _Ult_Num_NFSe = value; }
        }

        public byte Backup_Automatico
        {
            get { return _Backup_Automatico; }
            set { _Backup_Automatico = value; }
        }


        public string Inscricao_Municipal
        {
            get { return _Inscricao_Municipal; }
            set { _Inscricao_Municipal = value; }
        }

        public string Codigo_Municipio
        {
            get { return _Codigo_Municipio; }
            set { _Codigo_Municipio = value; }
        }

        public short Serie_NFe
        {
            get { return _Serie_NFe; }
            set { _Serie_NFe = value; }
        }

        public short Serie_NFCe
        {
            get { return _Serie_NFCe; }
            set { _Serie_NFCe = value; }
        }

        public short CFOP_Trib_Dentro
        {
            get { return _CFOP_Trib_Dentro; }
            set { _CFOP_Trib_Dentro = value; }
        }

        public short CFOP_Trib_Fora
        {
            get { return _CFOP_Trib_Fora; }
            set { _CFOP_Trib_Fora = value; }
        }

        public short CFOP_Subs_Dentro
        {
            get { return _CFOP_Subs_Dentro; }
            set { _CFOP_Subs_Dentro = value; }
        }

        public short CFOP_Subs_Fora
        {
            get { return _CFOP_Subs_Fora; }
            set { _CFOP_Subs_Fora = value; }
        }

        public string CRT
        {
            get { return _CRT; }
            set { _CRT = value; }
        }

        public string Empresa_Contador
        {
            get { return _Empresa_Contador; }
            set { _Empresa_Contador = value; }
        }

        public string CPF_CNPJ_Contador
        {
            get { return _CPF_CNPJ_Contador; }
            set { _CPF_CNPJ_Contador = value; }
        }

        public string IE_RG_Contador
        {
            get { return _IE_RG_Contador; }
            set { _IE_RG_Contador = value; }
        }

        public string Fantasia_Contador
        {
            get { return _Fantasia_Contador; }
            set { _Fantasia_Contador = value; }
        }

        public string Endereco_Contador
        {
            get { return _Endereco_Contador; }
            set { _Endereco_Contador = value; }
        }

        public int Numero_Contador
        {
            get { return _Numero_Contador; }
            set { _Numero_Contador = value; }
        }

        public string Complemento_Contador
        {
            get { return _Complemento_Contador; }
            set { _Complemento_Contador = value; }
        }

        public string Bairro_Contador
        {
            get { return _Bairro_Contador; }
            set { _Bairro_Contador = value; }
        }

        public string UF_Contador
        {
            get { return _UF_Contador; }
            set { _UF_Contador = value; }
        }

        public string Cidade_Contador
        {
            get { return _Cidade_Contador; }
            set { _Cidade_Contador = value; }
        }

        public string CEP_Contador
        {
            get { return _CEP_Contador; }
            set { _CEP_Contador = value; }
        }

        public string Telefone_Contador
        {
            get { return _Telefone_Contador; }
            set { _Telefone_Contador = value; }
        }

        public string Celular_Contador
        {
            get { return _Celular_Contador; }
            set { _Celular_Contador = value; }
        }

        public string Email_Contador
        {
            get { return _Email_Contador; }
            set { _Email_Contador = value; }
        }

        public string Referencia_Contador
        {
            get { return _Referencia_Contador; }
            set { _Referencia_Contador = value; }
        }

        public string Localizacao_Contador
        {
            get { return _Localizacao_Contador; }
            set { _Localizacao_Contador = value; }
        }

        public string Genero_Contador
        {
            get { return _Genero_Contador; }
            set { _Genero_Contador = value; }
        }

        public byte Pessoa_Contador
        {
            get { return _Pessoa_Contador; }
            set { _Pessoa_Contador = value; }
        }

        public byte Pessoa
        {
            get { return _Pessoa; }
            set { _Pessoa = value; }
        }

        public string Genero
        {
            get { return _Genero; }
            set { _Genero = value; }
        }

        public byte [] Imagem_Logo
        {
            get { return _Imagem_Logo; }
            set { _Imagem_Logo = value; }
        }

        public string Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }

        public string Localizacao
        {
            get { return _Localizacao; }
            set { _Localizacao = value; }
        }

        public byte Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Empresa
        {
            get { return _Empresa; }
            set { _Empresa = value; }
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

        public string Fantasia
        {
            get { return _Fantasia; }
            set { _Fantasia = value; }
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

        public string Email_Empresa
        {
            get { return _Email_Empresa; }
            set { _Email_Empresa = value; }
        }

        public string Senha_Email_Empresa
        {
            get { return _Senha_Email_Empresa; }
            set { _Senha_Email_Empresa = value; }
        }

        public void Dispose()
        {
            _Backup_Automatico = 0;
            _CRT = null;
            _Codigo = 0;
            _Empresa = null;
            _CPF_CNPJ = null;
            _IE_RG = null;
            _Fantasia = null;
            _Endereco = null;
            _Numero = 0;
            _Complemento = null;
            _Bairro = null;
            _UF = null;
            _Cidade = null;
            _CEP = null;
            _Telefone = null;
            _Celular = null;
            _Email = null;
            _Referencia = null;
            _Localizacao = null;
            _Imagem_Logo = null;
            _Genero = null;
            _Pessoa = 0;
            _Empresa_Contador = null;
            _CPF_CNPJ_Contador = null; ;
            _IE_RG_Contador = null;
            _Fantasia_Contador = null;
            _Endereco_Contador = null;
            _Numero_Contador = 0;
            _Complemento_Contador = null;
            _Bairro_Contador = null;
            _UF_Contador = null;
            _Cidade_Contador = null;
            _CEP_Contador = null;
            _Telefone_Contador = null;
            _Celular_Contador = null;
            _Email_Contador = null;
            _Referencia_Contador = null;
            _Localizacao_Contador = null;
            _Genero_Contador = null;
            _Pessoa_Contador = 0;
            _Email_Empresa = null;
            _Senha_Email_Empresa = null;
            _CFOP_Trib_Dentro = 0;
            _CFOP_Trib_Fora = 0;
            _CFOP_Subs_Dentro = 0;
            _CFOP_Subs_Fora = 0;
            _Serie_NFe = 0;
            _Serie_NFCe = 0;
            _Codigo_Municipio = null;
            _Inscricao_Municipal = null;
            _Ult_Num_NFCe = 0;
            _Ult_Num_NFe = 0;
            _Ult_Num_NFSe = 0;
        }
    }
}
