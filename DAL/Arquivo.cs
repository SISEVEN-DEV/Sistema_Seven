using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Arquivo : IDisposable
    {
        private short _Codigo;
        private string _Descricao;
        private string _Tabela;
        private string _Caminho;
        private string _Observacao;
        private string _Palavra_Chave;
        private string _Pesquisar;
        private byte _Excluir_Arquivo_Dir;
        private byte _Sel_Varios_Tipo_Arq;

        public byte Excluir_Arquivo_Dir 
        {
            get { return _Excluir_Arquivo_Dir; }
            set { _Excluir_Arquivo_Dir = value; }
        }

        public byte Sel_Varios_Tipo_Arq 
        {
            get { return _Sel_Varios_Tipo_Arq; }
            set { _Sel_Varios_Tipo_Arq = value; }
        }

        public short Codigo 
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public string Tabela
        {
            get { return _Tabela; }
            set { _Tabela = value; }
        }

        public string Caminho
        {
            get { return _Caminho; }
            set { _Caminho = value; }
        }

        public string Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        public string Palavra_Chave
        {
            get { return _Palavra_Chave; }
            set { _Palavra_Chave = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public void Dispose() 
        {
            _Codigo = 0;
            _Descricao = null;
            _Tabela = null;
            _Caminho = null;
            _Observacao = null;
            _Palavra_Chave = null;
            _Pesquisar = null;
            _Excluir_Arquivo_Dir = 0;
            _Sel_Varios_Tipo_Arq = 0;
        }
    }
}
