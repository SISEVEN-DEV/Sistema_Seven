using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Disciplina : IDisposable
    {
        private short _Codigo;
        private string _Palavra_Chave;
        private string _Descricao;
        private string _Tipo_Disciplina;
        private string _Carga_Horaria;
        private string _Observacao;
        private string _Pesquisar;

        public short Codigo 
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Palavra_Chave 
        {
            get { return _Palavra_Chave; }
            set { _Palavra_Chave = value; }
        }

        public string Descricao 
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public string Tipo_Disciplina 
        {
            get { return _Tipo_Disciplina; }
            set { _Tipo_Disciplina = value; }
        }

        public string Carga_Horaria 
        {
            get { return _Carga_Horaria; }
            set { _Carga_Horaria = value; }
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
            _Descricao = null;
            _Carga_Horaria = null;
            _Tipo_Disciplina = null;
            _Observacao = null;
            _Pesquisar = null;
        }
    }
}
