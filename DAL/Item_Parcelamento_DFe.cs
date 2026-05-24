using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Item_Parcelamento_DFe : IDisposable
    {
        private short _Ocorrencia_Parc;
        private string _Data_Vencimento;
        private decimal _Valor;
        public short _Cod_Conexao_Configuracoes;

        public short Cod_Conexao_Configuracoes
        {
            get { return _Cod_Conexao_Configuracoes; }
            set { _Cod_Conexao_Configuracoes = value; }
        }

        public short Ocorrencia_Parc
        {
            get { return _Ocorrencia_Parc; }
            set { _Ocorrencia_Parc = value; }
        }

        public string Data_Vencimento
        {
            get { return _Data_Vencimento; }
            set { _Data_Vencimento = value; }
        }

        public decimal Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        public void Dispose()
        {
            _Ocorrencia_Parc = 0;
            _Data_Vencimento = null;
            _Valor = 0;
            _Cod_Conexao_Configuracoes = 0;
        }
    }
}
