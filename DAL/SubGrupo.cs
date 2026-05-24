using System;

namespace DAL
{
    public class SubGrupo : IDisposable
    {
        private short _Codigo;
        private string _Descricao;
        private string _Palavra_Chave;
        private short _Cod_Grupo;
        private string _Desc_Grupo;
        private string _Pesquisar;
        private string _Data_Cadastro;

        private byte _Excluir_SubGrupo_Cascata;
        private short _Margem_Esq;
        private short _Margem_Topo;
        private short _Margem_Esq_Imp_Mat;
        private short _Margem_Topo_Imp_Mat;
        private short _Margem_Esq_Pdf_80;
        private short _Margem_Topo_Pdf_80;
        private byte _Usar_Axacropdf;

        public byte Excluir_SubGrupo_Cascata
        {
            get { return _Excluir_SubGrupo_Cascata; }
            set { _Excluir_SubGrupo_Cascata = value; }
        }

        public short Margem_Esq
        {
            get { return _Margem_Esq; }
            set { _Margem_Esq = value; }
        }

        public short Margem_Topo
        {
            get { return _Margem_Topo; }
            set { _Margem_Topo = value; }
        }

        public short Margem_Esq_Imp_Mat
        {
            get { return _Margem_Esq_Imp_Mat; }
            set { _Margem_Esq_Imp_Mat = value; }
        }

        public short Margem_Topo_Imp_Mat
        {
            get { return _Margem_Topo_Imp_Mat; }
            set { _Margem_Topo_Imp_Mat = value; }
        }

        public short Margem_Esq_Pdf_80
        {
            get { return _Margem_Esq_Pdf_80; }
            set { _Margem_Esq_Pdf_80 = value; }
        }

        public short Margem_Topo_Pdf_80
        {
            get { return _Margem_Topo_Pdf_80; }
            set { _Margem_Topo_Pdf_80 = value; }
        }

        public byte Usar_Axacropdf
        {
            get { return _Usar_Axacropdf; }
            set { _Usar_Axacropdf = value; }
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

        public string Data_Cadastro
        {
            get { return _Data_Cadastro; }
            set { _Data_Cadastro = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Descricao = null;
            _Cod_Grupo = 0;
            _Desc_Grupo = null;
            _Pesquisar = null;
            _Palavra_Chave = null;
            _Data_Cadastro = null;
            _Excluir_SubGrupo_Cascata = 0;
            _Margem_Esq = 0;
            _Margem_Topo = 0;
            _Margem_Topo_Imp_Mat = 0;
            _Margem_Topo_Imp_Mat = 0;
            _Margem_Esq_Pdf_80 = 0;
            _Margem_Topo_Pdf_80 = 0;
            _Usar_Axacropdf = 0;
        }
    }
}
