using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Curso : IDisposable
    {
        private short _Codigo;
        private string _Palavra_Chave;
        private string _Descricao;
        private decimal _Valor_Curso;
        private string _Sigla;        
        private string _Observacao;
        private string _Pesquisar; 
        
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

        public decimal Valor_Curso 
        {
            get { return _Valor_Curso; }
            set { _Valor_Curso = value; }
        }
  
        public string Sigla 
        {
            get { return _Sigla; }
            set { _Sigla = value; }
        }

        public string Palavra_Chave 
        {
            get { return _Palavra_Chave;}
            set { _Palavra_Chave = value;}
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
            _Codigo = 0;
            _Palavra_Chave = null;           
            _Sigla = null;
            _Valor_Curso = 0;
            _Observacao = null;
            _Pesquisar = null;            
        }
    }
}
