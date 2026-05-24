using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Item_DFe_Pgto_Temp : IDisposable
    {
        private short _Codigo;
        private short _Cod_Pagamento;
        private string _Tipo;
        private decimal _Valor_Pago;
        private short _Cod_Conexao_Configuracoes;

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

        public short Cod_Pagamento
        {
            get { return _Cod_Pagamento; }
            set { _Cod_Pagamento = value; }
        }

        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }

        public decimal Valor_Pago
        {
            get { return _Valor_Pago; }
            set { _Valor_Pago = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Pagamento = 0;
            _Tipo = null;
            _Valor_Pago = 0;
            _Cod_Conexao_Configuracoes = 0;
        }
    }
}
