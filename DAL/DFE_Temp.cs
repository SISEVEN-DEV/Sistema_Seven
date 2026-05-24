using System;

namespace DAL
{
    public class DFE_Temp : IDisposable
    {
        private int _Cod_DFe;
        private short _Cod_Conexao_Configuracoes;
        private string _Modelo;
        private string _Observacao;
        private string _Data_Saida;
        private string _Hora_Saida;
        private int _Cod_Emitente_Destinatario;
        private string _Nome_Emitente_Destinatario;
        private string _Emissao;
        private int _Cod_CFOP;
        private string _Descricao_CFOP;
        private string _Tipo_Emitente_Destinatario;
        private string _Finalidade;
        private byte _Consumidor_Final;
        private string _Tipo_Operacao;
        private string _CPF_CNPJ_Emitente_Destinatario;

        public int Cod_DFe
        {
            get { return _Cod_DFe; }
            set { _Cod_DFe = value; }
        }

        public string CPF_CNPJ_Emitente_Destinatario
        {
            get { return _CPF_CNPJ_Emitente_Destinatario; }
            set { _CPF_CNPJ_Emitente_Destinatario = value; }
        }

        public string Finalidade
        {
            get { return _Finalidade; }
            set { _Finalidade = value; }
        }

        public string Tipo_Emitente_Destinatario
        {
            get { return _Tipo_Emitente_Destinatario; }
            set { _Tipo_Emitente_Destinatario = value; }
        }

        public int Cod_CFOP
        {
            get { return _Cod_CFOP; }
            set { _Cod_CFOP = value; }
        }

        public string Descricao_CFOP
        {
            get { return _Descricao_CFOP; }
            set { _Descricao_CFOP = value; }
        }

        public short Cod_Conexao_Configuracoes
        {
            get { return _Cod_Conexao_Configuracoes; }
            set { _Cod_Conexao_Configuracoes = value; }
        }

        public string Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        public string Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }
        public string Data_Saida
        {
            get { return _Data_Saida; }
            set { _Data_Saida = value; }
        }

        public string Hora_Saida
        {
            get { return _Hora_Saida; }
            set { _Hora_Saida = value; }
        }
        public int Cod_Emitente_Destinatario
        {
            get { return _Cod_Emitente_Destinatario; }
            set { _Cod_Emitente_Destinatario = value; }
        }

        public string Nome_Emitente_Destinatario
        {
            get { return _Nome_Emitente_Destinatario; }
            set { _Nome_Emitente_Destinatario = value; }
        }

        public string Emissao
        {
            get { return _Emissao; }
            set { _Emissao = value; }
        }

        public byte Consumidor_Final
        {
            get { return _Consumidor_Final; }
            set { _Consumidor_Final = value; }
        }

        public string Tipo_Operacao
        {
            get { return _Tipo_Operacao; }
            set { _Tipo_Operacao = value; }
        }

        public void Dispose()
        {
            _Cod_DFe = 0;
            _Descricao_CFOP = null;
            _Cod_CFOP = 0;
            _Modelo = null;
            _Observacao = null;
            _Data_Saida = null;
            _Hora_Saida = null;
            _Cod_Emitente_Destinatario = 0;
            _Nome_Emitente_Destinatario = null;
            _Tipo_Emitente_Destinatario = null;
            _Finalidade = null;
            _Cod_Conexao_Configuracoes = 0;
            _Consumidor_Final = 0;
            _Tipo_Operacao = null;
            _CPF_CNPJ_Emitente_Destinatario = null;
        }
    }
}
