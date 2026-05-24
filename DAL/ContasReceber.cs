using System;

namespace DAL
{
    public class ContasReceber : IDisposable
    {
        private int _Codigo;
        private short _Ocorrencia_Parc;
        private string _Descricao;
        private string _Data_Emissao;
        private string _Data_Vencimento;
        private string _Tipo_Documento;
        private short _Cod_Grupo;
        private string _Desc_Grupo;
        private short _Cod_Subgrupo;
        private string _Desc_Subgrupo;
        private decimal _Valor_Documento;
        private string _Data_Desconto;
        private decimal _Desconto_Porc;
        private decimal _Valor_Desconto;
        private decimal _Multa_Porc;
        private decimal _Valor_Multa;
        private decimal _Juros_Am_Porc;
        private decimal _Valor_Juros_Am;
        private int _Cod_Consumidor;
        private string _Nome_Consumidor;
        private string _Observacao;
        private string _Data_Cadastro;
        private decimal _Valor_Real;
        private string _Data_Baixa;
        private string _Situacao;
        private decimal _Valor_Total_Pago;
        private string _Tipo_Consumidor;
        private string _Palavra_Chave;
        private string _Pesquisar;
        private int _Cod_Venda;
        private decimal _Troco;
        private string _Hora_Baixa;
        private int _N_Promissoria;
        private byte _Ignorar_Multa;
        private byte _Ignorar_Juros_Am;
        private short _Cod_Usuario_Baixa;
        private string _Nome_Usuario_Baixa;
        private byte _Baixa_Apos_Vencimento;
        private short _Cod_PDV_Computador_Baixa;
        private int _Cod_Controle_Cheque;

        public int Cod_Controle_Cheque
        {
            get { return _Cod_Controle_Cheque; }
            set { _Cod_Controle_Cheque = value; }
        }


        public short Cod_PDV_Computador_Baixa
        {
            get { return _Cod_PDV_Computador_Baixa; }
            set { _Cod_PDV_Computador_Baixa = value; }
        }

        public byte Baixa_Apos_Vencimento
        {
            get { return _Baixa_Apos_Vencimento; }
            set { _Baixa_Apos_Vencimento = value; }
        }

        public byte Ignorar_Multa
        {
            get { return _Ignorar_Multa; }
            set { _Ignorar_Multa = value; }
        }

        public byte Ignorar_Juros_Am
        {
            get { return _Ignorar_Juros_Am; }
            set { _Ignorar_Juros_Am = value; }
        }

        public short Cod_Usuario_Baixa
        {
            get { return _Cod_Usuario_Baixa; }
            set { _Cod_Usuario_Baixa = value; }
        }

        public string Nome_Usuario_Baixa
        {
            get { return _Nome_Usuario_Baixa; }
            set { _Nome_Usuario_Baixa = value; }
        }

        public int N_Promissoria
        {
            get { return _N_Promissoria; }
            set { _N_Promissoria = value; }
        }

        public int Cod_Venda
        {
            get { return _Cod_Venda; }
            set { _Cod_Venda = value; }
        }

