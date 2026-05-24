using System;

namespace DAL
{
    public class Item_Orc_Temp : IDisposable
    {
        private short _Codigo;
        private int _Cod_Item_Orc;
        private string _Descricao;
        private decimal _Quantidade;
        private decimal _Valor_Unitario;
        private decimal _Valor_Total;
        private string _UM;
        private decimal _Desconto_Porc;
        private decimal _Valor_Desconto_Item;
        private decimal _Acrescimo_Porc;
        private decimal _Valor_Acrescimo_Item;
        private decimal _Valor_Total_A_Desc_Acresc;
        private short _Cod_Conexao_Configuracoes;
        private byte _Tabela;

        public byte Tabela
        {
            get { return _Tabela; }
            set { _Tabela = value; }
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

        public decimal Acrescimo_Porc
        {
            get { return _Acrescimo_Porc; }
            set { _Acrescimo_Porc = value; }
        }

        public decimal Desconto_Porc
        {
            get { return _Desconto_Porc; }
            set { _Desconto_Porc = value; }
        }

        public decimal Valor_Desconto_Item
        {
            get { return _Valor_Desconto_Item; }
            set { _Valor_Desconto_Item = value; }
        }

        public decimal Valor_Acrescimo_Item
        {
            get { return _Valor_Acrescimo_Item; }
            set { _Valor_Acrescimo_Item = value; }
        }

        public string UM
        {
            get { return _UM; }
            set { _UM = value; }
        }

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public int Cod_Item_Orc
        {
            get { return _Cod_Item_Orc; }
            set { _Cod_Item_Orc = value; }
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

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Item_Orc = 0;
            _Descricao = null;
            _Quantidade = 0;
            _Valor_Unitario = 0;
            _Valor_Total = 0;
            _UM = null;
            _Valor_Acrescimo_Item = 0;
            _Valor_Desconto_Item = 0;
            _Acrescimo_Porc = 0;
            _Desconto_Porc = 0;
            _Valor_Total_A_Desc_Acresc = 0;
            _Cod_Conexao_Configuracoes = 0;
            _Tabela = 0;
        }
    }
}
