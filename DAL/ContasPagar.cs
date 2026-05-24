using System;

namespace DAL
{
    public class ContasPagar : IDisposable
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
        private string _Data_Desconto;
        private decimal _Desconto_Porc;
        private decimal _Valor_Desconto;
        private decimal _Multa_Porc;
        private decimal _Valor_Multa;
        private decimal _Juros_Am_Porc;
        private decimal _Valor_Juros_Am;
        private string _Palavra_Chave;
        private string _Contrato_Mat_Serv;
        private string _Cod_Barra;
        private string _Tipo_Emitente;
        private int _Cod_Emitente;
        private string _Nome_Emitente;
        private decimal _Valor_Documento;
        private string _Observacao;
        private string _Numero_Documento;
        private string _Situacao;
        private decimal _Valor_Total_Pago;
        private string _Data_Baixa;
        private string _Hora_Baixa;
        private decimal _Valor_Real;
        private string _Pesquisar;
        private string _Data_Cadastro;
        private decimal _Troco;
        private short _Cod_Usuario_Baixa;
        private string _Nome_Usuario_Baixa;
        private short _Cod_Entidade_Bancaria;
        private string _Desc_Entidade_Bancaria;
        private string _Tabela_Geradora;
        private int _Cod_Fato_Gerador;
        private short _Cod_PDV_Computador_Baixa;
        private byte _Alterar_Conta_Fechada;
        private byte _Excluir_Conta_Fechada;
        private byte _Excluir_Conta_Cascata;
        private int _Margem_Esq;
        private int _Margem_Topo;
        private int _Margem_Esq_Imp_Mat;
        private int _Margem_Topo_Imp_Mat;
        private int _Margem_Esq_Pdf_80;
        private int _Margem_Topo_Pdf_80;
        private byte _Usar_Axacropdf;
        private byte _Descontar_Caixa;

        public byte Descontar_Caixa
        {
            get { return _Descontar_Caixa; }
            set { _Descontar_Caixa = value; }
        }

        public short Cod_PDV_Computador_Baixa
        {
            get { return _Cod_PDV_Computador_Baixa; }
            set { _Cod_PDV_Computador_Baixa = value; }
        }

        public string Tabela_Geradora
        {
            get { return _Tabela_Geradora; }
            set { _Tabela_Geradora = value; }
        }

        public int Cod_Fato_Gerador
        {
            get { return _Cod_Fato_Gerador; }
            set { _Cod_Fato_Gerador = value; }
        }

        public short Cod_Entidade_Bancaria
        {
            get { return _Cod_Entidade_Bancaria; }
            set { _Cod_Entidade_Bancaria = value; }
        }

        public string Desc_Entidade_Bancaria
        {
            get { return _Desc_Entidade_Bancaria; }
            set { _Desc_Entidade_Bancaria = value; }
        }

        public decimal Valor_Juros_Am
        {
            get { return _Valor_Juros_Am; }
            set { _Valor_Juros_Am = value; }
        }

        public byte Excluir_Conta_Cascata
        {
            get { return _Excluir_Conta_Cascata; }
            set { _Excluir_Conta_Cascata = value; }
        }

        public byte Usar_Axacropdf
        {
            get { return _Usar_Axacropdf; }
            set { _Usar_Axacropdf = value; }
        }

        public int Margem_Esq_Imp_Mat
        {
            get { return _Margem_Esq_Imp_Mat; }
            set { _Margem_Esq_Imp_Mat = value; }
        }

        public int Margem_Topo_Imp_Mat
        {
            get { return _Margem_Topo_Imp_Mat; }
            set { _Margem_Topo_Imp_Mat = value; }
        }

        public int Margem_Esq_Pdf_80
        {
            get { return _Margem_Esq_Pdf_80; }
            set { _Margem_Esq_Pdf_80 = value; }
        }