        public decimal Troco
        {
            get { return _Troco; }
            set { _Troco = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public decimal Valor_Real
        {
            get { return _Valor_Real; }
            set { _Valor_Real = value; }
        }

        public short Ocorrencia_Parc
        {
            get { return _Ocorrencia_Parc; }
            set { _Ocorrencia_Parc = value; }
        }

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public string Data_Emissao
        {
            get { return _Data_Emissao; }
            set { _Data_Emissao = value; }
        }

        public string Data_Vencimento
        {
            get { return _Data_Vencimento; }
            set { _Data_Vencimento = value; }
        }

        public string Tipo_Documento
        {
            get { return _Tipo_Documento; }
            set { _Tipo_Documento = value; }
        }

        public short Cod_Grupo
        {
            get { return _Cod_Grupo; }
            set { _Cod_Grupo = value; }
        }

        public string Desc_Grupo
        {
            get { return _Desc_Grupo; }
            set { _Desc_Grupo = value; }
        }

        public short Cod_Subgrupo
        {
            get { return _Cod_Subgrupo; }
            set { _Cod_Subgrupo = value; }
        }

        public string Desc_Subgrupo
        {
            get { return _Desc_Subgrupo; }
            set { _Desc_Subgrupo = value; }
        }

        public decimal Valor_Documento
        {
            get { return _Valor_Documento; }
            set { _Valor_Documento = value; }
        }

        public string Data_Desconto
        {
            get { return _Data_Desconto; }
            set { _Data_Desconto = value; }
        }

        public decimal Desconto_Porc
        {
            get { return _Desconto_Porc; }
            set { _Desconto_Porc = value; }
        }

        public decimal Valor_Desconto
        {
            get { return _Valor_Desconto; }
            set { _Valor_Desconto = value; }
        }

        public decimal Multa_Porc
        {
            get { return _Multa_Porc; }
            set { _Multa_Porc = value; }
        }

        public decimal Valor_Multa
        {
            get { return _Valor_Multa; }
            set { _Valor_Multa = value; }
        }

        public decimal Juros_Am_Porc
        {
            get { return _Juros_Am_Porc; }
            set { _Juros_Am_Porc = value; }
        }

        public decimal Valor_Juros_Am
        {
            get { return _Valor_Juros_Am; }
            set { _Valor_Juros_Am = value; }
        }

        public int Cod_Consumidor
        {
            get { return _Cod_Consumidor; }
            set { _Cod_Consumidor = value; }
        }

        public string Nome_Consumidor
        {
            get { return _Nome_Consumidor; }
            set { _Nome_Consumidor = value; }
        }

        public string Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        public string Data_Cadastro
        {
            get { return _Data_Cadastro; }
            set { _Data_Cadastro = value; }
        }

        public string Data_Baixa
        {
            get { return _Data_Baixa; }
            set { _Data_Baixa = value; }
        }

        public string Situacao
        {
            get { return _Situacao; }
            set { _Situacao = value; }
        }

        public decimal Valor_Total_Pago
        {
            get { return _Valor_Total_Pago; }
            set { _Valor_Total_Pago = value; }
        }


        public string Tipo_Consumidor
        {
            get { return _Tipo_Consumidor; }
            set { _Tipo_Consumidor = value; }
        }

        public string Palavra_Chave
        {
            get { return _Palavra_Chave; }
            set { _Palavra_Chave = value; }
        }

        public string Hora_Baixa
        {
            get { return _Hora_Baixa; }
            set { _Hora_Baixa = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Ocorrencia_Parc = 0;
            _Descricao = null;
            _Data_Emissao = null;
            _Data_Vencimento = null;
            _Tipo_Documento = null;
            _Cod_Grupo = 0;
            _Desc_Grupo = null;
            _Cod_Subgrupo = 0;
            _Desc_Subgrupo = null;
            _Valor_Documento = 0;
            _Data_Desconto = null;
            _Desconto_Porc = 0;
            _Valor_Desconto = 0;
            _Multa_Porc = 0;
            _Valor_Multa = 0;
            _Juros_Am_Porc = 0;
            _Valor_Juros_Am = 0;
            _Cod_Consumidor = 0;
            _Nome_Consumidor = null;
            _Observacao = null;
            _Data_Cadastro = null;
            _Valor_Real = 0;
            _Data_Baixa = null;
            _Situacao = null;
            _Valor_Total_Pago = 0;
            _Tipo_Consumidor = null;
            _Palavra_Chave = null;
            _Pesquisar = null;
            _N_Promissoria = 0;
            _Cod_Venda = 0;
            _Troco = 0;
            _Hora_Baixa = null;
            _Cod_Usuario_Baixa = 0;
            _Nome_Usuario_Baixa = null;
            _Ignorar_Juros_Am = 0;
            _Ignorar_Multa = 0;
            _Baixa_Apos_Vencimento = 0;
            _Cod_PDV_Computador_Baixa = 0;
            _Cod_Controle_Cheque = 0;
        }
    }
}
