using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReferenciaDFe_Temp : IDisposable
    {
        private short _Codigo;
        private string _Chave_DFe;
        private short _Cod_Conexao_Configuracoes;

        public short Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Chave_DFe
        {
            get { return _Chave_DFe; }
            set { _Chave_DFe = value; }
        }

        public short Cod_Conexao_Configuracoes
        {
            get { return _Cod_Conexao_Configuracoes; }
            set { _Cod_Conexao_Configuracoes = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Chave_DFe = null;
            _Cod_Conexao_Configuracoes = 0;
        }
    }
}