        public int Margem_Topo_Pdf_80
        {
            get { return _Margem_Topo_Pdf_80; }
            set { _Margem_Topo_Pdf_80 = value; }
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

        public int Margem_Esq
        {
            get { return _Margem_Esq; }
            set { _Margem_Esq = value; }
        }

        public int Margem_Topo
        {
            get { return _Margem_Topo; }
            set { _Margem_Topo = value; }
        }

        public byte Alterar_Conta_Fechada
        {
            get { return _Alterar_Conta_Fechada; }
            set { _Alterar_Conta_Fechada = value; }
        }

        public byte Excluir_Conta_Fechada
        {
            get { return _Excluir_Conta_Fechada; }
            set { _Excluir_Conta_Fechada = value; }
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

        public string Hora_Baixa
        {
            get { return _Hora_Baixa; }
            set { _Hora_Baixa = value; }
        }

        public decimal Valor_Real
        {
            get { return _Valor_Real; }
            set { _Valor_Real = value; }
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

        public string Numero_Documento
        {
            get { return _Numero_Documento; }
            set { _Numero_Documento = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
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

        public string Palavra_Chave
        {
            get { return _Palavra_Chave; }
            set { _Palavra_Chave = value; }
        }

        public string Contrato_Mat_Serv
        {
            get { return _Contrato_Mat_Serv; }
            set { _Contrato_Mat_Serv = value; }
        }

        public decimal Troco
        {
            get { return _Troco; }
            set { _Troco = value; }
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

        public string Cod_Barra
        {
            get { return _Cod_Barra; }
            set { _Cod_Barra = value; }
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

        public string Tipo_Emitente
        {
            get { return _Tipo_Emitente; }
            set { _Tipo_Emitente = value; }
        }

        public int Cod_Emitente
        {
            get { return _Cod_Emitente; }
            set { _Cod_Emitente = value; }
        }

        public string Nome_Emitente
        {
            get { return _Nome_Emitente; }
            set { _Nome_Emitente = value; }
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

        public decimal Valor_Desconto
        {
            get { return _Valor_Desconto; }
            set { _Valor_Desconto = value; }
        }

        public decimal Desconto_Porc
        {
            get { return _Desconto_Porc; }
            set { _Desconto_Porc = value; }
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

        public void Dispose()
        {
            _Excluir_Conta_Cascata = 0;
            _Margem_Esq_Imp_Mat = 0;
            _Margem_Topo_Imp_Mat = 0;
            _Margem_Esq_Pdf_80 = 0;
            _Margem_Topo_Pdf_80 = 0;
            _Usar_Axacropdf = 0;
            _Codigo = 0;
            _Palavra_Chave = null;
            _Contrato_Mat_Serv = null;
            _Ocorrencia_Parc = 0;
            _Descricao = null;
            _Cod_Barra = null;
            _Data_Emissao = null;
            _Data_Vencimento = null;
            _Tipo_Documento = null;
            _Cod_Emitente = 0;
            _Nome_Emitente = null;
            _Tipo_Emitente = null;
            _Valor_Documento = 0;
            _Data_Desconto = null;
            _Valor_Desconto = 0;
            _Desconto_Porc = 0;
            _Multa_Porc = 0;
            _Juros_Am_Porc = 0;
            _Valor_Multa = 0;
            _Observacao = null;
            _Numero_Documento = null;
            _Pesquisar = null;
            _Situacao = null;
            _Valor_Total_Pago = 0;
            _Data_Baixa = null;
            _Hora_Baixa = null;
            _Valor_Real = 0;
            _Excluir_Conta_Fechada = 0;
            _Alterar_Conta_Fechada = 0;
            _Margem_Topo = 0;
            _Margem_Esq = 0;
            _Cod_Grupo = 0;
            _Desc_Grupo = null;
            _Cod_Subgrupo = 0;
            _Desc_Subgrupo = null;
            _Valor_Juros_Am = 0;
            _Cod_Usuario_Baixa = 0;
            _Nome_Usuario_Baixa = null;
            _Cod_Entidade_Bancaria = 0;
            _Desc_Entidade_Bancaria = null;
            _Tabela_Geradora = null;
            _Cod_Fato_Gerador = 0;
            _Descontar_Caixa = 0;
        }
    }
}
