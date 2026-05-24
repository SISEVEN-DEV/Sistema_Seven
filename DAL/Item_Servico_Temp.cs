using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Item_Servico_Temp : IDisposable
    {
        private short _Codigo;
        private int _Cod_Servico;
        private string _Desc_Servico;
        private decimal _Valor_Unitario;
        private decimal _Valor_Total;
        private short _Cod_Conexao_Configuracoes;
        private decimal _Quantidade;
        private decimal _Comissao_Porc;
        private decimal _Valor_Desconto;
        private decimal _Valor_Acrescimo;
        private decimal _Valor_Total_A_Desc_Acresc;
        private int _Cod_Orcamento;

        public int Cod_Orcamento
        {
            get { return _Cod_Orcamento; }
            set { _Cod_Orcamento = value; }
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

        public decimal Comissao_Porc
        {
            get { return _Comissao_Porc; }
            set { _Comissao_Porc = value; }
        }

        public short Cod_Conexao_Configuracoes
        {
            get { return _Cod_Conexao_Configuracoes; }
            set { _Cod_Conexao_Configuracoes = value; }
        }

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public int Cod_Servico
        {
            get { return _Cod_Servico; }
            set { _Cod_Servico = value; }
        }

        public string Desc_Servico
        {
            get { return _Desc_Servico; }
            set { _Desc_Servico = value; }
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

        public decimal Quantidade
        {
            get { return _Quantidade; }
            set { _Quantidade = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Servico = 0;
            _Desc_Servico = null;
            _Valor_Unitario = 0;
            _Cod_Conexao_Configuracoes = 0;
            _Valor_Total = 0;
            _Quantidade = 0;
            _Comissao_Porc = 0;
            _Valor_Acrescimo = 0;
            _Valor_Desconto = 0;
            _Valor_Total_A_Desc_Acresc = 0;
            _Cod_Orcamento = 0;
        }
    }
}
