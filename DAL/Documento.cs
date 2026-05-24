using System;

namespace DAL
{
    public class Documento : IDisposable
    {
        private int _Codigo;
        private string _Descricao;
        private string _Data;
        private string _Horario;
        private string _Situacao;
        private short _Cod_Grupo;
        private string _Desc_Grupo;
        private short _Cod_SubGrupo;
        private string _Desc_SubGrupo;
        private string _Observacao;
        private byte[] _Arq_Documento;
        private string _Nome_Arquivo;

        public string Nome_Arquivo
        {
            get { return _Nome_Arquivo; }
            set { _Nome_Arquivo = value; }
        }

        public byte[] Arq_Documento
        {
            get { return _Arq_Documento; }
            set { _Arq_Documento = value; }
        }

        public int Codigo
        { 
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Descricao 
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public string Data 
        {
            get { return _Data; }
            set { _Data = value; }
        }

        public string Horario
        {
            get { return _Horario; }
            set { _Horario = value; }
        }

        public string Situacao
        {
            get { return _Situacao; }
            set { _Situacao = value; }
        }

        public short Cod_Grupo 
        {
            get { return _Cod_Grupo; }
            set { _Cod_Grupo = value; }
        }

        public string Desc_Grupo
        {
            get { return _Desc_Grupo; }
            set { _Desc_Grupo = value; }
        }

        public short Cod_SubGrupo
        { 
            get { return _Cod_SubGrupo; }
            set { _Cod_SubGrupo = value; }
        }

        public string Desc_SubGrupo
        {
            get { return _Desc_SubGrupo; }
            set { _Desc_SubGrupo = value; }
        }

        public string Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Descricao = null;
            _Data = null;
            _Horario = null;
            _Situacao = null;
            _Cod_Grupo = 0;
            _Desc_Grupo = null;
            _Cod_SubGrupo = 0;
            _Desc_SubGrupo = null;
            _Observacao = null;
            _Arq_Documento = null;
            _Nome_Arquivo = null;
        }
    }
}
