using System;

namespace DAL
{
    public class Item_PDV_Temp : IDisposable
    {
        private short _Codigo;
        private int _Cod_Produto;
        private string _Descricao;
        private decimal _Quantidade;
        private string _UM;
        private decimal _Valor_Unitario;
        private decimal _Valor_Total;
        private decimal _Valor_Desconto;
        private decimal _Valor_Acrescimo;
        private decimal _Valor_Total_A_Desc_Acresc;
        private byte _Cod_Tabela;
        private short _Cod_Conexao_Configuracoes;
        private string _Tipo;

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public short Cod_Conexao_Configuracoes
        {
            get { return _Cod_Conexao_Configuracoes; }
            set { _Cod_Conexao_Configuracoes = value; }
        }

        public decimal Valor_Total_A_Desc_Acresc
        {
            get { return _Valor_Total_A_Desc_Acresc; }
            set { _Valor_Total_A_Desc_Acresc = value; }
        }

        public decimal Valor_Desconto
        {
            get { return _Valor_Desconto; }
            set { _Valor_Desconto = value; }
        }

        public decimal Valor_Acrescimo
        {
            get { return _Valor_Acrescimo; }
            set { _Valor_Acrescimo = value; }
        }

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public int Cod_Produto
        {
            get { return _Cod_Produto; }
            set { _Cod_Produto = value; }
        }

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public decimal Quantidade
        {
            get { return _Quantidade; }
            set { _Quantidade = value; }
        }

        public string UM
        {
            get { return _UM; }
            set { _UM = value; }
        }

        public decimal Valor_Unitario
        {
            get { return _Valor_Unitario; }
            set { _Valor_Unitario = value; }
        }

        public decimal Valor_Total
        {
            get { return _Valor_Total; }
            set { _Valor_Total = value; }
        }

        public byte Cod_Tabela
        {
            get { return _Cod_Tabela; }
            set { _Cod_Tabela = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Produto = 0;
            _Descricao = null;
            _Quantidade = 0;
            _UM = null;
            _Valor_Unitario = 0;
            _Valor_Total = 0;
            _Valor_Acrescimo = 0;
            _Valor_Desconto = 0;
            _Valor_Total_A_Desc_Acresc = 0;
            _Cod_Tabela = 0;
            _Cod_Conexao_Configuracoes = 0;
            _Tipo = null;
        }
    }
}
