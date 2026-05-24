using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Servico : IDisposable
    {
        private int _Codigo;
        private string _Descricao;
        private decimal _Preco;
        private string _Pesquisar;
        private string _Data_Cadastro;
        private int _Cod_Item_Servico;
        private string _Desc_Item_Servico;
        private decimal _Aliquota;
        private decimal _Comissao;
        private decimal _Acrescimo_Porc;
        private decimal _Desconto_Porc;
        private short _Cod_Grupo;
        private string _Desc_Grupo;
        private short _Cod_SubGrupo;
        private string _Desc_SubGrupo;
        private string _Situacao;

        public string Situacao
        {
            get { return _Situacao; }
            set { _Situacao = value; }
        }

        public string Desc_Grupo
        {
            get { return _Desc_Grupo; }
            set { _Desc_Grupo = value; }
        }

        public short Cod_Grupo
        {
            get { return _Cod_Grupo; }
            set { _Cod_Grupo = value; }
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

        public decimal Acrescimo_Porc
        {
            get { return _Acrescimo_Porc; }
            set { _Acrescimo_Porc = value; }
        }

        public decimal Desconto_Porc
        {
            get { return _Desconto_Porc; }
            set { _Desconto_Porc = value; }
        }

        public decimal Comissao
        {
            get { return _Comissao; }
            set { _Comissao = value; }
        }


        public decimal Aliquota
        {
            get { return _Aliquota; }
            set { _Aliquota = value; }
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

        public decimal Preco
        {
            get { return _Preco; }
            set { _Preco = value; }
        }

        public string Pesquisar
        {
            get { return _Pesquisar; }
            set { _Pesquisar = value; }
        }

        public string Data_Cadastro
        {
            get { return _Data_Cadastro; }
            set { _Data_Cadastro = value; }
        }

        public int Cod_Item_Servico
        {
            get { return _Cod_Item_Servico; }
            set { _Cod_Item_Servico = value; }
        }

        public string Desc_Item_Servico
        {
            get { return _Desc_Item_Servico; }
            set { _Desc_Item_Servico = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Descricao = null;
            _Pesquisar = null;
            _Preco = 0;
            _Data_Cadastro = null;
            _Cod_Item_Servico = 0;
            _Desc_Item_Servico = null;
            _Aliquota = 0;
            _Comissao = 0;
            _Acrescimo_Porc = 0;
            _Desconto_Porc = 0;
            _Cod_Grupo = 0;
            _Desc_Grupo = null;
            _Cod_SubGrupo = 0;
            _Desc_SubGrupo = null;
            _Situacao = null;
        }
    }
}
