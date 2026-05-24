using System;

namespace DAL
{
    public class Produto : IDisposable
    {
        private int _Codigo;
        private string _Palavra_Chave;
        private string _Descricao;
        private string _UM;
        private short _Cod_Marca;
        private string _Desc_Marca;
        private short _Cod_Localizacao;
        private string _Desc_Localizacao;
        private short _Cod_Grupo;
        private string _Desc_Grupo;
        private short _Cod_SubGrupo;
        private string _Desc_SubGrupo;
        private string _Cod_Barra;
        private decimal _Preco;
        private string _Referencia;
        private string _Pesquisar;
        private byte [] _Imagem_Prod;
        private string _Observacao;
        private decimal _Estoque_Min;
        private decimal _Estoque_Max;
        private decimal _Saldo_Atual;
        private string _Data_Cadastro;
        private decimal _Acrescimo_Porc;
        private decimal _Desconto_Porc;
        private byte _Alertar_Estoque;
        private byte _Dest_Est_Baixo;
        private string _NCM;
        private string _CEST;
        private string _CST;
        private decimal _Aliquota;
        private string _CSOSN;
        private byte _Importado_DFe;
        private string _Excecao_NCM;
        private string _CST_IBS_CBS;
        private string _CClass_Trib;
        private decimal _Aliq_IBS_Mun;
        private decimal _Aliq_IBS_Est;
        private decimal _Aliq_CBS;
        private string _Data_Ult_Alteracao;
        private string _Situacao;

        public string Situacao
        {
            get { return _Situacao; }
            set { _Situacao = value; }
        }

        public string CST_IBS_CBS 
        {
            get { return _CST_IBS_CBS; }
            set { _CST_IBS_CBS = value; }
        }

        public string CClass_Trib 
        {
            get { return _CClass_Trib; }
            set { _CClass_Trib = value; }
        }

        public decimal Aliq_IBS_Mun 
        {
            get { return _Aliq_IBS_Mun; }
            set { _Aliq_IBS_Mun = value; }
        }

        public decimal Aliq_IBS_Est 
        {
            get { return _Aliq_IBS_Est; }
            set { _Aliq_IBS_Est = value; }
        }

        public decimal Aliq_CBS 
        {
            get { return _Aliq_CBS; }
            set { _Aliq_CBS = value; }
        }

        public byte Importado_DFe
        {
            get { return _Importado_DFe; }
            set { _Importado_DFe = value; }
        }

        public string NCM
        {
            get { return _NCM; }
            set { _NCM = value; }
        }

        public string CEST
        {
            get { return _CEST; }
            set { _CEST = value; }
        }

        public string CST
        {
            get { return _CST; }
            set { _CST = value; }
        }

        public decimal Aliquota
        {
            get { return _Aliquota; }
            set { _Aliquota = value; }
        }

        public string CSOSN
        {
            get { return _CSOSN; }
            set { _CSOSN = value; }
        }

        public byte Alertar_Estoque
        {
            get { return _Alertar_Estoque; }
            set { _Alertar_Estoque = value; }
        }

        public byte Dest_Est_Baixo
        {
            get { return _Dest_Est_Baixo; }
            set { _Dest_Est_Baixo = value; }
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

        public string Data_Cadastro
        {
            get { return _Data_Cadastro; }
            set { _Data_Cadastro = value; }
        }

        public short Cod_Localizacao
        {
            get { return _Cod_Localizacao; }
            set { _Cod_Localizacao = value; }
        }

        public string Desc_Localizacao
        {
            get { return _Desc_Localizacao; }
            set { _Desc_Localizacao = value; }
        }

        public decimal Estoque_Min
        {
            get { return _Estoque_Min; }
            set { _Estoque_Min = value; }
        }

        public decimal Estoque_Max
        {
            get { return _Estoque_Max; }
            set { _Estoque_Max = value; }
        }

        public decimal Saldo_Atual
        {
            get { return _Saldo_Atual; }
            set { _Saldo_Atual = value; }
        }


        public string Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Palavra_Chave
        {
            get { return _Palavra_Chave; }
            set { _Palavra_Chave = value; }
        }

        public short Cod_SubGrupo
        {
            get { return _Cod_SubGrupo; }
            set { _Cod_SubGrupo = value; }
        }

        public string Descricao
        {
            get { return _Descricao; }
            set { _Descricao = value; }
        }

        public string UM
        {
            get { return _UM; }
            set { _UM = value; }
        }

        public short Cod_Marca
        {
            get { return _Cod_Marca; }
            set { _Cod_Marca = value; }
        }

        public string Desc_Marca
        {
            get { return _Desc_Marca; }
            set { _Desc_Marca = value; }
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

        public string Desc_SubGrupo
        {
            get { return _Desc_SubGrupo; }
            set { _Desc_SubGrupo = value; }
        }

        public string Cod_Barra
        {
            get { return _Cod_Barra; }
            set { _Cod_Barra = value; }
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

        public string Observacao
        {
            get { return _Observacao; }
            set { _Observacao = value; }
        }

        public byte [] Imagem_Prod
        {
            get { return _Imagem_Prod; }
            set { _Imagem_Prod = value; }
        }

        public string Excecao_NCM
        {
            get { return _Excecao_NCM; }
            set { _Excecao_NCM = value; }
        }

        public string Data_Ult_Alteracao 
        {
            get { return _Data_Ult_Alteracao; }
            set { _Data_Ult_Alteracao = value; }
        }

        public void Dispose()
        {
            _Codigo = 0;
            _Palavra_Chave = null;
            _Descricao = null;
            _UM = null;
            _Cod_Marca = 0;
            _Desc_Marca = null;
            _Cod_Grupo = 0;
            _Desc_Grupo = null;
            _Cod_SubGrupo = 0;
            _Desc_SubGrupo = null;
            _Cod_Barra = null;
            _Preco = 0;
            _Pesquisar = null;
            _Imagem_Prod = null;
            _Observacao = null;
            _Referencia = null;
            _Estoque_Min = 0;
            _Estoque_Max = 0;
            _Saldo_Atual = 0;
            _Data_Cadastro = null;
            _Cod_Localizacao = 0;
            _Desc_Localizacao = null;
            _Acrescimo_Porc = 0;
            _Desconto_Porc = 0;
            _Alertar_Estoque = 0;
            _Dest_Est_Baixo = 0;
            _Importado_DFe = 0;
            _Excecao_NCM = null;
            _CST_IBS_CBS = null;
            _CClass_Trib = null;
            _Aliq_IBS_Mun = 0;
            _Aliq_IBS_Est = 0;
            _Aliq_CBS = 0;
            _Data_Ult_Alteracao = null;
            _Situacao = null;
        }
    }
}
