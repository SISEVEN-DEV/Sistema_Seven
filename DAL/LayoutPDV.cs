using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LayoutPDV : IDisposable
    {
        private byte _Layout_Tipo;
        private short _Cod_Conexao_Configuracoes;

        public byte Layout_Tipo
        {
            get { return _Layout_Tipo; }
            set { _Layout_Tipo = value; }
        }

        public short Cod_Conexao_Configuracoes
        {
            get { return _Cod_Conexao_Configuracoes; }
            set { _Cod_Conexao_Configuracoes = value; }
        }

        public void Dispose()
        {
            _Layout_Tipo = 0;
            _Cod_Conexao_Configuracoes = 0;
        }
    }
}
