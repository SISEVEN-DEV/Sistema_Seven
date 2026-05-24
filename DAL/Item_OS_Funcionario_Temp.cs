using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Item_OS_Funcionario_Temp : IDisposable
    {
        private short _Codigo;
        private int _Cod_Funcionario;
        private string _Nome_Funcionario;
        private string _Imagem_Func;
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

        public int Cod_Funcionario
        {
            get { return _Cod_Funcionario; }
            set { _Cod_Funcionario = value; }
        }

        public string Nome_Funcionario
        {
            get { return _Nome_Funcionario; }
            set { _Nome_Funcionario = value; }
        }

        public string Imagem_Func
        {
            get { return _Imagem_Func; }
            set { _Imagem_Func = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Cod_Funcionario = 0;
            _Nome_Funcionario = null;
            _Cod_Conexao_Configuracoes = 0;
            _Imagem_Func = null;
        }
    }
}
