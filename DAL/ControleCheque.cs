using System;

namespace DAL
{
    public class ControleCheque : IDisposable
    {
        private int _Codigo;
        private string _Data_Entrada;
        private int _Cod_Cliente;
        private string _Nome_Cliente;
        private string _CPF_CNPJ;
        private short _Cod_Entidade_Bancaria;
        private string _Nome_Entidade_Bancaria;
        private string _Beneficiario;
        private string _Agencia;
        private string _Conta_Corrente;
        private int _Numero_Cheque;
        private decimal _Valor;
        private string _Data_Vencimento;
        private string _Data_Compensacao;
        private string _Situacao;
        private string _Observacao;
        private string _Horario_Entrada;
        private string _Horario_Vencimento;
        private string _Horario_Compensacao;
        private int _Cod_Fato_Gerador;
        private short _Cod_Usuario;
        private string _Nome_Usuario;
        private short _Cod_PDV_Computador;
        private string _Tipo_Emitente;
        private string _Tipo_Fato_Gerador;

        public string Tipo_Fato_Gerador
        {
            get { return _Tipo_Fato_Gerador; }
            set { _Tipo_Fato_Gerador = value; }
        }

        public string Tipo_Emitente
        {
            get { return _Tipo_Emitente; }
            set { _Tipo_Emitente = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Data_Entrada
        {
            get { return _Data_Entrada; }
            set { _Data_Entrada = value; }
        }

        public string CPF_CNPJ
        {
            get { return _CPF_CNPJ; }
            set { _CPF_CNPJ = value; }
        }

        public string Beneficiario
        {
            get { return _Beneficiario; }
            set { _Beneficiario = value; }
        }

        public int Cod_Cliente
        {
            get { return _Cod_Cliente; }
            set { _Cod_Cliente = value; }
        }

        public string Nome_Cliente
        {
            get { return _Nome_Cliente; }
            set { _Nome_Cliente = value; }
        }

        public short Cod_Entidade_Bancaria
        {
            get { return _Cod_Entidade_Bancaria; }
            set { _Cod_Entidade_Bancaria = value; }
        }

        public string Nome_Entidade_Bancaria
        {
            get { return _Nome_Entidade_Bancaria; }
            set { _Nome_Entidade_Bancaria = value; }
        }

        public string Agencia
        {
            get { return _Agencia; }
            set { _Agencia = value; }
        }

        public string Conta_Corrente
        {
            get { return _Conta_Corrente; }
            set { _Conta_Corrente = value; }
        }

        public int Numero_Cheque
        {
            get { return _Numero_Cheque; }
            set { _Numero_Cheque = value; }
        }

        public decimal Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        public string Data_Vencimento
        {
            get { return _Data_Vencimento; }
            set { _Data_Vencimento = value; }
        }

        public string Data_Compensacao
        {
            get { return _Data_Compensacao; }
            set { _Data_Compensacao = value; }
        }

        public string Situacao
        {
            get { return _Situacao; }
            set { _Situacao = value; }
        }

        public string Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        public string Horario_Entrada
        {
            get { return _Horario_Entrada; }
            set { _Horario_Entrada = value; }
        }

        public string Horario_Vencimento
        {
            get { return _Horario_Vencimento; }
            set { _Horario_Vencimento = value; }
        }

        public string Horario_Compensacao
        {
            get { return _Horario_Compensacao; }
            set { _Horario_Compensacao = value; }
        }

        public int Cod_Fato_Gerador
        {
            get { return _Cod_Fato_Gerador; }
            set { _Cod_Fato_Gerador = value; }
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

        public short Cod_PDV_Computador
        {
            get { return _Cod_PDV_Computador; }
            set { _Cod_PDV_Computador = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Data_Entrada = null;
            _Cod_Cliente = 0;
            _Nome_Cliente = null;
            _Cod_Entidade_Bancaria = 0;
            _Nome_Entidade_Bancaria = null;
            _Agencia = null;
            _Conta_Corrente = null;
            _Numero_Cheque = 0;
            _Valor = 0;
            _Data_Vencimento = null;
            _Data_Compensacao = null;
            _Situacao = null;
            _Observacao = null;
            _Horario_Entrada = null;
            _Horario_Vencimento = null;
            _Horario_Compensacao = null;
            _CPF_CNPJ = null;
            _Beneficiario = null;
            _Tipo_Emitente = null;
            _Tipo_Fato_Gerador = null;
        }
    }
}
