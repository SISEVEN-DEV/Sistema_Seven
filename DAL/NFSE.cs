using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NFSE : IDisposable
    {
        private int _Codigo;
        private int _Numero_NF;
        private int _Cod_Consumidor;
        private string _Nome_Consumidor;
        private string _CPF_CNPJ_Consumidor;
        private decimal _Preco;
        private string _Data_Emissao;
        private string _Hora_Emissao;
        private string _Serie;
        private string _Situacao;
        private string _Data_Cadastro;
        private int _Cod_OS;

        public int Cod_OS
        {
            get { return _Cod_OS; }
            set { _Cod_OS = value; }
        }

        public string Situacao
        {
            get { return _Situacao; }
            set { _Situacao = value; }
        }

        public string Data_Cadastro
        {
            get { return _Data_Cadastro; }
            set { _Data_Cadastro = value; }
        }

        public string Serie
        {
            get { return _Serie; }
            set { _Serie = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public int Numero_NF 
        {
            get { return _Numero_NF; }
            set { _Numero_NF = value; }
        }

        public int Cod_Consumidor
        {
            get { return _Cod_Consumidor; }
            set { _Cod_Consumidor = value; }
        }

        public string CPF_CNPJ_Consumidor
        {
            get { return _CPF_CNPJ_Consumidor; }
            set { _CPF_CNPJ_Consumidor = value; }
        }

        public string Nome_Consumidor
        {
            get { return _Nome_Consumidor; }
            set { _Nome_Consumidor = value; }
        }

        public decimal Preco
        {
            get { return _Preco; }
            set { _Preco = value; }
        }

        public string Data_Emissao
        {
            get { return _Data_Emissao; }
            set { _Data_Emissao = value; }
        }

        public string Hora_Emissao
        {
            get { return _Hora_Emissao; }
            set { _Hora_Emissao = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Numero_NF = 0;
            _Cod_Consumidor = 0;
            _Nome_Consumidor = null;
            _CPF_CNPJ_Consumidor = null;
            _Preco = 0;
            _Data_Emissao = null;
            _Hora_Emissao = null;
            _Serie = null;
            _Situacao = null;
            _Data_Cadastro = null;
            _Cod_OS = 0;
        }
    }
}
